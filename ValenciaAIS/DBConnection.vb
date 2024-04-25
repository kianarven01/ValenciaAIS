Imports MySql.Data.MySqlClient
Module DBConnection

    Public Function strconnection() As MySqlConnection
        Return New MySqlConnection("server=localhost; user id=root; password=; database=valencia_agriculture")
    End Function

    Public strcon As MySqlConnection = strconnection()

    Public result As String
    Public cmd As New MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As New DataTable

    Public UserType As String

    Public Sub create(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Failed to save data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub reload(ByVal sql As String, ByVal DTG As Object)
        Try
            If DTG Is Nothing Then
                MessageBox.Show("Error: The DataGridView object is null.")
                Return
            End If

            dt = New DataTable
            strcon.Open()

            ' Check if da is null before using it
            If da Is Nothing Then
                da = New MySqlDataAdapter
            End If

            ' Check if cmd is null before using it
            If cmd Is Nothing Then
                cmd = New MySqlCommand
            End If

            With cmd
                .Connection = strcon
                .CommandText = sql
            End With

            da.SelectCommand = cmd
            da.Fill(dt)
            DTG.DataSource = dt
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
            If da IsNot Nothing Then
                da.Dispose()
            End If
        End Try
    End Sub


    Public Sub updates(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Data failed to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

    Public Sub delete(ByVal sql As String)
        Try
            strcon.Open()
            With cmd
                .Connection = strcon
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result = 0 Then
                    MessageBox.Show("Data failed to delete in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            strcon.Close()
        End Try
    End Sub

End Module
