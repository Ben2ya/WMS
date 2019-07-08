Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class EmpDetails

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click

        If txtnum.Text = "" Then
            MsgBox("enter the emp number ")
        ElseIf txtname.Text = "" Then
            MsgBox("enter emp name")
        ElseIf txtadd.Text = "" Then
            MsgBox("enter the address")
        ElseIf txtqual.Text = "" Then
            MsgBox("enter the qualification")
        ElseIf txtph.Text = "" Then
            MsgBox("enter phone number")
        ElseIf txtsal.Text = "" Then
            MsgBox("enter salary")
        ElseIf ComboBox1.Text = "" Then
            MsgBox("enter gender")
        ElseIf txtdes.Text = "" Then
            MsgBox("enter the designation")
        ElseIf txtwe.Text = "" Then
            MsgBox("enter the work experience")
        ElseIf txtphoto.Text = "" Then
            MsgBox("browse the photo")
        ElseIf Len(txtph.Text) < 10 Then
            MsgBox("Enter valid phone number")
        Else

            Dim years As Long

            years = DateDiff("yyyy", DateTimePicker1.Value, DateTimePicker2.Value)
            If years < 18 Then
                MsgBox("CHILD LABOUR!!!!?? :(")

                con.Close()
                con.Open()
            Else


                sql = "INSERT INTO `empinfo`(`empno`, `name`, `address`, `dob`, `qualification`, `phone_number`, `gender`, `doj`, `designation`, `work_experience`, `photo`)"
                sql = sql + "values('" + txtnum.Text + "','" + txtname.Text + " ','" + txtadd.Text + "','" + DateTimePicker1.Value + "','" + txtqual.Text + "','" + txtph.Text + "','" + ComboBox1.Text + "','" + DateTimePicker2.Value + "','" + txtdes.Text + "','" + txtwe.Text + "','" + txtphoto.Text + "' )"
                VbConnection.RunSQL(sql)
                sql = "insert into bsal(empno,emp_sal)"
                sql = sql + "values('" + txtnum.Text + "','" + txtsal.Text + "')"
                VbConnection.RunSQL(sql)
                MsgBox("Added successfully")
                clear()
            End If
        End If
        checkID()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        With Me.OpenFileDialog1.Filter = "all files | *.*"
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                txtphoto.Text = OpenFileDialog1.FileName
            End If
        End With

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        sql = "  UPDATE `empinfo` SET `empno`='" + txtnum.Text + "',`name`='" + txtname.Text + "',`address`='" + txtadd.Text + "',`dob`='" + DateTimePicker1.Value + "',`qualification`='" + txtqual.Text + "',`phone_number`='" + txtph.Text + "',`gender`='" + ComboBox1.Text + "',`doj`='" + DateTimePicker2.Value + "',`designation`='" + txtdes.Text + "',`work_experience`='" + txtwe.Text + "',`photo`='" + txtphoto.Text + "' WHERE empno='" + DataGridView.CurrentRow.Cells(0).Value + "'"
        VbConnection.RunSQL(sql)
        MsgBox("record updated")
        clear()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        sql = "delete from empinfo where empno = '" + DataGridView.CurrentRow.Cells(0).Value + "'"
        VbConnection.RunSQL(sql)
        If MsgBoxResult.No = MsgBox("do you want to permanently delete this record?", MsgBoxStyle.YesNo) Then Exit Sub
        MsgBox("record deleted")
        clear()

    End Sub

    Private Sub clear()
        txtname.Text = ""
        txtadd.Text = ""
        txtqual.Text = ""
        txtph.Text = ""
        ComboBox1.SelectedIndex = -1
        txtdes.Text = ""
        txtwe.Text = ""
        txtphoto.Text = ""
        txtsal.Text = ""
        txtname.Focus()

    End Sub

    Private Sub loadgrid()
        DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Dim adapter As New MySqlDataAdapter("select * from empinfo", con)
        adapter.Fill(rs)
        DataGridView.DataSource = rs

        ' DataGridView1.Rows.Clear()
        Dim i
        i = 0


        'sql = " select * from bsal where empno='" + DataGridView1.Item(0, i).Value + "'"




    End Sub
    Private Sub checkID()
        '  Dim con As New MySqlConnection
        con.Close()
        con.Open()
        Dim cmd As New MySqlCommand
        Dim read As MySqlDataReader
        Dim autoId As Single
        sql = "select count(*) as empno from empinfo"
        VbConnection.RunSQL(sql)

        read = cmd.ExecuteReader
        While read.Read
            autoId = Val(read.Item("empno").ToString) + 1
        End While
        Select Case Len(Trim(autoId))
            Case 1 : txtnum.Text = "WHS000" + Trim(Str(autoId)) + Format(Now, "ddMMyyyyhhmmss")
            Case 1 : txtnum.Text = "WHS00" + Trim(Str(autoId)) + Format(Now, "ddMMyyyyhhmmss")
            Case 1 : txtnum.Text = "WHS0" + Trim(Str(autoId)) + Format(Now, "ddMMyyyyhhmmss")
        End Select


    End Sub

    Private Sub Refresher()
        Try
            con.Close()
            con.Open()
            sql = "SELECT * FROM empinfo"
            Dim search As New MySqlDataAdapter(sql, con)
            Dim ds As New DataSet
            search.Fill(ds, "empinfo")
            DataGridView.DataSource = ds.Tables("empinfo")
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellClick
        SendTo(e.RowIndex)
        loadgrid()
        Refresher()
    End Sub

    Private Sub SendTo(ByVal z As Integer)

        Try
            txtnum.Text = DataGridView.Rows(z).Cells(0).Value
            txtname.Text = DataGridView.Rows(z).Cells(1).Value
            txtadd.Text = DataGridView.Rows(z).Cells(2).Value
            DateTimePicker1.Text = DataGridView.Rows(z).Cells(3).Value
            txtqual.Text = DataGridView.Rows(z).Cells(4).Value
            txtph.Text = DataGridView.Rows(z).Cells(5).Value
            ComboBox1.Text = DataGridView.Rows(z).Cells(6).Value
            DateTimePicker2.Text = DataGridView.Rows(z).Cells(7).Value
            txtdes.Text = DataGridView.Rows(z).Cells(8).Value
            txtwe.Text = DataGridView.Rows(z).Cells(9).Value
            txtphoto.Text = DataGridView.Rows(z).Cells(10).Value
            txtsal.Text = DataGridView.Rows(z).Cells(11).Value
        Catch ex As Exception

        End Try

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

    Private Sub txtph_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtph.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtph.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtsal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsal.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtsal.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtwe_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtwe.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtwe.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtdes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdes.KeyPress
        If Char.IsDigit(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtdes.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        clear()

    End Sub

    Private Sub EmpDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        loadgrid()
        Refresher()
    End Sub

    Private Sub txtphoto_TextChanged(sender As Object, e As EventArgs) Handles txtphoto.TextChanged
        emppic1.ImageLocation = txtphoto.Text
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub txtnum_TextChanged(sender As Object, e As EventArgs) Handles txtnum.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView.CellContentClick

    End Sub

    Private Sub ButtonGN_Click(sender As Object, e As EventArgs) Handles ButtonGN.Click
        checkID()
    End Sub
End Class