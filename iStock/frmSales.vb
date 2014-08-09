Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockSales
Imports iStockCommon.iStockCustomers
Imports iStockCommon.iStockStock
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockModels

Public Class frmSales

#Region "Variables"
    Dim _CWBEmployers As iStockCommon.iStockEmployers
    Dim _CWBSales As iStockCommon.iStockSales
    Dim _CWBCustomers As iStockCommon.iStockCustomers
    Dim _CWBStockItems As iStockCommon.iStockStock
    Dim _CWBCollections As iStockCommon.iStockCollections
    Dim _CWBEnums As iStockCommon.iStockEnums
    Dim _CWBModels As iStockCommon.iStockModels
    Dim _CWBApplication As iStockCommon.iStockApplication
    Dim _CWBMessages As iStockCommon.iStockMessages



#End Region

#Region "Constructor"

    Public ReadOnly Property CWBEmployers() As iStockCommon.iStockEmployers
        Get

            If _CWBEmployers Is Nothing Then
                _CWBEmployers = New iStockCommon.iStockEmployers
            End If

            Return _CWBEmployers
        End Get
    End Property

    Public ReadOnly Property CWBModels() As iStockCommon.iStockModels
        Get

            If _CWBModels Is Nothing Then
                _CWBModels = New iStockCommon.iStockModels
            End If

            Return _CWBModels
        End Get
    End Property

    Public ReadOnly Property CWBSales() As iStockCommon.iStockSales
        Get

            If _CWBSales Is Nothing Then
                _CWBSales = New iStockCommon.iStockSales
            End If

            Return _CWBSales
        End Get
    End Property

    Public ReadOnly Property CWBCustomers() As iStockCommon.iStockCustomers
        Get

            If _CWBCustomers Is Nothing Then
                _CWBCustomers = New iStockCommon.iStockCustomers
            End If

            Return _CWBCustomers
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
    Public ReadOnly Property CWBStockItems() As iStockCommon.iStockStock
        Get

            If _CWBStockItems Is Nothing Then
                _CWBStockItems = New iStockCommon.iStockStock
            End If

            Return _CWBStockItems
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

    Public ReadOnly Property CWBApplication() As iStockCommon.iStockApplication
        Get

            If _CWBApplication Is Nothing Then
                _CWBApplication = New iStockCommon.iStockApplication
            End If

            Return _CWBApplication
        End Get
    End Property


    Public ReadOnly Property CWBMessages() As iStockCommon.iStockMessages
        Get

            If _CWBMessages Is Nothing Then
                _CWBMessages = New iStockCommon.iStockMessages
            End If

            Return _CWBMessages
        End Get
    End Property
#End Region

