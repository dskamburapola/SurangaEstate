Imports iStockCommon.iStockCompany
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockCashAdvance


Public Class frmCashAdvance

#Region "Properties"
    Private _iStockCashAdvance As iStockCommon.iStockCashAdvance

#End Region

#Region "Constructors"

    Public ReadOnly Property iStockCashAdvance() As iStockCommon.iStockCashAdvance
        Get

            If _iStockCashAdvance Is Nothing Then
                _iStockCashAdvance = New iStockCommon.iStockCashAdvance
            End If

            Return _iStockCashAdvance

        End Get
    End Property
#End Region

#Region "Form Events"
    'Private Sub frmCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
    '    Me.HideToolButtonsOnLoad()
    '    Me.DisplayCompany()
    'End Sub

    Private Sub frmCashAdvance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.deIssueDate.EditValue = Date.Today
        Me.GetEmployeeForWork()
        Me.deIssueDate.Focus()


    End Sub
    Private Sub frmCompany_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpCompany.Validate Then
            '   Me.SaveCompany()
        End If


    End Sub
#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try

            Me.leEmployee.Properties.DataSource = iStockCashAdvance.GetEmployeeForWork.Tables(0)
            Me.leEmployee.Properties.DisplayMember = "EmployerNo"
            Me.leEmployee.Properties.ValueMember = "EmployerID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Get Payment Details For Advance"
    Private Sub GetPaymentDetailsForAdvance()

        Try
            With iStockCashAdvance
                .EmployeeID = Me.leEmployee.EditValue
                .IssueDate = Me.deIssueDate.EditValue

                .GetPaymentDetailsForAdvance()

                If (iStockCashAdvance.GetPaymentDetailsForAdvance IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables.Count > 0 And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1) IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows.Count > 0) Then

                    Me.teWorkedDays.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("PWorkedDays") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("PWorkedDays").ToString(), String.Empty), 2, TriState.True)
                    Me.tePayment.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("PAmount") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("PAmount").ToString(), String.Empty), 2, TriState.True)
                    Me.teEPF.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("EPF") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(1).Rows(0)("EPF").ToString(), String.Empty), 2, TriState.True)

                End If

                If (iStockCashAdvance.GetPaymentDetailsForAdvance IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables.Count > 0 And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(2) IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(2).Rows.Count > 0) Then

                    Me.teFestivalAdvance.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(2).Rows(0)("FestivalAdvance") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(2).Rows(0)("FestivalAdvance").ToString(), String.Empty), 2, TriState.True)

                End If

                If (iStockCashAdvance.GetPaymentDetailsForAdvance IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables.Count > 0 And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(3) IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(3).Rows.Count > 0) Then

                    Me.teLoan.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(3).Rows(0)("Loan") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(3).Rows(0)("Loan").ToString(), String.Empty), 2, TriState.True)

                End If

                If (iStockCashAdvance.GetPaymentDetailsForAdvance IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables.Count > 0 And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(4) IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(4).Rows.Count > 0) Then

                    Me.teCashAdvance.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(4).Rows(0)("AdvanceAmount") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(4).Rows(0)("AdvanceAmount").ToString(), String.Empty), 2, TriState.True)

                End If


                If (iStockCashAdvance.GetPaymentDetailsForAdvance IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables.Count > 0 And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(5) IsNot Nothing And iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(5).Rows.Count > 0) Then

                    Me.teLMB.Text = FormatNumber(IIf(iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(5).Rows(0)("LmbValue") IsNot Nothing, iStockCashAdvance.GetPaymentDetailsForAdvance.Tables(5).Rows(0)("LmbValue").ToString(), String.Empty), 2, TriState.True)

                End If


            End With

            Me.teTotalDeductions.Text = Convert.ToDecimal(teLMB.Text) + Convert.ToDecimal(teEPF.Text) + Convert.ToDecimal(teFestivalAdvance.Text) + Convert.ToDecimal(teLoan.Text) + Convert.ToDecimal(teCashAdvance.Text)

            Me.tePaybleAmount.Text = Convert.ToDecimal(tePayment.Text) - Convert.ToDecimal(teTotalDeductions.Text)
        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Save CashAdvance"
    Private Sub SaveCashAdvance()

        Try
            With iStockCashAdvance

                .EmployeeID = Me.leEmployee.EditValue
                .IssueDate = Me.deIssueDate.Text
                .AdvanceAmount = Convert.ToDecimal(Me.sePaybleAmount.Text)
                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertCashAdvance()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()

               

            End With
         

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


        Me.ClearFormData()
        'Me.deIssueDate.Focus()

    End Sub
#End Region

#Region "Clear Form Data"

    Public Sub ClearFormData()

        Me.deIssueDate.Text = Date.Today
        Me.leEmployee.Text = String.Empty
        Me.teCashAdvance.Text = String.Empty
        Me.teEmployeeName.Text = String.Empty
        Me.teEPF.Text = String.Empty
        Me.teFestivalAdvance.Text = String.Empty
        Me.teLMB.Text = String.Empty
        Me.teLoan.Text = String.Empty
        Me.sePaybleAmount.Text = String.Empty
        Me.tePayment.Text = String.Empty
        Me.teTotalDeductions.Text = String.Empty
        Me.teWorkedDays.Text = String.Empty

        '    Me.deIssueDate.Focus()


    End Sub
#End Region

#Region "Daily Working Get All By Dates"
    Private Sub CashAdvanceGetAllByDates()

        Try


            With iStockCashAdvance



                .StartDate = deStartDate.EditValue
                .EndDate = deEndDate.EditValue
                gcCashAdvance.DataSource = .CashAdvanceGetAllByDates.Tables(0)




            End With




        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

    Private Sub leEmployee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        teEmployeeName.Text = leEmployee.GetColumnValue("EmployerName")
    End Sub

    Private Sub leEmployee_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.GetPaymentDetailsForAdvance()
        Me.sePaybleAmount.Focus()
        SendKeys.Send("{HOME}+{END}")

    End Sub

    Private Sub sePaybleAmount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.SaveCashAdvance()

    End Sub

   

    Private Sub sePaybleAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            Me.SaveCashAdvance()

        End If
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Me.CashAdvanceGetAllByDates()
    End Sub

End Class