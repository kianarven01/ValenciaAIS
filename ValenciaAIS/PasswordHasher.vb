Imports System.Security.Cryptography
Imports System.Text

Public Class PasswordHasher
    Public Shared Function HashPassword(password As String) As String
        Using sha256 As SHA256 = SHA256.Create()
            Dim bytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In bytes
                builder.Append(b.ToString("x2")) ' Convert byte to hexadecimal string
            Next
            Return builder.ToString()
        End Using
    End Function
End Class
