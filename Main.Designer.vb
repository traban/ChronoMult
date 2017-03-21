<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
    Me.Timer = New System.Windows.Forms.Timer(Me.components)
    Me.ButStart = New System.Windows.Forms.Button()
    Me.ButConf = New System.Windows.Forms.Button()
    Me.ButClrBest = New System.Windows.Forms.Button()
    Me.CheckSimu = New System.Windows.Forms.CheckBox()
    Me.ButQuit = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Timer
    '
    '
    'ButStart
    '
    Me.ButStart.Location = New System.Drawing.Point(651, 89)
    Me.ButStart.Name = "ButStart"
    Me.ButStart.Size = New System.Drawing.Size(75, 23)
    Me.ButStart.TabIndex = 1
    Me.ButStart.Text = "Restart"
    Me.ButStart.UseVisualStyleBackColor = True
    '
    'ButConf
    '
    Me.ButConf.Location = New System.Drawing.Point(632, 51)
    Me.ButConf.Name = "ButConf"
    Me.ButConf.Size = New System.Drawing.Size(106, 21)
    Me.ButConf.TabIndex = 2
    Me.ButConf.Text = "Configuration"
    Me.ButConf.UseVisualStyleBackColor = True
    '
    'ButClrBest
    '
    Me.ButClrBest.Location = New System.Drawing.Point(655, 130)
    Me.ButClrBest.Name = "ButClrBest"
    Me.ButClrBest.Size = New System.Drawing.Size(70, 25)
    Me.ButClrBest.TabIndex = 3
    Me.ButClrBest.Text = "Clear Best"
    Me.ButClrBest.UseVisualStyleBackColor = True
    '
    'CheckSimu
    '
    Me.CheckSimu.AutoSize = True
    Me.CheckSimu.Location = New System.Drawing.Point(630, 175)
    Me.CheckSimu.Name = "CheckSimu"
    Me.CheckSimu.Size = New System.Drawing.Size(74, 17)
    Me.CheckSimu.TabIndex = 4
    Me.CheckSimu.Text = "Simulation"
    Me.CheckSimu.UseVisualStyleBackColor = True
    '
    'ButQuit
    '
    Me.ButQuit.Location = New System.Drawing.Point(634, 449)
    Me.ButQuit.Name = "ButQuit"
    Me.ButQuit.Size = New System.Drawing.Size(69, 36)
    Me.ButQuit.TabIndex = 5
    Me.ButQuit.Text = "Quit"
    Me.ButQuit.UseVisualStyleBackColor = True
    '
    'Main
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(751, 622)
    Me.ControlBox = False
    Me.Controls.Add(Me.ButQuit)
    Me.Controls.Add(Me.CheckSimu)
    Me.Controls.Add(Me.ButClrBest)
    Me.Controls.Add(Me.ButConf)
    Me.Controls.Add(Me.ButStart)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Main"
    Me.Text = "Chrono"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Timer As System.Windows.Forms.Timer
  Friend WithEvents ButStart As System.Windows.Forms.Button
  Friend WithEvents ButConf As System.Windows.Forms.Button
  Friend WithEvents ButClrBest As System.Windows.Forms.Button
  Friend WithEvents CheckSimu As System.Windows.Forms.CheckBox
  Friend WithEvents ButQuit As System.Windows.Forms.Button

End Class
