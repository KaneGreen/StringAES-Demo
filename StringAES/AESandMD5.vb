'本作品采用知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议进行许可。
'http://creativecommons.org/licenses/by-nc-sa/4.0/

Imports System.IO
Imports System.Text
Imports System.Security.Cryptography
Public Class AESandMD5
    Implements IDisposable

#Region "IDisposable Support"
    Private disposedValue As Boolean ' 要检测冗余调用

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: 释放托管状态(托管对象)。
            End If

            ' TODO: 释放未托管资源(未托管对象)并在以下内容中替代 Finalize()。
            ' TODO: 将大型字段设置为 null。
        End If
        disposedValue = True
    End Sub

    ' TODO: 仅当以上 Dispose(disposing As Boolean)拥有用于释放未托管资源的代码时才替代 Finalize()。
    'Protected Overrides Sub Finalize()
    '    ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' Visual Basic 添加此代码以正确实现可释放模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 请勿更改此代码。将清理代码放入以上 Dispose(disposing As Boolean)中。
        Dispose(True)
        ' TODO: 如果在以上内容中替代了 Finalize()，则取消注释以下行。
        ' GC.SuppressFinalize(Me)
    End Sub
#End Region

    '声明一些用于属性的变量
    Private intKeySize As Integer = 256
    Private Const c_intBlockSize As Integer = 128   'AES只能支持128位的加密块大小
    Private pdmPaddingMode As PaddingMode = PaddingMode.PKCS7
    Private cpmCipherMode As CipherMode = CipherMode.CBC
    'Private intFeedbackSize As Integer = 32   '实测CFB下调节反馈大小对加密解密无影响
    ''' <summary>
    ''' 密钥长度 （AESandMD5类的属性，值只能是128、192、256中的一个）
    ''' </summary>
    ''' <returns></returns>
    Friend Property prpKeySize() As Integer
        Get
            Return intKeySize
        End Get
        Set(value As Integer)
            Select Case value
                Case 128, 192, 256
                    intKeySize = value
                Case Else
                    Throw New CryptographicException("The key size is not one of the KeySize values.")
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 加密块大小 （AESandMD5类的只读属性，AES只能支持128位的加密块大小）
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property prpBlockSize As Integer
        Get
            Return c_intBlockSize
        End Get
    End Property
    ''' <summary>
    ''' 填充模式 （AESandMD5类的属性，值只能是PKCS7、Zeros、ANSIX923、ISO10126中的一个）
    ''' </summary>
    ''' <returns></returns>
    Friend Property prpPaddingMode As PaddingMode
        Get
            Return pdmPaddingMode
        End Get
        Set(value As PaddingMode)
            Select Case value
                Case PaddingMode.ANSIX923, PaddingMode.ISO10126, PaddingMode.PKCS7, PaddingMode.Zeros
                    pdmPaddingMode = value
                Case Else
                    Throw New CryptographicException("The padding mode is not one of the supported PaddingMode values.")
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 加密模式 （AESandMD5类的属性，值只能是CBC、CFB、ECB中的一个）
    ''' </summary>
    ''' <returns></returns>
    Friend Property prpCipherMode As CipherMode
        Get
            Return cpmCipherMode
        End Get
        Set(value As CipherMode)
            Select Case value
                Case CipherMode.CBC, CipherMode.CFB, CipherMode.ECB
                    cpmCipherMode = value
                Case Else
                    Throw New CryptographicException("The cipher mode is not one of the supported CipherMode values.")
            End Select
        End Set
    End Property
    ''' <summary>
    ''' 获取文本对应MD5码，以含32个字符英文小写、数字的文本返回值
    ''' </summary>
    ''' <param name="strInput">需要计算的文本</param>
    ''' <returns>返回值为String型字符串，长度32字符，其中英文字母是小写形式。</returns>
    Public Function getMd5Hash(ByVal strInput As String) As String
        Return Me.Byte2Hex(getMd5HashBytes(strInput))
    End Function
    ''' <summary>
    ''' 获取文本对应MD5 Hash，以长度为16的Byte型数组返回值
    ''' </summary>
    ''' <param name="strInput">需要计算的文本</param>
    ''' <returns>返回值为Byte型数组，长度为16。</returns>
    Public Function getMd5HashBytes(ByVal strInput As String) As Byte()
        Dim md5Hasher As New MD5CryptoServiceProvider()
        Dim bytData As Byte() = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(strInput))
        md5Hasher.Dispose()
        Return bytData
    End Function
    ''' <summary>
    ''' 获取文本对应SHA512 Hash，以长度为64的Byte型数组返回值
    ''' </summary>
    ''' <param name="strInput">需要计算的文本</param>
    ''' <returns>返回值为Byte型数组，长度为64。</returns>
    Public Function getSha512HashBytes(ByVal strInput As String) As Byte()
        Dim Sha512Hasher As New SHA512CryptoServiceProvider
        Dim bytData As Byte() = Sha512Hasher.ComputeHash(Encoding.UTF8.GetBytes(strInput))
        Sha512Hasher.Dispose()
        Return bytData
    End Function
    ''' <summary>
    ''' AES加密：使用AES算法将字符串内容加密，以Byte型数组返回加密结果。
    ''' </summary>
    ''' <param name="plainText">明文：即将用于加密的字符串，String型。</param>
    ''' <param name="Key">密钥，Byte型数组，数组的大小为16(共128位)、24(共192位)或32(共256位)。
    ''' 需要数组的大小由prpKeySize属性决定。</param>
    ''' <param name="IV">初始化向量，Byte型数组，数组的大小为16，即共128位。</param>
    ''' <returns>返回值为Byte型数组。</returns>
    Public Function EncryptStringToBytes_Aes(ByVal plainText As String, ByVal Key() As Byte, ByVal IV() As Byte) As Byte()
        Dim encrypted As Byte()
        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Mode = prpCipherMode
            aesAlg.Padding = prpPaddingMode
            aesAlg.BlockSize = prpBlockSize
            'aesAlg.FeedbackSize = prpFeedbackSize
            aesAlg.Key = Key
            If aesAlg.Mode <> CipherMode.ECB Then
                aesAlg.IV = IV
            End If
            '以下注释内容为调试代码。
            'For intPosition As Integer = 0 To (aesAlg.IV.Length - 1)
            '    Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：向量数组：(" & Format(intPosition, "00") & ")" & aesAlg.IV(intPosition).ToString)
            'Next intPosition
            'For intPosition As Integer = 0 To (aesAlg.Key.Length - 1)
            '    Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥数组：(" & Format(intPosition, "00") & ")" & aesAlg.Key(intPosition).ToString)
            'Next intPosition
            'Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥长度：" & aesAlg.KeySize.ToString)
            '调试代码结束
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            Dim msEncrypt As New MemoryStream()
            Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                Using swEncrypt As New StreamWriter(csEncrypt, Encoding.UTF8)
                    swEncrypt.Write(plainText)
                End Using
                encrypted = msEncrypt.ToArray()
            End Using
        End Using
        Return encrypted
    End Function
    ''' <summary>
    ''' AES解密：使用AES算法将Byte型数组表示的加密结果解密，以String型字符串返回解密结果。
    ''' 如果密文、密钥、初始化向量、加密模式、填充模式、反馈大小中任何一个或多个出现错误，将会引发异常或者得到不正确的结果。
    ''' </summary>
    ''' <param name="cipherByte">密文：即将用于解密的内容，Byte型数组。</param>
    ''' <param name="Key">密钥，Byte型数组，数组的大小为16(共128位)、24(共192位)或32(共256位)。
    ''' 需要数组的大小由prpKeySize属性决定。</param>
    ''' <param name="IV">初始化向量，Byte型数组，数组的大小为16，即共128位。</param>
    ''' <returns>返回值为String型字符串。</returns>
    Public Function DecryptStringFromBytes_Aes(ByVal cipherByte() As Byte, ByVal Key() As Byte, ByVal IV() As Byte) As String
        Dim plaintext As String = Nothing
        Using aesAlg As New AesCryptoServiceProvider()
            aesAlg.Mode = prpCipherMode
            aesAlg.Padding = prpPaddingMode
            aesAlg.BlockSize = prpBlockSize
            'aesAlg.FeedbackSize = prpFeedbackSize
            aesAlg.Key = Key
            If aesAlg.Mode <> CipherMode.ECB Then
                aesAlg.IV = IV
            End If
            '以下注释内容为调试代码。
            'For intPosition As Integer = 0 To (aesAlg.IV.Length - 1)
            '    Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：向量数组：(" & Format(intPosition, "00") & ")" & aesAlg.IV(intPosition).ToString)
            'Next intPosition
            'For intPosition As Integer = 0 To (aesAlg.Key.Length - 1)
            '    Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥数组：(" & Format(intPosition, "00") & ")" & aesAlg.Key(intPosition).ToString)
            'Next intPosition
            'Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥长度：" & aesAlg.KeySize.ToString)
            '调试代码结束
            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)
            Using msDecrypt As New MemoryStream(cipherByte)
                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt, Encoding.UTF8)
                        plaintext = srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
        Return plaintext
    End Function
    ''' <summary>
    ''' 由密码创建密钥。（基于PBKDF2）
    ''' 使用Rfc2898DeriveBytes类实现。这里以密码的SHA512作为salt值，迭代次数为默认值1000。
    ''' </summary>
    ''' <param name="StringKey">用于创建密钥的密码，String型字符串。</param>
    ''' <returns>得到的密钥，Byte型数组，数组的大小为16(共128位)、24(共192位)或32(共256位)。
    ''' 产生数组的大小由prpKeySize属性决定。</returns>
    Public Function NewKey(ByVal StringKey As String) As Byte()
        Dim objRfc2898 As New Rfc2898DeriveBytes(StringKey, Me.getSha512HashBytes(StringKey), 1000)
        Dim bytKey As Byte() = objRfc2898.GetBytes(CInt(prpKeySize / 8))
        objRfc2898.Reset()
        objRfc2898.Dispose()
        Return bytKey
        '以下注释内容为老的生成Key的算法，新算法已经采用使用Rfc2898DeriveBytes类实现
        ''新密钥：间隔一个字符组成两个新字符串，分别计算MD5，在间隔一个字符组成新的长度为64位十六进制数值，以字符串形式保存
        ''这个是对应256位加密的
        'Dim sBuilderFirst As New StringBuilder()
        'Dim sBuilderSecond As New StringBuilder()
        'Dim sBuilderThird As New StringBuilder()
        'For intPosition As Integer = 1 To StringKey.Length
        '    Select Case (intPosition Mod 2)
        '        Case 1
        '            sBuilderFirst.Append(Microsoft.VisualBasic.Mid(StringKey, intPosition, 1))
        '        Case 0
        '            sBuilderSecond.Append(Microsoft.VisualBasic.Mid(StringKey, intPosition, 1))
        '    End Select
        'Next intPosition
        'Dim strMD5First As String = Me.getMd5Hash(sBuilderFirst.ToString)
        'Dim strMD5Second As String = Me.getMd5Hash(sBuilderSecond.ToString)
        'For intPosition As Integer = 1 To 64
        '    Select Case (intPosition Mod 2)
        '        Case 1
        '            sBuilderThird.Append(Microsoft.VisualBasic.Mid(strMD5First, CInt((intPosition + 1) \ 2), 1))
        '        Case 0
        '            sBuilderThird.Append(Microsoft.VisualBasic.Mid(strMD5Second, CInt((intPosition + 1) \ 2), 1))
        '    End Select
        'Next intPosition
        ''转换为下标为32的一维Byte型数组，对应的密钥长度为256位
        'Return Me.Hex2Byte(sBuilderThird.ToString.ToUpper)
        ''以下注释内容为调试代码，欲启用请先注释掉上一句已存在的Return语句。
        ''Dim strFinalKey As String = sBuilderThird.ToString.ToUpper
        ''Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥String内容：" & strFinalKey)
        ''Debug.WriteLine(Now.ToString("yyyy/MM/dd HH:mm:ss") & "(" & Format(Now.Millisecond, "000") & ")" & " 调试信息：密钥String长度：" & strFinalKey.Length.ToString)
        ''Return Me.String2Byte(strFinalKey)
        ''调试代码结束
        '老的生成Key的算法结束
    End Function
    ''' <summary>
    ''' 将连续的16进制串（String型）转换为Byte型数组
    ''' </summary>
    ''' <param name="StringValue"></param>
    ''' <returns></returns>
    Public Function Hex2Byte(ByVal StringValue As String) As Byte()
        Dim bytValue((StringValue.Length \ 2) - 1) As Byte
        For i As Integer = 0 To ((StringValue.Length \ 2) - 1)
            bytValue(i) = CByte("&H" & Microsoft.VisualBasic.Mid(StringValue, ((i * 2) + 1), 2))
        Next i
        Return bytValue
    End Function
    ''' <summary>
    ''' 将Byte型数组转换为连续的16进制串（String型）
    ''' </summary>
    ''' <param name="ByteValue"></param>
    ''' <returns></returns>
    Public Function Byte2Hex(ByVal ByteValue As Byte()) As String
        Dim sBuilder As New StringBuilder()
        For i As Integer = 0 To (ByteValue.Length - 1)
            sBuilder.Append(ByteValue(i).ToString("x2"))
        Next i
        Return sBuilder.ToString()
    End Function
    '''' <summary>
    '''' 反馈大小 （AESandMD5类的属性，值必须小于加密块大小，即prpBlockSize属性的值）
    '''' </summary>
    '''' <returns></returns>
    'Friend Property prpFeedbackSize As Integer
    '    Get
    '        Return intFeedbackSize
    '    End Get
    '    Set(value As Integer)
    '        If value <= prpBlockSize AndAlso value > 0 Then
    '            intFeedbackSize = value
    '        Else
    '            Throw New CryptographicException("The feedback size is larger than the block size or invaild")
    '        End If
    '    End Set
    'End Property
End Class
