Public Class frmChart_Expenses

#Region "Variables"

    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome
    Private _CWBCharts As iStockCommon.iStockCharts
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _PL As iStockCommon.iStockProfitAndLoss
#End Region

#Region "Constructor"


    Public ReadOnly Property PL() As iStockCommon.iStockProfitAndLoss
        Get

            If _PL Is Nothing Then
                _PL = New iStockCommon.iStockProfitAndLoss
            End If

            Return _PL
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
    Public ReadOnly Property CWBCharts() As iStockCommon.iStockCharts
        Get

            If _CWBCharts Is Nothing Then
                _CWBCharts = New iStockCommon.iStockCharts
            End If

            Return _CWBCharts
        End Get
    End Property

    Public ReadOnly Property CWBOtherIncome() As iStockCommon.iStockOtherIncome
        Get

            If _CWBOtherIncome Is Nothing Then
                _CWBOtherIncome = New iStockCommon.iStockOtherIncome()
            End If

            Return _CWBOtherIncome
        End Get
    End Property

#End Region

#Region "Form Events"

    Private Sub frmChart_income_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadYears()

    End Sub

    Private Sub frmChart_income_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated

    End Sub

    Private Sub frmChart_income_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
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

#Region "Editor Events"

    Private Sub sbProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess.Click
        If dxvpCommon.Validate Then
            Me.BindChart()
        End If
    End Sub



    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintChartPreview(Chart, "Expenses chart")
    End Sub
#End Region

#Region "Bind Chart"

    Private Sub BindChart()

        Dim selectedMonth, selectedYear As String
        Dim currentDate As Date
        selectedMonth = meMonth.EditValue
        selectedYear = leYear.EditValue
        currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

       

        Dim totalSalary As Decimal
        Dim PermenentTotal As Decimal
        Dim CasualTotalto15 As Decimal
        Dim CasualTotal5toEOM As Decimal
        Dim cashAdvancePermanent As Decimal
        Dim cashAdvanceCasual As Decimal
        Dim cashAdvanceAdmin As Decimal
        Dim cashAdvanceTotal As Decimal
        Dim cashRewards As Decimal
        Dim festivalAdvance As Decimal
        Dim KPB As Decimal
        Dim EPF_12 As Decimal
        Dim ETF_3 As Decimal

        Dim ds As New DataSet
        PL.FromDate = currentDate
        ds = PL.GetMonthlyExpenses()

        If (ds IsNot Nothing And ds.Tables.Count > 0) Then

            For Each dr As DataRow In ds.Tables(0).Rows
                PermenentTotal = PermenentTotal + Convert.ToDecimal(dr("PermenentTotal").ToString)
            Next

            For Each dr As DataRow In ds.Tables(1).Rows
                CasualTotalto15 = CasualTotalto15 + Convert.ToDecimal(dr("CasualTotalto15").ToString)
            Next

            For Each dr As DataRow In ds.Tables(2).Rows
                CasualTotal5toEOM = CasualTotal5toEOM + Convert.ToDecimal(dr("CasualTotal5toEOM").ToString)
            Next

            For Each dr As DataRow In ds.Tables(3).Rows
                KPB = KPB + Convert.ToDecimal(dr("KPB").ToString) 'admin salary
            Next

            For Each dr As DataRow In ds.Tables(4).Rows
                cashAdvancePermanent = cashAdvancePermanent + Convert.ToDecimal(dr("CashAdvance").ToString)
            Next

            For Each dr As DataRow In ds.Tables(5).Rows
                cashAdvanceCasual = cashAdvanceCasual + Convert.ToDecimal(dr("CashAdvance").ToString)
            Next


            For Each dr As DataRow In ds.Tables(10).Rows
                cashAdvanceAdmin = cashAdvanceAdmin + Convert.ToDecimal(dr("StaffAdvance").ToString)
            Next

            For Each dr As DataRow In ds.Tables(6).Rows
                festivalAdvance = festivalAdvance + Convert.ToDecimal(dr("FestivalAdvance").ToString)
            Next


            For Each dr As DataRow In ds.Tables(7).Rows
                EPF_12 = EPF_12 + Convert.ToDecimal(dr("EPF_12").ToString)
            Next


            For Each dr As DataRow In ds.Tables(8).Rows
                ETF_3 = ETF_3 + Convert.ToDecimal(dr("ETF_3").ToString)
            Next

            For Each dr As DataRow In ds.Tables(12).Rows
                cashRewards = cashRewards + Convert.ToDecimal(dr("CashRewards").ToString)
            Next


            totalSalary = PermenentTotal + CasualTotalto15 + CasualTotal5toEOM + KPB
            cashAdvanceTotal = cashAdvancePermanent + cashAdvanceCasual + cashAdvanceAdmin

        End If






        CWBCharts.Year = leYear.EditValue
        CWBCharts.Month = meMonth.EditValue

        Dim dt As New DataTable
        dt = CWBCharts.ChartExpenses().Tables(0)

        If (dt IsNot Nothing And dt.Rows.Count > 0) Then

            Dim index As Integer
            For index = 0 To dt.Rows.Count - 1

                If (dt.Rows(index)("Description") = "Balance Salary") Then
                    dt.Rows(index)("Amount") = totalSalary
                ElseIf (dt.Rows(index)("Description") = "Cash Advance") Then
                    dt.Rows(index)("Amount") = cashAdvanceTotal
                ElseIf (dt.Rows(index)("Description") = "Cash Rewards") Then
                    dt.Rows(index)("Amount") = cashRewards
                ElseIf (dt.Rows(index)("Description") = "EPF 12%") Then
                    dt.Rows(index)("Amount") = EPF_12
                ElseIf (dt.Rows(index)("Description") = "EPF 3%") Then
                    dt.Rows(index)("Amount") = ETF_3

                End If

            Next

        End If


      
        Chart.DataSource = dt

        Dim ct As New DevExpress.XtraCharts.ChartTitle
        ct.Text = "Expenses - " + leYear.Text + " - " + meMonth.Text
        Chart.Titles.Clear()
        Chart.Titles.Add(ct)



    End Sub

#End Region


End Class