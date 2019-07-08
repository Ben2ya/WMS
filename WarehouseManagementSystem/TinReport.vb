Public Class TinReport

    Private Sub frmtinreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        connect()
        zero()
        txt13.Text = 0
        txt14.Text = 0
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim qty1 = 0, qty2 = 0, qty3 = 0, qty4 = 0, qty5 = 0, qty6 = 0, qty7 = 0, qty8 = 0, qty9 = 0
        sql = "select * from tbl_stock1 where goods='Electrolytic tin plate' and compno='" & ComboBox1.Text & "'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty1 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='Tin solder'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty2 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='zinc chloride'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty3 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='tin lids'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty4 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='cashew shell cake'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty5 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='oil'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty6 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='cotton waste'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty7 = VbConnection.Login(2)
        End If

        sql = "select * from tbl_stock1 where goods='tin scrape'"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty8 = VbConnection.Login(2).Value
        End If

        sql = "select * from tbl_stock1 where goods='gas cylinder'"
       VbConnection.Login(sql)
        If VbConnection.Login(sql) = False Then
            qty9 = VbConnection.Login(2).Value
        End If
        If txtplate.Text > qty1 Then
            MsgBox("Electrolytic tin plate is less")
        ElseIf txtsolder.Text > qty2 Then
            MsgBox("Tin Solder is less")
        ElseIf txtzinc.Text > qty3 Then
            MsgBox("Zinc Chloride is less")
        ElseIf txtlids.Text > qty4 Then
            MsgBox("Tin Lids is less")
        ElseIf txtshell.Text > qty5 Then
            MsgBox("Cashew shell cake is less")
        ElseIf txtoil.Text > qty6 Then
            MsgBox("Oil is less")
        ElseIf txtcotton.Text > qty7 Then
            MsgBox("Cotton waste is less")
        ElseIf txtscrape.Text > qty8 Then
            MsgBox("Tin Scrape is less")
        ElseIf txtgas.Text > qty9 Then
            MsgBox("Gas Cylinder  is less")
        Else
            sql = "update tbl_stock1 set quantity=quantity - '" & txtplate.Text & "' where compno='" & ComboBox1.Text & "' "
            VbConnection.Login(sql)

            sql = "update tbl_stock1 set quantity=quantity - '" & txtsolder.Text & "' where goods='Tin solder' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtzinc.Text & "' where goods='Zinc chloride' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtlids.Text & "' where goods='Tin lids' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtshell.Text & "' where goods='Cashew shell cake' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtoil.Text & "' where goods='oil' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtcotton.Text & "' where goods='Cotton waste' "
            VbConnection.Login(sql)
            sql = "update tbl_stock1 set quantity=quantity - '" & txtscrape.Text & "' where goods='Tin scrape' "
            VbConnection.Login(sql)
            Stock.loadgrid1()
            MsgBox(" Deducted successfully")
        End If
        zero()
    End Sub
    Sub zero()
        txtplate.Text = 0
        txtsolder.Text = 0
        txtzinc.Text = 0
        txtshell.Text = 0
        txtlids.Text = 0
        txtoil.Text = 0
        txtcotton.Text = 0
        txtscrape.Text = 0
        txtgas.Text = 0
        txt13.Text = 0
        txt14.Text = 0
        ComboBox1.Text = ""
    End Sub


    Private Sub txtplate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtplate.KeyPress
        If ComboBox1.Text = "" Then
            MsgBox("Enter any of the company number")
        End If
        If Char.IsLetter(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtplate.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtsolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtsolder.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtsolder.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtzinc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtzinc.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtzinc.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtlids_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtlids.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtlids.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtshell_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtshell.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtshell.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub


    Private Sub txtoil_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtoil.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtoil.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtcotton_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcotton.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtcotton.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtscrape_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtscrape.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtscrape.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtgas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtgas.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        Else
            If Len(txtgas.Text) < 25 Or Char.IsControl(e.KeyChar) Then
                e.Handled = False
            Else
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        sql = "select * from tbl_tinsize"
        VbConnection.Login(sql)
        If VbConnection.Login(sql) = True Then
            sql = "insert into tbl_tinsize(tinsize13,tinsize14)values('" & txt13.Text & "','" & txt14.Text & "')"
            VbConnection.Login(sql)
        Else
            sql = "update tbl_tinsize set tinsize13=tinsize13+'" & txt13.Text & "',tinsize14=tinsize14+'" & txt14.Text & "'"
            VbConnection.Login(sql)
            MsgBox("Added successfully")
        End If
        txt13.Text = 0
        txt14.Text = 0
    End Sub
   
End Class