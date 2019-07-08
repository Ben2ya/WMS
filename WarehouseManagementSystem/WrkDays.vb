Public Class WrkDays

    Private Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If ComboBox1.Text = "" Then
            MsgBox("Enter the year")
        ElseIf ComboBox2.Text = "" Then
            MsgBox("Enter the month")
        ElseIf txtworkday.Text = "" Then
            MsgBox("Enter the no of working days")

        Else
            sql = "select * from yearset where year='" + ComboBox1.Text + "' and month= '" + ComboBox2.Text + "'"
            If VbConnection.Login(sql) Then
                MsgBox("Already entered")
            Else
                sql = "select * from yearset where month= '" + ComboBox2.Text + "'"
                VbConnection.Login(sql)
                If VbConnection.Login(sql) = False Then
                    If MsgBoxResult.Yes = MsgBox("do you want to update?", MsgBoxStyle.YesNo) Then
                        sql = "update yearset set year='" + ComboBox1.Text + "',month='" + ComboBox2.Text + "',work_day='" + txtworkday.Text + "' where month='" + ComboBox2.Text + "' "
                        VbConnection.RunSQL(sql)
                        MsgBox("record updated")

                    ElseIf MsgBoxResult.No Then
                        sql = "insert into yearset(year,month,work_day)"
                        sql = sql & "values('" + ComboBox1.Text + "','" + ComboBox2.Text + " ','" + txtworkday.Text + "')"
                        VbConnection.RunSQL(sql)
                        MsgBox("Added successfully")
                        ComboBox2.SelectedIndex = -1
                        txtworkday.Text = ""
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub txtworkday_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtworkday.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtworkday.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub frmyear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclear.Click
        clear()
    End Sub
    Sub clear()
        ComboBox1.SelectedIndex = -1
        ComboBox2.SelectedIndex = -1
        txtworkday.Text = ""
    End Sub

    Private Sub txtworkday_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtworkday.TextChanged
        If txtworkday.Text <> "" Then
            Dim monthint As Integer
            If ComboBox2.Text = "JAN" Then
                monthint = 1
            ElseIf ComboBox2.Text = "FEB" Then
                monthint = 2
            ElseIf ComboBox2.Text = "MAR" Then
                monthint = 3
            ElseIf ComboBox2.Text = "APR" Then
                monthint = 4
            ElseIf ComboBox2.Text = "MAY" Then
                monthint = 5
            ElseIf ComboBox2.Text = "JUN" Then
                monthint = 6
            ElseIf ComboBox2.Text = "JUL" Then
                monthint = 7
            ElseIf ComboBox2.Text = "AUG" Then
                monthint = 8
            ElseIf ComboBox2.Text = "SEP" Then
                monthint = 9
            ElseIf ComboBox2.Text = "OCT" Then
                monthint = 10
            ElseIf ComboBox2.Text = "NOV" Then
                monthint = 11
            ElseIf ComboBox2.Text = "DEC" Then
                monthint = 12
            End If
            'Total number of days
            Dim noofdays As Integer = System.DateTime.DaysInMonth(2012, monthint)
            'txtworkday.Text = noofdays
            If txtworkday.Text > noofdays Then
                MessageBox.Show("Not valid")
                txtworkday.Text = 0
                txtworkday.Focus()
            End If
        End If
    End Sub

End Class