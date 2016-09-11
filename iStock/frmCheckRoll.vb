Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmCheckRoll

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
        PrintPreview(gcPrint, "Check Roll Report (Permanent) " + meMonth.Text + " / " + leYear.Text)
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
        frmCoinCalculatorAdvance.lblTitle.Text = "Check Roll (Permanent)"



    End Sub

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        If dxvpAttendaceReport.Validate Then

            Dim currentDate As Date
            Dim selectedMonth, selectedYear As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)
            
            Dim ds As New DataSet

            ds = iStockDailyWorking.GetCheckRollReport(currentDate)

            CWBWorkDays.YearName = selectedYear
            CWBWorkDays.MonthName = meMonth.Text
            dtholiday = CWBWorkDays.GetHolyDaysAll.Tables(1)


            For Each row As DataRow In dtholiday.Rows
                listDays.Add(Convert.ToDateTime(row("Hdate")).Day.ToString)
            Next



            gvCheckRoll.Columns.Clear()
            gcCheckRoll.DataSource = Nothing
            gcCheckRoll.DataSource = ds.Tables(0)

            gvCheckRoll.BestFitColumns()


            gvPrint.Columns.Clear()
            gcPrint.DataSource = Nothing
            gcPrint.DataSource = ds.Tables(0)

            gvPrint.BestFitColumns()


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
            gvCheckRoll.Columns("SmokingS").Caption = "Smoking Sheets"

            gvCheckRoll.Columns("EvalutionAllowance").Caption = "Evaluation Allowance"

            gvCheckRoll.Columns("EPF_12").Caption = "EPF (12%)"
            gvCheckRoll.Columns("EPF_20").Caption = "EPF (20%)"
            gvCheckRoll.Columns("ETF_3").Caption = "ETF (3%)"

            gvCheckRoll.Columns("EPF_12").Width = 60
            gvCheckRoll.Columns("EPF_20").Width = 60
            gvCheckRoll.Columns("ETF_3").Width = 60

            gvCheckRoll.Columns("GrandTotalPay").AppearanceCell.BackColor = Color.Bisque
            gvCheckRoll.Columns("BalancePay").AppearanceCell.BackColor = Color.Thistle

            gvCheckRoll.Columns("EPFAmount").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("PayChit").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("FestivalAdvance").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("CashAdvance").AppearanceCell.BackColor = Color.LightCoral
            gvCheckRoll.Columns("TotalDeductions").AppearanceCell.BackColor = Color.LightCoral

            '*********************************************


            gvPrint.Columns("EmployeeID").Visible = False

            gvPrint.Columns("EmployeeNo").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            gvPrint.Columns("EmployeeName").Width = 150
            gvPrint.Columns("Sex").Width = 60

            gvPrint.Columns("EmployeeNo").Fixed = Columns.FixedStyle.Left
            gvPrint.Columns("EmployeeName").Fixed = Columns.FixedStyle.Left
            gvPrint.Columns("Sex").Fixed = Columns.FixedStyle.Left
            gvPrint.Columns("TotalDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("TotalDays").DisplayFormat.FormatString = "c1"
            gvPrint.Columns("TotalDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvPrint.Columns("NameDays").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("NameDays").DisplayFormat.FormatString = "f1"
            gvPrint.Columns("NameDays").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            gvPrint.Columns("PluckingKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("TappingL").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("SmokingS").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OverKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("LowerKgs").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OverSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("LowerSheets").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OTHours").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("BasicPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OverKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("LowerKgsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OverSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("LowerSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("SmokingSheetsPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("OTPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("WCPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EvalutionAllowance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("GrandTotalPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPFAmount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("PayChit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("FestivalAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("CashAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("TotalDeductions").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("BalancePay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPF_12").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPF_20").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("ETF_3").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("PluckingKgs").Caption = "Plucking (Kg)"
            gvPrint.Columns("OverKgs").Caption = "Over (Kg)"
            gvPrint.Columns("OverKgsPay").Caption = "Over (Kg) Pay"
            gvPrint.Columns("TappingL").Caption = "Tapping (L)"
            gvPrint.Columns("SmokingS").Caption = "Smoking Sheets"
            gvPrint.Columns("EvalutionAllowance").Caption = "Evaluation Allowance"
            gvPrint.Columns("EPF_12").Caption = "EPF (12%)"
            gvPrint.Columns("EPF_20").Caption = "EPF (20%)"
            gvPrint.Columns("ETF_3").Caption = "ETF (3%)"

            gvPrint.Columns("EPF_12").Width = 60
            gvPrint.Columns("EPF_20").Width = 60
            gvPrint.Columns("ETF_3").Width = 60

            'gvPrint.Columns("GrandTotalPay").AppearanceCell.BackColor = Color.Bisque
            'gvPrint.Columns("BalancePay").AppearanceCell.BackColor = Color.Thistle

            'gvPrint.Columns("EPFAmount").AppearanceCell.BackColor = Color.LightCoral
            'gvPrint.Columns("PayChit").AppearanceCell.BackColor = Color.LightCoral
            'gvPrint.Columns("FestivalAdvance").AppearanceCell.BackColor = Color.LightCoral
            'gvPrint.Columns("CashAdvance").AppearanceCell.BackColor = Color.LightCoral
            'gvPrint.Columns("TotalDeductions").AppearanceCell.BackColor = Color.LightCoral


            gvPrint.Columns("EmployeeID").Visible = False
            gvPrint.Columns("Sex").Visible = False
            gvPrint.Columns("TotalDays").Visible = False
            gvPrint.Columns("NameDays").Visible = False
            gvPrint.Columns("PluckingKgs").Visible = False
            gvPrint.Columns("TappingL").Visible = False
            gvPrint.Columns("SmokingS").Visible = False
            gvPrint.Columns("OverKgs").Visible = False
            gvPrint.Columns("LowerKgs").Visible = False
            gvPrint.Columns("OverSheets").Visible = False
            gvPrint.Columns("LowerSheets").Visible = False
            gvPrint.Columns("OTHours").Visible = False
            gvPrint.Columns("BasicPay").Visible = True
            gvPrint.Columns("OverKgsPay").Visible = False
            gvPrint.Columns("LowerKgsPay").Visible = False
            gvPrint.Columns("OverSheetsPay").Visible = False
            gvPrint.Columns("LowerSheetsPay").Visible = False
            gvPrint.Columns("SmokingSheetsPay").Visible = False
            gvPrint.Columns("OTPay").Visible = False
            gvPrint.Columns("WCPay").Visible = False
            gvPrint.Columns("EvalutionAllowance").Visible = False
            gvPrint.Columns("GrandTotalPay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPFAmount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("PayChit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("FestivalAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("CashAdvance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("TotalDeductions").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("BalancePay").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPF_12").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("EPF_20").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            gvPrint.Columns("ETF_3").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
           
            gvPrint.Columns("EPF_12").Caption = "EPF (12%)"
            gvPrint.Columns("EPF_20").Caption = "EPF (20%)"
            gvPrint.Columns("ETF_3").Caption = "ETF (3%)"

            gvPrint.Columns("EPF_12").Width = 60
            gvPrint.Columns("EPF_20").Width = 60
            gvPrint.Columns("ETF_3").Width = 60

            For index = 0 To gvPrint.Columns.Count - 1

                If IsDate(gvPrint.Columns(index).FieldName) Then

                    gvPrint.Columns(index).Visible = False


                End If

            Next


            '*********************************************
            For index = 0 To gvCheckRoll.Columns.Count - 1

                If IsDate(gvCheckRoll.Columns(index).FieldName) Then

                    gvCheckRoll.Columns(index).Caption = DatePart(DateInterval.Day, Convert.ToDateTime(gvCheckRoll.Columns(index).FieldName)).ToString()
                    'gvCheckRoll.Columns(index).SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count

                    gvCheckRoll.Columns(index).Width = 45


                End If

            Next





        End If
        gcCheckRoll.Refresh()
        gcCheckRoll.RefreshDataSource()
     
    End Sub


#End Region



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

    Private Sub gvCheckRoll_CustomDrawCell(sender As Object, e As Views.Base.RowCellCustomDrawEventArgs) Handles gvCheckRoll.CustomDrawCell

     

    End Sub
End Class