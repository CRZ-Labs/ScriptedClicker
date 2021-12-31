Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32
Module General
    Public DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\ScriptedClicker"
End Module
Module Utility
    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim finalContent As String = Nothing
            If flag = True Then
                finalContent = " [!!!]"
            End If
            Dim Message As String = DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy") & finalContent & " [" & from & "] " & content
            Console.WriteLine("[" & from & "]" & finalContent & " " & content)
            Try
                My.Computer.FileSystem.WriteAllText(DIRCommons & "\ScriptedClicker.log", vbCrLf & Message, True)
            Catch
            End Try
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Utility]Error: " & ex.Message)
        End Try
    End Sub
    <DllImport("kernel32")>
    Private Function GetPrivateProfileString(ByVal section As String, ByVal key As String, ByVal def As String, ByVal retVal As StringBuilder, ByVal size As Integer, ByVal filePath As String) As Integer
        'Use GetIniValue("KEY_HERE", "SubKEY_HERE", "filepath")
    End Function
    Public Function GetIniValue(section As String, key As String, filename As String, Optional defaultValue As String = Nothing) As String
        Dim sb As New StringBuilder(500)
        If GetPrivateProfileString(section, key, defaultValue, sb, sb.Capacity, filename) > 0 Then
            Return sb.ToString
        Else
            Return defaultValue
        End If
    End Function

    Sub FileAsociation_Manager(ByVal active As Boolean)
        Try
            Dim Ruta As String = "SOFTWARE\\Classes\\.sclk"
            Dim RutaIcon As String = Ruta & "\\DefaultIcon"
            Dim RutaShell As String = Ruta & "\\shell"
            Dim RutaShell_open As String = RutaShell & "\\open"
            Dim RutaShell_command As String = RutaShell_open & "\\command"

            Dim RegeditWriter1 As RegistryKey
            If active Then
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(Ruta)
                    Registry.CurrentUser.CreateSubKey(RutaIcon)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(Ruta, True)
                End If
                RegeditWriter1.SetValue("", "ScriptedClicker script", RegistryValueKind.String)

                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaIcon, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(RutaIcon)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaIcon, True)
                End If
                RegeditWriter1.SetValue("", DIRCommons & "\fileIcon.ico", RegistryValueKind.String)

                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(RutaShell)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell, True)
                End If
                RegeditWriter1.SetValue("", "open", RegistryValueKind.String)

                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell_open, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(RutaShell_open)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell_open, True)
                End If
                RegeditWriter1.SetValue("", "Open with ScriptedClicker", RegistryValueKind.String)

                RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell_command, True)
                If RegeditWriter1 Is Nothing Then
                    Registry.CurrentUser.CreateSubKey(RutaShell_command)
                    RegeditWriter1 = Registry.CurrentUser.OpenSubKey(RutaShell_command, True)
                End If
                RegeditWriter1.SetValue("", Application.ExecutablePath & " " & """" & "%1" & """", RegistryValueKind.String)
            Else
                RegeditWriter1 = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes", True)
                RegeditWriter1.DeleteSubKeyTree(".sclk")
            End If
        Catch ex As Exception
            AddToLog("FileAsociation_Manager@Utility", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub Timer_XYCursor_Manager()
        Try
            If Main.Timer_CursorPos.Enabled = True Then
                Main.Timer_CursorPos.Enabled = False
                Main.lblDetectStop.Text = "Detectar"
            Else
                Main.Timer_CursorPos.Enabled = True
                Main.lblDetectStop.Text = "Parar"
            End If
        Catch ex As Exception
            AddToLog("Timer_XYCursor@Utility", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module
Module StartUp
    Sub Init()
        Try
            CommonActions()
            FileAsociation_Manager(True)
            ExtractTheIcons()
        Catch ex As Exception
            AddToLog("Init@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CommonActions()
        Try
            If Not My.Computer.FileSystem.DirectoryExists(DIRCommons) Then
                My.Computer.FileSystem.CreateDirectory(DIRCommons)
            End If
        Catch ex As Exception
            AddToLog("CommonActions@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ExtractTheIcons()
        Try
            If My.Computer.FileSystem.FileExists(DIRCommons & "\fileIcon.ico") = False Then
                Using stream As New FileStream(DIRCommons & "\fileIcon.ico", FileMode.Create, FileAccess.Write, FileShare.None), ico = TryCast(My.Resources.ResourceManager.GetObject("fileIcon"), Icon)
                    ico.Save(stream)
                End Using
            End If
            If My.Computer.FileSystem.FileExists(DIRCommons & "\appIcon.ico") = False Then
                Using stream As New FileStream(DIRCommons & "\appIcon.ico", FileMode.Create, FileAccess.Write, FileShare.None), ico = TryCast(My.Resources.ResourceManager.GetObject("AppIcon"), Icon)
                    ico.Save(stream)
                End Using
            End If
        Catch ex As Exception
            AddToLog("ExtractTheIcons@StartUp", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module
Module ScriptedClickerFile
    Public file_Prop_ScriptName As String
    Public file_Prop_ScriptVersion As String
    Public file_Prop_ScriptAuthor As String
    Public file_Prop_Created As String
    Public file_Prop_Version As String

    Public file_Set_Count As Integer
    Public file_Set_Repeat As Boolean

    Public RawFileScript As New ArrayList

    Sub OpenClickerFile(ByVal filePath As String)
        Try
            Main.lbInstructions.Items.Clear()
            RawFileScript.Clear()
            file_Prop_ScriptName = GetIniValue("Properties", "ScriptName", filePath)
            file_Prop_ScriptVersion = GetIniValue("Properties", "ScriptVersion", filePath)
            file_Prop_ScriptAuthor = GetIniValue("Properties", "ScriptAuthor", filePath)
            file_Prop_Created = GetIniValue("Properties", "Created", filePath)
            file_Prop_Version = GetIniValue("Properties", "Version", filePath)

            file_Set_Count = Integer.Parse(GetIniValue("Settings", "Count", filePath))
            file_Set_Repeat = Boolean.Parse(GetIniValue("Settings", "Repeat", filePath))
            Main.cbRepeat.Checked = file_Set_Repeat
            Main.Text = file_Prop_ScriptName & " (v" & file_Prop_ScriptVersion & ") by " & file_Prop_ScriptAuthor & " | ScriptedClicker"

            Dim indice As Integer = 0
            While indice < file_Set_Count
                Dim formatString As String = GetIniValue("Script", "SCLK_" & indice, filePath)
                Dim argsFormatString As String() = formatString.Split(",")
                Main.lbInstructions.Items.Add(indice & ") " & argsFormatString(0) & "," & argsFormatString(1) & " Click: " & argsFormatString(2) & " Hold: " & argsFormatString(3) & " Release: " & argsFormatString(4) & " Delay: " & argsFormatString(5))
                RawFileScript.Add(formatString)
                indice += 1
            End While
            Main.btnPrevious.Enabled = False
            If Main.lbInstructions.Items.Count = 0 Then
                Main.btnNext.Text = "+"
            Else
                Main.btnNext.Text = ">"
                Main.lbInstructions.SelectedIndex = 0
            End If
        Catch ex As Exception
            AddToLog("OpenClickerFile@ScriptedClickerFile", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SaveClickerFile(ByVal filePath As String)
        Try
            If My.Computer.FileSystem.FileExists(filePath) Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If

            Dim PedirTitulo = InputBox("Ingrese el titulo de su script", "Titulo Script", file_Prop_ScriptName)
            If PedirTitulo <> Nothing Then
                file_Prop_ScriptName = PedirTitulo
            Else
                file_Prop_ScriptName = "Script sin titulo"
            End If
            If file_Prop_ScriptAuthor = Nothing Then
                file_Prop_ScriptAuthor = Environment.UserName
            End If
            If file_Prop_Created = Nothing Then
                file_Prop_Created = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt")
            End If
            Dim fileContent As String = "# ScriptedClicker File" &
                vbCrLf & "[Properties]" &
                vbCrLf & "ScriptName=" & file_Prop_ScriptName &
                vbCrLf & "ScriptVersion=" & Val(file_Prop_ScriptVersion + 1) &
                vbCrLf & "ScriptAuthor=" & file_Prop_ScriptAuthor &
                vbCrLf & "Created=" & file_Prop_Created &
                vbCrLf & "Version=" & My.Application.Info.Version.ToString &
                vbCrLf & "[Settings]" &
                vbCrLf & "Count=" & Main.lbInstructions.Items.Count &
                vbCrLf & "Repeat=" & Main.cbRepeat.Checked &
                vbCrLf & "[Script]"

            My.Computer.FileSystem.WriteAllText(filePath, fileContent, False)

            Dim index As Integer = 0
            For Each item As String In RawFileScript
                My.Computer.FileSystem.WriteAllText(filePath, vbCrLf & "SCLK_" & index & "=" & item.Trim(), True)
                index += 1
            Next

            OpenClickerFile(filePath)
        Catch ex As Exception
            AddToLog("SaveClickerFile@ScriptedClickerFile", "Error: " & ex.Message, True)
        End Try
    End Sub
End Module