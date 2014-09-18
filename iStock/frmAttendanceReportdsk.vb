Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockDailyWorking
Imports iStockCommon.iStockConstants
Public Class frmAttendanceReportdsk

#Region "Properties"
    Private _iStockEmployers As iStockCommon.iStockEmployers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings

#End Region

#Region "Constructors"

    Public ReadOnly Property iStockEmployers() As iStockCommon.iStockEmployers
        Get

            If _iStockEmployers Is Nothing Then
                _iStockEmployers = New iStockCommon.iStockEmployers
            End If

            Return _iStockEmployers
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

    Public ReadOnly Property ECSSettings() As iStockCommon.iStockSettings
        Get

            If _ECSSettings Is Nothing Then
                _ECSSettings = New iStockCommon.iStockSettings
            End If

            Return _ECSSettings
        End Get
    End Property
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

        If dxvpCompany.Validate Then
            'Me.SaveCompany()
        End If


    End Sub
#End Region

#Region "Daily Working Get All By Dates"
    Private Sub AttendancePivot()

        Try


            With iStockDailyWorking


                .EndDate = deEndDate.EditValue
                'PivotGridControl1.DataSource = .AttendancePivot.Tables(0)

            End With




        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region




    Private Sub frmAttendanceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.deEndDate.EditValue = Date.Today

    End Sub

    Private Sub deEndDate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles deEndDate.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.AttendancePivot()

        End If
    End Sub
End Class