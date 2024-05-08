Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class vehicle
	Public Event LoadedProductDataChanged As EventHandler
	Private loadingVehicleCodes As Boolean = False

	Private Sub ExecuteNonQueryWithoutPrompt(ByVal sql As String)
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

	Private Sub vehicle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		AddHandler product.ProductDataChanged, AddressOf ProductDataChangedHandler
		txb_vhcode.Enabled = False
		EnableVehicleDetails(False)
		EnableVehicleDetails(DBConnection.UserType = "admin")
		LoadVehicleCodes()
		' Load data into dgv_plist from product table
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
		reload("SELECT * FROM product", dgv_plist)
		InitializeLoadedProductDataGridView()
	End Sub

	Private Sub EnableVehicleDetails(ByVal enable As Boolean)
		txb_make.Enabled = enable
		txb_model.Enabled = enable
		txb_plate.Enabled = enable
		btn_new.Enabled = enable
		btn_create.Enabled = enable
		btn_update.Enabled = enable
		btn_delete.Enabled = enable
	End Sub


	Private Sub vehicle_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
		If Me.Visible Then
			' Clear the fields when the form becomes visible
			ClearFields()
			dgv_lplist.DataSource = Nothing
		End If
	End Sub




	Private Sub ProductDataChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
		' Reload dgv_plist and dgv_lplist to reflect the changes
		reload("SELECT * FROM product", dgv_plist)
		reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
	End Sub


	Private Sub dgv_plist_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_plist.CellDoubleClick
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			' Get the selected product details from dgv_plist
			Dim selectedRow = dgv_plist.Rows(e.RowIndex)
			Dim productId = Convert.ToInt32(selectedRow.Cells(0).Value)
			Dim productName = Convert.ToString(selectedRow.Cells(1).Value)
			Dim productPrice = Convert.ToDecimal(selectedRow.Cells(2).Value)
			Dim productStockFormat = Convert.ToString(selectedRow.Cells(4).Value)

			' Check if a vehicle is selected in the ComboBox
			If cbx_vehicle.SelectedItem Is Nothing Then
				MessageBox.Show("Please select a vehicle first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			' Prompt the user to enter the quantity
			Dim quantityForm As New QuantityInputForm
			If quantityForm.ShowDialog = DialogResult.OK Then
				' Get the quantity entered by the user
				Dim quantity = quantityForm.Quantity

				' Deduct the quantity from prod_stock in the product table
				Dim queryDeductStock = $"UPDATE product SET prod_stock = prod_stock - {quantity} WHERE productID = {productId}"
				ExecuteNonQueryWithoutPrompt(queryDeductStock)

				' Associate the loaded product with the selected vehicle
				Dim selectedVehicleCode As String = cbx_vehicle.SelectedItem.ToString()
				AssociateProductWithVehicle(productId, selectedVehicleCode, quantity)

				' Reload dgv_plist and dgv_lplist to reflect the changes
				reload("SELECT * FROM product", dgv_plist)

				' Trigger the selected index changed event of cbx_vehicle to reload dgv_lplist
				cbx_vehicle_SelectedIndexChanged(cbx_vehicle, EventArgs.Empty)
			End If
		End If
	End Sub


	Public Sub AssociateProductWithVehicle(productId As Integer, vehicleCode As String, quantity As Double)
		' Check if the product already exists in loaded_product
		Dim queryCheckExistingProduct = $"SELECT COUNT(*) FROM loaded_product WHERE productID = {productId} AND vehicle_code = '{vehicleCode}'"
		Dim existingProductCount = 0
		Try
			strcon.Open()
			cmd.Connection = strcon
			cmd.CommandText = queryCheckExistingProduct
			existingProductCount = Convert.ToInt32(cmd.ExecuteScalar)
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			strcon.Close()
		End Try

		' If the product already exists for the selected vehicle, update the loaded_stock, otherwise insert a new record
		If existingProductCount > 0 Then
			Dim queryUpdateLoadedStock = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE productID = {productId} AND vehicle_code = '{vehicleCode}'"
			ExecuteNonQueryWithoutPrompt(queryUpdateLoadedStock)
		Else
			Dim queryAddToLoadedStock = $"INSERT INTO loaded_product (productID, loaded_stock, vehicle_code) VALUES ({productId}, {quantity}, '{vehicleCode}')"
			ExecuteNonQueryWithoutPrompt(queryAddToLoadedStock)
		End If
		RaiseEvent LoadedProductDataChanged(Me, EventArgs.Empty)
	End Sub


	Private Function GetProductIdByName(ByVal productName As String) As Integer
		Dim productId As Integer = -1 ' Default value if product is not found
		Try
			strcon.Open()
			cmd.Connection = strcon
			cmd.CommandText = $"SELECT productID FROM product WHERE prod_name = '{productName}'"
			Dim result = cmd.ExecuteScalar()
			If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
				productId = Convert.ToInt32(result)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		Finally
			strcon.Close()
		End Try
		Return productId
	End Function


	Private Sub btn_remove_item_Click(sender As Object, e As EventArgs) Handles btn_remove_item.Click
		If dgv_lplist.SelectedCells.Count > 0 Then
			Dim rowIndex As Integer = dgv_lplist.SelectedCells(0).RowIndex
			Dim selectedRow = dgv_lplist.Rows(rowIndex)
			Dim loadedProductId As Integer = Convert.ToInt32(selectedRow.Cells("loaded_productID").Value)
			Dim productName As String = Convert.ToString(selectedRow.Cells("prod_name").Value)
			Dim loadedStock As Decimal = Convert.ToDecimal(selectedRow.Cells("loaded_stock").Value) ' Use Decimal data type

			' Fetch the productId based on the selected product name
			Dim productId As Integer = GetProductIdByName(productName)

			If productId <> -1 Then
				' Remove the item from loaded_product table
				Dim queryRemoveItem As String = $"DELETE FROM loaded_product WHERE loaded_productID = {loadedProductId}"
				ExecuteNonQueryWithoutPrompt(queryRemoveItem)

				' Update the product stock by adding the removed quantity
				Dim queryAddStock As String = $"UPDATE product SET prod_stock = prod_stock + {loadedStock} WHERE productID = {productId}" ' Add loaded stock back to product stock
				ExecuteNonQueryWithoutPrompt(queryAddStock)

				' Raise the LoadedProductDataChanged event to trigger reload
				RaiseEvent LoadedProductDataChanged(Me, EventArgs.Empty)

				' Reload dgv_lplist and dgv_plist to reflect the changes
				reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
				reload("SELECT * FROM product", dgv_plist)

				' Refresh the ComboBox to reload the associated loaded products
				cbx_vehicle_SelectedIndexChanged(cbx_vehicle, EventArgs.Empty)

				MessageBox.Show("Item removed successfully and stock updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Else
				MessageBox.Show("Selected product not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		Else
			MessageBox.Show("Please select an item to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End If
	End Sub



	'CRUD
	Private Sub ClearFields()
		txb_vhcode.Clear()
		txb_make.Clear()
		txb_model.Clear()
		txb_plate.Clear()
		cbx_vehicle.Text = ""

	End Sub

	Private Sub btn_new_Click(sender As Object, e As EventArgs) Handles btn_new.Click
		ClearFields()
	End Sub

	Private Sub btn_create_Click(sender As Object, e As EventArgs) Handles btn_create.Click
		If String.IsNullOrWhiteSpace(txb_make.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_model.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_plate.Text) Then
			MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Generate a new vehicle code
		Dim newVehicleCode As String = GenerateNextVehicleCode()

		' Proceed with data creation
		Try
			create("INSERT INTO vehicle (vehicle_code, make, model, plate) VALUES ('" & newVehicleCode & "', '" & txb_make.Text & "','" & txb_model.Text & "', '" & txb_plate.Text & "') ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

		' Reload the vehicle list
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
	End Sub

	Private Function GenerateNextVehicleCode() As String
		' Retrieve the maximum existing vehicle code
		Dim maxVehicleCode As String = ""
		Try
			strcon.Open()
			cmd.Connection = strcon
			cmd.CommandText = "SELECT MAX(vehicle_code) FROM vehicle"
			Dim result As Object = cmd.ExecuteScalar()
			If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
				maxVehicleCode = Convert.ToString(result)
			End If
		Catch ex As Exception
			Throw
		Finally
			strcon.Close()
		End Try

		' Extract the numeric part of the maximum vehicle code
		Dim numericPart As Integer = 0
		If Not String.IsNullOrEmpty(maxVehicleCode) AndAlso maxVehicleCode.StartsWith("VHC") AndAlso Integer.TryParse(maxVehicleCode.Substring(3), numericPart) Then
			numericPart += 1 ' Increment the numeric part
		Else
			' Set the initial numeric part if no existing vehicle code is found
			numericPart = 1
		End If

		' Generate the new vehicle code
		Return "VHC" & numericPart.ToString().PadLeft(3, "0"c) ' e.g., VHC001, VHC002, ...
	End Function

	Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
		Try
			' Check if all required fields are filled
			If String.IsNullOrWhiteSpace(txb_make.Text) OrElse
		   String.IsNullOrWhiteSpace(txb_model.Text) OrElse
		   String.IsNullOrWhiteSpace(txb_plate.Text) Then
				MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			' Proceed with updating the record
			updates("UPDATE vehicle SET make='" & txb_make.Text & "', model='" & txb_model.Text & "', plate='" & txb_plate.Text & "' WHERE vehicle_code = '" & txb_vhcode.Text & "'")

			' Reload the vehicle list
			reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
		Catch ex As Exception
			' If an error occurs during the update, show an error message
			MessageBox.Show("Failed to update record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		End Try
	End Sub


	Private Sub dgv_vlist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_vlist.CellClick
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			Dim selectedRow = dgv_vlist.Rows(e.RowIndex)
			txb_vhcode.Text = selectedRow.Cells(0).Value.ToString()
			txb_make.Text = selectedRow.Cells(1).Value.ToString()
			txb_model.Text = selectedRow.Cells(2).Value.ToString()
			txb_plate.Text = selectedRow.Cells(3).Value.ToString()
		End If
	End Sub

	Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
		Try
			delete("DELETE FROM vehicle WHERE vehicle_code ='" & txb_vhcode.Text & "' ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
	End Sub

	Private Sub LoadVehicleCodes()
		' Set flag to indicate ComboBox population
		loadingVehicleCodes = True

		' SQL query to fetch vehicle codes
		Dim query As String = "SELECT vehicle_code FROM vehicle"

		Try
			' Open connection
			strcon.Open()

			' Set up command
			cmd.Connection = strcon
			cmd.CommandText = query

			' Execute command and fetch data
			Dim reader As MySqlDataReader = cmd.ExecuteReader()
			While reader.Read()
				' Add each vehicle code to the ComboBox
				cbx_vehicle.Items.Add(reader("vehicle_code").ToString())
			End While
		Catch ex As Exception
			MessageBox.Show("Error loading vehicle codes: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			' Close connection
			strcon.Close()
		End Try

		' Set DisplayMember and ValueMember properties
		cbx_vehicle.DisplayMember = "vehicle_code"
		cbx_vehicle.ValueMember = "vehicle_code"

		' Reset flag after populating ComboBox
		loadingVehicleCodes = False
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

	Private Sub txb_searchVehicle_TextChanged(sender As Object, e As EventArgs) Handles txb_searchVehicle.TextChanged

		Dim connectionString = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query = "SELECT * FROM vehicle WHERE vehicle_code LIKE @Keyword OR make LIKE @Keyword  OR model LIKE @Keyword  OR plate LIKE @Keyword"
		Dim keyword = "%" & txb_searchVehicle.Text.Trim & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open()

				Using reader = command.ExecuteReader
					Dim dt As New DataTable
					dt.Load(reader)
					dgv_vlist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

	Private Sub txb_search_TextChanged(sender As Object, e As EventArgs) Handles txb_search.TextChanged
		Dim connectionString = "server=localhost; user id=root; password=; database=valencia_agriculture"
		Dim query = "SELECT * FROM product WHERE prod_name LIKE @Keyword OR productID LIKE @Keyword"
		Dim keyword = "%" & txb_search.Text.Trim & "%"

		Using connection As New MySqlConnection(connectionString)
			Using command As New MySqlCommand(query, connection)
				command.Parameters.AddWithValue("@Keyword", keyword)
				connection.Open()

				Using reader = command.ExecuteReader
					Dim dt As New DataTable
					dt.Load(reader)
					dgv_plist.DataSource = dt
				End Using
			End Using
		End Using
	End Sub

End Class