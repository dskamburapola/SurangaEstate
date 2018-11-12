Public Class frmMonthlyReport 

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

            Dim ds As New DataSet
            PL.FromDate = currentDate
            ds = PL.GetMonthlyReport()

            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            Dim dt5 As DataTable
            Dim dt6 As DataTable
            Dim dt7 As DataTable
            Dim dt8 As DataTable
            Dim dt9 As DataTable
            Dim dt10 As DataTable
            Dim dt11 As DataTable
            Dim dt12 As DataTable
            Dim dt13 As DataTable
            Dim dt14 As DataTable
            Dim dt15 As DataTable
            Dim dt16 As DataTable
            Dim dt17 As DataTable
            Dim dt18 As DataTable
            Dim dt19 As DataTable
            Dim dt20 As DataTable
            Dim dt21 As DataTable

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
            dt17 = ds.Tables(16)
            dt18 = ds.Tables(17)
            dt19 = ds.Tables(18)
            dt20 = ds.Tables(19)
            dt21 = ds.Tables(20)



            Dim report As New xrMonthlyReport
            frmPrint.PrintControl1.PrintingSystem = report.PrintingSystem

            report.xrMonth.Text = "MONTHLY REPORT - " + meMonth.Text.ToString + "-" + leYear.EditValue.ToString

            If (dt1.Rows.Count > 0) Then

                report.xrTeaDes.Text = dt1.Rows(0)("TeaCropQty").ToString() + " X " + dt1.Rows(0)("TeaRate").ToString()
                report.xrTeaAmt.Text = FormatNumber(dt1.Rows(0)("TeaAmt").ToString(), 2, TriState.True)
                report.xrTeaDeductions.Text = FormatNumber(dt1.Rows(0)("TeaDeductions").ToString(), 2, TriState.True)
                report.xrTeaTotal.Text = FormatNumber(Val(dt1.Rows(0)("TeaAmt").ToString()) - Val(dt1.Rows(0)("TeaDeductions").ToString()), 2, TriState.True)

                report.xrRubberLatexDes.Text = dt1.Rows(0)("RubberLatextCropQty").ToString() + " X " + dt1.Rows(0)("RubberLatexRate").ToString()
                report.xrRubberLatexAmt.Text = FormatNumber(dt1.Rows(0)("RubberLatexAmt").ToString(), 2, TriState.True)
                report.xrRLTotal.Text = FormatNumber(dt1.Rows(0)("RubberLatexAmt").ToString(), 2, TriState.True)

                report.xrRubberSheetDes.Text = dt1.Rows(0)("RubberSheetQty").ToString() + " X " + dt1.Rows(0)("RubberSheeRate").ToString()
                report.xrRubberSheetAmt.Text = FormatNumber(dt1.Rows(0)("RubberSheeAmt").ToString(), 2, TriState.True)
                report.xrRSTotal.Text = FormatNumber(dt1.Rows(0)("RubberSheeAmt").ToString(), 2, TriState.True)

                report.xrOTotal.Text = FormatNumber(dt1.Rows(0)("NonOtherAmt").ToString(), 2, TriState.True)

               
              
                '********************************************************************************************************************************

                'If dt15.Rows.Count > 0 Then

                '    Dim i As Int64

                '    Dim xx As New DevExpress.XtraReports.UI.XRTable

                '    For i = 0 To dt15.Rows.Count - 1


                '        Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                '        xx.WidthF = 345

                '        xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                '        xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                '        xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom



                '        cell1.Size = New Size(200, 21)
                '        cell2.Size = New Size(145, 21)

                '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                '        cell1.Text = ""


                '        If IsDBNull(dt15.Rows(i).Item("Note")) Then
                '            cell1.Text = ""
                '        Else
                '            cell1.Text = dt15.Rows(i).Item("Note").ToString
                '        End If



                '        If IsDBNull(dt15.Rows(i).Item("Amount")) Then
                '            cell2.Text = "0.00 "
                '        Else
                '            cell2.Text = FormatNumber(CStr((dt15.Rows(i).Item("Amount"))), 2, TriState.True) & " "

                '        End If





                '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                '        tr.Cells.Add(cell1)
                '        tr.Cells.Add(cell2)


                '        xx.Rows.Add(tr)


                '    Next

                '    Dim rISDP As New DevExpress.XtraReports.UI.XRTableRow
                '    rISDP = report.XrTable1.Rows("rowISDP")
                '    rISDP.Cells("xrtISDP").Controls.Add(xx)

                'End If


                '********************************************************************************************************************************


                report.xrEmployeeSalary.Text = FormatNumber(dt1.Rows(0)("EmployeeSalaryAmt").ToString(), 2, TriState.True)
                report.xrEPF12.Text = FormatNumber(dt1.Rows(0)("EPF12Amt").ToString(), 2, TriState.True)
                report.xrETF3.Text = FormatNumber(dt1.Rows(0)("ETF3Amt").ToString(), 2, TriState.True)


            End If

            If (dt2.Rows.Count > 0) Then

                For i = 0 To dt2.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrPluckingDes1.Text = "[" + dt2.Rows(i)("EmployerNo").ToString() + "] " + dt2.Rows(i)("EmployerName").ToString()
                            report.xrPluckingAmt1.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"

                        Case 1
                            report.xrPluckingDes2.Text = "[" + dt2.Rows(i)("EmployerNo").ToString() + "] " + dt2.Rows(i)("EmployerName").ToString()
                            report.xrPluckingAmt2.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"

                        Case 2
                            report.xrPluckingDes3.Text = "[" + dt2.Rows(i)("EmployerNo").ToString() + "] " + dt2.Rows(i)("EmployerName").ToString()
                            report.xrPluckingAmt3.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"
                       

                    End Select

                Next

            End If

            If (dt3.Rows.Count > 0) Then

                For i = 0 To dt3.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrRubberLatexDes1.Text = "[" + dt3.Rows(i)("EmployerNo").ToString() + "] " + dt3.Rows(i)("EmployerName").ToString()
                            report.xrRubberLatexAmt1.Text = dt3.Rows(i)("Quantity").ToString()

                        Case 1
                            report.xrRubberLatexDes2.Text = "[" + dt3.Rows(i)("EmployerNo").ToString() + "] " + dt3.Rows(i)("EmployerName").ToString()
                            report.xrRubberLatexAmt2.Text = dt3.Rows(i)("Quantity").ToString()

                        Case 2
                            report.xrRubberLatexDes3.Text = "[" + dt3.Rows(i)("EmployerNo").ToString() + "] " + dt3.Rows(i)("EmployerName").ToString()
                            report.xrRubberLatexAmt3.Text = dt3.Rows(i)("Quantity").ToString()
                       

                    End Select

                Next

            Else

                report.xrRubberLatexDes1.Text = "N/A"
                            report.xrRubberLatexDes2.Text = "N/A"
                            report.xrRubberLatexDes3.Text = "N/A"



            End If

            If (dt4.Rows.Count > 0) Then

                For i = 0 To dt4.Rows.Count - 1

                    Select Case i

                        Case 0
                            '  report.xrRubberSheetDes1.Text = "[" + dt4.Rows(i)("EmployerNo").ToString() + "] " + dt4.Rows(i)("EmployerName").ToString()
                            ' report.xrRubberSheetAmt1.Text = dt4.Rows(i)("Quantity").ToString()

                        Case 1
                            '   report.xrRubberSheetDes2.Text = "[" + dt4.Rows(i)("EmployerNo").ToString() + "] " + dt4.Rows(i)("EmployerName").ToString()
                            '   report.xrRubberSheetAmt2.Text = dt4.Rows(i)("Quantity").ToString()

                        Case 2
                            report.xrRubberSheetDes3.Text = "[" + dt4.Rows(i)("EmployerNo").ToString() + "] " + dt4.Rows(i)("EmployerName").ToString()
                            report.xrRubberSheetAmt3.Text = dt4.Rows(i)("Quantity").ToString()
                     

                    End Select

                Next

            Else

                
                '    report.xrRubberSheetDes1.Text = "N/A"
                '     report.xrRubberSheetDes2.Text = "N/A"
                report.xrRubberSheetDes3.Text = "N/A"

                   

            End If

            If (dt5.Rows.Count > 0) Then

                For i = 0 To dt5.Rows.Count - 1

                    Select Case i


                        Case 0
                            report.xrAttendaceDes1.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendaceDays1.Text = dt5.Rows(i)("WorkedDays").ToString()

                        Case 1
                            report.xrAttendaceDes2.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendaceDays2.Text = dt5.Rows(i)("WorkedDays").ToString()

                        Case 2
                            report.xrAttendaceDes3.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendaceDays3.Text = dt5.Rows(i)("WorkedDays").ToString()


                            'Case 0
                            '    report.xrAttendanceName1.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            '    report.xrAttendanceDays1.Text = dt5.Rows(i)("WorkedDays").ToString()
                            '    report.xrAttendanceDaysPerc1.Text = FormatNumber(dt5.Rows(i)("DaysAvg").ToString(), 2, TriState.True)
                            '    report.xrAttendancePluck1.Text = dt5.Rows(i)("Plucking").ToString()
                            '    report.xrAttendanceLatex1.Text = dt5.Rows(i)("Tapping").ToString()
                            '    report.xrAttendanceSheets1.Text = dt5.Rows(i)("RubberSheet").ToString()
                            '    report.xrAttendanceScrapping1.Text = dt5.Rows(i)("Scrapping").ToString()


                            'Case 1
                            '    report.xrAttendanceName2.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            '    report.xrAttendanceDays2.Text = dt5.Rows(i)("WorkedDays").ToString()
                            '    report.xrAttendanceDaysPerc2.Text = FormatNumber(dt5.Rows(i)("DaysAvg").ToString(), 2, TriState.True)
                            '    report.xrAttendancePluck2.Text = dt5.Rows(i)("Plucking").ToString()
                            '    report.xrAttendanceLatex2.Text = dt5.Rows(i)("Tapping").ToString()
                            '    report.xrAttendanceSheets2.Text = dt5.Rows(i)("RubberSheet").ToString()
                            '    report.xrAttendanceScrapping2.Text = dt5.Rows(i)("Scrapping").ToString()


                            'Case 2
                            '    report.xrAttendanceName3.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            '    report.xrAttendanceDays3.Text = dt5.Rows(i)("WorkedDays").ToString()
                            '    report.xrAttendanceDaysPerc3.Text = FormatNumber(dt5.Rows(i)("DaysAvg").ToString(), 2, TriState.True)
                            '    report.xrAttendancePluck3.Text = dt5.Rows(i)("Plucking").ToString()
                            '    report.xrAttendanceLatex3.Text = dt5.Rows(i)("Tapping").ToString()
                            '    report.xrAttendanceSheets3.Text = dt5.Rows(i)("RubberSheet").ToString()
                            '    report.xrAttendanceScrapping3.Text = dt5.Rows(i)("Scrapping").ToString()



                    End Select

                Next

            End If

            '**********************************************************
            If (dt6.Rows.Count > 0) Then

                For i = 0 To dt6.Rows.Count - 1

                    If dt6.Rows(i)("Designation").ToString() = "PERMANENT" Then

                        report.xrAdvancePermenant.Text = FormatNumber(dt6.Rows(i)("Advance").ToString(), 2, TriState.True)

                    End If

                    If dt6.Rows(i)("Designation").ToString() = "CASUAL" Then

                        report.xrAdvanceCasual.Text = FormatNumber(dt6.Rows(i)("Advance").ToString(), 2, TriState.True)
                        'Else
                        '    report.xrAdvanceCasual.Text = 0
                    End If

                    If dt6.Rows(i)("Designation").ToString() = "STAFF" Then

                        report.xrAdvanceStaff.Text = FormatNumber(dt6.Rows(i)("Advance").ToString(), 2, TriState.True)
                        'Else
                        '    report.xrAdvanceStaff.Text = 0

                    End If


                Next

               


            End If
            '********************************************************

            '**********************************************************
            If (dt7.Rows.Count > 0) Then

                For i = 0 To dt7.Rows.Count - 1

                    If dt7.Rows(i)("Designation").ToString() = "PERMANENT" Then

                        report.xrFadvPermanent.Text = FormatNumber(dt7.Rows(i)("FestivalAdvance").ToString(), 2, TriState.True)

                    Else
                        report.xrFadvPermanent.Text = 0
                    End If

                    If dt7.Rows(i)("Designation").ToString() = "CASUAL" Then

                        report.xrFadvCasual.Text = FormatNumber(dt7.Rows(i)("FestivalAdvance").ToString(), 2, TriState.True)
                    End If

                    If dt7.Rows(i)("Designation").ToString() = "STAFF" Then

                        report.xrFadvStaff.Text = FormatNumber(dt7.Rows(i)("FestivalAdvance").ToString(), 2, TriState.True)
                    Else
                        report.xrFadvStaff.Text = 0
                    End If


                Next

                
                '-------------------------------------
            End If
            '**

            '********************************************************************************************************************************

            Dim OtherEx As Decimal
            '**********************************************************
            If (dt8.Rows.Count > 0) Then

                For i = 0 To dt8.Rows.Count - 1

                    If dt8.Rows(i)("Description").ToString() = "WATER" Then

                        report.xrWater.Text = FormatNumber(dt8.Rows(i)("OtherExpense").ToString(), 2, TriState.True)

                    End If


                    If dt8.Rows(i)("Description").ToString() = "ELECTRICITY" Then
                        report.xrElectricity.Text = FormatNumber(dt8.Rows(i)("OtherExpense").ToString(), 2, TriState.True)

                    End If

                    If dt8.Rows(i)("Description").ToString() = "MOTIVATION PAYMENTS" Then

                        report.xrMotivation.Text = FormatNumber(dt8.Rows(i)("OtherExpense").ToString(), 2, TriState.True)

                    End If


                    If dt8.Rows(i)("Description").ToString() = "CASH REWARDS" Then

                        report.xrCashRewards.Text = FormatNumber(dt8.Rows(i)("OtherExpense").ToString(), 2, TriState.True)

                    End If


                    If dt8.Rows(i)("Description").ToString() <> "WATER" And dt8.Rows(i)("Description").ToString() <> "ELECTRICITY" And dt8.Rows(i)("Description").ToString() <> "MOTIVATION PAYMENTS" And dt8.Rows(i)("Description").ToString() <> "CASH REWARDS" Then

                        OtherEx = OtherEx + Convert.ToDecimal(dt8.Rows(i)("OtherExpense").ToString())


                    End If


                Next
                report.xrOtherExp.Text = FormatNumber(OtherEx, 2, TriState.True)
              



            End If
            '********************************************************

           

          
            '-------------------------------------------



            If dt17.Rows.Count > 0 Then

                Dim i As Int64

                Dim xx As New DevExpress.XtraReports.UI.XRTable

                For i = 0 To dt17.Rows.Count - 1


                    Dim cell1, cell2, cell3 As New DevExpress.XtraReports.UI.XRTableCell
                    xx.WidthF = 345

                    xx.Borders = DevExpress.XtraPrinting.BorderSide.None
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.Top
                    xx.Borders = DevExpress.XtraPrinting.BorderSide.Bottom

                 

                    cell1.Size = New Size(200, 21)
                    cell2.Size = New Size(145, 21)

                    cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                    cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight


                    cell1.Text = ""


                    If IsDBNull(dt17.Rows(i).Item("Note")) Then
                        cell1.Text = ""
                    Else
                        cell1.Text = dt17.Rows(i).Item("Note").ToString
                    End If



                    If IsDBNull(dt17.Rows(i).Item("Amount")) Then
                        cell2.Text = "0.00 "
                    Else
                        cell2.Text = FormatNumber(CStr((dt17.Rows(i).Item("Amount"))), 2, TriState.True) & " "

                    End If





                    Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                    tr.Cells.Add(cell1)
                    tr.Cells.Add(cell2)


                    xx.Rows.Add(tr)


                Next

                Dim rISDP As New DevExpress.XtraReports.UI.XRTableRow
                rISDP = report.XrTable1.Rows("rowEXI")
                rISDP.Cells("xrtEXI").Controls.Add(xx)
                
            End If


            '********************************************************************************************************************************


            If (dt9.Rows.Count > 0) Then
                report.xrtFW.Text = dt9.Rows(0)("FW").ToString()
            End If

            If (dt10.Rows.Count > 0) Then
                report.xrtPW.Text = dt10.Rows(0)("RW").ToString()
                report.xrtAVC.Text = dt10.Rows(0)("RW").ToString()
            End If

            report.xrtEXCESS.Text = Val(report.xrtFW.Text) - Val(report.xrtPW.Text)

            If (dt11.Rows.Count > 0) Then
                report.xrtAVP.Text = (dt11.Rows(0)("PLUCKER").ToString())
                'report.xrtAVP.Text = Convert.ToString(FormatNumber(dt11.Rows(0)("PLUCKER").ToString(), 0))
            Else
                report.xrtAVP.Text = ""
            End If

            report.xrtAVG.Text = Convert.ToString(FormatNumber(Val(report.xrtPW.Text) / Val(report.xrtAVP.Text), 2, TriState.True))




            If (dt11.Rows.Count > 0) Then
                'report.xrtPL.Text = FormatNumber(dt11.Rows(0)("PLUCKER").ToString(), 0)
                report.xrtPL.Text = (dt11.Rows(0)("PLUCKER").ToString())
            End If


            If (dt12.Rows.Count > 0) Then
                'report.xrtSU.Text = FormatNumber(dt12.Rows(0)("SUNDRAY").ToString(), 0)
                report.xrtSU.Text = (dt12.Rows(0)("SUNDRAY").ToString())
            End If


            If (dt13.Rows.Count > 0) Then
                'report.xrtWT.Text = FormatNumber(dt13.Rows(0)("WATCHER").ToString(), 0)
                report.xrtWT.Text = (dt13.Rows(0)("WATCHER").ToString())
            End If



            If (dt14.Rows.Count > 0) Then
                'report.xrtST.Text = FormatNumber(dt14.Rows(0)("STAFF").ToString(), 0)
                report.xrtST.Text = (dt14.Rows(0)("STAFF").ToString())
            End If


            If (dt18.Rows.Count > 0) Then
                'report.xrtPL.Text = FormatNumber(dt11.Rows(0)("PLUCKER").ToString(), 0)
                report.xrtTA.Text = (dt18.Rows(0)("TAPPER").ToString())
            End If

            If (dt19.Rows.Count > 0) Then

                If IsDBNull(dt19.Rows(0).Item("InvestmentExpenses")) Then
                    report.xrInvestmentExpenses.Text = "0.00 "
                Else
                    report.xrInvestmentExpenses.Text = FormatNumber(CStr((dt19.Rows(0)("InvestmentExpenses").ToString())), 2, TriState.True) & " "

                End If

            End If


            Dim a, b, c, d, t As Decimal

            a = IIf(report.xrTeaTotal.Text = String.Empty, 0, Convert.ToDecimal(report.xrTeaTotal.Text))
            b = IIf(report.xrRLTotal.Text = String.Empty, 0, Convert.ToDecimal(report.xrRLTotal.Text))
            c = IIf(report.xrRSTotal.Text = String.Empty, 0, Convert.ToDecimal(report.xrRSTotal.Text))
            d = IIf(report.xrOTotal.Text = String.Empty, 0, Convert.ToDecimal(report.xrOTotal.Text))
            t = a + b + c + d

            report.xrIncomeTotal.Text = FormatNumber(t, 2, TriState.True)

            Dim pad, pac, pas, pat As Decimal


            pad = Convert.ToDecimal(report.xrAdvancePermenant.Text)
            pac = Convert.ToDecimal(report.xrAdvanceCasual.Text)
            pas = Convert.ToDecimal(report.xrAdvanceStaff.Text)


            pat = pad + pac + pas
            report.xrAdvanceTotal.Text = FormatNumber(pat, 2, TriState.True)

            Dim fad, fac, fas, fat As Decimal

            fad = Convert.ToDecimal(IIf(report.xrFadvPermanent.Text = String.Empty, "0", report.xrFadvPermanent.Text))
            fac = Convert.ToDecimal(IIf(report.xrFadvCasual.Text = String.Empty, "0", report.xrFadvCasual.Text))
            fas = Convert.ToDecimal(IIf(report.xrFadvStaff.Text = String.Empty, "0", report.xrFadvStaff.Text))


            fat = fad + fac + fas
            report.xrFadvTotal.Text = FormatNumber(fat, 2, TriState.True)

            Dim TS, TA, TF, TST As Decimal


            TS = Convert.ToDecimal(report.xrEmployeeSalary.Text)

            TA = Convert.ToDecimal(report.xrAdvanceTotal.Text)
            TF = Convert.ToDecimal(report.xrFadvTotal.Text)

            TST = TS + TA + TF

            report.xrSalaryTotal.Text = FormatNumber(TST, 2, TriState.True)

            Dim wt, ec, mp, cr, ot, att As Decimal

            wt = Convert.ToDecimal(report.xrWater.Text)
            ec = Convert.ToDecimal(report.xrElectricity.Text)
            mp = Convert.ToDecimal(report.xrMotivation.Text)
            cr = Convert.ToDecimal(report.xrCashRewards.Text)
            ot = Convert.ToDecimal(report.xrOtherExp.Text)

            att = wt + ec + mp + cr + ot

            report.xrtotalOtherExpenses.Text = FormatNumber(att, 2, TriState.True)




            Dim a1, b1, c1, d1, tt1 As Decimal

            a1 = Convert.ToDecimal(report.xrSalaryTotal.Text)
            b1 = Convert.ToDecimal(report.xrEPF12.Text)
            c1 = Convert.ToDecimal(report.xrETF3.Text)
            d1 = Convert.ToDecimal(report.xrtotalOtherExpenses.Text)
            tt1 = a1 + b1 + c1 + d1

            report.xrTotalExpenses.Text = FormatNumber(tt1, 2, TriState.True)

            report.xrISDPTotal.Text = FormatNumber(dt1.Rows(0)("OtherAmt").ToString(), 2, TriState.True)

            report.xrtTO.Text = FormatNumber(Val(report.xrtPL.Text) + Val(report.xrtTA.Text) + Val(report.xrtSU.Text) + Val(report.xrtWT.Text) + Val(report.xrtST.Text), 0, TriState.False)

            report.xrtAVPL.Text = FormatNumber(Val(Val(report.xrtPL.Text) / Val(report.xrtTO.Text)) * 100, 2, TriState.True)

            report.xrtAVSU.Text = FormatNumber(Val(Val(report.xrtSU.Text) / Val(report.xrtTO.Text)) * 100, 2, TriState.True)

            report.xrtAVTA.Text = FormatNumber(Val(Val(report.xrtTA.Text) / Val(report.xrtTO.Text)) * 100, 2, TriState.True)

            report.xrtAVWT.Text = FormatNumber(Val(Val(report.xrtWT.Text) / Val(report.xrtTO.Text)) * 100, 2, TriState.True)

            report.xrtAVST.Text = FormatNumber(Val(Val(report.xrtST.Text) / Val(report.xrtTO.Text)) * 100, 2, TriState.True)

            report.xrtAvgTotal.Text = FormatNumber(Val(IIf(report.xrtAVPL.Text = String.Empty, 0, report.xrtAVPL.Text)) + Val(IIf(report.xrtAVSU.Text = String.Empty, 0, report.xrtAVSU.Text)) + Val(IIf(report.xrtAVTA.Text = String.Empty, 0, report.xrtAVTA.Text)) + Val(IIf(report.xrtAVWT.Text = String.Empty, 0, report.xrtAVWT.Text)) + Val(IIf(report.xrtAVST.Text = String.Empty, 0, report.xrtAVST.Text)))

            report.xrNettProfit.Text = FormatNumber((Convert.ToDecimal(report.xrIncomeTotal.Text) - Convert.ToDecimal(report.xrTotalExpenses.Text)), 2, TriState.True)

            If (dt16.Rows.Count > 0) Then
                report.xrtNOD.Text = "NOD = " & dt16.Rows(0)("WorkDays").ToString()
            End If

            report.xrtNOE.Text = "NOE = " & report.xrtTO.Text


            If (dt20.Rows.Count > 0) Then

                For i = 0 To dt5.Rows.Count - 1

                    Select Case i




                        Case 0
                            report.xrbpn1.Text = "[" + dt20.Rows(i)("EmployerNo").ToString() + "] " + dt20.Rows(i)("EmployerName").ToString()
                            report.xrbpd1.Text = dt20.Rows(i)("WorkedDays").ToString()
                            report.xrbpc1.Text = FormatNumber(dt20.Rows(i)("PContribution").ToString(), 2, TriState.True)
                            report.xrbpq1.Text = dt20.Rows(i)("Plucking").ToString()



                        Case 1
                            report.xrbpn2.Text = "[" + dt20.Rows(i)("EmployerNo").ToString() + "] " + dt20.Rows(i)("EmployerName").ToString()
                            report.xrbpd2.Text = dt20.Rows(i)("WorkedDays").ToString()
                            report.xrbpc2.Text = FormatNumber(dt20.Rows(i)("PContribution").ToString(), 2, TriState.True)
                            report.xrbpq2.Text = dt20.Rows(i)("Plucking").ToString()


                        Case 2
                            report.xrbpn3.Text = "[" + dt20.Rows(i)("EmployerNo").ToString() + "] " + dt20.Rows(i)("EmployerName").ToString()
                            report.xrbpd3.Text = dt20.Rows(i)("WorkedDays").ToString()
                            report.xrbpc3.Text = FormatNumber(dt20.Rows(i)("PContribution").ToString(), 2, TriState.True)
                            report.xrbpq3.Text = dt20.Rows(i)("Plucking").ToString()


                    End Select

                Next

            End If



            If (dt21.Rows.Count > 0) Then

                For i = 0 To dt5.Rows.Count - 1

                    Select Case i




                        Case 0
                            report.xrbtn1.Text = "[" + dt21.Rows(i)("EmployerNo").ToString() + "] " + dt21.Rows(i)("EmployerName").ToString()
                            report.xrbtd1.Text = dt21.Rows(i)("WorkedDays").ToString()
                            report.xrbtc1.Text = FormatNumber(dt21.Rows(i)("TContribution").ToString(), 2, TriState.True)
                            report.xrbtq1.Text = dt21.Rows(i)("Tapping").ToString()



                        Case 1
                            report.xrbtn2.Text = "[" + dt21.Rows(i)("EmployerNo").ToString() + "] " + dt21.Rows(i)("EmployerName").ToString()
                            report.xrbtd2.Text = dt21.Rows(i)("WorkedDays").ToString()
                            report.xrbtc2.Text = FormatNumber(dt21.Rows(i)("TContribution").ToString(), 2, TriState.True)
                            report.xrbtq2.Text = dt21.Rows(i)("Tapping").ToString()


                        Case 2
                            report.xrbtn3.Text = "[" + dt21.Rows(i)("EmployerNo").ToString() + "] " + dt21.Rows(i)("EmployerName").ToString()
                            report.xrbtd3.Text = dt21.Rows(i)("WorkedDays").ToString()
                            report.xrbtc3.Text = FormatNumber(dt21.Rows(i)("TContribution").ToString(), 2, TriState.True)
                            report.xrbtq3.Text = dt21.Rows(i)("Tapping").ToString()


                    End Select

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