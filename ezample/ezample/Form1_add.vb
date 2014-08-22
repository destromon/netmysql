Module RoomSave
    Public Sub createRoom(param_roomNumber As String, param_roomCapacity As String)
        Try
            dbConnect()

            Dim sql As String
            sql = "INSERT INTO room(room_number, room_capacity) VALUES(@roomNumber, @roomCapacity)"

            With sqlCmd
                .CommandText = sql
                .Connection = Con

                With .Parameters
                    .AddWithValue("roomNumber", param_roomNumber)
                    .AddWithValue("roomCapacity", param_roomCapacity)
                End With

                .ExecuteNonQuery()
            End With
            dbClose()
        Catch ex As Exception
            dbClose()
            MessageBox.Show(ex.Message.ToString)
        End Try

    End Sub

    Public Sub updateRoom(param_roomNumber As String, param_roomCapacity As String, param_criteria As String)
        Try
            dbConnect()
            Dim sql As String
            sql = "UPDATE room SET room_number = @roomNumber, room_capacity = @roomCapacity WHERE id = @criteria"

            With sqlCmd
                .CommandText = sql
                .Connection = Con

                With .Parameters
                    .AddWithValue("roomNumber", param_roomNumber)
                    .AddWithValue("roomCapacity", param_roomCapacity)
                    .AddWithValue("criteria", param_criteria)
                End With

                .ExecuteNonQuery()
            End With
            dbClose()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString)
            dbClose()
        End Try
    End Sub
End Module
Public Class Form1_add

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtCapacity.TextChanged

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.Text = "Save" Then
            createRoom(txtRoomNumber.Text, txtCapacity.Text)
        Else
            'update yan
            updateRoom(txtRoomNumber.Text, txtCapacity.Text, Form1.lvRoom.SelectedItems(0).Text)
        End If


    End Sub

    Private Sub Form1_add_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class