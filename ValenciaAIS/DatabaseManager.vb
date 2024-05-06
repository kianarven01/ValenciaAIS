Imports System.Diagnostics
Imports System.IO
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class DatabaseManager

    Private Const RegistryKeyPath As String = "SOFTWARE\MyApp"
    Private Const MySqlDumpPathValueName As String = "MySqlDumpPath"

    Public Sub BackupDatabase()
        Try
            Dim backupFileName As String = $"backup_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.sql"
            Dim backupFolderPath As String = Path.Combine(Application.StartupPath, "Backups")

            ' Check if the backup folder exists, if not, create it
            If Not Directory.Exists(backupFolderPath) Then
                Directory.CreateDirectory(backupFolderPath)
            End If

            Dim backupFilePath As String = Path.Combine(backupFolderPath, backupFileName)

            Dim mysqlDumpPath As String = FindMySqlDump()

            If mysqlDumpPath IsNot Nothing Then
                PerformBackup(mysqlDumpPath, backupFilePath)
            Else
                mysqlDumpPath = GetStoredMySqlDumpPath()
                If mysqlDumpPath IsNot Nothing AndAlso File.Exists(mysqlDumpPath) Then
                    PerformBackup(mysqlDumpPath, backupFilePath)
                Else
                    ' Show message box indicating mysqldump.exe is not found
                    MessageBox.Show("mysqldump.exe not found. Please locate it manually.")

                    ' Prompt the user to select the location of mysqldump.exe
                    Dim openFileDialog As New OpenFileDialog()
                    openFileDialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*"
                    openFileDialog.Title = "Select mysqldump.exe"
                    If openFileDialog.ShowDialog() = DialogResult.OK Then
                        mysqlDumpPath = openFileDialog.FileName
                        ' Save the path to the registry
                        SaveMySqlDumpPath(mysqlDumpPath)
                        PerformBackup(mysqlDumpPath, backupFilePath)
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error backing up database: " & ex.Message)
        End Try
    End Sub

    Private Function GetStoredMySqlDumpPath() As String
        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(RegistryKeyPath)
        If key IsNot Nothing Then
            Dim value As Object = key.GetValue(MySqlDumpPathValueName)
            If value IsNot Nothing AndAlso TypeOf value Is String Then
                Return DirectCast(value, String)
            End If
        End If
        Return Nothing
    End Function

    Private Sub SaveMySqlDumpPath(ByVal mysqlDumpPath As String)
        Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(RegistryKeyPath)
        key.SetValue(MySqlDumpPathValueName, mysqlDumpPath)
        key.Close()
    End Sub


    Private Sub PerformBackup(ByVal mysqlDumpPath As String, ByVal backupFilePath As String)
        Dim processStartInfo As New ProcessStartInfo()
        processStartInfo.FileName = mysqlDumpPath
        processStartInfo.Arguments = $"--user=root --host=localhost --result-file=""{backupFilePath}"" valencia_agriculture"
        processStartInfo.CreateNoWindow = True
        processStartInfo.UseShellExecute = False
        Process.Start(processStartInfo)
        'MessageBox.Show("Database backed up successfully.")
    End Sub

    Private Function FindMySqlDump() As String
        ' Common paths where mysqldump.exe might be installed
        Dim commonPaths() As String = {
            "C:\Program Files\MySQL\MySQL Server 8.0\bin\mysqldump.exe",
            "C:\Program Files (x86)\MySQL\MySQL Server 8.0\bin\mysqldump.exe"
        }

        For Each path As String In commonPaths
            If File.Exists(path) Then
                Return path
            End If
        Next

        ' Add more paths as needed

        Return Nothing ' Return Nothing if mysqldump.exe is not found
    End Function


    Public Sub RestoreDatabase(backupFilePath As String)
        Dim connectionString As String = "server=localhost; user id=root; password=;"
        Dim connection As New MySqlConnection(connectionString)

        Try
            connection.Open()

            ' Create the valencia_agriculture database if it does not exist
            Dim createDatabaseQuery As String = "CREATE DATABASE IF NOT EXISTS valencia_agriculture;"
            Dim createDatabaseCommand As New MySqlCommand(createDatabaseQuery, connection)
            createDatabaseCommand.ExecuteNonQuery()

            ' Switch to the valencia_agriculture database
            connection.ChangeDatabase("valencia_agriculture")

            ' Check if the backup file exists
            If Not File.Exists(backupFilePath) Then
                MessageBox.Show("Backup file not found.")
                Exit Sub
            End If

            ' Read the SQL script from the backup file
            Dim sql As String = File.ReadAllText(backupFilePath)

            ' Check if the SQL script is empty
            If String.IsNullOrWhiteSpace(sql) Then
                MessageBox.Show("Backup file is empty.")
                Exit Sub
            End If

            ' Execute the SQL script to restore the database
            Dim restoreCommand As New MySqlCommand(sql, connection)
            restoreCommand.ExecuteNonQuery()

            MessageBox.Show("Database restored successfully.")
        Catch ex As Exception
            MessageBox.Show("Error restoring database: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub


End Class
