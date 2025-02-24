﻿
Imports System.ComponentModel
Imports JM.LinqFaster
Imports StaxRip.UI

Public Class SimpleUI
    Inherits Control

    Public WithEvents Tree As New TreeViewEx
    Property Host As New Panel

    Public Event SaveValues()
    Public Event ValueChanged()

    Public Pages As New List(Of IPage)(16)

    Public ActivePage As IPage
    Public Store As Object

    Property FormSizeScaleFactor As SizeF

    Sub New()

        Tree.BeginUpdate()
        Host.SuspendLayout() 'Test This !!! TODO :
        SuspendLayout()
        'Parent?.SuspendLayout() No Parent Here ??? no good idea? in simplesettform is suspend

        InitControls()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Sub InitControls()
        Tree.Scrollable = False
        Tree.SelectOnMouseDown = True
        Tree.ShowLines = False
        Tree.HideSelection = False
        Tree.FullRowSelect = True
        Tree.ShowPlusMinus = False
        Tree.AutoCollaps = True
        Tree.ExpandMode = TreeNodeExpandMode.InclusiveChilds
        Controls.Add(Tree)
        Controls.Add(Host)
    End Sub

    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        MyBase.OnHandleCreated(e)

        If Not DesignMode Then
            Dim fF As Form = FindForm()
            Dim eh As EventHandler = Sub()
                                         If Tree.Nodes.Count > 0 Then
                                             Tree.ItemHeight = CInt(Tree.Height / (Tree.Nodes.Count)) - 2
                                         End If


                                         Dim tFH As Integer = If(s.UIScaleFactor <> 1, Tree.Font.Height, 16) 'Tree.Font.Height
                                         If Tree.ItemHeight > CInt(tFH * 1.5) Then
                                             Tree.ItemHeight = CInt(tFH * 1.5)
                                         End If
                                         RemoveHandler fF.Load, eh 'Test !!!
                                     End Sub

            AddHandler fF.Load, eh

            Host.ResumeLayout(False) 'Test This !!! TODO :
            ResumeLayout()
            Tree.EndUpdate()
            'Parent.ResumeLayout(False) 'No way ???

        End If
    End Sub

    Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
        Tree.BeginUpdate() 'ToDo Test this, Seems double Susp + in New contructor!!! = only SimpleUI OK??
        Host.SuspendLayout()

        Tree.Location = Point.Empty
        Dim fh As Integer = FontHeight

        If Tree.Nodes.Count > 1 Then
            Tree.Size = New Size(Tree.GetNodes.MaxF(Function(i) i.Bounds.Right) + fh, Height)
        Else
            Tree.Size = New Size(0, Height)
        End If

        Host.Location = New Point(Tree.Right + CInt(fh / 3), 0)
        Host.Size = New Size(Width - Tree.Width - CInt(fh / 3), Height)

        MyBase.OnLayout(levent)
        Host.ResumeLayout(False) 'ToDo Test this!!!
        Tree.EndUpdate()
    End Sub

    Sub Save()
        RaiseEvent SaveValues()
    End Sub

    Sub RaiseChangeEvent()
        RaiseEvent ValueChanged()
    End Sub

    Sub Tree_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree.AfterSelect
        Tree.BeginUpdate() 'Test this 

        Dim node = e.Node
        For Each i In Pages
            If i.Node IsNot node Then
                DirectCast(i, Control).Visible = False
            End If
        Next i
        Dim nodeExists As Boolean
        Dim fF = FindForm() 'test This !!!
        For Each i In Pages
            If i.Node Is node Then
                If Not i.FormSizeScaleFactor.IsEmpty Then
                    fF.ScaleClientSize(i.FormSizeScaleFactor.Width, i.FormSizeScaleFactor.Height)
                ElseIf Not FormSizeScaleFactor.IsEmpty Then
                    fF.ScaleClientSize(FormSizeScaleFactor.Width, FormSizeScaleFactor.Height)
                End If

                DirectCast(i, Control).Visible = True
                DirectCast(i, Control).BringToFront()
                ActivePage = i
                PerformLayout()

                nodeExists = True
                Exit For
            End If
        Next i
        ''If Pages.Where(Function(arg) arg.Node Is node).Count = 0 Then
        If Not nodeExists Then
            If node.Nodes.Count > 0 Then
                Tree.SelectedNode = node.Nodes(0)
            End If
        End If

        Tree.EndUpdate() 'Test this 
    End Sub

    Sub ShowPage(pagePath As String)
        For Each i In Pages
            If String.Equals(i.Path, pagePath) Then
                Tree.SelectedNode = i.Node
                Exit For 'Test this
            End If
        Next
    End Sub

    Sub ShowPage(page As IPage)
        For Each i In Pages
            If page Is i Then
                Tree.SelectedNode = i.Node
                Exit For 'Test this
            End If
        Next
    End Sub

    Sub SelectLast(id As String)
        Dim last = s.Storage.GetString(id)

        If last?.Length > 0 Then
            ShowPage(last)
        ElseIf Pages.Count > 0 Then
            ShowPage(Pages(0))
        End If
    End Sub

    Sub SaveLast(id As String)
        If ActivePage IsNot Nothing Then
            s.Storage.SetString(id, ActivePage.Path)
        End If
    End Sub

    Function GetActiveFlowPage() As FlowPage
        If ActivePage Is Nothing Then
            ActivePage = CreateFlowPage("main page")
        End If

        Return DirectCast(ActivePage, FlowPage)
    End Function

    Function GetFlowPage(path As String) As FlowPage
        If path.NullOrEmptyS Then
            path = "unknown"
        End If

        Dim q = Pages.FirstOrDefaultF(Function(i) String.Equals(i.Path, path))

        If q IsNot Nothing Then
            Return DirectCast(q, FlowPage)
        Else
            Return CreateFlowPage(path, autoSuspend:=  True)
        End If
    End Function

    Public SaveValEventHList As List(Of SaveValuesEventHandler) 'Debug Test
    Public Function SaveValEventsHLCreate(Optional capacity As Integer = 0) As List(Of SaveValuesEventHandler)
        SaveValEventHList = If(capacity = 0, New List(Of SaveValuesEventHandler), New List(Of SaveValuesEventHandler)(capacity))
        Return SaveValEventHList
    End Function
    Public Sub SaveValEventsHLRemove()
        If SaveValEventHList IsNot Nothing Then
            For h = 0 To SaveValEventHList.Count - 1
                RemoveHandler SaveValues, SaveValEventHList(h)
            Next h
            SaveValEventHList = Nothing
        End If
    End Sub

    Function AddBool(Optional parent As FlowLayoutPanelEx = Nothing) As SimpleUICheckBox
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New SimpleUICheckBox(Me)

        Dim sveh As SaveValuesEventHandler = AddressOf ret.Save
        If SaveValEventHList IsNot Nothing Then SaveValEventHList.Add(sveh)

        AddHandler SaveValues, sveh
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddEdit(parent As FlowLayoutPanelEx) As SimpleUITextEdit
        Dim ret As New SimpleUITextEdit(Me)
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddNumeric(parent As FlowLayoutPanelEx) As SimpleUINumEdit
        Dim ret As New SimpleUINumEdit(Me)
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddLabel(text As String) As SimpleUILabel
        Return AddLabel(Nothing, text)
    End Function

    Function AddLabel(parent As FlowLayoutPanelEx, text As String, Optional widthInFontHeights As Integer = 0) As SimpleUILabel

        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New SimpleUILabel With {.Offset = widthInFontHeights, .Text = text}
        parent.Controls.Add(ret)

        Return ret
    End Function

    Function AddNum(Optional parent As FlowLayoutPanelEx = Nothing) As NumBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New NumBlock(Me) With {.AutoSize = True, .UseParenWidth = True}

        Dim sveh As SaveValuesEventHandler = AddressOf ret.NumEdit.Save
        If SaveValEventHList IsNot Nothing Then SaveValEventHList.Add(sveh)

        AddHandler SaveValues, sveh
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddText(Optional parent As FlowLayoutPanelEx = Nothing) As TextBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New TextBlock(Me) With {.AutoSize = True, .UseParenWidth = True}
        AddHandler SaveValues, AddressOf ret.Edit.Save
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddTextMenu(Optional parent As FlowLayoutPanelEx = Nothing) As TextMenuBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New TextMenuBlock(Me) With {.AutoSize = True, .UseParenWidth = True}
        AddHandler SaveValues, AddressOf ret.Edit.Save
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddColorPicker(Optional parent As FlowLayoutPanelEx = Nothing) As ColorPickerBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New ColorPickerBlock(Me) With {.AutoSize = True, .UseParenWidth = True}
        AddHandler SaveValues, AddressOf ret.Save
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddButton(Optional parent As FlowLayoutPanelEx = Nothing) As ButtonBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New ButtonBlock(Me) With {.AutoSize = True, .UseParenWidth = True}
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddTextButton(Optional parent As FlowLayoutPanelEx = Nothing) As TextButtonBlock
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New TextButtonBlock(Me) With {.AutoSize = True, .UseParenWidth = True}
        AddHandler SaveValues, AddressOf ret.Edit.Save
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddMenu(Of T)(Optional parent As FlowLayoutPanelEx = Nothing) As MenuBlock(Of T)
        If parent Is Nothing Then
            parent = GetActiveFlowPage()
        End If

        Dim ret As New MenuBlock(Of T)(Me) With {.AutoSize = True, .UseParenWidth = True}

        Dim sveh As SaveValuesEventHandler = AddressOf ret.Button.Save
        If SaveValEventHList IsNot Nothing Then SaveValEventHList.Add(sveh)

        AddHandler SaveValues, AddressOf ret.Button.Save
        parent.Controls.Add(ret)
        Return ret
    End Function

    Function AddEmptyBlock(parent As FlowLayoutPanelEx) As EmptyBlock
        Dim ret As New EmptyBlock With {.AutoSize = True, .UseParenWidth = True}
        parent.Controls.Add(ret)
        Return ret
    End Function

    Sub AddLine(parent As FlowLayoutPanelEx, Optional text As String = "")
        Dim line As New SimpleUILineControl With {.Text = text, .Expand = True}
        parent.Controls.Add(line)
    End Sub

    Function CreateFlowPage(Optional path As String = "-", Optional autoSuspend As Boolean = False) As FlowPage

        Dim ret = New FlowPage With {.AutoSuspend = autoSuspend, .Path = path}
        If autoSuspend Then
            ret.SuspendLayout()
        End If

        Pages.Add(ret)
        ret.Dock = DockStyle.Fill
        ret.Node = Tree.AddNode(path)
        Host.Controls.Add(ret)
        ActivePage = ret
        Return ret
    End Function

    Function AddControlPage(ctrl As IPage, path As String) As IPage
        Pages.Add(ctrl)
        ctrl.Path = path
        DirectCast(ctrl, Control).Dock = DockStyle.Fill
        ctrl.Node = Tree.AddNode(path)
        Host.Controls.Add(DirectCast(ctrl, Control))
        Return ctrl
    End Function

    Function CreateDataPage(path As String) As DataPage
        Dim ret = New DataPage With {.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells, .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells,
                                     .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize, .Path = path, .Dock = DockStyle.Fill}
        Pages.Add(ret)
        ret.Node = Tree.AddNode(path)
        Host.Controls.Add(ret)
        ActivePage = ret
        Return ret
    End Function

    Public Class DataPage
        Inherits DataGridViewEx
        Implements IPage

        Property Node As TreeNode Implements IPage.Node
        Property Path As String Implements IPage.Path
        Property TipProvider As TipProvider Implements IPage.TipProvider

        Public Property FormSizeScaleFactor As SizeF Implements IPage.FormSizeScaleFactor

        Sub New()
            DirectCast(Me, ISupportInitialize).BeginInit()
            TipProvider = New TipProvider(Nothing)
            Dim deh As EventHandler = Sub()
                                          RemoveHandler Me.Disposed, deh
                                          TipProvider.Dispose()
                                      End Sub
            AddHandler Disposed, deh
        End Sub
    End Class

    Public Class FlowPage
        Inherits FlowLayoutPanelEx
        Implements IPage

        Property Node As TreeNode Implements IPage.Node
        Property Path As String Implements IPage.Path
        Property TipProvider As TipProvider Implements IPage.TipProvider
        Property AutoSuspend As Boolean

        Public Property FormSizeScaleFactor As SizeF Implements IPage.FormSizeScaleFactor

        Sub New()
            TipProvider = New TipProvider(Nothing)
            Dim deh As EventHandler = Sub()
                                          RemoveHandler Me.Disposed, deh
                                          TipProvider.Dispose()
                                      End Sub
            AddHandler Disposed, deh
            FlowDirection = FlowDirection.TopDown
        End Sub

        Protected Overrides Sub OnCreateControl()
            MyBase.OnCreateControl()

            If AutoSuspend Then
                ResumeLayout(False) ' no false ???
            End If
        End Sub

    End Class

    Public Class SimpleUILineControl
        Inherits LineControl
        Implements SimpleUIControl

        Property Expand As Boolean Implements SimpleUIControl.Expand

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            Height = If(s.UIScaleFactor <> 1, FontHeight * 2, 16 * 2)  'FontHeight * 2
            MyBase.OnLayout(levent)
        End Sub
    End Class

    Public Class SimpleUICheckBox
        Inherits CheckBoxEx

        Property MarginLeft As Double
        Property SaveAction As Action(Of Boolean)
        Property HelpAction As Action

        Private ReadOnly SimpleUI As SimpleUI

        Sub New(ui As SimpleUI)
            AutoSize = True
            SimpleUI = ui
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If e.Button = MouseButtons.Right AndAlso Not HelpAction Is Nothing Then
                HelpAction.Invoke
            End If
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight
            Margin = New Padding(CInt(fh / 8)) With {.Left = If(MarginLeft <> 0, CInt(MarginLeft), CInt(fh / 4))}
            MyBase.OnLayout(levent)
        End Sub

        Protected Overrides Sub OnCheckedChanged(e As EventArgs)
            MyBase.OnCheckedChanged(e)
            SimpleUI.RaiseChangeEvent()
        End Sub

        Sub Save()
            SaveAction?.Invoke(Checked)

            If Field?.Length > 0 Then
                SimpleUI.Store.GetType.GetField(Field).SetValue(SimpleUI.Store, Checked)
            ElseIf [Property]?.Length > 0 Then
                SimpleUI.Store.GetType.GetProperty([Property]).SetValue(SimpleUI.Store, Checked)
            End If
        End Sub

        Private FieldValue As String

        Property Field As String
            Get
                Return FieldValue
            End Get
            Set(value As String)
                Checked = CBool(SimpleUI.Store.GetType.GetField(value).GetValue(SimpleUI.Store))
                FieldValue = value
            End Set
        End Property

        Private PropertyValue As String

        Property [Property] As String
            Get
                Return PropertyValue
            End Get
            Set(value As String)
                Checked = CBool(SimpleUI.Store.GetType.GetProperty(value).GetValue(SimpleUI.Store))
                PropertyValue = value
            End Set
        End Property

        WriteOnly Property Help As String
            Set(value As String)
                Dim parent = Me.Parent

                While Not TypeOf parent Is IPage
                    parent = parent.Parent
                End While

                If value.StartsWith("http", StringComparison.Ordinal) Then
                    value = $"[{value} {value}]"
                End If

                DirectCast(parent, IPage).TipProvider.SetTip(value, Me)
            End Set
        End Property

        Private OffsetValue As Integer

        Property Offset As Integer 'not used ????
            Get
                Return OffsetValue
            End Get
            Set(value As Integer)
                OffsetValue = value
                PerformLayout()
            End Set
        End Property

        Overrides Function GetPreferredSize(proposedSize As Size) As Size
            If Offset > 0 Then
                Dim ret = MyBase.GetPreferredSize(proposedSize)
                Dim fhof As Integer = Offset * If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight

                If ret.Width < fhof Then
                    ret.Width = fhof
                End If

                Return ret
            Else
                Return MyBase.GetPreferredSize(proposedSize)
            End If
        End Function
    End Class

    Public Class SimpleUINumEdit
        Inherits NumEdit

        Private ReadOnly SimpleUI As SimpleUI

        Property SaveAction As Action(Of Double)

        Sub New(ui As SimpleUI)
            SimpleUI = ui
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            'dialog size
            Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight  '=Font.Height 'Experimant - NoScaling!!! Test This!!!
            Size = New Size(CInt(fh * 4.5), CInt(fh * 1.3))
            MyBase.OnLayout(levent)
        End Sub

        Sub Save()
            SaveAction?.Invoke(Value)

            If Field?.Length > 0 Then
                Dim field = SimpleUI.Store.GetType.GetField(Me.Field)
                field.SetValue(SimpleUI.Store, Convert.ChangeType(Value, field.FieldType))
            ElseIf [Property]?.Length > 0 Then
                Dim prop = SimpleUI.Store.GetType.GetProperty([Property])
                prop.SetValue(SimpleUI.Store, Convert.ChangeType(Value, prop.PropertyType))
            End If
        End Sub

        Private PropertyValue As String

        Property [Property] As String
            Get
                Return PropertyValue
            End Get
            Set(value As String)
                Me.Value = CDbl(SimpleUI.Store.GetType.GetProperty(value).GetValue(SimpleUI.Store))
                PropertyValue = value
            End Set
        End Property

        Private FieldValue As String

        Property Field As String
            Get
                Return FieldValue
            End Get
            Set(value As String)
                Me.Value = CDbl(SimpleUI.Store.GetType.GetField(value).GetValue(SimpleUI.Store))
                FieldValue = value
            End Set
        End Property

        Property Config As Double()
            Get
                Return {Minimum, Maximum, Increment, DecimalPlaces}
            End Get
            Set(value As Double())
                If Not value Is Nothing Then
                    If value(0) = 0 AndAlso value(1) = 0 Then
                        value(0) = Double.MinValue
                        value(1) = Double.MaxValue
                    End If

                    If value.Length > 0 Then Minimum = value(0)
                    If value.Length > 1 Then Maximum = value(1)
                    If value.Length > 2 Then Increment = value(2)
                    If value.Length > 3 Then DecimalPlaces = CInt(value(3))
                End If
            End Set
        End Property

        Protected Overrides Sub OnValueChanged(numEdit As NumEdit)
            MyBase.OnValueChanged(numEdit)
            SimpleUI.RaiseChangeEvent()
        End Sub
    End Class

    Public Class SimpleUIButton
        Inherits ButtonEx
        Implements SimpleUIControl

        Property Expand As Boolean Implements SimpleUIControl.Expand
    End Class

    Public Class SimpleUITextEdit
        Inherits TextEdit
        Implements SimpleUIControl

        Property Expand As Boolean Implements SimpleUIControl.Expand
        Property SaveAction As Action(Of String)
        Property MultilineHeightFactor As Integer = 4
        Property WidthFactor As Integer = 10
        Property SimpleUI As SimpleUI

        Sub New(ui As SimpleUI)
            SimpleUI = ui
            AddHandler TextBox.TextChanged, Sub() SimpleUI.RaiseChangeEvent()
            AddHandler SimpleUI.SaveValues, AddressOf Save
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight
            If TextBox.Multiline Then
                Height = fh * MultilineHeightFactor
            Else
                If Not Expand Then
                    Size = New Size(fh * WidthFactor, CInt(fh * 1.45))
                Else
                    Height = CInt(fh * 1.45)
                End If
            End If

            MyBase.OnLayout(levent)
        End Sub

        Sub Save()
            SaveAction?.Invoke(Text)

            If Field?.Length > 0 Then
                SimpleUI.Store.GetType.GetField(Field).SetValue(SimpleUI.Store, Text)
            ElseIf [Property]?.Length > 0 Then
                SimpleUI.Store.GetType.GetProperty([Property]).SetValue(SimpleUI.Store, Text)
            End If

        End Sub

        Private FieldValue As String

        Property Field As String
            Get
                Return FieldValue
            End Get
            Set(value As String)
                Text = CStr(SimpleUI.Store.GetType.GetField(value).GetValue(SimpleUI.Store))
                FieldValue = value
            End Set
        End Property

        Private PropertyValue As String

        Property [Property] As String
            Get
                Return PropertyValue
            End Get
            Set(value As String)
                Text = CStr(SimpleUI.Store.GetType.GetProperty(value).GetValue(SimpleUI.Store))
                PropertyValue = value
            End Set
        End Property

        WriteOnly Property UseCommandlineEditor As Boolean
            Set(value As Boolean)
                If value Then
                    AddHandler TextBox.MouseDown, Sub() EditCommandline()
                End If
            End Set
        End Property

        WriteOnly Property UseMacroEditor As Boolean
            Set(value As Boolean)
                If value Then
                    AddHandler TextBox.Click, Sub() EditMacro()
                End If
            End Set
        End Property

        Sub EditCommandline()
            Using form As New MacroEditorDialog
                form.SetBatchDefaults()
                form.MacroEditorControl.Value = Text

                If form.ShowDialog() = DialogResult.OK Then
                    Text = form.MacroEditorControl.Value
                End If
            End Using
        End Sub

        Sub EditMacro()
            Using dialog As New MacroEditorDialog
                dialog.SetMacroDefaults()
                dialog.MacroEditorControl.Value = Text

                If dialog.ShowDialog() = DialogResult.OK Then
                    Text = dialog.MacroEditorControl.Value
                End If
            End Using
        End Sub
    End Class

    Public Class SimpleUIMenuButton(Of T)
        Inherits MenuButton
        Implements SimpleUIControl

        Property Expand As Boolean Implements SimpleUIControl.Expand
        Property SaveAction As Action(Of T)
        Property HelpAction As Action

        Private ReadOnly SimpleUI As SimpleUI

        Sub New(ui As SimpleUI)
            SimpleUI = ui
        End Sub

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If e.Button = MouseButtons.Right AndAlso Not HelpAction Is Nothing Then
                HelpAction.Invoke
            End If
        End Sub

        Protected Overrides Sub OnValueChanged(value As Object)
            MyBase.OnValueChanged(value)
            SimpleUI.RaiseChangeEvent()
        End Sub

        Shadows Property Value As T
            Get
                Return CType(MyBase.Value, T)
            End Get
            Set(value As T)
                MyBase.Value = CType(value, T)
            End Set
        End Property

        Sub Save()
            SaveAction?.Invoke(Value)

            If Field?.Length > 0 Then
                Dim field = SimpleUI.Store.GetType.GetField(Me.Field)
                field.SetValue(SimpleUI.Store, Convert.ChangeType(Value, field.FieldType))
            ElseIf [Property]?.Length > 0 Then
                Dim prop = SimpleUI.Store.GetType.GetProperty([Property])
                prop.SetValue(SimpleUI.Store, Convert.ChangeType(Value, prop.PropertyType))
            End If

        End Sub

        Private PropertyValue As String

        Property [Property] As String
            Get
                Return PropertyValue
            End Get
            Set(value As String)
                Me.Value = DirectCast(SimpleUI.Store.GetType.GetProperty(value).GetValue(SimpleUI.Store), T)
                PropertyValue = value
            End Set
        End Property

        Private FieldValue As String

        Property Field As String
            Get
                Return FieldValue
            End Get
            Set(value As String)
                Me.Value = DirectCast(SimpleUI.Store.GetType.GetField(value).GetValue(SimpleUI.Store), T)
                FieldValue = value
            End Set
        End Property
    End Class

    Public Class SimpleUILabel
        Inherits LabelEx

        Property MarginTop As Integer
        Property HelpAction As Action

        Private OffsetValue As Double

        Property Offset As Double
            Get
                Return OffsetValue
            End Get
            Set(value As Double)
                OffsetValue = value
                PerformLayout()
            End Set
        End Property

        Sub New()
            TextAlign = ContentAlignment.MiddleLeft
            AutoSize = True
        End Sub

        WriteOnly Property Help As String
            Set(value As String)
                If value.StartsWith("http", StringComparison.Ordinal) Then
                    value = $"[{value} {value}]"
                End If

                Dim parent = Me.Parent

                While TypeOf parent IsNot IPage
                    parent = parent.Parent
                End While

                DirectCast(parent, IPage).TipProvider.SetTip(value, Me)
            End Set
        End Property

        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If e.Button = MouseButtons.Right AndAlso HelpAction IsNot Nothing Then
                HelpAction.Invoke
            End If
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            Dim m = Margin
            Dim mt As Integer = MarginTop
            If m.Top <> mt Then
                m.Top = mt
                Margin = m
            End If

            MyBase.OnLayout(levent)
        End Sub

        Public Overrides Function GetPreferredSize(proposedSize As Size) As Size
            If Offset > 0 Then
                Dim ret = MyBase.GetPreferredSize(proposedSize)
                Dim fhoff As Integer = CInt(Offset * If(s.UIScaleFactor <> 1, FontHeight, 16)) 'FontHeight)

                If ret.Width < fhoff Then
                    ret.Width = fhoff
                End If

                Return ret
            Else
                Return MyBase.GetPreferredSize(proposedSize)
            End If
        End Function
    End Class

    Public Class EmptyBlock
        Inherits FlowLayoutPanelEx

        Sub New()
            Font = New Font("Segoe UI", 9.0! * s.UIScaleFactor)
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            ' Dim fh15 As Integer = 1 'if(s.UIScaleFactor <> 1,FontHeight \ 15,1)
            Dim p1 As New Padding(1) '(fh15)
            For Each ctrl As Control In Controls
                ctrl.Margin = p1
            Next

            MyBase.OnLayout(levent)
        End Sub

    End Class

    MustInherit Class LabelBlock
        Inherits EmptyBlock

        Property Label As New SimpleUILabel

        Sub New()
            Controls.Add(Label)
        End Sub

        Shadows Property Text As String
            Get
                Return Label.Text
            End Get
            Set(value As String)
                If value.EndsWith(":", StringComparison.Ordinal) Then
                    Label.Text = value
                Else
                    Label.Text = value & ":"
                End If
            End Set
        End Property

        Overridable WriteOnly Property Help As String
            Set(value As String)
                Label.Help = value
            End Set
        End Property

        Public WriteOnly Property HelpAction As Action
            Set(value As Action)
                Label.HelpAction = value
            End Set
        End Property
    End Class

    Public Class NumBlock
        Inherits LabelBlock

        Property NumEdit As SimpleUINumEdit

        Sub New(ui As SimpleUI)
            NumEdit = New SimpleUINumEdit(ui)
            Controls.Add(NumEdit)
        End Sub

        Overrides WriteOnly Property Help As String
            Set(value As String)
                Label.Help = value
                NumEdit.Help = value
            End Set
        End Property

        Property Field As String
            Get
                Return NumEdit.Field
            End Get
            Set(value As String)
                NumEdit.Field = value
            End Set
        End Property

        Property [Property] As String
            Get
                Return NumEdit.Property
            End Get
            Set(value As String)
                NumEdit.Property = value
            End Set
        End Property

        Property Config As Double()
            Get
                Return NumEdit.Config
            End Get
            Set(value As Double())
                NumEdit.Config = value
            End Set
        End Property
    End Class

    Public Class ButtonBlock
        Inherits EmptyBlock

        Property Button As SimpleUIButton

        Sub New(ui As SimpleUI)
            Button = New SimpleUIButton
            Controls.Add(Button)
        End Sub
    End Class

    Public Class TextBlock
        Inherits LabelBlock

        Property Edit As SimpleUITextEdit

        Sub New(ui As SimpleUI)
            Edit = New SimpleUITextEdit(ui)
            Controls.Add(Edit)
        End Sub

        Overridable Property Field As String
            Get
                Return Edit.Field
            End Get
            Set(value As String)
                Edit.Field = value
            End Set
        End Property

        Overridable Property [Property] As String
            Get
                Return Edit.Property
            End Get
            Set(value As String)
                Edit.Property = value
            End Set
        End Property

        Property Expandet As Boolean
            Get
                Return Edit.Expand
            End Get
            Set(value As Boolean)
                Edit.Expand = value
            End Set
        End Property
    End Class

    Public Class TextMenuBlock
        Inherits TextBlock

        Property Button As ButtonEx

        Sub New(ui As SimpleUI)
            MyBase.New(ui)
            Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight
            Button = New ButtonEx With {.Size = New Size(fh * 2, CInt(fh * 1.5)), .ShowMenuSymbol = True, .ContextMenuStrip = New ContextMenuStripEx}
            Controls.Add(Button)
            'AddHandler Edit.EnabledChanged, Sub() Button.Enabled = Edit.Enabled
            AddHandler Edit.EnabledChanged, AddressOf ButtonEnChangedEH 'Test This 
        End Sub
        Sub ButtonEnChangedEH(sender As Object, e As EventArgs)
            Button.Enabled = Edit.Enabled
        End Sub
        Protected Overrides Sub Dispose(disposing As Boolean)
            RemoveHandler Edit.EnabledChanged, AddressOf ButtonEnChangedEH
            Button.ContextMenuStrip.Dispose()
            MyBase.Dispose(disposing)
        End Sub

        Sub MenuClick(value As String)
            value = Macro.Expand(value)
            Dim tup = Macro.ExpandGUI(value)

            If tup.Cancel Then
                Exit Sub
            End If

            Edit.Text = tup.Value
        End Sub

        Sub AddMenu(menu As String)
            TextCustomMenu.GetMenu(menu, Button, Nothing, AddressOf MenuClick)
        End Sub

        Sub AddMenu(menuText As String, menuValue As String)
            AddMenu(menuText, Function() menuValue)
        End Sub

        Sub AddMenu(menuText As String, menuFunc As Func(Of String))
            Dim action = Sub()
                             Dim v = menuFunc.Invoke
                             If v?.Length > 0 Then Edit.Text = v
                         End Sub

            AddMenu(menuText, action)
        End Sub

        Sub AddMenu(menuText As String, menuAction As Action)
            ActionMenuItem.Add(Button.ContextMenuStrip.Items, menuText, menuAction)
        End Sub
    End Class

    Public Class ColorPickerBlock
        Inherits TextButtonBlock

        Private _Color As Color
        Private ReadOnly SimpleUI As SimpleUI

        Property Color As Color
            Get
                Return _Color
            End Get
            Set(value As Color)
                _Color = value
                Edit.BackColor = value
                Edit.TextBox.BackColor = value
            End Set
        End Property

        Sub New(ui As SimpleUI)
            MyBase.New(ui)
            SimpleUI = ui
            Edit.TextBox.ReadOnly = True

            Button.ClickAction = Sub()
                                     Using cd As New ColorDialog
                                         cd.Color = Color

                                         If cd.ShowDialog() = DialogResult.OK Then
                                             Color = cd.Color
                                         End If
                                     End Using
                                 End Sub
        End Sub

        Sub Save()
            If Field?.Length > 0 Then
                SimpleUI.Store.GetType.GetField(Field).SetValue(SimpleUI.Store, Color)
            ElseIf [Property]?.Length > 0 Then
                SimpleUI.Store.GetType.GetProperty([Property]).SetValue(SimpleUI.Store, Color)
            End If
        End Sub

        Private _Field As String

        Overrides Property Field As String
            Get
                Return _Field
            End Get
            Set(value As String)
                Color = DirectCast(SimpleUI.Store.GetType.GetField(value).GetValue(SimpleUI.Store), Color)
                _Field = value
            End Set
        End Property

        Private _Property As String

        Overrides Property [Property] As String
            Get
                Return _Property
            End Get
            Set(value As String)
                Color = DirectCast(SimpleUI.Store.GetType.GetProperty(value).GetValue(SimpleUI.Store), Color)
                _Property = value
            End Set
        End Property
    End Class

    Public Class TextButtonBlock
        Inherits TextBlock

        Property Button As ButtonEx

        Sub New(ui As SimpleUI)
            MyBase.New(ui)
            Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight
            Button = New ButtonEx With {.Size = New Size(fh * 2, CInt(fh * 1.45)), .AutoSizeMode = AutoSizeMode.GrowOnly, .AutoSize = True, .Text = "..."}
            Controls.Add(Button)
            AddHandler Edit.EnabledChanged, Sub() Button.Enabled = Edit.Enabled
        End Sub

        Sub BrowseFile(filterTypes As String())
            BrowseFile(FileTypes.GetFilter(filterTypes))
        End Sub

        Sub BrowseFile(filter As String, Optional initDir As String = Nothing)
            Button.ClickAction = Sub()
                                     Using dia As New OpenFileDialog
                                         dia.Filter = filter

                                         If initDir.NullOrEmptyS OrElse Not Directory.Exists(initDir) Then
                                             initDir = p.TempDir
                                         End If

                                         dia.SetInitDir(initDir)

                                         If dia.ShowDialog = DialogResult.OK Then
                                             Edit.Text = dia.FileName
                                         End If
                                     End Using
                                 End Sub
        End Sub

        Sub BrowseFolder()
            Button.ClickAction =
                Sub()
                    Using dialog As New FolderBrowserDialog
                        dialog.SetSelectedPath(s.LastSourceDir)

                        If dialog.ShowDialog = DialogResult.OK Then
                            Edit.Text = dialog.SelectedPath
                        End If
                    End Using
                End Sub
        End Sub
    End Class

    Public Class MenuBlock(Of T)
        Inherits LabelBlock

        Property Button As SimpleUIMenuButton(Of T)

        Sub New(ui As SimpleUI)
            Button = New SimpleUIMenuButton(Of T)(ui)
            Controls.Add(Button)
        End Sub

        Protected Overrides Sub OnLayout(levent As LayoutEventArgs)
            If Button IsNot Nothing Then
                Dim fh As Integer = If(s.UIScaleFactor <> 1, FontHeight, 16) 'FontHeight
                Button.Size = New Size(fh * 15, CInt(fh * 1.5)) 'New Size(fh * 10, CInt(fh * 1.5))
            End If

            MyBase.OnLayout(levent)
        End Sub

        Sub Add(items As IEnumerable(Of Object))
            Button.Add(items)
        End Sub

        Sub Add(ParamArray items As Object())
            Button.Add(items)
        End Sub

        Sub Add(path As String, obj As T)
            Button.Add(path, obj)
        End Sub

        Sub Add2(path As String, obj As T)
            Button.Add2(path, obj)
        End Sub

        Public Shadows WriteOnly Property Help As String
            Set(value As String)
                Dim parent = Me.Parent

                While Not TypeOf parent Is IPage
                    parent = parent.Parent
                End While

                'Help for audio form menu, opus mapping family
                If value.StartsWith("http", StringComparison.Ordinal) Then
                    value = $"[{value} {value}]"
                End If

                DirectCast(parent, IPage).TipProvider.SetTip(value, Label, Button)
            End Set
        End Property

        Public Shadows WriteOnly Property HelpAction As Action
            Set(value As Action)
                Button.HelpAction = value
                Label.HelpAction = value
            End Set
        End Property

        Property Expandet As Boolean
            Get
                Return Button.Expand
            End Get
            Set(value As Boolean)
                Button.Expand = value
            End Set
        End Property

        Property Field As String
            Get
                Return Button.Field
            End Get
            Set(value As String)
                Button.Field = value
            End Set
        End Property

        Property [Property] As String
            Get
                Return Button.Property
            End Get
            Set(value As String)
                Button.Property = value
            End Set
        End Property
    End Class

    Interface SimpleUIControl
        Property Expand As Boolean
    End Interface
End Class