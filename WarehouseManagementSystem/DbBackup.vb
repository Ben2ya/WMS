Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient
Public Class DbBackup
    Dim sqlcon As New SqlConnection
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ' First create a FolderBrowserDialog object
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        ' Then use the following code to create the Dialog window
        ' Change the .SelectedPath property to the default location
        With FolderBrowserDialog1
            ' Desktop is the root folder in the dialog.
            .RootFolder = Environment.SpecialFolder.Desktop
            ' Select the C:\Windows directory on entry.
            .SelectedPath = "c:\windows\Backup"
            ' Prompt the user with a custom message.
            .Description = "Select the source directory"
            If .ShowDialog = DialogResult.OK Then
                ' Display the selected folder if the user clicked on the OK button.
                MessageBox.Show(.SelectedPath)
                Me.txtBackupFile.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Response As Integer
        If Me.txtBackupFile.Text = "" Then
            MessageBox.Show("Select Folder For Database Backup.", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Response = MessageBox.Show("Backup Database", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Response = vbYes Then
            prgLongProcess.Visible = True
            ' Get ready.
            prgLongProcess.Value = 0
            prgLongProcess.Style = ProgressBarStyle.Marquee
            ' Start the worker.
            bgrLongProcess.WorkerReportsProgress = True
            bgrLongProcess.WorkerSupportsCancellation = True
            bgrLongProcess.RunWorkerAsync()
        End If
    End Sub
    Private Sub bgrLongProcess_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgrLongProcess.DoWork
        Try
            'Dim Response As Integer
            SetConnection()
            Dim BackUpCmd As New MySqlCommand("BACKUP DATABASE warehousesystem TO disk ='" + txtBackupFile.Text + "" + "\warehousesystem.bak'", con)
            ' Dim BackUpCmd As New MySqlCommand("sp_BackUp " + "'" + Trim(Me.txtBackupFile.Text) + "" + "\warehousesystem.BAK'", con)
            BackUpCmd.ExecuteNonQuery()
            MessageBox.Show("Backup Completed..", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch er As System.Exception
            MsgBox(er.Message)
            ' MessageBox.Show("Selected Drive is not Found ! Please Select Other Drive", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try
    End Sub
    Private Sub bgrLongProcess_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) _
     Handles bgrLongProcess.RunWorkerCompleted
        Try
            prgLongProcess.Style = ProgressBarStyle.Blocks
            bgrLongProcess.CancelAsync()
            'MessageBox.Show("Backup Completed..", "MESSAGE", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DatabaseBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        prgLongProcess.Visible = False
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class