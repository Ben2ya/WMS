<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TinCost
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtsize14 = New System.Windows.Forms.TextBox()
        Me.txtsize13 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Algerian", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(57, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 30)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "TIN COST REPORT"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(108, 250)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtsize14
        '
        Me.txtsize14.Location = New System.Drawing.Point(144, 176)
        Me.txtsize14.Name = "txtsize14"
        Me.txtsize14.Size = New System.Drawing.Size(115, 20)
        Me.txtsize14.TabIndex = 9
        '
        'txtsize13
        '
        Me.txtsize13.Location = New System.Drawing.Point(144, 108)
        Me.txtsize13.Name = "txtsize13"
        Me.txtsize13.Size = New System.Drawing.Size(115, 20)
        Me.txtsize13.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(46, 179)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SIZE 14"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "SIZE 13"
        '
        'TinCost
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 361)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtsize14)
        Me.Controls.Add(Me.txtsize13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TinCost"
        Me.Text = "TinCost"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtsize14 As System.Windows.Forms.TextBox
    Friend WithEvents txtsize13 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
