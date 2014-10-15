Imports iStockCommon.iStockOtherIncomes
Imports iStockCommon.iStockCollections
Imports iStockCommon.iStockConstants
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockEnums


Public Class frmOtherIncome

#Region "Variables"
    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome
    Private _CWBCollection As iStockCommon.iStockCollections
    Dim _CWBEnums As iStockCommon.iStockEnums
#End Region

#Region "Constructors"

    Public ReadOnly Property CWBOtherIncome() As iStockCommon.iStockOtherIncome
        Get

            If _CWBOtherIncome Is Nothing Then
                _CWBOtherIncome = New iStockCommon.iStockOtherIncome()
            End If

            Return _CWBOtherIncome
        End Get
    End Property
    Public ReadOnly Property CWBEnums() As iStockCommon.iStockEnums
        Get

            If _CWBEnums Is Nothing Then
                _CWBEnums = New iStockCommon.iStockEnums
            End If

            Return _CWBEnums
        End Get
    End Property


    Public ReadOnly Property CWBCollection() As iStockCommon.iStockCollections
        Get

            If _CWBCollection Is Nothing Then
                _CWBCollection = New iStockCommon.iStockCollections
            End If

            Return _CWBCollection
        End Get
    End Property
#End Region

#Region "Form Events"
    Private Sub frmOtherIncomes_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmOtherIncomes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetCWBExpenseBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.PopulateOtherIncomeTypesLookup()
        Me.deDate.EditValue = Date.Today
        Me.deFromDate.EditValue = Date.Today
        Me.deToDate.EditValue = Date.Today
    End Sub
#End Region

#Region "Bar Button Events"

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpOtherIncomes.Validate Then
            If lblID.Text = String.Empty Then
                Me.SaveRecords()
            Else
                Dim frm As New frmUpdateYesNo
                frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
                frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL


                If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Me.UpdateRecords()

                End If
            End If
            Me.ClearFormData()
        End If
    End Sub

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick
        With gvOtherIncomes
            .ClearColumnsFilter()
            .ClearGrouping()
            .ClearSelection()
            .ClearSorting()
        End With
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

                Me.DeleteOtherIncomes(lblID.Text)
                Me.ClearFormData()
            End If
        End If

        lupOtherIncomeType.Focus()

    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick
        Me.DisplayOtherIncome()
    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        PrintPreview(gcOtherIncomes, "OtherIncome Report")
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
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

    End Sub
#End Region

#Region "Show Tool Buttons On New Record Tab change"
    Public Sub ShowToolButtonsOnNewRecordTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

    End Sub
#End Region

#Region "Tab Control Events"
    Private Sub xTab1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles xTab1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()


        End Select

    End Sub
#End Region

#Region "Clear Form Data"
    Private Sub ClearFormData()
        Me.lupOtherIncomeType.EditValue = DBNull.Value
        Me.seAmount.EditValue = 0
        Me.meNote.Text = String.Empty
        Me.lblID.Text = String.Empty
        Me.seRate.EditValue = 0
        Me.seQuantity.EditValue = 0
        dxvpOtherIncomes.RemoveControlError(lupOtherIncomeType)
        Me.lupOtherIncomeType.Focus()

    End Sub
#End Region

#Region "Populate OtherIncomeTypes Lookup"
    Public Sub PopulateOtherIncomeTypesLookup()

        Try
            With lupOtherIncomeType
                .Properties.DataSource = CWBOtherIncome.OtherIncomeTypesGetAll().Tables(0)
                .Properties.DisplayMember = "Description"
                .Properties.ValueMember = "OtherIncomeTypeID"

            End With


        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Lookup Events"
    Private Sub lupOtherIncomeType_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lupOtherIncomeType.ButtonClick
        Select Case e.Button.Index
            Case 1
                If Not Me.lupOtherIncomeType.Text = String.Empty Then
                    Me.SaveOtherIncomeType()
                    Me.PopulateOtherIncomeTypesLookup()
                End If

            Case 2


                If Not Me.lupOtherIncomeType.Text = String.Empty Then
                    Dim frm As New frmDeleteYesNo
                    frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
                    frm.lblDescription.ForeColor = Color.Red
                    frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
                    frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
                    frm.Text = CWB_DELETE_CONFIRMATION_TITLE

                    If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                        Me.DeleteOtherIncomeType()
                        Me.PopulateOtherIncomeTypesLookup()

                    End If
                End If

        End Select

    End Sub
#End Region

