<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPurchases
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim CompareAgainstControlValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule = New DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim ConditionValidatonRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidatonRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidatonRule()
        Me.deFromDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.smProcess = New DevExpress.XtraEditors.SimpleButton()
        Me.deToDate = New DevExpress.XtraEditors.DateEdit()
        Me.gcPurchaseHistory = New DevExpress.XtraGrid.GridControl()
        Me.gvPurchaseHistory = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.RepositoryItemComboBox2 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemCalcEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDisplaySelected = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemComboBox1 = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.xTab1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.sePercentage = New DevExpress.XtraEditors.SpinEdit()
        Me.lblSystemNo = New DevExpress.XtraEditors.LabelControl()
        Me.seDiscount = New DevExpress.XtraEditors.SpinEdit()
        Me.seGrandTotal = New DevExpress.XtraEditors.SpinEdit()
        Me.lblPurchaseID = New DevExpress.XtraEditors.LabelControl()
        Me.seTaxAmount = New DevExpress.XtraEditors.SpinEdit()
        Me.gcCollections = New DevExpress.XtraGrid.GridControl()
        Me.gvCollections = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcPurchasesDescription = New DevExpress.XtraGrid.GridControl()
        Me.gvPurchasesDescription = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.colStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStockCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.glupStockItems = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcolStockID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolStockCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolCatagory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolPurchasePrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcolReorderLevel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colBagWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colNoOfBas = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.risiQuantity = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colUnitPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.risiUnitPrice = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.colDiscount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colValue = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemCalcEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.RepositoryItemLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.meNote = New DevExpress.XtraEditors.MemoExEdit()
        Me.teReferenceNo = New DevExpress.XtraEditors.TextEdit()
        Me.dePurchaseDate = New DevExpress.XtraEditors.DateEdit()
        Me.lupSupplier = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.sbProcess2 = New DevExpress.XtraEditors.SimpleButton()
        Me.deTo2 = New DevExpress.XtraEditors.DateEdit()
        Me.deFrom2 = New DevExpress.XtraEditors.DateEdit()
        Me.gcPurchaseHistoryItems = New DevExpress.XtraGrid.GridControl()
        Me.gvPurchaseHistoryItems = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.dxvpPurchase = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.dxvpHistoryData = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.deFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFromDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.deToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deToDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcPurchaseHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPurchaseHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xTab1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.sePercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seDiscount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seGrandTotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seTaxAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcPurchasesDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPurchasesDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.glupStockItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.risiQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.risiUnitPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teReferenceNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dePurchaseDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dePurchaseDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lupSupplier.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.deTo2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deTo2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFrom2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFrom2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcPurchaseHistoryItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPurchaseHistoryItems, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpHistoryData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deFromDate
        '
        Me.deFromDate.EditValue = Nothing
        Me.deFromDate.EnterMoveNextControl = True
        Me.deFromDate.Location = New System.Drawing.Point(52, 43)
        Me.deFromDate.Name = "deFromDate"
        Me.deFromDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deFromDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFromDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deFromDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deFromDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deFromDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deFromDate.Size = New System.Drawing.Size(108, 20)
        Me.deFromDate.StyleController = Me.LayoutControl2
        Me.deFromDate.TabIndex = 0
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.smProcess)
        Me.LayoutControl2.Controls.Add(Me.deToDate)
        Me.LayoutControl2.Controls.Add(Me.deFromDate)
        Me.LayoutControl2.Controls.Add(Me.gcPurchaseHistory)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup4
        Me.LayoutControl2.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'smProcess
        '
        Me.smProcess.Location = New System.Drawing.Point(305, 43)
        Me.smProcess.Name = "smProcess"
        Me.smProcess.Size = New System.Drawing.Size(84, 29)
        Me.smProcess.StyleController = Me.LayoutControl2
        Me.smProcess.TabIndex = 2
        Me.smProcess.Text = "Process"
        '
        'deToDate
        '
        Me.deToDate.EditValue = Nothing
        Me.deToDate.EnterMoveNextControl = True
        Me.deToDate.Location = New System.Drawing.Point(192, 43)
        Me.deToDate.Name = "deToDate"
        Me.deToDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deToDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deToDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deToDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deToDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deToDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deToDate.Size = New System.Drawing.Size(109, 20)
        Me.deToDate.StyleController = Me.LayoutControl2
        Me.deToDate.TabIndex = 1
        CompareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.GreaterOrEqual
        CompareAgainstControlValidationRule1.Control = Me.deFromDate
        CompareAgainstControlValidationRule1.ErrorText = "Value must be a recent Date"
        Me.dxvpHistoryData.SetValidationRule(Me.deToDate, CompareAgainstControlValidationRule1)
        '
        'gcPurchaseHistory
        '
        Me.gcPurchaseHistory.Location = New System.Drawing.Point(12, 88)
        Me.gcPurchaseHistory.MainView = Me.gvPurchaseHistory
        Me.gcPurchaseHistory.Name = "gcPurchaseHistory"
        Me.gcPurchaseHistory.Size = New System.Drawing.Size(829, 398)
        Me.gcPurchaseHistory.TabIndex = 0
        Me.gcPurchaseHistory.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPurchaseHistory})
        '
        'gvPurchaseHistory
        '
        Me.gvPurchaseHistory.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn18, Me.GridColumn30, Me.GridColumn11, Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn23, Me.GridColumn22, Me.GridColumn25, Me.GridColumn34, Me.GridColumn31, Me.GridColumn32, Me.GridColumn33, Me.GridColumn24, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29})
        Me.gvPurchaseHistory.GridControl = Me.gcPurchaseHistory
        Me.gvPurchaseHistory.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "SupplierName", Me.GridColumn19, ""), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", Me.GridColumn23, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tax", Me.GridColumn22, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discount", Me.GridColumn25, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", Me.GridColumn31, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountPaid", Me.GridColumn32, "{0:n2}"), New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", Me.GridColumn33, "{0:n2}")})
        Me.gvPurchaseHistory.Name = "gvPurchaseHistory"
        Me.gvPurchaseHistory.OptionsBehavior.Editable = False
        Me.gvPurchaseHistory.OptionsView.ColumnAutoWidth = False
        Me.gvPurchaseHistory.OptionsView.EnableAppearanceOddRow = True
        Me.gvPurchaseHistory.OptionsView.ShowAutoFilterRow = True
        Me.gvPurchaseHistory.OptionsView.ShowFooter = True
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "PurchaseID"
        Me.GridColumn18.FieldName = "PurchaseID"
        Me.GridColumn18.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn18.Name = "GridColumn18"
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Purchase No"
        Me.GridColumn30.FieldName = "PurchaseNo"
        Me.GridColumn30.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 0
        Me.GridColumn30.Width = 120
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Supplier No"
        Me.GridColumn11.FieldName = "SupplierNo"
        Me.GridColumn11.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 120
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Supplier Name"
        Me.GridColumn19.FieldName = "SupplierName"
        Me.GridColumn19.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 2
        Me.GridColumn19.Width = 150
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Reference No"
        Me.GridColumn20.FieldName = "ReferenceNo"
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 3
        Me.GridColumn20.Width = 120
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Date"
        Me.GridColumn21.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn21.FieldName = "PurchaseDate"
        Me.GridColumn21.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 4
        Me.GridColumn21.Width = 120
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Total"
        Me.GridColumn23.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "Total"
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n2}")})
        Me.GridColumn23.Width = 120
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Tax"
        Me.GridColumn22.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "Tax"
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tax", "{0:n2}")})
        Me.GridColumn22.Width = 120
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Discount"
        Me.GridColumn25.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn25.FieldName = "Discount"
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discount", "{0:n2}")})
        Me.GridColumn25.Width = 120
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "Discount (%)"
        Me.GridColumn34.DisplayFormat.FormatString = "{0:n2}%"
        Me.GridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn34.FieldName = "Percentage"
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.Visible = True
        Me.GridColumn34.VisibleIndex = 5
        Me.GridColumn34.Width = 120
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Grand Total"
        Me.GridColumn31.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn31.FieldName = "GrandTotal"
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "GrandTotal", "{0:n2}")})
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 6
        Me.GridColumn31.Width = 120
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "Amount Paid"
        Me.GridColumn32.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn32.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn32.FieldName = "AmountPaid"
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountPaid", "{0:n2}")})
        Me.GridColumn32.Visible = True
        Me.GridColumn32.VisibleIndex = 7
        Me.GridColumn32.Width = 120
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Due Balance"
        Me.GridColumn33.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn33.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn33.FieldName = "Balance"
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Balance", "{0:n2}")})
        Me.GridColumn33.Visible = True
        Me.GridColumn33.VisibleIndex = 8
        Me.GridColumn33.Width = 120
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Paid"
        Me.GridColumn24.FieldName = "Paid"
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 9
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Created By"
        Me.GridColumn26.FieldName = "CreatedBy"
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 10
        Me.GridColumn26.Width = 120
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Created Date"
        Me.GridColumn27.DisplayFormat.FormatString = "dd-MMM-yy h:mm tt"
        Me.GridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn27.FieldName = "CreatedDate"
        Me.GridColumn27.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 11
        Me.GridColumn27.Width = 120
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Updated By"
        Me.GridColumn28.FieldName = "UpdatedBy"
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 12
        Me.GridColumn28.Width = 120
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Update Date"
        Me.GridColumn29.DisplayFormat.FormatString = "dd-MMM-yy h:mm tt"
        Me.GridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn29.FieldName = "UpdatedDate"
        Me.GridColumn29.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 13
        Me.GridColumn29.Width = 120
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.LayoutControlGroup5})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControlGroup4.Text = "LayoutControlGroup4"
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.gcPurchaseHistory
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 76)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(833, 402)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(393, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(440, 76)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "Select Date Range to Display History Purchase Bills"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.LayoutControlItem13, Me.LayoutControlItem14})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(393, 76)
        Me.LayoutControlGroup5.Text = "Select Date Range to Display History Purchase Bills"
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.deFromDate
        Me.LayoutControlItem10.CustomizationFormText = "From"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(140, 33)
        Me.LayoutControlItem10.Text = "From"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(24, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.deToDate
        Me.LayoutControlItem13.CustomizationFormText = "To"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(140, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(141, 33)
        Me.LayoutControlItem13.Text = "To"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(24, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.smProcess
        Me.LayoutControlItem14.CustomizationFormText = "LayoutControlItem14"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(281, 0)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(0, 33)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(61, 33)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(88, 33)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "LayoutControlItem14"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextToControlDistance = 0
        Me.LayoutControlItem14.TextVisible = False
        '
        'RepositoryItemComboBox2
        '
        Me.RepositoryItemComboBox2.AutoHeight = False
        Me.RepositoryItemComboBox2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox2.Items.AddRange(New Object() {"CASH", "CHECK", "CR CARD"})
        Me.RepositoryItemComboBox2.Name = "RepositoryItemComboBox2"
        Me.RepositoryItemComboBox2.ShowPopupShadow = False
        Me.RepositoryItemComboBox2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemDateEdit1.Mask.EditMask = "dd-MMM-yy"
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        Me.RepositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'RepositoryItemCalcEdit2
        '
        Me.RepositoryItemCalcEdit2.AutoHeight = False
        Me.RepositoryItemCalcEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit2.Name = "RepositoryItemCalcEdit2"
        Me.RepositoryItemCalcEdit2.ShowPopupShadow = False
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbSave, Me.bbNew, Me.bbClose, Me.bbRefresh, Me.bbDisplaySelected, Me.bbPrint})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 11
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemComboBox1})
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDisplaySelected), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'bbSave
        '
        Me.bbSave.Caption = "BarButtonItem1"
        Me.bbSave.Id = 0
        Me.bbSave.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S))
        Me.bbSave.Name = "bbSave"
        '
        'bbNew
        '
        Me.bbNew.Caption = "BarButtonItem2"
        Me.bbNew.Id = 1
        Me.bbNew.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N))
        Me.bbNew.Name = "bbNew"
        '
        'bbDisplaySelected
        '
        Me.bbDisplaySelected.Caption = "BarButtonItem5"
        Me.bbDisplaySelected.Id = 9
        Me.bbDisplaySelected.Name = "bbDisplaySelected"
        '
        'bbRefresh
        '
        Me.bbRefresh.Caption = "BarButtonItem1"
        Me.bbRefresh.Id = 8
        Me.bbRefresh.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R))
        Me.bbRefresh.Name = "bbRefresh"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "BarButtonItem1"
        Me.bbPrint.Id = 10
        Me.bbPrint.Name = "bbPrint"
        '
        'bbClose
        '
        Me.bbClose.Caption = "BarButtonItem2"
        Me.bbClose.Id = 3
        Me.bbClose.ItemShortcut = New DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W))
        Me.bbClose.Name = "bbClose"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(859, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 548)
        Me.barDockControlBottom.Size = New System.Drawing.Size(859, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 526)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(859, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 526)
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemComboBox1
        '
        Me.RepositoryItemComboBox1.AutoHeight = False
        Me.RepositoryItemComboBox1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemComboBox1.Name = "RepositoryItemComboBox1"
        '
        'xTab1
        '
        Me.xTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xTab1.Location = New System.Drawing.Point(0, 22)
        Me.xTab1.Name = "xTab1"
        Me.xTab1.SelectedTabPage = Me.XtraTabPage1
        Me.xTab1.Size = New System.Drawing.Size(859, 526)
        Me.xTab1.TabIndex = 200
        Me.xTab1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(853, 498)
        Me.XtraTabPage1.Text = "New Record"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.AllowCustomizationMenu = False
        Me.LayoutControl1.Controls.Add(Me.sePercentage)
        Me.LayoutControl1.Controls.Add(Me.lblSystemNo)
        Me.LayoutControl1.Controls.Add(Me.seDiscount)
        Me.LayoutControl1.Controls.Add(Me.seGrandTotal)
        Me.LayoutControl1.Controls.Add(Me.lblPurchaseID)
        Me.LayoutControl1.Controls.Add(Me.seTaxAmount)
        Me.LayoutControl1.Controls.Add(Me.gcCollections)
        Me.LayoutControl1.Controls.Add(Me.gcPurchasesDescription)
        Me.LayoutControl1.Controls.Add(Me.meNote)
        Me.LayoutControl1.Controls.Add(Me.teReferenceNo)
        Me.LayoutControl1.Controls.Add(Me.dePurchaseDate)
        Me.LayoutControl1.Controls.Add(Me.lupSupplier)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsFocus.AllowFocusControlOnActivatedTabPage = True
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'sePercentage
        '
        Me.sePercentage.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sePercentage.EnterMoveNextControl = True
        Me.sePercentage.Location = New System.Drawing.Point(521, 375)
        Me.sePercentage.Name = "sePercentage"
        Me.sePercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "%", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, False)})
        Me.sePercentage.Properties.DisplayFormat.FormatString = "{0:n2}"
        Me.sePercentage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.sePercentage.Properties.EditFormat.FormatString = "{0:n2}"
        Me.sePercentage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.sePercentage.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.sePercentage.Size = New System.Drawing.Size(123, 20)
        Me.sePercentage.StyleController = Me.LayoutControl1
        Me.sePercentage.TabIndex = 6
        '
        'lblSystemNo
        '
        Me.lblSystemNo.Location = New System.Drawing.Point(446, 12)
        Me.lblSystemNo.Name = "lblSystemNo"
        Me.lblSystemNo.Size = New System.Drawing.Size(395, 13)
        Me.lblSystemNo.StyleController = Me.LayoutControl1
        Me.lblSystemNo.TabIndex = 139
        '
        'seDiscount
        '
        Me.seDiscount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seDiscount.EnterMoveNextControl = True
        Me.seDiscount.Location = New System.Drawing.Point(648, 375)
        Me.seDiscount.Name = "seDiscount"
        Me.seDiscount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seDiscount.Properties.DisplayFormat.FormatString = "{0:n2}"
        Me.seDiscount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDiscount.Properties.EditFormat.FormatString = "{0:n2}"
        Me.seDiscount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDiscount.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.seDiscount.Size = New System.Drawing.Size(193, 20)
        Me.seDiscount.StyleController = Me.LayoutControl1
        Me.seDiscount.TabIndex = 7
        '
        'seGrandTotal
        '
        Me.seGrandTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seGrandTotal.Location = New System.Drawing.Point(521, 399)
        Me.seGrandTotal.Name = "seGrandTotal"
        Me.seGrandTotal.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seGrandTotal.Properties.Appearance.ForeColor = System.Drawing.Color.Red
        Me.seGrandTotal.Properties.Appearance.Options.UseFont = True
        Me.seGrandTotal.Properties.Appearance.Options.UseForeColor = True
        Me.seGrandTotal.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seGrandTotal.Properties.DisplayFormat.FormatString = "{0:n2}"
        Me.seGrandTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seGrandTotal.Properties.EditFormat.FormatString = "{0:n2}"
        Me.seGrandTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seGrandTotal.Properties.ReadOnly = True
        Me.seGrandTotal.Size = New System.Drawing.Size(320, 30)
        Me.seGrandTotal.StyleController = Me.LayoutControl1
        Me.seGrandTotal.TabIndex = 8
        Me.seGrandTotal.TabStop = False
        '
        'lblPurchaseID
        '
        Me.lblPurchaseID.Location = New System.Drawing.Point(12, 12)
        Me.lblPurchaseID.Name = "lblPurchaseID"
        Me.lblPurchaseID.Size = New System.Drawing.Size(430, 13)
        Me.lblPurchaseID.StyleController = Me.LayoutControl1
        Me.lblPurchaseID.TabIndex = 138
        '
        'seTaxAmount
        '
        Me.seTaxAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seTaxAmount.EnterMoveNextControl = True
        Me.seTaxAmount.Location = New System.Drawing.Point(521, 351)
        Me.seTaxAmount.Name = "seTaxAmount"
        Me.seTaxAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seTaxAmount.Properties.DisplayFormat.FormatString = "F"
        Me.seTaxAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seTaxAmount.Properties.EditFormat.FormatString = "F"
        Me.seTaxAmount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seTaxAmount.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.seTaxAmount.Size = New System.Drawing.Size(320, 20)
        Me.seTaxAmount.StyleController = Me.LayoutControl1
        Me.seTaxAmount.TabIndex = 5
        '
        'gcCollections
        '
        Me.gcCollections.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.First.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gcCollections.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.gcCollections.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None
        Me.gcCollections.Location = New System.Drawing.Point(12, 351)
        Me.gcCollections.MainView = Me.gvCollections
        Me.gcCollections.Name = "gcCollections"
        Me.gcCollections.Size = New System.Drawing.Size(435, 135)
        Me.gcCollections.TabIndex = 9
        Me.gcCollections.UseEmbeddedNavigator = True
        Me.gcCollections.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCollections})
        '
        'gvCollections
        '
        Me.gvCollections.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16})
        Me.gvCollections.GridControl = Me.gcCollections
        Me.gvCollections.Name = "gvCollections"
        Me.gvCollections.OptionsCustomization.AllowFilter = False
        Me.gvCollections.OptionsCustomization.AllowGroup = False
        Me.gvCollections.OptionsNavigation.EnterMoveNextColumn = True
        Me.gvCollections.OptionsView.EnableAppearanceOddRow = True
        Me.gvCollections.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.gvCollections.OptionsView.ShowFooter = True
        Me.gvCollections.OptionsView.ShowGroupPanel = False
        Me.gvCollections.PaintStyleName = "Skin"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Type"
        Me.GridColumn13.ColumnEdit = Me.RepositoryItemComboBox2
        Me.GridColumn13.FieldName = "Description"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 0
        Me.GridColumn13.Width = 63
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Date"
        Me.GridColumn14.ColumnEdit = Me.RepositoryItemDateEdit1
        Me.GridColumn14.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn14.FieldName = "Date"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        Me.GridColumn14.Width = 78
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "(Ch No / Cr Card No)"
        Me.GridColumn15.ColumnEdit = Me.RepositoryItemTextEdit2
        Me.GridColumn15.DisplayFormat.FormatString = "#.00"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "Reference"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        Me.GridColumn15.Width = 135
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Amount"
        Me.GridColumn16.ColumnEdit = Me.RepositoryItemCalcEdit2
        Me.GridColumn16.DisplayFormat.FormatString = "F"
        Me.GridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn16.FieldName = "Amount"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:n2}")})
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 3
        Me.GridColumn16.Width = 129
        '
        'gcPurchasesDescription
        '
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.First.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.Last.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.Next.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.Buttons.Prev.Visible = False
        Me.gcPurchasesDescription.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.[End]
        Me.gcPurchasesDescription.Location = New System.Drawing.Point(24, 89)
        Me.gcPurchasesDescription.MainView = Me.gvPurchasesDescription
        Me.gcPurchasesDescription.Name = "gcPurchasesDescription"
        Me.gcPurchasesDescription.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.glupStockItems, Me.risiUnitPrice, Me.RepositoryItemCalcEdit1, Me.risiQuantity, Me.RepositoryItemSpinEdit1, Me.RepositoryItemLookUpEdit1, Me.RepositoryItemSpinEdit2})
        Me.gcPurchasesDescription.Size = New System.Drawing.Size(805, 246)
        Me.gcPurchasesDescription.TabIndex = 4
        Me.gcPurchasesDescription.UseEmbeddedNavigator = True
        Me.gcPurchasesDescription.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPurchasesDescription})
        '
        'gvPurchasesDescription
        '
        Me.gvPurchasesDescription.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colStockID, Me.colStockCode, Me.colDescription, Me.colBagWeight, Me.colNoOfBas, Me.colQuantity, Me.colUnitPrice, Me.colDiscount, Me.colValue})
        Me.gvPurchasesDescription.GridControl = Me.gcPurchasesDescription
        Me.gvPurchasesDescription.Name = "gvPurchasesDescription"
        Me.gvPurchasesDescription.OptionsCustomization.AllowRowSizing = True
        Me.gvPurchasesDescription.OptionsNavigation.AutoFocusNewRow = True
        Me.gvPurchasesDescription.OptionsNavigation.EnterMoveNextColumn = True
        Me.gvPurchasesDescription.OptionsView.EnableAppearanceOddRow = True
        Me.gvPurchasesDescription.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        Me.gvPurchasesDescription.OptionsView.ShowFooter = True
        Me.gvPurchasesDescription.OptionsView.ShowGroupPanel = False
        '
        'colStockID
        '
        Me.colStockID.Caption = "Stock ID"
        Me.colStockID.FieldName = "StockID"
        Me.colStockID.Name = "colStockID"
        '
        'colStockCode
        '
        Me.colStockCode.Caption = "Stock Code"
        Me.colStockCode.ColumnEdit = Me.glupStockItems
        Me.colStockCode.FieldName = "StockCode"
        Me.colStockCode.Name = "colStockCode"
        Me.colStockCode.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.colStockCode.ToolTip = "Stock Code"
        Me.colStockCode.Visible = True
        Me.colStockCode.VisibleIndex = 0
        Me.colStockCode.Width = 116
        '
        'glupStockItems
        '
        Me.glupStockItems.AutoHeight = False
        Me.glupStockItems.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.glupStockItems.DisplayMember = "StockCode"
        Me.glupStockItems.ImmediatePopup = True
        Me.glupStockItems.Name = "glupStockItems"
        Me.glupStockItems.NullText = ""
        Me.glupStockItems.PopupFormMinSize = New System.Drawing.Size(775, 0)
        Me.glupStockItems.ValueMember = "StockID"
        Me.glupStockItems.View = Me.GridView3
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcolStockID, Me.gcolStockCode, Me.gcolDescription, Me.gcolCatagory, Me.gcolPurchasePrice, Me.gcolReorderLevel})
        Me.GridView3.DetailHeight = 50
        Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'gcolStockID
        '
        Me.gcolStockID.FieldName = "StockID"
        Me.gcolStockID.Name = "gcolStockID"
        '
        'gcolStockCode
        '
        Me.gcolStockCode.Caption = "Stock Code"
        Me.gcolStockCode.FieldName = "StockCode"
        Me.gcolStockCode.Name = "gcolStockCode"
        Me.gcolStockCode.Visible = True
        Me.gcolStockCode.VisibleIndex = 0
        Me.gcolStockCode.Width = 100
        '
        'gcolDescription
        '
        Me.gcolDescription.Caption = "Description"
        Me.gcolDescription.FieldName = "Description"
        Me.gcolDescription.Name = "gcolDescription"
        Me.gcolDescription.Visible = True
        Me.gcolDescription.VisibleIndex = 1
        Me.gcolDescription.Width = 250
        '
        'gcolCatagory
        '
        Me.gcolCatagory.Caption = "Catagory"
        Me.gcolCatagory.FieldName = "CatagoryName"
        Me.gcolCatagory.Name = "gcolCatagory"
        Me.gcolCatagory.Visible = True
        Me.gcolCatagory.VisibleIndex = 2
        Me.gcolCatagory.Width = 100
        '
        'gcolPurchasePrice
        '
        Me.gcolPurchasePrice.Caption = "Purchase Price"
        Me.gcolPurchasePrice.DisplayFormat.FormatString = "F"
        Me.gcolPurchasePrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcolPurchasePrice.FieldName = "PurchasingPrice"
        Me.gcolPurchasePrice.Name = "gcolPurchasePrice"
        Me.gcolPurchasePrice.Visible = True
        Me.gcolPurchasePrice.VisibleIndex = 3
        Me.gcolPurchasePrice.Width = 100
        '
        'gcolReorderLevel
        '
        Me.gcolReorderLevel.Caption = "Reorder Level"
        Me.gcolReorderLevel.DisplayFormat.FormatString = "F"
        Me.gcolReorderLevel.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.gcolReorderLevel.FieldName = "ReorderLevel"
        Me.gcolReorderLevel.Name = "gcolReorderLevel"
        Me.gcolReorderLevel.Visible = True
        Me.gcolReorderLevel.VisibleIndex = 4
        Me.gcolReorderLevel.Width = 100
        '
        'colDescription
        '
        Me.colDescription.Caption = "Description"
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.OptionsColumn.AllowEdit = False
        Me.colDescription.OptionsColumn.AllowFocus = False
        Me.colDescription.ToolTip = "Description of stock item"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 1
        Me.colDescription.Width = 254
        '
        'colBagWeight
        '
        Me.colBagWeight.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colBagWeight.AppearanceCell.Options.UseBackColor = True
        Me.colBagWeight.Caption = "Kg/L"
        Me.colBagWeight.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.colBagWeight.FieldName = "BagWeight"
        Me.colBagWeight.Name = "colBagWeight"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'colNoOfBas
        '
        Me.colNoOfBas.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.colNoOfBas.AppearanceCell.Options.UseBackColor = True
        Me.colNoOfBas.Caption = "# Containers"
        Me.colNoOfBas.ColumnEdit = Me.RepositoryItemSpinEdit2
        Me.colNoOfBas.FieldName = "NoOfBags"
        Me.colNoOfBas.Name = "colNoOfBas"
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'colQuantity
        '
        Me.colQuantity.Caption = "Quantity"
        Me.colQuantity.ColumnEdit = Me.risiQuantity
        Me.colQuantity.DisplayFormat.FormatString = "F"
        Me.colQuantity.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colQuantity.FieldName = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ToolTip = "Quanity purchase"
        Me.colQuantity.Visible = True
        Me.colQuantity.VisibleIndex = 2
        Me.colQuantity.Width = 80
        '
        'risiQuantity
        '
        Me.risiQuantity.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.risiQuantity.AutoHeight = False
        Me.risiQuantity.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.risiQuantity.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.risiQuantity.Name = "risiQuantity"
        Me.risiQuantity.ValidateOnEnterKey = True
        '
        'colUnitPrice
        '
        Me.colUnitPrice.Caption = "Unit Price"
        Me.colUnitPrice.ColumnEdit = Me.risiUnitPrice
        Me.colUnitPrice.DisplayFormat.FormatString = "F"
        Me.colUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colUnitPrice.FieldName = "UnitPrice"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ToolTip = "Unit Price of the stock item"
        Me.colUnitPrice.Visible = True
        Me.colUnitPrice.VisibleIndex = 3
        Me.colUnitPrice.Width = 76
        '
        'risiUnitPrice
        '
        Me.risiUnitPrice.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.risiUnitPrice.AutoHeight = False
        Me.risiUnitPrice.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.risiUnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.risiUnitPrice.DisplayFormat.FormatString = "F"
        Me.risiUnitPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.risiUnitPrice.EditFormat.FormatString = "F"
        Me.risiUnitPrice.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.risiUnitPrice.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.risiUnitPrice.Name = "risiUnitPrice"
        Me.risiUnitPrice.ValidateOnEnterKey = True
        '
        'colDiscount
        '
        Me.colDiscount.Caption = "Discount Amt"
        Me.colDiscount.ColumnEdit = Me.risiUnitPrice
        Me.colDiscount.DisplayFormat.FormatString = "F"
        Me.colDiscount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colDiscount.FieldName = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ToolTip = "Discount amount receive"
        Me.colDiscount.Visible = True
        Me.colDiscount.VisibleIndex = 4
        Me.colDiscount.Width = 80
        '
        'colValue
        '
        Me.colValue.Caption = "Value"
        Me.colValue.DisplayFormat.FormatString = "F"
        Me.colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.colValue.FieldName = "Value"
        Me.colValue.Name = "colValue"
        Me.colValue.OptionsColumn.AllowEdit = False
        Me.colValue.OptionsColumn.AllowFocus = False
        Me.colValue.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value", "Total : {0:n2}")})
        Me.colValue.ToolTip = "Stock value"
        Me.colValue.Visible = True
        Me.colValue.VisibleIndex = 5
        Me.colValue.Width = 125
        '
        'RepositoryItemCalcEdit1
        '
        Me.RepositoryItemCalcEdit1.AutoHeight = False
        Me.RepositoryItemCalcEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemCalcEdit1.Name = "RepositoryItemCalcEdit1"
        '
        'RepositoryItemLookUpEdit1
        '
        Me.RepositoryItemLookUpEdit1.AutoHeight = False
        Me.RepositoryItemLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemLookUpEdit1.Name = "RepositoryItemLookUpEdit1"
        '
        'meNote
        '
        Me.meNote.EditValue = ""
        Me.meNote.EnterMoveNextControl = True
        Me.meNote.Location = New System.Drawing.Point(515, 53)
        Me.meNote.Name = "meNote"
        Me.meNote.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.meNote.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.meNote.Properties.PopupFormSize = New System.Drawing.Size(350, 150)
        Me.meNote.Properties.ShowIcon = False
        Me.meNote.Properties.ShowPopupShadow = False
        Me.meNote.Size = New System.Drawing.Size(326, 20)
        Me.meNote.StyleController = Me.LayoutControl1
        Me.meNote.TabIndex = 3
        '
        'teReferenceNo
        '
        Me.teReferenceNo.EnterMoveNextControl = True
        Me.teReferenceNo.Location = New System.Drawing.Point(515, 29)
        Me.teReferenceNo.Name = "teReferenceNo"
        Me.teReferenceNo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teReferenceNo.Size = New System.Drawing.Size(326, 20)
        Me.teReferenceNo.StyleController = Me.LayoutControl1
        Me.teReferenceNo.TabIndex = 2
        '
        'dePurchaseDate
        '
        Me.dePurchaseDate.EditValue = New Date(2006, 8, 15, 0, 0, 0, 0)
        Me.dePurchaseDate.EnterMoveNextControl = True
        Me.dePurchaseDate.Location = New System.Drawing.Point(82, 53)
        Me.dePurchaseDate.Name = "dePurchaseDate"
        Me.dePurchaseDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.dePurchaseDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dePurchaseDate.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.dePurchaseDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.dePurchaseDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dePurchaseDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.dePurchaseDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dePurchaseDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.dePurchaseDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.dePurchaseDate.Size = New System.Drawing.Size(261, 20)
        Me.dePurchaseDate.StyleController = Me.LayoutControl1
        Me.dePurchaseDate.TabIndex = 1
        '
        'lupSupplier
        '
        Me.lupSupplier.EnterMoveNextControl = True
        Me.lupSupplier.Location = New System.Drawing.Point(82, 29)
        Me.lupSupplier.Name = "lupSupplier"
        Me.lupSupplier.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "+", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject2, "", Nothing, Nothing, False)})
        Me.lupSupplier.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.lupSupplier.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierNo", 15, "Supplier No"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("SupplierName", "Supplier Name")})
        Me.lupSupplier.Properties.NullText = ""
        Me.lupSupplier.Size = New System.Drawing.Size(261, 20)
        Me.lupSupplier.StyleController = Me.LayoutControl1
        Me.lupSupplier.TabIndex = 0
        ConditionValidatonRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidatonRule1.ErrorText = "Can no be blank"
        Me.dxvpPurchase.SetValidationRule(Me.lupSupplier, ConditionValidatonRule1)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem4, Me.LayoutControlItem12, Me.LayoutControlGroup2, Me.LayoutControlItem15, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem6, Me.LayoutControlGroup3, Me.LayoutControlItem11, Me.LayoutControlItem16})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.lupSupplier
        Me.LayoutControlItem1.CustomizationFormText = "Supplier"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 17)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(335, 24)
        Me.LayoutControlItem1.Text = "Supplier"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.teReferenceNo
        Me.LayoutControlItem3.CustomizationFormText = "Reference No"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(433, 17)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(400, 24)
        Me.LayoutControlItem3.Text = "Reference No"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dePurchaseDate
        Me.LayoutControlItem2.CustomizationFormText = "Date"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 41)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(335, 24)
        Me.LayoutControlItem2.Text = "Date"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.meNote
        Me.LayoutControlItem4.CustomizationFormText = "Note"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(433, 41)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(400, 24)
        Me.LayoutControlItem4.Text = "Note"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.lblPurchaseID
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(434, 17)
        Me.LayoutControlItem12.Text = "LayoutControlItem12"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextToControlDistance = 0
        Me.LayoutControlItem12.TextVisible = False
        Me.LayoutControlItem12.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(335, 17)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(98, 48)
        Me.LayoutControlGroup2.Spacing = New DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup2"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.seGrandTotal
        Me.LayoutControlItem15.CustomizationFormText = "Balance"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(439, 387)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(394, 91)
        Me.LayoutControlItem15.Text = "Grand Total"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.seTaxAmount
        Me.LayoutControlItem8.CustomizationFormText = "Amount"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(439, 339)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(394, 24)
        Me.LayoutControlItem8.Text = "Tax Amount"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(66, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.seDiscount
        Me.LayoutControlItem9.CustomizationFormText = "Discount"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(636, 363)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(197, 24)
        Me.LayoutControlItem9.Text = "Discount"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextToControlDistance = 0
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.gcCollections
        Me.LayoutControlItem6.CustomizationFormText = "LayoutControlItem6"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 339)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(439, 139)
        Me.LayoutControlItem6.Text = "LayoutControlItem6"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextToControlDistance = 0
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 65)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(833, 274)
        Me.LayoutControlGroup3.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.gcPurchasesDescription
        Me.LayoutControlItem5.CustomizationFormText = "Stock Items"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 250)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(111, 31)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(809, 250)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Stock Items"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.lblSystemNo
        Me.LayoutControlItem11.CustomizationFormText = "LayoutControlItem11"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(434, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(399, 17)
        Me.LayoutControlItem11.Text = "LayoutControlItem11"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextToControlDistance = 0
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.sePercentage
        Me.LayoutControlItem16.CustomizationFormText = "LayoutControlItem16"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(439, 363)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(197, 24)
        Me.LayoutControlItem16.Text = "Discount (%)"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(66, 13)
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LayoutControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(853, 498)
        Me.XtraTabPage2.Text = "History Data"
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.LayoutControl3)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(853, 498)
        Me.XtraTabPage3.Text = "Purchased Items"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.sbProcess2)
        Me.LayoutControl3.Controls.Add(Me.deTo2)
        Me.LayoutControl3.Controls.Add(Me.deFrom2)
        Me.LayoutControl3.Controls.Add(Me.gcPurchaseHistoryItems)
        Me.LayoutControl3.Controls.Add(Me.GridControl1)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem17})
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.Root = Me.LayoutControlGroup6
        Me.LayoutControl3.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControl3.TabIndex = 0
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'sbProcess2
        '
        Me.sbProcess2.Location = New System.Drawing.Point(305, 43)
        Me.sbProcess2.Name = "sbProcess2"
        Me.sbProcess2.Size = New System.Drawing.Size(84, 29)
        Me.sbProcess2.StyleController = Me.LayoutControl3
        Me.sbProcess2.TabIndex = 8
        Me.sbProcess2.Text = "Process"
        '
        'deTo2
        '
        Me.deTo2.EditValue = Nothing
        Me.deTo2.Location = New System.Drawing.Point(192, 43)
        Me.deTo2.Name = "deTo2"
        Me.deTo2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deTo2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deTo2.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deTo2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deTo2.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deTo2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deTo2.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deTo2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deTo2.Size = New System.Drawing.Size(109, 20)
        Me.deTo2.StyleController = Me.LayoutControl3
        Me.deTo2.TabIndex = 7
        '
        'deFrom2
        '
        Me.deFrom2.EditValue = Nothing
        Me.deFrom2.Location = New System.Drawing.Point(52, 43)
        Me.deFrom2.Name = "deFrom2"
        Me.deFrom2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deFrom2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deFrom2.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deFrom2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deFrom2.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deFrom2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deFrom2.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deFrom2.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deFrom2.Size = New System.Drawing.Size(108, 20)
        Me.deFrom2.StyleController = Me.LayoutControl3
        Me.deFrom2.TabIndex = 6
        '
        'gcPurchaseHistoryItems
        '
        Me.gcPurchaseHistoryItems.Location = New System.Drawing.Point(12, 88)
        Me.gcPurchaseHistoryItems.MainView = Me.gvPurchaseHistoryItems
        Me.gcPurchaseHistoryItems.Name = "gcPurchaseHistoryItems"
        Me.gcPurchaseHistoryItems.Size = New System.Drawing.Size(829, 398)
        Me.gcPurchaseHistoryItems.TabIndex = 5
        Me.gcPurchaseHistoryItems.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvPurchaseHistoryItems})
        '
        'gvPurchaseHistoryItems
        '
        Me.gvPurchaseHistoryItems.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn5, Me.GridColumn12, Me.GridColumn35, Me.GridColumn36, Me.GridColumn37, Me.GridColumn38, Me.GridColumn39, Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43})
        Me.gvPurchaseHistoryItems.GridControl = Me.gcPurchaseHistoryItems
        Me.gvPurchaseHistoryItems.Name = "gvPurchaseHistoryItems"
        Me.gvPurchaseHistoryItems.OptionsBehavior.Editable = False
        Me.gvPurchaseHistoryItems.OptionsView.EnableAppearanceOddRow = True
        Me.gvPurchaseHistoryItems.OptionsView.ShowAutoFilterRow = True
        Me.gvPurchaseHistoryItems.OptionsView.ShowFooter = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "PurchaseID"
        Me.GridColumn3.FieldName = "PurchaseID"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Purchase No"
        Me.GridColumn5.FieldName = "PurchaseNo"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Purchase Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "PurchaseDate"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "Supplier Name"
        Me.GridColumn35.FieldName = "SupplierName"
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.Visible = True
        Me.GridColumn35.VisibleIndex = 2
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "Stock Code"
        Me.GridColumn36.FieldName = "StockCode"
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn36.Visible = True
        Me.GridColumn36.VisibleIndex = 3
        '
        'GridColumn37
        '
        Me.GridColumn37.Caption = "Description"
        Me.GridColumn37.FieldName = "Description"
        Me.GridColumn37.Name = "GridColumn37"
        Me.GridColumn37.Visible = True
        Me.GridColumn37.VisibleIndex = 4
        '
        'GridColumn38
        '
        Me.GridColumn38.Caption = "Unit Price"
        Me.GridColumn38.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn38.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn38.FieldName = "UnitPrice"
        Me.GridColumn38.Name = "GridColumn38"
        Me.GridColumn38.Visible = True
        Me.GridColumn38.VisibleIndex = 5
        '
        'GridColumn39
        '
        Me.GridColumn39.Caption = "Quantity"
        Me.GridColumn39.FieldName = "Quantity"
        Me.GridColumn39.Name = "GridColumn39"
        Me.GridColumn39.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn39.Visible = True
        Me.GridColumn39.VisibleIndex = 6
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "Bag Weight"
        Me.GridColumn40.FieldName = "BagWeight"
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.Visible = True
        Me.GridColumn40.VisibleIndex = 7
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "No Of Bags"
        Me.GridColumn41.FieldName = "NoOfBags"
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.GridColumn41.Visible = True
        Me.GridColumn41.VisibleIndex = 8
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "Discount"
        Me.GridColumn42.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn42.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn42.FieldName = "Discount"
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Discount", "{0:n2}")})
        Me.GridColumn42.Visible = True
        Me.GridColumn42.VisibleIndex = 9
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "Value"
        Me.GridColumn43.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn43.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn43.FieldName = "Value"
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Value", "{0:n2}")})
        Me.GridColumn43.Visible = True
        Me.GridColumn43.VisibleIndex = 10
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(114, 7)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(730, 481)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.GridControl1
        Me.LayoutControlItem17.CustomizationFormText = "LayoutControlItem17"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(848, 492)
        Me.LayoutControlItem17.Text = "LayoutControlItem17"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem17.TextToControlDistance = 5
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem18, Me.LayoutControlGroup7, Me.EmptySpaceItem3})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(853, 498)
        Me.LayoutControlGroup6.Text = "LayoutControlGroup6"
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.gcPurchaseHistoryItems
        Me.LayoutControlItem18.CustomizationFormText = "LayoutControlItem18"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 76)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(833, 402)
        Me.LayoutControlItem18.Text = "LayoutControlItem18"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextToControlDistance = 0
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.CustomizationFormText = "Select Date Range to Display History Purchased Items"
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem19, Me.LayoutControlItem21, Me.LayoutControlItem20})
        Me.LayoutControlGroup7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup7.Name = "LayoutControlGroup7"
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(393, 76)
        Me.LayoutControlGroup7.Text = "Select Date Range to Display History Purchased Items"
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.deFrom2
        Me.LayoutControlItem19.CustomizationFormText = "From"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(140, 33)
        Me.LayoutControlItem19.Text = "From"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(24, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.sbProcess2
        Me.LayoutControlItem21.CustomizationFormText = "LayoutControlItem21"
        Me.LayoutControlItem21.Location = New System.Drawing.Point(281, 0)
        Me.LayoutControlItem21.MaxSize = New System.Drawing.Size(0, 33)
        Me.LayoutControlItem21.MinSize = New System.Drawing.Size(61, 33)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(88, 33)
        Me.LayoutControlItem21.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem21.Text = "LayoutControlItem21"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextToControlDistance = 0
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.deTo2
        Me.LayoutControlItem20.CustomizationFormText = "To"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(140, 0)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(141, 33)
        Me.LayoutControlItem20.Text = "To"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(24, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(393, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(440, 76)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 419)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(848, 10)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmPurchases
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 548)
        Me.Controls.Add(Me.xTab1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "frmPurchases"
        Me.Text = "Purchasings"
        CType(Me.deFromDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFromDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.deToDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deToDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcPurchaseHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPurchaseHistory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemComboBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xTab1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.sePercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seDiscount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seGrandTotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seTaxAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcCollections, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCollections, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcPurchasesDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPurchasesDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.glupStockItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.risiQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.risiUnitPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemCalcEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meNote.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teReferenceNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dePurchaseDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dePurchaseDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lupSupplier.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.deTo2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deTo2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFrom2.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFrom2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcPurchaseHistoryItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPurchaseHistoryItems, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpPurchase, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpHistoryData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemComboBox1 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents xTab1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcPurchaseHistory As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPurchaseHistory As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents bbRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDisplaySelected As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lupSupplier As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dePurchaseDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teReferenceNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents meNote As DevExpress.XtraEditors.MemoExEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcPurchasesDescription As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPurchasesDescription As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents colStockID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStockCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents glupStockItems As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcolStockCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolCatagory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolPurchasePrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolReorderLevel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colUnitPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents risiUnitPrice As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colDiscount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colValue As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemCalcEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcCollections As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCollections As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seTaxAmount As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PictureEdit2 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblPurchaseID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents dxvpPurchase As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents seGrandTotal As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seDiscount As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents RepositoryItemComboBox2 As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemCalcEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deFromDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deToDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents smProcess As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dxvpHistoryData As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblSystemNo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents sePercentage As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents risiQuantity As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colBagWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents colNoOfBas As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcPurchaseHistoryItems As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvPurchaseHistoryItems As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deTo2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deFrom2 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents sbProcess2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcolStockID As DevExpress.XtraGrid.Columns.GridColumn
End Class
