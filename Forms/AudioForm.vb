
Imports StaxRip.UI

Public Class AudioForm
    Inherits DialogBase

#Region " Designer "

    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents CommandLink1 As StaxRip.UI.CommandLink
    Friend WithEvents gbBasic As System.Windows.Forms.GroupBox
    Friend WithEvents numQuality As NumEdit
    Friend WithEvents numBitrate As NumEdit
    Friend WithEvents lQualiy As System.Windows.Forms.Label
    Friend WithEvents lCodec As System.Windows.Forms.Label
    Friend WithEvents mbCodec As StaxRip.UI.MenuButton
    Friend WithEvents mbLanguage As StaxRip.UI.MenuButton
    Friend WithEvents lLanguage As System.Windows.Forms.Label
    Friend WithEvents numDelay As NumEdit
    Friend WithEvents lDelay As System.Windows.Forms.Label
    Friend WithEvents mbChannels As StaxRip.UI.MenuButton
    Friend WithEvents lChannels As System.Windows.Forms.Label
    Friend WithEvents gbAdvanced As System.Windows.Forms.GroupBox
    Friend WithEvents laProfileName As System.Windows.Forms.Label
    Friend WithEvents tbProfileName As System.Windows.Forms.TextBox
    Friend WithEvents TipProvider As StaxRip.UI.TipProvider
    Friend WithEvents mbSamplingRate As StaxRip.UI.MenuButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bnOK As StaxRip.UI.ButtonEx
    Friend WithEvents bnCancel As StaxRip.UI.ButtonEx
    Friend WithEvents mbEncoder As StaxRip.UI.MenuButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SimpleUI As StaxRip.SimpleUI
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numGain As StaxRip.UI.NumEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tlpMain As TableLayoutPanel
    Friend WithEvents flpButtons As FlowLayoutPanel
    Friend WithEvents tlpBasic As TableLayoutPanel
    Friend WithEvents bnMenu As ButtonEx
    Friend WithEvents tlpRTB As TableLayoutPanel
    Friend WithEvents rtbCommandLine As CommandLineRichTextBox
    Friend WithEvents laStreamName As Label
    Friend WithEvents tbStreamName As TextBox
    Friend WithEvents laCustom As Label
    Friend WithEvents tbCustom As TextBox
    Friend WithEvents cbForcedTrack As CheckBoxEx
    Friend WithEvents cbDefaultTrack As CheckBoxEx
    Friend WithEvents laDecoder As Label
    Friend WithEvents mbDecoder As MenuButton
    Friend WithEvents tlpAdvanced As TableLayoutPanel
    Friend WithEvents bnAdvanced As ButtonEx
    Friend WithEvents cbNormalize As CheckBoxEx
    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.gbBasic = New System.Windows.Forms.GroupBox()
        Me.tlpBasic = New System.Windows.Forms.TableLayoutPanel()
        Me.lCodec = New System.Windows.Forms.Label()
        Me.tbProfileName = New System.Windows.Forms.TextBox()
        Me.laProfileName = New System.Windows.Forms.Label()
        Me.mbCodec = New StaxRip.UI.MenuButton()
        Me.mbLanguage = New StaxRip.UI.MenuButton()
        Me.mbSamplingRate = New StaxRip.UI.MenuButton()
        Me.lLanguage = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numBitrate = New StaxRip.UI.NumEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.mbEncoder = New StaxRip.UI.MenuButton()
        Me.lChannels = New System.Windows.Forms.Label()
        Me.mbChannels = New StaxRip.UI.MenuButton()
        Me.laStreamName = New System.Windows.Forms.Label()
        Me.tbStreamName = New System.Windows.Forms.TextBox()
        Me.laCustom = New System.Windows.Forms.Label()
        Me.tbCustom = New System.Windows.Forms.TextBox()
        Me.cbDefaultTrack = New StaxRip.UI.CheckBoxEx()
        Me.cbForcedTrack = New StaxRip.UI.CheckBoxEx()
        Me.laDecoder = New System.Windows.Forms.Label()
        Me.mbDecoder = New StaxRip.UI.MenuButton()
        Me.lQualiy = New System.Windows.Forms.Label()
        Me.numQuality = New StaxRip.UI.NumEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numGain = New StaxRip.UI.NumEdit()
        Me.cbNormalize = New StaxRip.UI.CheckBoxEx()
        Me.numDelay = New StaxRip.UI.NumEdit()
        Me.lDelay = New System.Windows.Forms.Label()
        Me.gbAdvanced = New System.Windows.Forms.GroupBox()
        Me.tlpAdvanced = New System.Windows.Forms.TableLayoutPanel()
        Me.SimpleUI = New StaxRip.SimpleUI()
        Me.bnAdvanced = New StaxRip.UI.ButtonEx()
        Me.TipProvider = New StaxRip.UI.TipProvider(Me.components)
        Me.bnOK = New StaxRip.UI.ButtonEx()
        Me.bnCancel = New StaxRip.UI.ButtonEx()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel()
        Me.flpButtons = New System.Windows.Forms.FlowLayoutPanel()
        Me.bnMenu = New StaxRip.UI.ButtonEx()
        Me.tlpRTB = New System.Windows.Forms.TableLayoutPanel()
        Me.rtbCommandLine = New StaxRip.UI.CommandLineRichTextBox()
        Me.gbBasic.SuspendLayout()
        Me.tlpBasic.SuspendLayout()
        Me.gbAdvanced.SuspendLayout()
        Me.tlpAdvanced.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.flpButtons.SuspendLayout()
        Me.tlpRTB.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBasic
        '
        Me.gbBasic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBasic.Controls.Add(Me.tlpBasic)
        Me.gbBasic.Location = New System.Drawing.Point(15, 14)
        Me.gbBasic.Margin = New System.Windows.Forms.Padding(15, 14, 7, 14)
        Me.gbBasic.Name = "gbBasic"
        Me.gbBasic.Padding = New System.Windows.Forms.Padding(5)
        Me.gbBasic.Size = New System.Drawing.Size(911, 1018)
        Me.gbBasic.TabIndex = 1
        Me.gbBasic.TabStop = False
        Me.gbBasic.Text = "Basic"
        '
        'tlpBasic
        '
        Me.tlpBasic.ColumnCount = 4
        Me.tlpBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.tlpBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.tlpBasic.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.tlpBasic.Controls.Add(Me.lCodec, 0, 0)
        Me.tlpBasic.Controls.Add(Me.tbProfileName, 1, 7)
        Me.tlpBasic.Controls.Add(Me.laProfileName, 0, 7)
        Me.tlpBasic.Controls.Add(Me.mbCodec, 1, 0)
        Me.tlpBasic.Controls.Add(Me.mbLanguage, 1, 5)
        Me.tlpBasic.Controls.Add(Me.mbSamplingRate, 1, 4)
        Me.tlpBasic.Controls.Add(Me.lLanguage, 0, 5)
        Me.tlpBasic.Controls.Add(Me.Label1, 0, 4)
        Me.tlpBasic.Controls.Add(Me.Label3, 2, 0)
        Me.tlpBasic.Controls.Add(Me.numBitrate, 3, 0)
        Me.tlpBasic.Controls.Add(Me.Label2, 0, 2)
        Me.tlpBasic.Controls.Add(Me.mbEncoder, 1, 2)
        Me.tlpBasic.Controls.Add(Me.lChannels, 0, 3)
        Me.tlpBasic.Controls.Add(Me.mbChannels, 1, 3)
        Me.tlpBasic.Controls.Add(Me.laStreamName, 0, 8)
        Me.tlpBasic.Controls.Add(Me.tbStreamName, 1, 8)
        Me.tlpBasic.Controls.Add(Me.laCustom, 0, 9)
        Me.tlpBasic.Controls.Add(Me.tbCustom, 1, 9)
        Me.tlpBasic.Controls.Add(Me.cbDefaultTrack, 0, 11)
        Me.tlpBasic.Controls.Add(Me.cbForcedTrack, 0, 12)
        Me.tlpBasic.Controls.Add(Me.laDecoder, 0, 1)
        Me.tlpBasic.Controls.Add(Me.mbDecoder, 1, 1)
        Me.tlpBasic.Controls.Add(Me.lQualiy, 2, 1)
        Me.tlpBasic.Controls.Add(Me.numQuality, 3, 1)
        Me.tlpBasic.Controls.Add(Me.Label4, 2, 2)
        Me.tlpBasic.Controls.Add(Me.numGain, 3, 2)
        Me.tlpBasic.Controls.Add(Me.cbNormalize, 0, 10)
        Me.tlpBasic.Controls.Add(Me.numDelay, 3, 3)
        Me.tlpBasic.Controls.Add(Me.lDelay, 2, 3)
        Me.tlpBasic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpBasic.Location = New System.Drawing.Point(5, 53)
        Me.tlpBasic.Margin = New System.Windows.Forms.Padding(5)
        Me.tlpBasic.Name = "tlpBasic"
        Me.tlpBasic.RowCount = 14
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpBasic.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8.0!))
        Me.tlpBasic.Size = New System.Drawing.Size(901, 960)
        Me.tlpBasic.TabIndex = 44
        '
        'lCodec
        '
        Me.lCodec.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lCodec.AutoSize = True
        Me.lCodec.Location = New System.Drawing.Point(5, 16)
        Me.lCodec.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lCodec.Name = "lCodec"
        Me.lCodec.Size = New System.Drawing.Size(128, 48)
        Me.lCodec.TabIndex = 0
        Me.lCodec.Text = "Codec:"
        '
        'tbProfileName
        '
        Me.tbProfileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpBasic.SetColumnSpan(Me.tbProfileName, 3)
        Me.tbProfileName.Location = New System.Drawing.Point(250, 485)
        Me.tbProfileName.Margin = New System.Windows.Forms.Padding(5)
        Me.tbProfileName.Name = "tbProfileName"
        Me.tbProfileName.Size = New System.Drawing.Size(646, 55)
        Me.tbProfileName.TabIndex = 16
        '
        'laProfileName
        '
        Me.laProfileName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laProfileName.AutoSize = True
        Me.laProfileName.Location = New System.Drawing.Point(5, 488)
        Me.laProfileName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.laProfileName.Name = "laProfileName"
        Me.laProfileName.Size = New System.Drawing.Size(235, 48)
        Me.laProfileName.TabIndex = 15
        Me.laProfileName.Text = "Profile Name:"
        '
        'mbCodec
        '
        Me.mbCodec.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbCodec.Location = New System.Drawing.Point(250, 5)
        Me.mbCodec.Margin = New System.Windows.Forms.Padding(5)
        Me.mbCodec.ShowMenuSymbol = True
        Me.mbCodec.Size = New System.Drawing.Size(293, 70)
        Me.mbCodec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mbLanguage
        '
        Me.mbLanguage.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbLanguage.Location = New System.Drawing.Point(250, 405)
        Me.mbLanguage.Margin = New System.Windows.Forms.Padding(5)
        Me.mbLanguage.ShowMenuSymbol = True
        Me.mbLanguage.Size = New System.Drawing.Size(293, 70)
        Me.mbLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mbSamplingRate
        '
        Me.mbSamplingRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbSamplingRate.Location = New System.Drawing.Point(250, 325)
        Me.mbSamplingRate.Margin = New System.Windows.Forms.Padding(5)
        Me.mbSamplingRate.ShowMenuSymbol = True
        Me.mbSamplingRate.Size = New System.Drawing.Size(293, 70)
        Me.mbSamplingRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lLanguage
        '
        Me.lLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lLanguage.AutoSize = True
        Me.lLanguage.Location = New System.Drawing.Point(5, 416)
        Me.lLanguage.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lLanguage.Name = "lLanguage"
        Me.lLanguage.Size = New System.Drawing.Size(182, 48)
        Me.lLanguage.TabIndex = 10
        Me.lLanguage.Text = "Language:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 336)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 48)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Sample Rate:"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(553, 16)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 48)
        Me.Label3.TabIndex = 29
        Me.Label3.TabStop = True
        Me.Label3.Text = "Bitrate:"
        '
        'numBitrate
        '
        Me.numBitrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numBitrate.Location = New System.Drawing.Point(703, 5)
        Me.numBitrate.Margin = New System.Windows.Forms.Padding(5)
        Me.numBitrate.Name = "numBitrate"
        Me.numBitrate.Size = New System.Drawing.Size(193, 70)
        Me.numBitrate.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 176)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(157, 48)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Encoder:"
        '
        'mbEncoder
        '
        Me.mbEncoder.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbEncoder.Location = New System.Drawing.Point(250, 165)
        Me.mbEncoder.Margin = New System.Windows.Forms.Padding(5)
        Me.mbEncoder.ShowMenuSymbol = True
        Me.mbEncoder.Size = New System.Drawing.Size(293, 70)
        Me.mbEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lChannels
        '
        Me.lChannels.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lChannels.AutoSize = True
        Me.lChannels.Location = New System.Drawing.Point(5, 256)
        Me.lChannels.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lChannels.Name = "lChannels"
        Me.lChannels.Size = New System.Drawing.Size(171, 48)
        Me.lChannels.TabIndex = 5
        Me.lChannels.Text = "Channels:"
        '
        'mbChannels
        '
        Me.mbChannels.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbChannels.Location = New System.Drawing.Point(250, 245)
        Me.mbChannels.Margin = New System.Windows.Forms.Padding(5)
        Me.mbChannels.ShowMenuSymbol = True
        Me.mbChannels.Size = New System.Drawing.Size(293, 70)
        Me.mbChannels.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'laStreamName
        '
        Me.laStreamName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laStreamName.AutoSize = True
        Me.laStreamName.Location = New System.Drawing.Point(5, 553)
        Me.laStreamName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.laStreamName.Name = "laStreamName"
        Me.laStreamName.Size = New System.Drawing.Size(215, 48)
        Me.laStreamName.TabIndex = 44
        Me.laStreamName.Text = "Track Name:"
        '
        'tbStreamName
        '
        Me.tbStreamName.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpBasic.SetColumnSpan(Me.tbStreamName, 3)
        Me.tbStreamName.Location = New System.Drawing.Point(250, 550)
        Me.tbStreamName.Margin = New System.Windows.Forms.Padding(5)
        Me.tbStreamName.Name = "tbStreamName"
        Me.tbStreamName.Size = New System.Drawing.Size(646, 55)
        Me.tbStreamName.TabIndex = 45
        '
        'laCustom
        '
        Me.laCustom.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laCustom.AutoSize = True
        Me.laCustom.Location = New System.Drawing.Point(5, 618)
        Me.laCustom.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.laCustom.Name = "laCustom"
        Me.laCustom.Size = New System.Drawing.Size(141, 48)
        Me.laCustom.TabIndex = 46
        Me.laCustom.Text = "Custom"
        '
        'tbCustom
        '
        Me.tbCustom.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpBasic.SetColumnSpan(Me.tbCustom, 3)
        Me.tbCustom.Location = New System.Drawing.Point(250, 615)
        Me.tbCustom.Margin = New System.Windows.Forms.Padding(5)
        Me.tbCustom.Name = "tbCustom"
        Me.tbCustom.Size = New System.Drawing.Size(646, 55)
        Me.tbCustom.TabIndex = 47
        '
        'cbDefaultTrack
        '
        Me.cbDefaultTrack.AutoSize = True
        Me.tlpBasic.SetColumnSpan(Me.cbDefaultTrack, 4)
        Me.cbDefaultTrack.Location = New System.Drawing.Point(15, 736)
        Me.cbDefaultTrack.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.cbDefaultTrack.Size = New System.Drawing.Size(272, 52)
        Me.cbDefaultTrack.Text = "Default Track"
        Me.cbDefaultTrack.UseVisualStyleBackColor = True
        '
        'cbForcedTrack
        '
        Me.cbForcedTrack.AutoSize = True
        Me.tlpBasic.SetColumnSpan(Me.cbForcedTrack, 4)
        Me.cbForcedTrack.Location = New System.Drawing.Point(15, 794)
        Me.cbForcedTrack.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.cbForcedTrack.Size = New System.Drawing.Size(267, 52)
        Me.cbForcedTrack.Text = "Forced Track"
        Me.cbForcedTrack.UseVisualStyleBackColor = True
        '
        'laDecoder
        '
        Me.laDecoder.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.laDecoder.AutoSize = True
        Me.laDecoder.Location = New System.Drawing.Point(5, 96)
        Me.laDecoder.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.laDecoder.Name = "laDecoder"
        Me.laDecoder.Size = New System.Drawing.Size(163, 48)
        Me.laDecoder.TabIndex = 50
        Me.laDecoder.Text = "Decoder:"
        '
        'mbDecoder
        '
        Me.mbDecoder.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mbDecoder.Location = New System.Drawing.Point(250, 85)
        Me.mbDecoder.Margin = New System.Windows.Forms.Padding(5)
        Me.mbDecoder.ShowMenuSymbol = True
        Me.mbDecoder.Size = New System.Drawing.Size(293, 70)
        Me.mbDecoder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lQualiy
        '
        Me.lQualiy.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lQualiy.AutoSize = True
        Me.lQualiy.Location = New System.Drawing.Point(553, 96)
        Me.lQualiy.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lQualiy.Name = "lQualiy"
        Me.lQualiy.Size = New System.Drawing.Size(140, 48)
        Me.lQualiy.TabIndex = 12
        Me.lQualiy.TabStop = True
        Me.lQualiy.Text = "Quality:"
        '
        'numQuality
        '
        Me.numQuality.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numQuality.Location = New System.Drawing.Point(703, 85)
        Me.numQuality.Margin = New System.Windows.Forms.Padding(5)
        Me.numQuality.Name = "numQuality"
        Me.numQuality.Size = New System.Drawing.Size(193, 70)
        Me.numQuality.TabIndex = 18
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(553, 176)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 48)
        Me.Label4.TabIndex = 36
        Me.Label4.TabStop = True
        Me.Label4.Text = "Gain:"
        '
        'numGain
        '
        Me.numGain.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numGain.Location = New System.Drawing.Point(703, 165)
        Me.numGain.Margin = New System.Windows.Forms.Padding(5)
        Me.numGain.Name = "numGain"
        Me.numGain.Size = New System.Drawing.Size(193, 70)
        Me.numGain.TabIndex = 37
        '
        'cbNormalize
        '
        Me.cbNormalize.AutoSize = True
        Me.tlpBasic.SetColumnSpan(Me.cbNormalize, 4)
        Me.cbNormalize.Location = New System.Drawing.Point(15, 678)
        Me.cbNormalize.Margin = New System.Windows.Forms.Padding(15, 3, 3, 3)
        Me.cbNormalize.Size = New System.Drawing.Size(229, 52)
        Me.cbNormalize.Text = "Normalize"
        Me.cbNormalize.UseVisualStyleBackColor = True
        '
        'numDelay
        '
        Me.numDelay.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numDelay.Location = New System.Drawing.Point(703, 245)
        Me.numDelay.Margin = New System.Windows.Forms.Padding(5)
        Me.numDelay.Name = "numDelay"
        Me.numDelay.Size = New System.Drawing.Size(193, 70)
        Me.numDelay.TabIndex = 19
        '
        'lDelay
        '
        Me.lDelay.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lDelay.AutoSize = True
        Me.lDelay.Location = New System.Drawing.Point(553, 256)
        Me.lDelay.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lDelay.Name = "lDelay"
        Me.lDelay.Size = New System.Drawing.Size(116, 48)
        Me.lDelay.TabIndex = 14
        Me.lDelay.TabStop = True
        Me.lDelay.Text = "Delay:"
        '
        'gbAdvanced
        '
        Me.gbAdvanced.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbAdvanced.Controls.Add(Me.tlpAdvanced)
        Me.gbAdvanced.Location = New System.Drawing.Point(940, 14)
        Me.gbAdvanced.Margin = New System.Windows.Forms.Padding(7, 14, 15, 14)
        Me.gbAdvanced.Name = "gbAdvanced"
        Me.gbAdvanced.Padding = New System.Windows.Forms.Padding(5)
        Me.gbAdvanced.Size = New System.Drawing.Size(911, 1018)
        Me.gbAdvanced.TabIndex = 3
        Me.gbAdvanced.TabStop = False
        Me.gbAdvanced.Text = "Advanced"
        '
        'tlpAdvanced
        '
        Me.tlpAdvanced.ColumnCount = 1
        Me.tlpAdvanced.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpAdvanced.Controls.Add(Me.SimpleUI, 0, 0)
        Me.tlpAdvanced.Controls.Add(Me.bnAdvanced, 0, 1)
        Me.tlpAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpAdvanced.Location = New System.Drawing.Point(5, 53)
        Me.tlpAdvanced.Name = "tlpAdvanced"
        Me.tlpAdvanced.RowCount = 2
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpAdvanced.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpAdvanced.Size = New System.Drawing.Size(901, 960)
        Me.tlpAdvanced.TabIndex = 1
        '
        'SimpleUI
        '
        Me.SimpleUI.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleUI.FormSizeScaleFactor = New System.Drawing.SizeF(0!, 0!)
        Me.SimpleUI.Location = New System.Drawing.Point(4, 3)
        Me.SimpleUI.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SimpleUI.Name = "SimpleUI"
        Me.SimpleUI.Size = New System.Drawing.Size(893, 878)
        Me.SimpleUI.TabIndex = 0
        Me.SimpleUI.Text = "SimpleUI1"
        '
        'bnAdvanced
        '
        Me.bnAdvanced.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnAdvanced.Location = New System.Drawing.Point(3, 887)
        Me.bnAdvanced.Size = New System.Drawing.Size(895, 70)
        Me.bnAdvanced.Text = "More..."
        '
        'bnOK
        '
        Me.bnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.bnOK.Location = New System.Drawing.Point(115, 15)
        Me.bnOK.Margin = New System.Windows.Forms.Padding(15)
        Me.bnOK.Size = New System.Drawing.Size(250, 70)
        Me.bnOK.Text = "OK"
        '
        'bnCancel
        '
        Me.bnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.bnCancel.Location = New System.Drawing.Point(380, 15)
        Me.bnCancel.Margin = New System.Windows.Forms.Padding(0, 15, 15, 15)
        Me.bnCancel.Size = New System.Drawing.Size(250, 70)
        Me.bnCancel.Text = "Cancel"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(22, 1268)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(5)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(0, 0)
        Me.FlowLayoutPanel1.TabIndex = 4
        '
        'tlpMain
        '
        Me.tlpMain.AutoSize = True
        Me.tlpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpMain.ColumnCount = 2
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpMain.Controls.Add(Me.gbBasic, 0, 0)
        Me.tlpMain.Controls.Add(Me.flpButtons, 1, 2)
        Me.tlpMain.Controls.Add(Me.gbAdvanced, 1, 0)
        Me.tlpMain.Controls.Add(Me.tlpRTB, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 3
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.tlpMain.Size = New System.Drawing.Size(1866, 1206)
        Me.tlpMain.TabIndex = 11
        '
        'flpButtons
        '
        Me.flpButtons.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.flpButtons.AutoSize = True
        Me.flpButtons.Controls.Add(Me.bnMenu)
        Me.flpButtons.Controls.Add(Me.bnOK)
        Me.flpButtons.Controls.Add(Me.bnCancel)
        Me.flpButtons.Location = New System.Drawing.Point(1221, 1106)
        Me.flpButtons.Margin = New System.Windows.Forms.Padding(0)
        Me.flpButtons.Name = "flpButtons"
        Me.flpButtons.Size = New System.Drawing.Size(645, 100)
        Me.flpButtons.TabIndex = 11
        '
        'bnMenu
        '
        Me.bnMenu.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.bnMenu.Location = New System.Drawing.Point(0, 15)
        Me.bnMenu.Margin = New System.Windows.Forms.Padding(0)
        Me.bnMenu.ShowMenuSymbol = True
        Me.bnMenu.Size = New System.Drawing.Size(100, 70)
        '
        'tlpRTB
        '
        Me.tlpRTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tlpRTB.AutoSize = True
        Me.tlpRTB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.tlpRTB.ColumnCount = 1
        Me.tlpMain.SetColumnSpan(Me.tlpRTB, 2)
        Me.tlpRTB.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRTB.Controls.Add(Me.rtbCommandLine, 0, 0)
        Me.tlpRTB.Location = New System.Drawing.Point(15, 1046)
        Me.tlpRTB.Margin = New System.Windows.Forms.Padding(15, 0, 15, 0)
        Me.tlpRTB.Name = "tlpRTB"
        Me.tlpRTB.RowCount = 1
        Me.tlpRTB.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpRTB.Size = New System.Drawing.Size(1836, 60)
        Me.tlpRTB.TabIndex = 12
        '
        'rtbCommandLine
        '
        Me.rtbCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbCommandLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbCommandLine.LastCommandLine = Nothing
        Me.rtbCommandLine.Location = New System.Drawing.Point(0, 0)
        Me.rtbCommandLine.Margin = New System.Windows.Forms.Padding(0)
        Me.rtbCommandLine.Name = "rtbCommandLine"
        Me.rtbCommandLine.ReadOnly = True
        Me.rtbCommandLine.Size = New System.Drawing.Size(1836, 60)
        Me.rtbCommandLine.TabIndex = 45
        Me.rtbCommandLine.Text = ""
        '
        'AudioForm
        '
        Me.AcceptButton = Me.bnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(256.0!, 256.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CancelButton = Me.bnCancel
        Me.ClientSize = New System.Drawing.Size(1866, 1206)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(7)
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Name = "AudioForm"
        Me.Text = "Audio Settings"
        Me.gbBasic.ResumeLayout(False)
        Me.tlpBasic.ResumeLayout(False)
        Me.tlpBasic.PerformLayout()
        Me.gbAdvanced.ResumeLayout(False)
        Me.tlpAdvanced.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.flpButtons.ResumeLayout(False)
        Me.tlpRTB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Profile, TempProfile As GUIAudioProfile

    Sub New()
        MyBase.New()
        InitializeComponent()

        rtbCommandLine.ReadOnly = True

        mbSamplingRate.Add("Original", 0)
        mbSamplingRate.Add("11025 Hz", 11025)
        mbSamplingRate.Add("22050 Hz", 22050)
        mbSamplingRate.Add("44100 Hz", 44100)
        mbSamplingRate.Add("48000 Hz", 48000)
        mbSamplingRate.Add("88200 Hz", 88200)
        mbSamplingRate.Add("96000 Hz", 96000)

        numBitrate.Minimum = 1
        numBitrate.Maximum = 16000
        numGain.DecimalPlaces = 1
        numGain.Increment = 0.5

        cbDefaultTrack.Visible = TypeOf p.VideoEncoder.Muxer Is MkvMuxer
        cbForcedTrack.Visible = TypeOf p.VideoEncoder.Muxer Is MkvMuxer

        If components Is Nothing Then
            components = New System.ComponentModel.Container
        End If

        rtbCommandLine.ScrollBars = RichTextBoxScrollBars.None

        Dim cms As New ContextMenuStripEx(components)
        bnMenu.ContextMenuStrip = cms

        cms.Add("Copy Command Line", Sub() Clipboard.SetText(TempProfile.GetCommandLine(True))).SetImage(Symbol.Copy)
        cms.Add("Execute Command Line", AddressOf Execute).SetImage(Symbol.fa_terminal)
        cms.Add("Show Command Line...", Sub() g.ShowCommandLinePreview("Command Line", TempProfile.GetCommandLine(True)))
        cms.Add("-")
        cms.Add("Save Profile...", AddressOf SaveProfile, "Saves the current settings as profile").SetImage(Symbol.Save)
        cms.Add("-")
        cms.Add("Help", AddressOf ShowHelp).SetImage(Symbol.Help)
        cms.Add("eac3to Help", Sub() g.ShellExecute("http://en.wikibooks.org/wiki/Eac3to"))
        cms.Add("ffmpeg Help", Sub() Package.ffmpeg.ShowHelp())

        TipProvider.SetTip("Defines which decoder to use and forces decoding even if not necessary.", laDecoder, mbDecoder)
        TipProvider.SetTip("Profile name that is auto generated when undefined.", laProfileName)
        TipProvider.SetTip("Language used by the muxer. Saved in projects/templates but not in profiles.", mbLanguage, lLanguage)
        TipProvider.SetTip("Delay in milliseconds. eac3to handles delay, ffmpeg don't but it is handled by the muxer. Saved in projects/templates but not in profiles.", numDelay, lDelay)
        TipProvider.SetTip("Track name used by the muxer.", tbStreamName, laStreamName)
        TipProvider.SetTip("Custom command line arguments.", tbCustom, laCustom)
        TipProvider.SetTip("Default MKV Track.", cbDefaultTrack)
        TipProvider.SetTip("Forced MKV Track.", cbForcedTrack)
    End Sub

    Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
        If DialogResult = DialogResult.OK Then
            SetValues(Profile)
        End If
    End Sub

    Protected Overrides Sub OnShown(e As EventArgs)
        UpdateControls()
        Refresh()
        ActiveControl = mbCodec

        For Each lng In Language.Languages
            If lng.IsCommon Then
                mbLanguage.Add(lng.ToString + " (" + lng.TwoLetterCode + ", " + lng.ThreeLetterCode + ")", lng)
            Else
                mbLanguage.Add("More | " + lng.ToString.Substring(0, 1).ToUpper + " | " + lng.ToString + " (" + lng.TwoLetterCode + ", " + lng.ThreeLetterCode + ")", lng)
            End If
        Next
    End Sub

    Sub SetValues(gap As GUIAudioProfile)
        gap.Bitrate = TempProfile.Bitrate
        gap.Language = TempProfile.Language
        gap.Delay = TempProfile.Delay
        gap.Name = TempProfile.Name
        gap.StreamName = TempProfile.StreamName
        gap.Gain = TempProfile.Gain
        gap.Default = TempProfile.Default
        gap.Forced = TempProfile.Forced
        gap.Params = TempProfile.Params
        gap.Decoder = TempProfile.Decoder
        gap.DecodingMode = TempProfile.DecodingMode
        gap.ExtractDTSCore = TempProfile.ExtractDTSCore
        gap.Depth = TempProfile.Depth
    End Sub

    Sub UpdateBitrate()
        nudQuality_ValueChanged(numQuality)
    End Sub

    Sub nudQuality_ValueChanged(numEdit As NumEdit) Handles numQuality.ValueChanged
        If Not TempProfile Is Nothing Then
            TempProfile.Params.Quality = CSng(numQuality.Value)
            numBitrate.Value = TempProfile.GetBitrate
            UpdateControls()
        End If
    End Sub

    Sub nudBitrate_ValueChanged(numEdit As NumEdit) Handles numBitrate.ValueChanged
        If Not TempProfile Is Nothing Then
            TempProfile.Bitrate = CSng(numBitrate.Value)
            UpdateControls()
        End If
    End Sub

    Sub nudDelay_ValueChanged(numEdit As NumEdit) Handles numDelay.ValueChanged
        TempProfile.Delay = CInt(numDelay.Value)
        UpdateControls()
    End Sub

    Sub numGain_ValueChanged(numEdit As NumEdit) Handles numGain.ValueChanged
        TempProfile.Gain = CSng(numGain.Value)
        UpdateControls()
    End Sub

    Sub SimpleUIValueChanged()
        SimpleUI.Save()
        UpdateControls()
    End Sub

    Sub UpdateControls()
        If TempProfile.ExtractCore Then
            numQuality.Enabled = False
            numBitrate.Enabled = False
            If Not numFFLFEMixLevel Is Nothing Then
                numFFLFEMixLevel.Enabled = False
            End If
        ElseIf TempProfile.Params.Codec = AudioCodec.WavPack Then
            numQuality.Enabled = False
            numBitrate.Enabled = TempProfile.Params.WavPackMode = 1
            If Not numFFLFEMixLevel Is Nothing Then
                numFFLFEMixLevel.Enabled = True
            End If
        Else
            Select Case TempProfile.Params.Codec
                Case AudioCodec.Opus, AudioCodec.FLAC, AudioCodec.W64, AudioCodec.WAV, AudioCodec.DTS
                    numQuality.Enabled = False
                Case Else
                    numQuality.Enabled = TempProfile.Params.RateMode = AudioRateMode.VBR
            End Select

            If TempProfile.Params.Codec = AudioCodec.FLAC Then
                numBitrate.Enabled = False
            Else
                numBitrate.Enabled = Not numQuality.Enabled
            End If
            If Not numFFLFEMixLevel Is Nothing Then
                numFFLFEMixLevel.Enabled = True
            End If
        End If

        mbDecoder.Enabled = Not TempProfile.ExtractCore
        mbChannels.Enabled = Not TempProfile.ExtractCore
        mbSamplingRate.Enabled = Not TempProfile.ExtractCore
        cbNormalize.Enabled = Not TempProfile.ExtractCore
        numGain.Enabled = Not TempProfile.ExtractCore
        numBitrate.Increment = If({AudioCodec.AC3, AudioCodec.EAC3}.Contains(TempProfile.Params.Codec), 32D, 8D)
        tbProfileName.SendMessageCue(TempProfile.Name, False)
        rtbCommandLine.SetText(TempProfile.GetCommandLine(False))
        rtbCommandLine.UpdateHeight()
    End Sub

    Sub mbCodec_ValueChangedUser() Handles mbCodec.ValueChangedUser
        TempProfile.Params.Codec = mbCodec.GetValue(Of AudioCodec)()

        Select Case TempProfile.Params.Codec
            Case AudioCodec.AAC
                Select Case TempProfile.Params.Encoder
                    Case GuiAudioEncoder.qaac, GuiAudioEncoder.Automatic
                        SetQuality(54)
                        TempProfile.Params.qaacQuality = 2
                        TempProfile.Params.qaacLowpass = 0
                        TempProfile.Params.qaacRateMode = 0
                    Case GuiAudioEncoder.eac3to
                        SetQuality(0.5)
                    Case GuiAudioEncoder.fdkaac, GuiAudioEncoder.ffmpeg
                        SetQuality(3)
                    Case Else
                        SetQuality(54)
                        TempProfile.Params.qaacQuality = 2
                        TempProfile.Params.qaacLowpass = 0
                        TempProfile.Params.qaacRateMode = 0
                End Select

                TempProfile.Params.RateMode = AudioRateMode.VBR
            Case AudioCodec.AC3, AudioCodec.EAC3
                If TempProfile.Channels = 6 Then
                    numBitrate.Value = 448
                Else
                    numBitrate.Value = 224
                End If

                TempProfile.Params.RateMode = AudioRateMode.CBR
            Case AudioCodec.FLAC
                TempProfile.Params.ffmpegCompressionLevel = 5
                TempProfile.Depth = 0
                numBitrate.Value = TempProfile.GetBitrate
                TempProfile.Params.RateMode = AudioRateMode.CBR

            Case AudioCodec.WavPack
                TempProfile.Params.WavPackMode = 0
                numBitrate.Value = TempProfile.GetBitrate
                TempProfile.Params.WavPackCreateCorrection = False
                TempProfile.Params.ffmpegCompressionLevel = 1
                TempProfile.Depth = If(TempProfile.GetEncoder() = GuiAudioEncoder.ffmpeg, 0, 32)
                TempProfile.Params.RateMode = AudioRateMode.CBR
                TempProfile.Params.WavPackCompression = 1
                TempProfile.Params.WavPackExtraCompression = 0
                TempProfile.Params.WavPackPreQuant = 0

            Case AudioCodec.W64
                TempProfile.Depth = 0

            Case AudioCodec.WAV
                TempProfile.Depth = 0

            Case AudioCodec.DTS
                If TempProfile.Channels = 6 Then
                    numBitrate.Value = 1536
                Else
                    numBitrate.Value = 768
                End If

                TempProfile.Params.RateMode = AudioRateMode.CBR
            Case AudioCodec.MP3
                SetQuality(4)
                TempProfile.Params.RateMode = AudioRateMode.VBR
                TempProfile.Params.ffmpegMp3Cutoff = 0
            Case AudioCodec.Vorbis
                SetQuality(1)
                TempProfile.Params.RateMode = AudioRateMode.VBR
            Case AudioCodec.Opus
                numBitrate.Value = If(TempProfile.Channels = 6, 256, TempProfile.Channels * 96 / 2)
                TempProfile.Params.RateMode = AudioRateMode.VBR
                TempProfile.Params.opusEncMode = OpusEncMode.VBR
                TempProfile.Params.opusEncComplexity = 10
                TempProfile.Params.opusEncFramesize = 20
                TempProfile.Params.opusEncNoPhaseInv = False
                TempProfile.Params.ffmpegOpusCompress = 10
                TempProfile.Params.ffmpegOpusRateMode = OpusRateMode.VBR
                TempProfile.Params.ffmpegOpusApp = OpusApp.audio
                TempProfile.Params.ffmpegOpusFrame = 20
                TempProfile.Params.ffmpegOpusPacket = 0
                TempProfile.Params.ffmpegOpusMap = If(TempProfile.Channels > 5, 1, 0)
                'Opus workaround for side channels
                If TempProfile.GetEncoder() = GuiAudioEncoder.ffmpeg Then ChannelsModeToChannel = TempProfile.Channels
        End Select

        UpdateBitrate()
        TempProfile.GetCommandLine(False) 'set encoder
        LoadAdvanced()
        UpdateControls()
    End Sub

    Sub SetQuality(value As Single)
        If TempProfile.Params.Codec = AudioCodec.AAC Then
            Select Case TempProfile.Params.Encoder
                Case GuiAudioEncoder.qaac, GuiAudioEncoder.Automatic
                    numQuality.Minimum = 0
                    numQuality.Maximum = 127
                    numQuality.Increment = 9
                    numQuality.DecimalPlaces = 0
                Case GuiAudioEncoder.eac3to
                    numQuality.Minimum = 0
                    numQuality.Maximum = 1
                    numQuality.Increment = 0.01
                    numQuality.DecimalPlaces = 2
                Case GuiAudioEncoder.fdkaac, GuiAudioEncoder.ffmpeg
                    numQuality.Minimum = 1
                    numQuality.Maximum = 5
                    numQuality.Increment = 1
                    numQuality.DecimalPlaces = 0
                Case Else
                    numQuality.Minimum = 0
                    numQuality.Maximum = 127
                    numQuality.Increment = 9
                    numQuality.DecimalPlaces = 0
            End Select
        ElseIf TempProfile.Params.Codec = AudioCodec.MP3 Then
            numQuality.Minimum = 0
            numQuality.Maximum = 9
            numQuality.Increment = 1
            numQuality.DecimalPlaces = 0
        ElseIf TempProfile.Params.Codec = AudioCodec.Vorbis Then
            numQuality.Minimum = 0
            numQuality.Maximum = 10
            numQuality.Increment = 1
            numQuality.DecimalPlaces = 0
        Else
            numQuality.Minimum = 0
            numQuality.Maximum = Integer.MaxValue
            numQuality.Increment = 0.1
            numQuality.DecimalPlaces = 2
        End If

        numQuality.Value = value
    End Sub

    Sub mbSamplingRate_ValueChanged() Handles mbSamplingRate.ValueChangedUser
        TempProfile.Params.SamplingRate = mbSamplingRate.GetValue(Of Integer)()
        UpdateBitrate()
        UpdateControls()
    End Sub

    Sub mbLanguage_ValueChanged() Handles mbLanguage.ValueChangedUser
        TempProfile.Language = mbLanguage.GetValue(Of Language)()
        mbLanguage.Text = TempProfile.Language.Name
        UpdateControls()
    End Sub

    Sub tbName_TextChanged(sender As Object, e As EventArgs) Handles tbProfileName.TextChanged
        TempProfile.Name = tbProfileName.Text
        UpdateControls()
    End Sub

    Sub SaveProfile()
        Dim gap = ObjectHelp.GetCopy(Of GUIAudioProfile)(TempProfile)
        Dim name = InputBox.Show("Enter the profile name.", "Save Profile", gap.Name)

        If name <> "" Then
            gap.Name = name
            s.AudioProfiles.Add(gap)
            MsgInfo("The profile was saved.")
        End If
    End Sub

    Sub LoadProfile(gap As GUIAudioProfile)
        Profile = gap
        TempProfile = ObjectHelp.GetCopy(Of GUIAudioProfile)(gap)
        LoadProfile()
    End Sub

    Sub LoadProfile()
        If TempProfile.Name <> TempProfile.DefaultName Then
            tbProfileName.Text = TempProfile.Name
        End If

        tbProfileName.SendMessageCue(TempProfile.Name, False)

        tbCustom.Text = TempProfile.Params.CustomSwitches
        tbStreamName.Text = TempProfile.StreamName

        cbDefaultTrack.Checked = TempProfile.Default
        cbForcedTrack.Checked = TempProfile.Forced
        cbNormalize.Checked = TempProfile.Params.Normalize

        mbCodec.Value = TempProfile.Params.Codec
        mbChannels.Value = TempProfile.Params.ChannelsMode
        mbLanguage.Value = TempProfile.Language
        mbSamplingRate.Value = TempProfile.Params.SamplingRate
        mbEncoder.Value = TempProfile.Params.Encoder
        mbDecoder.Value = TempProfile.Decoder

        SetQuality(TempProfile.Params.Quality)

        numBitrate.Value = TempProfile.Bitrate
        numDelay.Value = TempProfile.Delay
        numGain.Value = TempProfile.Gain

        LoadAdvanced()
        UpdateControls()
    End Sub

    Sub SetBitrate(v As Integer)
        numBitrate.Value = v
    End Sub

    Private numFFLFEMixLevel As SimpleUI.NumBlock

    Sub LoadAdvanced()
        RemoveHandler SimpleUI.ValueChanged, AddressOf SimpleUIValueChanged

        Dim ui = SimpleUI
        ui.Store = TempProfile.Params
        ui.Host.Controls.Clear()

        If Not ui.ActivePage Is Nothing Then
            DirectCast(ui.ActivePage, Control).Dispose()
        End If

        Dim page = ui.CreateFlowPage()
        page.SuspendLayout()

        'To DO : move away from advanced to main audio options?  ,add handler:
        If TempProfile.Params.ChannelsMode <> ChannelsMode.Original AndAlso TempProfile.Params.ChannelsMode < 3 AndAlso
           Not ({GuiAudioEncoder.eac3to}.Contains(TempProfile.GetEncoder()) AndAlso TempProfile.DecodingMode = TempProfile.DecodingMode.Pipe) Then
            numFFLFEMixLevel = ui.AddNum(page)
            numFFLFEMixLevel.Text = "FF LFE Downmix"
            numFFLFEMixLevel.NumEdit.Config = {-31, 31, 0.1, 3}
            numFFLFEMixLevel.Help = "Value 1.0 sets matrix coef. for LFE equal to other channels, ffmpeg default 0 means no LFE in 1C/2C downmix"
            numFFLFEMixLevel.NumEdit.Value = (Math.Round(TempProfile.Params.ffmpegLFEMixLevel, 3))
            numFFLFEMixLevel.NumEdit.SaveAction = Sub(value)
                                                      TempProfile.Params.ffmpegLFEMixLevel = (Math.Round(value, 3))
                                                  End Sub
        End If

        If {AudioCodec.W64, AudioCodec.WAV, AudioCodec.FLAC, AudioCodec.WavPack}.Contains(TempProfile.Params.Codec) Then
            Dim mDepth = ui.AddMenu(Of Integer)
            mDepth.Text = "Depth:"
            mDepth.Expandet = True
            mDepth.Add("Default", 0)
            mDepth.Add("16", 16)
            mDepth.Add("24", 24)
            If {AudioCodec.WAV, AudioCodec.WavPack, AudioCodec.W64}.Contains(TempProfile.Params.Codec) Then
                mDepth.Add("32 fp", 32)
            End If
            mDepth.Button.Value = TempProfile.Depth
            mDepth.Button.SaveAction = Sub(val)
                                           TempProfile.Depth = val
                                           UpdateBitrate()
                                           UpdateControls()
                                       End Sub

        End If

        Dim cb As SimpleUI.SimpleUICheckBox

        Dim cbCreateCorrectionWVC As SimpleUI.SimpleUICheckBox

        Select Case TempProfile.GetEncoder
            Case GuiAudioEncoder.eac3to
                Dim mbFrameRateMode = ui.AddMenu(Of AudioFrameRateMode)(page)
                mbFrameRateMode.Label.Text = "Frame rate:"
                mbFrameRateMode.Button.Expand = True
                mbFrameRateMode.Button.Value = TempProfile.Params.FrameRateMode
                mbFrameRateMode.Button.SaveAction = Sub(value) TempProfile.Params.FrameRateMode = value

                Dim mbStereoDownmix = ui.AddMenu(Of Integer)(page)
                mbStereoDownmix.Label.Text = "Stereo Downmix:"
                mbStereoDownmix.Button.Expand = True
                mbStereoDownmix.Button.Add("Simple", 0)
                mbStereoDownmix.Button.Add("DPL II", 1)
                mbStereoDownmix.Button.Value = TempProfile.Params.eac3toStereoDownmixMode
                mbStereoDownmix.Button.SaveAction = Sub(value) TempProfile.Params.eac3toStereoDownmixMode = value

                If (TempProfile.File = "" OrElse TempProfile.File.ToLower.Contains("dts") OrElse
                    (Not TempProfile.Stream Is Nothing AndAlso TempProfile.Stream.Name.Contains("DTS"))) AndAlso
                    TempProfile.Params.Codec = AudioCodec.DTS Then

                    cb = ui.AddBool(page)
                    cb.Text = "Extract DTS core"
                    cb.Checked = TempProfile.ExtractDTSCore
                    cb.SaveAction = Sub(value)
                                        TempProfile.ExtractDTSCore = value
                                        UpdateControls()
                                    End Sub
                End If
            Case GuiAudioEncoder.ffmpeg
                Select Case TempProfile.Params.Codec

                    Case AudioCodec.FLAC, AudioCodec.WavPack
                        Dim mCompressionLevel = ui.AddNum(page)
                        mCompressionLevel.Text = "Compression Level"
                        If TempProfile.Params.Codec = AudioCodec.FLAC Then
                            mCompressionLevel.NumEdit.Config = {0, 12}
                            ui.AddLabel("Over 10 is non-subset, could be unplayable")
                            'Over 10 are non-subset FLAC!!! addlabel,color?
                        Else
                            mCompressionLevel.NumEdit.Config = {0, 8}
                        End If
                        mCompressionLevel.NumEdit.Value = TempProfile.Params.ffmpegCompressionLevel
                        mCompressionLevel.NumEdit.SaveAction = Sub(value) TempProfile.Params.ffmpegCompressionLevel = CInt(value)

                    Case AudioCodec.DTS, AudioCodec.AC3, AudioCodec.EAC3
                    Case AudioCodec.AAC
                        Dim mbRateMode = ui.AddMenu(Of SimpleAudioRateMode)
                        mbRateMode.Text = "Rate Mode"
                        mbRateMode.Expandet = True
                        mbRateMode.Button.Value = TempProfile.Params.SimpleRateMode
                        mbRateMode.Button.SaveAction = Sub(value) TempProfile.Params.SimpleRateMode = value

                        cb = ui.AddBool
                        cb.Text = "Use fdk-aac"
                        cb.Property = NameOf(TempProfile.Params.ffmpegLibFdkAAC)
                    Case AudioCodec.Opus
                        Dim mbRateMode = ui.AddMenu(Of OpusRateMode)
                        mbRateMode.Text = "Rate Mode"
                        mbRateMode.Expandet = True
                        mbRateMode.Button.Value = TempProfile.Params.ffmpegOpusRateMode
                        mbRateMode.Button.SaveAction =
                            Sub(value)
                                TempProfile.Params.ffmpegOpusRateMode = value
                                TempProfile.Params.RateMode = If(TempProfile.Params.ffmpegOpusRateMode = OpusRateMode.VBR, AudioRateMode.VBR, AudioRateMode.CBR)
                            End Sub

                        Dim mbOpusApp = ui.AddMenu(Of OpusApp)
                        mbOpusApp.Text = "Application Type"
                        mbOpusApp.Expandet = True
                        mbOpusApp.Button.Value = TempProfile.Params.ffmpegOpusApp
                        mbOpusApp.Button.SaveAction = Sub(value) TempProfile.Params.ffmpegOpusApp = value

                        Dim frame = ui.AddMenu(Of Double)
                        frame.Text = "Frame Duration"
                        frame.Expandet = True
                        frame.Add("2.5", 2.5)
                        frame.Add("5", 5)
                        frame.Add("10", 10)
                        frame.Add("20", 20)
                        frame.Add("40", 40)
                        frame.Add("60", 60)
                        frame.Property = NameOf(TempProfile.Params.ffmpegOpusFrame)

                        Dim mMappingFamily = ui.AddMenu(Of Integer)
                        mMappingFamily.Text = "MappingFamily"
                        mMappingFamily.Expandet = True
                        mMappingFamily.Add("No surr.masking and LFE opt.", -1)
                        mMappingFamily.Add("Mono/Stereo 2 channels", 0)
                        mMappingFamily.Add("Masking and LFE opt.8Ch max", 1)
                        mMappingFamily.Add("Ambisonics as individual ch.", 2)
                        mMappingFamily.Add("Ambisonics with demixing", 3)
                        mMappingFamily.Add("Discrete channels 255Ch max", 255)
                        ui.AddLabel("Mapping Family 1 is the best for multichannel,")
                        ui.AddLabel("however in FFmpeg this may fail. Forcing channels can help   ")
                        'mMappingFamily.Help = "https://ffmpeg.org/ffmpeg-codecs.html#Option-Mapping"
                        mMappingFamily.Help = "https://tools.ietf.org/html/draft-ietf-codec-ambisonics-10#section-8"
                        mMappingFamily.Property = NameOf(TempProfile.Params.ffmpegOpusMap)

                        cb = ui.AddBool(page)
                        cb.Text = "No phase inversion for intensity stereo"
                        cb.Checked = TempProfile.Params.opusEncNoPhaseInv
                        cb.SaveAction = Sub(value) TempProfile.Params.opusEncNoPhaseInv = value

                        Dim comp = ui.AddNum(page)
                        comp.Text = "Compression Level"
                        comp.Config = {0, 10, 1}
                        comp.NumEdit.Value = TempProfile.Params.ffmpegOpusCompress
                        comp.NumEdit.SaveAction = Sub(value) TempProfile.Params.ffmpegOpusCompress = CInt(value)

                        Dim packet = ui.AddNum(page)
                        packet.Text = "Packet Loss"
                        packet.Config = {0, 100, 1}
                        packet.NumEdit.Value = TempProfile.Params.ffmpegOpusPacket
                        packet.NumEdit.SaveAction = Sub(value) TempProfile.Params.ffmpegOpusPacket = CInt(value)
                    Case Else
                        If Not {AudioCodec.WAV, AudioCodec.W64}.Contains(TempProfile.Params.Codec) Then
                            Dim mbRateMode = ui.AddMenu(Of AudioRateMode)
                            mbRateMode.Text = "Rate Mode:"
                            mbRateMode.Expandet = True
                            mbRateMode.Button.Value = TempProfile.Params.RateMode
                            mbRateMode.Button.SaveAction = Sub(value) TempProfile.Params.RateMode = value
                        End If
                End Select

                If TempProfile.Params.Codec = AudioCodec.MP3 Then
                    Dim num = ui.AddNum(page)
                    num.Text = "Lowpass"
                    num.Config = {0, 48000, 100}
                    num.NumEdit.Value = TempProfile.Params.ffmpegMp3Cutoff
                    num.NumEdit.SaveAction = Sub(value) TempProfile.Params.ffmpegMp3Cutoff = CInt(value)

                End If

                If (TempProfile.File = "" OrElse TempProfile.File.ToLower.Contains("dts") OrElse
                        (Not TempProfile.Stream Is Nothing AndAlso
                        TempProfile.Stream.Name.Contains("DTS"))) AndAlso
                        TempProfile.Params.Codec = AudioCodec.DTS Then

                    cb = ui.AddBool(page)
                    cb.Text = "Extract DTS core"
                    cb.Checked = TempProfile.ExtractDTSCore
                    cb.SaveAction = Sub(value)
                                        TempProfile.ExtractDTSCore = value
                                        UpdateControls()
                                    End Sub
                End If
            Case GuiAudioEncoder.fdkaac
                Dim getHelpAction = Function(switch As String) Sub() g.ShowCommandLineHelp(Package.fdkaac, switch)

                Dim modeMenu = ui.AddMenu(Of SimpleAudioRateMode)
                modeMenu.Text = "Rate Mode"
                modeMenu.Expandet = True
                modeMenu.HelpAction = getHelpAction("--bitrate-mode")
                modeMenu.Button.Value = TempProfile.Params.SimpleRateMode
                modeMenu.Button.SaveAction = Sub(value)
                                                 TempProfile.Params.SimpleRateMode = value
                                                 UpdateBitrate()
                                             End Sub

                Dim profileMenu = ui.AddMenu(Of Integer)
                profileMenu.Text = "Profile"
                profileMenu.Expandet = True
                profileMenu.HelpAction = getHelpAction("--profile")
                profileMenu.Add("AAC LC", 2)
                profileMenu.Add("HE-AAC SBR", 5)
                profileMenu.Add("HE-AAC SBR+PS", 29)
                profileMenu.Add("AAC LD", 23)
                profileMenu.Add("AAC ELD", 39)
                profileMenu.Property = NameOf(TempProfile.Params.fdkaacProfile)

                Dim lowDelaySBR = ui.AddMenu(Of Integer)
                lowDelaySBR.Text = "Lowdelay SBR"
                lowDelaySBR.Expandet = True
                lowDelaySBR.HelpAction = getHelpAction("--lowdelay-sbr")
                lowDelaySBR.Add("ELD SBR auto configuration", -1)
                lowDelaySBR.Add("Disable SBR on ELD", 0)
                lowDelaySBR.Add("Enable SBR on ELD", 1)
                lowDelaySBR.Property = NameOf(TempProfile.Params.fdkaacLowDelaySBR)

                Dim sbrRatio = ui.AddMenu(Of Integer)
                sbrRatio.Text = "SBR Ratio"
                sbrRatio.Expandet = True
                sbrRatio.HelpAction = getHelpAction("--sbr-ratio")
                sbrRatio.Add("Library Default", 0)
                sbrRatio.Add("Downsampled SBR (ELD+SBR default)", 1)
                sbrRatio.Add("Dual-rate SBR (HE-AAC default)", 2)
                sbrRatio.Property = NameOf(TempProfile.Params.fdkaacSbrRatio)

                Dim gaplessMode = ui.AddMenu(Of Integer)
                gaplessMode.Text = "Gapless Mode"
                gaplessMode.Expandet = True
                gaplessMode.HelpAction = getHelpAction("--gapless-mode")
                gaplessMode.Add("iTunSMPB", 0)
                gaplessMode.Add("ISO Standard (EDTS And SGPD)", 1)
                gaplessMode.Add("Both", 2)
                gaplessMode.Property = NameOf(TempProfile.Params.fdkaacGaplessMode)

                Dim transportFormat = ui.AddMenu(Of Integer)
                transportFormat.Text = "Transport Format"
                transportFormat.Expandet = True
                transportFormat.HelpAction = getHelpAction("--transport-format")
                transportFormat.Add("M4A", 0)
                transportFormat.Add("ADIF", 1)
                transportFormat.Add("ADTS", 2)
                transportFormat.Add("LATM MCP=1", 6)
                transportFormat.Add("LATM MCP=0", 7)
                transportFormat.Add("LOAS/LATM (LATM within LOAS)", 10)
                transportFormat.Property = NameOf(TempProfile.Params.fdkaacTransportFormat)

                Dim n = ui.AddNum
                n.Text = "Bandwidth"
                n.HelpAction = getHelpAction("--bandwidth")
                n.Property = NameOf(TempProfile.Params.fdkaacBandwidth)

                cb = ui.AddBool
                cb.Text = "Afterburner"
                cb.HelpAction = getHelpAction("--afterburner")
                cb.Property = NameOf(TempProfile.Params.fdkaacAfterburner)

                cb = ui.AddBool
                cb.Text = "Add CRC Check on ADTS header"
                cb.HelpAction = getHelpAction("--adts-crc-check")
                cb.Property = NameOf(TempProfile.Params.fdkaacAdtsCrcCheck)

                cb = ui.AddBool
                cb.Text = "Header Period"
                cb.HelpAction = getHelpAction("--header-period")
                cb.Property = NameOf(TempProfile.Params.fdkaacHeaderPeriod)

                cb = ui.AddBool
                cb.Text = "Include SBR Delay"
                cb.HelpAction = getHelpAction("--include-sbr-delay")
                cb.Property = NameOf(TempProfile.Params.fdkaacIncludeSbrDelay)

                cb = ui.AddBool
                cb.Text = "Place moov box before mdat box"
                cb.HelpAction = getHelpAction("--moov-before-mdat")
                cb.Property = NameOf(TempProfile.Params.fdkaacMoovBeforeMdat)
            Case GuiAudioEncoder.qaac
                Dim mbMode = ui.AddMenu(Of Integer)
                mbMode.Text = "Mode"
                mbMode.Expandet = True
                mbMode.Add("True VBR", 0)
                mbMode.Add("Constrained VBR", 1)
                mbMode.Add("ABR", 2)
                mbMode.Add("CBR", 3)
                mbMode.Button.Value = TempProfile.Params.qaacRateMode
                mbMode.Button.SaveAction = Sub(value)
                                               TempProfile.Params.qaacRateMode = value
                                               TempProfile.Params.RateMode = If(TempProfile.Params.qaacRateMode = 0, AudioRateMode.VBR, AudioRateMode.CBR)
                                               UpdateBitrate()
                                           End Sub

                Dim mbQuality = ui.AddMenu(Of Integer)(page)
                mbQuality.Label.Text = "Quality"
                mbQuality.Button.Expand = True
                mbQuality.Button.Add("Low", 0)
                mbQuality.Button.Add("Medium", 1)
                mbQuality.Button.Add("High", 2)
                mbQuality.Button.Value = TempProfile.Params.qaacQuality
                mbQuality.Button.SaveAction = Sub(value) TempProfile.Params.qaacQuality = value

                Dim num = ui.AddNum(page)
                num.Text = "Lowpass"
                num.Config = {0, 48000, 100}
                num.NumEdit.Value = TempProfile.Params.qaacLowpass
                num.NumEdit.SaveAction = Sub(value) TempProfile.Params.qaacLowpass = CInt(value)

                Dim cbqaacHE = ui.AddBool(page)
                cbqaacHE.Text = "High Efficiency"
                cbqaacHE.Checked = TempProfile.Params.qaacHE
                cbqaacHE.SaveAction = Sub(value) TempProfile.Params.qaacHE = value
                AddHandler cbqaacHE.CheckedChanged, Sub() If cbqaacHE.Checked Then If mbMode.Button.Value = 0 Then mbMode.Button.Value = 1
                AddHandler mbMode.Button.ValueChangedUser, Sub()
                                                               'cbqaacHE.Enabled = mbMode.Button.Value <> 0
                                                               If mbMode.Button.Value = 0 Then cbqaacHE.Checked = False
                                                           End Sub

                cb = ui.AddBool(page)
                cb.Text = "No dither when quantizing to lower bit depth"
                cb.Checked = TempProfile.Params.qaacNoDither
                cb.SaveAction = Sub(value) TempProfile.Params.qaacNoDither = value

            Case GuiAudioEncoder.WavPack
                Dim mbWavPackMode = ui.AddMenu(Of Integer)
                mbWavPackMode.Text = "Mode"
                mbWavPackMode.Expandet = True
                mbWavPackMode.Add("Lossless", 0)
                mbWavPackMode.Add("Lossy CBR", 1)
                mbWavPackMode.Button.Value = TempProfile.Params.WavPackMode
                mbWavPackMode.Button.SaveAction = Sub(value)
                                                      TempProfile.Params.WavPackMode = value
                                                      If TempProfile.Params.WavPackMode = 1 Then
                                                          TempProfile.Params.RateMode = AudioRateMode.CBR
                                                          'numBitrate.Value = TempProfile.Channels * 320 / 2
                                                          numBitrate.Value = If(TempProfile.Channels = 2, TempProfile.Channels * 384 / 2, TempProfile.Channels * 320 / 2)
                                                          cbCreateCorrectionWVC.Enabled = True
                                                      Else
                                                          cbCreateCorrectionWVC.Enabled = False
                                                          TempProfile.Params.WavPackCreateCorrection = False
                                                          UpdateBitrate()
                                                      End If
                                                  End Sub
                If TempProfile.Params.WavPackMode = 0 Then TempProfile.Params.WavPackCreateCorrection = False

                Dim mCompression = ui.AddMenu(Of Integer)
                mCompression.Text = "Comp/Decomp Mode"
                mCompression.Expandet = True
                mCompression.Add("Fast", 0)
                mCompression.Add("Normal", 1)
                mCompression.Add("High", 2)
                mCompression.Add("Very High", 3)
                mCompression.Button.Value = TempProfile.Params.WavPackCompression
                mCompression.Button.SaveAction = Sub(value) TempProfile.Params.WavPackCompression = value

                Dim mExtraCompression = ui.AddNum(page)
                mExtraCompression.Text = "Extra Compression"
                mExtraCompression.Config = {0, 6}
                mExtraCompression.NumEdit.Value = TempProfile.Params.WavPackExtraCompression
                mExtraCompression.NumEdit.SaveAction = Sub(value) TempProfile.Params.WavPackExtraCompression = CInt(value)

                Dim mPreQuant = ui.AddNum(page)
                mPreQuant.Text = "Pre-Quantitize bits"
                mPreQuant.Config = {0, 24}
                mPreQuant.NumEdit.Value = TempProfile.Params.WavPackPreQuant
                mPreQuant.NumEdit.SaveAction = Sub(value)
                                                   TempProfile.Params.WavPackPreQuant = CInt(value)
                                                   UpdateBitrate()
                                               End Sub

                cbCreateCorrectionWVC = ui.AddBool(page)
                cbCreateCorrectionWVC.Text = "Create correction file"
                cbCreateCorrectionWVC.Checked = TempProfile.Params.WavPackCreateCorrection
                cbCreateCorrectionWVC.SaveAction = Sub(value) TempProfile.Params.WavPackCreateCorrection = value
                cbCreateCorrectionWVC.Enabled = TempProfile.Params.WavPackMode = 1

            Case GuiAudioEncoder.OpusEnc
                Dim mbOpusMode = ui.AddMenu(Of OpusEncMode)
                mbOpusMode.Text = "Mode"
                mbOpusMode.Expandet = True
                mbOpusMode.Button.Value = TempProfile.Params.opusEncMode
                mbOpusMode.Button.SaveAction =
                    Sub(value)
                        TempProfile.Params.opusEncMode = value
                        TempProfile.Params.RateMode = If(TempProfile.Params.opusEncMode = 0, AudioRateMode.VBR, AudioRateMode.CBR)
                    End Sub

                Dim mFrameSize = ui.AddMenu(Of Double)(page)
                mFrameSize.Text = "Frame Size"
                mFrameSize.Expandet = True
                mFrameSize.Add("2.5 ms", 2.5)
                mFrameSize.Add("5 ms", 5)
                mFrameSize.Add("10 ms", 10)
                mFrameSize.Add("20 ms", 20)
                mFrameSize.Add("40 ms", 40)
                mFrameSize.Add("60 ms", 60)
                mFrameSize.Button.Value = TempProfile.Params.opusEncFramesize
                mFrameSize.Button.SaveAction = Sub(value) TempProfile.Params.opusEncFramesize = value

                Dim mComplexity = ui.AddNum(page)
                mComplexity.Text = "Compression Level"
                mComplexity.Config = {0, 10}
                mComplexity.NumEdit.Value = TempProfile.Params.opusEncComplexity
                mComplexity.NumEdit.SaveAction = Sub(value) TempProfile.Params.opusEncComplexity = CInt(value)

                cb = ui.AddBool(page)
                cb.Text = "No phase inversion for intensity stereo"
                cb.Checked = TempProfile.Params.opusEncNoPhaseInv
                cb.SaveAction = Sub(value) TempProfile.Params.opusEncNoPhaseInv = value

                'More options(like in ffmpeg wrapper) are propably not worthy exposing

        End Select

        page.ResumeLayout(True)
        AddHandler SimpleUI.ValueChanged, AddressOf SimpleUIValueChanged
    End Sub

    Sub nudBitrate_KeyUp(sender As Object, e As KeyEventArgs) Handles numBitrate.KeyUp
        Try
            Dim v = CInt(numBitrate.Text)

            If v Mod 16 = 0 Then
                numBitrate.Value = v
            End If
        Catch
        End Try
    End Sub

    Sub nudQuality_KeyUp(sender As Object, e As KeyEventArgs) Handles numQuality.KeyUp
        Try
            Dim v = CInt(numQuality.Text)
            numQuality.Value = v
        Catch
        End Try
    End Sub

    Sub Execute()
        If TempProfile.File <> "" Then
            If Not TempProfile.IsInputSupported AndAlso Not TempProfile.DecodingMode = AudioDecodingMode.Pipe Then
                MsgWarn("The input format isn't supported by the current encoder," + BR + "convert to WAV or FLAC first or enable piping in the options.")
            Else
                Dim pr As New Process
                pr.StartInfo.FileName = "cmd.exe"
                pr.StartInfo.Arguments = "/S /K """ + TempProfile.GetCommandLine(True) + """"
                pr.StartInfo.UseShellExecute = False
                Proc.SetEnvironmentVariables(pr)
                pr.Start()
            End If
        Else
            MsgWarn("Source file is missing!")
        End If
    End Sub

    Sub tbStreamName_TextChanged(sender As Object, e As EventArgs) Handles tbStreamName.TextChanged
        TempProfile.StreamName = tbStreamName.Text
    End Sub

    Sub tbCustom_TextChanged(sender As Object, e As EventArgs) Handles tbCustom.TextChanged
        TempProfile.Params.CustomSwitches = tbCustom.Text
        UpdateControls()
    End Sub

    Sub cbDefaultTrack_CheckedChanged(sender As Object, e As EventArgs) Handles cbDefaultTrack.CheckedChanged
        TempProfile.Default = cbDefaultTrack.Checked
    End Sub

    Sub cbForcedTrack_CheckedChanged(sender As Object, e As EventArgs) Handles cbForcedTrack.CheckedChanged
        TempProfile.Forced = cbForcedTrack.Checked
    End Sub

    Sub mbEncoder_ValueChangedUser(value As Object) Handles mbEncoder.ValueChangedUser
        TempProfile.Params.Encoder = mbEncoder.GetValue(Of GuiAudioEncoder)()
        mbCodec_ValueChangedUser()
    End Sub

    Sub ShowHelp()
        Dim form As New HelpForm()
        form.Doc.WriteStart(Text)
        form.Doc.WriteTips(TipProvider.GetTips, SimpleUI.ActivePage.TipProvider.GetTips)
        form.Show()
    End Sub

    Sub mbChannels_ValueChanged(value As Object) Handles mbChannels.ValueChangedUser
        TempProfile.Params.ChannelsMode = mbChannels.GetValue(Of ChannelsMode)()
        UpdateBitrate()
        LoadAdvanced()
        UpdateControls()
    End Sub

    Sub mbConvertMode_ValueChangedUser(value As Object) Handles mbDecoder.ValueChangedUser
        TempProfile.Decoder = mbDecoder.GetValue(Of AudioDecoderMode)()
        UpdateControls()
    End Sub

    Sub bnAdvanced_Click(sender As Object, e As EventArgs) Handles bnAdvanced.Click
        Using form As New SimpleSettingsForm("Advanced Audio Options")
            form.ScaleClientSize(30, 21)
            Dim ui = form.SimpleUI
            ui.Store = TempProfile.Params

            ui.CreateFlowPage("General", True)

            Dim convFormat = ui.AddMenu(Of AudioDecodingMode)
            convFormat.Text = "Decoding Method:"
            convFormat.Button.Value = TempProfile.DecodingMode
            convFormat.Button.SaveAction = Sub(val) TempProfile.DecodingMode = val

            ui.CreateFlowPage("ffmpeg", True)

            Dim ffmpegNormalize = ui.AddMenu(Of ffmpegNormalizeMode)
            ffmpegNormalize.Text = "Normalize Method:"
            ffmpegNormalize.Property = NameOf(TempProfile.Params.ffmpegNormalizeMode)

            ui.CreateFlowPage("ffmpeg | loudnorm", True)

            ui.AddLabel("EBU R128 Loudness Normalization")

            Dim helpUrl = "https://www.ffmpeg.org/ffmpeg-filters.html#loudnorm"

            Dim n = ui.AddNum()
            n.Text = "Integrated"
            n.Help = helpUrl
            n.Config = {-70.0, -5.0, 0.5, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegLoudnormIntegrated)

            n = ui.AddNum()
            n.Text = "True Peak"
            n.Help = helpUrl
            n.Config = {-9.0, 0, 0.2, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegLoudnormTruePeak)

            n = ui.AddNum()
            n.Text = "LRA"
            n.Help = helpUrl
            n.Config = {1, 20, 0.5, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegLoudnormLRA)

            ui.CreateFlowPage("ffmpeg | dynaudnorm", True)

            ui.AddLabel("Dynamic Audio Normalizer")

            helpUrl = "https://www.ffmpeg.org/ffmpeg-filters.html#dynaudnorm"

            n = ui.AddNum()
            n.Text = "Frame Length"
            n.Help = helpUrl
            n.Config = {10, 8000, 10}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormF)

            n = ui.AddNum()
            n.Text = "Gaus filter win size"
            n.Help = helpUrl
            n.Config = {3, 301}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormG)

            n = ui.AddNum()
            n.Text = "Target Peak"
            n.Help = helpUrl
            n.Config = {0, 1, 0.05, 2}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormP)

            n = ui.AddNum()
            n.Text = "Max gain factor"
            n.Help = helpUrl
            n.Config = {1, 100, 1, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormM)

            n = ui.AddNum()
            n.Text = "Target RMS"
            n.Help = helpUrl
            n.Config = {0, 1, 0.1, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormR)

            n = ui.AddNum()
            n.Text = "Compress factor"
            n.Help = helpUrl
            n.Config = {0, 30, 1, 1}
            n.Property = NameOf(TempProfile.Params.ffmpegDynaudnormS)

            Dim b = ui.AddBool
            b.Text = "Enable channels coupling"
            b.Help = helpUrl
            b.Property = NameOf(TempProfile.Params.ffmpegDynaudnormN)

            b = ui.AddBool
            b.Text = "Enable DC bias correction"
            b.Help = helpUrl
            b.Property = NameOf(TempProfile.Params.ffmpegDynaudnormC)

            b = ui.AddBool
            b.Text = "Enable alternative boundary mode"
            b.Help = helpUrl
            b.Property = NameOf(TempProfile.Params.ffmpegDynaudnormB)

            ui.SelectLast("last advanced audio options page")

            If form.ShowDialog() = DialogResult.OK Then
                ui.Save()
            End If

            LoadAdvanced()
            UpdateControls()
            ui.SaveLast("last advanced audio options page")
        End Using
    End Sub

    Sub cbNormalize_CheckedChanged(sender As Object, e As EventArgs) Handles cbNormalize.CheckedChanged
        TempProfile.Params.Normalize = cbNormalize.Checked
        UpdateControls()
    End Sub

    Sub AudioForm_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        ShowHelp()
    End Sub

    Private WriteOnly Property ChannelsModeToChannel As Integer
        Set(value As Integer)
            Dim channV = [Enum].Parse(GetType(ChannelsMode), "_" & value)
            TempProfile.Params.ChannelsMode = CType(channV, ChannelsMode)
            mbChannels.Value = channV
        End Set
    End Property
End Class
