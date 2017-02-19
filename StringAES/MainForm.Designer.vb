<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.chkWithIV = New System.Windows.Forms.CheckBox()
        Me.btnLoadCipherText = New System.Windows.Forms.Button()
        Me.btnSaveCipherText = New System.Windows.Forms.Button()
        Me.btnPasteCipherText = New System.Windows.Forms.Button()
        Me.btnCopyCipherText = New System.Windows.Forms.Button()
        Me.btnLoadPlainText = New System.Windows.Forms.Button()
        Me.btnSavePlainText = New System.Windows.Forms.Button()
        Me.btnPastePlainText = New System.Windows.Forms.Button()
        Me.btnCopyPlainText = New System.Windows.Forms.Button()
        Me.btnClearInformation = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtInformationOut = New System.Windows.Forms.TextBox()
        Me.chkDefaultIV = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDecryptString = New System.Windows.Forms.Button()
        Me.btnEncryptString = New System.Windows.Forms.Button()
        Me.btnRandomIV = New System.Windows.Forms.Button()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.lblIVTextBox = New System.Windows.Forms.Label()
        Me.txtIV = New System.Windows.Forms.TextBox()
        Me.txtPasswor2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPasswor1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHexCipherText = New System.Windows.Forms.TextBox()
        Me.txtPlainText = New System.Windows.Forms.TextBox()
        Me.sfdSavePlainText = New System.Windows.Forms.SaveFileDialog()
        Me.sfdSaveCipherText = New System.Windows.Forms.SaveFileDialog()
        Me.ofdLoadPlainText = New System.Windows.Forms.OpenFileDialog()
        Me.ofdLoadCipherText = New System.Windows.Forms.OpenFileDialog()
        Me.cmbCipherMode = New System.Windows.Forms.ComboBox()
        Me.cmbPaddingMode = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbKeySize = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbBlockSize = New System.Windows.Forms.ComboBox()
        Me.txtBase64CipherText = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnLoadBase64Cipher = New System.Windows.Forms.Button()
        Me.btnSaveBase64Cipher = New System.Windows.Forms.Button()
        Me.btnPasteBase64Cipher = New System.Windows.Forms.Button()
        Me.btnCopyBase64Cipher = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkWithIV
        '
        Me.chkWithIV.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkWithIV.AutoSize = True
        Me.chkWithIV.Checked = True
        Me.chkWithIV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWithIV.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkWithIV.Location = New System.Drawing.Point(727, 288)
        Me.chkWithIV.Name = "chkWithIV"
        Me.chkWithIV.Size = New System.Drawing.Size(245, 19)
        Me.chkWithIV.TabIndex = 42
        Me.chkWithIV.Text = "复制、保存时包含加密向量(&G)"
        Me.chkWithIV.UseVisualStyleBackColor = True
        '
        'btnLoadCipherText
        '
        Me.btnLoadCipherText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadCipherText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnLoadCipherText.Location = New System.Drawing.Point(897, 259)
        Me.btnLoadCipherText.Name = "btnLoadCipherText"
        Me.btnLoadCipherText.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadCipherText.TabIndex = 46
        Me.btnLoadCipherText.Text = "读取(&O)..."
        Me.btnLoadCipherText.UseVisualStyleBackColor = True
        '
        'btnSaveCipherText
        '
        Me.btnSaveCipherText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveCipherText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSaveCipherText.Location = New System.Drawing.Point(816, 259)
        Me.btnSaveCipherText.Name = "btnSaveCipherText"
        Me.btnSaveCipherText.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveCipherText.TabIndex = 45
        Me.btnSaveCipherText.Text = "保存(&I)..."
        Me.btnSaveCipherText.UseVisualStyleBackColor = True
        '
        'btnPasteCipherText
        '
        Me.btnPasteCipherText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPasteCipherText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnPasteCipherText.Location = New System.Drawing.Point(735, 259)
        Me.btnPasteCipherText.Name = "btnPasteCipherText"
        Me.btnPasteCipherText.Size = New System.Drawing.Size(75, 23)
        Me.btnPasteCipherText.TabIndex = 44
        Me.btnPasteCipherText.Text = "粘贴(&U)"
        Me.btnPasteCipherText.UseVisualStyleBackColor = True
        '
        'btnCopyCipherText
        '
        Me.btnCopyCipherText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyCipherText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnCopyCipherText.Location = New System.Drawing.Point(654, 259)
        Me.btnCopyCipherText.Name = "btnCopyCipherText"
        Me.btnCopyCipherText.Size = New System.Drawing.Size(75, 23)
        Me.btnCopyCipherText.TabIndex = 43
        Me.btnCopyCipherText.Text = "复制(&Y)"
        Me.btnCopyCipherText.UseVisualStyleBackColor = True
        '
        'btnLoadPlainText
        '
        Me.btnLoadPlainText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnLoadPlainText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnLoadPlainText.Location = New System.Drawing.Point(254, 566)
        Me.btnLoadPlainText.Name = "btnLoadPlainText"
        Me.btnLoadPlainText.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadPlainText.TabIndex = 41
        Me.btnLoadPlainText.Text = "读取(&V)..."
        Me.btnLoadPlainText.UseVisualStyleBackColor = True
        '
        'btnSavePlainText
        '
        Me.btnSavePlainText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSavePlainText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSavePlainText.Location = New System.Drawing.Point(173, 566)
        Me.btnSavePlainText.Name = "btnSavePlainText"
        Me.btnSavePlainText.Size = New System.Drawing.Size(75, 23)
        Me.btnSavePlainText.TabIndex = 40
        Me.btnSavePlainText.Text = "保存(&C)..."
        Me.btnSavePlainText.UseVisualStyleBackColor = True
        '
        'btnPastePlainText
        '
        Me.btnPastePlainText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPastePlainText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnPastePlainText.Location = New System.Drawing.Point(93, 566)
        Me.btnPastePlainText.Name = "btnPastePlainText"
        Me.btnPastePlainText.Size = New System.Drawing.Size(75, 23)
        Me.btnPastePlainText.TabIndex = 39
        Me.btnPastePlainText.Text = "粘贴(&X)"
        Me.btnPastePlainText.UseVisualStyleBackColor = True
        '
        'btnCopyPlainText
        '
        Me.btnCopyPlainText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopyPlainText.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnCopyPlainText.Location = New System.Drawing.Point(12, 566)
        Me.btnCopyPlainText.Name = "btnCopyPlainText"
        Me.btnCopyPlainText.Size = New System.Drawing.Size(75, 23)
        Me.btnCopyPlainText.TabIndex = 38
        Me.btnCopyPlainText.Text = "复制(&Z)"
        Me.btnCopyPlainText.UseVisualStyleBackColor = True
        '
        'btnClearInformation
        '
        Me.btnClearInformation.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearInformation.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnClearInformation.Location = New System.Drawing.Point(533, 347)
        Me.btnClearInformation.Name = "btnClearInformation"
        Me.btnClearInformation.Size = New System.Drawing.Size(83, 23)
        Me.btnClearInformation.TabIndex = 37
        Me.btnClearInformation.Text = "清除通知(&D)"
        Me.btnClearInformation.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(368, 361)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 15)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "通知："
        '
        'txtInformationOut
        '
        Me.txtInformationOut.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtInformationOut.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.txtInformationOut.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtInformationOut.Location = New System.Drawing.Point(368, 376)
        Me.txtInformationOut.Multiline = True
        Me.txtInformationOut.Name = "txtInformationOut"
        Me.txtInformationOut.ReadOnly = True
        Me.txtInformationOut.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtInformationOut.Size = New System.Drawing.Size(248, 213)
        Me.txtInformationOut.TabIndex = 47
        Me.txtInformationOut.Text = resources.GetString("txtInformationOut.Text")
        '
        'chkDefaultIV
        '
        Me.chkDefaultIV.AutoSize = True
        Me.chkDefaultIV.Checked = True
        Me.chkDefaultIV.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDefaultIV.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.chkDefaultIV.Location = New System.Drawing.Point(368, 216)
        Me.chkDefaultIV.Name = "chkDefaultIV"
        Me.chkDefaultIV.Size = New System.Drawing.Size(149, 19)
        Me.chkDefaultIV.TabIndex = 35
        Me.chkDefaultIV.Text = "使用默认向量(&F)"
        Me.chkDefaultIV.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(515, 213)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 30)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "解密文本您可以只" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "用输入一次密码。"
        '
        'btnDecryptString
        '
        Me.btnDecryptString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDecryptString.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnDecryptString.Location = New System.Drawing.Point(368, 187)
        Me.btnDecryptString.Name = "btnDecryptString"
        Me.btnDecryptString.Size = New System.Drawing.Size(248, 23)
        Me.btnDecryptString.TabIndex = 34
        Me.btnDecryptString.Text = "<== 解密文本(&E)"
        Me.btnDecryptString.UseVisualStyleBackColor = True
        '
        'btnEncryptString
        '
        Me.btnEncryptString.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEncryptString.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnEncryptString.Location = New System.Drawing.Point(368, 158)
        Me.btnEncryptString.Name = "btnEncryptString"
        Me.btnEncryptString.Size = New System.Drawing.Size(248, 23)
        Me.btnEncryptString.TabIndex = 32
        Me.btnEncryptString.Text = "加密文本(&W) ==>"
        Me.btnEncryptString.UseVisualStyleBackColor = True
        '
        'btnRandomIV
        '
        Me.btnRandomIV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRandomIV.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnRandomIV.Location = New System.Drawing.Point(368, 129)
        Me.btnRandomIV.Name = "btnRandomIV"
        Me.btnRandomIV.Size = New System.Drawing.Size(248, 23)
        Me.btnRandomIV.TabIndex = 36
        Me.btnRandomIV.Text = "生成随机向量(&Q)"
        Me.btnRandomIV.UseVisualStyleBackColor = True
        '
        'lblLength
        '
        Me.lblLength.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLength.AutoSize = True
        Me.lblLength.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblLength.Location = New System.Drawing.Point(581, 87)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(47, 15)
        Me.lblLength.TabIndex = 48
        Me.lblLength.Text = "32/32"
        Me.lblLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIVTextBox
        '
        Me.lblIVTextBox.AutoSize = True
        Me.lblIVTextBox.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lblIVTextBox.Location = New System.Drawing.Point(368, 87)
        Me.lblIVTextBox.Name = "lblIVTextBox"
        Me.lblIVTextBox.Size = New System.Drawing.Size(103, 15)
        Me.lblIVTextBox.TabIndex = 55
        Me.lblIVTextBox.Text = "初始化向量："
        '
        'txtIV
        '
        Me.txtIV.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIV.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIV.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.txtIV.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtIV.Location = New System.Drawing.Point(368, 102)
        Me.txtIV.MaxLength = 32
        Me.txtIV.Name = "txtIV"
        Me.txtIV.Size = New System.Drawing.Size(248, 25)
        Me.txtIV.TabIndex = 31
        Me.txtIV.Text = "D49303DCDF5AAE2B128001EA48D19D04"
        '
        'txtPasswor2
        '
        Me.txtPasswor2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPasswor2.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.txtPasswor2.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPasswor2.Location = New System.Drawing.Point(368, 63)
        Me.txtPasswor2.Name = "txtPasswor2"
        Me.txtPasswor2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswor2.Size = New System.Drawing.Size(248, 25)
        Me.txtPasswor2.TabIndex = 30
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(368, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "确认密码："
        '
        'txtPasswor1
        '
        Me.txtPasswor1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPasswor1.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.txtPasswor1.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtPasswor1.Location = New System.Drawing.Point(368, 24)
        Me.txtPasswor1.Name = "txtPasswor1"
        Me.txtPasswor1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPasswor1.Size = New System.Drawing.Size(248, 25)
        Me.txtPasswor1.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(368, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 15)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "密码："
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(622, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 15)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "十六进制密文："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "明文："
        '
        'txtHexCipherText
        '
        Me.txtHexCipherText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHexCipherText.BackColor = System.Drawing.Color.Black
        Me.txtHexCipherText.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtHexCipherText.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHexCipherText.ForeColor = System.Drawing.Color.Lime
        Me.txtHexCipherText.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtHexCipherText.Location = New System.Drawing.Point(622, 21)
        Me.txtHexCipherText.Multiline = True
        Me.txtHexCipherText.Name = "txtHexCipherText"
        Me.txtHexCipherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHexCipherText.Size = New System.Drawing.Size(350, 232)
        Me.txtHexCipherText.TabIndex = 33
        '
        'txtPlainText
        '
        Me.txtPlainText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtPlainText.BackColor = System.Drawing.Color.Black
        Me.txtPlainText.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlainText.ForeColor = System.Drawing.Color.Lime
        Me.txtPlainText.Location = New System.Drawing.Point(12, 24)
        Me.txtPlainText.Multiline = True
        Me.txtPlainText.Name = "txtPlainText"
        Me.txtPlainText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPlainText.Size = New System.Drawing.Size(350, 536)
        Me.txtPlainText.TabIndex = 28
        '
        'sfdSavePlainText
        '
        Me.sfdSavePlainText.FileName = "明文.txt"
        Me.sfdSavePlainText.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        Me.sfdSavePlainText.Title = "将明文保存为文件 - 请选择保存路径："
        '
        'sfdSaveCipherText
        '
        Me.sfdSaveCipherText.FileName = "密文.txt"
        Me.sfdSaveCipherText.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        Me.sfdSaveCipherText.Title = "将密文保存为文件 - 请选择保存路径："
        '
        'ofdLoadPlainText
        '
        Me.ofdLoadPlainText.FileName = "明文.txt"
        Me.ofdLoadPlainText.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        Me.ofdLoadPlainText.Title = "从文件中读取明文 - 请选择文件路径："
        '
        'ofdLoadCipherText
        '
        Me.ofdLoadCipherText.FileName = "密文.txt"
        Me.ofdLoadCipherText.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        Me.ofdLoadCipherText.Title = "从文件中读取密文 - 请选择文件路径："
        '
        'cmbCipherMode
        '
        Me.cmbCipherMode.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.cmbCipherMode.FormattingEnabled = True
        Me.cmbCipherMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbCipherMode.Items.AddRange(New Object() {"密码块链 (CBC)", "电子密码本 (ECB)", "密码反馈 (CFB)"})
        Me.cmbCipherMode.Location = New System.Drawing.Point(451, 240)
        Me.cmbCipherMode.Name = "cmbCipherMode"
        Me.cmbCipherMode.Size = New System.Drawing.Size(165, 23)
        Me.cmbCipherMode.TabIndex = 56
        '
        'cmbPaddingMode
        '
        Me.cmbPaddingMode.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.cmbPaddingMode.FormattingEnabled = True
        Me.cmbPaddingMode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbPaddingMode.Items.AddRange(New Object() {"PKCS7", "Zeros", "ANSIX923", "ISO10126"})
        Me.cmbPaddingMode.Location = New System.Drawing.Point(451, 266)
        Me.cmbPaddingMode.Name = "cmbPaddingMode"
        Me.cmbPaddingMode.Size = New System.Drawing.Size(165, 23)
        Me.cmbPaddingMode.TabIndex = 57
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(368, 243)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 58
        Me.Label8.Text = "加密模式："
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label9.Location = New System.Drawing.Point(368, 269)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 15)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "填充模式："
        '
        'cmbKeySize
        '
        Me.cmbKeySize.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.cmbKeySize.FormattingEnabled = True
        Me.cmbKeySize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbKeySize.Items.AddRange(New Object() {"128", "192", "256"})
        Me.cmbKeySize.Location = New System.Drawing.Point(451, 292)
        Me.cmbKeySize.Name = "cmbKeySize"
        Me.cmbKeySize.Size = New System.Drawing.Size(165, 23)
        Me.cmbKeySize.TabIndex = 60
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label10.Location = New System.Drawing.Point(368, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "密钥长度："
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label11.Location = New System.Drawing.Point(368, 321)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(103, 15)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "加密块大小："
        '
        'cmbBlockSize
        '
        Me.cmbBlockSize.Font = New System.Drawing.Font("新宋体", 9.2!)
        Me.cmbBlockSize.FormattingEnabled = True
        Me.cmbBlockSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmbBlockSize.Items.AddRange(New Object() {"128"})
        Me.cmbBlockSize.Location = New System.Drawing.Point(451, 318)
        Me.cmbBlockSize.Name = "cmbBlockSize"
        Me.cmbBlockSize.Size = New System.Drawing.Size(165, 23)
        Me.cmbBlockSize.TabIndex = 62
        '
        'txtBase64CipherText
        '
        Me.txtBase64CipherText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBase64CipherText.BackColor = System.Drawing.Color.Black
        Me.txtBase64CipherText.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase64CipherText.ForeColor = System.Drawing.Color.Lime
        Me.txtBase64CipherText.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtBase64CipherText.Location = New System.Drawing.Point(622, 328)
        Me.txtBase64CipherText.Multiline = True
        Me.txtBase64CipherText.Name = "txtBase64CipherText"
        Me.txtBase64CipherText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBase64CipherText.Size = New System.Drawing.Size(350, 232)
        Me.txtBase64CipherText.TabIndex = 66
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label13.Location = New System.Drawing.Point(622, 310)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(103, 15)
        Me.Label13.TabIndex = 67
        Me.Label13.Text = "Base64密文："
        '
        'btnLoadBase64Cipher
        '
        Me.btnLoadBase64Cipher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoadBase64Cipher.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnLoadBase64Cipher.Location = New System.Drawing.Point(897, 566)
        Me.btnLoadBase64Cipher.Name = "btnLoadBase64Cipher"
        Me.btnLoadBase64Cipher.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadBase64Cipher.TabIndex = 71
        Me.btnLoadBase64Cipher.Text = "读取(&L)..."
        Me.btnLoadBase64Cipher.UseVisualStyleBackColor = True
        '
        'btnSaveBase64Cipher
        '
        Me.btnSaveBase64Cipher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveBase64Cipher.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnSaveBase64Cipher.Location = New System.Drawing.Point(816, 566)
        Me.btnSaveBase64Cipher.Name = "btnSaveBase64Cipher"
        Me.btnSaveBase64Cipher.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveBase64Cipher.TabIndex = 70
        Me.btnSaveBase64Cipher.Text = "保存(&K)..."
        Me.btnSaveBase64Cipher.UseVisualStyleBackColor = True
        '
        'btnPasteBase64Cipher
        '
        Me.btnPasteBase64Cipher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPasteBase64Cipher.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnPasteBase64Cipher.Location = New System.Drawing.Point(735, 566)
        Me.btnPasteBase64Cipher.Name = "btnPasteBase64Cipher"
        Me.btnPasteBase64Cipher.Size = New System.Drawing.Size(75, 23)
        Me.btnPasteBase64Cipher.TabIndex = 69
        Me.btnPasteBase64Cipher.Text = "粘贴(&J)"
        Me.btnPasteBase64Cipher.UseVisualStyleBackColor = True
        '
        'btnCopyBase64Cipher
        '
        Me.btnCopyBase64Cipher.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCopyBase64Cipher.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.btnCopyBase64Cipher.Location = New System.Drawing.Point(654, 566)
        Me.btnCopyBase64Cipher.Name = "btnCopyBase64Cipher"
        Me.btnCopyBase64Cipher.Size = New System.Drawing.Size(75, 23)
        Me.btnCopyBase64Cipher.TabIndex = 68
        Me.btnCopyBase64Cipher.Text = "复制(&H)"
        Me.btnCopyBase64Cipher.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 601)
        Me.Controls.Add(Me.btnLoadBase64Cipher)
        Me.Controls.Add(Me.btnSaveBase64Cipher)
        Me.Controls.Add(Me.btnPasteBase64Cipher)
        Me.Controls.Add(Me.btnCopyBase64Cipher)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtBase64CipherText)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbBlockSize)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbKeySize)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbPaddingMode)
        Me.Controls.Add(Me.cmbCipherMode)
        Me.Controls.Add(Me.chkWithIV)
        Me.Controls.Add(Me.btnLoadCipherText)
        Me.Controls.Add(Me.btnSaveCipherText)
        Me.Controls.Add(Me.btnPasteCipherText)
        Me.Controls.Add(Me.btnCopyCipherText)
        Me.Controls.Add(Me.btnLoadPlainText)
        Me.Controls.Add(Me.btnSavePlainText)
        Me.Controls.Add(Me.btnPastePlainText)
        Me.Controls.Add(Me.btnCopyPlainText)
        Me.Controls.Add(Me.btnClearInformation)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtInformationOut)
        Me.Controls.Add(Me.chkDefaultIV)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnDecryptString)
        Me.Controls.Add(Me.btnEncryptString)
        Me.Controls.Add(Me.btnRandomIV)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.lblIVTextBox)
        Me.Controls.Add(Me.txtIV)
        Me.Controls.Add(Me.txtPasswor2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPasswor1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHexCipherText)
        Me.Controls.Add(Me.txtPlainText)
        Me.Font = New System.Drawing.Font("新宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name = "MainForm"
        Me.Text = "AES文本加密"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkWithIV As CheckBox
    Friend WithEvents btnLoadCipherText As Button
    Friend WithEvents btnSaveCipherText As Button
    Friend WithEvents btnPasteCipherText As Button
    Friend WithEvents btnCopyCipherText As Button
    Friend WithEvents btnLoadPlainText As Button
    Friend WithEvents btnSavePlainText As Button
    Friend WithEvents btnPastePlainText As Button
    Friend WithEvents btnCopyPlainText As Button
    Friend WithEvents btnClearInformation As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtInformationOut As TextBox
    Friend WithEvents chkDefaultIV As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnDecryptString As Button
    Friend WithEvents btnEncryptString As Button
    Friend WithEvents btnRandomIV As Button
    Friend WithEvents lblLength As Label
    Friend WithEvents lblIVTextBox As Label
    Friend WithEvents txtIV As TextBox
    Friend WithEvents txtPasswor2 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPasswor1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtHexCipherText As TextBox
    Friend WithEvents txtPlainText As TextBox
    Friend WithEvents sfdSavePlainText As SaveFileDialog
    Friend WithEvents sfdSaveCipherText As SaveFileDialog
    Friend WithEvents ofdLoadPlainText As OpenFileDialog
    Friend WithEvents ofdLoadCipherText As OpenFileDialog
    Friend WithEvents cmbCipherMode As ComboBox
    Friend WithEvents cmbPaddingMode As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbKeySize As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbBlockSize As ComboBox
    Friend WithEvents txtBase64CipherText As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnLoadBase64Cipher As Button
    Friend WithEvents btnSaveBase64Cipher As Button
    Friend WithEvents btnPasteBase64Cipher As Button
    Friend WithEvents btnCopyBase64Cipher As Button
End Class
