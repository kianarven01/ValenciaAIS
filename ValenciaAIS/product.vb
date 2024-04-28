Imports MySql.Data.MySqlClient


Public Class product

	Private isFormVisible As Boolean = False

	Private Sub product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		reload("SELECT * FROM product", dgv_plist)
		txb_pID.Enabled = False
		btn_delete.Enabled = False
		btn_delete.Enabled = (DBConnection.UserType = "admin")
		cbx_pgroup.Enabled = False
		cbx_pformat.SetPlaceholder("Select Format")
	End Sub

	Private Sub product_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
		If Me.Visible Then
			ClearFields()
		End If
	End Sub

	Private Sub ClearFields()
		txb_pID.Clear()
		txb_pname.Clear()
		txb_pprice.Clear()
		txb_pstock.Clear()
		cbx_pgroup.Items.Clear()
		cbx_pformat.Text = ""
		cbx_pformat.SetPlaceholder("Select Format")

	End Sub

	Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
		ClearFields()
	End Sub


	Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
		If String.IsNullOrWhiteSpace(txb_pname.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_pprice.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_pstock.Text) OrElse
	   String.IsNullOrEmpty(cbx_pformat.Text) OrElse
	   cbx_pformat.Text = "Select Format" Then
			MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Proceed with data creation
		Try
			create("INSERT INTO product (prod_name, prod_price, prod_stock, prod_stock_format) VALUES ('" & txb_pname.Text & "', '" & txb_pprice.Text & "','" & txb_pstock.Text & "', '" & cbx_pformat.Text & "') ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM product", dgv_plist)
	End Sub

	Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
		Try
			updates("UPDATE product SET prod_name='" & txb_pname.Text & "' ,prod_price='" & txb_pprice.Text & "' ,prod_stock='" & txb_pstock.Text & "',prod_stock_format='" & cbx_pformat.Text & "' WHERE productID = '" & txb_pID.Text & "'")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM product", dgv_plist)
	End Sub

	Private Sub dgv_plist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_plist.CellClick
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			Dim selectedRow = dgv_plist.Rows(e.RowIndex)
			txb_pID.Text = selectedRow.Cells(0).Value.ToString()
			txb_pname.Text = selectedRow.Cells(1).Value.ToString()
			txb_pprice.Text = selectedRow.Cells(2).Value.ToString()
			txb_pstock.Text = selectedRow.Cells(3).Value.ToString()
			cbx_pformat.Text = selectedRow.Cells(4).Value.ToString()
		End If
	End Sub


	Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
		Try
			delete("DELETE FROM product WHERE productID='" & txb_pID.Text & "' ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT * FROM product", dgv_plist)
	End Sub

	Private Sub txb_search_TextChanged(sender As Object, e As EventArgs) Handles txb_search.TextChanged
		Dim connectionString = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query = "SELECT * FROM product WHERE prod_name LIKE @Keyword OR productID LIKE @Keyword"
		Dim keyword = "%" & txb_search.Text.Trim & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open
				Using reader = command.ExecuteReader
					Dim dt As New DataTable
					dt.Load(reader)
					dgv_plist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

	Private Sub txb_pprice_TextChanged(sender As Object, e As EventArgs) Handles txb_pprice.TextChanged
		' Check if the entered text is numeric
		If Not IsNumeric(txb_pprice.Text) AndAlso txb_pprice.Text <> "" Then
			' If not numeric, show a message and remove the non-numeric character
			MessageBox.Show("Please enter a numeric value.")
			txb_pprice.Text = txb_pprice.Text.Substring(0, txb_pprice.Text.Length - 1)
			' Set the cursor position to the end of the textbox
			txb_pprice.SelectionStart = txb_pprice.Text.Length
		End If
	End Sub

	Private Sub txb_pstock_TextChanged(sender As Object, e As EventArgs) Handles txb_pstock.TextChanged
		If Not IsNumeric(txb_pstock.Text) AndAlso txb_pstock.Text <> "" Then
			MessageBox.Show("Please enter a numeric value.")
			txb_pstock.Text = txb_pstock.Text.Substring(0, txb_pstock.Text.Length - 1)
			txb_pstock.SelectionStart = txb_pstock.Text.Length
		End If
	End Sub



End Class