'------------------------------------
'Reversi v1.0
'Copyright TedTycoon 2008
'http://www.tedtycoon.co.uk
'------------------------------------
Module modReversi

    Public Game As ReversiGame

    Public AppPath As String = My.Application.Info.DirectoryPath & "\"
    Public HFile As String = AppPath & "highscores.dat"

#Region "Highscores"

    Structure Highscore
        Dim Name As String
        Dim Difficulty As Difficulty
        Dim Colour As Byte
        Dim PlayerCounters As Byte
        Dim ComputerCounters As Byte
        Dim Moves As Byte
        Dim Time As Integer
    End Structure

    Public HighscoreCount As Byte
    Public HScores(20) As Highscore

    Public Sub SubmitGame(ByVal h As Highscore)
        Dim Score As Integer = ScoreGame(h)
        For i As Integer = 1 To HighscoreCount
            If Score > ScoreGame(HScores(i)) Then
                'New highscore
                h.Name = InputBox("Please enter your name.", "Highscores")
                For j As Integer = HighscoreCount + 1 To j + 1 Step -1
                    HScores(j) = HScores(j - 1)
                Next
                HScores(i) = h
                If HighscoreCount < 20 Then
                    HighscoreCount += 1
                End If
            End If
        Next
    End Sub

    Public Sub LoadHighscores()
        Try
            Dim sb As Byte
            FileOpen(1, AppPath & "highscores.dat", OpenMode.Binary)
            FileGet(1, HighscoreCount)
            For i As Integer = 1 To HighscoreCount
                FileGet(1, sb) : HScores(i).Name = New String(Chr(0), sb)
                FileGet(1, HScores(i).Name)
                FileGet(1, sb) : HScores(i).Difficulty = sb
                FileGet(1, HScores(i).Colour)
                FileGet(1, HScores(i).PlayerCounters)
                FileGet(1, HScores(i).ComputerCounters)
                FileGet(1, HScores(i).Moves)
                FileGet(1, HScores(i).Time)
            Next
        Catch ex As Exception

        Finally
            FileClose(1)
        End Try
    End Sub

    Public Sub SaveHighscores()
        Try
            If My.Computer.FileSystem.FileExists(HFile) Then My.Computer.FileSystem.DeleteFile(HFile)
            FileOpen(1, HFile, OpenMode.Binary)
            FilePut(1, HighscoreCount)
            For i As Integer = 1 To HighscoreCount
                FilePut(1, HScores(i).Name.Length)
                FilePut(1, HScores(i).Name)
                FilePut(1, HScores(i).Difficulty)
                FilePut(1, HScores(i).Colour)
                FilePut(1, HScores(i).PlayerCounters)
                FilePut(1, HScores(i).ComputerCounters)
                FilePut(1, HScores(i).Moves)
                FilePut(1, HScores(i).Time)
            Next
        Catch ex As Exception

        Finally
            FileClose(1)
        End Try
    End Sub

    Public Function ScoreGame(ByVal g As Highscore) As Integer
        Dim Score As Integer
        Select Case g.Difficulty
            Case Difficulty.Newbie : Score += 100
            Case Difficulty.Random : Score += 200
            Case Difficulty.Player : Score += 400
            Case Difficulty.Grandmaster : Score += 800
        End Select
        Score += g.PlayerCounters - g.ComputerCounters
        Score -= g.Moves
        Score -= g.Time \ 30
    End Function

#End Region

End Module

Enum TILE
    Empty = 1
    White = 2
    Black = 4
End Enum

Enum Sounds
    Go1
    Go2
End Enum

Class ReversiGame

    Public InPlay As Boolean

    Public AIDifficulty As Difficulty

    Public AIPlayingWhite As Boolean
    Public AIPlayingBlack As Boolean
    Public PlayerTurn As Integer
    Public MoveCount As Integer

    Public WhiteTime As Integer
    Public BlackTime As Integer

    Dim Board(7, 7) As TILE
    Dim ValidDirection(7) As Boolean

