Imports MySql.Data.MySqlClient
Module connection
    Public Con As MySqlConnection
    Public sqlCmd As MySqlCommand
    Public dReader As MySqlDataReader

    'open database connection
    Public Sub dbConnect()
        Try
            sqlCmd = New MySqlCommand
            Con = New MySqlConnection
            With Con
                .ConnectionString = "Server=localhost;Database=test;Uid=root;Pwd=;"
                .Open()
            End With
            MessageBox.Show("Connected na tayo!")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Cant connecto to database")
        End Try
    End Sub

    'close database connection
    Public Sub dbClose()
        Try
            'clear parameters
            sqlCmd.Parameters.Clear()
            'remove from memory
            sqlCmd.Dispose()
            'close data reader
            dReader.Close()
            'close connection
            Con.Close()
            'remove connection from memory
            Con.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Cant connecto to database")
        End Try
    End Sub

End Module
