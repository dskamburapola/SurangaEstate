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
            Dim grandatotal As Decimal

            Dim dt1 As DataTable 'Tea

            dt1 = ds.Tables(0)

            If dt1.Rows.Count > 0 Then
                Dim i As Int64
                For i = 0 To dt1.Rows.Count - 1

                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1, cell2, cell3, cell4, cell5, cell6, cell7 As New DevExpress.XtraReports.UI.XRTableCell

                    cell1.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF + 2, 25)
                    cell4.Size = New Size(report.xrMainTable.Rows(0).Cells(3).WidthF, 25)
                    cell5.Size = New Size(report.xrMainTable.Rows(0).Cells(4).WidthF, 25)
                    cell6.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)
                    cell7.Size = New Size(report.xrMainTable.Rows(0).Cells(5).WidthF, 25)

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                    cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                    cell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight

                    cell1.Text = dt1.Rows(i).Item("Description")

                    If IsDBNull(dt1.Rows(i).Item("OtherIncomeDate")) Then
                        cell2.Text = ""
                    Else
                        Dim tempDate As Date
                        If DateTime.TryParse(CStr(dt1.Rows(i).Item("OtherIncomeDate").ToString), tempDate) Then
                            cell2.Text = tempDate.ToString("dd-MMM-yy")
                        Else
                            cell2.Text = ""
                        End If

                    End If



                    If IsDBNull(dt1.Rows(i).Item("Note")) Then
                        cell3.Text = ""
                    Else
                        cell3.Text = (dt1.Rows(i).Item("Note").ToString)
                        
                    End If


                    If IsDBNull(dt1.Rows(i).Item("Quantity")) Then
                        cell4.Text = ""
                    Else
                        cell4.Text = FormatNumber(CStr((dt1.Rows(i).Item("Quantity"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt1.Rows(i).Item("Rate")) Then
                        cell5.Text = ""
                    Else
                        cell5.Text = FormatNumber(CStr((dt1.Rows(i).Item("Rate"))) & Space(1), 2, TriState.True)

                    End If

                    If IsDBNull(dt1.Rows(i).Item("Amount")) Then
                        cell6.Text = ""
                    Else
                        cell6.Text = FormatNumber(CStr((dt1.Rows(i).Item("Amount"))) & Space(1), 2, TriState.True)

                    End If

                    cell7.Text = ""

                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)
                    tr.Cells.Add(cell3)
                    tr.Cells.Add(cell4)
                    tr.Cells.Add(cell5)
                    tr.Cells.Add(cell6)
                    tr.Cells.Add(cell7)

                    report.xrMainTable.Rows.Add(tr)

                    Dim tra As New DevExpress.XtraReports.UI.XRTableRow
                    Dim cell1a, cell2a, cell3a, cell4a, cell5a, cell6a, cell7a As New DevExpress.XtraReports.UI.XRTableCell

                    cell1a.Size = New Size(report.xrMainTable.Rows(0).Cells(0).WidthF, 25)
                    cell2a.Size = New Size(report.xrMainTable.Rows(0).Cells(1).WidthF, 25)
                    cell3a.Size = New Size(report.xrMainTable.Rows(0).Cells(2).WidthF + 2, 25)
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

                    cell1a.Text = ""
                    cell2a.Text = ""
                    cell3a.Text = ""
                    cell4a.Text = ""
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
                    grandatotal = grandatotal + (a - b)


                    tra.Cells.Add(cell1a)
                    tra.Cells.Add(cell2a)
                    tra.Cells.Add(cell3a)
                    tra.Cells.Add(cell4a)
                    tra.Cells.Add(cell5a)
                    tra.Cells.Add(cell6a)
                    tra.Cells.Add(cell7a)


                    report.xrMainTable.Rows.Add(tra)


                Next


                Dim trx As New DevExpress.XtraReports.UI.XRTableRow
                Dim cell1xa, cell2xa As New DevExpress.XtraReports.UI.XRTableCell
              
                Dim lastcellwidth = 0

                lastcellwidth = report.xrMainTable.Rows(0).Cells(0).WidthF
                lastcellwidth = lastcellwidth + report.xrMainTable.Rows(0).Cells(1).WidthF
                lastcellwidth = lastcellwidth + report.xrMainTable.Rows(0).Cells(2).WidthF
                lastcellwidth = lastcellwidth + report.xrMainTable.Rows(0).Cells(3).WidthF
                lastcellwidth = lastcellwidth + report.xrMainTable.Rows(0).Cells(4).WidthF
                lastcellwidth = lastcellwidth + report.xrMainTable.Rows(0).Cells(5).WidthF

                cell1xa.Size = New Size(lastcellwidth, 25)
                cell1xa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter

                cell2xa.Size = New Size(report.xrMainTable.Rows(0).Cells(6).WidthF, 25)
                cell2xa.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                cell1xa.Text = "GRAND TOTAL"
                cell1xa.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)
                cell2xa.Text = FormatNumber(grandatotal, TriState.True)
                cell2xa.Font = New Font(Me.Font.FontFamily, Me.Font.Size, FontStyle.Bold)

                trx.Cells.Add(cell1xa)
                trx.Cells.Add(cell2xa)
                report.xrMainTable.Rows.Add(trx)


            End If


           




            report.CreateDocument()
            report.BringToFront()
            frmPrint.MdiParent = frmMain
            frmPrint.Show()
            frmPrint.BringToFront()

        End If

    End Sub

  
End Class