Imports iStockCommon.iStockPurchases
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockStock
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockCollections


Public Class frmPurchases

#Region "Variables"
    Dim _CWBPurchases As iStockCommon.iStockPurchases
    Dim _CWBSuppliers As iStockCommon.iStockSuppliers
    Dim _CWBStockItems As iStockCommon.iStockStock
    Dim _CWBCollections As iStockCommon.iStockCollections
    Dim _CWBEnums As iStockCommon.iStockEnums



#End Region

#Region "Constructor"
    Public ReadOnly Property CWBPurchases() As iStockCommon.iStockPurchases
        Get

            If _CWBPurchases Is Nothing Then
                _CWBPurchases = New iStockCommon.iStockPurchases
            End If

            Return _CWBPurchases
        End Get
    End Property

    Public ReadOnly Property CWBSuppliers() As iStockCommon.iStockSuppliers
        Get

            If _CWBSuppliers Is Nothing Then
                _CWBSuppliers = New iStockCommon.iStockSuppliers
            End If

            Return _CWBSuppliers
        End Get
    End Property

    Public ReadOnly Property CWBStockItems() As iStockCommon.iStockStock
        Get

            If _CWBStockItems Is Nothing Then
                _CWBStockItems = New iStockCommon.iStockStock
            End If

            Return _CWBStockItems
        End Get
    End Property

    Public ReadOnly Property CWBCollections() As iStockCommon.iStockCollections
        Get

            If _CWBCollections Is Nothing Then
                _CWBCollections = New iStockCommon.iStockCollections
            End If

            Return _CWBCollections
        End Get
    End Property

    Public ReadOnly Property CWBEnums() As iStockCommon.iStockEnums
        Get

            If _CWBEnums Is Nothing Then
                _CWBEnums = New iStockCommon.iStockEnums()
            End If

            Return _CWBEnums
        End Get
    End Property
#End Region

