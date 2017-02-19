Public Class MainForm
    Private Const c_strKeyCharacters As String = "0123456789ABCDEF"
    Private Const c_strattachedCharacters As String = "GHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/="
    Private Const c_strDefaultIV As String = "D49303DCDF5AAE2B128001EA48D19D04"
    Private blnCipherCalled As Boolean = False
    Private objAesMd5 As New AESandMD5
    Private Sub txtIV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIV.KeyPress
        '向量的输入限制
        Dim chrKey As Char = e.KeyChar
        If InStr(c_strKeyCharacters & "abcdef", chrKey.ToString()) = 0 AndAlso chrKey <> Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtIV_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIV.TextChanged
        '粘贴检查
        Dim strEffectiveIV As String = Me.EffectuateString(txtIV.Text)
        If txtIV.Text <> strEffectiveIV Then
            txtIV.Text = strEffectiveIV
        End If
        '向量长度统计
        lblLength.Text = txtIV.TextLength & "/32"
        '是否等于默认向量
        If txtIV.Text = c_strDefaultIV AndAlso (Not chkDefaultIV.Checked) Then
            chkDefaultIV.Checked = True
        ElseIf txtIV.Text <> c_strDefaultIV AndAlso chkDefaultIV.Checked Then
            chkDefaultIV.Checked = False
        End If
    End Sub
    Private Function PasswordCheck() As Boolean
        '确认密码
        If txtPasswor1.Text = txtPasswor2.Text Then
            Return False
        Else
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！两次输入密码不同，请重新键入。"
            MessageBox.Show("操作中断！" & vbCrLf & "两次键入的密码不同，请重新键入。", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return True
        End If
    End Function
    Private Sub btnRandomIV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRandomIV.Click
        '产生新的随机向量
        Dim objRandom As New System.Random(Now.Millisecond)
        txtIV.Text = objAesMd5.getMd5Hash(CStr(TimeOfDay & CStr(objRandom.Next(100000000, 999999999)) & Application.ExecutablePath))
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：产生新的随机加密向量成功。" & vbCrLf
    End Sub
    Private Sub btnEncryptString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncryptString.Click
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程开始。"
        '加密前检查
        If txtPasswor1.Text = String.Empty OrElse txtPasswor2.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您还没有键入密码，请键入。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If Me.PasswordCheck Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If txtIV.Text.Length <> 32 AndAlso cmbCipherMode.SelectedIndex <> 1 Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入加密向量长度不是32位字符长度，请更正。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If Me.CheckString(txtIV.Text) Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入加密向量含有非法字符，请更正。" & vbCrLf & " 加密向量应只含有这些字符：0 1 2 3 4 5 6 7 8 9 A B C D E F"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If txtPlainText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您还没有键入明文文本，请键入。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        '正式加密
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：您键入的明文文本正在进行加密过程。请稍等..."
        txtHexCipherText.Text = objAesMd5.Byte2Hex(objAesMd5.EncryptStringToBytes_Aes(txtPlainText.Text, objAesMd5.NewKey(txtPasswor1.Text), objAesMd5.Hex2Byte(txtIV.Text)))
        '返回加密结果信息
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：您键入的明文文本已经加密完成。请牢记您的密码和加密向量，如需解密请使用本程序解密。"
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：加密过程结束。" & vbCrLf & vbCrLf
    End Sub
    Private Function CheckString(ByVal strText As String) As Boolean
        '检查文本是否合符要求
        strText = strText.ToUpper
        For i As Integer = 1 To strText.Length
            If InStr(c_strKeyCharacters, Microsoft.VisualBasic.Mid(strText, i, 1)) = 0 Then
                Return True
                Exit Function
            End If
        Next i
        Return False
    End Function
    Private Sub btnDecryptString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecryptString.Click
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程开始。"
        '解密前检查
        If txtPasswor1.Text = String.Empty AndAlso txtPasswor2.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您还没有键入密码，请键入。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        ElseIf txtPasswor1.Text = String.Empty AndAlso txtPasswor2.Text <> String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：密码框中的文本为空，将以确认密码框中的文本作为密钥进行解密。"
            txtPasswor1.Text = txtPasswor2.Text
        ElseIf txtPasswor1.Text <> String.Empty AndAlso txtPasswor2.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：确认密码框中的文本为空，将以密码框中的文本作为密钥进行解密。"
            txtPasswor2.Text = txtPasswor1.Text
        ElseIf txtPasswor1.Text <> txtPasswor2.Text Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！两次输入密码不同，请重新键入。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            txtPasswor1.Text = String.Empty
            txtPasswor2.Text = String.Empty
            Exit Sub
        End If
        If txtIV.Text.Length <> 32 AndAlso cmbCipherMode.SelectedIndex <> 1 Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入加密向量长度不是32位字符长度，请更正。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If Me.CheckString(txtIV.Text) Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入加密向量含有非法字符，请更正。" & vbCrLf & " 加密向量应只含有这些字符：0 1 2 3 4 5 6 7 8 9 A B C D E F"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        If Me.CheckString(txtHexCipherText.Text) Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入密文文本含有非法字符，请更正。" & vbCrLf & " 密文文本应只含有这些字符：0 1 2 3 4 5 6 7 8 9 A B C D E F"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        End If
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：若要成功解密，您的键入的密码和加密向量必须是正确的。如果您键入的密码或加密向量有误，解密过程将中断；即使解密过程能继续进行并完成，您获得的明文文本也将是错误的。"
        txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：您键入的密文文本正在进行解密过程。请稍等..."
        Dim bytEncryptedBytes() As Byte
        If txtHexCipherText.Text = String.Empty OrElse txtBase64CipherText.Text = String.Empty Then
            bytEncryptedBytes = Nothing
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您还没有键入密文文本，请键入。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
            Exit Sub
        Else
            bytEncryptedBytes = objAesMd5.Hex2Byte(txtHexCipherText.Text)
            txtBase64CipherText.Text = Convert.ToBase64String(bytEncryptedBytes, Base64FormattingOptions.None)
        End If
        Try
            '正式解密
            txtPlainText.Text = objAesMd5.DecryptStringFromBytes_Aes(bytEncryptedBytes, objAesMd5.NewKey(txtPasswor1.Text), objAesMd5.Hex2Byte(txtIV.Text))
            '返回解密结果信息
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：您键入的密文文本已经解密完成。"
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程结束。" & vbCrLf & vbCrLf
        Catch
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：操作中断！您键入的密码、加密向量或密文文本有误，请更正。"
            MessageBox.Show("操作中断！" & vbCrLf & "您键入的密码、加密向量或密文文本有误，请更正。", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：解密过程中断！" & vbCrLf & vbCrLf
        Finally
            bytEncryptedBytes = Nothing
        End Try
    End Sub
    Private Sub EncryptStringForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        '退出询问
        If MessageBox.Show("您确认要退出？", "消息：", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            objAesMd5 = Nothing
        End If
    End Sub
    Private Sub txtHexCipherText_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHexCipherText.KeyPress
        '检查输入的密文格式
        Dim chrKey As Char = e.KeyChar
        If InStr(c_strKeyCharacters, chrKey.ToString().ToUpper) = 0 AndAlso chrKey <> Microsoft.VisualBasic.ChrW(Keys.Back) Then
            e.Handled = True
        End If
    End Sub
    Private Sub chkDefaultIV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDefaultIV.CheckedChanged
        '使用默认向量替代加密向量文本框中的向量
        If chkDefaultIV.Checked Then
            txtIV.Text = c_strDefaultIV
        End If
    End Sub
    Private Sub btnClearInformation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearInformation.Click
        '清空通知文本框
        txtInformationOut.Clear()
    End Sub
    Private Sub txtInformationOut_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInformationOut.TextChanged
        '通知文本框自动跳至最后一行
        txtInformationOut.SelectionStart = txtInformationOut.TextLength
        txtInformationOut.ScrollToCaret()
    End Sub
    Private Function EffectuateString(ByVal strText As String) As String
        '清除无效字符
        Dim chrBuffer() As Char = strText.ToUpper.ToCharArray
        Dim sBuilder As New System.Text.StringBuilder()
        For i As Integer = 0 To (strText.Length - 1)
            If InStr(c_strKeyCharacters, chrBuffer(i).ToString) <> 0 Then
                sBuilder.Append(chrBuffer(i).ToString)
            End If
        Next i
        Dim strResult As String = sBuilder.ToString()
        Return strResult
    End Function
    Private Function EffectuateBase64(ByVal strText As String) As String
        '清除Base64中的无效字符
        Dim chrBuffer() As Char = strText.ToCharArray
        Dim sBuilder As New System.Text.StringBuilder()
        For i As Integer = 0 To (strText.Length - 1)
            If InStr(c_strKeyCharacters & c_strattachedCharacters, chrBuffer(i).ToString) <> 0 Then
                sBuilder.Append(chrBuffer(i).ToString)
            End If
        Next i
        Dim strResult As String = sBuilder.ToString()
        Return strResult
    End Function
    Private Sub txtHexCipherText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHexCipherText.TextChanged
        '粘贴检查
        Dim strEffectiveCipherText As String = Me.EffectuateString(txtHexCipherText.Text)
        If txtHexCipherText.Text <> strEffectiveCipherText Then
            txtHexCipherText.Text = strEffectiveCipherText
        End If
        If (txtHexCipherText.Text.Length Mod 2) = 0 Then
            If Not blnCipherCalled Then
                Dim bytEncryptedBytes() As Byte = objAesMd5.Hex2Byte(txtHexCipherText.Text)
                blnCipherCalled = True
                txtBase64CipherText.Text = Convert.ToBase64String(bytEncryptedBytes, Base64FormattingOptions.None)
                bytEncryptedBytes = Nothing
            Else
                blnCipherCalled = False
            End If
        End If
    End Sub
    Private Sub txtBase64CipherText_TextChanged(sender As Object, e As EventArgs) Handles txtBase64CipherText.TextChanged
        If Not blnCipherCalled Then
            Dim bytEncryptedBytes() As Byte
            Try
                blnCipherCalled = True
                bytEncryptedBytes = Convert.FromBase64String(txtBase64CipherText.Text)
                txtHexCipherText.Text = objAesMd5.Byte2Hex(bytEncryptedBytes)
            Catch ex As Exception
                txtHexCipherText.Text = String.Empty
            Finally
                bytEncryptedBytes = Nothing
            End Try
        Else
            blnCipherCalled = False
        End If
    End Sub
    Private Sub btnPastePlainText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPastePlainText.Click
        '从剪贴板里粘贴明文文本
        If My.Computer.Clipboard.ContainsText Then
            txtPlainText.Text = My.Computer.Clipboard.GetText
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从剪贴板粘贴明文成功。" & vbCrLf
        Else
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：剪贴板中没有文本。" & vbCrLf
        End If
    End Sub
    Private Sub btnPasteCipherText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasteCipherText.Click
        '从剪贴板里粘贴密文文本
        If My.Computer.Clipboard.ContainsText Then
            Dim strTextToPaste As String = My.Computer.Clipboard.GetText
            Dim intStart As Integer = InStr(strTextToPaste.ToUpper, "IV:")
            Dim strTextToIV As String = Me.EffectuateString(Microsoft.VisualBasic.Mid(strTextToPaste, intStart + 3, 32))
            If intStart > 0 AndAlso strTextToIV.Length = 32 Then
                txtIV.Text = strTextToIV
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：剪贴板内文本中含有加密向量信息，已自动填入。"
                txtHexCipherText.Text = Me.EffectuateString(Replace(strTextToPaste, "IV:" & strTextToIV, String.Empty))
            Else
                txtHexCipherText.Text = Me.EffectuateString(strTextToPaste)
            End If
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从剪贴板粘贴密文成功。" & vbCrLf
        Else
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：剪贴板中没有文本。" & vbCrLf
        End If
    End Sub
    Private Sub btnCopyPlainText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyPlainText.Click
        '复制明文
        If txtPlainText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：明文文本框中没有文本。" & vbCrLf
        Else
            My.Computer.Clipboard.SetText(txtPlainText.Text)
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：复制明文到剪贴板成功。" & vbCrLf
        End If
    End Sub
    Private Sub btnCopyCipherText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyCipherText.Click
        '复制密文及加密向量
        If txtHexCipherText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：密文文本框中没有文本。" & vbCrLf
        Else
            If chkWithIV.Checked AndAlso cmbCipherMode.SelectedIndex <> 1 Then
                My.Computer.Clipboard.SetText("[IV:" & txtIV.Text & "]" & vbCrLf & txtHexCipherText.Text)
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：复制密文和加密向量到剪贴板成功。" & vbCrLf
            Else
                My.Computer.Clipboard.SetText(txtHexCipherText.Text)
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：复制密文到剪贴板成功。" & vbCrLf
            End If
        End If
    End Sub
    Private Sub btnSavePlainText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePlainText.Click
        '保存明文
        If txtPlainText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：明文文本框中没有文本。" & vbCrLf
        Else
            If sfdSavePlainText.ShowDialog = DialogResult.OK Then
                Dim objFile As New System.IO.StreamWriter(sfdSavePlainText.FileName, False, System.Text.Encoding.Default)
                objFile.WriteLine(txtPlainText.Text)
                objFile.Close()
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：将明文保存为文件成功。" & vbCrLf
                objFile.Dispose()
            End If
        End If
    End Sub
    Private Sub btnLoadPlainText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPlainText.Click
        '读取明文
        If ofdLoadPlainText.ShowDialog = DialogResult.OK Then
            Try
                Dim objFile As New System.IO.StreamReader(ofdLoadPlainText.FileName, System.Text.Encoding.Default)
                txtPlainText.Text = objFile.ReadToEnd()
                objFile.Close()
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从文件中读取明文成功。" & vbCrLf
                objFile.Dispose()
            Catch ex As Exception
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：从文件中读取明文失败。指定文件无法访问或是无效文件。" & vbCrLf
            End Try
        End If
    End Sub
    Private Sub btnSaveCipherText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCipherText.Click
        '保存密文
        If txtHexCipherText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：密文文本框中没有文本。" & vbCrLf
        Else
            If sfdSaveCipherText.ShowDialog = DialogResult.OK Then
                Dim objFile As New System.IO.StreamWriter(sfdSaveCipherText.FileName, False, System.Text.Encoding.Default)
                Dim strTextToSave As String = txtHexCipherText.Text
                If chkWithIV.Checked Then
                    strTextToSave = "[IV:" & txtIV.Text & "]" & vbCrLf & txtHexCipherText.Text
                    objFile.WriteLine(strTextToSave)
                    objFile.Close()
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：将密文和加密向量保存为文件成功。" & vbCrLf
                Else
                    strTextToSave = txtHexCipherText.Text
                    objFile.WriteLine(strTextToSave)
                    objFile.Close()
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：将密文保存为文件成功。" & vbCrLf
                End If
                objFile.Dispose()
            End If
        End If
    End Sub
    Private Sub btnLoadCipherText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadCipherText.Click
        '读取密文
        If ofdLoadCipherText.ShowDialog = DialogResult.OK Then
            Try
                Dim objFile As New System.IO.StreamReader(ofdLoadCipherText.FileName, System.Text.Encoding.Default)
                Dim strTextToLoad As String = objFile.ReadToEnd()
                Dim intStart As Integer = InStr(strTextToLoad.ToUpper, "IV:")
                Dim strTextToIV As String = Me.EffectuateString(Microsoft.VisualBasic.Mid(strTextToLoad, intStart + 3, 32))
                If intStart > 0 AndAlso strTextToIV.Length = 32 Then
                    txtIV.Text = strTextToIV
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：所选文件中含有加密向量信息，已自动填入。"
                    txtHexCipherText.Text = Me.EffectuateString(Replace(strTextToLoad, "IV:" & strTextToIV, String.Empty))
                Else
                    txtHexCipherText.Text = Me.EffectuateString(strTextToLoad)
                End If
                objFile.Close()
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从文件中读取密文成功。" & vbCrLf
                objFile.Dispose()
            Catch ex As Exception
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：从文件中读取密文失败。指定文件无法访问或是无效文件。" & vbCrLf
            End Try
        End If
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '加载窗口后设置默认值
        cmbBlockSize.SelectedIndex = 0
        cmbKeySize.SelectedIndex = 2
        cmbCipherMode.SelectedIndex = 0
        cmbPaddingMode.SelectedIndex = 0
    End Sub
    Private Sub cmbBlockSize_TextChanged(sender As Object, e As EventArgs) Handles cmbBlockSize.TextChanged
        '块大小下拉框，AES支持128位
        If cmbBlockSize.Text <> "128" Then
            cmbBlockSize.SelectedIndex = 0
        End If
    End Sub
    Private Sub cmbKeySize_TextChanged(sender As Object, e As EventArgs) Handles cmbKeySize.TextChanged
        '密钥长度下拉框，支持128,192,256三种,根据输入的内容自动选择
        If cmbKeySize.SelectedIndex = -1 Then
            Dim strInput As String = Replace(Replace(Replace(cmbKeySize.Text.ToUpper, "(", String.Empty), ")", String.Empty), " ", String.Empty)
            If (Not CBool(InStr("21", strInput))) AndAlso CBool(InStr("128短小弱低", strInput)) Then
                cmbKeySize.SelectedIndex = 0
            ElseIf (Not CBool(InStr("21", strInput))) AndAlso CBool(InStr("192中等均衡", strInput)) Then
                cmbKeySize.SelectedIndex = 1
            ElseIf strInput <> "2" AndAlso CBool(InStr("256长大强高", strInput)) Then
                cmbKeySize.SelectedIndex = 2
            End If
            strInput = Nothing
        End If
    End Sub
    Private Sub cmbKeySize_LostFocus(sender As Object, e As EventArgs) Handles cmbKeySize.LostFocus
        '不支持的密钥长度下拉框重设为默认值256
        If cmbKeySize.SelectedIndex = -1 Then
            cmbKeySize.SelectedIndex = 2
        End If
    End Sub
    Private Sub cmbCipherMode_TextChanged(sender As Object, e As EventArgs) Handles cmbCipherMode.TextChanged
        '加密模式下拉框选择，根据输入内容自动选择
        If cmbCipherMode.SelectedIndex = -1 Then
            Dim strInput As String = Replace(Replace(Replace(Replace(Replace(cmbCipherMode.Text.ToUpper, "(", String.Empty), ")", String.Empty), " ", String.Empty), "密", String.Empty), "码", String.Empty)
            If (Not CBool(InStr("CB", strInput))) AndAlso CBool(InStr("块链CBC", strInput)) Then
                cmbCipherMode.SelectedIndex = 0
            ElseIf (Not CBool(InStr("CB", strInput))) AndAlso CBool(InStr("电子本ECB", strInput)) Then
                cmbCipherMode.SelectedIndex = 1
            ElseIf (Not CBool(InStr("BC", strInput))) AndAlso CBool(InStr("反馈CFB", strInput)) Then
                cmbCipherMode.SelectedIndex = 2
            End If
            strInput = Nothing
        End If
    End Sub
    Private Sub cmbCipherMode_LostFocus(sender As Object, e As EventArgs) Handles cmbCipherMode.LostFocus
        '不在列表内的加密模式下拉框重设为默认值CBC
        If cmbCipherMode.SelectedIndex = -1 Then
            cmbCipherMode.SelectedIndex = 0
        End If
    End Sub
    Private Sub cmbPaddingMode_TextChanged(sender As Object, e As EventArgs) Handles cmbPaddingMode.TextChanged
        '填充模式下拉框选择，根据输入内容自动选择
        If cmbPaddingMode.SelectedIndex = -1 Then
            Dim strInput As String = Replace(Replace(Replace(cmbPaddingMode.Text.ToUpper, "(", String.Empty), ")", String.Empty), " ", String.Empty)
            If strInput <> "S" AndAlso CBool(InStr("PKCS7", strInput)) Then
                cmbPaddingMode.SelectedIndex = 0
            ElseIf (Not CBool(InStr("SO", strInput))) AndAlso CBool(InStr("ZEROS", strInput)) Then
                cmbPaddingMode.SelectedIndex = 1
            ElseIf (Not CBool(InStr("IS2", strInput))) AndAlso CBool(InStr("ANSIX923", strInput)) Then
                cmbPaddingMode.SelectedIndex = 2
            ElseIf (Not CBool(InStr("2S0IO", strInput))) AndAlso CBool(InStr("ISO10126", strInput)) Then
                cmbPaddingMode.SelectedIndex = 3
            End If
            strInput = Nothing
        End If
    End Sub
    Private Sub cmbPaddingMode_LostFocus(sender As Object, e As EventArgs) Handles cmbPaddingMode.LostFocus
        '不在列表内的填充模式下拉框重设为默认值PKCS7
        If cmbPaddingMode.SelectedIndex = -1 Then
            cmbPaddingMode.SelectedIndex = 0
        End If
    End Sub
    Private Sub cmbCipherMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCipherMode.SelectedIndexChanged
        '同步设置AES的CipherMode属性
        Select Case cmbCipherMode.SelectedIndex
            Case 0
                objAesMd5.prpCipherMode = Security.Cryptography.CipherMode.CBC
            Case 1
                objAesMd5.prpCipherMode = Security.Cryptography.CipherMode.ECB
            Case 2
                objAesMd5.prpCipherMode = Security.Cryptography.CipherMode.CFB
        End Select
        If objAesMd5.prpCipherMode = Security.Cryptography.CipherMode.ECB Then
            txtIV.Visible = False
            lblLength.Visible = False
            chkDefaultIV.Visible = False
            chkWithIV.Visible = False
            lblIVTextBox.Text = String.Empty
            btnRandomIV.Enabled = False
            btnRandomIV.Text = "ECB模式无需初始化向量"
        Else
            btnRandomIV.Text = "生成随机向量(&Q)"
            btnRandomIV.Enabled = True
            txtIV.Visible = True
            lblLength.Visible = True
            chkDefaultIV.Visible = True
            chkWithIV.Visible = True
            lblIVTextBox.Text = "初始化向量："
        End If
    End Sub
    Private Sub cmbPaddingMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPaddingMode.SelectedIndexChanged
        '同步设置AES的PaddingMode属性
        Select Case cmbPaddingMode.SelectedIndex
            Case 0
                objAesMd5.prpPaddingMode = Security.Cryptography.PaddingMode.PKCS7
            Case 1
                objAesMd5.prpPaddingMode = Security.Cryptography.PaddingMode.Zeros
            Case 2
                objAesMd5.prpPaddingMode = Security.Cryptography.PaddingMode.ANSIX923
            Case 3
                objAesMd5.prpPaddingMode = Security.Cryptography.PaddingMode.ISO10126
        End Select
    End Sub
    Private Sub cmbKeySize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKeySize.SelectedIndexChanged
        '同步设置AES的KeySize属性
        objAesMd5.prpKeySize = CInt(cmbKeySize.SelectedItem.ToString)
    End Sub
    Private Sub btnCopyBase64Cipher_Click(sender As Object, e As EventArgs) Handles btnCopyBase64Cipher.Click
        '复制Base64密文及加密向量
        If txtBase64CipherText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：密文文本框中没有文本。" & vbCrLf
        Else
            If chkWithIV.Checked AndAlso cmbCipherMode.SelectedIndex <> 1 Then
                My.Computer.Clipboard.SetText("[IV:" & txtIV.Text & "]" & vbCrLf & txtBase64CipherText.Text)
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：复制密文和加密向量到剪贴板成功。" & vbCrLf
            Else
                My.Computer.Clipboard.SetText(txtBase64CipherText.Text)
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：复制密文到剪贴板成功。" & vbCrLf
            End If
        End If
    End Sub
    Private Sub btnPasteBase64Cipher_Click(sender As Object, e As EventArgs) Handles btnPasteBase64Cipher.Click
        '从剪贴板里粘贴Base64密文文本
        If My.Computer.Clipboard.ContainsText Then
            Dim strTextToPaste As String = My.Computer.Clipboard.GetText
            Dim intStart As Integer = InStr(strTextToPaste.ToUpper, "IV:")
            Dim strTextToIV As String = Me.EffectuateBase64(Microsoft.VisualBasic.Mid(strTextToPaste, intStart + 3, 32))
            If intStart > 0 AndAlso strTextToIV.Length = 32 Then
                txtIV.Text = strTextToIV
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：剪贴板内文本中含有加密向量信息，已自动填入。"
                txtBase64CipherText.Text = Me.EffectuateBase64(Replace(strTextToPaste, "IV:" & strTextToIV, String.Empty))
            Else
                txtBase64CipherText.Text = Me.EffectuateBase64(strTextToPaste)
            End If
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从剪贴板粘贴密文成功。" & vbCrLf
        Else
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：剪贴板中没有文本。" & vbCrLf
        End If
    End Sub
    Private Sub btnSaveBase64Cipher_Click(sender As Object, e As EventArgs) Handles btnSaveBase64Cipher.Click
        '保存Base64密文
        If txtBase64CipherText.Text = String.Empty Then
            txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：密文文本框中没有文本。" & vbCrLf
        Else
            If sfdSaveCipherText.ShowDialog = DialogResult.OK Then
                Dim objFile As New System.IO.StreamWriter(sfdSaveCipherText.FileName, False, System.Text.Encoding.Default)
                Dim strTextToSave As String = txtBase64CipherText.Text
                If chkWithIV.Checked Then
                    strTextToSave = "[IV:" & txtIV.Text & "]" & vbCrLf & txtBase64CipherText.Text
                    objFile.WriteLine(strTextToSave)
                    objFile.Close()
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：将密文和加密向量保存为文件成功。" & vbCrLf
                Else
                    strTextToSave = txtBase64CipherText.Text
                    objFile.WriteLine(strTextToSave)
                    objFile.Close()
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：将密文保存为文件成功。" & vbCrLf
                End If
                objFile.Dispose()
            End If
        End If
    End Sub
    Private Sub btnLoadBase64Cipher_Click(sender As Object, e As EventArgs) Handles btnLoadBase64Cipher.Click
        '读取Base64密文
        If ofdLoadCipherText.ShowDialog = DialogResult.OK Then
            Try
                Dim objFile As New System.IO.StreamReader(ofdLoadCipherText.FileName, System.Text.Encoding.Default)
                Dim strTextToLoad As String = objFile.ReadToEnd()
                Dim intStart As Integer = InStr(strTextToLoad.ToUpper, "IV:")
                Dim strTextToIV As String = Me.EffectuateBase64(Microsoft.VisualBasic.Mid(strTextToLoad, intStart + 3, 32))
                If intStart > 0 AndAlso strTextToIV.Length = 32 Then
                    txtIV.Text = strTextToIV
                    txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：所选文件中含有加密向量信息，已自动填入。"
                    txtBase64CipherText.Text = Me.EffectuateBase64(Replace(strTextToLoad, "IV:" & strTextToIV, String.Empty))
                Else
                    txtBase64CipherText.Text = Me.EffectuateBase64(strTextToLoad)
                End If
                objFile.Close()
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 信息：从文件中读取密文成功。" & vbCrLf
                objFile.Dispose()
            Catch ex As Exception
                txtInformationOut.Text = txtInformationOut.Text & vbCrLf & Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & vbCrLf & " 错误：从文件中读取密文失败。指定文件无法访问或是无效文件。" & vbCrLf
            End Try
        End If
    End Sub
    'Private Sub nudFeedbackSize_ValueChanged(sender As Object, e As EventArgs)
    '    '同步设置AES的FeedbackSize属性
    '    If (nudFeedbackSize.Value Mod 8) = 0 Then
    '        objAesMd5.prpFeedbackSize = CInt(nudFeedbackSize.Value)
    '    Else
    '        nudFeedbackSize.Value = 32
    '    End If
    'End Sub
End Class
