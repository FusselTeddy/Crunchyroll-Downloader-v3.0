﻿Option Strict On
Imports Crunchyroll_Downloader.CRD_Classes
Imports MetroFramework
Imports MetroFramework.Components

Public Class Error_msg

    Dim Manager As MetroStyleManager = Main.Manager

    Private Sub Btn_Close_MouseEnter(sender As Object, e As EventArgs) Handles Btn_Close.MouseEnter, Btn_Close.GotFocus
        If Manager.Theme = MetroThemeStyle.Dark Then
            Btn_Close.Image = My.Resources.main_close_dark_hover
        Else
            Btn_Close.Image = My.Resources.main_close_hover
        End If
    End Sub

    Private Sub Btn_Close_MouseLeave(sender As Object, e As EventArgs) Handles Btn_Close.MouseLeave, Btn_Close.LostFocus
        Btn_Close.Image = Main.CloseImg
    End Sub

    Private Sub Btn_Close_Click(sender As Object, e As EventArgs) Handles Btn_Close.Click
        Me.Close()
    End Sub

    Private Sub Error_msg_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Btn_Close.Location = New Point(Me.Width - 36, 1)

    End Sub

    Private Sub btn_cl_Click(sender As Object, e As EventArgs) Handles btn_cl.Click
        If Me.Height = 500 Then
            Me.Height = 275
        Else
            Me.Height = 500
        End If
    End Sub
    Private Sub Reso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Manager.Owner = Me
        Me.StyleManager = Manager

        Btn_Close.Image = Main.CloseImg

        Try
            Me.Icon = My.Resources.icon
        Catch ex As Exception

        End Try

        Me.Location = New Point(CInt(Main.Location.X + Main.Width / 2 - Me.Width / 2), CInt(Main.Location.Y + Main.Height / 2 - Me.Height / 2))
        ErrorText.TextAlign = HorizontalAlignment.Center
    End Sub

    Public Sub ShowErrorDia(ByVal Details As String, ShortError As String, Optional ByVal ThirdOption As String = "None")
        Me.Show()
        ErrorBox.Text = Details
        ErrorText.Text = ShortError

        If ThirdOption = "None" Then
            btn_option.BackgroundImage = My.Resources.error_dis
            btn_option.Cursor = Cursors.No
            btn_option.Enabled = False
        ElseIf ThirdOption = "Ignore" Then
            AddHandler btn_option.Click, AddressOf Ignore
        ElseIf ThirdOption = "Help" Then
            AddHandler btn_option.Click, AddressOf MoreInfo
            btn_option.Text = "More Info"
        End If

    End Sub

    Private Sub btn_ok_Click(sender As Object, e As EventArgs) Handles btn_ok.Click
        Me.Close()
    End Sub


    Private Sub Btn_ok_MouseEnter(sender As Object, e As EventArgs) Handles btn_ok.MouseEnter
        btn_ok.BackgroundImage = My.Resources.ffmpeg_OK_cL_hover
    End Sub

    Private Sub Btn_ok_MouseLeave(sender As Object, e As EventArgs) Handles btn_ok.MouseLeave
        btn_ok.BackgroundImage = My.Resources.ffmpeg_OK_cL
    End Sub

    Private Sub Btn_cl_MouseEnter(sender As Object, e As EventArgs) Handles btn_cl.MouseEnter
        btn_cl.BackgroundImage = My.Resources.ffmpeg_OK_cL_hover
    End Sub

    Private Sub Btn_cl_MouseLeave(sender As Object, e As EventArgs) Handles btn_cl.MouseLeave
        btn_cl.BackgroundImage = My.Resources.ffmpeg_OK_cL
    End Sub
    Private Sub Btn_ign_MouseEnter(sender As Object, e As EventArgs) Handles btn_option.MouseEnter
        btn_option.BackgroundImage = My.Resources.ffmpeg_OK_cL_hover
    End Sub

    Private Sub Btn_ign_MouseLeave(sender As Object, e As EventArgs) Handles btn_option.MouseLeave
        btn_option.BackgroundImage = My.Resources.ffmpeg_OK_cL
    End Sub

    Private Sub Ignore(sender As Object, e As EventArgs) 'Handles btn_ign.Click
        Main.IgnoreErrorDia = True
        Me.Close()
    End Sub
    Private Sub MoreInfo(sender As Object, e As EventArgs) 'Handles btn_ign.Click
        Process.Start("https://github.com/hama3254/Crunchyroll-Downloader-v3.0/issues/929")
        'Main.IgnoreErrorDia = True
        'Me.Close()
    End Sub
End Class