#Region "Properties"

    Public ReadOnly Property Counters(ByVal Types As TILE) As Integer
        Get
            Dim c As Integer = 0
            If Types And TILE.Empty Then
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        If Board(x, y) = TILE.Empty Then c += 1
                    Next
                Next
            End If
            If Types And TILE.White Then
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        If Board(x, y) = TILE.White Then c += 1
                    Next
                Next
            End If
            If Types And TILE.Black Then
                For x As Integer = 0 To 7
                    For y As Integer = 0 To 7
                        If Board(x, y) = TILE.Black Then c += 1
                    Next
                Next
            End If
            Return c
        End Get
    End Property

#End Region

#Region "Setup"

    Public Sub NewGame()
        'Clear board
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                Board(x, y) = TILE.Empty
            Next
        Next
        'Clear properties
        WhiteTime = 0
        BlackTime = 0
        MoveCount = 0
        InPlay = True
        'Setup the four starting counters
        Board(3, 3) = TILE.White
        Board(4, 4) = TILE.White
        Board(4, 3) = TILE.Black
        Board(3, 4) = TILE.Black

        PlayerTurn = 1  'White goes first
        If AIPlayingWhite Then
            AIGo(WhiteAI)
        End If
    End Sub

#End Region

#Region "Go control"

    Public Sub HaveGo(ByVal x As Integer, ByVal y As Integer)
        If PlayerTurn = 1 Then
            If ValidSpot(x, y, TILE.White) Then
                TurnOverCounters(x, y, TILE.White)
                AddMove(XtoL(x), y, 1)
                PlaySound(Sounds.Go1)
                PlayerTurn = 2
            End If
        ElseIf PlayerTurn = 2 Then
            If ValidSpot(x, y, TILE.Black) Then
                TurnOverCounters(x, y, TILE.Black)
                AddMove(XtoL(x), y, 2)
                PlaySound(Sounds.Go2)
                PlayerTurn = 1
            End If
        End If
rework:
        If CheckOver() Then
            Exit Sub
        Else
            If PlayerTurn = 1 Then
                If CanPlayerGo(TILE.White) Then
                    If AIPlayingWhite Then
                        AIGo(WhiteAI)
                    End If
                Else
                    PlayerTurn = 2
                    GoTo rework
                End If
            ElseIf PlayerTurn = 2 Then
                If CanPlayerGo(TILE.Black) Then
                    If AIPlayingBlack Then
                        AIGo(BlackAI)
                    End If
                Else
                    PlayerTurn = 1
                    GoTo rework
                End If
            End If
        End If
    End Sub

    Public Sub AIGo(ByVal ai As Integer)
        Dim tile As TILE = PlayerToTile(PlayerTurn)
        frmMain.RefreshGame()
        System.Threading.Thread.Sleep(AIWait)
        If CanPlayerGo(tile) Then
            Select Case ai
                Case 0 : TedAI(AIDifficulty)
                Case 1 : GrahamAI(AIDifficulty)
            End Select
        End If
        frmMain.imgBoard.Refresh()
    End Sub

    Public Function CheckOver() As Boolean
        Dim Whites As Integer = Counters(TILE.White)
        Dim Blacks As Integer = Counters(TILE.Black)
        If Not (CanPlayerGo(TILE.White) Or _
                CanPlayerGo(TILE.Black)) Then
            'Game Over, add up counters
            frmMain.RefreshGame()
            InPlay = False
            If Whites > Blacks Then
                'White Wins
                MsgBox("Game Over!" & vbCrLf & String.Format("White wins with {0} counters", Whites), MsgBoxStyle.Information)
            ElseIf Whites < Blacks Then
                'Black Wins
                MsgBox("Game Over!" & vbCrLf & String.Format("Black wins with {0} counters", Blacks), MsgBoxStyle.Information)
            Else
                'Draw
                MsgBox("Game Over!" & vbCrLf & "Looks like it's a draw...", MsgBoxStyle.Information)
            End If
            Return True
        Else
            Return False
        End If
    End Function

    Public Function CanPlayerGo(ByVal player As TILE)
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                If ValidSpot(x, y, player) Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

