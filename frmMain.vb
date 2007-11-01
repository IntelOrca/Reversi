'------------------------------------
'Reversi v1.0
'Copyright TedTycoon 2008
'http://www.tedtycoon.co.uk
'------------------------------------
Public Class frmMain

#Region "Menu Items"

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        NewGame()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Global.System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub DifficultysToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewbieToolStripMenuItem.Click, RandomToolStripMenuItem.Click, PlayerToolStripMenuItem.Click, GrandmasterToolStripMenuItem.Click
        Me.NewbieToolStripMenuItem.Checked = False
        Me.RandomToolStripMenuItem.Checked = False
        Me.PlayerToolStripMenuItem.Checked = False
        Me.GrandmasterToolStripMenuItem.Checked = False
        sender.Checked = True
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.ShowDialog()
    End Sub

#End Region

#Region "Events"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadHighscores()
        NewGame()
    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SaveHighscores()
    End Sub

    Private Sub imgBoard_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles imgBoard.MouseUp
        If Game.PlayerTurn = 1 Then
            If Not Game.AIPlayingWhite Then
                Game.HaveGo(e.X \ 50, e.Y \ 50)
                RefreshGame()
            End If
        ElseIf Game.PlayerTurn = 2 Then
            If Not Game.AIPlayingBlack Then
                Game.HaveGo(e.X \ 50, e.Y \ 50)
                RefreshGame()
            End If
        End If
    End Sub

    Private Sub imgBoard_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles imgBoard.Paint
        Game.DisplayBoard(e.Graphics)
    End Sub

    Private Sub tmrTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTime.Tick
        If Game.InPlay Then
            If Game.PlayerTurn = 1 Then
                'White
                If Game.WhiteTime < Integer.MaxValue Then
                    Game.WhiteTime += 1
                End If
            ElseIf Game.PlayerTurn = 2 Then
                'Black
                If Game.BlackTime < Integer.MaxValue Then
                    Game.BlackTime += 1
                End If
            End If
            RefreshTime()
        End If
    End Sub

#End Region

#Region "Functions"

    Public Sub NewGame()
        'AI
        Dim Diff As String
        Dim AIType As Difficulty
        If NewbieToolStripMenuItem.Checked Then AIType = Difficulty.Newbie
        If RandomToolStripMenuItem.Checked Then AIType = Difficulty.Random
        If PlayerToolStripMenuItem.Checked Then AIType = Difficulty.Player
        If GrandmasterToolStripMenuItem.Checked Then AIType = Difficulty.Grandmaster
        Select Case AIType
            Case Difficulty.Newbie : Diff = "Newbie"
            Case Difficulty.Random : Diff = "Random"
            Case Difficulty.Player : Diff = "Player"
            Case Difficulty.Grandmaster : Diff = "Grandmaster"
            Case Else : Diff = "Unknown"
        End Select
        lblDifficulty.Text = Diff

        Game = New ReversiGame
        Game.AIDifficulty = AIType
        Game.AIPlayingWhite = WhiteComputerToolStripMenuItem.Checked
        Game.AIPlayingBlack = BlackComputerToolStripMenuItem.Checked
        If WhiteComputerToolStripMenuItem.Checked Then
            lblWhite.Text = "White (Computer)"
            lblDifficulty.Text = "Computer VS "
        Else
            lblWhite.Text = "White (Human)"
            lblDifficulty.Text = "Human VS "
        End If
        If BlackComputerToolStripMenuItem.Checked Then
            lblBlack.Text = "Black (Computer)"
            lblDifficulty.Text &= "Computer"
        Else
            lblBlack.Text = "Black (Human)"
            lblDifficulty.Text &= "Human"
        End If
        txtMoveHistory.Text = vbNullString
        Game.NewGame()
        RefreshGame()
    End Sub

    Public Sub AddMove(ByVal Move As String)
        txtMoveHistory.Text &= Move & vbCrLf
        txtMoveHistory.SelectionStart = txtMoveHistory.TextLength
        txtMoveHistory.ScrollToCaret()
        txtMoveHistory.Refresh()
    End Sub

    Public Sub RefreshGame()
        'Player to go
        If Game.PlayerTurn = 1 Then
            lblStatus.Text = "White's turn"
            imgWhite.BorderStyle = BorderStyle.FixedSingle
            imgBlack.BorderStyle = BorderStyle.None
        Else
            lblStatus.Text = "Black's turn"
            imgWhite.BorderStyle = BorderStyle.None
            imgBlack.BorderStyle = BorderStyle.FixedSingle
        End If
        lblCounters.Text = String.Format("{0}:{1}", Game.Counters(TILE.White), Game.Counters(TILE.Black))
        lblWhiteCounters.Text = String.Format("Counters : {0}", Game.Counters(TILE.White))
        lblBlackCounters.Text = String.Format("Counters : {0}", Game.Counters(TILE.Black))

        lblWhiteCounters.Refresh()
        lblBlackCounters.Refresh()

        imgWhite.Refresh()
        imgBlack.Refresh()

        RefreshTime()

        imgBoard.Refresh()
    End Sub

    Public Sub RefreshTime()
        Dim TotalTime As Integer = Game.WhiteTime + Game.BlackTime
        lblWhiteTime.Text = TimeFormat(Game.WhiteTime)
        lblBlackTime.Text = TimeFormat(Game.BlackTime)
        lblTime.Text = TimeFormat(TotalTime)
    End Sub

    Public Function TimeFormat(ByVal Time As Integer) As String
        Return String.Format("{0}:{1}", Format(Time \ 60, "00"), Format(Time Mod 60, "00"))
    End Function

#End Region

End Class
