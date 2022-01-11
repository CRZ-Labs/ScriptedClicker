Public Class Main
    Dim threadClicker As Threading.Thread
    Private Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Private Const MOUSEEVENTF_LEFTUP As Integer = &H4
    Private Const MOUSEEVENTF_RIGHTDOWN As Integer = &H8
    Private Const MOUSEEVENTF_RIGHTUP As Integer = &H10
    Public Declare Sub mouse_event Lib "user32" (dwFlags As Integer, dx As Integer, dy As Integer, cButtons As Integer, dwExtraInfo As Integer)

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CheckForIllegalCrossThreadCalls = False
            Init()
            LINEA = pbAngleAndColor.CreateGraphics
            LAPIZ = New Pen(Brushes.Yellow, 5)
            LINEA.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            ReadParameters(Command())
        Catch ex As Exception
            AddToLog("Main_Load@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("¿Seguro que desea salir?", "Confirmar salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub
    Private Sub Main_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        If MessageBox.Show("Desarrollado por CRZ Labs." & vbCrLf & "¿Visitar perfil y repositorio?", "Créditos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Process.Start("https://github.com/CRZ-Labs")
            Process.Start("https://github.com/CRZ-Labs/ScriptedClicker")
        End If
    End Sub
    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.ControlKey Then
            Timer_XYCursor_Manager()
        End If
    End Sub

    Sub ReadParameters(ByVal parametro As String)
        Try
            If parametro <> Nothing Then
                parametro = parametro.Replace("""", Nothing)
                For i As Integer = 0 To My.Application.CommandLineArgs.Count - 1
                    Dim parameter As String = My.Application.CommandLineArgs(i)
                    If parameter Like "*.sclk" Then
                        OpenClickerFile(parameter)
                    ElseIf parameter Like "*-start*" Then
                        StartScriptedProcessor()
                    ElseIf parameter Like "*-repeat*" Then
                        cbRepeat.Checked = True
                    ElseIf parameter Like "*-norepeat*" Then
                        cbRepeat.Checked = False
                    ElseIf parameter Like "*-hide*" Then
                        Me.Hide()
                    End If
                Next
            End If
        Catch ex As Exception
            AddToLog("ReadParameters@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub lblStartStopDetectingCursorPos_Click(sender As Object, e As EventArgs) Handles lblDetectStop.Click
        If Timer_CursorPos.Enabled = False Then
            lblDetectStop.Text = "Parar"
            Timer_CursorPos.Enabled = True
        Else
            lblDetectStop.Text = "Detectar"
            Timer_CursorPos.Enabled = False
        End If
    End Sub
    Private Sub Timer_CursorPos_Tick(sender As Object, e As EventArgs) Handles Timer_CursorPos.Tick
        tbCoords.Text = MousePosition.X & "," & MousePosition.Y
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            If lbInstructions.SelectedIndex > 0 Then
                RawFileScript.RemoveAt(lbInstructions.SelectedIndex)
                lbInstructions.Items.RemoveAt(lbInstructions.SelectedIndex)
            End If
        Catch ex As Exception
            AddToLog("btnPrevious_Click@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If btnNext.Text = ">" Then
                If lbInstructions.SelectedIndex = lbInstructions.Items.Count - 1 Then
                    btnNext.Text = "+"
                Else
                    btnPrevious.Enabled = True
                    btnNext.Text = ">"
                    lbInstructions.SelectedIndex = lbInstructions.SelectedIndex + 1
                End If
            Else
                Dim clickType As SByte = 0
                If rbDERClick.Checked Then
                    clickType = 1
                Else
                    clickType = 0
                End If
                lbInstructions.Items.Add(lbInstructions.Items.Count & ") " & tbCoords.Text & " Click: " & clickType & " Hold: " & cbHold.Checked & " Release: " & cbRelease.Checked & " Delay: " & tbDelay.Text)
                RawFileScript.Add(tbCoords.Text & "," & clickType & "," & cbHold.Checked & "," & cbRelease.Checked & "," & tbDelay.Text)
                btnNext.Text = ">"
            End If
        Catch ex As Exception
            AddToLog("btnNext_Click@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnSaveFile_Click(sender As Object, e As EventArgs) Handles btnSaveFile.Click
        Dim SaveFile As New SaveFileDialog
        SaveFile.Filter = "Scripted Clicker File (*.sclk)|*.sclk|All file types (*.*)|*.*"
        SaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        SaveFile.Title = "Save file..."
        If SaveFile.ShowDialog() = DialogResult.OK Then
            SaveClickerFile(SaveFile.FileName)
        End If
    End Sub
    Private Sub btnLoadFile_Click(sender As Object, e As EventArgs) Handles btnLoadFile.Click
        Dim OpenFile As New OpenFileDialog
        OpenFile.Filter = "Scripted Clicker File (*.sclk)|*.sclk|All file types (*.*)|*.*"
        OpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        OpenFile.Title = "Load file..."
        If OpenFile.ShowDialog() = DialogResult.OK Then
            OpenClickerFile(OpenFile.FileName)
        End If
    End Sub

    Private Sub lbInstructions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbInstructions.SelectedIndexChanged
        Try
            Dim formatString As String() = RawFileScript(lbInstructions.SelectedIndex).Split(",")
            tbCoords.Text = formatString(0) & "," & formatString(1)
            Dim clickType As SByte = formatString(2)
            If clickType = 1 Then
                rbDERClick.Checked = True
            Else
                rbIZQClick.Checked = True
            End If
            cbHold.Checked = Boolean.Parse(formatString(3))
            cbRelease.Checked = Boolean.Parse(formatString(4))
            tbDelay.Text = formatString(5)
        Catch ex As Exception
            AddToLog("lbInstructions_SelectedIndexChanged@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub lbInstructions_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lbInstructions.MouseDoubleClick
        Dim item As String = RawFileScript(lbInstructions.SelectedIndex)
        Dim items As String() = item.Split(",")
        Cursor.Position = New Point(items(0), items(1))
    End Sub
    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        StartScriptedProcessor()
    End Sub

    Sub StartScriptedProcessor()
        Try
            If btnStartStop.Text = "Start" Then
                btnStartStop.Text = "Abort"
                threadClicker = New Threading.Thread(AddressOf ScriptedProcessor)
                threadClicker.Start()
            Else
                btnStartStop.Text = "Start"
                threadClicker.Abort()
            End If
        Catch ex As Exception
            AddToLog("btnStartStop_Click@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ScriptedProcessor()
        Try
            Dim indice As Integer = 0
            Dim iteraciones As Integer = lbInstructions.Items.Count
            Dim doRepeat As Boolean = False
            While indice < iteraciones
                If cbRepeat.Checked Then
                    If indice = (iteraciones - 1) Then
                        doRepeat = True
                    End If
                End If
                Dim item As String = RawFileScript(indice)
                'Procesa la linea
                lbInstructions.SelectedIndex = indice
                'Pone el string en objeto tipo lista
                Dim items As String() = item.Split(",")
                'Obtiene las coordenadas
                Dim posXY As String = items(0) & "," & items(1) 'X,Y
                'Obtiene el tipo de click (der 1 o izq 0)
                Dim clickType As SByte = items(2) '0 o 1
                'Obtiene el valor de mantener o no el click
                Dim MustHold As Boolean = Boolean.Parse(items(3))
                'Ve si debe limpiar
                Dim MustRelease As Boolean = Boolean.Parse(items(4))
                'Obtiene el delays
                Dim Delay As Integer = Integer.Parse(items(5))
                'PROCESA los valores
                '   mueve el cursor
                Cursor.Position = New Point(items(0), items(1))
                '   identifica el click
                If clickType = 0 Then
                    ClickIzquierdo(posXY, MustHold, MustRelease)
                Else
                    ClickDerecho(posXY, MustHold, MustRelease)
                End If

                indice += 1
                'Pone a dormir el thread segun el delay
                Threading.Thread.Sleep(Delay)
                If doRepeat Then
                    indice = 0
                End If
            End While
        Catch ex As Exception
            AddToLog("ScriptedProcessor@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ClickDerecho(ByVal ubicaciones As String, ByVal hold As Boolean, ByVal release As Boolean)
        Try
            Dim posiciones As String() = ubicaciones.Split(",")
            If hold Then
                mouse_event(MOUSEEVENTF_RIGHTDOWN, posiciones(0), posiciones(1), 0, 0) 'preciona
            End If
            Threading.Thread.Sleep(150)
            If release Then
                mouse_event(MOUSEEVENTF_RIGHTUP, posiciones(0), posiciones(1), 0, 0) 'suelta
            End If
        Catch ex As Exception
            AddToLog("[ClickDerecho@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ClickIzquierdo(ByVal ubicaciones As String, ByVal hold As Boolean, ByVal release As Boolean)
        Try
            Dim posiciones As String() = ubicaciones.Split(",")
            If hold Then
                mouse_event(MOUSEEVENTF_LEFTDOWN, posiciones(0), posiciones(1), 0, 0) 'preciona
            End If
            Threading.Thread.Sleep(150)
            If release Then
                mouse_event(MOUSEEVENTF_LEFTUP, posiciones(0), posiciones(1), 0, 0) 'suelta
            End If
        Catch ex As Exception
            AddToLog("ClickIzquierdo@Main", "Error: " & ex.Message, True)
        End Try
    End Sub

#Region "lujo"
    Dim LAPIZ As Pen
    Dim LINEA As Graphics
    Dim BM As New Bitmap(Screen.AllScreens.Sum(Function(s As Screen) s.Bounds.Width),
                        Screen.AllScreens.Max(Function(s As Screen) s.Bounds.Height))
    Dim DIBUJO As Graphics = Graphics.FromImage(BM)
    Dim MICOLOR As Color
    Private Sub Timer_CursorInfo_Tick(sender As Object, e As EventArgs) Handles Timer_CursorInfo.Tick
        getangulo()
        getColor()
    End Sub
    Sub getColor()
        Try
            DIBUJO.CopyFromScreen(SystemInformation.VirtualScreen.X,
                       SystemInformation.VirtualScreen.Y,
                       0, 0, SystemInformation.VirtualScreen.Size)
            MICOLOR = BM.GetPixel(Cursor.Position.X, Cursor.Position.Y)
            pbAngleAndColor.BackColor = Color.FromArgb(MICOLOR.A * 0.99, MICOLOR.R, MICOLOR.G, MICOLOR.B)
        Catch ex As Exception
            AddToLog("getColor@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub getangulo()
        Try
            Dim FINX As Integer = Cursor.Position.X
            Dim FINY As Integer = Cursor.Position.Y
            Dim CEROX As Integer = Me.Location.X + 8 + pbAngleAndColor.Location.X + pbAngleAndColor.Width / 2
            Dim CEROY As Integer = Me.Location.Y + 30 + pbAngleAndColor.Location.Y + pbAngleAndColor.Height / 2
            Dim ATAN As Single = Math.Round(Math.Atan((CEROY - FINY) / (FINX - CEROX)) * 57.3, 1)
            If FINX = CEROX And FINY > CEROY Then
                ATAN = 270
            ElseIf FINX < CEROX And FINY = CEROY Then
                ATAN = 180
            ElseIf FINX > CEROX And FINY > CEROY Then
                ATAN += 360
            ElseIf FINX < CEROX And FINY > CEROY Then
                ATAN += 180
            ElseIf FINX < CEROX And FINY < CEROY Then
                ATAN += 180
            End If
            pbAngleAndColor.Refresh()
            Dim CORRECX As Integer = FINX - (Me.Location.X + 8 + pbAngleAndColor.Location.X)
            Dim CORRECY As Integer = FINY - (Me.Location.Y + 30 + pbAngleAndColor.Location.Y)
            LINEA.DrawLine(LAPIZ, CInt(pbAngleAndColor.Width / 2), CInt(pbAngleAndColor.Width / 2), CORRECX, CORRECY)
        Catch ex As Exception
            AddToLog("getangulo@Main", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
End Class