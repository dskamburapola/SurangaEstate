Public Class frmChart_Income

#Region "Variables"

    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome
    Private _CWBCharts As iStockCommon.iStockCharts
    Private _PL As iStockCommon.iStockProfitAndLoss

#End Region

#Region "Constructor"

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
    Public ReadOnly Property PL() As iStockCommon.iStockProfitAndLoss
        Get

            If _PL Is Nothing Then
                _PL = New iStockCommon.iStockProfitAndLoss
            End If

            Return _PL
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
        PrintChartPreview(Chart, "Income, Expenses and Profit chart")
    End Sub

#End Region

#Region "Bind Chart"

    Private Sub BindChart()



        CWBCharts.Year = leYear.EditValue
        CWBCharts.Month = meMonth.EditValue
        Dim dt As New DataTable
        dt = CWBCharts.ChartIncome().Tables(0)
        

        'Dim totalSalary As Decimal
        'Dim PermenentTotal As Decimal
        'Dim CasualTotalto15 As Decimal
        'Dim CasualTotal5toEOM As Decimal
        'Dim cashAdvancePermanent As Decimal
        'Dim cashAdvanceCasual As Decimal
        'Dim cashAdvanceAdmin As Decimal
        'Dim cashAdvanceTotal As Decimal
        'Dim festivalAdvance As Decimal
        'Dim KPB As Decimal
        'Dim EPF_12 As Decimal
        'Dim ETF_3 As Decimal
        Dim totalExpenes As Decimal

        Dim selectedMonth, selectedYear As String
        Dim currentDate As Date
        selectedMonth = meMonth.EditValue
        selectedYear = leYear.EditValue


        currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

        Dim ds As New DataSet
        PL.FromDate = currentDate
        ds = PL.GetMonthlyExpenses()

        Dim dt1 As DataTable 'Permenant Salary
        Dim dt2 As DataTable 'Casual Salary 1-15
        Dim dt3 As DataTable 'Casual Salary 15-EOM
        Dim dt4 As DataTable 'KP Balance 
        Dim dt5 As DataTable 'Permenant Cash Advance 
        Dim dt6 As DataTable 'Casual Cash Advance 
        Dim dt7 As DataTable 'Festival Advance - permnent
        Dim dt8 As DataTable 'EPF 12% 
        Dim dt9 As DataTable 'ETF 3%
        Dim dt10 As DataTable ' Other Expenses
        Dim dt11 As DataTable 'KP Advance
        Dim dt12 As DataTable 'Investments
        Dim dt13 As DataTable 'CashRewards
        Dim dt14 As DataTable 'Festival Advance - Casual
        Dim dt15 As DataTable 'Festival Advance - Staff

        dt1 = ds.Tables(0)
        dt2 = ds.Tables(1)
        dt3 = ds.Tables(2)
        dt4 = ds.Tables(3)
        dt5 = ds.Tables(4)
        dt6 = ds.Tables(5)
        dt7 = ds.Tables(6)
        dt8 = ds.Tables(7)
        dt9 = ds.Tables(8)
        dt10 = ds.Tables(9)
        dt11 = ds.Tables(10)
        dt12 = ds.Tables(11)
        dt13 = ds.Tables(12)
        dt14 = ds.Tables(13)
        dt15 = ds.Tables(14)


        If (ds IsNot Nothing And ds.Tables.Count > 0) Then

       

            If dt1.Rows.Count > 0 Then
                If Not IsDBNull(dt1.Rows(0).Item("PermenentTotal")) Then
                    totalExpenes = Convert.ToDecimal(dt1.Rows(0).Item("PermenentTotal").ToString())
                End If
            End If


            If dt2.Rows.Count > 0 Then
                If Not IsDBNull(dt2.Rows(0).Item("CasualTotalto15")) Then
                    totalExpenes = totalExpenes + Convert.ToDecimal(dt2.Rows(0).Item("CasualTotalto15").ToString())
                End If
            End If


            If dt3.Rows.Count > 0 Then
                If Not IsDBNull(dt3.Rows(0).Item("CasualTotal5toEOM")) Then
                    totalExpenes = totalExpenes + Convert.ToDecimal((dt3.Rows(0).Item("CasualTotal5toEOM").ToString))
                End If
            End If

            If dt4.Rows.Count > 0 Then
                If Not IsDBNull(dt4.Rows(0).Item("KPB")) Then
                    totalExpenes = totalExpenes + Convert.ToDecimal((dt4.Rows(0).Item("KPB").ToString))
                End If
            End If



            If dt5.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt5.Rows.Count - 1
                    If Not IsDBNull(dt5.Rows(i).Item("AdvanceAmount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt5.Rows(i).Item("AdvanceAmount").ToString))
                    End If
                Next
            End If


            If dt6.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt6.Rows.Count - 1
                    If Not IsDBNull(dt6.Rows(i).Item("AdvanceAmount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt6.Rows(i).Item("AdvanceAmount").ToString))
                    End If
                Next
            End If

           
            If dt7.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt7.Rows.Count - 1
                    If Not IsDBNull(dt7.Rows(i).Item("TDAmount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt7.Rows(i).Item("TDAmount").ToString))
                    End If
                Next
            End If


            If dt14.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt14.Rows.Count - 1
                    If Not IsDBNull(dt14.Rows(i).Item("TDAmount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt14.Rows(i).Item("TDAmount").ToString))
                    End If
                Next
            End If

            If dt15.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt15.Rows.Count - 1
                    If Not IsDBNull(dt15.Rows(i).Item("TDAmount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt15.Rows(i).Item("TDAmount").ToString))
                    End If
                Next
            End If

            If dt8.Rows.Count > 0 Then

                Dim i As Int64
                For i = 0 To dt8.Rows.Count - 1
                    If Not IsDBNull(dt8.Rows(i).Item("EPF_12")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt8.Rows(i).Item("EPF_12").ToString))
                    End If
                Next
            End If

            If dt9.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt9.Rows.Count - 1
                    If Not IsDBNull(dt9.Rows(i).Item("ETF_3")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt9.Rows(i).Item("ETF_3").ToString))
                    End If
                Next
            End If


            If dt10.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt10.Rows.Count - 1
                    If Not IsDBNull(dt10.Rows(i).Item("Amount")) Then
                        totalExpenes = totalExpenes + Convert.ToDecimal((dt10.Rows(i).Item("Amount").ToString))
                    End If
                Next
            End If

        End If


        Dim incomeDataTable As New DataTable
        incomeDataTable = PL.GetMonthlyIncome().Tables(0)

        Dim tolalIncome As Decimal = 0
        Dim tolDeductions As Decimal = 0
        Dim netIncome As Decimal = 0

        If incomeDataTable.Rows.Count > 0 Then
            Dim i As Int64
            For i = 0 To incomeDataTable.Rows.Count - 1

                If Not IsDBNull(incomeDataTable.Rows(i).Item("Amount")) Then
                    tolalIncome = tolalIncome + FormatNumber(CStr((incomeDataTable.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)
                End If

                If Not IsDBNull(incomeDataTable.Rows(i).Item("Deduction")) Then
                    tolDeductions = tolDeductions + FormatNumber(CStr((incomeDataTable.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                End If
            Next
        End If


        netIncome = tolalIncome - tolDeductions



        If (dt IsNot Nothing And dt.Rows.Count > 0) Then

            Dim Allexpenses As Decimal
            Dim AllIncome As Decimal

            Dim index As Integer
            For index = 0 To dt.Rows.Count - 1

                If (dt.Rows(index)("Description") = "Expenses") Then
                    dt.Rows(index)("Amount") = totalExpenes
                    Allexpenses = Convert.ToDecimal(dt.Rows(index)("Amount"))
                ElseIf (dt.Rows(index)("Description") = "Income") Then
                    dt.Rows(index)("Amount") = netIncome
                    AllIncome = Convert.ToDecimal(dt.Rows(index)("Amount"))
                ElseIf (dt.Rows(index)("Description") = "Profit") Then
                    dt.Rows(index)("Amount") = (AllIncome - Allexpenses)
                End If
            Next
        End If

        Chart.DataSource = dt

        Dim ct As New DevExpress.XtraCharts.ChartTitle
        ct.Text = "Income, Expenses and Profit - " + leYear.Text + " - " + meMonth.Text
        Chart.Titles.Clear()
        Chart.Titles.Add(ct)


    End Sub

#End Region



    Private Sub Chart_CustomDrawSeriesPoint(sender As Object, e As DevExpress.XtraCharts.CustomDrawSeriesPointEventArgs) Handles Chart.CustomDrawSeriesPoint
        e.LabelText = e.LabelText + " (" + FormatNumber(e.SeriesPoint.Values(0).ToString(), TriState.True) + ")"

    End Sub
End Class