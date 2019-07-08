Imports MySql.Data.MySqlClient
Public Class TinCost

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        sql = "select * from tinrate"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            sql = "insert into tinrate(tin13,tin14)values('" + txtsize13.Text + "','" + txtsize14.Text + "')"
            VbConnection.Login(sql)
        Else
            sql = "update tinrate set tin13='" + txtsize13.Text + "',tin14='" + txtsize14.Text + "'"
            VbConnection.Login(sql)
            MsgBox("Cost of tin is added")
        End If
    End Sub

    Private Sub frmtincost_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        Dim reader As MySqlDataReader

        sql = "select tin13,tin14 from tinrate"
        VbConnection.Login(sql)
        Try
            con.Close()
            con.Open()
            Dim COMMAND As New MySqlCommand
            COMMAND = New MySqlCommand(sql, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                txtsize13.Text = reader.GetString("tin13")
                txtsize14.Text = reader.GetString("tin14")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub txtsize13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsize13.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtsize13.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtsize14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsize14.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtsize14.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
End Class