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
            Dim dt2 As DataTable 'Rubber
            Dim dt3 As DataTable 'Other
            Dim dt4 As DataTable 'SDP



            dt1 = ds.Tables(0)
            dt2 = ds.Tables(1)
            dt3 = ds.Tables(2)
            dt4 = ds.Tables(3)
          


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

                    End If



                    If IsDBNull(dt1.Rows(i).Item("Note")) Then
                        cell3.Text = " "
                    Else
                        cell3.Text = (dt1.Rows(i).Item("Note").ToString)
                        
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

                    cell7.Text = " Done end"

                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)
                    tr.Cells.Add(cell6)
                    tr.Cells.Add(cell7)


                    report.xrMainTable.Rows.Add(tr)


                    'If (dt1.Rows(i).Item("Description")).ToString.ToUpper = "TEA" And Convert.ToDecimal((dt1.Rows(i).Item("Deduction"))) > 0 Then

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


                    cell1a.Text = "  "
                    cell2a.Text = "  "
                    cell3a.Text = "  "
                    cell4a.Text = "  "
                    cell5a.Text = "Deduction "

                    If IsDBNull(dt1.Rows(i).Item("Deduction")) Then
                        cell6a.Text = " "
                    Else
                        cell6a.Text = FormatNumber(CStr((dt1.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                    End If

                    Dim a, b As Decimal

                    a = Convert.ToDecimal(dt1.Rows(i).Item("Amount"))
                    b = Convert.ToDecimal(dt1.Rows(i).Item("Deduction"))

                    cell7a.Text = FormatNumber(CStr(a - b) & Space(1), 2, TriState.True)

                    tra.Cells.Add(cell1a)
                    tra.Cells.Add(cell2a)
                    tra.Cells.Add(cell3a)
                    tra.Cells.Add(cell4a)
                    tra.Cells.Add(cell5a)
                    tra.Cells.Add(cell6a)
                    tra.Cells.Add(cell7a)


                    report.xrMainTable.Rows.Add(tra)

                    '**********************************************************************************************


                Next
            End If


            '---------------------------Empty Row as Separator  - START ----------------------------------------------------------------

            Dim trTE As New DevExpress.XtraReports.UI.XRTableRow
            Dim cellTC1, cellTC2, cellTC3, cellTC4, cellTC5, cellTC6, cellTC7 As New DevExpress.XtraReports.UI.XRTableCell

            cellTC1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            cellTC2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            cellTC3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            cellTC4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            cellTC5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            cellTC6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

            cellTC1.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            cellTC1.Borders = DevExpress.XtraPrinting.BorderSide.Left

            cellTC2.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellTC3.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellTC4.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellTC5.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellTC6.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellTC6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellTC7.Borders = DevExpress.XtraPrinting.BorderSide.All


            cellTC1.Text = String.Empty
            cellTC2.Text = String.Empty
            cellTC3.Text = String.Empty
            cellTC4.Text = String.Empty
            cellTC5.Text = String.Empty
            cellTC6.Text = String.Empty
            celltc7.Text = String.Empty


            trTE.Cells.Add(cellTC1)
            trTE.Cells.Add(cellTC2)
            trTE.Cells.Add(cellTC3)
            trTE.Cells.Add(cellTC4)
            trTE.Cells.Add(cellTC5)
            trTE.Cells.Add(cellTC6)
            trTE.Cells.Add(cellTC7)
            report.xrMainTable.Rows.Add(trTE)

            '---------------------------Empty Row as Separator  - END ----------------------------------------------------------------

            '***************************************************************************************************************************************************

            If dt2.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt2.Rows.Count - 1

                    Dim trRB As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1R, cell2R, cell3R, cell4R, cell5R, cell6R, cell7R As New DevExpress.XtraReports.UI.XRTableCell



                    cell1R.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2R.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3R.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4R.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5R.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6R.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7R.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    cell1R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7R.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1R.Text = "RUBBER"

                    If IsDBNull(dt2.Rows(i).Item("OtherIncomeDate")) Then
                        cell2R.Text = "  "
                    Else
                        Dim tempDate As Date
                        If DateTime.TryParse(CStr(dt2.Rows(i).Item("OtherIncomeDate").ToString), tempDate) Then
                            cell2R.Text = tempDate.ToShortDateString
                        Else
                            cell2R.Text = "  "
                        End If

                     
                    End If



                    If IsDBNull(dt2.Rows(i).Item("Note")) Then
                        cell3R.Text = " "
                    Else
                        cell3R.Text = (dt2.Rows(i).Item("Note").ToString)
                        'FormatNumber(CStr((dt2.Rows(i).Item("Note"))) & Space(1), 2, TriState.True)

                    End If


                    If IsDBNull(dt2.Rows(i).Item("Quantity")) Then
                        cell4R.Text = " "
                    Else
                        cell4R.Text = FormatNumber(CStr((dt2.Rows(i).Item("Quantity"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt2.Rows(i).Item("Rate")) Then
                        cell5R.Text = " "
                    Else
                        cell5R.Text = FormatNumber(CStr((dt2.Rows(i).Item("Rate"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt2.Rows(i).Item("Amount")) Then
                        cell6R.Text = " "
                    Else
                        cell6R.Text = FormatNumber(CStr((dt2.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)

                    End If


                    cell7R.Text = " mash"

                    trRB.Cells.Add(cell1R)
                    trRB.Cells.Add(cell2R)
                    trRB.Cells.Add(cell3R)
                    trRB.Cells.Add(cell4R)
                    trRB.Cells.Add(cell5R)
                    trRB.Cells.Add(cell6R)
                    trRB.Cells.Add(cell7R)


                    report.xrMainTable.Rows.Add(trRB)


                    
                    
                        '**********************************************************************************************
                    Dim trSa As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1aS, cell2aR, cell3aR, cell4aR, cell5aR, cell6aR, cell7aR As New DevExpress.XtraReports.UI.XRTableCell



                    cell1aS.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2aR.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3aR.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4aR.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5aR.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6aR.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7aR.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    cell1aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1aS.Text = "  "
                    cell2aR.Text = "  "
                    cell3aR.Text = "  "
                    cell4aR.Text = "  "
                    cell5aR.Text = "Deduction "
                    'cell6aR.Text = "cell6aR "
                    'cell7aR.Text = "cell7aR "

                    If IsDBNull(dt2.Rows(i).Item("Deduction")) Then
                        cell6aR.Text = " "
                    Else
                        cell6aR.Text = FormatNumber(CStr((dt2.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                    End If

                    Dim a, b As Decimal

                    a = Convert.ToDecimal(dt2.Rows(i).Item("Amount"))
                    b = Convert.ToDecimal(dt2.Rows(i).Item("Deduction"))

                    cell7aR.Text = FormatNumber(CStr(a - b) & Space(1), 2, TriState.True)

                    trSa.Cells.Add(cell1aS)
                    trSa.Cells.Add(cell2aR)
                    trSa.Cells.Add(cell3aR)
                    trSa.Cells.Add(cell4aR)
                    trSa.Cells.Add(cell5aR)
                    trSa.Cells.Add(cell6aR)
                    trSa.Cells.Add(cell7aR)


                    report.xrMainTable.Rows.Add(trSa)

                    '**********************************************************************************************


                Next
            End If


            '---------------------------Empty Row as Separator  - START ----------------------------------------------------------------

            Dim trRE As New DevExpress.XtraReports.UI.XRTableRow
            Dim cellRB1, cellRB2, cellRB3, cellRB4, cellRB5, cellRB6, cellRB7 As New DevExpress.XtraReports.UI.XRTableCell

            cellRB1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            cellRB2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            cellRB3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            cellRB4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            cellRB5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            cellRB6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
            cellRB7.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

            cellRB1.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            cellRB1.Borders = DevExpress.XtraPrinting.BorderSide.Left

            cellRB2.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRB3.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRB4.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRB5.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRB6.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRB6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRB7.Borders = DevExpress.XtraPrinting.BorderSide.All


            cellRB1.Text = String.Empty
            cellRB2.Text = String.Empty
            cellRB3.Text = String.Empty
            cellRB4.Text = String.Empty
            cellRB5.Text = String.Empty
            cellRB6.Text = String.Empty
            cellRB7.Text = String.Empty


            trRE.Cells.Add(cellRB1)
            trRE.Cells.Add(cellRB2)
            trRE.Cells.Add(cellRB3)
            trRE.Cells.Add(cellRB4)
            trRE.Cells.Add(cellRB5)
            trRE.Cells.Add(cellRB6)
            trRE.Cells.Add(cellRB7)

            report.xrMainTable.Rows.Add(trRE)



            '***************************************************************************************************************************************************


            '***************************************************************************************************************************************************

            If dt3.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt3.Rows.Count - 1

                    Dim trRB As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1O, cell2O, cell3O, cell4O, cell5O, cell6O, cell7O As New DevExpress.XtraReports.UI.XRTableCell



                    cell1O.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2O.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3O.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4O.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5O.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6O.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7O.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    cell1O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7O.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1O.Text = "OTHER"

                    If IsDBNull(dt3.Rows(i).Item("OtherIncomeDate")) Then
                        cell2O.Text = "  "
                    Else
                        Dim tempDate As Date
                        If DateTime.TryParse(CStr(dt3.Rows(i).Item("OtherIncomeDate").ToString), tempDate) Then
                            cell2O.Text = tempDate.ToShortDateString
                        Else
                            cell2O.Text = "  "
                        End If


                    End If



                    If IsDBNull(dt3.Rows(i).Item("Note")) Then
                        cell3O.Text = " "
                    Else
                        cell3O.Text = (dt3.Rows(i).Item("Note").ToString)
                        'FormatNumber(CStr((dt3.Rows(i).Item("Note"))) & Space(1), 2, TriState.True)

                    End If


                    If IsDBNull(dt3.Rows(i).Item("Quantity")) Then
                        cell4O.Text = " "
                    Else
                        cell4O.Text = FormatNumber(CStr((dt3.Rows(i).Item("Quantity"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt3.Rows(i).Item("Rate")) Then
                        cell5O.Text = " "
                    Else
                        cell5O.Text = FormatNumber(CStr((dt3.Rows(i).Item("Rate"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt3.Rows(i).Item("Amount")) Then
                        cell6O.Text = " "
                    Else
                        cell6O.Text = FormatNumber(CStr((dt3.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)

                    End If


                    trRB.Cells.Add(cell1O)
                    trRB.Cells.Add(cell2O)
                    trRB.Cells.Add(cell3O)
                    trRB.Cells.Add(cell4O)
                    trRB.Cells.Add(cell5O)
                    trRB.Cells.Add(cell6O)
                    trRB.Cells.Add(cell7O)


                    report.xrMainTable.Rows.Add(trRB)




                    '**********************************************************************************************
                    Dim trSa As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1aS, cell2aR, cell3aR, cell4aR, cell5aR, cell6aR, cell7aR As New DevExpress.XtraReports.UI.XRTableCell



                    cell1aS.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2aR.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3aR.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4aR.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5aR.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6aR.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7aR.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    cell1aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7aR.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1aS.Text = "  "
                    cell2aR.Text = "  "
                    cell3aR.Text = "  "
                    cell4aR.Text = "  "
                    cell5aR.Text = "Deduction "
                    'cell6aR.Text = "cell6aR "
                    'cell7aR.Text = "cell7aR "

                    If IsDBNull(dt3.Rows(i).Item("Deduction")) Then
                        cell6aR.Text = " "
                    Else
                        cell6aR.Text = FormatNumber(CStr((dt3.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                    End If

                    Dim a, b As Decimal

                    a = Convert.ToDecimal(dt3.Rows(i).Item("Amount"))
                    b = Convert.ToDecimal(dt3.Rows(i).Item("Deduction"))

                    cell7aR.Text = FormatNumber(CStr(a - b) & Space(1), 2, TriState.True)

                    trSa.Cells.Add(cell1aS)
                    trSa.Cells.Add(cell2aR)
                    trSa.Cells.Add(cell3aR)
                    trSa.Cells.Add(cell4aR)
                    trSa.Cells.Add(cell5aR)
                    trSa.Cells.Add(cell6aR)
                    trSa.Cells.Add(cell7aR)


                    report.xrMainTable.Rows.Add(trSa)

                    '**********************************************************************************************


                Next
            End If


            '---------------------------Empty Row as Separator  - START ----------------------------------------------------------------

            Dim trOE As New DevExpress.XtraReports.UI.XRTableRow
            Dim cellRO1, cellRO2, cellRO3, cellRO4, cellRO5, cellRO6, cellRO7 As New DevExpress.XtraReports.UI.XRTableCell

            cellRO1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
            cellRO2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
            cellRO3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
            cellRO4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
            cellRO5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
            cellRO6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
            cellRO7.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

            cellRO1.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            cellRO1.Borders = DevExpress.XtraPrinting.BorderSide.Left

            cellRO2.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRO3.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRO4.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRO5.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO5.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRO6.Borders = DevExpress.XtraPrinting.BorderSide.Top
            cellRO6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

            cellRO7.Borders = DevExpress.XtraPrinting.BorderSide.All


            cellRO1.Text = String.Empty
            cellRO2.Text = String.Empty
            cellRO3.Text = String.Empty
            cellRO4.Text = String.Empty
            cellRO5.Text = String.Empty
            cellRO6.Text = String.Empty
            cellRO7.Text = String.Empty


            trOE.Cells.Add(cellRO1)
            trOE.Cells.Add(cellRO2)
            trOE.Cells.Add(cellRO3)
            trOE.Cells.Add(cellRO4)
            trOE.Cells.Add(cellRO5)
            trOE.Cells.Add(cellRO6)
            trOE.Cells.Add(cellRO7)

            report.xrMainTable.Rows.Add(trOE)



            '***************************************************************************************************************************************************

            '***************************************************************************************************************************************************

            If dt4.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt4.Rows.Count - 1

                    Dim trRB As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1S, cell2S, cell3S, cell4S, cell5S, cell6S, cell7S As New DevExpress.XtraReports.UI.XRTableCell

                    Dim tot As Decimal


                    cell1S.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2S.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3S.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    cell4S.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5S.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6S.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7S.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    cell1S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell3S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7S.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1S.Text = "other"

                    If IsDBNull(dt4.Rows(i).Item("OtherIncomeDate")) Then
                        cell2S.Text = "  "
                    Else
                        Dim tempDate As Date
                        If DateTime.TryParse(CStr(dt4.Rows(i).Item("OtherIncomeDate").ToString), tempDate) Then
                            cell2S.Text = tempDate.ToShortDateString
                        Else
                            cell2S.Text = "  "
                        End If


                    End If



                    If IsDBNull(dt4.Rows(i).Item("Note")) Then
                        cell3S.Text = " "
                    Else
                        cell3S.Text = (dt4.Rows(i).Item("Note").ToString)
                        'FormatNumber(CStr((dt4.Rows(i).Item("Note"))) & Space(1), 2, TriState.True)

                    End If


                    If IsDBNull(dt4.Rows(i).Item("Quantity")) Then
                        cell4S.Text = " "
                    Else
                        cell4S.Text = FormatNumber(CStr((dt4.Rows(i).Item("Quantity"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt4.Rows(i).Item("Rate")) Then
                        cell5S.Text = " "
                    Else
                        cell5S.Text = FormatNumber(CStr((dt4.Rows(i).Item("Rate"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt4.Rows(i).Item("Amount")) Then
                        cell6S.Text = " "
                    Else
                        cell6S.Text = FormatNumber(CStr((dt4.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)
                        tot = tot + Convert.ToDecimal(dt4.Rows(i).Item("Amount"))
                    End If


                    trRB.Cells.Add(cell1S)
                    trRB.Cells.Add(cell2S)
                    trRB.Cells.Add(cell3S)
                    trRB.Cells.Add(cell4S)
                    trRB.Cells.Add(cell5S)
                    trRB.Cells.Add(cell6S)
                    trRB.Cells.Add(cell7S)


                    report.xrMainTable.Rows.Add(trRB)




                    ''**********************************************************************************************
                    'Dim trSa As New DevExpress.XtraReports.UI.XRTableRow
                    'Dim cell1aS, cell2aS, cell3aS, cell4aS, cell5aS, cell6aS, cell7aS As New DevExpress.XtraReports.UI.XRTableCell



                    'cell1aS.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    'cell2aS.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    'cell3aS.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF, 25)
                    'cell4aS.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    'cell5aS.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    'cell6aS.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    'cell7aS.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)

                    'cell1aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    'cell2aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    'cell3aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    'cell4aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    'cell5aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    'cell6aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    'cell7aS.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    'cell1aS.Text = "  "
                    'cell2aS.Text = "  "
                    'cell3aS.Text = "  "
                    'cell4aS.Text = "  "
                    'cell5aS.Text = "Deduction "
                    ''cell6aS.Text = "cell6aS "
                    ''cell7aS.Text = "cell7aS "

                    'If IsDBNull(dt4.Rows(i).Item("Deduction")) Then
                    '    cell6aS.Text = " "
                    'Else
                    '    cell6aS.Text = FormatNumber(CStr((dt4.Rows(i).Item("Deduction"))) & Space(1), 2, TriState.True)

                    'End If

                    'Dim a, b As Decimal

                    'a = Convert.ToDecimal(dt4.Rows(i).Item("Amount"))
                    'b = Convert.ToDecimal(dt4.Rows(i).Item("Deduction"))

                    'cell7aS.Text = FormatNumber(CStr(a - b) & Space(1), 2, TriState.True)

                    'trSa.Cells.Add(cell1aS)
                    'trSa.Cells.Add(cell2aS)
                    'trSa.Cells.Add(cell3aS)
                    'trSa.Cells.Add(cell4aS)
                    'trSa.Cells.Add(cell5aS)
                    'trSa.Cells.Add(cell6aS)
                    'trSa.Cells.Add(cell7aS)


                    'report.xrMainTable.Rows.Add(trSa)

                    ''**********************************************************************************************

                    cell7S.Text = tot

                Next

                
            End If




            report.CreateDocument()
            report.BringToFront()
            frmPrint.MdiParent = frmMain
            frmPrint.Show()
            frmPrint.BringToFront()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


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
            Dim dt2 As DataTable 'Rubber
            Dim dt3 As DataTable 'Other
            Dim dt4 As DataTable 'SDP



            dt1 = ds.Tables(0)
            dt2 = ds.Tables(1)
            dt3 = ds.Tables(2)
            dt4 = ds.Tables(3)



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

                    End If



                    If IsDBNull(dt1.Rows(i).Item("Note")) Then
                        cell3.Text = " "
                    Else
                        cell3.Text = (dt1.Rows(i).Item("Note").ToString)

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

                Next

            End If



            report.CreateDocument()
            report.BringToFront()
            frmPrint.MdiParent = frmMain
            frmPrint.Show()
            frmPrint.BringToFront()

        End If


    End Sub
End Class