#Region "Form Events"

    Private Sub frmSales_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmSales_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.PopulateCustomerLookup()
        Me.PopulateStockItemsGridLookup()
    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetPurchaseSalesBarButton(bbSave, bbNew, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.PopulateDescriptionGrid()
        Me.PopulateCollectionsGrid()
        Me.PopulateMessageLookup()

        Me.deSalesDate.EditValue = Date.Today

        If UserType = "USER" Then

            Me.deSalesDate.Enabled = False
        End If

        Me.deFromDate.EditValue = Date.Today
        Me.deToDate.EditValue = Date.Today

        Me.deFrom2.EditValue = Date.Today
        Me.deTo2.EditValue = Date.Today

    End Sub




#End Region

#Region "Bar Button Events"
    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        If dxvpSales.Validate Then

            If lblSalesID.Text = String.Empty Then
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
                
                'If UserType = "OWNER" Then
                '    If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                '        Me.UpdateRecords()
                '        Me.PopulateStockItemsGridLookup()
                '    End If

                'ElseIf UserType = "USER" Then

                '    If deSalesDate.EditValue = CWBApplication.GetServerDateTime Then
                '        If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                '            Me.UpdateRecords()
                '            Me.PopulateStockItemsGridLookup()
                '        End If
                '    Else
                '        MessageOK("Can not Update", "You don't have permission", "Click OK to continue")

                '    End If


                'Else
                '    MessageOK("Can not Update", "You don't have permission", "Click OK to continue")
                'End If





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
            With gvSalesHistory
                .ClearColumnsFilter()
                .ClearGrouping()
                .ClearSelection()
                .ClearSorting()
            End With
        ElseIf xTab1.SelectedTabPageIndex = 2 Then
            With gvSalesItemHistory
                .ClearColumnsFilter()
                .ClearGrouping()
                .ClearSelection()
                .ClearSorting()
            End With
        End If

    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick
       
        If xTab1.SelectedTabPageIndex = 1 Then
            Me.DisplayRecord(Me.gvSalesHistory.GetFocusedRowCellValue(GridColumn41))
        ElseIf xTab1.SelectedTabPageIndex = 2 Then
            Me.DisplayRecord(Me.gvSalesHistory.GetFocusedRowCellValue(GridColumn37))
        End If


    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick

        Select Case xTab1.SelectedTabPageIndex
            Case 0
                If Not Me.lblSalesID.Text = String.Empty Then

                    Me.ShowPrintPreview(Convert.ToInt64(Me.lblSalesID.Text))
                End If
            Case 1
                If gvSalesHistory.RowCount > 0 Then

                    PrintPreview(gcSalesHistory, "Sales Report")
                Else
                    Exit Sub
                End If

            Case 2

                If gvSalesItemHistory.RowCount > 0 Then

                    PrintPreview(gcSalesItemHistory, "Sales Items Report")
                Else
                    Exit Sub
                End If


        End Select


    End Sub

#End Region

#Region "Clear Form Data"
    Public Sub ClearFormData()

        lblSalesID.Text = String.Empty
        teReferenceNo.Text = String.Empty
        lblSystemNo.Text = String.Empty
        seTaxAmount.Text = "0"
        seDiscount.Text = "0"
        sbCalculate.Text = "Calculate"
        seGrandTotal.EditValue = 0
        sePercentage.Text = "0"
        lupCustomer.EditValue = DBNull.Value
        leMessages.EditValue = Nothing
        dxvpSales.RemoveControlError(lupCustomer)
        teReferenceNo.Text = String.Empty
        memNote.Text = String.Empty
        Me.PopulateDescriptionGrid()
        Me.PopulateCollectionsGrid()
        lupCustomer.Focus()

    End Sub
#End Region

#Region "Simple Button Events"
    Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCalculate.Click

        Try
            Dim a As Decimal

            GridColumn5.SummaryItem.DisplayFormat = ""
            a = Val(GridColumn5.SummaryText)
            GridColumn5.SummaryItem.DisplayFormat = "Total : {0:n2}"


            sbCalculate.Text = a + Val(seTaxAmount.EditValue) - Val(seDiscount.EditValue)
            a = 0

            gvCollections.Focus()
            gvCollections.AddNewRow()
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Populate Customer Lookup"
    Public Sub PopulateCustomerLookup()

        Try
            With lupCustomer
                .Properties.DataSource = CWBCustomers.GetAllCustomers().Tables(0)
                .Properties.DisplayMember = "CustomerName"
                .Properties.ValueMember = "CustomerID"
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
            With gcSalesDescription
                CWBSales.SalesID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
                .DataSource = CWBSales.GetSalesDescriptionByID.Tables(0)

            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Collections Grid"
    Private Sub PopulateCollectionsGrid()
        Try
            CWBSales.SalesID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
            CWBCollections.SystemID = CWBSales.SalesID
            CWBCollections.TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.SALES
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
                gvSalesDescription.SetFocusedRowCellValue(colStockID, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolStockID).ToString())
                gvSalesDescription.SetFocusedRowCellValue(colDescription, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolDescription).ToString())
                gvSalesDescription.SetFocusedRowCellValue(colUnitPrice, gridLookUpEdit.Properties.View.GetFocusedRowCellValue(gcolPurchasePrice).ToString())

            End If

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Grid Events"

    Private Sub gvSalesDescription_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvSalesDescription.CellValueChanged

        Try
            Select Case e.Column.Name

                Case "colQuantity", "colUnitPrice", "colDiscountAmt"
                    Dim a, b, c As Decimal

                    a = IIf(Not IsDBNull(gvSalesDescription.GetFocusedRowCellValue(colUnitPrice)), gvSalesDescription.GetFocusedRowCellValue(colUnitPrice), 0)
                    b = IIf(Not IsDBNull(gvSalesDescription.GetFocusedRowCellValue(colQuantity)), gvSalesDescription.GetFocusedRowCellValue(colQuantity), 0)
                    c = IIf(Not IsDBNull(gvSalesDescription.GetFocusedRowCellValue(colDiscountAmt)), gvSalesDescription.GetFocusedRowCellValue(colDiscountAmt), 0)
                    gvSalesDescription.SetFocusedRowCellValue(colValue, ((a * b) - c))

                    a = 0
                    b = 0
                    c = 0

            End Select

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub


    Private Sub gcSalessDescription_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gvSalesDescription.KeyDown
        If e.KeyCode = Keys.Delete Then
            gvSalesDescription.DeleteRow(gvSalesDescription.FocusedRowHandle)
        End If
    End Sub

    Private Sub gcCollections_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles gcCollections.KeyDown, gvCollections.KeyDown
        If e.KeyCode = Keys.Delete Then
            gvCollections.DeleteRow(gvCollections.FocusedRowHandle)
        End If
    End Sub

    Private Sub gvSalesHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvSalesHistory.DoubleClick
        Me.DisplayRecord(Me.gvSalesHistory.GetFocusedRowCellValue(GridColumn41))
    End Sub

    Private Sub gvSalesDescription_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles gvSalesDescription.FocusedRowChanged
        Me.CalculateBalance()
    End Sub

    Private Sub gvSalesDescription_RowUpdated(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles gvSalesDescription.RowUpdated
        Me.CalculateBalance()
    End Sub

    Private Sub gvCollections_CellValueChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles gvCollections.CellValueChanged
        Try

            Select Case e.Column.VisibleIndex
                Case 0
                    Dim a, b As Decimal

                    colValue.SummaryItem.DisplayFormat = ""
                    a = Val(colValue.SummaryText)
                    colValue.SummaryItem.DisplayFormat = "Total : {0:n2}"

                    GridColumn27.SummaryItem.DisplayFormat = ""
                    b = Val(GridColumn27.SummaryText)
                    GridColumn27.SummaryItem.DisplayFormat = "{0:n2}"

                    gvCollections.SetFocusedRowCellValue(GridColumn25, Date.Today)
                    gvCollections.SetFocusedRowCellValue(GridColumn27, Val(a + Val(seTaxAmount.EditValue) - Val(seDiscount.EditValue) - b))


            End Select
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Sales History"
    Private Sub PopulateSalesHistory()

        Try


            CWBSales.FromDate = Me.deFromDate.EditValue
            CWBSales.ToDate = Me.deToDate.EditValue
            gcSalesHistory.DataSource = CWBSales.GetSalesByDates().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never


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
                Me.PopulateSalesHistory()

        End Select
    End Sub
#End Region

#Region "Dispay Record"
    Public Sub DisplayRecord(ByVal id As Long)

        Try


            With CWBSales
                .SalesID = id
                .GetSalesByID()
                lblSalesID.Text = .SalesID
                lblSystemNo.Text = "System No - " + .SalesNo.ToString
                lupCustomer.EditValue = .CustomerID
                deSalesDate.EditValue = .SalesDate
                teReferenceNo.Text = .ReferenceNo

                sePercentage.EditValue = .TaxPercent
                leMessages.EditValue = .MessageID
                sePercentage.Text = .TaxPercent
                memNote.Text = .Note
                seTaxAmount.Text = .TaxAmount
                seDiscount.Text = .Discount
                Me.PopulateDescriptionGrid()
                Me.PopulateCollectionsGrid()
            End With
            xTab1.SelectedTabPageIndex = 0


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


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


            gvSalesDescription.PostEditor()
            gvCollections.PostEditor()

            gvSalesDescription.MoveLast()
            gvCollections.MoveLast()


            With CWBSales
                .SalesID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
                .CustomerID = lupCustomer.EditValue

                .SalesDate = deSalesDate.EditValue

                .ReferenceNo = teReferenceNo.Text.Trim
                .Note = memNote.Text.Trim

                colValue.SummaryItem.DisplayFormat = ""
                .Total = gvSalesDescription.Columns("Value").SummaryText
                .TaxPercent = sePercentage.Text
                .TaxAmount = seTaxAmount.EditValue
                .Discount = seDiscount.EditValue
                .GrandTotal = seGrandTotal.EditValue


                .MessageID = leMessages.EditValue


                If seGrandTotal.EditValue = GridColumn27.SummaryText Then
                    .Paid = True
                Else
                    .Paid = False
                End If



                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertSales(_DB, _Transaction)


                For i As Integer = 0 To Me.gvSalesDescription.RowCount
                    If Not gvSalesDescription.GetRowCellDisplayText(i, gvSalesDescription.Columns(0)) = "" Then
                        .SalesID = .CurrentSalesID
                        .StockID = Me.gvSalesDescription.GetRowCellDisplayText(i, colStockID)
                        .UnitPrice = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colUnitPrice))
                        .PurchasingPrice = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colPruchasePrice))
                        .Quantity = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colQuantity))
                        .Discount = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colDiscountAmt))
                        .BagWeight = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colBagWeight))
                        .NoOfBags = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colNoOfBas))
                        .Value = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colValue))
                        .InsertSalesDescription(_DB, _Transaction)

                        'Update Main Stock
                        .StockID = Me.gvSalesDescription.GetRowCellDisplayText(i, colStockID)
                        .StockBalance = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colQuantity))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next



                With CWBCollections
                    For i As Integer = 0 To Me.gvCollections.RowCount
                        If Not gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(0)) = "" Then
                            .SystemID = CWBSales.CurrentSalesID
                            .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.SALES

                            Select Case Me.gvCollections.GetRowCellDisplayText(i, GridColumn22)

                                Case "CASH"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                                Case "CHECK"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                                Case "CR CARD"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD

                            End Select

                            .Date = Date.Parse(Me.gvCollections.GetRowCellDisplayText(i, GridColumn25))
                            .Reference = Me.gvCollections.GetRowCellDisplayText(i, GridColumn26)

                            .Amount = FormatNumber(Me.gvCollections.GetRowCellDisplayText(i, GridColumn27), 2, , , )
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

                'ShowPrintPreview(CWBSales.CurrentSalesID)

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


            gvSalesDescription.PostEditor()
            gvCollections.PostEditor()

            gvSalesDescription.MoveLast()
            gvCollections.MoveLast()



            With CWBSales
                .SalesID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
                .CustomerID = lupCustomer.EditValue
                .SalesDate = deSalesDate.Text
                .ReferenceNo = teReferenceNo.Text.Trim
                .TaxPercent = sePercentage.Text
                .Note = memNote.Text.Trim

                colValue.SummaryItem.DisplayFormat = ""
                .Total = gvSalesDescription.Columns("Value").SummaryText


                .TaxAmount = seTaxAmount.EditValue
                .Discount = seDiscount.EditValue
                .GrandTotal = seGrandTotal.EditValue

                .MessageID = leMessages.EditValue

                If seGrandTotal.EditValue = GridColumn27.SummaryText Then
                    .Paid = True
                Else
                    .Paid = False
                End If

                .CreatedBy = UserID
                .UpdatedBy = UserID
                .InsertSales(_DB, _Transaction)

                .AddToStock(_DB, _Transaction)
                .SalesDescriptionDelete(_DB, _Transaction)


                For i As Integer = 0 To Me.gvSalesDescription.RowCount
                    If Not gvSalesDescription.GetRowCellDisplayText(i, gvSalesDescription.Columns(0)) = "" Then

                        .StockID = Me.gvSalesDescription.GetRowCellDisplayText(i, colStockID)
                        .UnitPrice = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colUnitPrice))
                        .PurchasingPrice = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colPruchasePrice))
                        .Quantity = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colQuantity))
                        .Discount = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colDiscountAmt))

                        .BagWeight = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colBagWeight))
                        .NoOfBags = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colNoOfBas))

                        .Value = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colValue))
                        .InsertSalesDescription(_DB, _Transaction)

                        'Update Main Stock
                        .StockID = Me.gvSalesDescription.GetRowCellDisplayText(i, colStockID)
                        .StockBalance = Val(Me.gvSalesDescription.GetRowCellDisplayText(i, colQuantity))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next



                With CWBCollections
                    .SystemID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
                    .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.SALES
                    .CollectionDelete(_DB, _Transaction)


                    'Add new Records to Collection Table

                    For i As Integer = 0 To Me.gvCollections.RowCount
                        If Not gvCollections.GetRowCellDisplayText(i, gvCollections.Columns(0)) = "" Then
                            .SystemID = Convert.ToInt64(IIf(lblSalesID.Text = String.Empty, 0, lblSalesID.Text))
                            .TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.SALES

                            Select Case Me.gvCollections.GetRowCellDisplayText(i, GridColumn22)

                                Case "CASH"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CASH
                                Case "CHECK"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CHECK
                                Case "CR CARD"
                                    .PaymentTypeID = iStockCommon.iStockEnums.EnumPaymentTypes.CCARD

                            End Select

                            .Date = Date.Parse(Me.gvCollections.GetRowCellDisplayText(i, GridColumn25))
                            .Reference = Me.gvCollections.GetRowCellDisplayText(i, GridColumn26)
                            .Amount = FormatNumber(Me.gvCollections.GetRowCellDisplayText(i, GridColumn27), 2, , , )
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
    Private Sub ShowPrintPreview(ByVal SalesId As Int64)
        Try
            Dim _frmPrintPreview As New frmPrint
            Dim _xrSales As New xrSales





            With CWBSales
                .SalesID = SalesId
                .GetSalesByID()

                CWBCustomers.CustomerID = Me.lupCustomer.EditValue
                CWBCustomers.GetCustomerByID()




                _xrSales.xrlCustomers.Text = "[" + CWBCustomers.CustomerNo.ToString + "]  " + CWBCustomers.Salutation + " " + lupCustomer.Text

                _xrSales.xrlAddress1.Text = CWBCustomers.AddressLine1
                _xrSales.xrlAddress2.Text = CWBCustomers.AddressLine2
                _xrSales.xrlAddress3.Text = CWBCustomers.AddressLine3



                _xrSales.xrlSalesNo.Text = CWBSales.SalesNo
                _xrSales.xrlDate.Text = Format(IIf(Not IsDBNull(.SalesDate), .SalesDate, String.Empty), "dd-MMM-yy")
                _xrSales.xrlVehicleNo.Text = IIf(Not IsDBNull(.ReferenceNo), .ReferenceNo, String.Empty)



                _xrSales.xrlKM1.Text = "Km"
                _xrSales.xrlKm2.Text = "Km"


                Dim dtStock As New DataTable
                Dim dtCollection As New DataTable

                dtStock = CWBSales.GetSalesDescriptionByID.Tables(0)

                If dtStock.Rows.Count > 0 Then

                    For i As Integer = 0 To dtStock.Rows.Count - 1
                        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                        tr.Height = 10

                        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

                        cell1.Size = New Size(116, 10)
                        cell2.Size = New Size(235, 10)
                        cell3.Size = New Size(107, 10)
                        cell4.Size = New Size(141, 10)
                        'cell5.Size = New Size(125, 25)
                        cell6.Size = New Size(131, 10)


                        If IsDBNull(dtStock.Rows(i).Item("StockCode")) Then
                            cell1.Text = "N/A"
                        Else
                            cell1.Text = CStr((dtStock.Rows(i).Item("StockCode")))
                        End If

                        If IsDBNull(dtStock.Rows(i).Item("Description")) Then
                            cell2.Text = "N/A"
                        Else
                            cell2.Text = dtStock.Rows(i).Item("Description")
                        End If


                        If IsDBNull(dtStock.Rows(i).Item("UnitPrice")) Then
                            cell3.Text = "0.00"
                        Else
                            cell3.Text = CStr(FormatNumber(dtStock.Rows(i).Item("UnitPrice"), 2, , , ))
                        End If



                        If IsDBNull(dtStock.Rows(i).Item("Quantity")) Then
                            cell4.Text = "0.00"
                        Else
                            cell4.Text = CStr(dtStock.Rows(i).Item("Quantity"))
                        End If


                        'If IsDBNull(dtStock.Rows(i).Item("Discount")) Then
                        '    cell5.Text = "0.00"
                        'Else
                        '    cell5.Text = CStr(FormatNumber(dtStock.Rows(i).Item("Discount"), 2, , , ))
                        'End If



                        If IsDBNull(dtStock.Rows(i).Item("Value")) Then
                            cell6.Text = "0.00"
                        Else
                            cell6.Text = CStr(FormatNumber(dtStock.Rows(i).Item("Value"), 2, , , ))
                        End If


                        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
                        'cell5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                        cell6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



                        tr.Cells.Add(cell1)
                        tr.Cells.Add(cell2)
                        tr.Cells.Add(cell3)
                        tr.Cells.Add(cell4)
                        'tr.Cells.Add(cell5)
                        tr.Cells.Add(cell6)

                        If i = 0 Then
                            _xrSales.xrtStock.Rows.FirstRow.Cells(0).Text = cell1.Text
                            _xrSales.xrtStock.Rows.FirstRow.Cells(1).Text = cell2.Text
                            _xrSales.xrtStock.Rows.FirstRow.Cells(2).Text = cell3.Text
                            _xrSales.xrtStock.Rows.FirstRow.Cells(3).Text = cell4.Text
                            '_xrSales.xrtStock.Rows.FirstRow.Cells(4).Text = cell5.Text
                            _xrSales.xrtStock.Rows.FirstRow.Cells(4).Text = cell6.Text

                        Else
                            _xrSales.xrtStock.Rows.Add(tr)
                        End If

                    Next


                End If



                CWBCollections.SystemID = CWBSales.SalesID
                CWBCollections.TransactionTypeID = iStockCommon.iStockEnums.EnumTransactionTypes.SALES
                dtCollection = CWBCollections.CollectionGetByID().Tables(0)


                'If dtCollection.Rows.Count > 0 Then

                '    For i As Integer = 0 To dtCollection.Rows.Count - 1
                '        Dim tr As New DevExpress.XtraReports.UI.XRTableRow
                '        Dim cell1, cell2, cell3, cell4, cell5, cell6 As New DevExpress.XtraReports.UI.XRTableCell

                '        cell1.Size = New Size(92, 25)
                '        cell2.Size = New Size(108, 25)
                '        cell3.Size = New Size(167, 25)
                '        cell4.Size = New Size(133, 25)



                '        If IsDBNull(dtCollection.Rows(i).Item("Description")) Then
                '            cell1.Text = "N/A"
                '        Else
                '            cell1.Text = CStr((dtCollection.Rows(i).Item("Description")))
                '        End If

                '        If IsDBNull(dtCollection.Rows(i).Item("Date")) Then
                '            cell2.Text = "N/A"
                '        Else
                '            cell2.Text = Format(dtCollection.Rows(i).Item("Date"), "dd-MMM-yy")
                '        End If



                '        If IsDBNull(dtCollection.Rows(i).Item("Reference")) Then
                '            cell3.Text = "0.00"
                '        Else
                '            cell3.Text = CStr(dtCollection.Rows(i).Item("Reference"))
                '        End If



                '        If IsDBNull(dtCollection.Rows(i).Item("Amount")) Then
                '            cell4.Text = "0.00"
                '        Else
                '            cell4.Text = CStr(FormatNumber(dtCollection.Rows(i).Item("Amount"), 2, , , ))
                '        End If





                '        cell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                '        cell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                '        cell3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                '        cell4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight



                '        tr.Cells.Add(cell1)
                '        tr.Cells.Add(cell2)
                '        tr.Cells.Add(cell3)
                '        tr.Cells.Add(cell4)


                '        'If i = 0 Then
                '        '    _xrSales.xrtCollections.Rows.FirstRow.Cells(0).Text = cell1.Text
                '        '    _xrSales.xrtCollections.Rows.FirstRow.Cells(1).Text = cell2.Text
                '        '    _xrSales.xrtCollections.Rows.FirstRow.Cells(2).Text = cell3.Text
                '        '    _xrSales.xrtCollections.Rows.FirstRow.Cells(3).Text = cell4.Text


                '        'Else
                '        '    _xrSales.xrtCollections.Rows.Add(tr)
                '        'End If



                '    Next
                'End If

                '_xrSales.xrlTotal.Text = FormatNumber(IIf(Not IsDBNull(.Total), .Total, 0), 2, , , )
                '_xrSales.xrlTax.Text = FormatNumber(IIf(Not IsDBNull(.TaxAmount), .TaxAmount, 0), 2, , , )
                '_xrSales.xrlDiscount.Text = FormatNumber(IIf(Not IsDBNull(.Discount), .Discount, 0), 2, , , )

                Dim a, b, c, d As Decimal
                a = .Total
                'b = .TaxAmount
                c = .Discount

                GridColumn27.SummaryItem.DisplayFormat = ""
                b = gvCollections.Columns("Amount").SummaryText
                GridColumn27.SummaryItem.DisplayFormat = "{0:n2}"


                d = a - (b + c)

                _xrSales.xrlTotal.Text = FormatNumber(a, 2, , , )
                _xrSales.xrlPaid.Text = FormatNumber(b, 2, , , )

                _xrSales.xrlDue.Text = FormatNumber(d, 2, , , )





                If leMessages.Text = "NONE" Then
                    _xrSales.xrlMessage.Text = String.Empty
                Else
                    _xrSales.xrlMessage.Text = leMessages.Text
                End If

                If CWBSales.TaxPercent = 0 Then
                    _xrSales.xrlDiscount.Text = FormatNumber(CWBSales.Discount, 2, , , )

                Else
                    _xrSales.xrlDiscount.Text = "(" + FormatNumber(CWBSales.TaxPercent, 2, , , ) + "%)  " + FormatNumber(CWBSales.Discount, 2, , , )

                End If


            End With




            _frmPrintPreview.PrintControl1.PrintingSystem = _xrSales.PrintingSystem
            _xrSales.CreateDocument()
            _frmPrintPreview.MdiParent = frmMain
            _frmPrintPreview.Show()
            _frmPrintPreview.BringToFront()

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Save Message"
    Private Sub SaveMessage()
        Try
            With CWBMessages
                .MessageText = Me.leMessages.Text
                .InsertMessage()

            End With
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Messages"
    Public Sub PopulateMessageLookup()

        Try
            With leMessages
                .Properties.DataSource = CWBMessages.GetAllMessage.Tables(0)
                .Properties.DisplayMember = "Message"
                .Properties.ValueMember = "MessageID"

            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Delete Message"
    Private Sub DeleteMessage()
        Try
            With CWBMessages
                .MessageText = Me.leMessages.Text
                .DeleteMessage()
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

