Public Class Room
    '2. Read 
    Public Sub getRooms(ByRef lv As ListView)
        Try
            dbConnect()
            Dim sql As String
            sql = "SELECT * FROM room"
            With sqlCmd
                .CommandText = sql
                .Connection = Con
                dReader = .ExecuteReader
            End With

            'clear listing
            lv.Items.Clear()

            'populate listview
            While dReader.Read()
                lv.Items.Add(dReader("id"))
                lv.Items(lv.Items.Count - 1).SubItems.Add(dReader("room_number"))
                lv.Items(lv.Items.Count - 1).SubItems.Add(dReader("room_capacity"))
            End While
            dbClose()

        Catch ex As Exception
            dbClose()
        End Try
    End Sub

    Public Function exists()

    End Function
End Class
