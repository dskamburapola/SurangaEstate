Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmAttendaceAdvanceReport

#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking

#End Region

#Region "Constructor"

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
        LoadYears()
    End Sub

    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Print Preview"
    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPreview(gcCheckRoll, "Attendance Report (Permanent)")
    End Sub
#End Region

#Region "Populate Years"

    Private Sub LoadYears()

        Dim dict As New Dictionary(Of Integer, Integer)

        For index = 2013 To 2040
            dict.Add(index, index)
        Next

        leYear.Properties.DataSource = dict
        leYear.Properties.DisplayMember = "Key"
        leYear.Properties.ValueMember = "Key"


    End Sub


#End Region

#Region "Button Events"

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        If dxvpAttendaceReport.Validate Then

            Dim currentDate As Date
            Dim selectedMonth, selectedYear As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

            Dim ds As New DataSet

            ds = iStockDailyWorking.GetCheckRollReport(currentDate)

            gcCheckRoll.DataSource = Nothing
            gcCheckRoll.DataSource = ds.Tables(0)

            gvCheckRoll.BestFitColumns()

            gvCheckRoll.Columns("EmployeeID").Visible = False

            gvCheckRoll.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            gvCheckRoll.Columns("EmployeeName").Width = 150
            gvCheckRoll.Columns("Sex").Width = 60

            gvCheckRoll.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
            gvCheckRoll.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left
            gvCheckRoll.Columns("Sex").Fixed = Columns.FixedStyle.Left


            gvCheckRoll.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("PluckingKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("TappingL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("PluckingOrTappingPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("WCPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("DevalutionAllowance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("GrandTotalPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("EPFAmount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("PayChit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("FestivalAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("CashAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("TotalDeductions").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("BalancePay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("EPF_12").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("EPF_20").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("ETF_3").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

            gvCheckRoll.Columns("PluckingKgs").Caption = "Plucking (Kg)"
            gvCheckRoll.Columns("OverKgs").Caption = "Over (Kg)"
            gvCheckRoll.Columns("OverKgsPay").Caption = "Over (Kg) Pay"
            gvCheckRoll.Columns("TappingL").Caption = "Tapping (L)"

            gvCheckRoll.Columns("EPF_12").Caption = "EPF (12%)"
            gvCheckRoll.Columns("EPF_20").Caption = "EPF (20%)"
            gvCheckRoll.Columns("ETF_3").Caption = "ETF (3%)"

            gvCheckRoll.Columns("EPF_12").Width = 60
            gvCheckRoll.Columns("EPF_20").Width = 60
            gvCheckRoll.Columns("ETF_3").Width = 60

            For index = 0 To gvCheckRoll.Columns.Count - 1

                If IsDate(gvCheckRoll.Columns(index).FieldName) Then

                    gvCheckRoll.Columns(index).Caption = DatePart(DateInterval.Day, Convert.ToDateTime(gvCheckRoll.Columns(index).FieldName)).ToString()
                    'gvCheckRoll.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

                End If

            Next





        End If


    End Sub


#End Region

End Class