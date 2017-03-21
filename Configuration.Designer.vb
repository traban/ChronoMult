<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Configuration
  Inherits System.Windows.Forms.Form

  'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

  'Requise par le Concepteur Windows Form
  Private components As System.ComponentModel.IContainer

  'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
  'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
  'Ne la modifiez pas à l'aide de l'éditeur de code.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Me.LabPort = New System.Windows.Forms.Label()
    Me.ListPorts = New System.Windows.Forms.ComboBox()
    Me.LabRate = New System.Windows.Forms.Label()
    Me.ListRates = New System.Windows.Forms.ComboBox()
    Me.LabStopBits = New System.Windows.Forms.Label()
    Me.ListStopBits = New System.Windows.Forms.ComboBox()
    Me.LabConf = New System.Windows.Forms.Label()
    Me.Serial = New System.IO.Ports.SerialPort(Me.components)
    Me.GroupBoxSerial = New System.Windows.Forms.GroupBox()
    Me.GroupBoxChrono = New System.Windows.Forms.GroupBox()
    Me.ListTracks = New System.Windows.Forms.ComboBox()
    Me.LabTrack = New System.Windows.Forms.Label()
    Me.ButDefConf = New System.Windows.Forms.Button()
    Me.ButLoadConf = New System.Windows.Forms.Button()
    Me.ButConf = New System.Windows.Forms.Button()
    Me.GroupBoxSensor = New System.Windows.Forms.GroupBox()
    Me.ListSensorFilt = New System.Windows.Forms.ComboBox()
    Me.LabSensorFilt = New System.Windows.Forms.Label()
    Me.ListSensorLevel = New System.Windows.Forms.ComboBox()
    Me.LabSensorLevel = New System.Windows.Forms.Label()
    Me.GroupBoxSerial.SuspendLayout()
    Me.GroupBoxChrono.SuspendLayout()
    Me.GroupBoxSensor.SuspendLayout()
    Me.SuspendLayout()
    '
    'LabPort
    '
    Me.LabPort.AutoSize = True
    Me.LabPort.Location = New System.Drawing.Point(6, 37)
    Me.LabPort.Name = "LabPort"
    Me.LabPort.Size = New System.Drawing.Size(26, 13)
    Me.LabPort.TabIndex = 0
    Me.LabPort.Text = "Port"
    '
    'ListPorts
    '
    Me.ListPorts.FormattingEnabled = True
    Me.ListPorts.Location = New System.Drawing.Point(45, 19)
    Me.ListPorts.Name = "ListPorts"
    Me.ListPorts.Size = New System.Drawing.Size(101, 21)
    Me.ListPorts.TabIndex = 1
    '
    'LabRate
    '
    Me.LabRate.AutoSize = True
    Me.LabRate.Location = New System.Drawing.Point(6, 64)
    Me.LabRate.Name = "LabRate"
    Me.LabRate.Size = New System.Drawing.Size(30, 13)
    Me.LabRate.TabIndex = 2
    Me.LabRate.Text = "Rate"
    '
    'ListRates
    '
    Me.ListRates.FormattingEnabled = True
    Me.ListRates.Location = New System.Drawing.Point(45, 64)
    Me.ListRates.Name = "ListRates"
    Me.ListRates.Size = New System.Drawing.Size(100, 21)
    Me.ListRates.TabIndex = 3
    '
    'LabStopBits
    '
    Me.LabStopBits.AutoSize = True
    Me.LabStopBits.Location = New System.Drawing.Point(6, 91)
    Me.LabStopBits.Name = "LabStopBits"
    Me.LabStopBits.Size = New System.Drawing.Size(29, 13)
    Me.LabStopBits.TabIndex = 4
    Me.LabStopBits.Text = "Stop"
    '
    'ListStopBits
    '
    Me.ListStopBits.FormattingEnabled = True
    Me.ListStopBits.Location = New System.Drawing.Point(45, 91)
    Me.ListStopBits.Name = "ListStopBits"
    Me.ListStopBits.Size = New System.Drawing.Size(101, 21)
    Me.ListStopBits.TabIndex = 5
    '
    'LabConf
    '
    Me.LabConf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LabConf.Location = New System.Drawing.Point(165, 15)
    Me.LabConf.Name = "LabConf"
    Me.LabConf.Size = New System.Drawing.Size(133, 170)
    Me.LabConf.TabIndex = 6
    '
    'GroupBoxSerial
    '
    Me.GroupBoxSerial.Controls.Add(Me.LabConf)
    Me.GroupBoxSerial.Controls.Add(Me.LabPort)
    Me.GroupBoxSerial.Controls.Add(Me.LabRate)
    Me.GroupBoxSerial.Controls.Add(Me.LabStopBits)
    Me.GroupBoxSerial.Controls.Add(Me.ListStopBits)
    Me.GroupBoxSerial.Controls.Add(Me.ListRates)
    Me.GroupBoxSerial.Controls.Add(Me.ListPorts)
    Me.GroupBoxSerial.Location = New System.Drawing.Point(19, 180)
    Me.GroupBoxSerial.Name = "GroupBoxSerial"
    Me.GroupBoxSerial.Size = New System.Drawing.Size(390, 202)
    Me.GroupBoxSerial.TabIndex = 9
    Me.GroupBoxSerial.TabStop = False
    Me.GroupBoxSerial.Text = "Serial link"
    '
    'GroupBoxChrono
    '
    Me.GroupBoxChrono.Controls.Add(Me.ListTracks)
    Me.GroupBoxChrono.Controls.Add(Me.LabTrack)
    Me.GroupBoxChrono.Location = New System.Drawing.Point(19, 21)
    Me.GroupBoxChrono.Name = "GroupBoxChrono"
    Me.GroupBoxChrono.Size = New System.Drawing.Size(390, 140)
    Me.GroupBoxChrono.TabIndex = 10
    Me.GroupBoxChrono.TabStop = False
    Me.GroupBoxChrono.Text = "Chrono"
    '
    'ListTracks
    '
    Me.ListTracks.FormattingEnabled = True
    Me.ListTracks.Location = New System.Drawing.Point(85, 27)
    Me.ListTracks.Name = "ListTracks"
    Me.ListTracks.Size = New System.Drawing.Size(95, 21)
    Me.ListTracks.TabIndex = 1
    '
    'LabTrack
    '
    Me.LabTrack.AutoSize = True
    Me.LabTrack.Location = New System.Drawing.Point(18, 32)
    Me.LabTrack.Name = "LabTrack"
    Me.LabTrack.Size = New System.Drawing.Size(40, 13)
    Me.LabTrack.TabIndex = 0
    Me.LabTrack.Text = "Tracks"
    '
    'ButDefConf
    '
    Me.ButDefConf.Location = New System.Drawing.Point(19, 508)
    Me.ButDefConf.Name = "ButDefConf"
    Me.ButDefConf.Size = New System.Drawing.Size(70, 21)
    Me.ButDefConf.TabIndex = 4
    Me.ButDefConf.Text = "Default"
    Me.ButDefConf.UseVisualStyleBackColor = True
    '
    'ButLoadConf
    '
    Me.ButLoadConf.Location = New System.Drawing.Point(104, 505)
    Me.ButLoadConf.Name = "ButLoadConf"
    Me.ButLoadConf.Size = New System.Drawing.Size(73, 24)
    Me.ButLoadConf.TabIndex = 3
    Me.ButLoadConf.Text = "Reload"
    Me.ButLoadConf.UseVisualStyleBackColor = True
    '
    'ButConf
    '
    Me.ButConf.Location = New System.Drawing.Point(334, 505)
    Me.ButConf.Name = "ButConf"
    Me.ButConf.Size = New System.Drawing.Size(75, 23)
    Me.ButConf.TabIndex = 2
    Me.ButConf.Text = "Configure"
    Me.ButConf.UseVisualStyleBackColor = True
    '
    'GroupBoxSensor
    '
    Me.GroupBoxSensor.Controls.Add(Me.ListSensorFilt)
    Me.GroupBoxSensor.Controls.Add(Me.LabSensorFilt)
    Me.GroupBoxSensor.Controls.Add(Me.ListSensorLevel)
    Me.GroupBoxSensor.Controls.Add(Me.LabSensorLevel)
    Me.GroupBoxSensor.Location = New System.Drawing.Point(19, 404)
    Me.GroupBoxSensor.Name = "GroupBoxSensor"
    Me.GroupBoxSensor.Size = New System.Drawing.Size(389, 91)
    Me.GroupBoxSensor.TabIndex = 11
    Me.GroupBoxSensor.TabStop = False
    Me.GroupBoxSensor.Text = "Sensors"
    '
    'ListSensorFilt
    '
    Me.ListSensorFilt.FormattingEnabled = True
    Me.ListSensorFilt.Location = New System.Drawing.Point(119, 57)
    Me.ListSensorFilt.Name = "ListSensorFilt"
    Me.ListSensorFilt.Size = New System.Drawing.Size(107, 21)
    Me.ListSensorFilt.TabIndex = 3
    '
    'LabSensorFilt
    '
    Me.LabSensorFilt.AutoSize = True
    Me.LabSensorFilt.Location = New System.Drawing.Point(19, 57)
    Me.LabSensorFilt.Name = "LabSensorFilt"
    Me.LabSensorFilt.Size = New System.Drawing.Size(69, 13)
    Me.LabSensorFilt.TabIndex = 2
    Me.LabSensorFilt.Text = "Filtering Time"
    '
    'ListSensorLevel
    '
    Me.ListSensorLevel.FormattingEnabled = True
    Me.ListSensorLevel.Location = New System.Drawing.Point(117, 22)
    Me.ListSensorLevel.Name = "ListSensorLevel"
    Me.ListSensorLevel.Size = New System.Drawing.Size(110, 21)
    Me.ListSensorLevel.TabIndex = 1
    '
    'LabSensorLevel
    '
    Me.LabSensorLevel.AutoSize = True
    Me.LabSensorLevel.Location = New System.Drawing.Point(16, 24)
    Me.LabSensorLevel.Name = "LabSensorLevel"
    Me.LabSensorLevel.Size = New System.Drawing.Size(66, 13)
    Me.LabSensorLevel.TabIndex = 0
    Me.LabSensorLevel.Text = "Active Level"
    '
    'Configuration
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(436, 538)
    Me.ControlBox = False
    Me.Controls.Add(Me.ButConf)
    Me.Controls.Add(Me.ButDefConf)
    Me.Controls.Add(Me.GroupBoxSensor)
    Me.Controls.Add(Me.ButLoadConf)
    Me.Controls.Add(Me.GroupBoxChrono)
    Me.Controls.Add(Me.GroupBoxSerial)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Configuration"
    Me.Text = "Configuration"
    Me.GroupBoxSerial.ResumeLayout(False)
    Me.GroupBoxSerial.PerformLayout()
    Me.GroupBoxChrono.ResumeLayout(False)
    Me.GroupBoxChrono.PerformLayout()
    Me.GroupBoxSensor.ResumeLayout(False)
    Me.GroupBoxSensor.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents LabPort As System.Windows.Forms.Label
  Friend WithEvents ListPorts As System.Windows.Forms.ComboBox
  Friend WithEvents LabRate As System.Windows.Forms.Label
  Friend WithEvents ListRates As System.Windows.Forms.ComboBox
  Friend WithEvents LabStopBits As System.Windows.Forms.Label
  Friend WithEvents ListStopBits As System.Windows.Forms.ComboBox
  Friend WithEvents LabConf As System.Windows.Forms.Label
  Friend WithEvents Serial As System.IO.Ports.SerialPort
  Friend WithEvents GroupBoxSerial As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBoxChrono As System.Windows.Forms.GroupBox
  Friend WithEvents ListTracks As System.Windows.Forms.ComboBox
  Friend WithEvents LabTrack As System.Windows.Forms.Label
  Friend WithEvents ButConf As System.Windows.Forms.Button
  Friend WithEvents GroupBoxSensor As System.Windows.Forms.GroupBox
  Friend WithEvents ListSensorFilt As System.Windows.Forms.ComboBox
  Friend WithEvents LabSensorFilt As System.Windows.Forms.Label
  Friend WithEvents ListSensorLevel As System.Windows.Forms.ComboBox
  Friend WithEvents LabSensorLevel As System.Windows.Forms.Label
  Friend WithEvents ButLoadConf As System.Windows.Forms.Button
  Friend WithEvents ButDefConf As System.Windows.Forms.Button
End Class