#Region "Form Events"

    Private Sub frmPurchases_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmPurchasings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPurchaseSalesBarButton(bbSave, bbNew, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.dePurchaseDate.EditValue = Date.Today
        Me.deFromDate.EditValue = Date.Today
        Me.deToDate.EditValue = Date.Today

        Me.deFrom2.EditValue = Date.Today
        Me.deTo2.EditValue = Date.Today

        Me.PopulateDescriptionGrid()
        Me.PopulateCollectionsGrid()

    End Sub

    Private Sub frmPurchases_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.PopulateSupplierLookup()
        Me.PopulateStockItemsGridLookup()

    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If dxvpPurchase.Validate Then

            If lblPurchaseID.Text = String.Empty Then
                Me.SaveRecords()
                Me.PopulateStockItemsGridLookup()

            Else

                Dim frm As New frmUpdateYesNo
                frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
                frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL

                If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Me.UpdateRecords()
                    Me.PopulateStockItemsGridLookup()
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

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick


        If xTab1.SelectedTabPageIndex = 1 Then
            With gvPurchaseHistory
                .ClearColumnsFilter()
                .ClearGrouping()
                .ClearSelection()
                .ClearSorting()
            End With
        ElseIf xTab1.SelectedTabPageIndex = 2 Then
            With gvPurchaseHistoryItems
                .ClearColumnsFilter()
                .ClearGrouping()
                .ClearSelection()
                .ClearSorting()
            End With
        End If


  
    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick
        If xTab1.SelectedTabPageIndex = 1 Then
            Me.DisplayRecord(Me.gvPurchaseHistory.GetFocusedRowCellValue(GridColumn18))
        ElseIf xTab1.SelectedTabPageIndex = 2 Then
            Me.DisplayRecord(Me.gvPurchaseHistoryItems.GetFocusedRowCellValue(GridColumn3))
        End If


    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick

        If xTab1.SelectedTabPageIndex = 1 Then
            PrintPreview(gcPurchaseHistory, "Purchases Report")
        ElseIf xTab1.SelectedTabPageIndex = 2 Then
            PrintPreview(gcPurchaseHistoryItems, "Purchases Items Report")
        End If




    End Sub
#End Region

#Region "Clear Form Data"
    Public Sub ClearFormData()

        lblPurchaseID.Text = String.Empty
        lblSystemNo.Text = String.Empty
        teReferenceNo.Text = String.Empty
        seTaxAmount.Text = "0"
        seDiscount.Text = "0"
        meNote.Text = String.Empty
        sePercentage.Text = "0"
        seGrandTotal.Text = 0
        lupSupplier.EditValue = DBNull.Value

        dxvpPurchase.RemoveControlError(lupSupplier)

        Me.PopulateDescriptionGrid()
        Me.PopulateCollectionsGrid()
        lupSupplier.Focus()

    End Sub
#End Region

#Region "Simple Button Events"
    'Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCalculate.Click

    '    Try
    '        Dim a, b As Decimal

    '        GridColumn5.SummaryItem.DisplayFormat = ""
    '        a = Val(GridColumn5.SummaryText)
    '        GridColumn5.SummaryItem.DisplayFormat = "Total : {0:n2}"

    '        b = Convert.ToDecimal(a + Val(seTaxAmount.EditValue) - Val(seDiscount.EditValue))

    '        'lblBalance.Text = "Payable - " + FormatNumber(Convert.ToString(b), 2)
    '        a = 0



    '    Catch ex As Exception
    '        MessageError(ex.ToString)
    '    End Try


    'End Sub
#End Region

#Region "Populate Suppliers Lookup"
    Public Sub PopulateSupplierLookup()

        Try
            With lupSupplier
                .Properties.DataSource = CWBSuppliers.GetAllSuppliers.Tables(0)
                .Properties.DisplayMember = "SupplierName"
                .Properties.ValueMember = "SupplierID"
                .Properties.PopupWidth = 350
            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Stock Items Grid Lookup"
    Public Sub PopulateStockItemsGridLookup()

        Try
            With glupStockItems
                .DataSource = CWBStockItems.GetAllStockItems.Tables(0)
                .DisplayMember = "StockCode"
                .ValueMember = "StockCode"
            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Description Grid"
    Public Sub PopulateDescriptionGrid()

        Try
            With gcPurchasesDescription
                CWBPurchases.PurchaseID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
                .DataSource = CWBPurchases.GetPurchaseDescriptionByID.Tables(0)

            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Collections Grid"
    Private Sub PopulateCollectionsGrid()
        Try
            CWBPurchases.PurchaseID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
            CWBCollections.SystemID = CWBPurchases.PurchaseID
            CWBCollections.TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.PURCHASE
            gcCollections.DataSource = CWBCollections.CollectionGetByID().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Repository Events"
    Private Sub glupStockItems_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles glupStockItems.EditValueChanged
        Try
            
            Dim gridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = CType(sender, DevExpress.XtraEditors.GridLookUpEdit)
            Dim iCurrentRow As Integer = CInt(gvPurchasesDescription.FocusedRowHandle.ToString)

            If gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolStockID) IsNot Nothing Then
                gvPurchasesDescription.SetFocusedRowCellValue(colStockID, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolStockID).ToString())

                gvPurchasesDescription.SetFocusedRowCellValue(colDescription, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolDescription).ToString())
                gvPurchasesDescription.SetFocusedRowCellValue(colUnitPrice, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolPurchasePrice).ToString())

            End If


          

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub
#End Region

