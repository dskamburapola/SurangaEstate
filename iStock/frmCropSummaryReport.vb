Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmCropSummaryReport

#Region "Variables"

    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings



#End Region

#Region "Constructor"

    Public ReadOnly Property ECSSettings() As iStockCommon.iStockSettings
        Get

            If _ECSSettings Is Nothing Then
                _ECSSettings = New iStockCommon.iStockSettings
            End If

            Return _ECSSettings
        End Get
    End Property
    Public ReadOnly Property CWBStock() As iStockCommon.iStockStock
        Get

            If _CWBStock Is Nothing Then
                _CWBStock = New iStockCommon.iStockStock()
            End If

            Return _CWBStock
        End Get
    End Property

    Public ReadOnly Property CWBSuppliers() As iStockCommon.iStockSuppliers
        Get

            If _CWBSuppliers Is Nothing Then
                _CWBSuppliers = New iStockCommon.iStockSuppliers()
            End If

            Return _CWBSuppliers
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

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadTypes()
    End Sub

    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        pgcAttendance.BestFitColumnArea()
    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Print Preview"
    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPivotPreview(pgcAttendance, "Overall Crop Report - " + leType.Text)
    End Sub
#End Region

#Region "Populate Types"

    Private Sub LoadTypes()


        Me.leType.Properties.DataSource = ECSSettings.GetAbbreviations.Tables(0)
        Me.leType.Properties.DisplayMember = "AbbreviationDesc"
        Me.leType.Properties.ValueMember = "AbbreviationID"


    End Sub


#End Region

#Region "Button Events"

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        If dxvpAttendaceReport.Validate Then

            Dim ds As New DataSet

            ds = iStockDailyWorking.GetCropSummary(leType.EditValue)
            pgcAttendance.DataSource = ds.Tables(0)

            'Dim frow As New PivotGridField
            'Dim fcol As New PivotGridField
            'Dim fdata As New PivotGridField
            'Dim fdataPercentage As New PivotGridField


            'frow.FieldName = "MONTH"
            'fcol.FieldName = "YEAR"
            'fdata.FieldName = "Crop"
            'fdataPercentage.FieldName = "Crop"

            'frow=

            'With pgcAttendance
            '    .Fields.Add(frow)
            '    .Fields.Add(fdata)
            '    .Fields.Add(fdataPercentage).SummaryDisplayType = DevExpress.Data.PivotGrid.PivotSummaryDisplayType.PercentOfColumn
            '    .Fields.Add(fcol)

            'End With


            pgcAttendance.BestFitColumnArea()

            'PivotGridField2.FilterValues.ShowBlanks = False



        End If


    End Sub


#End Region

    Private Sub pgcAttendance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pgcAttendance.Click

    End Sub
End Class