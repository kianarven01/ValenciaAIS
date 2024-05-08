Imports MySql.Data.MySqlClient

Public Class stores

	Private isFormVisible As Boolean = False
	Private Sub stores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		reload("SELECT * FROM store", dgv_stlist)
		txb_stID.Enabled = False
		btn_delete.Enabled = False
		btn_delete.Enabled = (DBConnection.UserType = "admin")
		cbx_stmunicipality.SetPlaceholder("Select Municipality")
	End Sub

	Private Sub stores_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
		If Me.Visible Then
			ClearFields()
		End If
	End Sub

	Private Sub ClearFields()
		txb_stID.Clear()
		txb_stname.Clear()
		txb_stbarangay.Clear()
		txb_stmanager.Clear()
		txb_stcontact.Clear()
		cbx_stmunicipality.Text = ""
		cbx_stmunicipality.SetPlaceholder("Select Municipality")

	End Sub

	Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
		ClearFields()
	End Sub


	Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
		If String.IsNullOrWhiteSpace(txb_stname.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_stbarangay.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_stmanager.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_stcontact.Text) OrElse
	   String.IsNullOrEmpty(cbx_stmunicipality.Text) OrElse
	   cbx_stmunicipality.Text = "Select Municipality" Then
			MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If
		Try
			create("INSERT INTO store(store_name, store_location, store_contact, store_manager) VALUES ('" & txb_stname.Text & "', '" & txb_stbarangay.Text & ", " & cbx_stmunicipality.Text & "' ,'" & txb_stcontact.Text & "', '" & txb_stmanager.Text & "') ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM store", dgv_stlist)
	End Sub

	Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
		Try
			updates("UPDATE store SET store_name='" & txb_stname.Text & "' ,store_location='" & txb_stbarangay.Text & ", " & cbx_stmunicipality.Text & "' ,store_contact='" & txb_stcontact.Text & "',store_manager='" & txb_stmanager.Text & "' WHERE storeID = '" & txb_stID.Text & "'")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM store", dgv_stlist)
	End Sub

	Private Sub dgv_stlist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_stlist.CellClick
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			Dim selectedRow = dgv_stlist.Rows(e.RowIndex)
			txb_stID.Text = selectedRow.Cells(0).Value.ToString()
			txb_stname.Text = selectedRow.Cells(1).Value.ToString()
			Dim locationParts = selectedRow.Cells(2).Value.ToString().Split(","c)
			If locationParts.Length = 2 Then
				txb_stbarangay.Text = locationParts(0).Trim()
				cbx_stmunicipality.Text = locationParts(1).Trim()
			Else
				txb_stbarangay.Text = ""
				cbx_stmunicipality.Text = ""
			End If
			txb_stcontact.Text = selectedRow.Cells(3).Value.ToString()
			txb_stmanager.Text = selectedRow.Cells(4).Value.ToString()
		End If
	End Sub

	Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
		Try
			delete("DELETE FROM store WHERE storeID='" & txb_stID.Text & "' ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM store", dgv_stlist)
	End Sub

	Private Sub txb_search_TextChanged(sender As Object, e As EventArgs) Handles txb_search.TextChanged
		Dim connectionString As String = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query As String = "SELECT * FROM store WHERE store_name LIKE @Keyword OR store_location LIKE @Keyword OR store_manager LIKE @Keyword OR storeID LIKE @Keyword"
		Dim keyword As String = "%" & txb_search.Text.Trim() & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open()
				Using reader As MySqlDataReader = command.ExecuteReader()
					Dim dt As New DataTable()
					dt.Load(reader)
					dgv_stlist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

	Private Sub txb_stcontact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txb_stcontact.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
			MessageBox.Show("Please enter only numeric characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf txb_stcontact.Text.Length >= 11 AndAlso e.KeyChar <> ControlChars.Back Then

			e.Handled = True
		End If
	End Sub

	Private Sub txb_stcontact_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txb_stcontact.Validating
		If Not String.IsNullOrEmpty(txb_stcontact.Text) AndAlso txb_stcontact.Text.Length <> 11 Then
			MessageBox.Show("Phone number should be 11 digits long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			e.Cancel = True
		End If
	End Sub

End Class