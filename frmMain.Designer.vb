'------------------------------------
'Reversi v1.0
'Copyright TedTycoon 2008
'http://www.tedtycoon.co.uk
'------------------------------------
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.GameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.DifficultyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewbieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.RandomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PlayerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrandmasterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.WhiteComputerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BlackComputerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.SoundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.HighscoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblCounters = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblDifficulty = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblTime = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblWhiteCounters = New System.Windows.Forms.Label
        Me.lblWhiteTime = New System.Windows.Forms.Label
        Me.lblWhite = New System.Windows.Forms.Label
        Me.lblBlack = New System.Windows.Forms.Label
        Me.lblBlackTime = New System.Windows.Forms.Label
        Me.lblBlackCounters = New System.Windows.Forms.Label
        Me.txtMoveHistory = New System.Windows.Forms.TextBox
        Me.lblMoveHistory = New System.Windows.Forms.Label
        Me.imgBlack = New System.Windows.Forms.PictureBox
        Me.imgWhite = New System.Windows.Forms.PictureBox
        Me.pnlGame = New System.Windows.Forms.Panel
        Me.imgBoard = New System.Windows.Forms.PictureBox
        Me.tmrTime = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.imgBlack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgWhite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGame.SuspendLayout()
        CType(Me.imgBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GameToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(589, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GameToolStripMenuItem
        '
        Me.GameToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator2, Me.DifficultyToolStripMenuItem, Me.ToolStripSeparator3, Me.WhiteComputerToolStripMenuItem, Me.BlackComputerToolStripMenuItem, Me.ToolStripSeparator4, Me.SoundToolStripMenuItem, Me.ToolStripSeparator5, Me.HighscoresToolStripMenuItem, Me.ToolStripSeparator6, Me.ExitToolStripMenuItem})
        Me.GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        Me.GameToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.GameToolStripMenuItem.Text = "Game"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = Global.Reversi.My.Resources.Resources._new
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(167, 6)
        '
        'DifficultyToolStripMenuItem
        '
        Me.DifficultyToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewbieToolStripMenuItem, Me.RandomToolStripMenuItem, Me.PlayerToolStripMenuItem, Me.GrandmasterToolStripMenuItem})
        Me.DifficultyToolStripMenuItem.Name = "DifficultyToolStripMenuItem"
        Me.DifficultyToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.DifficultyToolStripMenuItem.Text = "Difficulty"
        '
        'NewbieToolStripMenuItem
        '
        Me.NewbieToolStripMenuItem.Name = "NewbieToolStripMenuItem"
        Me.NewbieToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.NewbieToolStripMenuItem.Text = "Newbie"
        '
        'RandomToolStripMenuItem
        '
        Me.RandomToolStripMenuItem.CheckOnClick = True
        Me.RandomToolStripMenuItem.Name = "RandomToolStripMenuItem"
        Me.RandomToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.RandomToolStripMenuItem.Text = "Random"
        '
        'PlayerToolStripMenuItem
        '
        Me.PlayerToolStripMenuItem.Checked = True
        Me.PlayerToolStripMenuItem.CheckOnClick = True
        Me.PlayerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlayerToolStripMenuItem.Name = "PlayerToolStripMenuItem"
        Me.PlayerToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.PlayerToolStripMenuItem.Text = "Player"
        '
        'GrandmasterToolStripMenuItem
        '
        Me.GrandmasterToolStripMenuItem.CheckOnClick = True
        Me.GrandmasterToolStripMenuItem.Name = "GrandmasterToolStripMenuItem"
        Me.GrandmasterToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.GrandmasterToolStripMenuItem.Text = "Grandmaster"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(167, 6)
        '
        'WhiteComputerToolStripMenuItem
        '
        Me.WhiteComputerToolStripMenuItem.Checked = True
        Me.WhiteComputerToolStripMenuItem.CheckOnClick = True
        Me.WhiteComputerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.WhiteComputerToolStripMenuItem.Name = "WhiteComputerToolStripMenuItem"
        Me.WhiteComputerToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.WhiteComputerToolStripMenuItem.Text = "White (Computer)"
        '
        'BlackComputerToolStripMenuItem
        '
        Me.BlackComputerToolStripMenuItem.CheckOnClick = True
        Me.BlackComputerToolStripMenuItem.Name = "BlackComputerToolStripMenuItem"
        Me.BlackComputerToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.BlackComputerToolStripMenuItem.Text = "Black (Computer)"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(167, 6)
        '
        'SoundToolStripMenuItem
        '
        Me.SoundToolStripMenuItem.Checked = True
        Me.SoundToolStripMenuItem.CheckOnClick = True
        Me.SoundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SoundToolStripMenuItem.Name = "SoundToolStripMenuItem"
        Me.SoundToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.SoundToolStripMenuItem.Text = "Sound"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(167, 6)
        '
        'HighscoresToolStripMenuItem
        '
        Me.HighscoresToolStripMenuItem.Name = "HighscoresToolStripMenuItem"
        Me.HighscoresToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.HighscoresToolStripMenuItem.Text = "Highscores..."
        Me.HighscoresToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(167, 6)
        Me.ToolStripSeparator6.Visible = False
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.HintToolStripMenuItem, Me.ToolStripSeparator1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Image = Global.Reversi.My.Resources.Resources.help
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ContentsToolStripMenuItem.Text = "Contents"
        Me.ContentsToolStripMenuItem.Visible = False
        '
        'HintToolStripMenuItem
        '
        Me.HintToolStripMenuItem.Name = "HintToolStripMenuItem"
        Me.HintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HintToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.HintToolStripMenuItem.Text = "Hint"
        Me.HintToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(153, 6)
        Me.ToolStripSeparator1.Visible = False
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.AboutToolStripMenuItem.Text = "About Reversi..."
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus, Me.lblCounters, Me.lblDifficulty, Me.lblTime})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 474)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(589, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 2
        Me.StatusStrip.Text = "StatusStrip"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = False
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(150, 17)
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCounters
        '
        Me.lblCounters.AutoSize = False
        Me.lblCounters.Name = "lblCounters"
        Me.lblCounters.Size = New System.Drawing.Size(50, 17)
        '
        'lblDifficulty
        '
        Me.lblDifficulty.AutoSize = False
        Me.lblDifficulty.Name = "lblDifficulty"
        Me.lblDifficulty.Size = New System.Drawing.Size(150, 17)
        '
        'lblTime
        '
        Me.lblTime.AutoSize = False
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(100, 17)
        '
        'lblWhiteCounters
        '
        Me.lblWhiteCounters.AutoSize = True
        Me.lblWhiteCounters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhiteCounters.Location = New System.Drawing.Point(452, 104)
        Me.lblWhiteCounters.Name = "lblWhiteCounters"
        Me.lblWhiteCounters.Size = New System.Drawing.Size(95, 20)
        Me.lblWhiteCounters.TabIndex = 4
        Me.lblWhiteCounters.Text = "Counters : 2"
        '
        'lblWhiteTime
        '
        Me.lblWhiteTime.AutoSize = True
        Me.lblWhiteTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhiteTime.Location = New System.Drawing.Point(452, 124)
        Me.lblWhiteTime.Name = "lblWhiteTime"
        Me.lblWhiteTime.Size = New System.Drawing.Size(86, 20)
        Me.lblWhiteTime.TabIndex = 5
        Me.lblWhiteTime.Text = "Time : 0:00"
        '
        'lblWhite
        '
        Me.lblWhite.AutoSize = True
        Me.lblWhite.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWhite.Location = New System.Drawing.Point(452, 28)
        Me.lblWhite.Name = "lblWhite"
        Me.lblWhite.Size = New System.Drawing.Size(93, 20)
        Me.lblWhite.TabIndex = 3
        Me.lblWhite.Text = "White (You)"
        '
        'lblBlack
        '
        Me.lblBlack.AutoSize = True
        Me.lblBlack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlack.Location = New System.Drawing.Point(452, 189)
        Me.lblBlack.Name = "lblBlack"
        Me.lblBlack.Size = New System.Drawing.Size(132, 20)
        Me.lblBlack.TabIndex = 6
        Me.lblBlack.Text = "Black (Computer)"
        '
        'lblBlackTime
        '
        Me.lblBlackTime.AutoSize = True
        Me.lblBlackTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlackTime.Location = New System.Drawing.Point(452, 285)
        Me.lblBlackTime.Name = "lblBlackTime"
        Me.lblBlackTime.Size = New System.Drawing.Size(86, 20)
        Me.lblBlackTime.TabIndex = 8
        Me.lblBlackTime.Text = "Time : 0:00"
        '
        'lblBlackCounters
        '
        Me.lblBlackCounters.AutoSize = True
        Me.lblBlackCounters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlackCounters.Location = New System.Drawing.Point(452, 265)
        Me.lblBlackCounters.Name = "lblBlackCounters"
        Me.lblBlackCounters.Size = New System.Drawing.Size(95, 20)
        Me.lblBlackCounters.TabIndex = 7
        Me.lblBlackCounters.Text = "Counters : 2"
        '
        'txtMoveHistory
        '
        Me.txtMoveHistory.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoveHistory.Location = New System.Drawing.Point(453, 340)
        Me.txtMoveHistory.Multiline = True
        Me.txtMoveHistory.Name = "txtMoveHistory"
        Me.txtMoveHistory.ReadOnly = True
        Me.txtMoveHistory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMoveHistory.Size = New System.Drawing.Size(133, 131)
        Me.txtMoveHistory.TabIndex = 10
        '
        'lblMoveHistory
        '
        Me.lblMoveHistory.AutoSize = True
        Me.lblMoveHistory.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMoveHistory.Location = New System.Drawing.Point(456, 317)
        Me.lblMoveHistory.Name = "lblMoveHistory"
        Me.lblMoveHistory.Size = New System.Drawing.Size(97, 20)
        Me.lblMoveHistory.TabIndex = 9
        Me.lblMoveHistory.Text = "Move history"
        '
        'imgBlack
        '
        Me.imgBlack.Image = Global.Reversi.My.Resources.Resources.black
        Me.imgBlack.Location = New System.Drawing.Point(456, 212)
        Me.imgBlack.Name = "imgBlack"
        Me.imgBlack.Size = New System.Drawing.Size(50, 50)
        Me.imgBlack.TabIndex = 10
        Me.imgBlack.TabStop = False
        '
        'imgWhite
        '
        Me.imgWhite.Image = Global.Reversi.My.Resources.Resources.white
        Me.imgWhite.Location = New System.Drawing.Point(456, 51)
        Me.imgWhite.Name = "imgWhite"
        Me.imgWhite.Size = New System.Drawing.Size(50, 50)
        Me.imgWhite.TabIndex = 5
        Me.imgWhite.TabStop = False
        '
        'pnlGame
        '
        Me.pnlGame.BackgroundImage = Global.Reversi.My.Resources.Resources.board
        Me.pnlGame.Controls.Add(Me.imgBoard)
        Me.pnlGame.Location = New System.Drawing.Point(0, 24)
        Me.pnlGame.Name = "pnlGame"
        Me.pnlGame.Size = New System.Drawing.Size(450, 450)
        Me.pnlGame.TabIndex = 0
        '
        'imgBoard
        '
        Me.imgBoard.BackColor = System.Drawing.Color.Transparent
        Me.imgBoard.Location = New System.Drawing.Point(25, 25)
        Me.imgBoard.Name = "imgBoard"
        Me.imgBoard.Size = New System.Drawing.Size(400, 400)
        Me.imgBoard.TabIndex = 0
        Me.imgBoard.TabStop = False
        '
        'tmrTime
        '
        Me.tmrTime.Enabled = True
        Me.tmrTime.Interval = 1000
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 496)
        Me.Controls.Add(Me.lblMoveHistory)
        Me.Controls.Add(Me.txtMoveHistory)
        Me.Controls.Add(Me.lblBlack)
        Me.Controls.Add(Me.lblBlackTime)
        Me.Controls.Add(Me.lblBlackCounters)
        Me.Controls.Add(Me.imgBlack)
        Me.Controls.Add(Me.lblWhite)
        Me.Controls.Add(Me.lblWhiteTime)
        Me.Controls.Add(Me.lblWhiteCounters)
        Me.Controls.Add(Me.imgWhite)
        Me.Controls.Add(Me.pnlGame)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reversi"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.imgBlack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgWhite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGame.ResumeLayout(False)
        CType(Me.imgBoard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents imgBoard As System.Windows.Forms.PictureBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlGame As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblCounters As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblDifficulty As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents imgWhite As System.Windows.Forms.PictureBox
    Friend WithEvents lblTime As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblWhiteCounters As System.Windows.Forms.Label
    Friend WithEvents lblWhiteTime As System.Windows.Forms.Label
    Friend WithEvents lblWhite As System.Windows.Forms.Label
    Friend WithEvents lblBlack As System.Windows.Forms.Label
    Friend WithEvents lblBlackTime As System.Windows.Forms.Label
    Friend WithEvents lblBlackCounters As System.Windows.Forms.Label
    Friend WithEvents imgBlack As System.Windows.Forms.PictureBox
    Friend WithEvents txtMoveHistory As System.Windows.Forms.TextBox
    Friend WithEvents lblMoveHistory As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DifficultyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents WhiteComputerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RandomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrandmasterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SoundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HighscoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tmrTime As System.Windows.Forms.Timer
    Friend WithEvents NewbieToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlackComputerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
