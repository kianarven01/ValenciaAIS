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


			Using connection As New MySqlConnection(connectionString)
				Using adapter As New MySqlDataAdapter(query, connection)
					adapter.Fill(dt)
				End Using
			End Using


			cbx_stname.Items.Clear()


			For Each row As DataRow In dt.Rows
				cbx_stname.Items.Add(row("store_name").ToString())
			Next


			cbx_stname.SetPlaceholder("Select Store")
		Catch ex As Exception
			MessageBox.Show("Error loading store data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub
	Private Sub StoreForm_FormClosed(sender As Object, e As FormClosedEventArgs)

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
		PopulateStoreComboBox()
		PopulateVehicleComboBox()
		InitializeLoadedProductDataGridView()
		cbx_stname.SetPlaceholder("Select Store")
		ResizeListViewColumns()
		LoadInvoices()
	End Sub


	Private Sub transaction_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		ResizeListViewColumns()
	End Sub


	Private Sub ReloadTransactionData()
		If cbx_vehicle.SelectedItem IsNot Nothing Then
			Dim selectedVehicleCode As String = cbx_vehicle.SelectedItem.ToString()


			Dim query As String = $"SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID WHERE lp.vehicle_code = '{selectedVehicleCode}'"

			Try

				strcon.Open()


				cmd.Connection = strcon
				cmd.CommandText = query


				Dim dt As New DataTable()


				dt.Load(cmd.ExecuteReader())


				dgv_lplist.DataSource = dt
			Catch ex As Exception
				MessageBox.Show("Error fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally

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

		For Each item As ListViewItem In lsv_transaction.Items
			Dim productName As String = item.SubItems(0).Text
			Dim quantity As Integer = Convert.ToInt32(item.SubItems(1).Text)

			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then

					Dim loadedProductId As Integer = Convert.ToInt32(row.Cells("loaded_productID").Value)
					Dim queryAddStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE loaded_productID = {loadedProductId}"
					ExecuteNonQueryWithoutPrompt(queryAddStock)


					Dim updatedStock As Integer = Convert.ToInt32(row.Cells("loaded_stock").Value) + quantity
					row.Cells("loaded_stock").Value = updatedStock
					Exit For
				End If
			Next
		Next


		lsv_transaction.Items.Clear()


		ReloadTransactionData()
	End Sub



	Private Sub InitializeLoadedProductDataGridView()

		If dgv_lplist.Columns.Count = 0 Then
			dgv_lplist.AutoGenerateColumns = False


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

		AddHandler dgv_lplist.DataBindingComplete, AddressOf dgv_lplist_DataBindingComplete
	End Sub
	Private Sub dgv_lplist_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs)

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


		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

			Dim selectedRow = dgv_lplist.Rows(e.RowIndex)


			Dim productName As String = selectedRow.Cells("prod_name").Value.ToString()
			Dim price As Decimal = Convert.ToDecimal(selectedRow.Cells("prod_price").Value)
			Dim format As String = selectedRow.Cells("prod_stock_format").Value.ToString()
			Dim loadedProductId As Integer = Convert.ToInt32(selectedRow.Cells("loaded_productID").Value)
			Dim loadedStock As Integer = Convert.ToInt32(selectedRow.Cells("loaded_stock").Value)


			Dim quantityInputForm As New QuantityInputForm()
			If quantityInputForm.ShowDialog() = DialogResult.OK Then

				Dim quantity As Decimal = quantityInputForm.Quantity
				If quantity > loadedStock Then
					MessageBox.Show($"Insufficient stock. Available stock: {loadedStock}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End If


				Dim queryDeductStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock - {quantity} WHERE loaded_productID = {loadedProductId}"
				ExecuteNonQueryWithoutPrompt(queryDeductStock)


				selectedRow.Cells("loaded_stock").Value = loadedStock - quantity


				Dim existingItem As ListViewItem = lsv_transaction.FindItemWithText(productName)
				If existingItem IsNot Nothing Then

					Dim currentQuantity As Decimal = Convert.ToDecimal(existingItem.SubItems(1).Text)
					Dim newQuantity As Decimal = currentQuantity + quantity
					existingItem.SubItems(1).Text = newQuantity.ToString()


					existingItem.SubItems(3).Text = (price * newQuantity).ToString()
					UpdateTotalSum()
				Else

					Dim item As New ListViewItem(productName)
					item.SubItems.Add(quantity.ToString())
					item.SubItems.Add(format)


					Dim totalPrice As Decimal = price * quantity
					item.SubItems.Add(totalPrice.ToString())
					lsv_transaction.Items.Add(item)
					UpdateTotalSum()
				End If
			End If
		End If
	End Sub

	Private Sub btn_removeItem_Click(sender As Object, e As EventArgs) Handles btn_removeItem.Click
		If lsv_transaction.SelectedItems.Count > 0 Then

			Dim selectedItem As ListViewItem = lsv_transaction.SelectedItems(0)
			Dim productName As String = selectedItem.SubItems(0).Text
			Dim quantity As Decimal = Convert.ToDecimal(selectedItem.SubItems(1).Text) ' Use Decimal data type
			Dim format As String = selectedItem.SubItems(2).Text
			Dim price As Decimal = Convert.ToDecimal(selectedItem.SubItems(3).Text)

			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then

					Dim loadedProductId As Integer = Convert.ToInt32(row.Cells("loaded_productID").Value)
					Dim queryAddStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE loaded_productID = {loadedProductId}"
					ExecuteNonQueryWithoutPrompt(queryAddStock)


					Dim updatedStock As Decimal = Convert.ToDecimal(row.Cells("loaded_stock").Value) + quantity ' Use Decimal data type
					row.Cells("loaded_stock").Value = updatedStock
					Exit For
				End If
			Next

			lsv_transaction.Items.Remove(selectedItem)
			UpdateTotalSum()
		Else
			MessageBox.Show("Please select an item to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub


	Public Sub RevertItems()


		For Each item As ListViewItem In lsv_transaction.Items
			Dim productName As String = item.SubItems(0).Text
			Dim quantity As Integer = Convert.ToInt32(item.SubItems(1).Text)

			For Each row As DataGridViewRow In dgv_lplist.Rows
				If productName = row.Cells("prod_name").Value.ToString() Then

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

		If cbx_stname.SelectedIndex = -1 Then

			cbx_stname.SetPlaceholder("Select Store")
		Else

			ClearItems()
		End If
	End Sub


	Private Sub btn_stadd_Click(sender As Object, e As EventArgs) Handles btn_stadd.Click
		Dim storeForm As New stores()
		AddHandler storeForm.FormClosed, AddressOf StoreForm_FormClosed
		storeForm.Show()
	End Sub

	Public Sub UpdateTotalSum()

		Dim totalSum As Decimal = 0

		For Each item As ListViewItem In lsv_transaction.Items
			Dim totalPrice As Decimal
			If Decimal.TryParse(item.SubItems(3).Text, totalPrice) Then

				totalSum += totalPrice
			End If
		Next


		txb_total.Text = $"₱{totalSum:F}"
	End Sub


	Private Sub btn_generate_Click(sender As Object, e As EventArgs) Handles btn_generate.Click

		If (cbx_stname.SelectedIndex = -1 AndAlso cbx_payment.SelectedIndex = -1) AndAlso lsv_transaction.Items.Count = 0 Then
			MessageBox.Show("Please select a store, payment method, and add items to the transaction list before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If


		If cbx_stname.SelectedIndex = -1 OrElse cbx_payment.SelectedIndex = -1 Then
			MessageBox.Show("Please select both a store and a payment method before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If


		If lsv_transaction.Items.Count = 0 Then
			MessageBox.Show("Please add items to the transaction list before generating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If


		Dim storeName As String = cbx_stname.SelectedItem.ToString()
		Dim transactionDate As String = DateTime.Today.ToString("yyyy-MM-dd")


		Dim insertInvoiceQuery As String = $"INSERT INTO invoices (store_id, payment_method, transaction_date) VALUES ((SELECT storeID FROM store WHERE store_name = '{storeName}'), '{cbx_payment.SelectedItem}', '{transactionDate}')"
		Dim invoiceId As Integer = -1

		Try

			strcon.Open()


			cmd.Connection = strcon
			cmd.CommandText = insertInvoiceQuery
			cmd.ExecuteNonQuery()


			cmd.CommandText = "SELECT LAST_INSERT_ID()"
			invoiceId = Convert.ToInt32(cmd.ExecuteScalar())


			Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
			Dim receiptsFolderPath As String = Path.Combine(projectDirectory, "receipts")
			If Not Directory.Exists(receiptsFolderPath) Then
				Directory.CreateDirectory(receiptsFolderPath)
			End If


			Dim timeStamp As String = DateTime.Now.ToString("yyyyMMdd_HHmmss")
			Dim fileName As String = $"{storeName}_{timeStamp}.pdf"
			Dim filePath As String = Path.Combine(receiptsFolderPath, fileName)

			Dim document As New iTextSharp.text.Document()


			Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))

			document.Open()


			document.Add(New Paragraph($"Store: {cbx_stname.SelectedItem}"))
			document.Add(New Paragraph($"Payment Method: {cbx_payment.SelectedItem}"))
			document.Add(New Paragraph($"Transaction Date: {dtp_transaction.Value.ToString("MM/dd/yyyy HH:mm:ss")}"))
			document.Add(New Paragraph(Environment.NewLine))

			Dim table As New PdfPTable(4)
			table.WidthPercentage = 100
			table.HorizontalAlignment = Element.ALIGN_LEFT

			table.AddCell("Product Name")
			table.AddCell("Quantity")
			table.AddCell("Format")
			table.AddCell("Total Price")


			Dim totalSum As Decimal = Decimal.Parse(txb_total.Text.Replace("₱", ""), Globalization.NumberStyles.Currency)


			For Each item As ListViewItem In lsv_transaction.Items
				Dim productName As String = item.SubItems(0).Text
				Dim quantity As String = item.SubItems(1).Text
				Dim format As String = item.SubItems(2).Text
				Dim totalPrice As String = item.SubItems(3).Text


				table.AddCell(productName)
				table.AddCell(quantity)
				table.AddCell(format)
				table.AddCell(totalPrice)
			Next


			Dim fontPath As String = "C:\Windows\Fonts\Arial.ttf"
			Dim baseFont As BaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
			Dim font As New Font(baseFont, 12, Font.NORMAL)


			Dim totalSumCell As New PdfPCell(New Phrase($"Total Sum: ₱{totalSum:F}", font))
			totalSumCell.Colspan = 4
			totalSumCell.HorizontalAlignment = Element.ALIGN_RIGHT
			totalSumCell.Border = Rectangle.NO_BORDER
			table.AddCell(totalSumCell)


			document.Add(table)


			document.Close()


			For Each item As ListViewItem In lsv_transaction.Items
				Dim productName As String = item.SubItems(0).Text
				Dim quantityDouble As Double
				Dim quantity As Double
				Dim format As String
				Dim totalPrice As Decimal

				If Double.TryParse(item.SubItems(1).Text, quantityDouble) Then
					quantity = quantityDouble
					format = item.SubItems(2).Text
					totalPrice = Decimal.Parse(item.SubItems(3).Text.Replace("₱", ""), Globalization.NumberStyles.Currency)

					Dim productId As Integer = -1
					cmd.CommandText = $"SELECT productID FROM product WHERE prod_name = '{productName}'"
					Dim reader As MySqlDataReader = cmd.ExecuteReader()
					If reader.Read() Then
						productId = reader.GetInt32(0)
					End If
					reader.Close()


					Dim insertInvoiceItemQuery As String = $"INSERT INTO invoice_items (invoice_id, product_id, quantity, format, total_price) VALUES ({invoiceId}, {productId}, {quantity}, '{format}', {totalPrice})"
					cmd.CommandText = insertInvoiceItemQuery
					cmd.ExecuteNonQuery()
				Else

					MessageBox.Show("Invalid quantity format: " & item.SubItems(1).Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Continue For
				End If


				table.AddCell(productName)
				table.AddCell(quantity.ToString())
				table.AddCell(format)
				table.AddCell(totalPrice.ToString())
			Next

			MessageBox.Show($"Receipt generated successfully. Saved as: {filePath}", "Receipt Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)


			lsv_transaction.Items.Clear()
			txb_total.Text = ""
			cbx_stname.SelectedIndex = -1
			cbx_payment.SelectedIndex = -1
			cbx_payment.SetPlaceholder("Select Payment Method")
			LoadInvoices()
		Catch ex As Exception

			MessageBox.Show($"An error occurred while generating the receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally

			If strcon.State = ConnectionState.Open Then
				strcon.Close()
			End If
		End Try
	End Sub



	Private Sub PopulateVehicleComboBox()
		Try
			Dim query As String = "SELECT vehicle_code FROM vehicle"
			Dim dt As New DataTable()

			Using connection As New MySqlConnection(connectionString)
				Using adapter As New MySqlDataAdapter(query, connection)
					adapter.Fill(dt)
				End Using
			End Using


			cbx_vehicle.Items.Clear()

			For Each row As DataRow In dt.Rows
				cbx_vehicle.Items.Add(row("vehicle_code").ToString())
			Next

			cbx_vehicle.SetPlaceholder("Select Vehicle")
		Catch ex As Exception
			MessageBox.Show("Error loading vehicle data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub


	Private Sub cbx_vehicle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_vehicle.SelectedIndexChanged
		If cbx_vehicle.SelectedItem IsNot Nothing Then
			Dim selectedVehicleCode As String = cbx_vehicle.SelectedItem.ToString()


			Dim query As String = $"SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID WHERE lp.vehicle_code = '{selectedVehicleCode}'"

			Try

				strcon.Open()


				cmd.Connection = strcon
				cmd.CommandText = query


				Dim dt As New DataTable()


				dt.Load(cmd.ExecuteReader())


				dgv_lplist.DataSource = dt
			Catch ex As Exception
				MessageBox.Show("Error fetching data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally

				If strcon.State = ConnectionState.Open Then
					strcon.Close()
				End If
			End Try
		End If
	End Sub

	Private Sub btn_showReceipt_Click(sender As Object, e As EventArgs) Handles btn_showReceipt.Click
		Try

			Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
			Dim receiptsFolderPath As String = Path.Combine(projectDirectory, "receipts")


			If Directory.Exists(receiptsFolderPath) Then

				Process.Start("explorer.exe", receiptsFolderPath)
			Else
				MessageBox.Show("The receipts folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		Catch ex As Exception
			MessageBox.Show($"An error occurred while opening the receipt folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub LoadInvoices()

		dgv_invoice.Rows.Clear()


		Using connection As MySqlConnection = strconnection()

			Dim query As String = "SELECT i.invoice_id, s.store_name, i.payment_method, i.transaction_date " &
							  "FROM invoices i " &
							  "JOIN store s ON i.store_id = s.storeID"


			Using command As New MySqlCommand(query, connection)

				connection.Open()


				Using reader As MySqlDataReader = command.ExecuteReader()

					While reader.Read()

						Dim invoiceID As Integer = reader.GetInt32("invoice_id")
						Dim storeName As String = reader.GetString("store_name")
						Dim paymentMethod As String = reader.GetString("payment_method")
						Dim transactionDate As Date = reader.GetDateTime("transaction_date")

						dgv_invoice.Rows.Add(invoiceID, storeName, paymentMethod, transactionDate.ToString("yyyy-MM-dd"))
					End While
				End Using
			End Using
		End Using
	End Sub


	Private Sub dgv_invoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_invoice.CellDoubleClick

		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then

			Dim invoiceID As Integer = Convert.ToInt32(dgv_invoice.Rows(e.RowIndex).Cells("InvoiceID").Value)


			GeneratePDF(invoiceID)
		End If
	End Sub

	Private Sub GeneratePDF(invoiceID As Integer)
		Try

			Using connection As MySqlConnection = strconnection()

				Dim query As String = "SELECT i.invoice_id, s.store_name, i.payment_method, i.transaction_date, " &
										"ii.product_id, p.prod_name, ii.format, ii.quantity, p.prod_price AS unit_price, " &
										"(ii.quantity * p.prod_price) AS total_price " &
										"FROM invoices i " &
										"JOIN invoice_items ii ON i.invoice_id = ii.invoice_id " &
										"JOIN product p ON ii.product_id = p.productID " &
										"JOIN store s ON i.store_id = s.storeID " &
										$"WHERE i.invoice_id = {invoiceID}"


				Using command As New MySqlCommand(query, connection)

					connection.Open()

					Dim storeName As String = ""
					Dim transactionDate As String = ""
					Using reader As MySqlDataReader = command.ExecuteReader()
						If reader.Read() Then
							storeName = reader.GetString("store_name")
							transactionDate = reader.GetDateTime("transaction_date").ToString("yyyyMMdd_HHmmss")
						End If
					End Using


					Dim fileName As String = $"Invoice_{invoiceID}_{storeName}_{transactionDate}.pdf"


					Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
					Dim invoiceFolderPath As String = Path.Combine(projectDirectory, "invoice")


					If Not Directory.Exists(invoiceFolderPath) Then
						Directory.CreateDirectory(invoiceFolderPath)
					End If

					Dim filePath As String = Path.Combine(invoiceFolderPath, fileName)


					Dim document As New iTextSharp.text.Document()


					Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(filePath, FileMode.Create))


					document.Open()


					Using reader As MySqlDataReader = command.ExecuteReader()
						If reader.Read() Then

							document.Add(New Paragraph($"Invoice ID: {invoiceID}"))
							document.Add(New Paragraph($"Store Name: {storeName}"))
							document.Add(New Paragraph($"Payment Method: {reader.GetString("payment_method")}"))
							document.Add(New Paragraph($"Transaction Date: {reader.GetDateTime("transaction_date").ToString("MM/dd/yyyy HH:mm:ss")}"))
							document.Add(New Paragraph(Environment.NewLine))


							Dim table As New PdfPTable(5)
							table.WidthPercentage = 100
							table.HorizontalAlignment = Element.ALIGN_LEFT

							table.AddCell("Product Name")
							table.AddCell("Format")
							table.AddCell("Total Quantity")
							table.AddCell("Unit Price")
							table.AddCell("Total Price")

							Dim totalSum As Decimal = 0


							Do

								Dim productName As String = reader.GetString("prod_name")
								Dim format As String = reader.GetString("format")
								Dim quantity As Double = reader.GetDouble("quantity")
								Dim unitPrice As Decimal = reader.GetDecimal("unit_price")
								Dim totalPrice As Decimal = reader.GetDecimal("total_price")


								table.AddCell(productName)
								table.AddCell(format)
								table.AddCell(quantity.ToString())
								table.AddCell(unitPrice.ToString("F2"))
								table.AddCell(totalPrice.ToString("F2"))


								totalSum += totalPrice
							Loop While reader.Read()
							Dim fontPath As String = "C:\Windows\Fonts\Arial.ttf"
							Dim baseFont As BaseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
							Dim font As New Font(baseFont, 12, Font.NORMAL)


							document.Add(table)
							Dim totalSumParagraph As New Paragraph($"Total Sum: ₱{totalSum.ToString("F2")}", font)
							document.Add(totalSumParagraph)
						End If
					End Using

					document.Close()


					MessageBox.Show($"PDF generated successfully. Saved as: {filePath}", "PDF Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)
				End Using
			End Using
		Catch ex As Exception

			MessageBox.Show($"An error occurred while generating the PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

	Private Sub btn_showInvoices_Click(sender As Object, e As EventArgs) Handles btn_showInvoices.Click
		Try

			Dim projectDirectory As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName
			Dim invoiceFolderPath As String = Path.Combine(projectDirectory, "invoice")


			If Directory.Exists(invoiceFolderPath) Then

				Process.Start("explorer.exe", invoiceFolderPath)
			Else
				MessageBox.Show("The invoice folder does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		Catch ex As Exception
			MessageBox.Show($"An error occurred while opening the invoice folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub

End Class