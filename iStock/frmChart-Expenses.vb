Public Class frmChart_Expenses

#Region "Variables"

    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome
    Private _CWBCharts As iStockCommon.iStockCharts
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking

#End Region

#Region "Constructor"

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

        Dim ds As New DataSet
        Dim dt As New DataTable

        ds = iStockDailyWorking.GetCheckRollReport(currentDate)

        Dim salarypermanent As Decimal = 0
        Dim epf12 As Decimal = 0
        Dim etf3 As Decimal = 0

        If (ds IsNot Nothing And ds.Tables.Count > 0) Then

            For Each dr As DataRow In ds.Tables(0).Rows
                salarypermanent = salarypermanent + Convert.ToDecimal(dr("GrandTotalPay").ToString)
                epf12 = epf12 + Convert.ToDecimal(dr("EPF_12").ToString)
                etf3 = epf12 + Convert.ToDecimal(dr("ETF_3").ToString)
            Next

        End If

        Dim ds1 As New DataSet

        Dim salarycasual As Decimal = 0
        ds1 = iStockDailyWorking.GetCheckRollCasualReport(currentDate, 0)

        If (ds1 IsNot Nothing And ds1.Tables.Count > 0) Then
            For Each dr As DataRow In ds1.Tables(0).Rows
                salarycasual = salarycasual + Convert.ToDecimal(dr("GrandTotalPay").ToString)

            Next
        End If



        CWBCharts.Year = leYear.EditValue
        CWBCharts.Month = meMonth.EditValue
        dt = CWBCharts.ChartExpenses().Tables(0)

        If (dt IsNot Nothing And dt.Rows.Count > 0) Then

            Dim index As Integer
            For index = 0 To dt.Rows.Count - 1

                If (dt.Rows(index)("Description") = "Balance Salary") Then
                    dt.Rows(index)("Amount") = salarypermanent + salarycasual
                ElseIf (dt.Rows(index)("Description") = "EPF 12%") Then
                    dt.Rows(index)("Amount") = epf12
                ElseIf (dt.Rows(index)("Description") = "EPF 3%") Then
                    dt.Rows(index)("Amount") = etf3
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