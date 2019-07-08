Imports MySql.Data.MySqlClient
Public Class Salary
    Dim COMMAND As MySqlCommand
    Sub empno()
        ComboBox1.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from empinfo "
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                Dim empno = reader.GetString("empno")
                ComboBox1.Items.Add(empno)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub year()


        ComboBox2.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from yearset "
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                Dim year = reader.GetString("year")
                ComboBox2.Items.Add(year)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub month()
        ComboBox3.Items.Clear()
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select * from yearset "
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                Dim month = reader.GetString("month")
                ComboBox3.Items.Add(month)
            End While


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub frmsalary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtdayattended.Enabled = False
        connect()
        empno()
        year()
        month()
        clear()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = "Select empinfo.empno, empinfo.name, bsal.emp_sal from empinfo, bsal where empinfo.empno = bsal.empno and '" + ComboBox1.Text + "' "
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                txtname.Text = reader.GetString("name")
                txtsal.Text = reader.GetString("emp_sal")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        txtdayattended.Enabled = True

        Dim reader As MySqlDataReader
        Try
            con.Close()
            con.Open()
            Dim query As String
            query = " select yearset.work_day from yearset where  month ='" + ComboBox3.Text + "'"
            COMMAND = New MySqlCommand(query, con)
            reader = COMMAND.ExecuteReader
            While reader.Read
                txtworkday.Text = reader.GetString("work_day")
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub txtdayattended_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdayattended.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtdayattended.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If (txtdayattended.Text > txtworkday.Text) Then
            txtdayattended.Text = ""
            MsgBox(" No of days attended must be less than no of working days")
        Else
            Dim bsal, workdays, attendance
            bsal = txtsal.Text
            workdays = txtworkday.Text
            attendance = txtdayattended.Text
            Dim netsal = (bsal * attendance) / workdays
            txtnetsal.Text = netsal
        End If
    End Sub

    Private Sub btninsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btninsert.Click
        If ComboBox1.Text = "" Then
            MsgBox(" enter employee number")
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Enter year")
        ElseIf ComboBox3.Text = "" Then
            MsgBox("Enter month")
        ElseIf txtdayattended.Text = "" Then
            MsgBox("Enter no of days attended")
        Else
            sql = "select * from salary where year='" + ComboBox2.Text + "' and month= '" + ComboBox3.Text + "'"
            VbConnection.Login(sql)
            If VbConnection.Login(sql) = True Then
                MsgBox("Salary already paid")
            Else

                sql = "insert into salary(empno,year,month,work_day,day_attended,net_sal)"
                sql = sql & " values('" + ComboBox1.Text + "','" + ComboBox2.Text + "','" + ComboBox3.Text + "','" + txtworkday.Text + "','" + txtdayattended.Text + "','" + txtnetsal.Text + "' )"
                VbConnection.Login(sql)
                MsgBox("Added successfully")
            End If
        End If

        clear()
    End Sub
    Sub clear()
        ComboBox1.SelectedIndex = -1
        txtname.Text = ""
        txtsal.Text = ""
        ComboBox2.SelectedIndex = -1
        ComboBox3.SelectedIndex = -1
        txtworkday.Text = ""
        txtdayattended.Text = ""
        txtnetsal.Text = ""
    End Sub
    Private Sub btnclr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclr.Click
        clear()

    End Sub


End Class