Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockSettings
Public Class frmSettings

#Region "Properties"
    Private _ECSSettings As iStockCommon.iStockSettings
#End Region

#Region "Constructors"

    Public ReadOnly Property ECSSettings() As iStockCommon.iStockSettings
        Get

            If _ECSSettings Is Nothing Then
                _ECSSettings = New iStockCommon.iStockSettings
            End If

            Return _ECSSettings
        End Get
    End Property
#End Region

#Region "Form Events"
    Private Sub frmCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.DisplaySettings()
        Me.GetAbbreviations()
    End Sub

    'Private Sub frmCompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
    '    If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
    '        Me.Close()
    '    End If
    'End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpSettings.Validate Then
            Me.SaveSettigs()
        End If


    End Sub
#End Region

#Region "Save Settigs"
    Private Sub SaveSettigs()

        Try
            With ECSSettings

                .PayChitCost = Me.sePayChitCost.Text
                .DevalutionAllowance = Me.seDevalutionAllowance.Text
                .DayRate = Me.seDayRate.Text
                .OTRate = Me.seOTRate.Text
                .KgsPerDay = Me.seKgsPerDay.Text
                .IncentiveDays = Me.seIncentiveDays.Text
                .IncentiveRate = Me.seIncentiveRate.Text

                .InsertSettings()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try




    End Sub
#End Region

#Region "Display Settings"
    Private Sub DisplaySettings()
        Try
            With ECSSettings
                .GetSettings()
                Me.sePayChitCost.Text = .PayChitCost
                Me.seDevalutionAllowance.Text = .DevalutionAllowance
                Me.seDayRate.Text = .DayRate
                Me.seOTRate.Text = .OTRate
                Me.seKgsPerDay.Text = .KgsPerDay
                Me.seIncentiveDays.Text = .IncentiveDays
                Me.seIncentiveRate.Text = .IncentiveRate

            End With
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Get Abbreviations"
    Private Sub GetAbbreviations()

        Try

            Me.leAbbriviationCode.Properties.DataSource = ECSSettings.GetAbbreviations.Tables(0)

            Me.leAbbriviationCode.Properties.DisplayMember = "AbbreviationCode"
            Me.leAbbriviationCode.Properties.ValueMember = "AbbreviationID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Lookup Events"
    Private Sub leAbbriviationCode_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles leAbbriviationCode.ButtonClick
        Select Case e.Button.Index
            Case 1
                Me.LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

                'TNLRoutes.RouteDescription = leRoute.Text
                'TNLRoutes.RouteInsert()
                'Me.PopulateRoutes()
            Case 2
                If Not leAbbriviationCode.EditValue = Nothing Then
                    Dim frm As New frmDeleteYesNo
                    frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
                    frm.lblDescription.ForeColor = Color.Red
                    frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
                    frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
                    frm.Text = CWB_DELETE_CONFIRMATION_TITLE

                    If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                        Me.DeleteAbbreviation(leAbbriviationCode.EditValue)

                    End If
                End If
                Me.GetAbbreviations()

        End Select

    End Sub
#End Region

#Region "Button Events"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        teAbbreviationCode.Text = String.Empty
        teAbbreviationDesc.Text = String.Empty

        Me.LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dxvpSettings.Validate Then

            SaveAbbreviations()

        Else

            Return

        End If


        teAbbreviationCode.Text = String.Empty
        teAbbreviationDesc.Text = String.Empty
        GetAbbreviations()

        Me.LayoutControlGroup2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

#End Region
    
#Region "Save Abbreviations"
    Private Sub SaveAbbreviations()

        Try
            With ECSSettings

                .AbbreviationCode = Me.teAbbreviationCode.Text
                .AbbreviationDesc = Me.teAbbreviationDesc.Text

                .InsertAbbreviation()



            End With

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

      



    End Sub
#End Region

#Region "Delete Abbreviation"
    Private Sub DeleteAbbreviation(ByVal AbbreviationID As Int64)

        Try
            With ECSSettings
                .AbbreviationID = AbbreviationID
                .DeleteAbbrevation()
            End With


        Catch ex As SqlClient.SqlException
            Dim frm As New frmOk
            frm.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_DELETE_ERROR_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()
        End Try

    End Sub
#End Region
End Class