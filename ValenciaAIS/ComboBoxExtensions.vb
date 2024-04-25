Imports System.Runtime.CompilerServices

Module ComboBoxExtensions

    <Extension()>
    Public Sub SetPlaceholder(cbx As ComboBox, placeholder As String)
        If String.IsNullOrEmpty(cbx.Text) Then
            cbx.Text = placeholder
        End If
    End Sub

End Module
