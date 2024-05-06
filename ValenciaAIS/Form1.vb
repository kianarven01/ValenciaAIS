Imports System.IO

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

	Private Sub EnableButtonsBasedOnUserType(ByVal userType As String)
		If userType = "superadmin" Then
			' If user is superadmin, disable the buttons
			btn_transaction.Enabled = False
			btn_supplier.Enabled = False
			btn_product.Enabled = False
			btn_vehicle.Enabled = False
			btn_stores.Enabled = False
		Else
			' If user is not superadmin, enable the buttons
			btn_transaction.Enabled = True
			btn_supplier.Enabled = True
			btn_product.Enabled = True
			btn_vehicle.Enabled = True
			btn_stores.Enabled = True
		End If
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
					' Revert the items in the transaction list to dgv_lplist values
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

			' Check user type
			Dim userType As String = DBConnection.UserType

			' Enable or disable buttons based on user type
			EnableButtonsBasedOnUserType(userType)
			If userType = "superadmin" Then
				lbl_company.Text = "Superadmin Mode"
				btn_restore.Visible = True
			Else
				btn_restore.Visible = False
			End If

			' Start with transaction form if user is not superadmin
			If userType <> "superadmin" Then
				childform(transaction)
				Dim backupManager As New DatabaseManager()
				backupManager.BackupDatabase()
			End If
		Else
			' Close the main form if login was not successful
			Me.Close()
		End If
	End Sub

	Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
		If currentChildForm IsNot Nothing AndAlso TypeOf currentChildForm Is transaction Then
			Dim transactionForm As transaction = DirectCast(currentChildForm, transaction)
			If transactionForm.HasUnsavedItems Then
				Dim result As DialogResult = MessageBox.Show("There are unsaved items in the transaction. Are you sure you want to proceed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
				If result = DialogResult.No Then
					e.Cancel = True ' Cancel the form closing event if the user chooses not to proceed
				Else
					' Clear the items in the transaction list and update stock
					transactionForm.ClearItems()
				End If
			End If
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
	Private Sub btn_vehicle_Click(sender As Object, e As EventArgs) Handles btn_vehicle.Click
		childform(vehicle)
	End Sub
	Private Sub btn_stores_Click(sender As Object, e As EventArgs) Handles btn_stores.Click
		childform(stores)
	End Sub

	' Open the login form when the button is clicked
	Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
		Me.Close()
		Application.Restart()
	End Sub

	Private Sub btn_restore_Click(sender As Object, e As EventArgs) Handles btn_restore.Click
		' Prompt the user to confirm restoration
		Dim result As DialogResult = MessageBox.Show("Are you sure you want to restore the database?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

		If result = DialogResult.Yes Then
			' Proceed with restoration
			Dim backupFolderPath As String = Path.Combine(Application.StartupPath, "Backups")
			Dim openFileDialog As New OpenFileDialog()
			openFileDialog.InitialDirectory = backupFolderPath
			openFileDialog.Filter = "SQL Files (*.sql)|*.sql|All Files (*.*)|*.*"
			openFileDialog.FilterIndex = 1
			openFileDialog.RestoreDirectory = True

			If openFileDialog.ShowDialog() = DialogResult.OK Then
				' Get the selected file path
				Dim backupFilePath As String = openFileDialog.FileName

				' Restore the database
				Dim databaseManager As New DatabaseManager()
				databaseManager.RestoreDatabase(backupFilePath)
			End If
		End If
	End Sub


End Class
