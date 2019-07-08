Imports System.Data.SqlClient
Public Class MainPage

    Private Sub ACCOUNTCONFIGURATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ACCOUNTCONFIGURATIONToolStripMenuItem.Click
        Registration.MdiParent = Me
        Registration.Show()
    End Sub

    Private Sub MainPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub EMPLOYEEDETAILSToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EMPLOYEEDETAILSToolStripMenuItem1.Click
        EmpDetails.MdiParent = Me
        EmpDetails.Show()
    End Sub
    Private Sub PURCHASEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PURCHASEToolStripMenuItem.Click
        CPurchase.MdiParent = Me
        CPurchase.Show()
    End Sub

    Private Sub SALESToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SALESToolStripMenuItem1.Click
        Sales.MdiParent = Me
        Sales.Show()
    End Sub
    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Salary.MdiParent = Me
        salary.Show()
    End Sub

    Private Sub WORKDAYSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WORKDAYSToolStripMenuItem.Click
        WrkDays.MdiParent = Me
        WrkDays.Show()
    End Sub
    Private Sub TINCOSTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TINCOSTToolStripMenuItem.Click
        TinCost.MdiParent = Me
        tincost.Show()
    End Sub
    Private Sub BACKUPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BACKUPToolStripMenuItem.Click
        DbBackup.MdiParent = Me
        DbBackup.Show()
    End Sub
    Private Sub EXITToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem.Click
        If MsgBoxResult.No = MsgBox("do you want to exit?", MsgBoxStyle.YesNo) Then Exit Sub
        Application.Exit()
    End Sub
    Private Sub NEWSTOCKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEWSTOCKToolStripMenuItem.Click
        NPurchase.MdiParent = Me
        NPurchase.Show()
    End Sub
    Private Sub RAWMATERIALSTOCKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RAWMATERIALSTOCKToolStripMenuItem.Click
        stock.MdiParent = Me
        stock.Show()
    End Sub
    Private Sub TINSTOCKToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TINSTOCKToolStripMenuItem.Click
        TinStock.MdiParent = Me
        tinstock.Show()
    End Sub
    Private Sub TINREPORTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TINREPORTSToolStripMenuItem.Click
        TinReport.MdiParent = Me
        tinreport.Show()
    End Sub
    Private Sub CUSTOMERORDERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CUSTOMERORDERToolStripMenuItem.Click
        CustomerOrder.MdiParent = Me
        CustomerOrder.Show()
    End Sub
    Private Sub INSALESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSALESToolStripMenuItem.Click
        Salesin.MdiParent = Me
        Salesin.Show()
    End Sub
    Private Sub OUTSALESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OUTSALESToolStripMenuItem.Click
        SalesOut.MdiParent = Me
        SalesOut.Show()
    End Sub
    Private Sub HELPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HELPToolStripMenuItem.Click
        System.Diagnostics.Process.Start("C:\Users\bened\Documents\311.docx")
    End Sub

    Private Sub EXITToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EXITToolStripMenuItem1.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If MsgBoxResult.No = MsgBox("do you want to exit?", MsgBoxStyle.YesNo) Then Exit Sub
        Application.Exit()
    End Sub


End Class