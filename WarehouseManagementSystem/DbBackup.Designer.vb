<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DbBackup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DbBackup))
        Me.txtBackupFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.prgLongProcess = New System.Windows.Forms.ProgressBar()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.bgrLongProcess = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'txtBackupFile
        '
        Me.txtBackupFile.BackColor = System.Drawing.Color.White
        Me.txtBackupFile.Location = New System.Drawing.Point(312, 77)
        Me.txtBackupFile.Name = "txtBackupFile"
        Me.txtBackupFile.ReadOnly = True
        Me.txtBackupFile.Size = New System.Drawing.Size(187, 20)
        Me.txtBackupFile.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(258, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Location"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(345, 210)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 38)
        Me.Button1.TabIndex = 23
        Me.Button1.Text = "Cancel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'prgLongProcess
        '
        Me.prgLongProcess.Location = New System.Drawing.Point(50, 299)
        Me.prgLongProcess.MarqueeAnimationSpeed = 40
        Me.prgLongProcess.Maximum = 40
        Me.prgLongProcess.Name = "prgLongProcess"
        Me.prgLongProcess.Size = New System.Drawing.Size(464, 18)
        Me.prgLongProcess.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgLongProcess.TabIndex = 22
        '
        'btnSave
        '
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSave.Location = New System.Drawing.Point(186, 210)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(91, 38)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Backup Data"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(312, 127)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(87, 23)
        Me.btnBrowse.TabIndex = 20
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'bgrLongProcess
        '
        '
        'DbBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(554, 389)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.prgLongProcess)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.txtBackupFile)
        Me.Controls.Add(Me.Label2)
        Me.Name = "DbBackup"
        Me.Text = "DbBackup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBackupFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents prgLongProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents bgrLongProcess As System.ComponentModel.BackgroundWorker
End Class