#Region "Grid Events"



    Private Sub gvCollectionGrid_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvCollections.CellValueChanged

        Try
            Select Case e.Column.VisibleIndex
                Case 0
                    Dim a, b As Decimal

                    colValue.SummaryItem.DisplayFormat = ""
                    a = Val(colValue.SummaryText)
                    colValue.SummaryItem.DisplayFormat = "Total : {0:n2}"



                    GridColumn16.SummaryItem.DisplayFormat = ""
                    b = Val(GridColumn16.SummaryText)
                    GridColumn16.SummaryItem.DisplayFormat = "{0:n2}"


                    gvCollections.SetFocusedRowCellValue(GridColumn14, Date.Today)
                    gvCollections.SetFocusedRowCellValue(GridColumn16, Val(a + Val(seTaxAmount.EditValue) - Val(seDiscount.EditValue) - b))

                    Me.CalculateBalance()
            End Select
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub

    Private Sub gcPurchasesDescription_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvPurchasesDescription.KeyDown
        If e.KeyCode = Keys.Delete Then
            gvPurchasesDescription.DeleteRow(gvPurchasesDescription.FocusedRowHandle)
        End If
    End Sub

    Private Sub gvCollections_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvCollections.KeyDown
        If e.KeyCode = Keys.Delete Then
            gvCollections.DeleteRow(gvCollections.FocusedRowHandle)
        End If
    End Sub

    Private Sub gvPurchaseHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvPurchaseHistory.DoubleClick
        Me.DisplayRecord(Me.gvPurchaseHistory.GetFocusedRowCellValue(GridColumn18))
        Me.CalculateBalance()
    End Sub

    Private Sub gvPurchasesDescription_RowUpdated(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gvPurchasesDescription.RowUpdated

        Me.CalculateBalance()
    End Sub

    Private Sub gvPurchasesDescription_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvPurchasesDescription.FocusedRowChanged
        Me.CalculateBalance()
    End Sub
#End Region

#Region "Populate Purchase History"
    Private Sub PopulatePurchaseHistory()

        Try
            CWBPurchases.FromDate = Me.deFromDate.EditValue
            CWBPurchases.ToDate = Me.deToDate.EditValue
            gcPurchaseHistory.DataSource = CWBPurchases.GetPurchasesByDates().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

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

    End Sub
#End Region

#Region "Show Tool Buttons On New Record Tab change"
    Public Sub ShowToolButtonsOnNewRecordTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always

    End Sub
#End Region

#Region "Tab Control Events"
    Private Sub xTab1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles xTab1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()
                Me.PopulatePurchaseHistory()
        End Select
    End Sub
#End Region

#Region "Dispay Record"
    Public Sub DisplayRecord(ByVal id As Long)


        With CWBPurchases
            .PurchaseID = id
            .GetPurchasesByID()
            lblPurchaseID.Text = .PurchaseID
            lblSystemNo.Text = "System No - " + .PurchaseNo.ToString
            lupSupplier.EditValue = .SupplierID
            dePurchaseDate.EditValue = .PurchaseDate
            teReferenceNo.Text = .RefBillNo
            meNote.Text = .Note
            seTaxAmount.Text = .TaxAmount
            sePercentage.Text = .TaxPercent
            seDiscount.Text = .Discount
            Me.PopulateDescriptionGrid()
            Me.PopulateCollectionsGrid()
        End With
        xTab1.SelectedTabPageIndex = 0
    End Sub
#End Region

#Region "Save Record"
    Private Sub SaveRecords()



        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            gvPurchasesDescription.PostEditor()
            gvCollections.PostEditor()

            gvPurchasesDescription.MoveLast()
            gvCollections.MoveLast()



            With CWBPurchases
                .PurchaseID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
                .SupplierID = lupSupplier.EditValue
                .PurchaseDate = dePurchaseDate.Text
                .RefBillNo = teReferenceNo.Text.Trim

                colValue.SummaryItem.DisplayFormat = ""
                .Total = gvPurchasesDescription.Columns("Value").SummaryText
                .TaxPercent = sePercentage.EditValue

                .TaxAmount = seTaxAmount.EditValue
                .Discount = seDiscount.EditValue
                .GrandTotal = seGrandTotal.EditValue
                .Note = meNote.Text

                If seGrandTotal.EditValue = GridColumn16.SummaryText Then
                    .Paid = True
                Else
                    .Paid = False
                End If


                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertPurchase(_DB, _Transaction)



                For i As Integer = 0 To Me.gvPurchasesDescription.RowCount
                    If Not gvPurchasesDescription.GetRowCellDisplayText(i, gvPurchasesDescription.Columns(0)) = "" Then
                        .PurchaseID = .CurrentPurchaseID
                        .StockID = Me.gvPurchasesDescription.GetRowCellDisplayText(i, colStockID)
                        .Unit_Price = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colUnitPrice))
                        .Quantity = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colQuantity))
                        .Discount = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colDiscount))
                        .BagWeight = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colBagWeight))
                        .NoOfBags = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colNoOfBas))
                        .Value = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colValue))
                        .InsertPurchaseDescription(_DB, _Transaction)

                        'Update Main Stock
                        .StockID = Me.gvPurchasesDescription.GetRowCellDisplayText(i, colStockID)
                        .StockBalance = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colQuantity))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next



                With CWBCollections
                    For i As Integer = 0 To Me.gvCollections.RowCount
                        If Not gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(0)) = "" Then
                            .SystemID = CWBPurchases.CurrentPurchaseID
                            .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.PURCHASE

                            Select Case Me.gvCollections.GetRowCellDisplayText(i, GridColumn13)

                                Case "CASH"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                                Case "CHECK"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                                Case "CR CARD"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD

                            End Select

                            .Date = Date.Parse(Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(1)))
                            .Reference = Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(2))
                            .Amount = FormatNumber(Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(3)), 2, , , )
                            .InsertCollection(_DB, _Transaction)
                        End If

                    Next

                End With



                _Transaction.Commit()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
                Me.ClearFormData()


            End With


        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If

        End Try
    End Sub
#End Region

