Public Class frmMonthlyExpenses

    Dim PermanentSalaryTotal = 0
    Dim CasualSalaryTotal As Decimal = 0
    Dim StaffSalaryTotal = 0
    Dim TotalSalary As Decimal = 0

    Dim SubTotal1 As Decimal = 0

    Dim PermanentAdvPay As Decimal = 0
    Dim CasualAdvPay As Decimal = 0
    Dim StaffAdvPay As Decimal = 0
    Dim TotalAdvPay As Decimal = 0

    Dim FestivalAdvanceTotal As Decimal = 0
    Dim total As Decimal = 0
    Dim OtherExpenseTotal As Decimal = 0

    Dim ExpenseWaterTotal As Decimal = 0
    Dim ExpenseElectricityTotal As Decimal = 0
    Dim ExpenseMotivationTotal As Decimal = 0
    Dim ExpenseCachRewardsTotal As Decimal = 0
    Dim ExpenseOtherTotal As Decimal = 0


    Dim EPFTotal As Decimal = 0
    Dim ETFTotal As Decimal = 0

    Dim GrandTotal As Decimal = 0

    Private _PL As iStockCommon.iStockProfitAndLoss

    Public ReadOnly Property PL() As iStockCommon.iStockProfitAndLoss
        Get

            If _PL Is Nothing Then
                _PL = New iStockCommon.iStockProfitAndLoss
            End If

            Return _PL
        End Get
    End Property

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

    Private Sub frmMonthlyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
    End Sub

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        If dxvpMonthlyReport.Validate Then

            total = 0
            FestivalAdvanceTotal = 0
            PermanentAdvPay = 0
            PermanentSalaryTotal = 0
            CasualSalaryTotal = 0
            StaffSalaryTotal = 0


            SubTotal1 = 0

            Dim currentDate As Date
            Dim selectedMonth, selectedYear As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

            Dim report As New xrpMonthlyExpensesDetails
            frmPrint.PrintControl1.PrintingSystem = report.PrintingSystem

            report.XrLabel2.Text = "MONTHLY EXPENSES OF  " & meMonth.Text & "-" & leYear.Text

            Dim ds As New DataSet
            PL.FromDate = currentDate
            ds = PL.GetMonthlyExpenses()

            Dim dt1 As DataTable 'Permenant Salary
            Dim dt2 As DataTable 'Casual Salary 1-15
            Dim dt3 As DataTable 'Casual Salary 15-EOM
            Dim dt4 As DataTable 'KP Balance 
            Dim dt5 As DataTable 'Permenant Cash Advance 
            Dim dt6 As DataTable 'Staff Cash Advance 
            Dim dt7 As DataTable 'Festival Advance - permnent
            Dim dt8 As DataTable 'EPF 12% 
            Dim dt9 As DataTable 'ETF 3%
            Dim dt10 As DataTable ' Other Expenses
            Dim dt11 As DataTable 'KP Advance
            Dim dt12 As DataTable 'Investments
            Dim dt13 As DataTable 'CashRewards
            Dim dt14 As DataTable 'Festival Advance - Casual
            Dim dt15 As DataTable 'Festival Advance - Staff
            Dim dt16 As DataTable 'Casual Cash Advance 



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
            dt16 = ds.Tables(15)



            'Balance Salary - Permanent

            If dt1.Rows.Count > 0 Then

                Dim r0 As New DevExpress.XtraReports.UI.XRTableRow
                r0 = report.xrMainTable.Rows("row0")
                If IsDBNull(dt1.Rows(0).Item("PermenentTotal")) Then

                    r0.Cells("r1c5").Text = "0.00"
                Else
                    r0.Cells("r1c5").Text = FormatNumber(CStr((dt1.Rows(0).Item("PermenentTotal"))) & Space(1), 2, TriState.True)
                    PermanentSalaryTotal = Convert.ToDecimal(dt1.Rows(0).Item("PermenentTotal").ToString())

                End If

            End If

            
            'Balance Salary - Casual (1-15)

            If dt2.Rows.Count > 0 Then

                Dim r2 As New DevExpress.XtraReports.UI.XRTableRow
                r2 = report.xrMainTable.Rows("row2")

                If IsDBNull(dt2.Rows(0).Item("CasualTotalto15")) Then
                    r2.Cells("r3c4").Text = "0.00 "
                Else
                    r2.Cells("r3c4").Text = FormatNumber(CStr((dt2.Rows(0).Item("CasualTotalto15"))), 2, TriState.True) & " "
                    CasualSalaryTotal = Convert.ToDecimal(dt2.Rows(0).Item("CasualTotalto15").ToString())
                End If

            End If


            'Balance Salary - Casual (1-EOM)

            If dt3.Rows.Count > 0 Then

                Dim r3 As New DevExpress.XtraReports.UI.XRTableRow
                r3 = report.xrMainTable.Rows("row3")

                If IsDBNull(dt3.Rows(0).Item("CasualTotal5toEOM")) Then
                    r3.Cells("r4c4").Text = "0.00 "
                Else
                    r3.Cells("r4c4").Text = FormatNumber(CStr((dt3.Rows(0).Item("CasualTotal5toEOM"))), 2, TriState.True) & " "
                    CasualSalaryTotal = CasualSalaryTotal + Convert.ToDecimal((dt3.Rows(0).Item("CasualTotal5toEOM").ToString))
                End If

                r3.Cells("r3casualTotal").Text = FormatNumber(CasualSalaryTotal.ToString, 2, TriState.True)

            End If




            'Balance Salary - Staff 

            If dt4.Rows.Count > 0 Then

                Dim r5 As New DevExpress.XtraReports.UI.XRTableRow
                r5 = report.xrMainTable.Rows("row5")

                If IsDBNull(dt4.Rows(0).Item("KPB")) Then
                    r5.Cells("r6c4").Text = "0.00 "
                Else
                    r5.Cells("r6c4").Text = FormatNumber(CStr((dt4.Rows(0).Item("KPB"))), 2, TriState.True) & " "
                    StaffSalaryTotal = StaffSalaryTotal + Convert.ToDecimal((dt4.Rows(0).Item("KPB").ToString))
                End If

                r5.Cells("balanceSalaryTotal").Text = FormatNumber((PermanentSalaryTotal + CasualSalaryTotal + StaffSalaryTotal).ToString, 2, TriState.True)


            End If



            'Cash Advance - Permanent

            If dt5.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt5.Rows.Count - 1

                    '      Dim AdvTot As Decimal

                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)


                    If IsDBNull(dt5.Rows(i).Item("IssueDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt5.Rows(i).Item("IssueDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt5.Rows(i).Item("EmployeeName")))

                    If IsDBNull(dt5.Rows(i).Item("AdvanceAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt5.Rows(i).Item("AdvanceAmount"))), 2, TriState.True) & " "
                        PermanentAdvPay = PermanentAdvPay + Convert.ToDecimal((dt5.Rows(i).Item("AdvanceAmount").ToString))
                    End If

                    'AdvTot = AdvTot + (dt5.Rows(i).Item("AdvanceAmount"))

                    'If i = dt5.Rows.Count - 1 Then
                    '    cell4.Text = FormatNumber(AdvTot, 2, TriState.True)
                    'End If



                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)


                    xx.Rows.Add(tr)

                Next

                Dim r7 As New DevExpress.XtraReports.UI.XRTableRow
                r7 = report.xrMainTable.Rows("row7")
                r7.Cells("rCashAdvancePermanent").Controls.Add(xx)

            End If



            '*****************************************************************************************
            'Cash Advance - Casual


            If dt16.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt16.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    If IsDBNull(dt16.Rows(i).Item("IssueDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt16.Rows(i).Item("IssueDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt16.Rows(i).Item("EmployeeName")))

                    If IsDBNull(dt16.Rows(i).Item("AdvanceAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt16.Rows(i).Item("AdvanceAmount"))), 2, TriState.True) & " "
                        PermanentAdvPay = PermanentAdvPay + Convert.ToDecimal((dt16.Rows(i).Item("AdvanceAmount").ToString))
                    End If


                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r91 As New DevExpress.XtraReports.UI.XRTableRow
                r91 = report.xrMainTable.Rows("row91")
                r91.Cells("rCashAdvanceCasual").Controls.Add(xx)
                ' r91.Cells("rCashAdvanceTotal").Text = FormatNumber((PermanentAdvPay).ToString, 2, TriState.True)

            End If

            '*****************************************************************************************

            'Cash Advance - Staff

            If dt6.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt6.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    If IsDBNull(dt6.Rows(i).Item("IssueDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt6.Rows(i).Item("IssueDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt6.Rows(i).Item("EmployeeName")))

                    If IsDBNull(dt6.Rows(i).Item("AdvanceAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt6.Rows(i).Item("AdvanceAmount"))), 2, TriState.True) & " "
                        PermanentAdvPay = PermanentAdvPay + Convert.ToDecimal((dt6.Rows(i).Item("AdvanceAmount").ToString))
                    End If


                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r9 As New DevExpress.XtraReports.UI.XRTableRow
                r9 = report.xrMainTable.Rows("row9")
                r9.Cells("rCashAdvanceStaff").Controls.Add(xx)
                r9.Cells("rCashAdvanceTotal").Text = FormatNumber((PermanentAdvPay).ToString, 2, TriState.True)

            End If

            'Festival Advance - Permanent


            If dt7.Rows.Count > 0 Then


                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt7.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    If IsDBNull(dt7.Rows(i).Item("TDDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt7.Rows(i).Item("TDDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt7.Rows(i).Item("EmployerName")))

                    If IsDBNull(dt7.Rows(i).Item("TDAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt7.Rows(i).Item("TDAmount"))), 2, TriState.True) & " "
                        FestivalAdvanceTotal = FestivalAdvanceTotal + Convert.ToDecimal((dt7.Rows(i).Item("TDAmount").ToString))
                    End If


                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next
                Dim r12 As New DevExpress.XtraReports.UI.XRTableRow

                r12 = report.xrMainTable.Rows("row12")
                r12.Cells("rFestivalAdvancePermanent").Controls.Add(xx)

            End If

            'Festival Advance - Casual


            If dt14.Rows.Count > 0 Then



                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt14.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    If IsDBNull(dt14.Rows(i).Item("TDDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt14.Rows(i).Item("TDDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt14.Rows(i).Item("EmployerName")))

                    If IsDBNull(dt14.Rows(i).Item("TDAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt14.Rows(i).Item("TDAmount"))), 2, TriState.True) & " "
                        FestivalAdvanceTotal = FestivalAdvanceTotal + Convert.ToDecimal((dt14.Rows(i).Item("TDAmount").ToString))
                    End If


                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r14 As New DevExpress.XtraReports.UI.XRTableRow
                r14 = report.xrMainTable.Rows("row14")
                r14.Cells("rFestivalAdvanceCasual").Controls.Add(xx)

            End If

            'Festival Advance - Staff


            If dt15.Rows.Count > 0 Then


                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt15.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    If IsDBNull(dt15.Rows(i).Item("TDDate")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = Convert.ToDateTime(dt15.Rows(i).Item("TDDate").ToString).ToString("dd-MMM-yy")
                    End If


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt15.Rows(i).Item("EmployerName")))

                    If IsDBNull(dt15.Rows(i).Item("TDAmount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt15.Rows(i).Item("TDAmount"))), 2, TriState.True) & " "
                        FestivalAdvanceTotal = FestivalAdvanceTotal + Convert.ToDecimal((dt15.Rows(i).Item("TDAmount").ToString))
                    End If


                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r16 As New DevExpress.XtraReports.UI.XRTableRow
                r16 = report.xrMainTable.Rows("row16")
                r16.Cells("rFestivalAdvanceStaff").Controls.Add(xx)



            End If

            Dim r16a As New DevExpress.XtraReports.UI.XRTableRow
            r16a = report.xrMainTable.Rows("row16")


            r16a.Cells("rFestivalAdvance").Text = FormatNumber((FestivalAdvanceTotal).ToString, 2, TriState.True)
            total = FestivalAdvanceTotal + PermanentAdvPay + PermanentSalaryTotal + CasualSalaryTotal + StaffSalaryTotal

            r16a.Cells("rTotal").Text = FormatNumber((total).ToString, 2, TriState.True)

            'EPF 12 %

            If dt8.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable


                For i = 0 To dt8.Rows.Count - 1



                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt8.Rows(i).Item("EmployeeName")))


                    If IsDBNull(dt8.Rows(i).Item("EPF_12")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt8.Rows(i).Item("EPF_12"))), 2, TriState.True) & " "
                        EPFTotal = EPFTotal + Convert.ToDecimal((dt8.Rows(i).Item("EPF_12").ToString))
                    End If

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r18 As New DevExpress.XtraReports.UI.XRTableRow
                r18 = report.xrMainTable.Rows("row18")

                r18.Cells("rEPF12").Controls.Add(xx)


            End If

            Dim r18a As New DevExpress.XtraReports.UI.XRTableRow
            r18a = report.xrMainTable.Rows("row18")

            '   r18a.Cells("rEPFTotal").Text = FormatNumber((EPFTotal).ToString, 2, TriState.True)
            r18a.Cells("rEPFTotal1").Text = FormatNumber((EPFTotal).ToString, 2, TriState.True)

            'ETF 3%

            If dt9.Rows.Count > 0 Then
                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt9.Rows.Count - 1



                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 452.92

                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    'xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.All

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(244.54, 25)
                    cell3.Size = New Size(100.4, 25)

                    cell1.Text = ""


                    cell2.Text = "[" + CStr((dt5.Rows(i).Item("EmployerNo"))) + "] " + CStr((dt9.Rows(i).Item("EmployeeName")))


                    If IsDBNull(dt9.Rows(i).Item("ETF_3")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dt9.Rows(i).Item("ETF_3"))), 2, TriState.True) & " "
                        ETFTotal = ETFTotal + Convert.ToDecimal((dt9.Rows(i).Item("ETF_3").ToString))
                    End If

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Borders = DevExpress.XtraPrinting.BorderSide.Right


                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)

                    xx.Rows.Add(tr)


                Next

                Dim r20 As New DevExpress.XtraReports.UI.XRTableRow
                r20 = report.xrMainTable.Rows("row20")
                r20.Cells("rEPF3").Controls.Add(xx)


            End If

            Dim r20a As New DevExpress.XtraReports.UI.XRTableRow
            r20a = report.xrMainTable.Rows("row20")

            ' r20a.Cells("rEPF3Total").Text = FormatNumber((ETFTotal).ToString, 2, TriState.True)
            r20a.Cells("rEPF3Total1").Text = FormatNumber((ETFTotal).ToString, 2, TriState.True)

            'Exepenses Water

            If dt10.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                Dim dv As DataView
                dv = dt10.DefaultView
                'dv.Sort = "DESCRIPTION ASC"
                dv.RowFilter = "Description ='WATER'"


                For i = 0 To dv.Count - 1


                    Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

                    xx.WidthF = 862.9
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)


                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(344.95, 25)
                    cell3.Size = New Size(111.65, 25)
                    cell4.Size = New Size(114.26, 25)
                    cell5.Size = New Size(184.06, 25)

                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft


                    If IsDBNull(dv(i).Item("ExpenseDate")) Then
                        cell1.Text = String.Empty
                    Else
                        cell1.Text = Convert.ToDateTime(CStr((dv(i).Item("ExpenseDate").ToString))).ToString("dd-MMM-yy")
                    End If


                    If IsDBNull(dv(i).Item("Description")) Then
                        cell2.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell2.Text = IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)

                    End If

                    If IsDBNull(dv(i).Item("Amount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dv(i).Item("Amount"))), 2, TriState.True) & " "
                        ExpenseWaterTotal = ExpenseWaterTotal + Convert.ToDecimal((dv(i).Item("Amount").ToString))
                    End If

                    cell4.Text = ""

                    If IsDBNull(dv(i).Item("Remarks")) Then
                        cell5.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell5.Text = IIf(IsDBNull(dv(i).Item("Remarks")), String.Empty, dv(i).Item("Remarks").ToString)

                    End If


      



                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)

                    xx.Rows.Add(tr)
                Next

                Dim r22 As New DevExpress.XtraReports.UI.XRTableRow
                r22 = report.xrMainTable.Rows("row22")
                r22.Cells("rExpensesWater").Controls.Add(xx)


                'Dim r22a As New DevExpress.XtraReports.UI.XRTableRow
                'r22a = report.xrMainTable.Rows("row22")

                '' r22a.Cells("rExpenseWaterTotal").Text = FormatNumber((ExpenseWaterTotal).ToString, 2, TriState.True)
                'r22a.Cells("rExpenseWaterTotal1").Text = FormatNumber((ExpenseWaterTotal).ToString, 2, TriState.True)
                report.rExpenseWaterTotal.Text = FormatNumber((ExpenseWaterTotal).ToString, 2, TriState.True)
                report.rExpenseWaterTotal1.Text = FormatNumber((ExpenseWaterTotal).ToString, 2, TriState.True)
            End If

          
            'Expenses Electrity

            If dt10.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                Dim dv As DataView
                dv = dt10.DefaultView
                dv.RowFilter = "Description ='ELECTRICITY'"

                For i = 0 To dv.Count - 1

                    Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

                    xx.WidthF = 862.9
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)

                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(344.95, 25)
                    cell3.Size = New Size(111.65, 25)
                    cell4.Size = New Size(114.26, 25)
                    cell5.Size = New Size(184.06, 25)

                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                  

                    If IsDBNull(dv(i).Item("ExpenseDate")) Then
                        cell1.Text = String.Empty
                    Else
                        cell1.Text = Convert.ToDateTime(CStr((dv(i).Item("ExpenseDate").ToString))).ToString("dd-MMM-yy")
                    End If


                    If IsDBNull(dv(i).Item("Description")) Then
                        cell2.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell2.Text = IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)

                    End If

                    If IsDBNull(dv(i).Item("Amount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dv(i).Item("Amount"))), 2, TriState.True) & " "
                        ExpenseElectricityTotal = ExpenseElectricityTotal + Convert.ToDecimal((dv(i).Item("Amount").ToString))
                    End If

                    cell4.Text = ""

                    If IsDBNull(dv(i).Item("Remarks")) Then
                        cell5.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell5.Text = IIf(IsDBNull(dv(i).Item("Remarks")), String.Empty, dv(i).Item("Remarks").ToString)

                    End If

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft

                  
                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)

                    xx.Rows.Add(tr)
                Next

                Dim r23 As New DevExpress.XtraReports.UI.XRTableRow
                r23 = report.xrMainTable.Rows("row23")
                r23.Cells("rExprenesEletricity").Controls.Add(xx)

                'Dim r23a As New DevExpress.XtraReports.UI.XRTableRow
                'r23a = report.xrMainTable.Rows("row23")

                ' r23a.Cells("rExpenseElectrityTotal").Text = FormatNumber((ExpenseElectricityTotal).ToString, 2, TriState.True)
                'r23a.Cells("rExpenseElectrityTotal1").Text = FormatNumber((ExpenseElectricityTotal).ToString, 2, TriState.True)

                report.rExpenseElectrityTotal.Text = FormatNumber((ExpenseElectricityTotal).ToString, 2, TriState.True)
                report.rExpenseElectrityTotal1.Text = FormatNumber((ExpenseElectricityTotal).ToString, 2, TriState.True)


            End If



            'Expenses Motivation Paymenet

            If dt10.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                Dim dv As DataView
                dv = dt10.DefaultView
                dv.RowFilter = "Description ='MOTIVATION PAYMENTS'"

                For i = 0 To dv.Count - 1

                    Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

                    xx.WidthF = 862.9
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)


                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(344.95, 25)
                    cell3.Size = New Size(111.65, 25)
                    cell4.Size = New Size(114.26, 25)
                    cell5.Size = New Size(184.06, 25)

                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft

                    If IsDBNull(dv(i).Item("ExpenseDate")) Then
                        cell1.Text = String.Empty
                    Else
                        cell1.Text = Convert.ToDateTime(CStr((dv(i).Item("ExpenseDate").ToString))).ToString("dd-MMM-yy")
                    End If


                    If IsDBNull(dv(i).Item("Description")) Then
                        cell2.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell2.Text = IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)

                    End If

                    If IsDBNull(dv(i).Item("Amount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dv(i).Item("Amount"))), 2, TriState.True) & " "
                        ExpenseMotivationTotal = ExpenseMotivationTotal + Convert.ToDecimal((dv(i).Item("Amount").ToString))
                    End If

                    cell4.Text = ""

                    If IsDBNull(dv(i).Item("Remarks")) Then
                        cell5.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell5.Text = IIf(IsDBNull(dv(i).Item("Remarks")), String.Empty, dv(i).Item("Remarks").ToString)

                    End If

                 

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)

                    xx.Rows.Add(tr)
                Next

                Dim r25 As New DevExpress.XtraReports.UI.XRTableRow
                r25 = report.xrMainTable.Rows("row25")
                r25.Cells("rExprenesMotivation").Controls.Add(xx)

                'Dim r25a As New DevExpress.XtraReports.UI.XRTableRow
                'r25a = report.xrMainTable.Rows("row25")

                'r25a.Cells("rExprenesMotivationTotal").Text = FormatNumber((ExpenseMotivationTotal).ToString, 2, TriState.True)
                'r25a.Cells("rExprenesMotivationTotal1").Text = FormatNumber((ExpenseMotivationTotal).ToString, 2, TriState.True)

                report.rExprenesMotivationTotal.Text = FormatNumber((ExpenseMotivationTotal).ToString, 2, TriState.True)
                report.rExprenesMotivationTotal1.Text = FormatNumber((ExpenseMotivationTotal).ToString, 2, TriState.True)

            End If


            'Expenses cash rewards

            If dt10.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                Dim dv As DataView
                dv = dt10.DefaultView
                dv.RowFilter = "Description ='CASH REWARDS'"

                For i = 0 To dv.Count - 1

                    Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

                    xx.WidthF = 862.9
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)


                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(344.95, 25)
                    cell3.Size = New Size(111.65, 25)
                    cell4.Size = New Size(114.26, 25)
                    cell5.Size = New Size(184.06, 25)

                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft

                    If IsDBNull(dv(i).Item("ExpenseDate")) Then
                        cell1.Text = String.Empty
                    Else
                        cell1.Text = Convert.ToDateTime(CStr((dv(i).Item("ExpenseDate").ToString))).ToString("dd-MMM-yy")
                    End If


                    If IsDBNull(dv(i).Item("Description")) Then
                        cell2.Text = String.Empty
                    Else
                        ' cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell2.Text = IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)

                    End If

                    If IsDBNull(dv(i).Item("Amount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dv(i).Item("Amount"))), 2, TriState.True) & " "
                        ExpenseCachRewardsTotal = ExpenseCachRewardsTotal + Convert.ToDecimal((dv(i).Item("Amount").ToString))
                    End If

                    If IsDBNull(dv(i).Item("Remarks")) Then
                        cell5.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell5.Text = IIf(IsDBNull(dv(i).Item("Remarks")), String.Empty, dv(i).Item("Remarks").ToString)

                    End If

                
                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)

                    xx.Rows.Add(tr)
                Next

                Dim r25 As New DevExpress.XtraReports.UI.XRTableRow
                r25 = report.xrMainTable.Rows("row26")
                r25.Cells("rExprenesCashRewards").Controls.Add(xx)

                'Dim r25a As New DevExpress.XtraReports.UI.XRTableRow
                'r25a = report.xrMainTable.Rows("row26")

                'r25a.Cells("rExprenesCashRewardsTotal").Text = FormatNumber((ExpenseCachRewardsTotal).ToString, 2, TriState.True)
                ' r25a.Cells("rExprenesCashRewardsTotal1").Text = FormatNumber((ExpenseCachRewardsTotal).ToString, 2, TriState.True)

                report.rExprenesCashRewardsTotal2.Text = FormatNumber((ExpenseCachRewardsTotal).ToString, 2, TriState.True)
                report.rExprenesCashRewardsTotal3.Text = FormatNumber((ExpenseCachRewardsTotal).ToString, 2, TriState.True)


            End If


            'Expenses Other

            If dt10.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                Dim dv As DataView
                dv = dt10.DefaultView
                dv.RowFilter = "Description <>'WATER' and  Description <> 'ELECTRICITY' and Description <>'MOTIVATION PAYMENTS' and Description <> 'CASH REWARDS'"

                For i = 0 To dv.Count - 1

                    Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

                    xx.WidthF = 862.9
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Right) Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)


                    cell1.Size = New Size(107.98, 25)
                    cell2.Size = New Size(344.95, 25)
                    cell3.Size = New Size(111.65, 25)
                    cell4.Size = New Size(114.26, 25)
                    cell5.Size = New Size(184.06, 25)

                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft


                    If IsDBNull(dv(i).Item("ExpenseDate")) Then
                        cell1.Text = String.Empty
                    Else
                        cell1.Text = Convert.ToDateTime(CStr((dv(i).Item("ExpenseDate").ToString))).ToString("dd-MMM-yy")
                    End If


                    If IsDBNull(dv(i).Item("Description")) Then
                        cell2.Text = String.Empty
                    Else
                        cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                    End If

                    If IsDBNull(dv(i).Item("Amount")) Then
                        cell3.Text = "0.00 "
                    Else
                        cell3.Text = FormatNumber(CStr((dv(i).Item("Amount"))), 2, TriState.True) & " "
                        ExpenseOtherTotal = ExpenseOtherTotal + Convert.ToDecimal((dv(i).Item("Amount").ToString))
                    End If

                    cell4.Text = ""

                    If IsDBNull(dv(i).Item("Remarks")) Then
                        cell5.Text = String.Empty
                    Else
                        'cell2.Text = CStr((dv(i).Item("Description").ToString.Trim)) + "-" + IIf(IsDBNull(dv(i).Item("Note")), String.Empty, dv(i).Item("Note").ToString)
                        cell5.Text = IIf(IsDBNull(dv(i).Item("Remarks")), String.Empty, dv(i).Item("Remarks").ToString)

                    End If

                
                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)

                    xx.Rows.Add(tr)
                Next

                Dim r27 As New DevExpress.XtraReports.UI.XRTableRow
                r27 = report.xrMainTable.Rows("row27")
                r27.Cells("rExprenesOther").Controls.Add(xx)

                'Dim r27a As New DevExpress.XtraReports.UI.XRTableRow
                'r27a = report.xrMainTable.Rows("row27")

                '  r27a.Cells("rExprenesOtherTotal").Text = FormatNumber((ExpenseOtherTotal).ToString, 2, TriState.True)
                'r27a.Cells("rExprenesOtherTotal1").Text = FormatNumber((ExpenseOtherTotal).ToString, 2, TriState.True)

                report.rExprenesOtherTotal.Text = FormatNumber((ExpenseOtherTotal).ToString, 2, TriState.True)
                report.rExprenesOtherTotal1.Text = FormatNumber((ExpenseOtherTotal).ToString, 2, TriState.True)

            End If
    

            GrandTotal = total + EPFTotal + ETFTotal + ExpenseWaterTotal + ExpenseElectricityTotal + ExpenseMotivationTotal + ExpenseCachRewardsTotal + ExpenseOtherTotal

            Dim r24 As New DevExpress.XtraReports.UI.XRTableRow
            r24 = report.xrMainTable.Rows("row24")
            r24.Cells("rGrandTotal").Text = FormatNumber((GrandTotal).ToString, 2, TriState.True)
            r24.Cells("rGrandTotal").ForeColor = Color.Red




            report.CreateDocument()
            report.BringToFront()
            frmPrint.MdiParent = frmMain
            frmPrint.Show()
            frmPrint.BringToFront()

        End If

    End Sub
End Class