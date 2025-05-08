Public Class MessageForm
    Private WithEvents closeTimer As New Timer()

    Public Sub New(message As String)
        InitializeComponent()
        LabelMessage.Text = message ' Set the message text
        closeTimer.Interval = 1000 ' Set timer interval to 3 seconds (5000 ms)
        closeTimer.Start() ' Start the timer
    End Sub

    Private Sub closeTimer_Tick(sender As Object, e As EventArgs) Handles closeTimer.Tick
        closeTimer.Stop() ' Stop the timer
        Me.Close() ' Close the form
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        closeTimer.Stop() ' Stop the timer
        Me.Close() ' Close the form
    End Sub
End Class