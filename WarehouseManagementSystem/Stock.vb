Imports MySql.Data.MySqlClient
Public Class Stock
    Sub loadgrid1()
        DataGridView1.Rows.Clear()
        con.Close()
        con.Open()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select compno,goods,sum(quantity) from tbl_stock1 group by compno,goods", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
        ' DataGridView1.Rows.Clear()
      
    End Sub

    Private Sub frmstock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        loadgrid1()
    End Sub
End Class