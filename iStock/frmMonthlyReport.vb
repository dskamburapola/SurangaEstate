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


            Dim ds As New DataSet
            ds = PL.GetMonthlyReport()
            Dim dt1 As DataTable
            Dim dt2 As DataTable
            Dim dt3 As DataTable
            Dim dt4 As DataTable
            Dim dt5 As DataTable

            dt1 = ds.Tables(0)
            dt2 = ds.Tables(1)
            dt3 = ds.Tables(2)
            dt4 = ds.Tables(3)
            dt5 = ds.Tables(4)


            Dim report As New xrMonthlyReport
            frmPrint.PrintControl1.PrintingSystem = report.PrintingSystem

            report.xrMonth.Text = meMonth.Text.ToString + "-" + leYear.EditValue.ToString

            If (dt1.Rows.Count > 0) Then

                report.xrTeaDes.Text = dt1.Rows(0)("TeaCropQty").ToString() + " X " + dt1.Rows(0)("TeaRate").ToString()
                report.xrTeaAmt.Text = dt1.Rows(0)("TeaAmt").ToString()
                report.xrRubberLatexDes.Text = dt1.Rows(0)("RubberLatextCropQty").ToString() + " X " + dt1.Rows(0)("RubberLatexRate").ToString()
                report.xrRubberLatexAmt.Text = dt1.Rows(0)("RubberLatexAmt").ToString()
                report.xrRubberSheetDes.Text = dt1.Rows(0)("RubberSheetQty").ToString() + " X " + dt1.Rows(0)("RubberSheeRate").ToString()
                report.xrRubberSheetAmt.Text = dt1.Rows(0)("RubberSheeAmt").ToString()
                report.xrOtherAmt.Text = dt1.Rows(0)("OtherAmt").ToString()
                report.xrCroptTotalAmt.Text = dt1.Rows(0)("CropTotal").ToString()
                report.xrEmployeeSalary.Text = dt1.Rows(0)("EmployeeSalaryAmt").ToString()
                report.xrEPF12.Text = dt1.Rows(0)("EPF12Amt").ToString()
                report.xrETF3.Text = dt1.Rows(0)("ETF3Amt").ToString()
                report.xrTotal.Text = dt1.Rows(0)("Total").ToString()

            End If

            If (dt2.Rows.Count > 0) Then

                For i = 0 To dt2.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrPluckingDes1.Text = dt2.Rows(i)("Name").ToString()
                            report.xrPluckingAmt1.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"

                        Case 1
                            report.xrPluckingDes2.Text = dt2.Rows(i)("Name").ToString()
                            report.xrPluckingAmt2.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"

                        Case 2
                            report.xrPluckingDes3.Text = dt2.Rows(i)("Name").ToString()
                            report.xrPluckingAmt3.Text = dt2.Rows(i)("Quantity").ToString() + "Kg"
                       

                    End Select

                Next

            End If

            If (dt3.Rows.Count > 0) Then

                For i = 0 To dt3.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrRubberLatexDes1.Text = dt3.Rows(i)("Name").ToString()
                            report.xrRubberLatexAmt1.Text = dt3.Rows(i)("Quantity").ToString()

                        Case 1
                            report.xrRubberLatexDes2.Text = IIf(dt3.Rows(i)("Name") IsNot Nothing, dt3.Rows(i)("Name").ToString(), String.Empty)
                            report.xrRubberLatexAmt2.Text = dt3.Rows(i)("Quantity").ToString()

                        Case 2
                            report.xrRubberLatexDes3.Text = dt3.Rows(i)("Name").ToString()
                            report.xrRubberLatexAmt3.Text = dt3.Rows(i)("Quantity").ToString()
                       

                    End Select

                Next

            End If

            If (dt4.Rows.Count > 0) Then

                For i = 0 To dt4.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrRubberSheetDes1.Text = dt4.Rows(i)("Name").ToString()
                            report.xrRubberSheetAmt1.Text = dt4.Rows(i)("Quantity").ToString()

                        Case 1
                            report.xrRubberSheetDes2.Text = dt4.Rows(i)("Name").ToString()
                            report.xrRubberSheetAmt2.Text = dt4.Rows(i)("Quantity").ToString()

                        Case 2
                            report.xrRubberSheetDes3.Text = dt4.Rows(i)("Name").ToString()
                            report.xrRubberSheetAmt3.Text = dt4.Rows(i)("Quantity").ToString()
                     

                    End Select

                Next

            End If

            If (dt5.Rows.Count > 0) Then

                For i = 0 To dt5.Rows.Count - 1

                    Select Case i

                        Case 0
                            report.xrAttendanceName1.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendanceDays1.Text = dt5.Rows(i)("WorkedDays").ToString()
                            report.xrAttendanceDaysPerc1.Text = dt5.Rows(i)("DaysAvg").ToString()
                            report.xrAttendancePluck1.Text = dt5.Rows(i)("Plucking").ToString()
                            report.xrAttendanceLatex1.Text = dt5.Rows(i)("Tapping").ToString()
                            report.xrAttendanceSheets1.Text = dt5.Rows(i)("RubberSheet").ToString()


                        Case 1
                            report.xrAttendanceName2.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendanceDays2.Text = dt5.Rows(i)("WorkedDays").ToString()
                            report.xrAttendanceDaysPerc2.Text = dt5.Rows(i)("DaysAvg").ToString()
                            report.xrAttendancePluck2.Text = dt5.Rows(i)("Plucking").ToString()
                            report.xrAttendanceLatex2.Text = dt5.Rows(i)("Tapping").ToString()
                            report.xrAttendanceSheets2.Text = dt5.Rows(i)("RubberSheet").ToString()

                        Case 2
                            report.xrAttendanceName3.Text = "[" + dt5.Rows(i)("EmployerNo").ToString() + "] " + dt5.Rows(i)("EmployerName").ToString()
                            report.xrAttendanceDays3.Text = dt5.Rows(i)("WorkedDays").ToString()
                            report.xrAttendanceDaysPerc3.Text = dt5.Rows(i)("DaysAvg").ToString()
                            report.xrAttendancePluck3.Text = dt5.Rows(i)("Plucking").ToString()
                            report.xrAttendanceLatex3.Text = dt5.Rows(i)("Tapping").ToString()
                            report.xrAttendanceSheets3.Text = dt5.Rows(i)("RubberSheet").ToString()


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