#Region "Save OtherIncomes"
    Private Sub SaveRecords()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try

            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            With CWBOtherIncome
                .OtherIncomeID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
                .OtherIncomeTypeID = Me.lupOtherIncomeType.EditValue
                Select Case cbePaymentType.SelectedIndex
                    Case 0
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                    Case 1
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                    Case 2
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD
                End Select

                .OtherIncomeDate = Me.deDate.EditValue
                .Amount = Me.seAmount.EditValue
                .Rate = Me.seRate.EditValue
                .Quantity = Me.seQuantity.EditValue
                .Note = Me.meNote.EditValue
                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertExpnese(_DB, _Transaction)

                With CWBCollection
                    .SystemID = CWBOtherIncome.CurrentOtherIncomeID
                    .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.OTHERINCOME

                    Select Case Me.cbePaymentType.SelectedIndex
                        Case 0
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                        Case 1
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                        Case 2
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD
                    End Select

                    .Date = Me.deDate.EditValue
                    .Reference = String.Empty
                    .Amount = Me.seAmount.EditValue

                    .InsertCollection(_DB, _Transaction)

                End With
                _Transaction.Commit()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With
        Catch ex As Exception
            _Transaction.Rollback()
        End Try

    End Sub
#End Region

#Region "Update OtherIncomes"
    Private Sub UpdateRecords()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try

            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            With CWBOtherIncome

                .OtherIncomeID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
                .OtherIncomeTypeID = Me.lupOtherIncomeType.EditValue

                Select Case cbePaymentType.SelectedIndex
                    Case 0
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                    Case 1
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                    Case 2
                        .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD
                End Select

                .OtherIncomeDate = Me.deDate.EditValue
                .Amount = Me.seAmount.EditValue
                .Note = Me.meNote.EditValue
                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertExpnese(_DB, _Transaction)



                With CWBCollection

                    .SystemID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
                    .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.OTHERINCOME
                    .CollectionDelete(_DB, _Transaction)

                    .SystemID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
                    .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.OTHERINCOME

                    Select Case Me.cbePaymentType.SelectedIndex
                        Case 0
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                        Case 1
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                        Case 2
                            .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD
                    End Select

                    .Date = Date.Now
                    .Reference = String.Empty
                    .Amount = Me.seAmount.EditValue
                    .InsertCollection(_DB, _Transaction)

                End With
                _Transaction.Commit()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With
        Catch ex As Exception
            _Transaction.Rollback()
        End Try

    End Sub
#End Region

#Region "Save OtherIncome Type"
    Private Sub SaveOtherIncomeType()
        Try
            With CWBOtherIncome
                .Description = Me.lupOtherIncomeType.Text
                .InsertExpneseTypes()

            End With
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Delete OtherIncome Type"
    Private Sub DeleteOtherIncomeType()
        Try
            With CWBOtherIncome
                .Description = Me.lupOtherIncomeType.Text
                .OtherIncomeTypesDelete()
            End With
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Populate Grid"
    Public Sub PopulateHistoryData()
        Try
            CWBOtherIncome.FromDate = Me.deFromDate.EditValue
            CWBOtherIncome.ToDate = Me.deToDate.EditValue

            gcOtherIncomes.DataSource = CWBOtherIncome.OtherIncomeGetByDates().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Delete OtherIncomes"
    Private Sub DeleteOtherIncomes(ByVal OtherIncomeID As Int64)
        Try
            With CWBOtherIncome
                .OtherIncomeID = OtherIncomeID
                .OtherIncomeDelete()
            End With

        Catch ex As Exception
            Dim frm As New frmOk
            frm.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_DELETE_ERROR_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()
        End Try


    End Sub
#End Region

#Region "Display OtherIncome"
    Public Sub DisplayOtherIncome()

        If gvOtherIncomes.RowCount > 0 Then


            xTab1.SelectedTabPageIndex = 0
            With CWBOtherIncome
                .OtherIncomeID = gvOtherIncomes.GetFocusedRowCellValue(GridColumn1)
                .GetOtherIncomeByID()
                lblID.Text = .OtherIncomeID
                lupOtherIncomeType.EditValue = .OtherIncomeTypeID

                Select Case .PaymentTypeID
                    Case 1
                        cbePaymentType.SelectedIndex = 0
                    Case 2
                        cbePaymentType.SelectedIndex = 1
                    Case 3
                        cbePaymentType.SelectedIndex = 2


                End Select

                deDate.EditValue = .OtherIncomeDate
                seAmount.EditValue = .Amount
                seRate.EditValue = .Rate
                seQuantity.EditValue = .Quantity
                meNote.EditValue = .Note


            End With
        End If

    End Sub
#End Region

#Region "Grid Events"
    Private Sub gvOtherIncomes_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvOtherIncomes.DoubleClick
        Me.DisplayOtherIncome()
    End Sub
#End Region

#Region "Button Events"
    Private Sub sbProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess.Click
        Try

            If dxvpHistoryData.Validate Then
                Me.PopulateHistoryData()
            End If

        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

End Class