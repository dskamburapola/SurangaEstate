Public Class frmMonthlyIncome

    Dim PermanentSalaryTotal = 0
    Dim CasualSalaryTotal As Decimal = 0
    Dim StaffSalaryTotal = 0
    Dim TotalSalary As Decimal = 0


    Dim PermanentAdvPay As Decimal = 0
    Dim CasualAdvPay As Decimal = 0
    Dim StaffAdvPay As Decimal = 0
    Dim TotalAdvPay As Decimal = 0

    Dim FestivalAdvanceTotal As Decimal = 0
    Dim OtherExpenseTotal As Decimal = 0

    Dim EPFTotal As Decimal = 0
    Dim ETFTotal As Decimal = 0

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


            Dim currentDate As Date
            Dim selectedMonth, selectedYear As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime("01-" + selectedMonth + "-" + selectedYear)

            Dim report As New xrpIncomeReport
            frmPrint.PrintControl1.PrintingSystem = report.PrintingSystem

            report.XrLabel1.Text = "MONTHLY INCOME OF  " & meMonth.Text & "-" & leYear.Text

            Dim ds As New DataSet
            PL.FromDate = currentDate
            ds = PL.GetMonthlyIncome()

            Dim dt1 As DataTable 'Tea
            'Dim dt2 As DataTable 'Rubber
            'Dim dt3 As DataTable 'Other
            'Dim dt4 As DataTable 'SDP



            dt1 = ds.Tables(0)
            'dt2 = ds.Tables(1)
            'dt3 = ds.Tables(2)
            'dt4 = ds.Tables(3)
          


            '******************************* Permenant Salary **************************************************************************
            If dt1.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt1.Rows.Count - 1

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1, cell2, cell3, cell4, cell5, cell6, cell7 As New DevExpress.XtraReports.UI.XRTableCell



                    cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1.Text = "Tea"

                    If IsDBNull(dt1.Rows(i).Item("OtherIncomeDate")) Then
                        cell2.Text = "  "
                    Else
                        Dim tempDate As Date
                        If DateTime.TryParse(CStr(dt1.Rows(i).Item("OtherIncomeDate").ToString), tempDate) Then
                            cell2.Text = tempDate.ToShortDateString
                        Else
                            cell2.Text = "  "
                        End If

                        '    cell2.Text = (dt1.Rows(i).Item("OtherIncomeDate").ToString())
                        'FormatNumber(CStr((dt1.Rows(i).Item("OtherIncomeDate"))) & Space(1), 2, TriState.True)
                      
                    End If



                    If IsDBNull(dt1.Rows(i).Item("Note")) Then
                        cell3.Text = " "
                    Else
                        cell3.Text = (dt1.Rows(i).Item("Note").ToString)
                        'FormatNumber(CStr((dt1.Rows(i).Item("Note"))) & Space(1), 2, TriState.True)
                       
                    End If


                    If IsDBNull(dt1.Rows(i).Item("Quantity")) Then
                        cell4.Text = " "
                    Else
                        cell4.Text = FormatNumber(CStr((dt1.Rows(i).Item("Quantity"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt1.Rows(i).Item("Rate")) Then
                        cell5.Text = " "
                    Else
                        cell5.Text = FormatNumber(CStr((dt1.Rows(i).Item("Rate"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt1.Rows(i).Item("Amount")) Then
                        cell6.Text = " "
                    Else
                        cell6.Text = FormatNumber(CStr((dt1.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)

                    End If
                    

                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)
                    tr.Cells.Add(cell6)
                    tr.Cells.Add(cell7)


                    report.xrMainTable.Rows.Add(tr)


                    If (dt1.Rows(i).Item("Description")).ToString.ToUpper = "TEA" And Convert.ToDecimal((dt1.Rows(i).Item("Deduction"))) > 0 Then

                        'If (dt1.Rows(i).Item("Description")).ToString = "Tea" And Val(dt1.Rows(i).Item("Deduction")) > 0 Then

                        '**********************************************************************************************
                        Dim tra As New DevExpress.XtraReports.UI.XRTableRow
                        Dim cell1a, cell2a, cell3a, cell4a, cell5a, cell6a, cell7a As New DevExpress.XtraReports.UI.XRTableCell



                        cell1a.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                        cell2a.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                        cell3a.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                        cell4a.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                        cell5a.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                        cell6a.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                        cell7a.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

                        cell1a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        cell2a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        cell3a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        cell4a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        cell5a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        cell6a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        cell7a.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                        cell1a.Text = "cell1a "
                        cell2a.Text = "cell2a "
                        cell3a.Text = "cell3a "
                        cell4a.Text = "cell4a "
                        cell5a.Text = "Deduction "
                        'cell6a.Text = "cell6a "
                        'cell7a.Text = "cell7a "

                        If IsDBNull(dt1.Rows(i).Item("Deduction")) Then
                            cell6a.Text = " "
                        Else
                            cell6a.Text = FormatNumber(CStr((dt1.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                        End If
                        cell7a.Text = " "

                        tra.Cells.Add(cell1a)
                        tra.Cells.Add(cell2a)
                        tra.Cells.Add(cell3a)
                        tra.Cells.Add(cell4a)
                        tra.Cells.Add(cell5a)
                        tra.Cells.Add(cell6a)
                        tra.Cells.Add(cell7a)


                        report.xrMainTable.Rows.Add(tra)

                    End If
                    '**********************************************************************************************


                Next
            End If




            ''******************************* Casual 1-15 Salary **************************************************************************

            'If dt2.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt2.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell



            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            '        cell1.Text = ""
            '        cell2.Text = "Casual 1 - 15"

            '        If IsDBNull(dt2.Rows(i).Item("CasualTotalto15")) Then
            '            cell3.Text = "0.00 "
            '        Else
            '            cell3.Text = FormatNumber(CStr((dt2.Rows(i).Item("CasualTotalto15"))), 2, TriState.True) & " "
            '            CasualSalaryTotal = Convert.ToDecimal(dt2.Rows(i).Item("CasualTotalto15").ToString())
            '        End If


            '        cell4.Text = String.Empty
            '        cell5.Text = String.Empty
            '        cell6.Text = String.Empty

            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If


            ''******************************* Casual 1-EOM Total **************************************************************************

            'If dt3.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt3.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell


            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft

            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            '        cell1.Text = ""
            '        cell2.Text = "Casual 15 - EOM"

            '        If IsDBNull(dt3.Rows(i).Item("CasualTotal5toEOM")) Then
            '            cell3.Text = "0.00 "
            '        Else
            '            cell3.Text = FormatNumber(CStr((dt3.Rows(i).Item("CasualTotal5toEOM"))), 2, TriState.True) & " "
            '            CasualSalaryTotal = CasualSalaryTotal + Convert.ToDecimal((dt3.Rows(i).Item("CasualTotal5toEOM").ToString))
            '        End If

            '        cell4.Text = FormatNumber(CasualSalaryTotal.ToString(), 2, TriState.True) & " "

            '        cell5.Text = String.Empty

            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If





            ''******************************* Staff Salary [KP] **************************************************************************

            'If dt4.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt4.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell


            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            '        cell1.Text = ""
            '        cell2.Text = "KP's Balance Salary"
            '        cell3.Text = String.Empty
            '        If IsDBNull(dt4.Rows(i).Item("KPB")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = FormatNumber(CStr((dt4.Rows(i).Item("KPB"))), 2, TriState.True) & " "
            '            StaffSalaryTotal = Convert.ToDecimal(dt4.Rows(i).Item("KPB").ToString())


            '        End If

            '        TotalSalary = PermanentSalaryTotal + CasualSalaryTotal + StaffSalaryTotal
            '        cell5.Text = FormatNumber(TotalSalary.ToString(), 2, TriState.True) & " "
            '        cell6.Text = String.Empty

            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If




            ''---------------------------Empty Row as Separator  - START ----------------------------------------------------------------

            'Dim trEmpty As New DevExpress.XtraReports.UI.XRTableRow
            'Dim cellEmpty1, cellEmpty2, cellEmpty3, cellEmpty4, cellEmpty5, cellEmpty6 As New DevExpress.XtraReports.UI.XRTableCell
            'cellEmpty1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            'cellEmpty2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            'cellEmpty3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            'cellEmpty4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            'cellEmpty5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            'cellEmpty6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            'cellEmpty1.Borders = DevExpress.XtraPrinting.BorderSide.Top
            'cellEmpty1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            'cellEmpty1.Borders = DevExpress.XtraPrinting.BorderSide.Left

            'cellEmpty2.Borders = DevExpress.XtraPrinting.BorderSide.Top
            'cellEmpty2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            'cellEmpty3.Borders = DevExpress.XtraPrinting.BorderSide.Top
            'cellEmpty3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            'cellEmpty4.Borders = DevExpress.XtraPrinting.BorderSide.Top
            'cellEmpty4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            'cellEmpty5.Borders = DevExpress.XtraPrinting.BorderSide.Top
            'cellEmpty5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            'cellEmpty6.Borders = DevExpress.XtraPrinting.BorderSide.All


            'cellEmpty1.Text = String.Empty
            'cellEmpty2.Text = String.Empty
            'cellEmpty3.Text = String.Empty
            'cellEmpty4.Text = String.Empty
            'cellEmpty5.Text = String.Empty
            'cellEmpty6.Text = "JJJ"

            'trEmpty.Cells.Add(cellEmpty1)
            'trEmpty.Cells.Add(cellEmpty2)
            'trEmpty.Cells.Add(cellEmpty3)
            'trEmpty.Cells.Add(cellEmpty4)
            'trEmpty.Cells.Add(cellEmpty5)
            'trEmpty.Cells.Add(cellEmpty6)
            'report.xrMainTable.Rows.Add(trEmpty)

            ''---------------------------Empty Row as Separator  - END ----------------------------------------------------------------



            'If dt5.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt5.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


            '        If i = 0 Then
            '            cell1.Text = "Cash Advance-Permanent"
            '        End If

            '        If IsDBNull(dt5.Rows(i).Item("EmployeeName")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt5.Rows(i).Item("EmployeeName")))
            '        End If

            '        If IsDBNull(dt5.Rows(i).Item("CashAdvance")) Then
            '            cell3.Text = "0.00 "
            '        Else
            '            cell3.Text = FormatNumber(CStr((dt5.Rows(i).Item("CashAdvance"))), 2, TriState.True) & " "
            '            PermanentAdvPay = PermanentAdvPay + Convert.ToDecimal((dt5.Rows(i).Item("CashAdvance").ToString))
            '        End If

            '        If i = dt5.Rows.Count - 1 Then
            '            cell4.Text = FormatNumber(PermanentAdvPay.ToString(), 2, TriState.True) & " "
            '            cell5.Text = String.Empty

            '        Else
            '            cell4.Text = String.Empty
            '            cell5.Text = String.Empty


            '        End If
            '        cell6.Text = String.Empty


            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If




            'If dt6.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt6.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



            '        If i = 0 Then
            '            cell1.Text = "Cash Advance-Permanent"
            '        End If

            '        If IsDBNull(dt6.Rows(i).Item("EmployeeName")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt6.Rows(i).Item("EmployeeName")))
            '        End If

            '        If IsDBNull(dt6.Rows(i).Item("CashAdvance")) Then
            '            cell3.Text = "0.00 "
            '        Else
            '            cell3.Text = FormatNumber(CStr((dt6.Rows(i).Item("CashAdvance"))), 2, TriState.True) & " "
            '            CasualAdvPay = CasualAdvPay + Convert.ToDecimal((dt6.Rows(i).Item("CashAdvance").ToString))
            '        End If

            '        If i = dt6.Rows.Count - 1 Then
            '            cell4.Text = FormatNumber(CasualAdvPay.ToString(), 2, TriState.True) & " "
            '            cell5.Text = String.Empty

            '        Else
            '            cell4.Text = String.Empty
            '            cell5.Text = String.Empty

            '        End If
            '        cell6.Text = String.Empty


            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If



            'If dt11.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt11.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


            '        If i = 0 Then
            '            cell1.Text = "Cash Advance - Staff"
            '        End If

            '        If IsDBNull(dt11.Rows(i).Item("EmployeeName")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt11.Rows(i).Item("EmployeeName")))
            '        End If

            '        cell3.Text = String.Empty


            '        If IsDBNull(dt11.Rows(i).Item("StaffAdvance")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = FormatNumber(CStr((dt11.Rows(i).Item("StaffAdvance"))), 2, TriState.True) & " "
            '            StaffAdvPay = StaffAdvPay + Convert.ToDecimal((dt11.Rows(i).Item("StaffAdvance").ToString))
            '        End If

            '        TotalAdvPay = PermanentAdvPay + CasualAdvPay + StaffAdvPay

            '        If i = dt11.Rows.Count - 1 Then

            '            cell5.Text = FormatNumber(TotalAdvPay.ToString(), 2, TriState.True) & " "

            '        Else
            '            cell5.Text = String.Empty

            '        End If

            '        cell6.Text = String.Empty


            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If




            ''Dim FPT As Decimal = 0

            'If dt7.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt7.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


            '        If i = 0 Then
            '            cell1.Text = "Festival Advance"
            '        End If

            '        If IsDBNull(dt7.Rows(i).Item("Designation")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt7.Rows(i).Item("Designation")))
            '        End If

            '        cell3.Text = String.Empty


            '        If IsDBNull(dt7.Rows(i).Item("FestivalAdvance")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = CStr((dt7.Rows(i).Item("FestivalAdvance")))
            '            FestivalAdvanceTotal = FestivalAdvanceTotal + Convert.ToDecimal((dt7.Rows(i).Item("FestivalAdvance").ToString))
            '        End If

            '        If i = dt7.Rows.Count - 1 Then


            '            cell5.Text = FormatNumber(FestivalAdvanceTotal, 2, TriState.True)

            '        Else
            '            cell5.Text = String.Empty

            '        End If
            '        cell6.Text = String.Empty

            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If


            ''---------------------------Empty Row as Separator  - START ----------------------------------------------------------------
            'Dim trEmpty2 As New DevExpress.XtraReports.UI.XRTableRow
            'Dim cellEmpty12 As New DevExpress.XtraReports.UI.XRTableCell
            'cellEmpty12.Size = New Size(report.xrMainTable.WidthF, 25)
            'cellEmpty12.Text = " "
            'trEmpty2.Cells.Add(cellEmpty12)
            'report.xrMainTable.Rows.Add(trEmpty2)


            ''---------------------------Empty Row as Separator  - END ----------------------------------------------------------------



            'If dt8.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt8.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



            '        If i = 0 Then
            '            cell1.Text = "ETF 12%"
            '        End If

            '        If IsDBNull(dt8.Rows(i).Item("EmployeeName")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt8.Rows(i).Item("EmployeeName")))
            '        End If

            '        cell3.Text = String.Empty

            '        If IsDBNull(dt8.Rows(i).Item("EPF_12")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = FormatNumber(CStr((dt8.Rows(i).Item("EPF_12"))), 2, TriState.True) & " "
            '            EPFTotal = EPFTotal + Convert.ToDecimal((dt8.Rows(i).Item("EPF_12").ToString))
            '        End If

            '        If i = dt8.Rows.Count - 1 Then
            '            cell5.Text = FormatNumber(EPFTotal.ToString(), 2, TriState.True) & " "

            '        Else
            '            cell5.Text = String.Empty

            '        End If
            '        cell6.Text = String.Empty



            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)
            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If

            ''---------------------------Empty Row as Separator  - START ----------------------------------------------------------------
            'Dim trEmpty3 As New DevExpress.XtraReports.UI.XRTableRow
            'Dim cellEmpty13 As New DevExpress.XtraReports.UI.XRTableCell
            'cellEmpty13.Size = New Size(report.xrMainTable.WidthF, 10)
            'cellEmpty13.Text = " "
            'trEmpty3.Cells.Add(cellEmpty13)
            'report.xrMainTable.Rows.Add(trEmpty3)


            ''---------------------------Empty Row as Separator  - END ----------------------------------------------------------------



            'If dt9.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt9.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



            '        If i = 0 Then
            '            cell1.Text = "ETF 3%"
            '        End If

            '        If IsDBNull(dt9.Rows(i).Item("EmployeeName")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt9.Rows(i).Item("EmployeeName")))
            '        End If

            '        cell3.Text = String.Empty

            '        If IsDBNull(dt9.Rows(i).Item("ETF_3")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = FormatNumber(CStr((dt9.Rows(i).Item("ETF_3"))), 2, TriState.True) & " "
            '            ETFTotal = ETFTotal + Convert.ToDecimal((dt9.Rows(i).Item("ETF_3").ToString))
            '        End If

            '        If i = dt9.Rows.Count - 1 Then
            '            cell5.Text = FormatNumber(ETFTotal.ToString(), 2, TriState.True) & " "


            '        Else
            '            cell5.Text = String.Empty

            '        End If
            '        cell6.Text = String.Empty



            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)

            '    report.xrMainTable.Rows.Add(tr)

            '        Next
            'End If

            ''---------------------------Empty Row as Separator  - START ----------------------------------------------------------------
            'Dim trEmpty4 As New DevExpress.XtraReports.UI.XRTableRow
            'Dim cellEmpty14 As New DevExpress.XtraReports.UI.XRTableCell
            'cellEmpty14.Size = New Size(report.xrMainTable.WidthF, 10)
            'cellEmpty14.Text = " "
            'trEmpty4.Cells.Add(cellEmpty14)
            'report.xrMainTable.Rows.Add(trEmpty4)


            ''---------------------------Empty Row as Separator  - END ----------------------------------------------------------------



            'If dt10.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt10.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            '        cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            '        If i = 0 Then
            '            cell1.Text = "OTHER"
            '        End If

            '        If IsDBNull(dt10.Rows(i).Item("Description")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt10.Rows(i).Item("Description")))
            '        End If

            '        cell3.Text = String.Empty

            '        If IsDBNull(dt10.Rows(i).Item("Amount")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = FormatNumber(CStr((dt10.Rows(i).Item("Amount"))), 2, TriState.True) & " "
            '            OtherExpenseTotal = OtherExpenseTotal + Convert.ToDecimal((dt10.Rows(i).Item("Amount").ToString))
            '        End If

            '        If i = dt10.Rows.Count - 1 Then
            '            cell5.Text = FormatNumber(OtherExpenseTotal.ToString(), 2, TriState.True) & " "


            '        Else
            '            cell5.Text = String.Empty

            '        End If

            '        cell6.Text = String.Empty

            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)
            '        tr.Cells.Add(cell6)


            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If





            'Dim trT As New DevExpress.XtraReports.UI.XRTableRow

            'Dim Tcell1, Tcell2, Tcell3, Tcell4, Tcell5, Tcell6 As New DevExpress.XtraReports.UI.XRTableCell

            'Tcell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            'Tcell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            'Tcell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            'Tcell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            'Tcell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            'Tcell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            'Tcell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            'Tcell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            'Tcell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            'Tcell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            'Tcell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            'Tcell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            'Tcell1.Text = "GRAND TOTAL"
            'Tcell2.Text = String.Empty
            'Tcell3.Text = String.Empty
            'Tcell4.Text = String.Empty
            'Tcell5.Text = String.Empty
            'Tcell6.Text = FormatNumber((TotalSalary + TotalAdvPay + FestivalAdvanceTotal + OtherExpenseTotal + EPFTotal + ETFTotal), 2, TriState.True)




            'trT.Cells.Add(Tcell1)
            'trT.Cells.Add(Tcell2)
            'trT.Cells.Add(Tcell3)
            'trT.Cells.Add(Tcell4)
            'trT.Cells.Add(Tcell5)

            'report.xrMainTable.Rows.Add(trT)


            'If dt12.Rows.Count > 0 Then
            '    Dim i As Int64
            '    For i = 0 To dt12.Rows.Count - 1

            '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow

            '        Dim cell1, cell2, cell3, cell4, cell5 As New DevExpress.XtraReports.UI.XRTableCell

            '        cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            '        cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            '        cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            '        cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            '        cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)


            '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            '        cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

            '        If i = 0 Then
            '            cell1.Text = "EXPENSES OF INVESTMENTS"
            '        End If

            '        If IsDBNull(dt12.Rows(i).Item("Description")) Then
            '            cell2.Text = "0.00 "
            '        Else
            '            cell2.Text = CStr((dt12.Rows(i).Item("Description")))
            '        End If

            '        cell3.Text = String.Empty

            '        If IsDBNull(dt12.Rows(i).Item("Amount")) Then
            '            cell4.Text = "0.00 "
            '        Else
            '            cell4.Text = ""

            '        End If

            '        If i = dt12.Rows.Count - 1 Then
            '            cell5.Text = FormatNumber(CStr((dt12.Rows(i).Item("Amount"))), 2, TriState.True) & " "


            '        Else
            '            cell5.Text = String.Empty

            '        End If

            '        'Adding values to Total Column



            '        tr.Cells.Add(cell1)
            '        tr.Cells.Add(cell2)
            '        tr.Cells.Add(cell3)
            '        tr.Cells.Add(cell4)
            '        tr.Cells.Add(cell5)

            '        report.xrMainTable.Rows.Add(tr)

            '    Next
            'End If



            report.CreateDocument()
            report.BringToFront()
            frmPrint.MdiParent = frmMain
            frmPrint.Show()
            frmPrint.BringToFront()

        End If

    End Sub
End Class