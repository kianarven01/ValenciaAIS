Public Class QuantityInputForm
	' Property to get the quantity entered by the user
	Public Property Quantity As Integer

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        ' Validate and parse the input quantity
        Dim input As String = txb_quantity.Text.Trim()
        If Not String.IsNullOrEmpty(input) AndAlso Integer.TryParse(input, Quantity) AndAlso Quantity > 0 Then
            ' Close the form if the input is a valid positive integer
            DialogResult = DialogResult.OK
            Close()
        Else
            ' Show an error message if the input is not a valid positive integer
            MessageBox.Show("Please enter a valid positive integer for the quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
		' Close the form without setting the quantity if the user cancels
		DialogResult = DialogResult.Cancel
		Close()
	End Sub

End Class
