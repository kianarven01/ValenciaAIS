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

	Public Sub ExecuteNonQueryWithoutPrompt(ByVal sql As String)
		Try
			strcon.Open()
			cmd.Connection = strcon
			cmd.CommandText = sql
			result = cmd.ExecuteNonQuery
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			strcon.Close()
		End Try
	End Sub

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

	Private Sub ResizeListViewColumns()
		Dim totalWidth = lsv_transaction.ClientSize.Width
		Dim columnWidth = totalWidth \ lsv_transaction.Columns.Count

		For Each column As ColumnHeader In lsv_transaction.Columns
			column.Width = columnWidth
		Next

		lsv_transaction.Columns(lsv_transaction.Columns.Count - 1).Width += totalWidth Mod lsv_transaction.Columns.Count
	End Sub


	Private Sub transaction_Load(sender As Object, e As EventArgs)
		reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
		PopulateStoreComboBox() ' Call the method to populate the ComboBox with store names
		cbx_stname.SetPlaceholder("Select Store")
		ResizeListViewColumns()
	End Sub


	Private Sub transaction_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		ResizeListViewColumns()
	End Sub


	Private Sub ReloadTransactionData()
		reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
	End Sub

	Private Sub transaction_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged, MyBase.Load
		If Me.Visible Then
			ClearFields()
			ReloadTransactionData()
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


	Private Sub dgv_lplist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_lplist.CellDoubleClick
		' Check if a valid cell is clicked and it's not the header row
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			' Get the selected row
			Dim selectedRow = dgv_lplist.Rows(e.RowIndex)

			' Extract the product information from the selected row
			Dim productName As String = selectedRow.Cells("prod_name").Value.ToString()
			Dim price As Decimal = Convert.ToDecimal(selectedRow.Cells("prod_price").Value)
			Dim format As String = selectedRow.Cells("prod_stock_format").Value.ToString()
			Dim loadedProductId As Integer = Convert.ToInt32(selectedRow.Cells("loaded_productID").Value)
			Dim loadedStock As Integer = Convert.ToInt32(selectedRow.Cells("loaded_stock").Value)

			' Open a popup window to input the quantity
			Dim quantityInputForm As New QuantityInputForm()
			If quantityInputForm.ShowDialog() = DialogResult.OK Then
				' Retrieve the quantity from the popup window
				Dim quantity As Integer = quantityInputForm.Quantity

				' Check if the entered quantity exceeds the available stock
				If quantity > loadedStock Then
					MessageBox.Show($"Insufficient stock. Available stock: {loadedStock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End If

				' Deduct the quantity from the loaded stock in the loaded_product table
				Dim queryDeductStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock - {quantity} WHERE loaded_productID = {loadedProductId}"
				ExecuteNonQueryWithoutPrompt(queryDeductStock)

				' Check if an item with the same product name already exists in lsv_transaction
				Dim existingItem As ListViewItem = lsv_transaction.FindItemWithText(productName)
				If existingItem IsNot Nothing Then
					' Update the quantity of the existing item
					Dim currentQuantity As Integer = Convert.ToInt32(existingItem.SubItems(1).Text)
					Dim newQuantity As Integer = currentQuantity + quantity
					existingItem.SubItems(1).Text = newQuantity.ToString()

					' Recalculate the total price based on the updated quantity
					existingItem.SubItems(3).Text = (price * newQuantity).ToString()
				Else
					' Add the selected product information along with the quantity to the ListView
					Dim item As New ListViewItem(productName)
					item.SubItems.Add(quantity.ToString())
					item.SubItems.Add(format)
					item.SubItems.Add((price * quantity).ToString()) ' Calculate total price and add to ListView
					lsv_transaction.Items.Add(item)
				End If

				' Reload dgv_lplist to reflect the changes
				ReloadTransactionData()
			End If
		End If
	End Sub




	Private Sub btn_removeItem_Click(sender As Object, e As EventArgs) Handles btn_removeItem.Click
		If lsv_transaction.SelectedItems.Count > 0 Then
			' Get the selected item in lsv_transaction
			Dim selectedItem As ListViewItem = lsv_transaction.SelectedItems(0)
			Dim productName As String = selectedItem.SubItems(0).Text
			Dim quantity As Integer = Convert.ToInt32(selectedItem.SubItems(1).Text)
			Dim format As String = selectedItem.SubItems(2).Text
			Dim price As Decimal = Convert.ToDecimal(selectedItem.SubItems(3).Text)

			' Find the corresponding row in dgv_lplist
			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then
					' Update the loaded stock in the loaded_product table
					Dim loadedProductId As Integer = Convert.ToInt32(row.Cells("loaded_productID").Value)
					Dim queryAddStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE loaded_productID = {loadedProductId}"
					ExecuteNonQueryWithoutPrompt(queryAddStock)
					Exit For
				End If
			Next

			' Remove the item from lsv_transaction
			lsv_transaction.Items.Remove(selectedItem)

			' Reload dgv_lplist to reflect the changes
			ReloadTransactionData()
		Else
			MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub

	Public Sub RevertItems()
		' Iterate through the items in the transaction list
		For Each item As ListViewItem In lsv_transaction.Items
			Dim productName As String = item.SubItems(0).Text
			Dim quantity As Integer = Convert.ToInt32(item.SubItems(1).Text)

			' Find the corresponding row in dgv_lplist
			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then
					' Update the loaded stock in the loaded_product table
					Dim loadedProductId As Integer = Convert.ToInt32(row.Cells("loaded_productID").Value)
					Dim queryAddStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE loaded_productID = {loadedProductId}"
					ExecuteNonQueryWithoutPrompt(queryAddStock)
					Exit For
				End If
			Next
		Next
		ClearItems()
		ReloadTransactionData()
	End Sub


	Private Sub cbx_stname_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_stname.SelectedIndexChanged
		' Check if the selected index is -1 (no selection)
		If cbx_stname.SelectedIndex = -1 Then
			' Set placeholder text
			cbx_stname.SetPlaceholder("Select Store")
		End If
	End Sub

	Private Sub btn_stadd_Click(sender As Object, e As EventArgs) Handles btn_stadd.Click
		Dim storeForm As New stores()
		AddHandler storeForm.FormClosed, AddressOf StoreForm_FormClosed
		storeForm.Show()
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