Imports MySql.Data.MySqlClient

Public Class login

    Public Property LoginSuccessful As Boolean


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btn_login

        cbx_privilege.Items.AddRange({"admin", "user"})

        cbx_privilege.SelectedItem = "user"
    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click

        If String.IsNullOrWhiteSpace(txb_username.Text) OrElse String.IsNullOrWhiteSpace(txb_password.Text) Then
            MessageBox.Show("Username and password are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If


        If txb_username.Text.ToLower() = "superadmin" AndAlso txb_password.Text.ToLower() = "helloworld" Then

            DBConnection.UserType = "superadmin"

            LoginSuccessful = True

            Me.Close()

            MessageBox.Show("Logged in as superadmin.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim hashedPassword As String = PasswordHasher.HashPassword(txb_password.Text)


        Dim sql As String = "SELECT * FROM user WHERE username = @username AND password = @password AND user_type = @userType"
        Using connection As MySqlConnection = DBConnection.strconnection()
            Using adapter As New MySqlDataAdapter(sql, connection)
                adapter.SelectCommand.Parameters.AddWithValue("@username", txb_username.Text)
                adapter.SelectCommand.Parameters.AddWithValue("@password", hashedPassword)
                adapter.SelectCommand.Parameters.AddWithValue("@userType", cbx_privilege.SelectedItem.ToString())
                Dim dt As New DataTable()
                Try
                    connection.Open()
                    adapter.Fill(dt)
                    If dt.Rows.Count > 0 Then

                        Dim userType As String = dt.Rows(0)("user_type").ToString()

                        DBConnection.UserType = userType

                        MessageBox.Show("Login successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        LoginSuccessful = True

                        Me.Close()
                    Else

                        MessageBox.Show("Invalid username, password, or user type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Catch ex As MySqlException When ex.Number = 1049
                    MessageBox.Show("Database not found. Please login as superadmin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End Using
        End Using
    End Sub


    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click

        LoginSuccessful = False

        Me.Close()
    End Sub

    Private Sub txb_password_TextChanged(sender As Object, e As EventArgs) Handles txb_password.TextChanged
        txb_password.PasswordChar = "*"
    End Sub
End Class
