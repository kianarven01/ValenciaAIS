﻿Public Class vehicle
    ' Method to execute SQL queries without showing the success message
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
        ' Load data into dgv_plist from product table
        reload("SELECT * FROM product", dgv_plist)
        reload("SELECT * FROM loaded_product", dgv_lplist)

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

                ' Reload dgv_plist and dgv_lplist to reflect the changes
                reload("SELECT * FROM product", dgv_plist)
                ' Update the SQL query to include price and format columns
                reload("SELECT lp.loaded_productID, p.prod_name, p.prod_price, lp.loaded_stock, p.prod_stock_format FROM loaded_product lp INNER JOIN product p ON lp.productID = p.productID", dgv_lplist)
            End If
        End If
    End Sub

End Class