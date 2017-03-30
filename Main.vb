Public Class Main

  Private Const NB_DIGITS = 5
  Private Const NB_TIMES = 3

  Private CUR_TIME = 0
  Private BEST_TIME = 1
  Private POS_LAP = 2

  Private TIME_TICK = 567 'Empiric value for the simulation


  Private DIGIT_FONT As Font
  Private NAME_FONT As Font
  Private BUT_FONT As Font

  Private Const MARG = 4
  Private Const DIGIT_WIDTH = 36
  Private Const POINT_WIDTH = 6
  Private Const DIGIT_HEIGHT = 64
  Private Const DIGIT_MARG = 0
  Private Const FRAME_MARG = 8
  Private Const BUT_WIDTH = 128
  Private Const BUT_HEIGHT = 24

  Private GroupFrames(MAX_TRACKS) As GroupBox
  Private LabName(MAX_TRACKS) As Label
  Private LabTime(MAX_TRACKS, NB_TIMES, NB_DIGITS) As Label
  Private LabPoint(MAX_TRACKS, NB_TIMES) As Label
  Private LabPosition(MAX_TRACKS) As Label

  Private CurLapTimes(MAX_TRACKS) As Integer
  Private LastLapTimes(MAX_TRACKS) As Integer
  Private LastTotalTimes(MAX_TRACKS) As Integer
  Private BestTimes(MAX_TRACKS) As Integer
  Private Laps(MAX_TRACKS) As Integer
  Private FirstLaps(MAX_TRACKS) As Boolean
  Private Positions(MAX_TRACKS) As Integer
  Private BestTime As Integer
  Private IdxBestTime As Integer

  Private Sub Init()
    BuildDisplay()

    Timer.Interval = TIME_TICK
    Timer.Stop()

    ClearCurLapTimes()
    ClearBestTimes()

  End Sub

  Private Sub BuildDisplay()
    Dim Shift, LeftAlign, Bottom As Integer
    Dim BackCol, ForeCol As Color
    Dim V As Integer

    DIGIT_FONT = New Font("Quartz", 48, FontStyle.Bold, GraphicsUnit.Pixel)
    NAME_FONT = New Font("Arial", 28, FontStyle.Bold, GraphicsUnit.Pixel)
    BUT_FONT = New Font("Arial", 20, FontStyle.Bold, GraphicsUnit.Pixel)

    For I = 0 To NB_TRACKS - 1
      ' The positions
      LabPosition(I) = New Label
      Me.Controls.Add(LabPosition(I))
      LabPosition(I).Font = NAME_FONT
      LabPosition(I).BackColor = Color.DarkGoldenrod
      LabPosition(I).ForeColor = Color.Yellow
      LabPosition(I).Text = Chr(Asc("A") + I)
      LabPosition(I).AutoSize = False
      LabPosition(I).BorderStyle = BorderStyle.None
      LabPosition(I).TextAlign = ContentAlignment.MiddleLeft
      LabPosition(I).Margin = New Padding(0, 0, 0, 0)
      LabPosition(I).Width = DIGIT_WIDTH
      LabPosition(I).Height = DIGIT_HEIGHT
      LabPosition(I).Left = FRAME_MARG
      LabPosition(I).Top = FRAME_MARG + (DIGIT_HEIGHT + MARG) * I
      LabPosition(I).Name = I.ToString


      ' The background frame
      GroupFrames(I) = New GroupBox
      Me.Controls.Add(GroupFrames(I))
      GroupFrames(I).Font = DIGIT_FONT
      GroupFrames(I).BackColor = Color.White
      GroupFrames(I).ForeColor = Color.Black
      GroupFrames(I).Text = ""
      GroupFrames(I).AutoSize = False
      GroupFrames(I).Width = (DIGIT_WIDTH + DIGIT_MARG) * NB_DIGITS + POINT_WIDTH + MARG * 2
      GroupFrames(I).Height = DIGIT_HEIGHT * (NB_TIMES + 1) + FRAME_MARG * 2
      If I < 4 Then
        GroupFrames(I).Left = LabPosition(0).Right + FRAME_MARG + (FRAME_MARG + GroupFrames(I).Width) * I
        GroupFrames(I).Top = FRAME_MARG
      Else
        GroupFrames(I).Left = LabPosition(0).Right + FRAME_MARG + (FRAME_MARG + GroupFrames(I).Width) * (I - 4)
        GroupFrames(I).Top = FRAME_MARG * 2 + GroupFrames(I).Height
      End If
      ' Times
      For J = 0 To NB_TIMES - 1
        If J = 0 Then
          ForeCol = Color.Yellow
          BackCol = Color.Black
        ElseIf J = 1 Then
          ForeCol = Color.Orange
          BackCol = Color.Black
        End If
        For K = 0 To NB_DIGITS - 1
          If J = 2 Then
            If K = 0 Then
              ' Track identifier
              ForeCol = Color.Yellow
              BackCol = Color.Black
            ElseIf K = 1 Then
              ' Position
              ForeCol = Color.White
              BackCol = Color.DarkGoldenrod
            ElseIf K Then
              ' Laps number
              ForeCol = Color.LightGreen
              BackCol = Color.Black
            End If
          End If
          If K < 2 Then
            Shift = 0
          Else
            Shift = POINT_WIDTH
          End If
          LabTime(I, J, K) = New Label
          GroupFrames(I).Controls.Add(LabTime(I, J, K))
          LabTime(I, J, K).Font = DIGIT_FONT
          LabTime(I, J, K).BackColor = BackCol
          LabTime(I, J, K).ForeColor = ForeCol
          LabTime(I, J, K).Text = ""
          LabTime(I, J, K).AutoSize = False
          LabTime(I, J, K).BorderStyle = BorderStyle.None
          LabTime(I, J, K).Margin = New Padding(0, 0, 0, 0)
          LabTime(I, J, K).Width = DIGIT_WIDTH
          LabTime(I, J, K).Height = DIGIT_HEIGHT
          LabTime(I, J, K).Top = MARG
          LabTime(I, J, K).TextAlign = ContentAlignment.MiddleCenter
          'LabTime(I,J,K).Visible = False
          LabTime(I, J, K).Left = MARG + (DIGIT_WIDTH + DIGIT_MARG) * K + Shift
          LabTime(I, J, K).Top = MARG + DIGIT_HEIGHT * (J + 1)
        Next
        ' Decimal point
        LabPoint(I, J) = New Label
        GroupFrames(I).Controls.Add(LabPoint(I, J))
        LabPoint(I, J).Font = DIGIT_FONT
        LabPoint(I, J).BackColor = Color.Black
        LabPoint(I, J).ForeColor = Color.Yellow
        If J < 2 Then
          LabPoint(I, J).Text = "_"
        Else
          LabPoint(I, J).Text = ""
        End If
        LabPoint(I, J).AutoSize = False
        LabPoint(I, J).BorderStyle = BorderStyle.None
        LabPoint(I, J).Width = DIGIT_WIDTH
        LabPoint(I, J).Height = DIGIT_HEIGHT
        LabPoint(I, J).Left = LabTime(I, 0, 1).Right - (DIGIT_WIDTH - POINT_WIDTH) / 2
        LabPoint(I, J).Top = LabTime(I, J, 0).Top
      Next
      ' Name
      LabName(I) = New Label
      GroupFrames(I).Controls.Add(LabName(I))
      LabName(I).Font = NAME_FONT
      LabName(I).BackColor = Color.DarkGoldenrod
      LabName(I).ForeColor = Color.LightGreen
      LabName(I).Text = Configuration.GetName(I)
      LabName(I).AutoSize = False
      LabName(I).BorderStyle = BorderStyle.None
      LabName(I).TextAlign = ContentAlignment.MiddleLeft
      LabName(I).Margin = New Padding(0, 0, 0, 0)
      LabName(I).Width = LabTime(I, 0, 4).Right - LabTime(I, 0, 0).Left
      LabName(I).Height = DIGIT_HEIGHT
      LabName(I).Left = LabTime(I, 0, 0).Left
      LabName(I).Top = MARG
      LabName(I).Name = I.ToString
      AddHandler LabName(I).Click, AddressOf LabName_Click
      LabTime(I, POS_LAP, 0).Text = Chr(Asc("A") + I)
    Next

    If NB_TRACKS <= 4 Then
      LeftAlign = GroupFrames(NB_TRACKS - 1).Right + FRAME_MARG
      Bottom = GroupFrames(0).Bottom
    Else
      LeftAlign = GroupFrames(3).Right + FRAME_MARG
      Bottom = GroupFrames(4).Bottom
    End If

    ButConf.Width = BUT_WIDTH
    ButConf.Height = BUT_HEIGHT
    ButConf.Left = LeftAlign
    ButConf.Top = FRAME_MARG

    ButStart.Width = BUT_WIDTH
    ButStart.Height = BUT_HEIGHT * 2
    ButStart.Left = LeftAlign
    ButStart.Top = ButConf.Bottom + FRAME_MARG
    ButStart.BackColor = Color.Green
    ButStart.Margin = New Padding(0, 0, 0, 0)
    ButStart.Font = BUT_FONT


    ButClrBest.Width = BUT_WIDTH
    ButClrBest.Height = BUT_HEIGHT * 2
    ButClrBest.Left = LeftAlign
    ButClrBest.Top = ButStart.Bottom + FRAME_MARG
    ButClrBest.BackColor = Color.Orange
    ButClrBest.Margin = New Padding(0, 0, 0, 0)
    ButClrBest.Font = BUT_FONT

    CheckSimu.Width = BUT_WIDTH
    CheckSimu.Height = BUT_HEIGHT
    CheckSimu.Left = LeftAlign
    CheckSimu.Top = ButClrBest.Bottom + FRAME_MARG

    ButQuit.Width = BUT_WIDTH
    ButQuit.Height = BUT_HEIGHT
    ButQuit.Left = LeftAlign
    ButQuit.Top = Bottom - BUT_HEIGHT

    Me.ClientSize = New Size(ButStart.Right + FRAME_MARG, Bottom + MARG)

    If SerialOk Then
      Me.Text = "ChronoNano Version  Host : " & HOST_VERSION & "  Embedded : " & Math.DivRem(EmbeddedVersion, 16, V) & "." & V
    Else
      Me.Text = "ChronoNano Version  Host : " & HOST_VERSION & "  Embedded : Disconnected"
    End If

  End Sub

  Private Sub Restart()
    ClearCurLapTimes()
    ClearLastLapTimes()
    ClearLastTotalTimes()
    ClearBestTimes()
    ClearPositions()
    ClearLaps()
  End Sub

  Private Sub ClearCurLapTimes()
    For I = 0 To NB_TRACKS - 1
      CurLapTimes(I) = 0
      For J = 0 To NB_DIGITS - 1
        LabTime(I, CUR_TIME, J).Text = "-"
      Next
    Next
  End Sub

  Private Sub ClearLastLapTimes()
    For I = 0 To NB_TRACKS - 1
      LastLapTimes(I) = 0
    Next
  End Sub

  Private Sub ClearLastTotalTimes()
    For I = 0 To NB_TRACKS - 1
      LastTotalTimes(I) = 0
    Next
  End Sub

  Private Sub ClearBestTimes()
    For I = 0 To NB_TRACKS - 1
      BestTimes(I) = 99999
      For J = 0 To NB_DIGITS - 1
        LabTime(I, BEST_TIME, J).Text = "-"
        LabTime(I, BEST_TIME, J).BackColor = Color.Black
      Next
      LabPoint(I, BEST_TIME).BackColor = Color.Black
    Next

  End Sub

  Private Sub ClearPositions()
    For I = 0 To NB_TRACKS - 1
      Positions(I) = 0
      LabTime(I, POS_LAP, 1).Text = "*"
    Next
  End Sub

  Private Sub ClearLaps()
    For I = 0 To NB_TRACKS - 1
      Laps(I) = 0
      For J = 2 To NB_DIGITS - 1
        LabTime(I, POS_LAP, J).Text = "0"
        FirstLaps(I) = True
      Next
    Next
  End Sub

  Private Sub SetTime(ByVal Track As Integer, ByVal Time As Integer)
    Dim StrTime, StrBest As String

    StrTime = String.Format("{0:D5}", Time)
    If LastLapTimes(Track) < BestTimes(Track) Then
      BestTimes(Track) = LastLapTimes(Track)
    End If
    StrBest = String.Format("{0:D5}", BestTimes(Track))
    For I = 0 To NB_DIGITS - 1
      LabTime(Track, CUR_TIME, I).Text = Mid(StrTime, I + 1, 1)
      LabTime(Track, BEST_TIME, I).Text = Mid(StrBest, I + 1, 1)
    Next
  End Sub

  Private Sub SetPosition(ByVal Track As Integer, ByVal Pos As Integer)
    Positions(Track) = Pos
    LabPosition(Pos - 1).Text = Chr(Asc("A") + Track)
    LabTime(Track, POS_LAP, 1).Text = Chr(Asc("0") + Pos)
  End Sub

  Private Sub ComputePositions()
    Dim Candidates(MAX_TRACKS) As Integer
    Dim Index
    Dim Flag As Boolean

    ' Build the list of candidates
    For I = 0 To NB_TRACKS - 1
      Candidates(I) = I
    Next

    ' Sort the candidates according the laps and the last time
    Flag = True
    While Flag
      Flag = False
      For I = 0 To NB_TRACKS - 2
        If Laps(Candidates(I + 1)) > Laps(Candidates(I)) Then
          Index = Candidates(I)
          Candidates(I) = Candidates(I + 1)
          Candidates(I + 1) = Index
          Flag = True
        ElseIf Laps(Candidates(I + 1)) = Laps(Candidates(I)) Then
          If LastTotalTimes(Candidates(I + 1)) < LastTotalTimes(Candidates(I)) Then
            Index = Candidates(I)
            Candidates(I) = Candidates(I + 1)
            Candidates(I + 1) = Index
            Flag = True
          End If
        End If
      Next
    End While

    ' Display the positions
    For I = 0 To NB_TRACKS - 1
      SetPosition(Candidates(I), I + 1)
    Next

  End Sub

  Private Sub ComputeBest()
    Dim Index As Integer

    BestTime = BestTimes(0)
    Index = 0
    For I = 1 To NB_TRACKS - 1
      If BestTimes(I) < BestTime Then
        BestTime = BestTimes(I)
        Index = I
      End If
    Next

    For I = 0 To NB_DIGITS - 1
      LabTime(IdxBestTime, BEST_TIME, I).BackColor = Color.Black
      LabTime(Index, BEST_TIME, I).BackColor = Color.DarkRed
    Next
    LabPoint(IdxBestTime, BEST_TIME).BackColor = Color.Black
    LabPoint(Index, BEST_TIME).BackColor = Color.DarkRed
    IdxBestTime = Index

  End Sub

  Private Sub IncLap(ByVal Track As Integer)
    Dim StrLap As String

    Laps(Track) += 1
    StrLap = String.Format("{0:D3}", Laps(Track))
    For I = 2 To NB_DIGITS - 1
      LabTime(Track, POS_LAP, I).Text = Mid(StrLap, I - 1, 1)
    Next
  End Sub

  Private Sub Main_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Configuration.InitConf()
    Init()
    Restart()
    Timer.Start()
  End Sub

  Private Sub ButStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButStart.Click
    Restart()
  End Sub

  Private Sub Timer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer.Tick
    Dim Track As Byte
    Dim Time As Integer

    For I = 0 To NB_TRACKS - 1
      CurLapTimes(I) += TIME_TICK
    Next

    If SerialOk Then
      While Configuration.ScanSerial(Track, Time)
        If FirstLaps(Track) Then
          FirstLaps(Track) = False
        Else
          CurLapTimes(Track) = 0
          LastLapTimes(Track) = Time
          LastTotalTimes(Track) += LastLapTimes(Track)
          SetTime(Track, LastLapTimes(Track))
          SetPosition(Track, Track + 1)
          IncLap(Track)
          ComputePositions()
          ComputeBest()
        End If
      End While
    End If

  End Sub

  Private Sub LabName_Click(ByVal Sender As Object, ByVal Evt As System.EventArgs)
    Dim Lab As Label = Sender
    Dim Track As Integer = CInt(Lab.Name)

    If CheckSimu.Checked Then
      LastLapTimes(Track) = CurLapTimes(Track)
      CurLapTimes(Track) = 0
      LastTotalTimes(Track) += LastLapTimes(Track)
      SetTime(Track, LastLapTimes(Track))
      SetPosition(Track, Track + 1)
      IncLap(Track)
      ComputePositions()
      ComputeBest()
    End If
  End Sub

  Private Sub ButConf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConf.Click
    Timer.Stop()
    For I = 0 To NB_TRACKS - 1
      Me.Controls.Remove(GroupFrames(I))
      Me.Controls.Remove(LabPosition(I))
    Next
    Configuration.ShowDialog()
    Init()
    Restart()
    Timer.Start()
  End Sub

  Private Sub ButClrBest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButClrBest.Click
    ClearBestTimes()
  End Sub

  Private Sub ButQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButQuit.Click
    End
  End Sub
End Class
