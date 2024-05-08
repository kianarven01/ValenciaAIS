Public Class QuantityInputForm

	Public Property Quantity As Double

	Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btn_OK.Click

		Dim input As String = txb_quantity.Text.Trim()
		If Not String.IsNullOrEmpty(input) AndAlso Double.TryParse(input, Quantity) AndAlso Quantity > 0 Then

			DialogResult = DialogResult.OK
			Close()
		Else

			MessageBox.Show("Please enter a valid positive number for the quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub

	Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click

		DialogResult = DialogResult.Cancel
		Close()
	End Sub

	Private Sub QuantityInputForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

	End Sub
End Class
