Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmCheckRollCasualReport

#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _CWBWorkDays As iStockCommon.iStockWorkDays
    Dim dtholiday As New DataTable
    Dim listDays As New List(Of String)

#End Region

#Region "Constructor"


    Public ReadOnly Property CWBWorkDays() As iStockCommon.iStockWorkDays
        Get

            If _CWBWorkDays Is Nothing Then
                _CWBWorkDays = New iStockCommon.iStockWorkDays()
            End If

            Return _CWBWorkDays
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
        PrintPreview(gcPayrollPrint, "Check Roll Report (Casual) " + meMonth.Text + " / " + leYear.Text + " Period - " + cbeRange.EditValue)
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

            Dim daterange As Integer = 1
            Dim currentDate As Date
            Dim selectedMonth, selectedYear, selectedRange As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)
            selectedRange = cbeRange.EditValue

            CWBWorkDays.YearName = selectedYear
            CWBWorkDays.MonthName = meMonth.Text
            dtholiday = CWBWorkDays.GetHolyDaysAll.Tables(1)


            For Each row As DataRow In dtholiday.Rows
                listDays.Add(Convert.ToDateTime(row("Hdate")).Day.ToString)
            Next


            If (selectedRange = "1-15") Then
                daterange = 1
            ElseIf (selectedRange = "16-EOM") Then
                daterange = 2
            End If


            Dim ds As New DataSet

            ds = iStockDailyWorking.GetCheckRollCasualReport(currentDate, daterange)

            gvCheckRoll.Columns.Clear()
            gcCheckRoll.DataSource = Nothing
            gcCheckRoll.DataSource = ds.Tables(0)

            gvCheckRoll.BestFitColumns()

            gvPayrollPrint.Columns.Clear()
            gcPayrollPrint.DataSource = Nothing
            gcPayrollPrint.DataSource = ds.Tables(0)

            gvPayrollPrint.BestFitColumns()

            gvCheckRoll.Columns("EmployeeID").Visible = False
            gvCheckRoll.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            gvCheckRoll.Columns("EmployeeName").Width = 150
            gvCheckRoll.Columns("Sex").Width = 60
            gvCheckRoll.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
            gvCheckRoll.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left
            gvCheckRoll.Columns("Sex").Fixed = Columns.FixedStyle.Left
            gvCheckRoll.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("TotalDays").DisplayFormat.FormatString = "c1"
            gvCheckRoll.Columns("TotalDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvCheckRoll.Columns("NameDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("NameDays").DisplayFormat.FormatString = "f1"
            gvCheckRoll.Columns("NameDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvCheckRoll.Columns("PluckingKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("TappingL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("SmokingS").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("LowerKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("LowerSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OTHours").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("BasicPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("LowerKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OverSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("LowerSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("SmokingSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("OTPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("WCPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("EvalutionAllowance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("GrandTotalPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("FestivalAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("CashAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("TotalDeductions").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("BalancePay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvCheckRoll.Columns("PluckingKgs").Caption = "Plucking (Kg)"
            gvCheckRoll.Columns("OverKgs").Caption = "Over (Kg)"
            gvCheckRoll.Columns("OverKgsPay").Caption = "Over (Kg) Pay"
            gvCheckRoll.Columns("TappingL").Caption = "Tapping (L)"
            gvCheckRoll.Columns("SmokingS").Caption = "Smoking Sheets"
            gvCheckRoll.Columns("EvalutionAllowance").Caption = "Evaluation Allowance"
            gvCheckRoll.Columns("GrandTotalPay").AppearanceCell.BackColor = Color.Bisque
            gvCheckRoll.Columns("BalancePay").AppearanceCell.BackColor = Color.Thistle
            gvCheckRoll.Columns("FestivalAdvance").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("CashAdvance").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("TotalDeductions").AppearanceCell.BackColor = Color.LightCoral

            gvCheckRoll.Columns("WCPay").Visible = False
            gvCheckRoll.Columns("EvalutionAllowance").Visible = False



            '////////////////////////////////////////////////////////////////////////////////////

            gvPayrollPrint.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            gvPayrollPrint.Columns("EmployeeName").Width = 150
            gvPayrollPrint.Columns("Sex").Width = 60
            'gvPayrollPrint.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
            'gvPayrollPrint.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left
            'gvPayrollPrint.Columns("Sex").Fixed = Columns.FixedStyle.Left
            gvPayrollPrint.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("TotalDays").DisplayFormat.FormatString = "c1"
            gvPayrollPrint.Columns("TotalDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvPayrollPrint.Columns("NameDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("NameDays").DisplayFormat.FormatString = "f1"
            gvPayrollPrint.Columns("NameDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvPayrollPrint.Columns("PluckingKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("TappingL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("SmokingS").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OverKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("LowerKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OverSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("LowerSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OTHours").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("BasicPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OverKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("LowerKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OverSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("LowerSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("SmokingSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("OTPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("WCPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("EvalutionAllowance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("GrandTotalPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("FestivalAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("CashAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("TotalDeductions").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("BalancePay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPayrollPrint.Columns("PluckingKgs").Caption = "Plucking (Kg)"
            gvPayrollPrint.Columns("OverKgs").Caption = "Over (Kg)"
            gvPayrollPrint.Columns("OverKgsPay").Caption = "Over (Kg) Pay"
            gvPayrollPrint.Columns("TappingL").Caption = "Tapping (L)"
            gvPayrollPrint.Columns("SmokingS").Caption = "Smoking Sheets"
            gvPayrollPrint.Columns("EvalutionAllowance").Caption = "Evaluation Allowance"
            'gvPayrollPrint.Columns("GrandTotalPay").AppearanceCell.BackColor = Color.Bisque
            'gvPayrollPrint.Columns("BalancePay").AppearanceCell.BackColor = Color.Thistle
            'gvPayrollPrint.Columns("FestivalAdvance").AppearanceCell.BackColor = Color.LightCoral
            'gvPayrollPrint.Columns("CashAdvance").AppearanceCell.BackColor = Color.LightCoral
            'gvPayrollPrint.Columns("TotalDeductions").AppearanceCell.BackColor = Color.LightCoral


            gvPayrollPrint.Columns("EmployeeID").Visible = False
            gvPayrollPrint.Columns("Sex").Visible = False
            gvPayrollPrint.Columns("TotalDays").Visible = False
            gvPayrollPrint.Columns("NameDays").Visible = False
            gvPayrollPrint.Columns("PluckingKgs").Visible = False
            gvPayrollPrint.Columns("TappingL").Visible = False
            gvPayrollPrint.Columns("SmokingS").Visible = False
            gvPayrollPrint.Columns("OverKgs").Visible = False
            gvPayrollPrint.Columns("LowerKgs").Visible = False
            gvPayrollPrint.Columns("OverSheets").Visible = False
            gvPayrollPrint.Columns("LowerSheets").Visible = False
            gvPayrollPrint.Columns("OTHours").Visible = False
            gvPayrollPrint.Columns("BasicPay").Visible = True
            gvPayrollPrint.Columns("OverKgsPay").Visible = False
            gvPayrollPrint.Columns("LowerKgsPay").Visible = False
            gvPayrollPrint.Columns("OverSheetsPay").Visible = False
            gvPayrollPrint.Columns("LowerSheetsPay").Visible = False
            gvPayrollPrint.Columns("SmokingSheetsPay").Visible = False
            gvPayrollPrint.Columns("OTPay").Visible = False
            gvPayrollPrint.Columns("WCPay").Visible = False
            gvPayrollPrint.Columns("EvalutionAllowance").Visible = False

            For index = 0 To gvPayrollPrint.Columns.Count - 1

                If IsDate(gvPayrollPrint.Columns(index).FieldName) Then

                    gvPayrollPrint.Columns(index).Visible = False
                    'gvCheckRoll.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    ' gvPayrollPrint.Columns(index).Width = 50
                End If

            Next
            '////////////////////////////////////////////////////////////////////////////////////



            For index = 0 To gvCheckRoll.Columns.Count - 1

                If IsDate(gvCheckRoll.Columns(index).FieldName) Then

                    gvCheckRoll.Columns(index).Caption = DatePart(DateInterval.Day, Convert.ToDateTime(gvCheckRoll.Columns(index).FieldName)).ToString()
                    'gvCheckRoll.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                    gvCheckRoll.Columns(index).Width = 50
                End If

            Next



        End If

        gcCheckRoll.Refresh()
        gcCheckRoll.RefreshDataSource()

        gcPayrollPrint.Refresh()
        gcPayrollPrint.RefreshDataSource()


    End Sub


#End Region

    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SimpleButton1.Click


        Dim dt As New DataTable
        dt = frmCoinCalculatorAdvance.CreateDataSource()

        For i = 0 To gvCheckRoll.RowCount - 1 Step 1

            Dim dr As DataRow
            dr = dt.NewRow


            Dim cointval() As Integer = {1, 2, 5, 10, 20, 50, 100, 500, 1000}
            Dim numofCoinUsed(9) As Integer
            Dim amountToCal As Integer
            amountToCal = Convert.ToDecimal(gvCheckRoll.GetRowCellValue(i, gvCheckRoll.Columns("BalancePay")))

            Dim remainingAmount As Integer

            remainingAmount = amountToCal

            For currentCoin As Integer = 8 To 0 Step -1

                Dim currentCoinIndex As Integer
                currentCoinIndex = 0


                Dim x As Decimal

                x = (remainingAmount / cointval(currentCoin))

                currentCoinIndex = IIf(x < 1, 0, Math.Abs(Math.Floor(x)))

                numofCoinUsed(currentCoin) = currentCoinIndex

                remainingAmount = remainingAmount - (currentCoinIndex * cointval(currentCoin))

                If (remainingAmount = 0) Then
                    Continue For
                End If

            Next


            dr("EmployeeName") = gvCheckRoll.GetRowCellValue(i, gvCheckRoll.Columns("EmployeeName"))
            dr("EmployeeNo") = gvCheckRoll.GetRowCellValue(i, gvCheckRoll.Columns("EmployeeNo"))
            dr("BalancePay") = gvCheckRoll.GetRowCellValue(i, gvCheckRoll.Columns("BalancePay"))

            dr("1000") = numofCoinUsed(8)
            dr("500") = numofCoinUsed(7)
            dr("100") = numofCoinUsed(6)
            dr("50") = numofCoinUsed(5)
            dr("20") = numofCoinUsed(4)
            dr("10") = numofCoinUsed(3)
            dr("5") = numofCoinUsed(2)
            dr("2") = numofCoinUsed(1)
            dr("1") = numofCoinUsed(0)

            dt.Rows.Add(dr)

        Next


        frmCoinCalculatorAdvance.gcSummary.DataSource = dt

        ShowIStockForm(frmCoinCalculatorAdvance)
        frmCoinCalculatorAdvance.BringToFront()
        frmCoinCalculatorAdvance.lblTitle.Text = "Check Roll (Casual)"
    End Sub

    Private Sub gvCheckRoll_CustomColumnDisplayText(sender As Object, e As Views.Base.CustomColumnDisplayTextEventArgs) Handles gvCheckRoll.CustomColumnDisplayText
        If listDays.Contains(e.Column.Caption) Then

            e.Column.AppearanceCell.BackColor = Color.Red
            e.DisplayText = e.DisplayText.Replace(".00", "")
            e.DisplayText = e.DisplayText.Replace(".50", ".5")

        Else
            If (e.DisplayText = String.Empty) Then
                e.DisplayText = "ab"
            ElseIf IsNumeric(e.DisplayText) Then
                e.DisplayText = e.DisplayText.Replace(".00", "")
                e.DisplayText = e.DisplayText.Replace(".50", ".5")
            End If
        End If
    End Sub
End Class