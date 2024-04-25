Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Public Class transaction
	Private isFormVisible As Boolean = False
	Private connectionString As String = "server=localhost; user id=root; password=; database=valencia_agriculture"
	Public ReadOnly Property HasUnsavedItems As Boolean
		Get
			Return lsv_transaction.Items.Count > 0
		End Get
	End Property

	Private Sub PopulateStoreComboBox()
		Try
			Dim query As String = "SELECT store_name FROM store"
			Dim dt As New DataTable()

			' Fill the DataTable with data from the store table
			Using connection As New MySqlConnection(connectionString)
				Using adapter As New MySqlDataAdapter(query, connection)
					adapter.Fill(dt)
				End Using
			End Using

			' Clear the ComboBox items
			cbx_stname.Items.Clear()

			' Add items to the ComboBox from the DataTable
			For Each row As DataRow In dt.Rows
				cbx_stname.Items.Add(row("store_name").ToString())
			Next

			' Set placeholder text
			cbx_stname.SetPlaceholder("Select Store")
		Catch ex As Exception
			MessageBox.Show("Error loading store data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub StoreForm_FormClosed(sender As Object, e As FormClosedEventArgs)
		' Reload the ComboBox items when the stores form is closed
		PopulateStoreComboBox()
	End Sub


	Private Sub transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		reload("SELECT * FROM product", dgv_plist)
		PopulateStoreComboBox() ' Call the method to populate the ComboBox with store names
		cbx_stname.SetPlaceholder("Select Store")
		Dim totalWidth As Integer = lsv_transaction.ClientSize.Width
		Dim columnWidth As Integer = totalWidth \ lsv_transaction.Columns.Count
		For Each column As ColumnHeader In lsv_transaction.Columns
			column.Width = columnWidth
		Next
		lsv_transaction.Columns(lsv_transaction.Columns.Count - 1).Width += totalWidth Mod lsv_transaction.Columns.Count

	End Sub

	Private Sub transaction_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
		If Me.Visible Then
			ClearFields()
		End If
	End Sub

	Private Sub ClearFields()

		cbx_stname.SelectedIndex = -1
		cbx_payment.Text = ""
		cbx_payment.SetPlaceholder("Select Format")
	End Sub


	Public Sub ClearItems()
		lsv_transaction.Items.Clear()
	End Sub


	Private Sub txb_search_TextChanged(sender As Object, e As EventArgs) Handles txb_search.TextChanged
		Dim connectionString As String = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query As String = "SELECT * FROM product WHERE prod_name LIKE @Keyword OR productID LIKE @Keyword"
		Dim keyword As String = "%" & txb_search.Text.Trim() & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open()
				Using reader As MySqlDataReader = command.ExecuteReader()
					Dim dt As New DataTable()
					dt.Load(reader)
					dgv_plist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

	Private Sub btn_stadd_Click(sender As Object, e As EventArgs) Handles btn_stadd.Click
		Dim storeForm As New stores()
		AddHandler storeForm.FormClosed, AddressOf StoreForm_FormClosed
		storeForm.Show()
	End Sub

	Private Sub dgv_plist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_plist.CellDoubleClick
		' Check if a valid cell is clicked and it's not the header row
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			' Get the selected row
			Dim selectedRow = dgv_plist.Rows(e.RowIndex)

			' Extract the product information from the selected row
			Dim productName As String = selectedRow.Cells("prod_name").Value.ToString()
			Dim price As String = selectedRow.Cells("prod_price").Value.ToString()
			Dim format As String = selectedRow.Cells("prod_stock_format").Value.ToString()

			' Open a popup window to input the quantity
			Dim quantityInputForm As New QuantityInputForm()
			If quantityInputForm.ShowDialog() = DialogResult.OK Then
				' Retrieve the quantity from the popup window
				Dim quantity As Integer = quantityInputForm.Quantity

				' Add the selected product information along with the quantity to the ListView
				Dim item As New ListViewItem(productName)
				item.SubItems.Add(quantity.ToString())
				item.SubItems.Add(format)
				item.SubItems.Add(price)
				lsv_transaction.Items.Add(item)
			End If
		End If
	End Sub

	Private Sub btn_removeItem_Click(sender As Object, e As EventArgs) Handles btn_removeItem.Click
		If lsv_transaction.SelectedItems.Count > 0 Then
			lsv_transaction.Items.Remove(lsv_transaction.SelectedItems(0))
		Else
			MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub

	Private Sub cbx_stname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_stname.SelectedIndexChanged
		' Check if the selected index is -1 (no selection)
		If cbx_stname.SelectedIndex = -1 Then
			' Set placeholder text
			cbx_stname.SetPlaceholder("Select Store")
		End If
	End Sub

	Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click
		' Check if both ComboBoxes are not selected and the ListView is empty
		If (cbx_stname.SelectedIndex = -1 AndAlso cbx_payment.SelectedIndex = -1) AndAlso lsv_transaction.Items.Count = 0 Then
			MessageBox.Show("Please select a store, payment method, and add items to the transaction list before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Check if at least one of the ComboBoxes is not selected
		If cbx_stname.SelectedIndex = -1 OrElse cbx_payment.SelectedIndex = -1 Then
			MessageBox.Show("Please select both a store and a payment method before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Check if the ListView is empty
		If lsv_transaction.Items.Count = 0 Then
			MessageBox.Show("Please add items to the transaction list before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Your code to generate the transaction goes here
		' ...
	End Sub
End Class