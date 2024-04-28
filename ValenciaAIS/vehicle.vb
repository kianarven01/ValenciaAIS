Public Class vehicle
	Public Event LoadedProductDataChanged As EventHandler
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
			Dim productId As Integer = Convert.ToInt32(selectedRow.Cells(0).Value)
			Dim productName As String = Convert.ToString(selectedRow.Cells(1).Value)
			Dim productPrice As Decimal = Convert.ToDecimal(selectedRow.Cells(2).Value)
			Dim productStockFormat As String = Convert.ToString(selectedRow.Cells(4).Value)

			' Prompt the user to enter the quantity
			Dim quantityForm As New QuantityInputForm()
			If quantityForm.ShowDialog() = DialogResult.OK Then
				' Get the quantity entered by the user
				Dim quantity As Integer = quantityForm.Quantity

				' Deduct the quantity from prod_stock in the product table
				Dim queryDeductStock As String = $"UPDATE product SET prod_stock = prod_stock - {quantity} WHERE productID = {productId}"
				ExecuteNonQueryWithoutPrompt(queryDeductStock)

				' Check if the product already exists in loaded_product
				Dim queryCheckExistingProduct As String = $"SELECT COUNT(*) FROM loaded_product WHERE productID = {productId}"
				Dim existingProductCount As Integer = 0
				Try
					strcon.Open()
					cmd.Connection = strcon
					cmd.CommandText = queryCheckExistingProduct
					existingProductCount = Convert.ToInt32(cmd.ExecuteScalar())
				Catch ex As Exception
					MessageBox.Show(ex.Message)
				Finally
					strcon.Close()
				End Try
				' If the product already exists, update the loaded_stock, otherwise insert a new record
				If existingProductCount > 0 Then
					Dim queryUpdateLoadedStock As String = $"UPDATE loaded_product SET loaded_stock = loaded_stock + {quantity} WHERE productID = {productId}"
					ExecuteNonQueryWithoutPrompt(queryUpdateLoadedStock)
				Else
					Dim queryAddToLoadedStock As String = $"INSERT INTO loaded_product (productID, loaded_stock) VALUES ({productId}, {quantity})"
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







End Class
