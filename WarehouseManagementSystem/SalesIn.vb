Imports MySql.Data.MySqlClient
Public Class SalesIn

    Public Command As New MySqlCommand
    Public reader As MySqlDataReader
    Public vno As String
    Sub orderid()


        cmborder.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from tbl_custorder1 where status=0"""
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                Dim order_id = reader.GetString("order_id")
                cmborder.Items.Add(order_id)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmsales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        ' orderid()
        '  checkID()
        ' loadid()
        btnadd.Enabled = False
    End Sub

    Private Sub cmborder_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmborder.SelectedIndexChanged
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = " Select scomp_id from tbl_custorder1 where order_id='" & cmborder.Text & "'"
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                txtnum.Text = reader.GetString("scomp_id")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim query As String
            query = " Select scomp_name from tbl_scomp where scomp_id='" & txtnum.Text & "'"
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                txtname.Text = reader.GetString("scomp_name")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim query As String
            query = " Select tinsize_ord from tbl_custorder1 where order_id='" & cmborder.Text & "'"
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                txtsize.Text = reader.GetString("tinsize_ord")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            Dim query As String
            query = " Select no_oftin_ordered from tbl_custorder1 where order_id='" & cmborder.Text & "'"
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                txtnotin.Text = reader.GetString("no_oftin_ordered")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim i As Double
        i = Val(txtvatnet.Text)
        i = Val(txtrate.Text) * Val(txtnotin.Text)
        txtvatnet.Text = i
    End Sub
    Sub checkID()
        Dim cmd As New MySqlCommand
        Dim number As Integer
        cmd.CommandText = "select max(sales_id) from tbl_sales"
        If IsDBNull(cmd.ExecuteScalar) Then
            number = 100
            txtid.Text = number
        End If
        cmd.Dispose()

    End Sub

    Sub loadid()
        Dim id

        Dim cmd As New MySqlCommand
        cmd.CommandText = "select MAX(cast(SUBSTRING(invoice,6,len(invoice))+1 as int ))from sales "
        If IsDBNull(cmd.ExecuteScalar) Then
            txtinv.Text = "INKAR1"
        Else
            If IsDBNull(cmd.ExecuteScalar) = False Then
                id = IsDBNull(cmd.ExecuteScalar)
                id = "INKAR" & id
                txtinv.Text = id
            End If
            cmd.Dispose()

        End If
    End Sub



    Private Sub txtsize_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsize.TextChanged

        Try
            Dim query As String
            If txtsize.Text = 13 Then

                query = " Select tin13 from tinrate "
                Command = New MySqlCommand(query, con)
                reader = Command.ExecuteReader
                While reader.Read
                    txtrate.Text = reader.GetString("tin13")
                End While
            Else
                query = " Select tin14 from tinrate "
                Command = New MySqlCommand(query, con)
                reader = Command.ExecuteReader
                While reader.Read
                    txtrate.Text = reader.GetString("tin14")
                End While
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txttax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttax.TextChanged
        Dim i As Double
        If txttax.Text = "" Then
            MsgBox("Enter tax")
        Else
            i = Val(txt5tax.Text)
            i = Val(txtvatnet.Text) * Val(txttax.Text / 100)
            txt5tax.Text = i
            Dim a As Double
            a = Val(txttot.Text)
            a = Val(txt5tax.Text) + Val(txtvatnet.Text)
            txttot.Text = a
        End If
    End Sub


    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        Dim qty1 = 0, qty2 = 0
        Dim query As String

        Try
            query = "select tinsize13 from tbl_tinsize "
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                qty1 = reader.GetString("tinsize13")
            End While

            query = "select tinsize14 from tbl_tinsize "
            Command = New MySqlCommand(query, con)
            reader = Command.ExecuteReader
            While reader.Read
                qty2 = reader.GetString("tinsize14")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If txtnotin.Text > qty1 Then
            MsgBox(" Tins of size13 is less in number")
            clear()
        ElseIf txtnotin.Text > qty2 Then

            MsgBox(" Tins of size14 is less in number")
            clear()
        ElseIf txttax.Text = "" Then
            MsgBox("Enter Tax")
        ElseIf TextBox1.Text = "" Then
            MsgBox("Enter vehicle number")
        Else
            vno = TextBox1.Text
            sql = "insert into tbl_sales(sales_id,order_id,date,scomp_id,scomp_name,invoice_in,tin_size,no_of_items,vatnet_sale,tax,tax_amt,tot_amt)"
            sql = sql & "values('" & txtid.Text & "','" & cmborder.Text & "','" & DateTimePicker1.Value & "','" & txtnum.Text & " ','" & txtname.Text & "','" & txtinv.Text & "','" & txtsize.Text & "','" & txtnotin.Text & "','" & txtvatnet.Text & "','" & txttax.Text & "','" & txt5tax.Text & "','" & txttot.Text & "')"
            VbConnection.Login(sql)
            sql = "update tbl_custorder1 set status=1 where order_id='" & cmborder.Text & "'"
            VbConnection.Login(sql)
            If txtsize.Text = 13 Then
                sql = "update tbl_tinsize set tinsize13=tinsize13 - '" & txtnotin.Text & "'"
                VbConnection.Login(sql)
                clear()

                MsgBox("tins sold")

            Else
                sql = "update tbl_tinsize set tinsize14=tinsize14 - '" & txtnotin.Text & "'"
                VbConnection.Login(sql)
                clear()
                MsgBox("tins sold")

            End If
        End If


    End Sub
    Sub clear()
        checkID()
        txtnum.Text = ""
        txtname.Text = ""

        txtnotin.Text = ""

        txtrate.Text = ""
        txtvatnet.Text = ""

        txt5tax.Text = ""
        txttot.Text = ""
        TextBox1.Text = ""
        cmborder.SelectedIndex = -1
        btnadd.Enabled = False
    End Sub


    Private Sub cmborder_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmborder.TextChanged
        btnadd.Enabled = True
    End Sub

    Private Sub btncl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncl.Click
        clear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'salesReport.MdiParent = MainPage
        salesReport.Show()

        '    If vno = "" Then
        'MsgBox("select record to print")

        '        Else

        '        Dim Sql = "select * from settings"
        '       VbConnection.Login(Sql)
        '      If VbConnection.Login(Sql) = False Then
        'Server = rs(0).Value
        '    Database = rs(1).Value
        '   User = rs(2).Value
        '        Password = rs(3).Value
        '       End If
        '      Dim rpt As New salesReport
        '     rpt.DataSourceConnections.Item(0).SetConnection(Server, Database, User, Password)
        '    rpt.DataSourceConnections.Item(0).SetLogon(User, Password)
        '   'rpt.RecordSelectionFormula = " {command.receiptNo}='" & txtrno.Text & "'"
        '  rpt.SetParameterValue("sid", id1)
        ' rpt.SetParameterValue("vno", vno)
        'salesReport.Text = "RECEIPT"
        '       salesReport.CrystalReportViewer1.ReportSource = rpt
        '       salesReport.CrystalReportViewer1.Refresh()
        '      salesReport.ShowDialog()
        '     End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class