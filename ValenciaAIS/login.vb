Imports MySql.Data.MySqlClient

Public Class login
	' Public property to indicate login status
	Public Property LoginSuccessful As Boolean

	Public Shared UserType As String

	' Set the AcceptButton property to the login button
	Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Me.AcceptButton = btn_login
	End Sub

	Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
		' Check if textboxes are empty
		If String.IsNullOrWhiteSpace(txb_username.Text) OrElse String.IsNullOrWhiteSpace(txb_password.Text) Then
			MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Return
		End If

		' Your login code here
		Dim sql As String = "SELECT * FROM user WHERE username = @username AND password = @password"
		Using connection As MySqlConnection = DBConnection.strconnection()
			Using adapter As New MySqlDataAdapter(sql, connection)
				adapter.SelectCommand.Parameters.AddWithValue("@username", txb_username.Text)
				adapter.SelectCommand.Parameters.AddWithValue("@password", txb_password.Text)
				Dim dt As New DataTable()
				Try
					connection.Open()
					adapter.Fill(dt)
					If dt.Rows.Count > 0 Then
						' Retrieve user type from the database
						Dim userType As String = dt.Rows(0)("user_type").ToString()
						' Store user type in the DBConnection module
						DBConnection.UserType = userType

						' Login successful
						MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
						' Set LoginSuccessful property to True
						LoginSuccessful = True
						' Close the login form
						Me.Close()
					Else
						' Login failed
						MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
					End If
				Catch ex As Exception
					MessageBox.Show(ex.Message)
				End Try
			End Using
		End Using
	End Sub


	Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
		' Set LoginSuccessful property to False
		LoginSuccessful = False
		' Close the login form
		Me.Close()
	End Sub

	Private Sub txb_password_TextChanged(sender As Object, e As EventArgs) Handles txb_password.TextChanged
		txb_password.PasswordChar = "*"
	End Sub

End Class
