Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO
Imports System.Globalization
Imports System.Reflection.Metadata
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar

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


	Private Sub transaction_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
		PopulateStoreComboBox() ' Call the method to populate the ComboBox with store names
		PopulateVehicleComboBox() ' Call the method to populate the ComboBox with vehicle codes
		InitializeLoadedProductDataGridView()
		cbx_stname.SetPlaceholder("Select Store")
		ResizeListViewColumns()
	End Sub


	Private Sub transaction_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		ResizeListViewColumns()
	End Sub


	Private Sub ReloadTransactionData()
		If cbx_vehicle.SelectedItem IsNot Nothing Then
			Dim selectedVehicleCode As String = cbx_vehicle.SelectedItem.ToString()

			' Construct the SQL query to fetch loaded products associated with the selected vehicle code
			Dim query As String = $"SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID WHERE lp.vehicle_code = '{selectedVehicleCode}'"

			Try
				' Open connection
				strcon.Open()

				' Set up command
				cmd.Connection = strcon
				cmd.CommandText = query

				' Create a DataTable to store the results
				Dim dt As New DataTable()

				' Fill the DataTable with the results
				dt.Load(cmd.ExecuteReader())

				' Bind the DataTable to the DataGridView
				dgv_lplist.DataSource = dt
			Catch ex As Exception
				MessageBox.Show("Error fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				' Close connection
				If strcon.State = ConnectionState.Open Then
					strcon.Close()
				End If
			End Try
		End If
	End Sub


	Private Sub transaction_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged, MyBase.Load
		If Me.Visible Then
			ClearFields()
			ReloadTransactionData()
			PopulateStoreComboBox()
			dgv_lplist.DataSource = Nothing
		End If
	End Sub

	Private Sub ClearFields()

		cbx_stname.SelectedIndex = -1
		cbx_payment.Text = ""
		cbx_vehicle.Text = ""
		cbx_payment.SetPlaceholder("Select Payment Method")
	End Sub

	Public Sub ClearItems()
		' Revert the items in lsv_transaction
		For Each item As ListViewItem In lsv_transaction.Items
			Dim productName As String = item.SubItems(0).Text
			Dim quantity As Integer = Convert.ToInt32(item.SubItems(1).Text)

			' Find the corresponding row in dgv_lplist
			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then
					' Update the loaded stock in the dgv_lplist DataGridView
					Dim loadedProductId As Integer = Convert.ToInt32(row.Cells("loaded_productID").Value)
					Dim queryAddStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE loaded_productID = {loadedProductId}"
					ExecuteNonQueryWithoutPrompt(queryAddStock)

					' Update the loaded stock in the DataGridView
					Dim updatedStock As Integer = Convert.ToInt32(row.Cells("loaded_stock").Value) + quantity
					row.Cells("loaded_stock").Value = updatedStock
					Exit For
				End If
			Next
		Next

		' Clear the items in lsv_transaction
		lsv_transaction.Items.Clear()

		' Refresh the DataGridView to reflect the updated stocks
		ReloadTransactionData()
	End Sub



	Private Sub InitializeLoadedProductDataGridView()
		' Only initialize columns if they haven't been initialized already
		If dgv_lplist.Columns.Count = 0 Then
			dgv_lplist.AutoGenerateColumns = False

			' Define columns manually
			Dim colLoadedProductId As New DataGridViewTextBoxColumn()
			colLoadedProductId.HeaderText = "Loaded Product ID"
			colLoadedProductId.DataPropertyName = "loaded_productID"
			dgv_lplist.Columns.Add(colLoadedProductId)

			Dim colProductName As New DataGridViewTextBoxColumn()
			colProductName.HeaderText = "Product Name"
			colProductName.DataPropertyName = "prod_name"
			dgv_lplist.Columns.Add(colProductName)

			Dim colProductPrice As New DataGridViewTextBoxColumn()
			colProductPrice.HeaderText = "Product Price"
			colProductPrice.DataPropertyName = "prod_price"
			dgv_lplist.Columns.Add(colProductPrice)

			Dim colLoadedStock As New DataGridViewTextBoxColumn()
			colLoadedStock.HeaderText = "Loaded Stock"
			colLoadedStock.DataPropertyName = "loaded_stock"
			dgv_lplist.Columns.Add(colLoadedStock)

			Dim colProductStockFormat As New DataGridViewTextBoxColumn()
			colProductStockFormat.HeaderText = "Format"
			colProductStockFormat.DataPropertyName = "prod_stock_format"
			dgv_lplist.Columns.Add(colProductStockFormat)
		End If

		' Attach the DataBindingComplete event handler
		AddHandler dgv_lplist.DataBindingComplete, AddressOf dgv_lplist_DataBindingComplete
	End Sub
	Private Sub dgv_lplist_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)
		' Manually set the column names after data binding is complete
		dgv_lplist.Columns("loaded_productID").HeaderText = "Loaded Product ID"
		dgv_lplist.Columns("prod_name").HeaderText = "Product Name"
		dgv_lplist.Columns("prod_price").HeaderText = "Product Price"
		dgv_lplist.Columns("loaded_stock").HeaderText = "Loaded Stock"
		dgv_lplist.Columns("prod_stock_format").HeaderText = "Format"
	End Sub
	Private Sub dgv_lplist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_lplist.CellDoubleClick

		If cbx_stname.SelectedIndex = -1 OrElse cbx_payment.SelectedIndex = -1 Then
			MessageBox.Show("Please select a store and a payment method before adding items.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

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

				' Update the loaded stock in the selected row
				selectedRow.Cells("loaded_stock").Value = loadedStock - quantity

				' Check if an item with the same product name already exists in lsv_transaction
				Dim existingItem As ListViewItem = lsv_transaction.FindItemWithText(productName)
				If existingItem IsNot Nothing Then
					' Update the quantity of the existing item
					Dim currentQuantity As Integer = Convert.ToInt32(existingItem.SubItems(1).Text)
					Dim newQuantity As Integer = currentQuantity + quantity
					existingItem.SubItems(1).Text = newQuantity.ToString()

					' Recalculate the total price based on the updated quantity
					existingItem.SubItems(3).Text = (price * newQuantity).ToString()
					UpdateTotalSum()
				Else
					' Add the selected product information along with the quantity to the ListView
					Dim item As New ListViewItem(productName)
					item.SubItems.Add(quantity.ToString())
					item.SubItems.Add(format)
					item.SubItems.Add((price * quantity).ToString()) ' Calculate total price and add to ListView
					lsv_transaction.Items.Add(item)
					UpdateTotalSum()
				End If
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

					' Update the loaded stock in the DataGridView
					Dim updatedStock As Integer = Convert.ToInt32(row.Cells("loaded_stock").Value) + quantity
					row.Cells("loaded_stock").Value = updatedStock
					Exit For
				End If
			Next

			' Remove the item from lsv_transaction
			lsv_transaction.Items.Remove(selectedItem)
			UpdateTotalSum()
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
		Else
			' Clear items in lsv_transaction when the store is changed
			ClearItems()
		End If
	End Sub


	Private Sub btn_stadd_Click(sender As Object, e As EventArgs) Handles btn_stadd.Click
		Dim storeForm As New stores()
		AddHandler storeForm.FormClosed, AddressOf StoreForm_FormClosed
		storeForm.Show()
	End Sub

	Public Sub UpdateTotalSum()
		' Variable to store the total sum of product prices
		Dim totalSum As Decimal = 0

		' Iterate through items in the transaction list and calculate the total sum
		For Each item As ListViewItem In lsv_transaction.Items
			Dim totalPrice As Decimal
			If Decimal.TryParse(item.SubItems(3).Text, totalPrice) Then
				' Add the price of the current item to the total sum
				totalSum += totalPrice
			End If
		Next

		' Display the total sum in the TextBox with the peso sign
		txb_total.Text = $"₱{totalSum:F}" ' Assuming txb_total is the name of your TextBox
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

		' Get the selected store name and transaction date
		Dim storeName As String = cbx_stname.SelectedItem.ToString()
		Dim transactionDate As String = dtp_transaction.Value.ToString("MM-dd-yyyy_HH-mm-ss")

		' Include timestamp in the file name
		Dim timestamp As String = DateTime.Now.ToString("yyyyMMddHHmmss")
		Dim fileName As String = $"{storeName}_{transactionDate}_{timestamp}.pdf"

		Try
			' Specify the file path for the PDF receipt using the store name and transaction date
			Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
			Dim receiptsFolderPath As String = Path.Combine(projectDirectory, "receipts")

			' Check if the receipts folder exists, if not, create it
			If Not Directory.Exists(receiptsFolderPath) Then
				Directory.CreateDirectory(receiptsFolderPath)
			End If

			Dim filePath As String = Path.Combine(receiptsFolderPath, fileName)

			' Create a new iTextSharp Document
			Dim document As New iTextSharp.text.Document()

			' Create a PdfWriter to write to the specified file path
			Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

			' Open the document for writing
			document.Open()

			' Add store and payment information to the PDF
			document.Add(New Paragraph($"Store: {cbx_stname.SelectedItem}"))
			document.Add(New Paragraph($"Payment Method: {cbx_payment.SelectedItem}"))
			document.Add(New Paragraph($"Transaction Date: {dtp_transaction.Value.ToString("MM/dd/yyyy HH:mm:ss")}"))
			document.Add(New Paragraph(Environment.NewLine))

			' Create a table to mimic the ListView format
			Dim table As New PdfPTable(4) ' Number of columns in the table
			table.WidthPercentage = 100 ' Make the table fill the width of the document
			table.HorizontalAlignment = Element.ALIGN_LEFT ' Align the table to the left

			' Add headers to the table
			table.AddCell("Product Name")
			table.AddCell("Quantity")
			table.AddCell("Format")
			table.AddCell("Total Price")

			' Variable to store the total sum of product prices
			Dim totalSum As Decimal = Decimal.Parse(txb_total.Text.Replace("₱", ""), Globalization.NumberStyles.Currency)

			' Iterate through items in the transaction list and add them to the table
			For Each item As ListViewItem In lsv_transaction.Items
				Dim productName As String = item.SubItems(0).Text
				Dim quantity As String = item.SubItems(1).Text
				Dim format As String = item.SubItems(2).Text
				Dim totalPrice As String = item.SubItems(3).Text

				' Add item details to the table
				table.AddCell(productName)
				table.AddCell(quantity)
				table.AddCell(format)
				table.AddCell(totalPrice)
			Next

			' Create a font that supports the Philippine Peso symbol
			Dim fontPath As String = "C:\Windows\Fonts\Arial.ttf" ' Adjust the font path as needed
			Dim baseFont As BaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
			Dim font As New Font(baseFont, 12, Font.NORMAL)

			' Add a row for the total sum at the bottom of the table
			Dim totalSumCell As New PdfPCell(New Phrase($"Total Sum: ₱{totalSum:F}", font))
			totalSumCell.Colspan = 4 ' Span all columns
			totalSumCell.HorizontalAlignment = Element.ALIGN_RIGHT ' Align to the right
			totalSumCell.Border = Rectangle.NO_BORDER ' Remove border
			table.AddCell(totalSumCell)

			' Add the table to the document
			document.Add(table)

			' Show a success message
			document.Close()
			MessageBox.Show($"Receipt generated successfully. Saved as: {filePath}", "Receipt Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)

			' Clear the transaction list and total sum TextBox after generating receipt
			lsv_transaction.Items.Clear()
			txb_total.Text = ""
			If lsv_transaction.Items.Count = 0 Then
				cbx_stname.SelectedIndex = -1
				cbx_payment.SelectedIndex = -1
				cbx_payment.SetPlaceholder("Select Payment Method") ' Reset placeholder
			End If

		Catch ex As Exception
			' Show an error message if an exception occurs
			MessageBox.Show($"An error occurred while generating the receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub


	Private Sub PopulateVehicleComboBox()
		Try
			Dim query As String = "SELECT vehicle_code FROM vehicle"
			Dim dt As New DataTable()

			' Fill the DataTable with data from the vehicle table
			Using connection As New MySqlConnection(connectionString)
				Using adapter As New MySqlDataAdapter(query, connection)
					adapter.Fill(dt)
				End Using
			End Using

			' Clear the ComboBox items
			cbx_vehicle.Items.Clear()

			' Add items to the ComboBox from the DataTable
			For Each row As DataRow In dt.Rows
				cbx_vehicle.Items.Add(row("vehicle_code").ToString())
			Next

			' Set placeholder text 
			cbx_vehicle.SetPlaceholder("Select Vehicle")
		Catch ex As Exception
			MessageBox.Show("Error loading vehicle data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub


	Private Sub cbx_vehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_vehicle.SelectedIndexChanged
		If cbx_vehicle.SelectedItem IsNot Nothing Then
			Dim selectedVehicleCode As String = cbx_vehicle.SelectedItem.ToString()

			' Construct the SQL query to fetch loaded products associated with the selected vehicle code
			Dim query As String = $"SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID WHERE lp.vehicle_code = '{selectedVehicleCode}'"

			Try
				' Open connection
				strcon.Open()

				' Set up command
				cmd.Connection = strcon
				cmd.CommandText = query

				' Create a DataTable to store the results
				Dim dt As New DataTable()

				' Fill the DataTable with the results
				dt.Load(cmd.ExecuteReader())

				' Bind the DataTable to the DataGridView
				dgv_lplist.DataSource = dt
			Catch ex As Exception
				MessageBox.Show("Error fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				' Close connection
				If strcon.State = ConnectionState.Open Then
					strcon.Close()
				End If
			End Try
		End If
	End Sub

	Private Sub btn_showReceipt_Click(sender As Object, e As EventArgs) Handles btn_showReceipt.Click
		Try
			' Specify the path to the receipt folder
			Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
			Dim receiptsFolderPath As String = Path.Combine(projectDirectory, "receipts")

			' Check if the receipts folder exists
			If Directory.Exists(receiptsFolderPath) Then
				' Open the folder using the default file explorer
				Process.Start("explorer.exe", receiptsFolderPath)
			Else
				MessageBox.Show("The receipts folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		Catch ex As Exception
			MessageBox.Show($"An error occurred while opening the receipt folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

End Class