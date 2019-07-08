Public Class Loader

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
         If ProgressBar1.Value = 100 Then
            Me.Hide()
            Login.Show()
            Timer1.Enabled = False
            Exit Sub
        Else
            ProgressBar1.Value += 1

        End If
    End Sub

    Private Sub Loader_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
    End Sub
End Class