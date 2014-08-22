Module frmRoom
    '1. Create
    'ok
    

    '3. Update

    '4. Delete
    Public Sub deleteRoom(param_roomId As String)
        Try
            dbConnect()
            Dim sql As String
            sql = "DELETE FROM room where id = @roomId"

            With sqlCmd
                .CommandText = sql
                .Connection = Con

                With .Parameters
                    .AddWithValue("roomId", param_roomId)
                End With

                .ExecuteNonQuery()
            End With
            dbClose()
        Catch ex As Exception
            dbClose()
            MsgBox(ex.Message.ToString)

        End Try
    End Sub

End Module
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim room = New Room
        room.getRooms(lvRoom)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Form1_add.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim roomId As String
        roomId = lvRoom.SelectedItems(0).Text
        ''MessageBox.Show(roomId)
        'deleteRoom(roomId)
        'getRooms(lvRoom)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Form1_add.txtRoomNumber.Text = lvRoom.SelectedItems(0).SubItems(1).Text()
        Form1_add.txtCapacity.Text = lvRoom.SelectedItems(0).SubItems(2).Text()
        Form1_add.btnSave.Text = "Update"
        Form1_add.ShowDialog()
    End Sub
End Class
