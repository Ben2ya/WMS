Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class NPurchase
    Public COMMAND As MySqlCommand
    Dim adapter As New MySqlDataAdapter
    Private Sub frmpurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        loadcheck()
        check()
        reload()
        compname()
        reset()
        loadGrid()
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
            reader = Command.ExecuteReader
            While reader.Read
                Dim empno = reader.GetString("name")
                ComboBox1.Items.Add(empno)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If txtno.Text = "" Then
            MsgBox("enter number")
        ElseIf txtnum.Text = "" Then
            MsgBox("enter cmpid")
        ElseIf txtinvoiceno.Text = "" Then
            MsgBox("enter invoice number")
        ElseIf txtraw.Text = "" Then
            MsgBox("enter discription of goods")
        ElseIf txtqty.Text = "" Then
            MsgBox("enter quantity")
        ElseIf txtamt.Text = "" Then
            MsgBox("enter amount")
        ElseIf txttax.Text = "" Then
            MsgBox("enter tax")
        ElseIf txttaxamt.Text = "" Then
            MsgBox("enter tax amount")
        ElseIf txttotamt.Text = "" Then
            MsgBox("enter total amount")
        Else
            sql = "insert into tbl_purchase(purchaseid,compno,date,invoice_no,invoice_date,disc_goods,quantity,amt,taxper,taxamt,total)"
            sql = sql & "values('" & txtno.Text & "','" & txtnum.Text & "','" & DateTimePicker1.Value & "','" & txtinvoiceno.Text & "','" & DateTimePicker2.Value & "','" & txtraw.Text & "','" & txtqty.Text & "','" & txtamt.Text & "','" & txttax.Text & "','" & txttaxamt.Text & "','" & txttotamt.Text & "')"
            VbConnection.Login(sql)

            sql = "select * from tbl_stock1 where compno='" & txtnum.Text & "' and goods='" & txtraw.Text & "'"
            VbConnection.Login(sql)
            If VbConnection.Login(sql) = False Then
                'If IsDBNull(rs(1).Value) = True Then
                sql = "update tbl_stock1 set quantity=quantity + '" & txtqty.Text & "' where compno='" & txtnum.Text & "' and goods='" & txtraw.Text & "'"
                VbConnection.Login(sql)
                MsgBox("Added successfully")
            Else
                sql = "insert into tbl_stock1(compno,goods,quantity)"
                sql = sql & "values('" & txtnum.Text & "','" & txtraw.Text & "','" & txtqty.Text & "')"
                VbConnection.Login(sql)
                MsgBox("Added successfully")
                ' MsgBox("record updated")

            End If
        End If
        loadcheck()
        reset()

    End Sub


    Sub loadcheck()
        sql = "select * from tbl_purchase where date= '" & DateTimePicker1.Value & "' and compno='" & txtnum.Text & "' "
       VbConnection.Login(sql)
        DataGridView1.Rows.Clear()
        Dim i
        i = 0
     
    End Sub


    Private Sub reload()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM tbl_purchase"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "tbl_purchase")
            DataGridView1.DataSource = ds.Tables("tbl_purchase")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SendToTxtBox(ByVal x As Integer)

        Try
            txtno.Text = DataGridView1.Rows(x).Cells(0).Value
            DateTimePicker1.Value = DataGridView1.Rows(x).Cells(1).Value
            txtnum.Text = DataGridView1.Rows(x).Cells(2).Value
            txtinvoiceno.Text = DataGridView1.Rows(x).Cells(3).Value
            DateTimePicker2.Value = DataGridView1.Rows(x).Cells(4).Value
            txtraw.Text = DataGridView1.Rows(x).Cells(5).Value
            txtqty.Text = DataGridView1.Rows(x).Cells(6).Value
            txtamt.Text = DataGridView1.Rows(x).Cells(7).Value
            txttax.Text = DataGridView1.Rows(x).Cells(8).Value
            txttaxamt.Text = DataGridView1.Rows(x).Cells(9).Value
            txttotamt.Text = DataGridView1.Rows(x).Cells(10).Value
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadGrid()
        con.Close()
        con.Open()
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from tbl_purchase", con)
        adapter.Fill(rs)
        DataGridView1.DataSource = rs
       
    End Sub
    
    

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sql = "update tbl_purchase set purchaseid='" & txtno.Text & "',compno='" & txtnum.Text & "','" & DateTimePicker1.Value & "',invoice_no='" & txtinvoiceno.Text & "',invoice_date='" & DateTimePicker2.Value & "', disc_goods='" & txtraw.Text & "',quantity='" & txtqty.Text & "',amt='" & txtamt.Text & "',taxper='" & txttax.Text & "',taxamt='" & txttaxamt.Text & "',total='" & txttotamt.Text & "' where purchaseid='" & DataGridView1.CurrentRow.Cells(0).Value & "'"
        VbConnection.Login(sql)
        MsgBox("record updated")
        loadcheck()

    End Sub
    Sub check()
        Dim j
        j = 100
        txtno.Text = j
        sql = "select max(purchaseid) from tbl_purchase"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            j = VbConnection.Login(sql).Value
            j = j + 1
            txtno.Text = j
        End If

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = " Select * from pchase where name='" & ComboBox1.Text & "'"
            COMMAND = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                txtnum.Text = reader.GetString("id")
                txtraw.Text = reader.GetString("raw_material")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        reset()
        check()
    End Sub

    Sub reset()
        ComboBox1.SelectedIndex = -1
        txtnum.Text = ""
        txtraw.Text = ""
        txtinvoiceno.Text = ""
        txtamt.Text = ""
        txttax.Text = ""
        txtqty.Text = ""
        txttaxamt.Text = ""
        txttotamt.Text = ""
    End Sub


    Private Sub txttax_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.TextChanged
        Dim i As Double
        i = Val(txttaxamt.Text)
        i = Val(txtamt.Text) * (Val(txttax.Text) / 100)
        txttaxamt.Text = i
        Dim a As Double
        a = Val(txttotamt.Text)
        a = Val(txtamt.Text) + Val(txttaxamt.Text)
        txttotamt.Text = a
    End Sub

    Private Sub txtinvoiceno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtinvoiceno.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtinvoiceno.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
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

    Private Sub txtamt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtamt.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtamt.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txttax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txttax.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txttax.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        SendToTxtBox(e.RowIndex)
    End Sub
End Class