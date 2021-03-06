﻿Public Class Configuration
  Private Const PORTS_NB = 15

  Private Const CONFIG_FILE = "Config.xml"

  Private Const MARG = 10
  Private Const BUT_BIG_WIDTH = 116
  Private Const BUT_MID_WIDTH = 64
  Private Const BUT_LTL_WIDTH = 28
  Private Const BUT_HEIGHT = 24
  Private Const LBL_WIDTH = 48
  Private Const LBL_BIG_WIDTH = 80

  Private Const SERIAL_DEF_RATE = "57600"
  Private Const SERIAL_DEF_PORT = "COM1"
  Private Const SERIAL_DEF_STOP = "One"

  Private Const SENSOR_DEF_LEVEL = "High (1)"
  Private Const SENSOR_DEF_FILT = "1 ms"

  Private TxtNames(MAX_TRACKS) As TextBox
  Private LabNames(MAX_TRACKS) As Label

  Private SensorsLevel(MAX_TRACKS) As Integer
  Private SensorsFiltIdx(MAX_TRACKS) As Integer

  Private InitDone As Boolean

  Public Sub InitConf()
    Dim Port As String
    Dim Valid As Boolean

    Dim Path As String

    InitDone = False

    ' Group box chrono
    LabTrack.AutoSize = False
    LabTrack.Width = LBL_WIDTH
    LabTrack.Height = BUT_HEIGHT
    LabTrack.Left = MARG
    LabTrack.Top = 3 * MARG

    ListTracks.Width = BUT_BIG_WIDTH
    ListTracks.Height = BUT_HEIGHT
    ListTracks.Left = LabTrack.Right + MARG
    ListTracks.Top = LabTrack.Top

    For I = 1 To MAX_TRACKS
      ListTracks.Items.Add(I.ToString)
    Next
    ListTracks.SelectedIndex = NB_TRACKS - 1

    For I = 0 To MAX_TRACKS - 1
      LabNames(I) = New Label
      GroupBoxChrono.Controls.Add(LabNames(I))
      LabNames(I).AutoSize = False
      LabNames(I).Width = LBL_WIDTH
      LabNames(I).Height = BUT_HEIGHT
      LabNames(I).Top = ListTracks.Bottom + 2 * MARG + I * (BUT_HEIGHT + MARG / 4)
      LabNames(I).Left = MARG
      LabNames(I).Text = Chr(Asc("A") + I)
      TxtNames(I) = New TextBox
      GroupBoxChrono.Controls.Add(TxtNames(I))
      TxtNames(I).Width = BUT_BIG_WIDTH
      TxtNames(I).Height = BUT_HEIGHT
      TxtNames(I).Top = LabNames(I).Top
      TxtNames(I).Left = LabNames(I).Right + MARG
    Next

    ' Group box serial link
    LabPort.Width = LBL_WIDTH
    LabPort.Height = BUT_HEIGHT
    LabPort.Left = MARG
    LabPort.Top = 3 * MARG

    ListPorts.Width = BUT_BIG_WIDTH
    ListPorts.Height = BUT_HEIGHT
    ListPorts.Left = LabPort.Right + MARG
    ListPorts.Top = LabPort.Top

    LabRate.Width = LBL_WIDTH
    LabRate.Height = BUT_HEIGHT
    LabRate.Left = MARG
    LabRate.Top = LabPort.Bottom + 3 * MARG

    ListRates.Width = BUT_BIG_WIDTH
    ListRates.Height = BUT_HEIGHT
    ListRates.Left = ListPorts.Left
    ListRates.Top = LabRate.Top

    LabStopBits.Width = LBL_WIDTH
    LabStopBits.Height = BUT_HEIGHT
    LabStopBits.Left = MARG
    LabStopBits.Top = LabRate.Bottom + 3 * MARG

    ListStopBits.Width = BUT_BIG_WIDTH
    ListStopBits.Height = BUT_HEIGHT
    ListStopBits.Left = ListPorts.Left
    ListStopBits.Top = LabStopBits.Top

    LabConf.Width = 160
    LabConf.Height = ListStopBits.Bottom - ListPorts.Top
    LabConf.Left = ListPorts.Right + 2 * MARG
    LabConf.Top = LabPort.Top

    'Fixed parameters
    Serial.DataBits = 8
    Serial.Parity = IO.Ports.Parity.None
    Serial.WriteTimeout = 10000

    ' Modifiable parameters
    For I = 1 To PORTS_NB
      Port = "COM" + I.ToString
      Serial.PortName = Port
      Valid = True
      Try
        Serial.Open()
      Catch Except As Exception
        Valid = False
      End Try
      If Valid Then
        Serial.Close()
        ListPorts.Items.Add("COM" + I.ToString)
      End If
    Next I

    ListRates.Items.Add("110")
    ListRates.Items.Add("150")
    ListRates.Items.Add("300")
    ListRates.Items.Add("1200")
    ListRates.Items.Add("2400")
    ListRates.Items.Add("4800")
    ListRates.Items.Add("9600")
    ListRates.Items.Add("19200")
    ListRates.Items.Add("38400")
    ListRates.Items.Add("57600")
    ListRates.Items.Add("115200")
    ListRates.Items.Add("230400")
    ListRates.Items.Add("460800")
    ListRates.Items.Add("921600")

    ListStopBits.Items.Add("None")
    ListStopBits.Items.Add("One")
    ListStopBits.Items.Add("OnePointFive")
    ListStopBits.Items.Add("Two")

    ' GroupBox Sensor
    ' Group box chrono
    LabSensorLevel.AutoSize = False
    LabSensorLevel.Width = LBL_BIG_WIDTH
    LabSensorLevel.Height = BUT_HEIGHT
    LabSensorLevel.Left = MARG
    LabSensorLevel.Top = 3 * MARG

    ListSensorLevel.Width = BUT_MID_WIDTH
    ListSensorLevel.Height = BUT_HEIGHT
    ListSensorLevel.Left = LabSensorLevel.Right + MARG
    ListSensorLevel.Top = LabSensorLevel.Top
    ListSensorLevel.Items.Add("Low (0)")
    ListSensorLevel.Items.Add("High (1)")
    ListSensorLevel.SelectedIndex = 0

    LabSensorFilt.AutoSize = False
    LabSensorFilt.Width = LBL_BIG_WIDTH
    LabSensorFilt.Height = BUT_HEIGHT
    LabSensorFilt.Left = MARG
    LabSensorFilt.Top = LabSensorLevel.Bottom + MARG

    ListSensorFilt.Width = BUT_MID_WIDTH
    ListSensorFilt.Height = BUT_HEIGHT
    ListSensorFilt.Left = LabSensorFilt.Right + MARG
    ListSensorFilt.Top = LabSensorFilt.Top
    ListSensorFilt.Items.Add("250 us")
    ListSensorFilt.Items.Add("500 us")
    ListSensorFilt.Items.Add("1 ms")
    ListSensorFilt.Items.Add("2 ms")
    ListSensorFilt.Items.Add("5 ms")
    ListSensorFilt.Items.Add("10 ms")
    ListSensorFilt.Items.Add("20 ms")
    ListSensorFilt.Items.Add("50 ms")
    ListSensorFilt.Items.Add("100 ms")
    ListSensorFilt.Items.Add("200 ms")
    ListSensorFilt.Items.Add("500 ms")
    ListSensorFilt.SelectedIndex = 2

    ListSensors.Width = BUT_BIG_WIDTH
    ListSensors.Height = BUT_HEIGHT * 6
    ListSensors.Left = LabConf.Left
    ListSensors.Top = ListSensorLevel.Top

    ButAppAll.Width = ListSensorLevel.Right - LabSensorLevel.Left
    ButAppAll.Height = BUT_HEIGHT
    ButAppAll.Left = LabSensorLevel.Left
    ButAppAll.Top = ListSensorFilt.Bottom + 2 * MARG

    ButAppSel.Width = ButAppAll.Width
    ButAppSel.Height = BUT_HEIGHT
    ButAppSel.Left = LabSensorLevel.Left
    ButAppSel.Top = ButAppAll.Bottom + MARG

    GroupBoxChrono.Height = TxtNames(MAX_TRACKS - 1).Bottom + MARG
    GroupBoxChrono.Left = MARG
    GroupBoxChrono.Top = MARG

    GroupBoxSerial.Height = LabConf.Bottom + MARG
    GroupBoxSerial.Left = MARG
    GroupBoxSerial.Top = GroupBoxChrono.Bottom + MARG

    GroupBoxSensor.Height = ListSensors.Bottom + MARG
    GroupBoxSensor.Left = MARG
    GroupBoxSensor.Top = GroupBoxSerial.Bottom + MARG

    GroupBoxSerial.Width = LabConf.Right + MARG
    GroupBoxChrono.Width = GroupBoxSerial.Width
    GroupBoxSensor.Width = GroupBoxSerial.Width

    ' Buttons
    ButConf.Width = BUT_BIG_WIDTH
    ButConf.Height = BUT_HEIGHT
    ButConf.Left = GroupBoxSensor.Right - ButConf.Width
    ButConf.Top = GroupBoxSensor.Bottom + 2 * MARG

    ButDefConf.Width = BUT_MID_WIDTH
    ButDefConf.Height = BUT_HEIGHT
    ButDefConf.Left = GroupBoxSensor.Left
    ButDefConf.Top = GroupBoxSensor.Bottom + 2 * MARG

    ButLoadConf.Width = BUT_MID_WIDTH
    ButLoadConf.Height = BUT_HEIGHT
    ButLoadConf.Left = ButDefConf.Right + MARG
    ButLoadConf.Top = GroupBoxSensor.Bottom + 2 * MARG

    ButArduino.Width = BUT_MID_WIDTH
    ButArduino.Height = BUT_HEIGHT
    ButArduino.Left = ButLoadConf.Right + MARG
    ButArduino.Top = GroupBoxSensor.Bottom + 2 * MARG
    ButArduino.ForeColor = Color.Red

    ButConf.Select()

    Me.ClientSize = New Size(GroupBoxSensor.Right + MARG, ButConf.Bottom + MARG)
    Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
    Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

    Path = Application.ExecutablePath & "\..\" & CONFIG_FILE
    UpdateSerialConf()
    If Not (Dir(Path) <> "" AndAlso LoadConf(Path)) Then
      MsgBox("Incorrect configuration file '" & CONFIG_FILE & "' " & vbCrLf & "Default values will be used")
      DefaultConf()
    End If
    UpdateSerialConf()
    InitDone = True

    For I = 0 To NB_TRACKS - 1
      TxtNames(I).Enabled = True
    Next
    For I = NB_TRACKS To MAX_TRACKS - 1
      TxtNames(I).Enabled = False
    Next
    UpdateListSensors()
    Me.ShowDialog()

  End Sub

  ' Update the serial characteristics
  Private Sub UpdateSerialConf()

    LabConf.Text = "Port = " & ListPorts.SelectedItem & vbCrLf & _
           "Bauds rate = " & ListRates.SelectedItem & vbCrLf & _
           "Parity = " & Serial.Parity.ToString & vbCrLf & _
           "Data bits = " & Serial.DataBits.ToString & vbCrLf & _
           "Stop bits = " & ListStopBits.SelectedItem & vbCrLf & _
           "Read Buffer size = " & Serial.ReadBufferSize.ToString & vbCrLf & _
           "Write Buffer size = " & Serial.WriteBufferSize.ToString & vbCrLf
  End Sub

  Public Function LoadConf(ByVal LocFic As String) As Boolean
    Dim Document As System.Xml.XPath.XPathDocument = New System.Xml.XPath.XPathDocument(LocFic)
    Dim Navigator As System.Xml.XPath.XPathNavigator = Document.CreateNavigator()
    Dim Nodes As System.Xml.XPath.XPathNodeIterator = Navigator.Select("/")
    Dim I As Integer
    Dim Port As String

    ' Access CONFIGURATION node
    Nodes.Current.MoveToFirstChild()
    ' Verification
    If Nodes.Current.Name <> "CONFIGURATION" Then
      Return False
    End If

    ' Access CHRONO node
    Nodes.Current.MoveToFirstChild()
    ' Verification
    If Nodes.Current.Name <> "CHRONO" Then
      Return False
    End If

    ' Acquire number of tracks
    NB_TRACKS = CInt(Nodes.Current.GetAttribute("tracks", ""))
    ListTracks.SelectedIndex = NB_TRACKS - 1
    ' Access NAME node
    Nodes.Current.MoveToFirstChild()
    ' Verification 
    If Nodes.Current.Name <> "NAME" Then
      Return False
    End If
    ' Acquire names
    I = 0
    Do
      TxtNames(I).Text = Nodes.Current.GetAttribute("ident", "")
      SensorsLevel(I) = CInt(Nodes.Current.GetAttribute("level", ""))
      SensorsFiltIdx(I) = CInt(Nodes.Current.GetAttribute("filt_idx", ""))
      I += 1
    Loop While Nodes.Current.MoveToNext()

    ' Access SERIAL node
    Nodes.Current.MoveToParent()
    Nodes.Current.MoveToNext()
    Nodes.Current.MoveToFirstChild()
    ' Verification
    If Nodes.Current.Name <> "SERIAL" Then
      Return False
    End If

    ' Acquire serial parameters
    ListRates.SelectedItem = Nodes.Current.GetAttribute("rate", "")
    Port = Nodes.Current.GetAttribute("port", "")
    ListStopBits.SelectedItem = Nodes.Current.GetAttribute("stop", "")

    If ListPorts.Items.Count > 0 Then
      ListPorts.SelectedIndex = 0
      For I = 0 To ListPorts.Items.Count - 1
        If Port = ListPorts.Items(I) Then
          ListPorts.SelectedIndex = I
        End If
      Next
    Else
      ListPorts.SelectedItem = ""
    End If

    UpdateListSensors()

    Return True
  End Function

  Public Sub SaveConf(ByVal LocFic As String)
    Dim Disp As New System.Xml.XmlWriterSettings()

    Disp.Indent = True
    Disp.IndentChars = "  "
    Using GenXml As System.Xml.XmlWriter = System.Xml.XmlWriter.Create(LocFic, Disp)
      ' Write XML data.
      GenXml.WriteStartElement("CONFIGURATION")
      GenXml.WriteStartElement("CHRONO")
      GenXml.WriteAttributeString("tracks", "", NB_TRACKS)

      For I = 0 To MAX_TRACKS - 1
        GenXml.WriteStartElement("NAME")
        GenXml.WriteAttributeString("ident", "", TxtNames(I).Text)
        GenXml.WriteAttributeString("level", "", SensorsLevel(I).ToString)
        GenXml.WriteAttributeString("filt_idx", "", SensorsFiltIdx(I).ToString)
        GenXml.WriteEndElement()
      Next

      GenXml.WriteEndElement()
      GenXml.WriteStartElement("SERIAL")
      GenXml.WriteAttributeString("port", "", ListPorts.SelectedItem)
      GenXml.WriteAttributeString("rate", "", ListRates.SelectedItem)
      GenXml.WriteAttributeString("stop", "", ListStopBits.SelectedItem)
      GenXml.WriteEndElement()
      GenXml.Flush()

    End Using

  End Sub

  Private Sub UpdateListSensors()
    ListSensors.Items.Clear()
    For I = 0 To NB_TRACKS - 1
      ListSensors.Items.Add(Chr(Asc("A") + I) & " : " & ListSensorLevel.Items(SensorsLevel(I)) & ", " & ListSensorFilt.Items(SensorsFiltIdx(I)))
    Next

  End Sub

  Private Sub DefaultConf()
    NB_TRACKS = 2
    ListTracks.SelectedItem = "2"
    For I = 0 To MAX_TRACKS - 1
      TxtNames(I).Text = "Track " & Chr(Asc("A") + I)
    Next
    ListRates.SelectedItem = SERIAL_DEF_RATE
    If ListPorts.Items.Count > 0 Then
      ListPorts.SelectedIndex = 0
    Else
      ListPorts.SelectedItem = ""
    End If
    ListStopBits.SelectedItem = SERIAL_DEF_STOP

    ListSensorLevel.SelectedItem = SENSOR_DEF_LEVEL
    ListSensorFilt.SelectedItem = SENSOR_DEF_FILT

    UpdateSerialConf()
  End Sub

  Private Sub ConfigureSerial()
    ' Close the serial port, update the serial configuration an reopen the serial port 
    If Serial.IsOpen Then
      Serial.Close()
    End If
    Serial.BaudRate = ListRates.SelectedItem
    Select Case ListStopBits.SelectedItem
      Case "None"
        Serial.StopBits = IO.Ports.StopBits.None
      Case "One"
        Serial.StopBits = IO.Ports.StopBits.One
      Case "OnePointFive"
        Serial.StopBits = IO.Ports.StopBits.OnePointFive
      Case "Two"
        Serial.StopBits = IO.Ports.StopBits.Two
      Case Else
        Serial.StopBits = IO.Ports.StopBits.One
    End Select 

    If ListPorts.SelectedItem <> "" Then
      Serial.PortName = ListPorts.SelectedItem
      Try
        Serial.Open()
      Catch Except As Exception
        MsgBox("Selected Serial Port unvailable")
        SerialOk = False
        Exit Sub
      End Try
    Else
      MsgBox("None Serial Port selected")
      SerialOk = False
    End If
    SerialOk = True

  End Sub

  ' Verification of the serial communication
  Private Sub CheckSerial()
    Dim Buf(MAX_TRACKS + 2) As Byte
    Dim C, Verif As Byte
    Dim N As Integer

    ' Wait to allow the complete reception of possible data 
    System.Threading.Thread.Sleep(100)
    ' Send the stop scan command to the embedded system
    Serial.Write("CS")
    System.Threading.Thread.Sleep(50)
    If Not (Serial.BytesToRead = 1 AndAlso Serial.ReadByte = Asc("S")) Then
      MsgBox("Connection with embedded unit failed " & vbCrLf & "Bad response to CS command)")
      SerialOk = False
      Return
    End If
    ' Send the configuration to the embedded system 'CF'
    Serial.Write("CF")
    ' Number of tracks
    Buf(0) = NB_TRACKS
    For I = 0 To MAX_TRACKS
      ' Sensor level (0->low, 1->high) on MSB, Sensor filtering time index on LSB
      Buf(I + 1) = SensorsLevel(I) * 16 + SensorsFiltIdx(I)
    Next
    ' Terminal character
    Buf(MAX_TRACKS + 1) = Asc("*")
    Serial.Write(Buf, 0, MAX_TRACKS + 2)

    ' Wait to allow the complete transmission of the configuration response by the embedded system
    System.Threading.Thread.Sleep(100)
    ' Check the correct bytes number of the configuration response 
    N = Serial.BytesToRead
    If N = 3 Then
      ' Wait for 'C' header
      C = Serial.ReadByte
      Verif = Serial.ReadByte
      EmbeddedVersion = Serial.ReadByte
      If C = Asc("F") AndAlso Verif = Buf(0) Then
        ' Send the restart scan command to the embedded system
        Serial.Write("CR")
        ' Get possible data
        System.Threading.Thread.Sleep(100)
        ' Flush the buffer
        While Serial.BytesToRead > 0
          C = Serial.ReadByte
        End While
        MsgBox("Connection with embedded unit OK")
      Else
        MsgBox("Connection with embedded unit failed " & vbCrLf & "Bad response to CF command)")
        SerialOk = False
      End If
    Else
      MsgBox("Connection with embedded unit failed " & vbCrLf & "Bad response length to CF command)")
      SerialOk = False
    End If

  End Sub
  ' Check the asynchrone messages received from the embedded system
  Public Function ScanSerial(ByRef Track As Byte, ByRef Time As Integer)

    If Not Serial.IsOpen Then
      Return False
    End If

    If Serial.BytesToRead > 3 Then
      Track = Serial.ReadByte
      ' Receiving of a new time : The header of a new time is 'A' for track A, 'B'
      If Track >= Asc("A") And Track <= Asc("H") Then
        ' The time is coded in Ms inside the next two bytes, MSB first
        Time = Serial.ReadByte * 256
        Time = Time + Serial.ReadByte
        Time = Time + Serial.ReadByte * 65536
        Track -= Asc("A")
        Return True
      End If
    End If

    Return False
  End Function

  Public Function GetName(ByVal Track As Integer) As String
    Return TxtNames(Track).Text
  End Function


  ' Return the connected port
  Public Function GetPort() As String
    Return ListPorts.SelectedItem
  End Function

  Private Sub ButConf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConf.Click
    SaveConf(CONFIG_FILE)
    ConfigureSerial()
    If SerialOk Then
      CheckSerial()
    End If
    Me.Close()
  End Sub

  Private Sub ButLoadConf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButLoadConf.Click
    LoadConf(CONFIG_FILE)
  End Sub

  Private Sub ButDefConf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButDefConf.Click
    DefaultConf()
  End Sub

  Private Sub ListPorts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPorts.SelectedIndexChanged
    UpdateSerialConf()
  End Sub

  Private Sub ListRates_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListRates.SelectedIndexChanged
    UpdateSerialConf()
  End Sub

  Private Sub ListStopBits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListStopBits.SelectedIndexChanged
    UpdateSerialConf()
  End Sub

  Private Sub ListTracks_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListTracks.SelectedIndexChanged
    If InitDone Then
      NB_TRACKS = ListTracks.SelectedIndex + 1
      For I = 0 To NB_TRACKS - 1
        TxtNames(I).Enabled = True
      Next
      For I = NB_TRACKS To MAX_TRACKS - 1
        TxtNames(I).Enabled = False
      Next
      UpdateListSensors()
    End If
  End Sub

  Private Sub ButAppAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAppAll.Click
    For I = 0 To NB_TRACKS - 1
      SensorsLevel(I) = ListSensorLevel.SelectedIndex
      SensorsFiltIdx(I) = ListSensorFilt.SelectedIndex
    Next
    UpdateListSensors()
  End Sub

  Private Sub ButAppSel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAppSel.Click
    Dim N As Integer

    For I = 0 To ListSensors.SelectedIndices.Count - 1
      N = ListSensors.SelectedIndices(I)
      SensorsLevel(N) = ListSensorLevel.SelectedIndex
      SensorsFiltIdx(N) = ListSensorFilt.SelectedIndex
    Next
    UpdateListSensors()

  End Sub

  Private Sub ButArduino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButArduino.Click
    Dim Port As String
    Dim Rate As String
    Dim Desc As Integer

    If ListPorts.Items.Count > 0 AndAlso ListPorts.SelectedItem <> "" Then
      Port = ListPorts.SelectedItem
      Rate = ListRates.SelectedItem


      If MsgBox("The Arduino card will be flashed on port " & Port & ", at rate of " & Rate & "Bds", vbOKCancel) = vbOK Then
        Desc = FreeFile()
        FileOpen(Desc, "Flash.bat", OpenMode.Output)
        FileSystem.Print(Desc, "avrdude.exe -C avrdude.conf -v -patmega328p -carduino -P" & Port & " -b" & Rate & " -D -Uflash:w:ChronoNano.hex:i" & vbCrLf)
        FileSystem.Print(Desc, "pause" & vbCrLf)
        FileClose(Desc)
        Shell("Flash.bat", AppWinStyle.NormalFocus)
      End If
    End If
  End Sub
End Class