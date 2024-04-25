Public Class Form1
	' Create an instance of the login form
	Private loginForm As New login()
	Private WithEvents currentChildForm As Form
	' Method to enable or disable controls based on login status
	Private Sub EnableControls(ByVal enable As Boolean)
		For Each ctrl As Control In Controls
			If ctrl IsNot btn_logout Then ' Exclude the login button
				ctrl.Enabled = enable
			End If
		Next
	End Sub

	'for panels
	Private Sub childform(ByVal panel As Form)
		If currentChildForm IsNot Nothing AndAlso TypeOf currentChildForm Is transaction Then
			Dim transactionForm As transaction = DirectCast(currentChildForm, transaction)
			If transactionForm.HasUnsavedItems Then
				Dim result As DialogResult = MessageBox.Show("There are unsaved items in the transaction. Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
				If result = DialogResult.No Then
					Return
				Else
					transactionForm.ClearItems()
				End If
			End If
		End If

		mainpanel.Controls.Clear()
		panel.TopLevel = False
		panel.FormBorderStyle = FormBorderStyle.None
		panel.Dock = DockStyle.Fill
		mainpanel.Controls.Add(panel)
		panel.Show()

		currentChildForm = panel
	End Sub


	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		' Disable all controls initially
		EnableControls(False)
		' Show the login form
		loginForm.ShowDialog()
		' Check if login was successful before proceeding
		If loginForm.LoginSuccessful Then
			' Enable all controls if login is successful
			EnableControls(True)
			btn_settings.Enabled = (DBConnection.UserType = "admin")
			childform(transaction)
		Else
			' Close the main form if login was not successful
			Me.Close()
		End If
	End Sub

	Private Sub btn_transaction_Click(sender As Object, e As EventArgs) Handles btn_transaction.Click
		childform(transaction)
	End Sub

	Private Sub btn_supplier_Click(sender As Object, e As EventArgs) Handles btn_supplier.Click
		childform(supplier)
	End Sub

	Private Sub btn_product_Click(sender As Object, e As EventArgs) Handles btn_product.Click
		childform(product)
	End Sub
	Private Sub btn_stores_Click(sender As Object, e As EventArgs) Handles btn_stores.Click
		childform(stores)
	End Sub

	' Open the login form when the button is clicked
	Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
		Me.Close()
		Application.Restart()
	End Sub


End Class
