Imports MySql.Data.MySqlClient

Public Class salesReport


    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        ' Me.Close()
        ' Environment.Exit(0)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        ' WebBrowser1.ShowPrintDialog()

    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click


    End Sub
    Private Sub salesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  GenerateReport()
        ' Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs)

    End Sub
End Class
