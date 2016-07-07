Imports iStockCommon.iStockConstants
Public Class frmStaffSalary


#Region "Variables"
    Private _CWBExpenses As iStockCommon.iStockExpenses
    Private _CWBEmployers As iStockCommon.iStockEmployers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
#End Region

#Region "Constructors"

    Public ReadOnly Property CWBEmployers() As iStockCommon.iStockEmployers
        Get

            If _CWBEmployers Is Nothing Then
                _CWBEmployers = New iStockCommon.iStockEmployers
            End If

            Return _CWBEmployers
        End Get
    End Property

    Public ReadOnly Property CWBExpenses() As iStockCommon.iStockExpenses
        Get

            If _CWBExpenses Is Nothing Then
                _CWBExpenses = New iStockCommon.iStockExpenses
            End If

            Return _CWBExpenses
        End Get
    End Property

    Public ReadOnly Property iStockDailyWorking() As iStockCommon.iStockDailyWorking
        Get

            If _iStockDailyWorking Is Nothing Then
                _iStockDailyWorking = New iStockCommon.iStockDailyWorking
            End If

            Return _iStockDailyWorking
        End Get
    End Property
#End Region

#Region "Form Events"
    Private Sub frmEmployers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmEmployers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        deDatePaid.EditValue = Date.Today.ToShortDateString
       
    End Sub
#End Region

#Region "Tab Events"
    Private Sub xTab1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles xTab1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()


                Me.PopulateGrid()


        End Select
    End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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

#Region "Bar Button Events"
    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If dxvpEmployers.Validate Then
            If lblID.Text = String.Empty Then

                CWBEmployers.EmployerNo = Mid(Me.leEmployee.Text.Trim, 1, 3)



                Me.SaveRecords()


            Else
                Dim frm As New frmUpdateYesNo
                frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
                frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL


                If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then

                    CWBEmployers.EmployerNo = Mid(Me.leEmployee.Text.Trim, 1, 3)

                        Me.SaveRecords()
            
                End If
            End If

        End If
    End Sub

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        If Not lblID.Text = String.Empty Then
            Dim frm As New frmDeleteYesNo
            frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
            frm.lblDescription.ForeColor = Color.Red
            frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
            frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
            frm.Text = CWB_DELETE_CONFIRMATION_TITLE

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Me.Delete(lblID.Text)

            End If
        End If

    End Sub

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick
        With gvEmployers
            .ClearColumnsFilter()
            .ClearGrouping()
            .ClearSelection()
            .ClearSorting()
        End With

    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick
        Me.DisplayRecord()
    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick

        PrintPreview(gcEmployers, "Employees Report")
    End Sub
#End Region

#Region "Grid Events"

    Private Sub gvEmployers_DoubleClick_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DisplayRecord()
    End Sub
#End Region

#Region "Save Records"
    Private Sub SaveRecords()


        Try
            With CWBExpenses
                .StaffPayID = 0 'Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))

                .EmployerID = Convert.ToInt64(leEmployee.EditValue)

                .Department = ceDepartment.Text

                If IsDate(deDatePaid.EditValue) Then
                    .PayDate = deDatePaid.EditValue
                Else
                    .PayDate = Date.MinValue
                End If

                .Amount = seAmount.EditValue

                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertStaffPay()

                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With
            Me.ClearFormData()
        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

#Region "Delete Data"
    Private Sub Delete(ByVal EmployerID As Int64)

        Try
            With CWBEmployers
                .EmployerID = EmployerID
                .Delete()
            End With
            Me.ClearFormData()

        Catch ex As SqlClient.SqlException
            Dim frm As New frmOk
            frm.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_DELETE_ERROR_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()
        End Try

    End Sub
#End Region

#Region "Dispay Record"
    Public Sub DisplayRecord()

        Try
            If gvEmployers.RowCount > 0 And Not gvEmployers.IsFilterRow(gvEmployers.FocusedRowHandle) Then
                xTab1.SelectedTabPageIndex = 0
                With CWBExpenses

                    .StaffPayID = Me.gvEmployers.GetFocusedRowCellValue(GridColumn1)
                    .SelectStaffPayByID()


                    lblID.Text = .StaffPayID
                    ceDepartment.Text = .Department
                    leEmployee.EditValue = .EmployerID

                    If .PayDate = Date.MinValue Then
                        deDatePaid.EditValue = DBNull.Value
                    Else
                        deDatePaid.EditValue = .PayDate
                    End If

                    seAmount.Text = .Amount
                    
                End With

                
            End If
        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

#Region "Populate Grid"
    Public Sub PopulateGrid()
        Try
            gcEmployers.DataSource = CWBExpenses.StaffPayGetAll.Tables(0)

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Clears Form Data"

    Private Sub ClearFormData()
        Try
            'lblID.Text = String.Empty
            'seEmployerNo.Text = String.Empty
            'teEmployerName.Text = String.Empty
            '' peEmployer.EditValue = DBNull.Value
            'teAdressLine1.Text = String.Empty
            'teAddressLine2.Text = String.Empty
            'teCity.Text = String.Empty
            'deDOB.EditValue = DBNull.Value
            'deDatePaid.EditValue = DBNull.Value
            'ceSex.Text = String.Empty
            'teNICNo.Text = String.Empty
            'teTelephone.Text = String.Empty
            'ceDesignation.Text = String.Empty
            'ceDepartment.Text = String.Empty
            'teEmployerContactPerson.Text = String.Empty
            'cmbIsResign.Text = String.Empty
            'deResignDate.EditValue = DBNull.Value

            ''seBasicSalary.Text = 0
            ''seOTRate.Text = 0
            ''seFixedAllowance.Text = 0
            ''seOtherAllowance.Text = 0.0
            ''seDeduction.Text = 0
            'seAmount.Text = String.Empty
            'dxvpEmployers.RemoveControlError(seEmployerNo)
            'dxvpEmployers.RemoveControlError(teEmployerName)
            'dxvpEmployers.RemoveControlError(ceSex)


            'seEmployerNo.Focus()
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub

#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try

            iStockDailyWorking.WorkType = ceDepartment.Text
            Me.leEmployee.Properties.DataSource = iStockDailyWorking.GetEmployeeForWork.Tables(1)
            Me.leEmployee.Properties.DisplayMember = "EmployerNo"
            Me.leEmployee.Properties.ValueMember = "EmployerID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region


   

    Private Sub ceDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ceDepartment.SelectedIndexChanged
        GetEmployeeForWork()
    End Sub

    Private Sub leEmployee_EditValueChanged(sender As Object, e As EventArgs) Handles leEmployee.EditValueChanged

    End Sub

    

    Private Sub gcEmployers_Click(sender As Object, e As EventArgs) Handles gcEmployers.Click
        Me.DisplayRecord()
    End Sub
End Class