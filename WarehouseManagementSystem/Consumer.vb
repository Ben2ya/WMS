Imports MySql.Data.MySqlClient
Public Class Consumer
    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        If txtnum.Text = "" Then
            MsgBox("Enter Company number")
        ElseIf txtname.Text = "" Then
            MsgBox("Enter Company Name")
        Else
            sql = "insert into sales(sale_id,sale_name)"
            sql = sql + "values('" + txtnum.Text + " ','" + txtname.Text + "')"
            VbConnection.RunSQL(sql)
            MsgBox("Added successfully")

            clear()
        End If

    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        sql = "update sales set sale_name='" + txtname.Text + "' where sale_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        VbConnection.RunSQL(sql)
        MsgBox("record updated")
        clear()
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        sql = "delete from sales where sale_id='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        VbConnection.RunSQL(sql)
        If MsgBoxResult.No = MsgBox("do you want to permanently delete this record?", MsgBoxStyle.YesNo) Then Exit Sub
        MsgBox("record deleted")
        clear()
    End Sub

    Private Sub comp_sales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        loadGrid()
        reload()
    End Sub

    Sub clear()
        txtname.Text = ""
        txtnum.Text = ""
    End Sub
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        SendToTxtBox(e.RowIndex)
        btn_add.Enabled = False
        btn_update.Enabled = True
        btn_del.Enabled = True

    End Sub

    Private Sub reload()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM sales"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "sales")
            DataGridView1.DataSource = ds.Tables("sales")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SendToTxtBox(ByVal x As Integer)

        Try
            txtnum.Text = DataGridView1.Rows(x).Cells(0).Value
            txtname.Text = DataGridView1.Rows(x).Cells(1).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadGrid()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from sales", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
    End Sub



    Private Sub btn_clr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clr.Click
        clear()
    End Sub

    Private Sub txtname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtname.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtname.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtnum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtnum.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtnum.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

End Class