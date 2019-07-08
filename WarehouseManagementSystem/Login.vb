Public Class Login

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If ComboBox1.Text = "" Then
            MsgBox("enter logintype")
        ElseIf txtname.Text = "" Then
            MsgBox("enter loginname")
        ElseIf txtpass.Text = "" Then
            MsgBox("enter loginpass")

        Else

            Try

                Dim Sql As String = "SELECT * FROM user WHERE Usertype = '" + ComboBox1.Text + "'  AND Username = '" + txtname.Text + "' AND Password = '" + txtpass.Text + "'"
                If VbConnection.Login(Sql) Then
                    If ComboBox1.Text = "admin" Then
                        Me.Hide()
                        MainPage.Show()
                        txtname.Text = ""
                        txtpass.Text = ""
                        ComboBox1.Text = ""
                        

                    ElseIf ComboBox1.Text = "subuser" Then
                        Me.Hide()
                        MainPage.PAYROLLToolStripMenuItem.Visible = False
                        MainPage.Show()
                        txtname.Text = ""
                        txtpass.Text = ""
                        ComboBox1.SelectedIndex = -1
                        
                    End If
                Else
                    MessageBox.Show("Login Failed", "Login")
                    clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            con.Close()
            con.Open()
        End If
    End Sub
    Sub clear()
        txtname.Text = ""
        txtpass.Text = ""
        ComboBox1.SelectedIndex = -1
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class