#Region "Update Records"
    Private Sub UpdateRecords()


        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try
            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            gvPurchasesDescription.PostEditor()
            gvCollections.PostEditor()

            gvPurchasesDescription.MoveLast()
            gvCollections.MoveLast()



            With CWBPurchases
                .PurchaseID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
                .SupplierID = lupSupplier.EditValue
                .PurchaseDate = dePurchaseDate.Text
                .RefBillNo = teReferenceNo.Text.Trim

                colValue.SummaryItem.DisplayFormat = ""
                .Total = gvPurchasesDescription.Columns("Value").SummaryText
                .TaxPercent = 0
                .TaxAmount = seTaxAmount.EditValue
                .Discount = seDiscount.EditValue
                .GrandTotal = seGrandTotal.EditValue
                .TaxPercent = sePercentage.EditValue
                .Note = meNote.Text
                If seGrandTotal.EditValue = GridColumn16.SummaryText Then
                    .Paid = True
                Else
                    .Paid = False
                End If

                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertPurchase(_DB, _Transaction)

                .RemoveFromStock(_DB, _Transaction)
                .PurchasesDescriptionDelete(_DB, _Transaction)


                For i As Integer = 0 To Me.gvPurchasesDescription.RowCount
                    If Not gvPurchasesDescription.GetRowCellDisplayText(i, gvPurchasesDescription.Columns(0)) = "" Then

                        .StockID = Me.gvPurchasesDescription.GetRowCellDisplayText(i, colStockID)
                        .Unit_Price = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colUnitPrice))
                        .Quantity = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colQuantity))
                        .Discount = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colDiscount))
                        .BagWeight = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colBagWeight))
                        .NoOfBags = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colNoOfBas))
                        .Value = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colValue))
                        .InsertPurchaseDescription(_DB, _Transaction)

                        'Update Main Stock
                        .StockID = Me.gvPurchasesDescription.GetRowCellDisplayText(i, colStockID)
                        .StockBalance = Val(Me.gvPurchasesDescription.GetRowCellDisplayText(i, colQuantity))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next



                With CWBCollections
                    .SystemID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
                    .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.PURCHASE
                    .CollectionDelete(_DB, _Transaction)


                    'Add new Records to Collection Table
                    For i As Integer = 0 To Me.gvCollections.RowCount
                        If Not gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(0)) = "" Then
                            .SystemID = Convert.ToInt64(IIf(lblPurchaseID.Text = String.Empty, 0, lblPurchaseID.Text))
                            .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.PURCHASE

                            Select Case Me.gvCollections.GetRowCellDisplayText(i, GridColumn13)

                                Case "CASH"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                                Case "CHECK"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                                Case "CR CARD"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD

                            End Select

                            .Date = Date.Parse(Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(1)))
                            .Reference = Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(2))
                            .Amount = FormatNumber(Me.gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(3)), 2, , , )
                            .InsertCollection(_DB, _Transaction)
                        End If

                    Next

                End With


                _Transaction.Commit()
                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
                Me.ClearFormData()


            End With

        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If

        End Try


    End Sub
#End Region

#Region "Show Print Preview"
    Private Sub ShowPrintPreview()
        Try
            Dim _frmPrintPreview As New frmPrint
            ''Dim _xrPurchasing As New xrPurchasing
            ''_xrPurchasing.Purchases_GetByIDTableAdapter.GetData(Me.gvPurchaseHistory.GetFocusedRowCellValue(GridColumn18))
            ''_xrPurchasing.PurchasesDescription_GetByIDTableAdapter.GetData(Me.gvPurchaseHistory.GetFocusedRowCellValue(GridColumn18))
            ''_frmPrintPreview.PrintControl1.PrintingSystem = _xrPurchasing.PrintingSystem

            '_xrPurchasing.CreateDocument()

            _frmPrintPreview.MdiParent = frmMain
            _frmPrintPreview.Show()
            _frmPrintPreview.BringToFront()
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Calculate Balance"
    Private Sub CalculateBalance()
        Try

            Dim total, taxamount, discount, balance As Decimal



            colValue.SummaryItem.DisplayFormat = ""
            total = Val(colValue.SummaryText)
            colValue.SummaryItem.DisplayFormat = "Total : {0:n2}"


            taxamount = Me.seTaxAmount.EditValue
            discount = Me.seDiscount.EditValue
            balance = total + taxamount - (discount)

            seGrandTotal.EditValue = balance

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Calculate Discount Percent"
    Private Sub CalculateDiscountPercent()

        Try

            Dim total, discount As Decimal



            colValue.SummaryItem.DisplayFormat = ""
            total = Val(colValue.SummaryText)
            colValue.SummaryItem.DisplayFormat = "Total : {0:n2}"



            discount = total * (sePercentage.EditValue / 100)


            seDiscount.EditValue = discount



        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "SpinEdit Events"

    Private Sub seTaxAmount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles seTaxAmount.EditValueChanged
        Me.CalculateBalance()
    End Sub

    Private Sub seDiscount_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles seDiscount.EditValueChanged
        Me.CalculateBalance()
    End Sub

    Private Sub sePercentage_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sePercentage.EditValueChanged
        Me.CalculateDiscountPercent()
    End Sub
