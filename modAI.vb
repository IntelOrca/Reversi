'------------------------------------
'Reversi v1.0
'Copyright TedTycoon 2008
'http://www.tedtycoon.co.uk
'------------------------------------
Enum Difficulty As Byte
    Newbie
    Random
    Player
    Grandmaster
End Enum

Module modAIPublic

    Public Const WhiteAI As Integer = 0
    Public Const BlackAI As Integer = 1
    Public Const AIWait As Integer = 100

    Public Function IsValid(ByVal x As Integer, ByVal y As Integer) As Boolean
        If Game.PlayerTurn = 1 Then
            Return Game.ValidSpot(x, y, TILE.White)
        ElseIf Game.PlayerTurn = 2 Then
            Return Game.ValidSpot(x, y, TILE.Black)
        End If
    End Function

    Public Function GetAvailableMoves() As ArrayList
        Dim Moves As New ArrayList
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If IsValid(i, j) Then
                    Moves.Add(New Move(i, j))
                End If
            Next
        Next
        Return Moves
    End Function

    Class Move
        Public X As Byte
        Public Y As Byte

        Public Sub New(ByVal nx As Byte, ByVal ny As Byte)
            X = nx
            Y = ny
        End Sub

        Public Function IsCorner() As Boolean
            If X = 0 And Y = 0 Then Return True
            If X = 7 And Y = 0 Then Return True
            If X = 0 And Y = 7 Then Return True
            If X = 7 And Y = 7 Then Return True
        End Function

        Public Function IsEdge() As Boolean
            If X = 0 Or X = 7 Then
                Return True
            End If
            If Y = 0 Or Y = 7 Then
                Return True
            End If
        End Function

    End Class

End Module

Module modAI1

    Dim r As New Random

    Public Sub TedAI(ByVal Difficulty As Difficulty)
        Select Case Difficulty
            Case Reversi.Difficulty.Random
                RandomMove()
            Case Reversi.Difficulty.Player
                PlayerMove()
        End Select
    End Sub

    Private Sub PlayerMove()
        Dim i As Integer
        Dim Moves As ArrayList = GetAvailableMoves()
        Dim Move As Move = Moves(0)

        'If only 1 move available
        If Moves.Count = 1 Then
            Game.HaveGo(Move.X, Move.Y)
            Exit Sub
        End If

        'Go for corner
        Dim FoundCorner As Boolean
        For i = 0 To Moves.Count - 1
            If Moves(i).IsCorner() Then
                If FoundCorner Then
                    If rnd(0, 1) = 1 Then
                        Move = Moves(i)
                    End If
                Else
                    Move = Moves(i)
                    FoundCorner = True
                End If
            End If
        Next
        If FoundCorner Then
            Game.HaveGo(Move.X, Move.Y)
            Exit Sub
        End If

        'Go for edge
        Dim EdgeFound As Boolean
        For i = 0 To Moves.Count - 1
            If Moves(i).IsEdge() Then
                If EdgeFound Then
                    If rnd(0, 1) = 1 Then
                        Move = Moves(i)
                    End If
                Else
                    Move = Moves(i)
                    EdgeFound = True
                End If
            End If
        Next
        If EdgeFound Then
            Game.HaveGo(Move.X, Move.Y)
            Exit Sub
        End If

        'Else do a random move
        RandomMove()
    End Sub

    Private Sub RandomMove()
        Dim Moves As ArrayList = GetAvailableMoves()
        Dim MoveNo As Integer = rnd(0, Moves.Count - 1)
        Game.HaveGo(Moves.Item(MoveNo).X, Moves.Item(MoveNo).Y)
    End Sub

    Private Function rnd(ByVal low As Integer, ByVal high As Integer)
        Return r.Next(low, high + 1)
    End Function

End Module

Module modAI2

    Dim r As New Random

    Public Sub GrahamAI(ByVal Difficulty As Difficulty)
        Select Case Difficulty
            Case Reversi.Difficulty.Random
                RandomMove()
            Case Reversi.Difficulty.Player
                playerMove()
        End Select
    End Sub

    Private Sub PlayerMove()
        'Check for corners
        If IsValid(0, 0) Then Game.HaveGo(0, 0) : Exit Sub
        If IsValid(7, 0) Then Game.HaveGo(7, 0) : Exit Sub
        If IsValid(0, 7) Then Game.HaveGo(0, 7) : Exit Sub
        If IsValid(7, 7) Then Game.HaveGo(7, 7) : Exit Sub
        'Check for edge
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                If x = 0 Or y = 0 Or x = 7 Or y = 7 Then
                    If IsValid(x, y) Then Game.HaveGo(x, y) : Exit Sub
                End If
            Next
        Next
        'Check for corner-2
        If IsValid(2, 2) Then Game.HaveGo(2, 2) : Exit Sub
        If IsValid(5, 2) Then Game.HaveGo(5, 2) : Exit Sub
        If IsValid(2, 5) Then Game.HaveGo(2, 5) : Exit Sub
        If IsValid(5, 5) Then Game.HaveGo(5, 5) : Exit Sub
        'Check for centre
        If IsValid(3, 3) Then Game.HaveGo(3, 3) : Exit Sub
        If IsValid(3, 4) Then Game.HaveGo(3, 4) : Exit Sub
        If IsValid(4, 3) Then Game.HaveGo(4, 3) : Exit Sub
        If IsValid(4, 4) Then Game.HaveGo(4, 4) : Exit Sub
        If IsValid(2, 3) Then Game.HaveGo(2, 3) : Exit Sub
        If IsValid(2, 4) Then Game.HaveGo(2, 4) : Exit Sub
        If IsValid(5, 3) Then Game.HaveGo(5, 3) : Exit Sub
        If IsValid(5, 4) Then Game.HaveGo(5, 4) : Exit Sub
        If IsValid(3, 2) Then Game.HaveGo(3, 2) : Exit Sub
        If IsValid(4, 2) Then Game.HaveGo(4, 2) : Exit Sub
        If IsValid(3, 5) Then Game.HaveGo(3, 5) : Exit Sub
        If IsValid(4, 5) Then Game.HaveGo(4, 5) : Exit Sub
        'Check if surrounded
        'Else do a random move
        RandomMove()

    End Sub

    Private Sub RandomMove()
        Dim Moves As New ArrayList
        For i As Integer = 0 To 7
            For j As Integer = 0 To 7
                If Game.ValidSpot(i, j, TILE.Black) Then
                    Moves.Add(New Point(i, j))
                End If
            Next
        Next
        Dim MoveNo As Integer = r.Next(0, Moves.Count)
        Game.HaveGo(Moves.Item(MoveNo).X, Moves.Item(MoveNo).Y)
        Exit Sub
    End Sub

End Module
