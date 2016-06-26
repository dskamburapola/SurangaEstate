Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockWorkDays
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmAttendaceReport

    Dim varWD As Integer

#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _iStockWorkDays As iStockCommon.iStockWorkDays


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

    Public ReadOnly Property iStockWorkDays() As iStockCommon.iStockWorkDays
        Get

            If _iStockWorkDays Is Nothing Then
                _iStockWorkDays = New iStockCommon.iStockWorkDays
            End If

            Return _iStockWorkDays
        End Get
    End Property

#End Region

#Region "Form Events"

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
    End Sub

    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ' pgcAttendance.BestFitColumnArea()
    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Print Preview"
    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPreview(gcAttendance, "Attendance Report")
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
        Dim currentDate As Date
        Dim selectedMonth, selectedYear, workType As String
        Dim workDays As Int32

        If dxvpAttendaceReport.Validate Then

            With iStockWorkDays

                .MonthName = Me.meMonth.Text
                .YearName = leYear.Text

                .GetSelectedMonthWorkDays()

                workDays = .WorkDays
                'MsgBox(varWD)


            End With


            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

            workType = cbeWorkType.EditValue

            If workType = "ALL" Then

                Dim ds As New DataSet

                ds = iStockDailyWorking.GetAttendanceReportAllWorkCategory(currentDate, workDays)



                gvAttendance.Columns.Clear()
                gcAttendance.DataSource = Nothing
                gcAttendance.DataSource = ds.Tables(0)

                gvAttendance.BestFitColumns()

                gvAttendance.Columns("EmployeeID").Visible = False

                gvAttendance.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                gvAttendance.Columns("EmployeeName").Width = 150

                gvAttendance.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
                gvAttendance.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left

                gvAttendance.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                gvAttendance.Columns("MWA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

                gvAttendance.Columns("MWA").Caption = "Monthly Work Average"


                For index = 0 To gvAttendance.Columns.Count - 1

                    If IsDate(gvAttendance.Columns(index).FieldName) Then

                        gvAttendance.Columns(index).Caption = DatePart(DateInterval.Day, Convert.ToDateTime(gvAttendance.Columns(index).FieldName)).ToString()
                        'gvAttendance.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

                        gvAttendance.Columns(index).Width = 45


                    End If

                Next


            Else


                Dim ds As New DataSet

                ds = iStockDailyWorking.GetAttendanceReportByWorkCategory(currentDate, workType, workDays)



                gvAttendance.Columns.Clear()
                gcAttendance.DataSource = Nothing
                gcAttendance.DataSource = ds.Tables(0)

                gvAttendance.BestFitColumns()

                gvAttendance.Columns("EmployeeID").Visible = False

                gvAttendance.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                gvAttendance.Columns("EmployeeName").Width = 150

                gvAttendance.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
                gvAttendance.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left

                gvAttendance.Columns("Designation").Fixed = Columns.FixedStyle.Left
               
                gvAttendance.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                gvAttendance.Columns("MWA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

                gvAttendance.Columns("MWA").Caption = "Monthly Work Average"


                For index = 0 To gvAttendance.Columns.Count - 1

                    If IsDate(gvAttendance.Columns(index).FieldName) Then

                        gvAttendance.Columns(index).Caption = DatePart(DateInterval.Day, Convert.ToDateTime(gvAttendance.Columns(index).FieldName)).ToString()
                        'gvAttendance.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

                        gvAttendance.Columns(index).Width = 45


                    End If

                Next


            End If


        End If


    End Sub


#End Region

#Region "Pivot Grid events"

    Private Sub pgcAttendance_CustomDrawFieldValue(ByVal sender As System.Object, ByVal e As DevExpress.XtraPivotGrid.PivotCustomDrawFieldValueEventArgs)

        If (e.ValueType = PivotGridValueType.GrandTotal) Then
            ' e.Info.Caption = "Total"
        End If

    End Sub

#End Region

    Private Sub cbeWorkType_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles cbeWorkType.ButtonClick
        If e.Button.Index = 1 Then
            cbeWorkType.EditValue = Nothing
        End If
    End Sub
End Class