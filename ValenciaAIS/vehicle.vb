﻿Public Class vehicle
	Public Event LoadedProductDataChanged As EventHandler
	Private selectedVehicleCode As String
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
		' Load data into dgv_plist from product table
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
		reload("SELECT * FROM product", dgv_plist)
		reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)


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

			' Prompt the user to enter the quantity
			Dim quantityForm As New QuantityInputForm
			If quantityForm.ShowDialog = DialogResult.OK Then
				' Get the quantity entered by the user
				Dim quantity = quantityForm.Quantity

				' Deduct the quantity from prod_stock in the product table
				Dim queryDeductStock = $"UPDATE product SET prod_stock = prod_stock - {quantity} WHERE productID = {productId}"
				ExecuteNonQueryWithoutPrompt(queryDeductStock)

				' Check if the product already exists in loaded_product
				Dim queryCheckExistingProduct = $"SELECT COUNT(*) FROM loaded_product WHERE productID = {productId}"
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
				' If the product already exists, update the loaded_stock, otherwise insert a new record
				If existingProductCount > 0 Then
					Dim queryUpdateLoadedStock = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE productID = {productId}"
					ExecuteNonQueryWithoutPrompt(queryUpdateLoadedStock)
				Else
					Dim queryAddToLoadedStock = $"INSERT INTO loaded_product (productID, loaded_stock) VALUES ({productId}, {quantity})"
					ExecuteNonQueryWithoutPrompt(queryAddToLoadedStock)
				End If
				RaiseEvent LoadedProductDataChanged(Me, EventArgs.Empty)
				' Reload dgv_plist and dgv_lplist to reflect the changes
				reload("SELECT * FROM product", dgv_plist)
				' Update the SQL query to include price and format columns
				reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
			End If
		End If
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
			Dim loadedStock As Integer = Convert.ToInt32(selectedRow.Cells("loaded_stock").Value)

			' Fetch the productId based on the selected product name
			Dim productId As Integer = GetProductIdByName(productName)

			If productId <> -1 Then
				' Remove the item from loaded_product table
				Dim queryRemoveItem As String = $"DELETE FROM loaded_product WHERE loaded_productID = {loadedProductId}"
				ExecuteNonQueryWithoutPrompt(queryRemoveItem)

				' Update the product stock by adding the removed quantity
				Dim queryAddStock As String = $"UPDATE product SET prod_stock = prod_stock + {loadedStock} WHERE productID = {productId}"
				ExecuteNonQueryWithoutPrompt(queryAddStock)

				' Raise the LoadedProductDataChanged event to trigger reload
				RaiseEvent LoadedProductDataChanged(Me, EventArgs.Empty)

				' Reload dgv_lplist and dgv_plist to reflect the changes
				reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
				reload("SELECT * FROM product", dgv_plist)

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
		If String.IsNullOrWhiteSpace(txb_vhcode.Text) OrElse
		String.IsNullOrWhiteSpace(txb_make.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_model.Text) OrElse
	   String.IsNullOrWhiteSpace(txb_plate.Text) Then
			MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Proceed with data creation
		Try
			create("INSERT INTO vehicle (vehicle_code, make, model, plate) VALUES ('" & txb_vhcode.Text & "', '" & txb_make.Text & "','" & txb_model.Text & "', '" & txb_plate.Text & "') ")
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
	End Sub

	Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
		Try
			' Retrieve vehicleID based on the provided vehicle_code
			Dim vehicleID As Integer = GetVehicleIDByCode(txb_vhcode.Text)

			' If vehicleID is found, check if the vehicle_code has been changed
			If vehicleID <> -1 Then
				' Check if the vehicle_code has been changed
				If txb_vhcode.Text <> selectedVehicleCode Then
					MessageBox.Show("Cannot update Vehicle Code. Please update the vehicle details using the correct Vehicle Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Else
					' Proceed with updating other details
					updates("UPDATE vehicle SET make='" & txb_make.Text & "', model='" & txb_model.Text & "', plate='" & txb_plate.Text & "' WHERE vehicleID = '" & vehicleID & "'")
				End If
			Else
				MessageBox.Show("Vehicle not found for the provided vehicle code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message)
		End Try

		' Reload the vehicle list
		reload("SELECT vehicle_code, make, model, plate FROM vehicle", dgv_vlist)
	End Sub



	Private Function GetVehicleIDByCode(ByVal vehicleCode As String) As Integer
		Dim vehicleID As Integer = -1 ' Default value if vehicle not found
		Try
			' Perform a query to retrieve vehicleID based on vehicle_code
			Dim query As String = $"SELECT vehicleID FROM vehicle WHERE vehicle_code = '{vehicleCode}'"
			strcon.Open()
			cmd.Connection = strcon
			cmd.CommandText = query
			Dim result As Object = cmd.ExecuteScalar()
			If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
				vehicleID = Convert.ToInt32(result)
			End If
		Catch ex As Exception
			Throw
		Finally
			strcon.Close()
		End Try
		Return vehicleID
	End Function

	Private Sub dgv_vlist_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_vlist.CellClick
		If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
			Dim selectedRow = dgv_vlist.Rows(e.RowIndex)
			selectedVehicleCode = txb_vhcode.Text ' Store the original vehicle_code
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

End Class
