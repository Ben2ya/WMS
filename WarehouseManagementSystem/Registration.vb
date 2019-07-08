Imports MySql.Data.MySqlClient
Public Class Registration
    Private Sub btnreg_Click(sender As Object, e As EventArgs) Handles btnreg.Click
        If ComboBox1.Text = "" And txtname.Text = "" And txtpass.Text = "" Then
            MsgBox("please empty field")
        Else
            Dim Sql As String = "SELECT * FROM user WHERE Username = '" + txtname.Text + "'"
            If VbConnection.Login(Sql) Then
                MsgBox("Record exist")
                txtname.Clear()
                txtpass.Clear()
                con.Close()
                con.Open()
            Else

                Dim query As String = "INSERT INTO `user`(`usertype`, `username`, `password`) VALUES('" + ComboBox1.Text + "','" + txtname.Text + "','" + txtpass.Text + "')"
                VbConnection.RunSQL(query)

                MessageBox.Show("registered successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtname.Clear()
                txtpass.Clear()
                con.Close()
                con.Open()
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        SendToTxtBox(e.RowIndex)

    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click

        Dim Sql As String = "SELECT * FROM user WHERE Username = '" + txtname.Text + "'"
        If VbConnection.Login(Sql) Then
            MsgBox("username exist")
            txtname.Clear()
            txtpass.Clear()
            con.Close()
            con.Open()
        Else
            Sql = "UPDATE `user` SET `usertype`='" + ComboBox1.Text + "', `username`='" + txtname.Text + "', `password`='" + txtpass.Text + "' WHERE username='" + DataGridView1.CurrentRow.Cells(1).Value + "'"
            VbConnection.Login(Sql)
            MsgBox("record updated")
            con.Close()
            con.Open()
        End If

    End Sub
    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        sql = "delete from user where username='" + DataGridView1.CurrentRow.Cells(1).Value + "'"
        VbConnection.Login(sql)
        If MsgBoxResult.No = MsgBox("do you want to permanently delete this record?", MsgBoxStyle.YesNo, "Warning") Then Exit Sub
        MsgBox("record deleted")
        clear()

        
    End Sub
   

    Private Sub reload()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM user"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "user")
            DataGridView1.DataSource = ds.Tables("user")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SendToTxtBox(ByVal x As Integer)

        Try
            ComboBox1.Text = DataGridView1.Rows(x).Cells(0).Value
            txtname.Text = DataGridView1.Rows(x).Cells(1).Value
            txtpass.Text = DataGridView1.Rows(x).Cells(2).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadGrid()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from user", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
    End Sub
    Private Sub clear()
        ComboBox1.SelectedIndex = -1
        txtname.Text = ""
        txtpass.Text = ""
        ComboBox1.Focus()

    End Sub

    Private Sub Registration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        loadGrid()
        reload()
    End Sub


    Private Sub btnclr_Click(sender As Object, e As EventArgs) Handles btnclr.Click
        clear()
    End Sub

End Class