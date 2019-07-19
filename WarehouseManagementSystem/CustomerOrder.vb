Imports MySql.Data.MySqlClient
Public Class CustomerOrder

    Dim Tsize As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtorderid.Text = "" Then
            MsgBox("enter number")
        ElseIf ComboBox2.Text = "" Then
            MsgBox("enter empno")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("enter company name")
        ElseIf txtcompid.Text = "" Then
            MsgBox("enter company id")
        ElseIf txtqty.Text = "" Then
            MsgBox("enter quantity")


        Else
            tin_size()
            Dim sql As String = "insert into tbl_custorder1(order_id,empno,scomp_id,order_date,delivery_date,tinsize_ord,no_oftin_ordered,advance_paid,status)"
            sql = sql & "values('" & txtorderid.Text & "','" & ComboBox2.Text & "','" & txtcompid.Text & "','" & DateTimePicker1.Value & "','" & DateTimePicker2.Value & "','" & Tsize & "' ,'" & txtqty.Text & "',0,0)"
            VbConnection.Login(sql)
            MsgBox("Added successfully")
        End If
        clear()

    End Sub

    Sub tin_size()
        If RadioButton1.Checked = True Then
            Tsize = 13
        Else
            Tsize = 14
        End If
    End Sub
  

    Private Sub reload()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM tbl_custorder1"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "tbl_custorder1")
            DataGridView1.DataSource = ds.Tables("user")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SendToTxtBox(ByVal x As Integer)

        Try
            txtorderid.Text = DataGridView1.CurrentRow.Cells(0).Value
            ComboBox2.Text = DataGridView1.CurrentRow.Cells(1).Value
            txtcompid.Text = DataGridView1.CurrentRow.Cells(2).Value
            ComboBox1.Text = DataGridView1.CurrentRow.Cells(3).Value
            DateTimePicker1.Value = DataGridView1.CurrentRow.Cells(4).Value
            DateTimePicker2.Value = DataGridView1.CurrentRow.Cells(5).Value
            If DataGridView1.CurrentRow.Cells(6).Value = 13 Then
                RadioButton1.Checked = True
            Else
                RadioButton2.Checked = True
            End If
            txtqty.Text = DataGridView1.CurrentRow.Cells(7).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadGrid()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from tbl_custorder1 where status=0", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
    End Sub



    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Button2.Enabled = True
        Button3.Enabled = True
        SendToTxtBox(e.RowIndex)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tin_size()
        sql = "update tbl_custorder1 set order_id='" + txtorderid.Text + "',empno='" + ComboBox2.Text + "',scomp_id='" + txtcompid.Text + "','" + DateTimePicker1.Value + "',delivery_date='" + DateTimePicker2.Value + "',tinsize_ordered='" + Tsize + "',no_oftin_ordered='" + txtqty.Text + "' where order_id='" + DataGridView1.CurrentRow.Cells(0).Value + "'"
        VbConnection.Login(sql)
        MsgBox("record updated")

        clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        sql = "delete from tbl_custorder1 where order_id ='" + DataGridView1.CurrentRow.Cells(0).Value + "'"
        VbConnection.Login(sql)
        MsgBox("record deleted")

        clear()
    End Sub
    Sub clear()
        checkID()
        ComboBox2.SelectedIndex = -1
        ComboBox1.SelectedIndex = -1
        txtcompid.Text = ""
        txtqty.Text = ""

    End Sub
    Sub checkID()
        Dim cmd As New MySqlCommand
        Dim number As Integer
        cmd.CommandText = "select max(order_id) from tbl_custorder1"
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 100
            txtorderid.Text = number
        End If
        cmd.Dispose()

    End Sub
    Dim COMMAND As New MySqlCommand
    Sub empno()
        ComboBox2.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from empinfo "
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                Dim empno = reader.GetString("empno")
                ComboBox2.Items.Add(empno)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Sub compname()
        ComboBox1.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from pchase "
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                Dim name = reader.GetString("name")
                ComboBox1.Items.Add(name)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clear()
    End Sub


    Private Sub customer_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        reload()
        loadgrid()
        '  empno()
        ' compname()
        ' checkID()
        Button2.Enabled = False
        Button3.Enabled = False

    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = " select id from pchase where name='" + ComboBox1.Text + "'"
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                txtcompid.Text = reader.GetString("id")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub txtqty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtqty.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtqty.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtqty_TextChanged(sender As Object, e As EventArgs) Handles txtqty.TextChanged

    End Sub
End Class