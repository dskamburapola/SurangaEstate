
Public Class frmLogin

#Region "Variables"
    Private _CWBUserLogins As iStockCommon.iStockUserLogins
    Private _CWBLogBook As iStockCommon.iStockLogBook

#End Region

#Region "Constructors"
    Public ReadOnly Property CWBUserLogins() As iStockCommon.iStockUserLogins
        Get

            If _CWBUserLogins Is Nothing Then
                _CWBUserLogins = New iStockCommon.iStockUserLogins()
            End If

            Return _CWBUserLogins
        End Get
    End Property


    Public ReadOnly Property CWBLogBook() As iStockCommon.iStockLogBook
        Get
            ' Create on demand...
            If _CWBLogBook Is Nothing Then
                _CWBLogBook = New iStockCommon.iStockLogBook()
            End If

            Return _CWBLogBook
        End Get
    End Property
#End Region

#Region "Form Events"
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        Me.PopulateLookup()
        Me.ShowAppName()
    End Sub
#End Region

#Region "Populate Users"
    Public Sub PopulateLookup()
        Try
            leUsers.Properties.DataSource = CWBUserLogins.SelectAll.Tables(0)
            leUsers.Properties.DisplayMember = "UserName"
            leUsers.Properties.ValueMember = "UserLoginID"

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Button Events"
    Private Sub SimpleButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbExit.Click
        Application.Exit()
    End Sub

    Private Sub sbLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbLogin.Click

        Me.Loging()

    End Sub
#End Region

#Region "Show App Name"
    Private Sub ShowAppName()
        Try
            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Me.Text = ApplicationTitle

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub
#End Region

    Private Sub tePassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tePassword.KeyPress
        If e.KeyChar = Chr(13) Then
            Loging()
        End If
    End Sub


    Public Function Loging() As String
        Try
            If dxvpLogin.Validate Then


                With CWBLogBook
                    .UserName = Me.leUsers.Text
                    .Password = Me.tePassword.Text
                    .IPAddress = "Assing By DHCP"
                    .ComputerName = Environment.MachineName
                    .InsertLogbook()

                End With



                CWBUserLogins.UserName = Me.leUsers.Text
                CWBUserLogins.Password = Me.tePassword.Text.Trim

                CWBUserLogins.SelectRowByUserNameAndPassword()

                If IsDBNull(CWBUserLogins.UserLoginID) Or CWBUserLogins.UserLoginID = 0 Then
                    lblError.Text = "Wrong Password"
                Else
                    lblError.Text = "Athunticated"

                    UserID = CWBUserLogins.UserLoginID
                    UserName = CWBUserLogins.UserName
                    UserType = CWBUserLogins.UserType


                    Select Case UserType

                        Case "USER"
                            frmMain.RibbonPage1.Visible = False
                            frmMain.RibbonPage3.Visible = False
                            frmMain.RibbonPage4.Visible = False
                            frmMain.RibbonPageGroup2.Visible = False
                            frmMain.BarButtonItem6.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                            frmMain.BarButtonItem10.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
                            frmMain.BarButtonItem5.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

                    End Select

                    Me.Hide()
                    frmMain.Show()


                End If

            Else
                tePassword.Focus()
            End If

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

        Return String.Empty
    End Function
End Class