#Region "Button Events"
    Private Sub sbPreviousBills_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            CWBSales.ReferenceNo = Me.teReferenceNo.Text.Trim
            frmPreviousBills.lblDescription.Text = "Previous Bills for " + Me.teReferenceNo.Text.Trim


            Dim dset As New DataSet

            dset = CWBSales.GetSalesByReferenceNo



            Dim keyColumn As DataColumn = dset.Tables(0).Columns("SalesID")
            Dim foreignKeyColumn As DataColumn = dset.Tables(1).Columns("SalesID")
            dset.Relations.Add("Bill Description", keyColumn, foreignKeyColumn)
            frmPreviousBills.gcPreviousBills.LevelTree.Nodes.Add("Bill Description", frmPreviousBills.gvDescription)
            frmPreviousBills.gcPreviousBills.ForceInitialize()
            frmPreviousBills.gcPreviousBills.DataSource = dset.Tables(0)

            frmPreviousBills.ShowDialog()




        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Button Events"
    Private Sub sbProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess.Click
        Try
            If dxvpHistoryData.Validate Then
                PopulateSalesHistory()
            End If


        Catch ex As Exception

            MessageError(ex.ToString)
        End Try

    End Sub
#End Region

#Region "Lookup  Event"


    Private Sub leMessages_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles leMessages.ButtonClick
        Select Case e.Button.Index
            Case 1
                If Not Me.leMessages.Text = String.Empty Then
                    Me.SaveMessage()
                    Me.PopulateMessageLookup()
                End If

            Case 2
                If Not Me.leMessages.Text = String.Empty Then
                    Dim frm As New frmDeleteYesNo
                    frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
                    frm.lblDescription.ForeColor = Color.Red
                    frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
                    frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
                    frm.Text = CWB_DELETE_CONFIRMATION_TITLE


                    If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                        Me.DeleteMessage()
                        Me.PopulateMessageLookup()
                    End If
                End If



        End Select
    End Sub
#End Region

#Region "Sping Edit Evets"

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

    Private Sub lupCustomer_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lupCustomer.ButtonClick
        Try

            If e.Button.Index = 1 Then
                frmCustomers.StartPosition = FormStartPosition.CenterParent
                frmCustomers.ShowDialog()


            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub sbProcess2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess2.Click
        Try

            PopulateSalesItemHistory()

        Catch ex As Exception

            MessageError(ex.ToString)
        End Try
    End Sub

    Private Sub PopulateSalesItemHistory()

        Try

            CWBSales.FromDate = Me.deFrom2.EditValue
            CWBSales.ToDate = Me.deTo2.EditValue
            gcSalesItemHistory.DataSource = CWBSales.GetSalesItemsByDates().Tables(0)

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try

    End Sub

    Private Sub gvSalesItemHistory_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gvSalesItemHistory.DoubleClick
        Me.DisplayRecord(Me.gvSalesItemHistory.GetFocusedRowCellValue(GridColumn37))
    End Sub
End Class