#End Region

#Region "Button Events"
    Private Sub smProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smProcess.Click
        If dxvpHistoryData.Validate Then
            Me.PopulatePurchaseHistory()
        End If

    End Sub


#End Region


    Private Sub gvPurchasesDescription_ValidatingEditor(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles gvPurchasesDescription.ValidatingEditor


        Dim grd As DevExpress.XtraGrid.Views.Grid.GridView

        grd = sender

        If grd.ActiveEditor.EditorTypeName = "SpinEdit" Then


            If grd.ActiveEditor.Properties.Name = "risiUnitPrice" Or grd.ActiveEditor.Properties.Name = "risiQuantity" Then

                If Not IsDBNull(grd.ActiveEditor.EditValue) Or Not grd.ActiveEditor.EditValue = Nothing Then

                    If grd.ActiveEditor.EditValue.ToString() = "0" Or grd.ActiveEditor.EditValue = 0 Then
                        e.Valid = False
                    Else
                        e.Valid = True

                    End If


                End If

            End If
        End If


    End Sub

    Private Sub gvPurchasesDescription_ValidateRow(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles gvPurchasesDescription.ValidateRow

        Try

            Dim grd As DevExpress.XtraGrid.Views.Grid.GridView

            grd = sender

            If IsDBNull(grd.GetFocusedRowCellValue(colStockCode)) Or IsDBNull(grd.GetFocusedRowCellValue(colUnitPrice)) Or IsDBNull(grd.GetFocusedRowCellValue(colQuantity)) Then
                e.Valid = False

            Else
                e.Valid = True

            End If



            'If grd.ActiveEditor.EditorTypeName = "SpinEdit" Then


            '    If grd.ActiveEditor.Properties.Name = "risiUnitPrice" Or grd.ActiveEditor.Properties.Name = "risiQuantity" Then

            '        If grd.ActiveEditor.EditValue.ToString() = "0" Or grd.ActiveEditor.EditValue = 0 Then
            '            e.Valid = False
            '        Else
            '            e.Valid = True

            '        End If


            '    End If
            'End If






        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub

    Private Sub lupSupplier_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lupSupplier.ButtonClick
        Try

            If e.Button.Index = 1 Then
                frmSuppliers.StartPosition = FormStartPosition.CenterParent
                frmSuppliers.ShowDialog()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub sbProcess2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess2.Click
        Try
            Me.PopulatePurchaseItemsHistory()
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub

    Private Sub PopulatePurchaseItemsHistory()

        Try
            CWBPurchases.FromDate = Me.deFrom2.EditValue
            CWBPurchases.ToDate = Me.deTo2.EditValue
            gcPurchaseHistoryItems.DataSource = CWBPurchases.GetPurchasesItemsByDates().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub

    Private Sub gvPurchaseHistoryItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvPurchaseHistoryItems.DoubleClick
        Me.DisplayRecord(Me.gvPurchaseHistoryItems.GetFocusedRowCellValue(GridColumn3))
        Me.CalculateBalance()
    End Sub

    Private Sub gvPurchasesDescription_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvPurchasesDescription.CellValueChanged

        Select Case e.Column.Name

            Case "colQuantity", "colUnitPrice", "colDiscount"
                Dim a, b, c As Decimal

                a = IIf(Not IsDBNull(gvPurchasesDescription.GetFocusedRowCellValue(colUnitPrice)), gvPurchasesDescription.GetFocusedRowCellValue(colUnitPrice), 0)
                b = IIf(Not IsDBNull(gvPurchasesDescription.GetFocusedRowCellValue(colQuantity)), gvPurchasesDescription.GetFocusedRowCellValue(colQuantity), 0)
                c = IIf(Not IsDBNull(gvPurchasesDescription.GetFocusedRowCellValue(colDiscount)), gvPurchasesDescription.GetFocusedRowCellValue(colDiscount), 0)
                gvPurchasesDescription.SetFocusedRowCellValue(colValue, ((a * b) - c))

                a = 0
                b = 0
                c = 0

        End Select

    End Sub
End Class