Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Public Class salesReport

    Public con As MySqlConnection
    Public cmd As MySqlCommand
    Public rdr As MySqlDataReader


    Sub GenerateReport()
        Dim html = ""

        html += "<head><style>table {border-collapse: collapse;width: 50%;}th, td{text-align: left;padding: 4px;}tr:nth-child(even){background-color: #f2f2f2}th {background-color: #4CAF50;color: white;}</style></head>"
        html += "<table cellpadding='5' cellspacing='0'><tr></td></tr><tr><td><h2>CAR PARKING SYSTEM</h2>Summary Report </td></tr> "
        html += "<tr></table><table border='1'></td></tr>"


        html += "<tr>"
        html += "<th>Sales ID. </th>"
        html += "<th>Order ID</th>"
        html += "<th>Date</th>"
        html += "<th>Purchase ID </th>"
        html += "<th>Purchase Name </th>"
        html += "<th>Invoice IN No. </th>"
        html += "<th>Number of Items</th>"
        html += "<th>Tin Size </th>"
        html += "<th>VAT Net Sale</th>"
        html += "<th>Tax </th>"
        html += "<th>Tax Amount</th>"
        html += "<th>Total amount</th>"
        html += "</tr>"
        Dim search As String
        '  `sales_id`, `order_id`, `date`, `scomp_id`, `scomp_name`, `invoice_in`, `no_of_items`, `tin_size`, `vatnet_sale`, `tax`, `tax_amt`, `tot_amt`

        search = "SELECT * FROM `tbl_insales` "
        
        cmd = New MySqlCommand
        rdr = cmd.ExecuteReader()
        While rdr.Read()
            html += "<tr>"
            html += "<td class='boldCell'>" + rdr.GetString(0) + ".</td>"
            html += "<td class='boldCell'>" + rdr.GetString(1) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(2) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(3) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(4) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(5) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(6) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(7) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(8) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(9) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(10) + "</td>"
            html += "<td class='boldCell'>" + rdr.GetString(11) + "</td>"
            html += "</tr>"
        End While
        con.Close()
        con.Open()
        html += "</table>"
        WebBrowser1.DocumentText = html
  
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()
        Environment.Exit(0)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        WebBrowser1.ShowPrintDialog()

    End Sub

    Private Sub PrintPreviewToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PrintPreviewToolStripMenuItem.Click
        WebBrowser1.ShowPrintPreviewDialog()

    End Sub
    Private Sub salesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateReport()
    End Sub
End Class