#End Region

#Region "Validation & Turnover"

    Public Function ValidSpot(ByVal x As Integer, ByVal y As Integer, ByVal player As TILE) As Boolean
        Dim i, j As Integer
        Dim Opponent As TILE
        If player = TILE.Black Then
            Opponent = TILE.White
        Else
            Opponent = TILE.Black
        End If
        For i = 0 To 7
            ValidDirection(i) = False
        Next
        'Make sure the square is empty
        If Board(x, y) = TILE.Empty Then
            'Check up
            If y > 1 Then
                If Board(x, y - 1) = Opponent Then
                    For i = y - 2 To 0 Step -1
                        If Board(x, i) = player Then
                            ValidDirection(0) = True
                            Exit For
                        ElseIf Board(x, i) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check right
            If x < 6 Then
                If Board(x + 1, y) = Opponent Then
                    For i = x + 2 To 7
                        If Board(i, y) = player Then
                            ValidDirection(1) = True
                            Exit For
                        ElseIf Board(i, y) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check down
            If y < 6 Then
                If Board(x, y + 1) = Opponent Then
                    For i = y + 2 To 7
                        If Board(x, i) = player Then
                            ValidDirection(2) = True
                            Exit For
                        ElseIf Board(x, i) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check left
            If x > 1 Then
                If Board(x - 1, y) = Opponent Then
                    For i = x - 2 To 0 Step -1
                        If Board(i, y) = player Then
                            ValidDirection(3) = True
                            Exit For
                        ElseIf Board(i, y) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check Up Right
            If y > 1 And x < 6 Then
                If Board(x + 1, y - 1) = Opponent Then
                    i = x + 1
                    For j = y - 2 To 0 Step -1
                        i += 1
                        If i > 7 Then Exit For
                        If Board(i, j) = player Then
                            ValidDirection(4) = True
                            Exit For
                        ElseIf Board(i, j) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check Down Right
            If y < 6 And x < 6 Then
                If Board(x + 1, y + 1) = Opponent Then
                    i = x + 1
                    For j = y + 2 To 7
                        i += 1
                        If i > 7 Then Exit For
                        If Board(i, j) = player Then
                            ValidDirection(5) = True
                            Exit For
                        ElseIf Board(i, j) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check Up Left
            If y > 1 And x > 1 Then
                If Board(x - 1, y - 1) = Opponent Then
                    i = x - 1
                    For j = y - 2 To 0 Step -1
                        i -= 1
                        If i < 0 Then Exit For
                        If Board(i, j) = player Then
                            ValidDirection(6) = True
                            Exit For
                        ElseIf Board(i, j) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
            'Check Down Left
            If y < 6 And x > 1 Then
                If Board(x - 1, y + 1) = Opponent Then
                    i = x - 1
                    For j = y + 2 To 7
                        i -= 1
                        If i < 0 Then Exit For
                        If Board(i, j) = player Then
                            ValidDirection(7) = True
                            Exit For
                        ElseIf Board(i, j) = TILE.Empty Then
                            Exit For
                        End If
                    Next
                End If
            End If
        End If
        For i = 0 To 7
            If ValidDirection(i) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Sub TurnOverCounters(ByVal x As Integer, ByVal y As Integer, ByVal player As TILE)
        Dim i, j, Counters As Integer
        Dim Opponent As TILE
        If player = TILE.Black Then
            Opponent = TILE.White
        Else
            Opponent = TILE.Black
        End If
        'Make sure the square is empty
        Board(x, y) = player
        'Up
        If ValidDirection(0) Then
            For i = y - 1 To 0 Step -1
                If Board(x, i) = player Then
                    Exit For
                Else
                    Board(x, i) = player
                    Counters += 1
                End If
            Next
        End If
        'Right
        If ValidDirection(1) Then
            For i = x + 1 To 7
                If Board(i, y) = player Then
                    Exit For
                Else
                    Board(i, y) = player
                    Counters += 1
                End If
            Next
        End If
        'Down
        If ValidDirection(2) Then
            For i = y + 1 To 7
                If Board(x, i) = player Then
                    Exit For
                Else
                    Board(x, i) = player
                    Counters += 1
                End If
            Next
        End If
        'Left
        If ValidDirection(3) Then
            For i = x - 1 To 0 Step -1
                If Board(i, y) = player Then
                    Exit For
                Else
                    Board(i, y) = player
                    Counters += 1
                End If
            Next
        End If
        'Up Right
        If ValidDirection(4) Then
            i = x
            For j = y - 1 To 0 Step -1
                i += 1
                If i > 7 Then Exit For
                If Board(i, j) = player Then
                    Exit For
                Else
                    Board(i, j) = player
                    Counters += 1
                End If
            Next
        End If
        'Down Right
        If ValidDirection(5) Then
            i = x
            For j = y + 1 To 7
                i += 1
                If i > 7 Then Exit For
                If Board(i, j) = player Then
                    Exit For
                Else
                    Board(i, j) = player
                    Counters += 1
                End If
            Next
        End If
        'Up Left
        If ValidDirection(6) Then
            i = x
            For j = y - 1 To 0 Step -1
                i -= 1
                If i < 0 Then Exit For
                If Board(i, j) = player Then
                    Exit For
                Else
                    Board(i, j) = player
                    Counters += 1
                End If
            Next
        End If
        'Down Left
        If ValidDirection(7) Then
            i = x
            For j = y + 1 To 7
                i -= 1
                If i < 0 Then Exit For
                If Board(i, j) = player Then
                    Exit For
                Else
                    Board(i, j) = player
                    Counters += 1
                End If
            Next
        End If
    End Sub

