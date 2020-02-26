Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckDPI()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim g As Graphics = Me.CreateGraphics()
        Dim t As String = "ScreenWidth:" & Screen.PrimaryScreen.Bounds.Width & " ScreenHeight:" & Screen.PrimaryScreen.Bounds.Height & vbCrLf & " DpiX:" & g.DpiX & " DpiY:" & g.DpiY
        t1.Text = t
        g.Dispose()
        g = Nothing
    End Sub

    Public Sub CheckDPI()
        Dim screenW As Integer = 0
        Dim screenH As Integer = 0
        Dim DpiX As Integer = 0
        Dim DpiY As Integer = 0
        Try
            Using g As Graphics = Me.CreateGraphics()
                screenW = Screen.PrimaryScreen.Bounds.Width
                screenH = Screen.PrimaryScreen.Bounds.Height
                DpiX = g.DpiX
                DpiY = g.DpiY
            End Using

            If DpiX > 96 Then
                If MsgBox($"Your screen resolution has high DPI: ({DpiX}x{DpiY})." & vbNewLine &
                       "Some controls may not scale or display correctly." & vbNewLine & vbNewLine &
                       "Do you want to continue loading?", vbApplicationModal + vbExclamation + vbYesNo, "Warning") = vbNo Then
                    End
                End If
            End If
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub
End Class
