Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class supplier

	Private isFormVisible As Boolean = False
	Private Sub supplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		reload("SELECT * FROM supplier", dgv_slist)
		txb_sID.Enabled = False
		btn_delete.Enabled = False
		btn_delete.Enabled = (DBConnection.UserType = "admin")
	End Sub

	Private Sub product_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
		If Me.Visible Then
			ClearFields()
		End If
	End Sub

	Private Sub ClearFields()
		txb_sID.Clear()
		txb_sname.Clear()
		txb_saddress.Clear()
		txb_scontact.Clear()
	End Sub

	Private Sub btn_create_Click_1(sender As Object, e As EventArgs) Handles btn_create.Click

		If String.IsNullOrWhiteSpace(txb_sname.Text) OrElse String.IsNullOrWhiteSpace(txb_scontact.Text) OrElse String.IsNullOrWhiteSpace(txb_saddress.Text) Then
			MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		Try
			create("INSERT INTO supplier (supp_name,supp_contact,supp_address) VALUES ('" & txb_sname.Text & "', '" & txb_scontact.Text & "','" & txb_saddress.Text & "') ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM supplier", dgv_slist)
	End Sub

	Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
		Try
			updates("UPDATE supplier SET supp_name='" & txb_sname.Text & "' ,supp_contact='" & txb_scontact.Text & "' ,supp_address='" & txb_saddress.Text & "' WHERE supplierID = '" & txb_sID.Text & "'")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM supplier", dgv_slist)
	End Sub

	Private Sub dgv_slist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_slist.CellClick

		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			Dim selectedRow = dgv_slist.Rows(e.RowIndex)
			txb_sID.Text = selectedRow.Cells(0).Value.ToString()
			txb_sname.Text = selectedRow.Cells(1).Value.ToString()
			txb_scontact.Text = selectedRow.Cells(2).Value.ToString()
			txb_saddress.Text = selectedRow.Cells(3).Value.ToString()
		End If
	End Sub


	Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
		Try
			delete("DELETE FROM supplier WHERE supplierID='" & txb_sID.Text & "' ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM supplier", dgv_slist)
	End Sub

	Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
		txb_sID.Clear()
		txb_sname.Clear()
		txb_scontact.Clear()
		txb_saddress.Clear()
	End Sub

	Private Sub txb_search_TextChanged(sender As Object, e As EventArgs) Handles txb_search.TextChanged
		Dim connectionString As String = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query As String = "SELECT * FROM supplier WHERE supp_name LIKE @Keyword OR supp_address LIKE @Keyword"
		Dim keyword As String = "%" & txb_search.Text.Trim() & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open()
				Using reader As MySqlDataReader = command.ExecuteReader()
					Dim dt As New DataTable()
					dt.Load(reader)
					dgv_slist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

	Private Sub txb_scontact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txb_scontact.KeyPress
		If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
			e.Handled = True
			MessageBox.Show("Please enter only numeric characters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
		ElseIf txb_scontact.Text.Length >= 11 AndAlso e.KeyChar <> ControlChars.Back Then

			e.Handled = True
		End If
	End Sub

	Private Sub txb_scontact_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txb_scontact.Validating
		If Not String.IsNullOrEmpty(txb_scontact.Text) AndAlso txb_scontact.Text.Length <> 11 Then
			MessageBox.Show("Phone number should be 11 digits long.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			e.Cancel = True
		End If
	End Sub

End Class