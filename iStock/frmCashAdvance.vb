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


    Private Sub frmCashAdvance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.deIssueDate.EditValue = Date.Today
        Me.GetEmployeeForWork()
        Me.deIssueDate.Focus()

        Me.deStartDate.EditValue = Date.Today
        Me.deEndDate.EditValue = Date.Today

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
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

    End Sub

#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        
        If dxvpCashAdvance.Validate Then

            Me.SaveCashAdvance()
            Me.ClearFormData()
        End If

    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick

    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick

    End Sub

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick
        With gvCashAdvance
            .ClearColumnsFilter()
            .ClearGrouping()
            .ClearSelection()
            .ClearSorting()
        End With

    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        PrintPreview(gcCashAdvance, "Monthly Cash Advance Report")

    End Sub

#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try

            Me.leEmployee.Properties.DataSource = iStockCashAdvance.GetEmployeeForWork.Tables(0)
            Me.leEmployee.Properties.DisplayMember = "EmployerName"
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

                Dim ds As New DataSet
                ds=.GetPaymentDetailsForAdvance()

                If (ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(1) IsNot Nothing And ds.Tables(1).Rows.Count > 0) Then

                    Me.teWorkedDays.Text = IIf(ds.Tables(1).Rows(0)("PWorkedDays") IsNot Nothing And ds.Tables(1).Rows(0)("PWorkedDays").ToString() <> String.Empty, ds.Tables(1).Rows(0)("PWorkedDays").ToString(), 0)
                    Me.tePayment.Text = IIf(ds.Tables(1).Rows(0)("PAmount") IsNot Nothing And ds.Tables(1).Rows(0)("PAmount").ToString() <> String.Empty, ds.Tables(1).Rows(0)("PAmount").ToString(), 0)
                    Me.teEPF.Text = IIf(ds.Tables(1).Rows(0)("EPF") IsNot Nothing And ds.Tables(1).Rows(0)("EPF").ToString() <> String.Empty, ds.Tables(1).Rows(0)("EPF").ToString(), 0)

                Else
                    Me.teWorkedDays.Text = 0
                    Me.tePayment.Text = 0
                    Me.teEPF.Text = 0
                End If

                If (ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(2) IsNot Nothing And ds.Tables(2).Rows.Count > 0) Then

                    Me.teFestivalAdvance.Text = IIf(ds.Tables(2).Rows(0)("FestivalAdvance") IsNot Nothing And ds.Tables(2).Rows(0)("FestivalAdvance").ToString() <> String.Empty, ds.Tables(2).Rows(0)("FestivalAdvance").ToString(), 0)

                Else
                    Me.teFestivalAdvance.Text = 0

                End If

                If (ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(3) IsNot Nothing And ds.Tables(3).Rows.Count > 0) Then

                    Me.teLoan.Text = IIf(ds.Tables(3).Rows(0)("Loan") IsNot Nothing And ds.Tables(3).Rows(0)("Loan").ToString() <> String.Empty, ds.Tables(3).Rows(0)("Loan").ToString(), 0)
                Else
                    Me.teLoan.Text = 0
                End If

                If (ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(4) IsNot Nothing And ds.Tables(4).Rows.Count > 0) Then

                    Me.teCashAdvance.Text = IIf(ds.Tables(4).Rows(0)("AdvanceAmount") IsNot Nothing And ds.Tables(4).Rows(0)("AdvanceAmount").ToString() <> String.Empty, ds.Tables(4).Rows(0)("AdvanceAmount").ToString(), 0)
                Else
                    Me.teCashAdvance.Text = 0
                End If


                If (ds IsNot Nothing And ds.Tables.Count > 0 And ds.Tables(5) IsNot Nothing And ds.Tables(5).Rows.Count > 0) Then

                    Me.teLMB.Text = IIf(ds.Tables(5).Rows(0)("LmbValue") IsNot Nothing And ds.Tables(5).Rows(0)("LmbValue").ToString() <> String.Empty, ds.Tables(5).Rows(0)("LmbValue").ToString(), 0)
                Else
                    Me.teLMB.Text = 0

                End If


            End With

            Me.teTotalDeductions.Text = Convert.ToDecimal(teLMB.EditValue) + Convert.ToDecimal(teEPF.EditValue) + Convert.ToDecimal(teFestivalAdvance.EditValue) + Convert.ToDecimal(teLoan.EditValue) + Convert.ToDecimal(teCashAdvance.EditValue)

            Me.tePaybleAmount.Text = Convert.ToDecimal(tePayment.EditValue) - Convert.ToDecimal(teTotalDeductions.EditValue)
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

        '  Me.deIssueDate.Text = Date.Today
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

        Me.leEmployee.Focus()


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

#Region "Tab Events"
    Private Sub xTab1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles xTab1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()
                'Me.PopulateGrid()

        End Select
    End Sub
#End Region

#Region "Editor Events"

    Private Sub leEmployee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        teEmployeeName.Text = leEmployee.GetColumnValue("EmployerName")
    End Sub

    Private Sub leEmployee_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)

       

    End Sub

    

    

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Me.CashAdvanceGetAllByDates()
    End Sub

#End Region

#Region "Show Tool Buttons On History Tab change"
    Public Sub ShowToolButtonsOnHistoryTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Show Tool Buttons On New Record Tab change"
    Public Sub ShowToolButtonsOnNewRecordTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub
#End Region

   
    'Private Sub leEmployee_EditValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leEmployee.EditValueChanged
    '    Me.GetPaymentDetailsForAdvance()
    '    Me.sePaybleAmount.Focus()
    '    SendKeys.Send("{HOME}+{END}")
    'End Sub

    

   
    Private Sub leEmployee_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles leEmployee.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.GetPaymentDetailsForAdvance()
            Me.sePaybleAmount.Focus()
            SendKeys.Send("{HOME}+{END}")
        End If

    End Sub

   
    Private Sub sePaybleAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles sePaybleAmount.KeyPress
        If Asc(e.KeyChar) = 13 Then

            If dxvpCashAdvance.Validate Then

                Me.SaveCashAdvance()
                Me.ClearFormData()
            End If

        End If
    End Sub
End Class