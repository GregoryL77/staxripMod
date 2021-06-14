
Imports System.ComponentModel
Imports System.Drawing.Design
Imports JM.LinqFaster

Namespace UI
    Public Class FormBase
        Inherits Form

        Event FilesDropped(files As String())

        Private FileDropValue As Boolean
        Private DefaultWidthScale As Single
        Private DefaultHeightScale As Single

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
        Shadows Property FontHeight As Integer

        Sub New()
            Font = New Font("Segoe UI", 9)
            FontHeight = If(s.UIScaleFactor = 1, 16, Font.Height) ' Test This Experiment!!! NoScaling
        End Sub

        <DefaultValue(False)>
        Property FileDrop As Boolean
            Get
                Return FileDropValue
            End Get
            Set(value As Boolean)
                FileDropValue = value
                AllowDrop = value
            End Set
        End Property

        Protected Overrides Sub OnDragEnter(e As DragEventArgs)
            MyBase.OnDragEnter(e)

            If FileDrop Then
                Dim files = TryCast(e.Data.GetData(DataFormats.FileDrop), String())

                If Not files.NothingOrEmpty Then
                    e.Effect = DragDropEffects.Copy
                End If
            End If
        End Sub

        Protected Overrides Sub OnDragDrop(args As DragEventArgs)
            MyBase.OnDragDrop(args)

            If FileDrop Then
                Dim files = TryCast(args.Data.GetData(DataFormats.FileDrop), String())

                If Not files.NothingOrEmpty Then
                    RaiseEvent FilesDropped(files)
                End If
            End If
        End Sub

        Sub SetMinimumSize(w As Integer, h As Integer)
            MinimumSize = New Size(CInt(FontHeight * w), CInt(FontHeight * h))
        End Sub

        Protected Overrides Sub OnLoad(args As EventArgs)
            KeyPreview = True
            SetTabIndexes(Me)

            If s.UIScaleFactor <> 1 Then
                Font = New Font("Segoe UI", 9 * s.UIScaleFactor)
                Scale(New SizeF(1 * s.UIScaleFactor, 1 * s.UIScaleFactor))
            End If

            Dim workAr As Size  'Rectangle
            If DefaultWidthScale <> 0 Then
                'Dim fh As Integer = Font.Height
                Dim fh As Integer = FontHeight
                Dim defaultWidth = CInt(fh * DefaultWidthScale)
                Dim defaultHeight = CInt(fh * DefaultHeightScale)

                Dim fName As String = Me.GetType().Name
                Dim w = s.Storage.GetInt(fName + "width")
                Dim h = s.Storage.GetInt(fName + "height")

                If w = 0 OrElse w < (defaultWidth \ 2) OrElse h = 0 OrElse h < (defaultHeight \ 2) Then
                    w = defaultWidth
                    h = defaultHeight
                End If

                workAr = Screen.FromControl(Me).WorkingArea.Size
                If w > workAr.Width OrElse h > workAr.Height Then
                    w = workAr.Width
                    h = workAr.Height
                End If

                Width = w
                Height = h
            End If

            If StartPosition = FormStartPosition.CenterScreen Then
                If workAr.IsEmpty Then workAr = Screen.FromControl(Me).WorkingArea.Size
                WindowPositions.CenterScreen(Me, workAr)
            End If

            If Not DesignHelp.IsDesignMode Then
                If workAr.IsEmpty Then workAr = Screen.FromControl(Me).WorkingArea.Size
                s.WindowPositions?.RestorePosition(Me, workAr)
            End If

            MyBase.OnLoad(args)
        End Sub

        Protected Overrides Sub OnFormClosing(args As FormClosingEventArgs)
            MyBase.OnFormClosing(args)

            If Not s.WindowPositions Is Nothing Then
                s.WindowPositions.Save(Me)
            End If

            If DefaultWidthScale <> 0 Then
                SaveClientSize()
            End If
        End Sub

        Sub SetTabIndexes(c As Control)
            Dim index = 0
            Dim controls = From i In c.Controls.OfType(Of Control)()
                           Order By Math.Sqrt(i.Top * i.Top + i.Left * i.Left)
            'Dim ca(c.Controls.Count - 1) As Control 'Test This!!!
            'c.Controls.CopyTo(ca, 0)
            'Dim ka(ca.Length - 1) As Double
            'For i = 0 To ca.Length - 1
            '    Dim ci = ca(i)
            '    ka(i) = Math.Sqrt(ci.Top * ci.Top + ci.Left * ci.Left)
            'Next i
            'Array.Sort(ka, ca)
            'For i = 0 To ca.Length - 1
            '    ca(i).TabIndex = i
            '    SetTabIndexes(ca(i))
            'Next i
            'Dim ttt = controls.ToArray.SequenceEqual(ca) 'Debug
            For Each i In controls
                i.TabIndex = index
                index += 1
                SetTabIndexes(i)
            Next i
        End Sub

        Sub RestoreClientSize(defaultWidthScale As Single, defaultHeightScale As Single)
            Me.DefaultWidthScale = defaultWidthScale
            Me.DefaultHeightScale = defaultHeightScale
        End Sub

        Sub SaveClientSize()
            s.Storage.SetInt(Me.GetType().Name + "width", Width)
            s.Storage.SetInt(Me.GetType().Name + "height", Height)
        End Sub
    End Class

    Public Class DialogBase
        Inherits FormBase

        Sub New()
            'FormBorderStyle = FormBorderStyle.FixedDialog
            HelpButton = True
            'MaximizeBox = False
            'MinimizeBox = False
            ShowIcon = False
            ShowInTaskbar = False
            StartPosition = FormStartPosition.CenterParent
        End Sub

        Protected Overrides Sub OnHelpButtonClicked(args As CancelEventArgs)
            MyBase.OnHelpButtonClicked(args)
            args.Cancel = True
            OnHelpRequested(New HelpEventArgs(MousePosition))
        End Sub
    End Class

    Public Class ListBag(Of T)
        Implements IComparable(Of ListBag(Of T))

        Property Text As String
        Property Value As T

        Sub New(text As String, value As T)
            Me.Text = text
            Me.Value = value
        End Sub

        Shared Sub SelectItem(cb As ComboBox, value As T)
            Dim selectItem As Object = Nothing

            For Each i As ListBag(Of T) In cb.Items
                If i.Value.Equals(value) Then selectItem = i
            Next

            If Not selectItem Is Nothing Then cb.SelectedItem = selectItem
        End Sub

        Shared Function GetValue(cb As ComboBox) As T
            Return DirectCast(DirectCast(cb.SelectedItem, ListBag(Of T)).Value, T)
        End Function

        Shared Function GetBagsForEnumType() As ListBag(Of T)()
            Dim ret As New List(Of ListBag(Of T))

            For Each i As T In System.Enum.GetValues(GetType(T))
                ret.Add(New ListBag(Of T)(UI.DispNameAttribute.GetValueForEnum(i), i))
            Next

            Return ret.ToArray
        End Function

        Overrides Function ToString() As String
            Return Text
        End Function

        Function CompareTo(other As ListBag(Of T)) As Integer Implements IComparable(Of ListBag(Of T)).CompareTo
            Return String.Compare(Text, other.Text, StringComparison.OrdinalIgnoreCase)
        End Function
    End Class

    <Serializable()>
    Public Class WindowPositions
        Public Positions As New Dictionary(Of String, Point)(7, StringComparer.Ordinal)
        Private WindowStates As New Dictionary(Of String, FormWindowState)(7, StringComparer.Ordinal)

        Sub Save(form As Form)
            SavePosition(form)
            SaveWindowState(form)
        End Sub

        Sub SavePosition(form As Form)
            If form.WindowState = FormWindowState.Normal Then
                Positions(GetKey(form)) = form.Location
            End If
        End Sub

        Sub SaveWindowState(form As Form)
            WindowStates(GetKey(form)) = form.WindowState
        End Sub

        Shared Sub CenterScreen(form As Form, screenSize As Size) ' Screen.FromControl(form).WorkingArea
            form.StartPosition = FormStartPosition.Manual
            form.Location = New Point((screenSize.Width - form.Width) \ 2, (screenSize.Height - form.Height) \ 2)
        End Sub

        Sub RestorePosition(form As Form, screenSz As Size)
            Dim text = GetText(form)

            If Not s.WindowPositionsRemembered.NothingOrEmpty AndAlso Not TypeOf form Is UI.InputBoxForm Then
                For Each i In s.WindowPositionsRemembered
                    If text.StartsWith(i, StringComparison.Ordinal) OrElse String.Equals(i, "all") Then

                        If Positions.ContainsKey(GetKey(form)) Then
                            Dim pos = Positions(GetKey(form))

                            If pos.X < 0 OrElse pos.Y < 0 OrElse pos.X + form.Width > screenSz.Width OrElse pos.Y + form.Height > screenSz.Height Then
                                CenterScreen(form, screenSz)
                            Else
                                form.StartPosition = FormStartPosition.Manual
                                form.Location = pos
                            End If
                        End If

                        Exit For
                    End If
                Next
            End If
        End Sub

        Function GetKey(form As Form) As String
            Return form.Name + form.GetType().FullName + GetText(form)
        End Function

        Function GetText(form As Form) As String

            If TypeOf form Is AudioConverterForm Then
                Return "AudioConverter"
            ElseIf TypeOf form Is MainForm Then
                Return "StaxRip"
            ElseIf TypeOf form Is HelpForm Then
                Return "Help"
            ElseIf TypeOf form Is PreviewForm Then
                Return "Preview"
            End If

            Return form.Text
        End Function
    End Class

    Public Class OpenFileDialogEditor
        Inherits UITypeEditor

        Overloads Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
            Using f As New OpenFileDialog
                If f.ShowDialog = DialogResult.OK Then
                    Return f.FileName
                Else
                    Return value
                End If
            End Using
        End Function

        Overloads Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.Modal
        End Function
    End Class

    Public Class StringEditor
        Inherits UITypeEditor

        Sub New()
        End Sub

        Overloads Overrides Function EditValue(context As ITypeDescriptorContext, provider As IServiceProvider, value As Object) As Object
            Dim form As New UI.StringEditorForm
            form.rtb.Text = DirectCast(value, String)

            If form.ShowDialog() = DialogResult.OK Then
                Return form.rtb.Text
            Else
                Return value
            End If
        End Function

        Overloads Overrides Function GetEditStyle(context As ITypeDescriptorContext) As UITypeEditorEditStyle
            Return UITypeEditorEditStyle.Modal
        End Function
    End Class

    Public Class DesignHelp
        Private Shared IsDesignModeValue As Boolean?

        Shared ReadOnly Property IsDesignMode As Boolean
            Get
                If Not IsDesignModeValue.HasValue Then
                    IsDesignModeValue = String.Equals(Process.GetCurrentProcess.ProcessName, "devenv")
                End If

                Return IsDesignModeValue.Value
            End Get
        End Property
    End Class
End Namespace
