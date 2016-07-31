<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTermDeductions
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
        Dim ConditionValidationRule7 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule8 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule5 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDisplaySelected = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.dxvpCompany = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.cmbDeductionType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmbWorkType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblID = New DevExpress.XtraEditors.LabelControl()
        Me.gcTermDeductions = New DevExpress.XtraGrid.GridControl()
        Me.gvTermDeductions = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.deStartMonth = New DevExpress.XtraEditors.DateEdit()
        Me.sePeriod = New DevExpress.XtraEditors.SpinEdit()
        Me.seAmount = New DevExpress.XtraEditors.SpinEdit()
        Me.leEmployeeCode = New DevExpress.XtraEditors.LookUpEdit()
        Me.deIssueDate = New DevExpress.XtraEditors.DateEdit()
        Me.teEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcTermDeductioDetails = New DevExpress.XtraGrid.GridControl()
        Me.gvTermDeductioDetails = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.teDescription = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDeductionType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcTermDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTermDeductions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartMonth.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sePeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deIssueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deIssueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.gcTermDeductioDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvTermDeductioDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teDescription.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowQuickCustomization = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbSave, Me.bbClose, Me.bbNew, Me.bbDisplaySelected, Me.bbDelete, Me.bbRefresh, Me.bbPrint})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 7
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDisplaySelected), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose)})
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'bbSave
        '
        Me.bbSave.Caption = "Save"
        Me.bbSave.Id = 0
        Me.bbSave.Name = "bbSave"
        '
        'bbNew
        '
        Me.bbNew.Caption = "BarButtonItem1"
        Me.bbNew.Id = 2
        Me.bbNew.Name = "bbNew"
        '
        'bbDisplaySelected
        '
        Me.bbDisplaySelected.Caption = "BarButtonItem2"
        Me.bbDisplaySelected.Id = 3
        Me.bbDisplaySelected.Name = "bbDisplaySelected"
        '
        'bbDelete
        '
        Me.bbDelete.Caption = "BarButtonItem2"
        Me.bbDelete.Id = 4
        Me.bbDelete.Name = "bbDelete"
        '
        'bbRefresh
        '
        Me.bbRefresh.Caption = "BarButtonItem2"
        Me.bbRefresh.Id = 5
        Me.bbRefresh.Name = "bbRefresh"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "BarButtonItem1"
        Me.bbPrint.Id = 6
        Me.bbPrint.Name = "bbPrint"
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        'bbClose
        '
        Me.bbClose.Caption = "Close"
        Me.bbClose.Id = 1
        Me.bbClose.Name = "bbClose"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(703, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 434)
        Me.barDockControlBottom.Size = New System.Drawing.Size(703, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 412)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(703, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 412)
        '
        'cmbDeductionType
        '
        Me.cmbDeductionType.EnterMoveNextControl = True
        Me.dxvpCompany.SetIconAlignment(Me.cmbDeductionType, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.cmbDeductionType.Location = New System.Drawing.Point(188, 77)
        Me.cmbDeductionType.MenuManager = Me.BarManager1
        Me.cmbDeductionType.Name = "cmbDeductionType"
        Me.cmbDeductionType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDeductionType.Properties.Items.AddRange(New Object() {"FESTIVAL ", "LOAN "})
        Me.cmbDeductionType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbDeductionType.Size = New System.Drawing.Size(156, 20)
        Me.cmbDeductionType.StyleController = Me.LayoutControl1
        Me.cmbDeductionType.TabIndex = 1
        ConditionValidationRule7.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule7.ErrorText = "Require"
        Me.dxvpCompany.SetValidationRule(Me.cmbDeductionType, ConditionValidationRule7)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.teDescription)
        Me.LayoutControl1.Controls.Add(Me.cmbWorkType)
        Me.LayoutControl1.Controls.Add(Me.lblID)
        Me.LayoutControl1.Controls.Add(Me.gcTermDeductions)
        Me.LayoutControl1.Controls.Add(Me.deStartMonth)
        Me.LayoutControl1.Controls.Add(Me.sePeriod)
        Me.LayoutControl1.Controls.Add(Me.seAmount)
        Me.LayoutControl1.Controls.Add(Me.leEmployeeCode)
        Me.LayoutControl1.Controls.Add(Me.deIssueDate)
        Me.LayoutControl1.Controls.Add(Me.cmbDeductionType)
        Me.LayoutControl1.Controls.Add(Me.teEmployeeName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(327, 248, 250, 350)
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmbWorkType
        '
        Me.cmbWorkType.Location = New System.Drawing.Point(188, 29)
        Me.cmbWorkType.MenuManager = Me.BarManager1
        Me.cmbWorkType.Name = "cmbWorkType"
        Me.cmbWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWorkType.Properties.Items.AddRange(New Object() {"STAFF", "CASUAL", "PERMANENT"})
        Me.cmbWorkType.Size = New System.Drawing.Size(156, 20)
        Me.cmbWorkType.StyleController = Me.LayoutControl1
        Me.cmbWorkType.TabIndex = 13
        '
        'lblID
        '
        Me.lblID.Location = New System.Drawing.Point(89, 12)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(524, 13)
        Me.lblID.StyleController = Me.LayoutControl1
        Me.lblID.TabIndex = 12
        '
        'gcTermDeductions
        '
        Me.gcTermDeductions.Location = New System.Drawing.Point(89, 149)
        Me.gcTermDeductions.MainView = Me.gvTermDeductions
        Me.gcTermDeductions.MenuManager = Me.BarManager1
        Me.gcTermDeductions.Name = "gcTermDeductions"
        Me.gcTermDeductions.Size = New System.Drawing.Size(524, 223)
        Me.gcTermDeductions.TabIndex = 6
        Me.gcTermDeductions.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTermDeductions})
        '
        'gvTermDeductions
        '
        Me.gvTermDeductions.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn15})
        Me.gvTermDeductions.GridControl = Me.gcTermDeductions
        Me.gvTermDeductions.Name = "gvTermDeductions"
        Me.gvTermDeductions.OptionsView.EnableAppearanceOddRow = True
        Me.gvTermDeductions.OptionsView.ShowFooter = True
        Me.gvTermDeductions.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Month"
        Me.GridColumn1.FieldName = "TDMonthName"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Amount"
        Me.GridColumn2.DisplayFormat.FormatString = "{0:N2}"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn2.FieldName = "TDInsAmount"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TDInsAmount", "{0:N2}")})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Range"
        Me.GridColumn15.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn15.FieldName = "ActiveDate"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 2
        '
        'deStartMonth
        '
        Me.deStartMonth.EditValue = Nothing
        Me.deStartMonth.EnterMoveNextControl = True
        Me.deStartMonth.Location = New System.Drawing.Point(447, 101)
        Me.deStartMonth.MenuManager = Me.BarManager1
        Me.deStartMonth.Name = "deStartMonth"
        Me.deStartMonth.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deStartMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartMonth.Properties.DisplayFormat.FormatString = "MMM-yy"
        Me.deStartMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartMonth.Properties.EditFormat.FormatString = "MMM-yy"
        Me.deStartMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartMonth.Properties.Mask.EditMask = "MMM-yy"
        Me.deStartMonth.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deStartMonth.Size = New System.Drawing.Size(166, 20)
        Me.deStartMonth.StyleController = Me.LayoutControl1
        Me.deStartMonth.TabIndex = 5
        ConditionValidationRule8.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule8.ErrorText = "Require"
        Me.dxvpCompany.SetValidationRule(Me.deStartMonth, ConditionValidationRule8)
        '
        'sePeriod
        '
        Me.sePeriod.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sePeriod.EnterMoveNextControl = True
        Me.sePeriod.Location = New System.Drawing.Point(447, 77)
        Me.sePeriod.MenuManager = Me.BarManager1
        Me.sePeriod.Name = "sePeriod"
        Me.sePeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.sePeriod.Properties.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.sePeriod.Size = New System.Drawing.Size(166, 20)
        Me.sePeriod.StyleController = Me.LayoutControl1
        Me.sePeriod.TabIndex = 4
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule1.ErrorText = "Require"
        ConditionValidationRule1.Value1 = CType(0, Long)
        Me.dxvpCompany.SetValidationRule(Me.sePeriod, ConditionValidationRule1)
        '
        'seAmount
        '
        Me.seAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seAmount.EnterMoveNextControl = True
        Me.seAmount.Location = New System.Drawing.Point(447, 53)
        Me.seAmount.MenuManager = Me.BarManager1
        Me.seAmount.Name = "seAmount"
        Me.seAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seAmount.Properties.MaxValue = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.seAmount.Size = New System.Drawing.Size(166, 20)
        Me.seAmount.StyleController = Me.LayoutControl1
        Me.seAmount.TabIndex = 3
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule2.ErrorText = "Require"
        ConditionValidationRule2.Value1 = CType(0, Long)
        Me.dxvpCompany.SetValidationRule(Me.seAmount, ConditionValidationRule2)
        '
        'leEmployeeCode
        '
        Me.leEmployeeCode.EnterMoveNextControl = True
        Me.leEmployeeCode.Location = New System.Drawing.Point(188, 53)
        Me.leEmployeeCode.MenuManager = Me.BarManager1
        Me.leEmployeeCode.Name = "leEmployeeCode"
        Me.leEmployeeCode.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leEmployeeCode.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerID", "EmployerID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerNo", "Employer No"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerName", "Employer Name")})
        Me.leEmployeeCode.Properties.NullText = ""
        Me.leEmployeeCode.Size = New System.Drawing.Size(156, 20)
        Me.leEmployeeCode.StyleController = Me.LayoutControl1
        Me.leEmployeeCode.TabIndex = 0
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Require"
        Me.dxvpCompany.SetValidationRule(Me.leEmployeeCode, ConditionValidationRule3)
        '
        'deIssueDate
        '
        Me.deIssueDate.EditValue = Nothing
        Me.deIssueDate.EnterMoveNextControl = True
        Me.deIssueDate.Location = New System.Drawing.Point(188, 101)
        Me.deIssueDate.MenuManager = Me.BarManager1
        Me.deIssueDate.Name = "deIssueDate"
        Me.deIssueDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.deIssueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deIssueDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deIssueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deIssueDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deIssueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deIssueDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deIssueDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deIssueDate.Size = New System.Drawing.Size(156, 20)
        Me.deIssueDate.StyleController = Me.LayoutControl1
        Me.deIssueDate.TabIndex = 2
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule4.ErrorText = "Require"
        Me.dxvpCompany.SetValidationRule(Me.deIssueDate, ConditionValidationRule4)
        '
        'teEmployeeName
        '
        Me.teEmployeeName.Enabled = False
        Me.teEmployeeName.Location = New System.Drawing.Point(188, 125)
        Me.teEmployeeName.MenuManager = Me.BarManager1
        Me.teEmployeeName.Name = "teEmployeeName"
        Me.teEmployeeName.Size = New System.Drawing.Size(425, 20)
        Me.teEmployeeName.StyleController = Me.LayoutControl1
        Me.teEmployeeName.TabIndex = 7
        ConditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule5.ErrorText = "Require"
        Me.dxvpCompany.SetValidationRule(Me.teEmployeeName, ConditionValidationRule5)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem11, Me.LayoutControlItem4, Me.LayoutControlItem12})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cmbDeductionType
        Me.LayoutControlItem1.CustomizationFormText = "Deduction Type"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(77, 65)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(259, 24)
        Me.LayoutControlItem1.Text = "Deduction Type"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.deIssueDate
        Me.LayoutControlItem2.CustomizationFormText = "Date"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(77, 89)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(259, 24)
        Me.LayoutControlItem2.Text = "Date"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.gcTermDeductions
        Me.LayoutControlItem8.CustomizationFormText = "LayoutControlItem8"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(77, 137)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(528, 227)
        Me.LayoutControlItem8.Text = "LayoutControlItem8"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextToControlDistance = 0
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lblID
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(77, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(528, 17)
        Me.LayoutControlItem10.Text = "LayoutControlItem10"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextToControlDistance = 0
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(77, 364)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(605, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(72, 364)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.leEmployeeCode
        Me.LayoutControlItem3.CustomizationFormText = "Employee Code"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(77, 41)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(259, 24)
        Me.LayoutControlItem3.Text = "Employee Code"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.seAmount
        Me.LayoutControlItem5.CustomizationFormText = "Amount"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(336, 41)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem5.Text = "Amount"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.sePeriod
        Me.LayoutControlItem6.CustomizationFormText = "Period"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(336, 65)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem6.Text = "Period"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.deStartMonth
        Me.LayoutControlItem7.CustomizationFormText = "Start Month"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(336, 89)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem7.Text = "Start Month"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmbWorkType
        Me.LayoutControlItem11.CustomizationFormText = "Work Type"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(77, 17)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(259, 24)
        Me.LayoutControlItem11.Text = "Work Type"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.teEmployeeName
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(77, 113)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(528, 24)
        Me.LayoutControlItem4.Text = "LayoutControlItem4"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        Me.LayoutControlItem4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 22)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(703, 412)
        Me.XtraTabControl1.TabIndex = 9
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(697, 384)
        Me.XtraTabPage1.Text = "Add New"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LayoutControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(697, 384)
        Me.XtraTabPage2.Text = "History Data"
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.gcTermDeductioDetails)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'gcTermDeductioDetails
        '
        Me.gcTermDeductioDetails.Location = New System.Drawing.Point(12, 12)
        Me.gcTermDeductioDetails.MainView = Me.gvTermDeductioDetails
        Me.gcTermDeductioDetails.MenuManager = Me.BarManager1
        Me.gcTermDeductioDetails.Name = "gcTermDeductioDetails"
        Me.gcTermDeductioDetails.Size = New System.Drawing.Size(673, 360)
        Me.gcTermDeductioDetails.TabIndex = 4
        Me.gcTermDeductioDetails.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvTermDeductioDetails})
        '
        'gvTermDeductioDetails
        '
        Me.gvTermDeductioDetails.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.gvTermDeductioDetails.GridControl = Me.gcTermDeductioDetails
        Me.gvTermDeductioDetails.Name = "gvTermDeductioDetails"
        Me.gvTermDeductioDetails.OptionsView.EnableAppearanceOddRow = True
        Me.gvTermDeductioDetails.OptionsView.ShowAutoFilterRow = True
        Me.gvTermDeductioDetails.OptionsView.ShowFooter = True
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "TermDeductionID"
        Me.GridColumn3.FieldName = "TermDeductionID"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Issued Date"
        Me.GridColumn4.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn4.FieldName = "TDDate"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Type"
        Me.GridColumn5.FieldName = "TDdescription"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Employee ID"
        Me.GridColumn6.FieldName = "EmployerID"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.AllowFocus = False
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Employee No"
        Me.GridColumn7.FieldName = "EmployerNo"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowFocus = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Employee Name "
        Me.GridColumn8.FieldName = "EmployerName"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowFocus = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 3
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Amount"
        Me.GridColumn9.DisplayFormat.FormatString = "{0:N2}"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn9.FieldName = "TDAmount"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowFocus = False
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TDAmount", "{0:N2}")})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 4
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Period"
        Me.GridColumn10.FieldName = "TDInstallments"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.AllowFocus = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 5
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "CreatedBy"
        Me.GridColumn11.FieldName = "CreatedBy"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowFocus = False
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "CreatedDate"
        Me.GridColumn12.FieldName = "CreatedDate"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.AllowFocus = False
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "UpdatedBy"
        Me.GridColumn13.FieldName = "UpdatedBy"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.AllowFocus = False
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "UdatedDate"
        Me.GridColumn14.FieldName = "UdatedDate"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.AllowFocus = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup2"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.gcTermDeductioDetails
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(677, 364)
        Me.LayoutControlItem9.Text = "LayoutControlItem9"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextToControlDistance = 0
        Me.LayoutControlItem9.TextVisible = False
        '
        'teDescription
        '
        Me.teDescription.Location = New System.Drawing.Point(447, 29)
        Me.teDescription.MenuManager = Me.BarManager1
        Me.teDescription.Name = "teDescription"
        Me.teDescription.Size = New System.Drawing.Size(166, 20)
        Me.teDescription.StyleController = Me.LayoutControl1
        Me.teDescription.TabIndex = 14
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.teDescription
        Me.LayoutControlItem12.CustomizationFormText = "Description"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(336, 17)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(269, 24)
        Me.LayoutControlItem12.Text = "Description"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(96, 13)
        '
        'frmTermDeductions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(703, 434)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "frmTermDeductions"
        Me.Text = "Festival Advance | Loan"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDeductionType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcTermDeductions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTermDeductions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartMonth.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sePeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leEmployeeCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deIssueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deIssueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.gcTermDeductioDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvTermDeductioDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teDescription.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents bbNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDisplaySelected As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents dxvpCompany As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents deStartMonth As DevExpress.XtraEditors.DateEdit
    Friend WithEvents sePeriod As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seAmount As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents teEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents leEmployeeCode As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deIssueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents cmbDeductionType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcTermDeductions As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTermDeductions As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcTermDeductioDetails As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvTermDeductioDetails As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbWorkType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teDescription As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
End Class
