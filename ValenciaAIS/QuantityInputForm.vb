Public Class QuantityInputForm
    ' Property to get the quantity entered by the user
    Public Property Quantity As Double ' Change data type to Double or Decimal

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click
        ' Validate and parse the input quantity
        Dim input As String = txb_quantity.Text.Trim()
        If Not String.IsNullOrEmpty(input) AndAlso Double.TryParse(input, Quantity) AndAlso Quantity > 0 Then
            ' Close the form if the input is a valid positive number
            DialogResult = DialogResult.OK
            Close()
        Else
            ' Show an error message if the input is not a valid positive number
            MessageBox.Show("Please enter a valid positive number for the quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        ' Close the form without setting the quantity if the user cancels
        DialogResult = DialogResult.Cancel
        Close()
    End Sub
End Class
