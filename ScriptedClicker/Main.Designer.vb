<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.GroupBox_General = New System.Windows.Forms.GroupBox()
        Me.btnStartStop = New System.Windows.Forms.Button()
        Me.cbRepeat = New System.Windows.Forms.CheckBox()
        Me.btnLoadFile = New System.Windows.Forms.Button()
        Me.btnSaveFile = New System.Windows.Forms.Button()
        Me.GroupBox_MouseOptions = New System.Windows.Forms.GroupBox()
        Me.cbRelease = New System.Windows.Forms.CheckBox()
        Me.lblDelay = New System.Windows.Forms.Label()
        Me.cbHold = New System.Windows.Forms.CheckBox()
        Me.rbIZQClick = New System.Windows.Forms.RadioButton()
        Me.tbDelay = New System.Windows.Forms.TextBox()
        Me.rbDERClick = New System.Windows.Forms.RadioButton()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.lblDetectStopInfo = New System.Windows.Forms.Label()
        Me.lblDetectStop = New System.Windows.Forms.Label()
        Me.pbAngleAndColor = New System.Windows.Forms.PictureBox()
        Me.tbCoords = New System.Windows.Forms.TextBox()
        Me.Timer_CursorPos = New System.Windows.Forms.Timer(Me.components)
        Me.lbInstructions = New System.Windows.Forms.ListBox()
        Me.Timer_CursorInfo = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox_General.SuspendLayout()
        Me.GroupBox_MouseOptions.SuspendLayout()
        CType(Me.pbAngleAndColor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox_General
        '
        Me.GroupBox_General.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_General.Controls.Add(Me.btnStartStop)
        Me.GroupBox_General.Controls.Add(Me.cbRepeat)
        Me.GroupBox_General.Controls.Add(Me.btnLoadFile)
        Me.GroupBox_General.Controls.Add(Me.btnSaveFile)
        Me.GroupBox_General.Controls.Add(Me.GroupBox_MouseOptions)
        Me.GroupBox_General.Controls.Add(Me.btnNext)
        Me.GroupBox_General.Controls.Add(Me.btnPrevious)
        Me.GroupBox_General.Controls.Add(Me.lblDetectStopInfo)
        Me.GroupBox_General.Controls.Add(Me.lblDetectStop)
        Me.GroupBox_General.Controls.Add(Me.pbAngleAndColor)
        Me.GroupBox_General.Controls.Add(Me.tbCoords)
        Me.GroupBox_General.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox_General.Name = "GroupBox_General"
        Me.GroupBox_General.Size = New System.Drawing.Size(455, 312)
        Me.GroupBox_General.TabIndex = 0
        Me.GroupBox_General.TabStop = False
        '
        'btnStartStop
        '
        Me.btnStartStop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnStartStop.Location = New System.Drawing.Point(164, 283)
        Me.btnStartStop.Name = "btnStartStop"
        Me.btnStartStop.Size = New System.Drawing.Size(126, 23)
        Me.btnStartStop.TabIndex = 10
        Me.btnStartStop.Text = "Start"
        Me.btnStartStop.UseVisualStyleBackColor = True
        '
        'cbRepeat
        '
        Me.cbRepeat.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.cbRepeat.AutoSize = True
        Me.cbRepeat.Location = New System.Drawing.Point(296, 287)
        Me.cbRepeat.Name = "cbRepeat"
        Me.cbRepeat.Size = New System.Drawing.Size(60, 17)
        Me.cbRepeat.TabIndex = 9
        Me.cbRepeat.Text = "Repetir"
        Me.cbRepeat.UseVisualStyleBackColor = True
        Me.cbRepeat.Visible = False
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(6, 283)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadFile.TabIndex = 8
        Me.btnLoadFile.Text = "Cargar"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'btnSaveFile
        '
        Me.btnSaveFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveFile.Location = New System.Drawing.Point(374, 283)
        Me.btnSaveFile.Name = "btnSaveFile"
        Me.btnSaveFile.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveFile.TabIndex = 7
        Me.btnSaveFile.Text = "Guardar"
        Me.btnSaveFile.UseVisualStyleBackColor = True
        '
        'GroupBox_MouseOptions
        '
        Me.GroupBox_MouseOptions.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox_MouseOptions.Controls.Add(Me.cbRelease)
        Me.GroupBox_MouseOptions.Controls.Add(Me.lblDelay)
        Me.GroupBox_MouseOptions.Controls.Add(Me.cbHold)
        Me.GroupBox_MouseOptions.Controls.Add(Me.rbIZQClick)
        Me.GroupBox_MouseOptions.Controls.Add(Me.tbDelay)
        Me.GroupBox_MouseOptions.Controls.Add(Me.rbDERClick)
        Me.GroupBox_MouseOptions.Location = New System.Drawing.Point(127, 180)
        Me.GroupBox_MouseOptions.Name = "GroupBox_MouseOptions"
        Me.GroupBox_MouseOptions.Size = New System.Drawing.Size(200, 97)
        Me.GroupBox_MouseOptions.TabIndex = 6
        Me.GroupBox_MouseOptions.TabStop = False
        '
        'cbRelease
        '
        Me.cbRelease.AutoSize = True
        Me.cbRelease.Location = New System.Drawing.Point(110, 42)
        Me.cbRelease.Name = "cbRelease"
        Me.cbRelease.Size = New System.Drawing.Size(58, 17)
        Me.cbRelease.TabIndex = 11
        Me.cbRelease.Text = "Liberar"
        Me.cbRelease.UseVisualStyleBackColor = True
        '
        'lblDelay
        '
        Me.lblDelay.AutoSize = True
        Me.lblDelay.Location = New System.Drawing.Point(27, 68)
        Me.lblDelay.Name = "lblDelay"
        Me.lblDelay.Size = New System.Drawing.Size(40, 13)
        Me.lblDelay.TabIndex = 8
        Me.lblDelay.Text = "Delay: "
        '
        'cbHold
        '
        Me.cbHold.AutoSize = True
        Me.cbHold.Location = New System.Drawing.Point(33, 42)
        Me.cbHold.Name = "cbHold"
        Me.cbHold.Size = New System.Drawing.Size(71, 17)
        Me.cbHold.TabIndex = 2
        Me.cbHold.Text = "Mantener"
        Me.cbHold.UseVisualStyleBackColor = True
        '
        'rbIZQClick
        '
        Me.rbIZQClick.AutoSize = True
        Me.rbIZQClick.Location = New System.Drawing.Point(6, 19)
        Me.rbIZQClick.Name = "rbIZQClick"
        Me.rbIZQClick.Size = New System.Drawing.Size(93, 17)
        Me.rbIZQClick.TabIndex = 1
        Me.rbIZQClick.TabStop = True
        Me.rbIZQClick.Text = "Click izquierdo"
        Me.rbIZQClick.UseVisualStyleBackColor = True
        '
        'tbDelay
        '
        Me.tbDelay.Location = New System.Drawing.Point(73, 65)
        Me.tbDelay.Name = "tbDelay"
        Me.tbDelay.Size = New System.Drawing.Size(100, 20)
        Me.tbDelay.TabIndex = 7
        Me.tbDelay.Text = "1000"
        '
        'rbDERClick
        '
        Me.rbDERClick.AutoSize = True
        Me.rbDERClick.Checked = True
        Me.rbDERClick.Location = New System.Drawing.Point(105, 19)
        Me.rbDERClick.Name = "rbDERClick"
        Me.rbDERClick.Size = New System.Drawing.Size(90, 17)
        Me.rbDERClick.TabIndex = 0
        Me.rbDERClick.TabStop = True
        Me.rbDERClick.Text = "Click derecho"
        Me.rbDERClick.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnNext.Location = New System.Drawing.Point(288, 55)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(36, 74)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnPrevious.Location = New System.Drawing.Point(130, 55)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(36, 74)
        Me.btnPrevious.TabIndex = 4
        Me.btnPrevious.Text = "-"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'lblDetectStopInfo
        '
        Me.lblDetectStopInfo.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDetectStopInfo.AutoSize = True
        Me.lblDetectStopInfo.ForeColor = System.Drawing.Color.Silver
        Me.lblDetectStopInfo.Location = New System.Drawing.Point(149, 158)
        Me.lblDetectStopInfo.Name = "lblDetectStopInfo"
        Me.lblDetectStopInfo.Size = New System.Drawing.Size(78, 13)
        Me.lblDetectStopInfo.TabIndex = 3
        Me.lblDetectStopInfo.Text = "CTRL para fijar"
        '
        'lblDetectStop
        '
        Me.lblDetectStop.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblDetectStop.AutoSize = True
        Me.lblDetectStop.ForeColor = System.Drawing.Color.Gray
        Me.lblDetectStop.Location = New System.Drawing.Point(255, 158)
        Me.lblDetectStop.Name = "lblDetectStop"
        Me.lblDetectStop.Size = New System.Drawing.Size(48, 13)
        Me.lblDetectStop.TabIndex = 2
        Me.lblDetectStop.Text = "Detectar"
        '
        'pbAngleAndColor
        '
        Me.pbAngleAndColor.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.pbAngleAndColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAngleAndColor.Location = New System.Drawing.Point(172, 19)
        Me.pbAngleAndColor.Name = "pbAngleAndColor"
        Me.pbAngleAndColor.Size = New System.Drawing.Size(110, 110)
        Me.pbAngleAndColor.TabIndex = 1
        Me.pbAngleAndColor.TabStop = False
        '
        'tbCoords
        '
        Me.tbCoords.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.tbCoords.Location = New System.Drawing.Point(152, 135)
        Me.tbCoords.Name = "tbCoords"
        Me.tbCoords.Size = New System.Drawing.Size(151, 20)
        Me.tbCoords.TabIndex = 0
        Me.tbCoords.Text = "0,0"
        Me.tbCoords.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Timer_CursorPos
        '
        '
        'lbInstructions
        '
        Me.lbInstructions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbInstructions.FormattingEnabled = True
        Me.lbInstructions.Location = New System.Drawing.Point(12, 330)
        Me.lbInstructions.Name = "lbInstructions"
        Me.lbInstructions.Size = New System.Drawing.Size(455, 134)
        Me.lbInstructions.TabIndex = 1
        '
        'Timer_CursorInfo
        '
        Me.Timer_CursorInfo.Enabled = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 476)
        Me.Controls.Add(Me.lbInstructions)
        Me.Controls.Add(Me.GroupBox_General)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(335, 515)
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScriptedClicker"
        Me.GroupBox_General.ResumeLayout(False)
        Me.GroupBox_General.PerformLayout()
        Me.GroupBox_MouseOptions.ResumeLayout(False)
        Me.GroupBox_MouseOptions.PerformLayout()
        CType(Me.pbAngleAndColor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox_General As GroupBox
    Friend WithEvents tbCoords As TextBox
    Friend WithEvents lblDetectStopInfo As Label
    Friend WithEvents lblDetectStop As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents GroupBox_MouseOptions As GroupBox
    Friend WithEvents rbIZQClick As RadioButton
    Friend WithEvents rbDERClick As RadioButton
    Friend WithEvents cbHold As CheckBox
    Friend WithEvents lblDelay As Label
    Friend WithEvents tbDelay As TextBox
    Friend WithEvents Timer_CursorPos As Timer
    Friend WithEvents lbInstructions As ListBox
    Friend WithEvents btnLoadFile As Button
    Friend WithEvents btnSaveFile As Button
    Friend WithEvents cbRepeat As CheckBox
    Friend WithEvents pbAngleAndColor As PictureBox
    Friend WithEvents Timer_CursorInfo As Timer
    Friend WithEvents btnStartStop As Button
    Friend WithEvents cbRelease As CheckBox
End Class
