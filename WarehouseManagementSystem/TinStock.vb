Imports MySql.Data.MySqlClient
Public Class TinStock


    Sub loadgrid1()

        DataGridView1.Rows.Clear()
        con.Close()
        con.Open()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from tbl_tinsize ", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
        ' DataGridView1.Rows.Clear()

    End Sub

    Private Sub TinStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        loadgrid1()

    End Sub
End Class