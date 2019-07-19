Imports MySql.Data.MySqlClient
Public Class Supplier
    Dim cmd As New mysqlcommand

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        If txtname.Text = "" Then
            MsgBox("Enter Company name")
        ElseIf txtnum.Text = "" Then
            MsgBox("Enter Company number")
        ElseIf txtraw.Text = "" Then
            MsgBox("Enter raw material")
        Else
            sql = "select * from pchase where id= '" + txtnum.Text + "'"
            VbConnection.Login(sql)
            If VbConnection.Login(sql) = True Then
                MsgBox("companyid already exit")
            Else

                sql = "insert into pchase(name,id,raw_material)"
                sql = sql + "values('" + txtname.Text + " ','" + txtnum.Text + "','" + txtraw.Text + "' )"
                VbConnection.Login(sql)
                MsgBox("Added successfully")
                clear()
            End If
        End If
    End Sub

    Private Sub comp_purchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        loadGrid()
        reload()
        btn_update.Enabled = False
        btn_del.Enabled = False
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        btn_update.Enabled = True
        btn_del.Enabled = True
        btn_add.Enabled = False
        SendToTxtBox(e.RowIndex)
    End Sub

    Private Sub btn_del_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_del.Click
        sql = "delete from pchase where id='" + DataGridView1.CurrentRow.Cells(1).Value + "'"
        VbConnection.Login(sql)
        If MsgBoxResult.No = MsgBox("do you want to permanently delete this record?", MsgBoxStyle.YesNo) Then Exit Sub
        MsgBox("record deleted")
        clear()
    End Sub

    Private Sub btn_clr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clr.Click
        clear()
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        sql = "  UPDATE `pchase` SET `name`='" + txtname.Text + "',`id`='" + txtnum.Text + "',`raw_material`='" + txtraw.Text + "' WHERE `id`= '" + DataGridView1.CurrentRow.Cells(1).Value + "' "
        ' sql = "update pchase set  name='" + txtname.Text + "', id= '" + txtnum.Text + "',raw_material='" + txtraw.Text + "' where id= '" + DataGridView1.CurrentRow.Cells(1).Value + "'"
        VbConnection.Login(sql)
        MsgBox("record updated")
        clear()
    End Sub

    Private Sub reload()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM pchase"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "pchase")
            DataGridView1.DataSource = ds.Tables("pchase")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub SendToTxtBox(ByVal x As Integer)

        Try
            txtname.Text = DataGridView1.Rows(x).Cells(0).Value
            txtnum.Text = DataGridView1.Rows(x).Cells(1).Value
            txtraw.Text = DataGridView1.Rows(x).Cells(2).Value
        Catch ex As Exception

        End Try

    End Sub

    Sub clear()
        txtname.Text = ""
        txtnum.Text = ""
        txtraw.Text = ""
    End Sub
    Private Sub loadGrid()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from pchase", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
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
    Private Sub txtraw_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtraw.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtraw.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class