#End Region

#Region "Display"

    Public Sub DisplayBoard(ByRef g As Graphics)
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                Select Case Board(x, y)
                    Case TILE.Empty
                        If ValidSpot(x, y, PlayerToTile(PlayerTurn)) Then
                            g.DrawImage(My.Resources.possible, x * 50, y * 50, 50, 50)
                        Else
                            g.DrawImage(My.Resources.null, x * 50, y * 50, 50, 50)
                        End If
                    Case TILE.White
                        g.DrawImage(My.Resources.white, x * 50, y * 50, 50, 50)
                    Case TILE.Black
                        g.DrawImage(My.Resources.black, x * 50, y * 50, 50, 50)
                End Select
            Next
        Next
    End Sub

#End Region

#Region "Other Functions"

    Public Function PlayerToTile(ByVal Player As Integer) As TILE
        If Player = 1 Then
            Return TILE.White
        ElseIf Player = 2 Then
            Return TILE.Black
        Else
            Return TILE.Empty
        End If
    End Function

    Public Function XtoL(ByVal x As Integer) As Char
        Return Chr(65 + x)
    End Function

    Public Sub PlaySound(ByVal Sound As Sounds)
        If frmMain.SoundToolStripMenuItem.Checked Then
            With My.Computer.Audio
                Select Case Sound
                    Case Sounds.Go1
                        If My.Computer.FileSystem.FileExists(AppPath & "Go1.wav") Then
                            .Play(AppPath & "Go1.wav")
                        End If
                    Case Sounds.Go2
                        If My.Computer.FileSystem.FileExists(AppPath & "Go2.wav") Then
                            .Play(AppPath & "Go2.wav")
                        End If
                End Select
            End With
        End If
    End Sub

    Public Sub AddMove(ByVal x As Char, ByVal y As Integer, ByVal player As Integer)
        MoveCount += 1
        Dim p As String
        If player = 1 Then : p = "White"
        Else : p = "Black"
        End If
        frmMain.AddMove(String.Format("{0}. {1}: [{2}{3}]", Format(MoveCount, "00"), p, x, y + 1))
    End Sub

#End Region

End Class