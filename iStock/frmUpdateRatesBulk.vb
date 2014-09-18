Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockSettings
Imports iStockCommon.iStockDailyWorking

Public Class frmUpdateRatesBulk

#Region "Properties"
    Private _ECSSettings As iStockCommon.iStockSettings
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
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

    Public ReadOnly Property iStockDailyWorking() As iStockCommon.iStockDailyWorking
        Get

            If _iStockDailyWorking Is Nothing Then
                _iStockDailyWorking = New iStockCommon.iStockDailyWorking
            End If

            Return _iStockDailyWorking
        End Get
    End Property
#End Region

#Region "Form Events"
    

    Private Sub frmUpdateRatesBulk_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmUpdateRatesBulk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.DisplaySettings()

    End Sub


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
        Try


            Me.UpdateRates()


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Update Rates"
    Private Sub UpdateRates()


        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            gvUpdateRates.PostEditor()


            With iStockDailyWorking



                For i As Integer = 0 To Me.gvUpdateRates.RowCount

                    If Not gvUpdateRates.GetRowCellDisplayText(i, gvUpdateRates.Columns(10)) = "" Then

                        .DailyWorkingID = Me.gvUpdateRates.GetRowCellDisplayText(i, GridColumn10)
                        .DayRate = Me.seDayRate.Value
                        .OTRate = Me.seOTRate.Value

                        If Me.gvUpdateRates.GetRowCellDisplayText(i, GridColumn5) = 0 Then
                            .KgsPerDay = 0
                        Else
                            .KgsPerDay = Me.seKgsPerDay.Value
                        End If


                        If Me.gvUpdateRates.GetRowCellDisplayText(i, GridColumn5) = 0 Then
                            .OverKgRate = 0
                        Else
                            .OverKgRate = Me.seOverKgsRate.Value
                        End If


                        If Me.gvUpdateRates.GetRowCellDisplayText(i, GridColumn5) = 0 Then
                            .EPF = 0
                        Else
                            .EPF = Me.seEPF.Value
                        End If


                        .CasualPayRate = Me.seCasualPayRate.Value
                        .CasualOTPayRate = Me.seCasualOTPayRate.Value

                      



                        .UpdateRates()

                    End If

                Next
            End With
            _Transaction.Commit()
            Dim frm As New frmSavedOk
            frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()


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
                Me.seDayRate.Text = .DayRate
                Me.seOTRate.Text = .OTRate
                Me.seKgsPerDay.Text = .KgsPerDay
                '  Me.seIncentiveRate.Text = .IncentiveRate
                Me.seEPF.Text = .EPF
                Me.seOverKgsRate.Text = .OverKgRate
                Me.seCasualPayRate.Text = .CasualPayRate
                Me.seCasualOTPayRate.Text = .CasualOTPayRate

            End With
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Button Events"


    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        If dxvpSearch.Validate Then
            Me.DisplayRecords()



            Dim frm As New frmUpdateYesNo
            frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
            frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = "Do you want to update" 'CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL



            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then

                Me.EnableControls()

                Select Case cmbDesignation.Text.Trim

                    Case "PERMENANT"
                        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always

                        LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never


                        Me.seCasualPayRate.Value = 0
                        Me.seCasualOTPayRate.Value = 0

                        Me.seCasualPayRate.Enabled = False
                        Me.seCasualOTPayRate.Enabled = False
                        Me.seDayRate.Enabled = True
                        Me.seOTRate.Enabled = True

                        Me.seDayRate.Focus()

                    Case "CASUAL"

                        LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        LayoutControlItem17.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
                        LayoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
                        LayoutControlItem15.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never

                        Me.seCasualPayRate.Enabled = True
                        Me.seCasualOTPayRate.Enabled = True
                        Me.seDayRate.Enabled = False
                        Me.seOTRate.Enabled = False

                        Me.seDayRate.Value = 0
                        Me.seOTRate.Value = 0
                        Me.seEPF.Value = 0

                        Me.seCasualPayRate.Focus()

                End Select

                'If dxvpUpdate.Validate Then
                '    Me.SaveSettigs()
                'End If
                'MsgBox("FFFFFFFFFFF")
            Else

                Return
                deStartDate.Focus()

            End If

        End If

    End Sub


#End Region

#Region "Display Records"
    Private Sub DisplayRecords()

        Try

            With iStockDailyWorking

                .StartDate = deStartDate.EditValue
                .EndDate = deEndDate.EditValue
                .Designation = Me.cmbDesignation.Text.Trim

                gcUpdateRates.DataSource = .DailyWorkingGetforRateUpdate.Tables(0)

            End With




        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Enable Controls"
    Private Sub EnableControls()

        Try
            Me.seCasualOTPayRate.Enabled = True
            Me.seCasualPayRate.Enabled = True
            Me.seDayRate.Enabled = True
            Me.seOTRate.Enabled = True
            Me.seKgsPerDay.Enabled = True
            Me.seOverKgsRate.Enabled = True
            Me.seEPF.Enabled = True

        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region



End Class