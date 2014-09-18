<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateRatesBulk
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
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim CompareAgainstControlValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule = New DevExpress.XtraEditors.DXErrorProvider.CompareAgainstControlValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDisplaySelected = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcUpdateRates = New DevExpress.XtraGrid.GridControl()
        Me.gvUpdateRates = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.cmbDesignation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.btnDisplay = New DevExpress.XtraEditors.SimpleButton()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.seCasualOTPayRate = New DevExpress.XtraEditors.SpinEdit()
        Me.seCasualPayRate = New DevExpress.XtraEditors.SpinEdit()
        Me.seEPF = New DevExpress.XtraEditors.SpinEdit()
        Me.seOverKgsRate = New DevExpress.XtraEditors.SpinEdit()
        Me.seKgsPerDay = New DevExpress.XtraEditors.SpinEdit()
        Me.seOTRate = New DevExpress.XtraEditors.SpinEdit()
        Me.seDayRate = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dxvpUpdate = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.dxvpSearch = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcUpdateRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvUpdateRates, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbDesignation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seCasualOTPayRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seCasualPayRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seEPF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seOverKgsRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seKgsPerDay.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seOTRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seDayRate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(206, 43)
        Me.deStartDate.MenuManager = Me.BarManager1
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deStartDate.Size = New System.Drawing.Size(88, 20)
        Me.deStartDate.StyleController = Me.LayoutControl1
        Me.deStartDate.TabIndex = 31
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
        Me.Bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose), New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDisplaySelected), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbPrint)})
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
        'bbClose
        '
        Me.bbClose.Caption = "Close"
        Me.bbClose.Id = 1
        Me.bbClose.Name = "bbClose"
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
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(888, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 627)
        Me.barDockControlBottom.Size = New System.Drawing.Size(888, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 605)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(888, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 605)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcUpdateRates)
        Me.LayoutControl1.Controls.Add(Me.cmbDesignation)
        Me.LayoutControl1.Controls.Add(Me.btnDisplay)
        Me.LayoutControl1.Controls.Add(Me.deEndDate)
        Me.LayoutControl1.Controls.Add(Me.deStartDate)
        Me.LayoutControl1.Controls.Add(Me.seCasualOTPayRate)
        Me.LayoutControl1.Controls.Add(Me.seCasualPayRate)
        Me.LayoutControl1.Controls.Add(Me.seEPF)
        Me.LayoutControl1.Controls.Add(Me.seOverKgsRate)
        Me.LayoutControl1.Controls.Add(Me.seKgsPerDay)
        Me.LayoutControl1.Controls.Add(Me.seOTRate)
        Me.LayoutControl1.Controls.Add(Me.seDayRate)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 22)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(888, 605)
        Me.LayoutControl1.TabIndex = 4
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'gcUpdateRates
        '
        Me.gcUpdateRates.Location = New System.Drawing.Point(106, 112)
        Me.gcUpdateRates.MainView = Me.gvUpdateRates
        Me.gcUpdateRates.MenuManager = Me.BarManager1
        Me.gcUpdateRates.Name = "gcUpdateRates"
        Me.gcUpdateRates.Size = New System.Drawing.Size(668, 330)
        Me.gcUpdateRates.TabIndex = 35
        Me.gcUpdateRates.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvUpdateRates})
        '
        'gvUpdateRates
        '
        Me.gvUpdateRates.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.gvUpdateRates.GridControl = Me.gcUpdateRates
        Me.gvUpdateRates.Name = "gvUpdateRates"
        Me.gvUpdateRates.OptionsView.ShowAutoFilterRow = True
        Me.gvUpdateRates.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "WorkingDate"
        Me.GridColumn1.FieldName = "WorkingDate"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowMove = False
        Me.GridColumn1.OptionsColumn.ReadOnly = True
        Me.GridColumn1.OptionsColumn.TabStop = False
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "WorkType"
        Me.GridColumn2.FieldName = "WorkType"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowMove = False
        Me.GridColumn2.OptionsColumn.ReadOnly = True
        Me.GridColumn2.OptionsColumn.TabStop = False
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "DayRate"
        Me.GridColumn3.FieldName = "DayRate"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowMove = False
        Me.GridColumn3.OptionsColumn.ReadOnly = True
        Me.GridColumn3.OptionsColumn.TabStop = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 4
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "OTRate"
        Me.GridColumn4.FieldName = "OTRate"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowMove = False
        Me.GridColumn4.OptionsColumn.ReadOnly = True
        Me.GridColumn4.OptionsColumn.TabStop = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "KgsPerDay"
        Me.GridColumn5.FieldName = "KgsPerDay"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowMove = False
        Me.GridColumn5.OptionsColumn.ReadOnly = True
        Me.GridColumn5.OptionsColumn.TabStop = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 6
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "OverKgRate"
        Me.GridColumn6.FieldName = "OverKgRate"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.AllowMove = False
        Me.GridColumn6.OptionsColumn.ReadOnly = True
        Me.GridColumn6.OptionsColumn.TabStop = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 7
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "CasualPayRate"
        Me.GridColumn7.FieldName = "CasualPayRate"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowMove = False
        Me.GridColumn7.OptionsColumn.ReadOnly = True
        Me.GridColumn7.OptionsColumn.TabStop = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 8
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "CasualOTPayRate"
        Me.GridColumn8.FieldName = "CasualOTPayRate"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowMove = False
        Me.GridColumn8.OptionsColumn.ReadOnly = True
        Me.GridColumn8.OptionsColumn.TabStop = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 9
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "EPF"
        Me.GridColumn9.FieldName = "EPF"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowMove = False
        Me.GridColumn9.OptionsColumn.ReadOnly = True
        Me.GridColumn9.OptionsColumn.TabStop = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 10
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "DailyWorkingID"
        Me.GridColumn10.FieldName = "DailyWorkingID"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.AllowMove = False
        Me.GridColumn10.OptionsColumn.ReadOnly = True
        Me.GridColumn10.OptionsColumn.TabStop = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "EmployerNo"
        Me.GridColumn11.FieldName = "EmployerNo"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowMove = False
        Me.GridColumn11.OptionsColumn.ReadOnly = True
        Me.GridColumn11.OptionsColumn.TabStop = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "EmployerName"
        Me.GridColumn12.FieldName = "EmployerName"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.AllowMove = False
        Me.GridColumn12.OptionsColumn.ReadOnly = True
        Me.GridColumn12.OptionsColumn.TabStop = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'cmbDesignation
        '
        Me.cmbDesignation.Location = New System.Drawing.Point(596, 43)
        Me.cmbDesignation.MenuManager = Me.BarManager1
        Me.cmbDesignation.Name = "cmbDesignation"
        Me.cmbDesignation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDesignation.Properties.Items.AddRange(New Object() {"PERMENANT", "CASUAL"})
        Me.cmbDesignation.Size = New System.Drawing.Size(89, 20)
        Me.cmbDesignation.StyleController = Me.LayoutControl1
        Me.cmbDesignation.TabIndex = 34
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "This value is not valid"
        Me.dxvpSearch.SetValidationRule(Me.cmbDesignation, ConditionValidationRule1)
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(689, 43)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(85, 22)
        Me.btnDisplay.StyleController = Me.LayoutControl1
        Me.btnDisplay.TabIndex = 33
        Me.btnDisplay.Text = "Display"
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Location = New System.Drawing.Point(398, 43)
        Me.deEndDate.MenuManager = Me.BarManager1
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deEndDate.Size = New System.Drawing.Size(94, 20)
        Me.deEndDate.StyleController = Me.LayoutControl1
        Me.deEndDate.TabIndex = 32
        CompareAgainstControlValidationRule1.CompareControlOperator = DevExpress.XtraEditors.DXErrorProvider.CompareControlOperator.Greater
        CompareAgainstControlValidationRule1.Control = Me.deStartDate
        CompareAgainstControlValidationRule1.ErrorText = "Not Supported Date"
        Me.dxvpSearch.SetValidationRule(Me.deEndDate, CompareAgainstControlValidationRule1)
        '
        'seCasualOTPayRate
        '
        Me.seCasualOTPayRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seCasualOTPayRate.Enabled = False
        Me.seCasualOTPayRate.EnterMoveNextControl = True
        Me.seCasualOTPayRate.Location = New System.Drawing.Point(545, 513)
        Me.seCasualOTPayRate.MenuManager = Me.BarManager1
        Me.seCasualOTPayRate.Name = "seCasualOTPayRate"
        Me.seCasualOTPayRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seCasualOTPayRate.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.seCasualOTPayRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seCasualOTPayRate.Properties.EditFormat.FormatString = "{0:N2}"
        Me.seCasualOTPayRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seCasualOTPayRate.Size = New System.Drawing.Size(229, 20)
        Me.seCasualOTPayRate.StyleController = Me.LayoutControl1
        Me.seCasualOTPayRate.TabIndex = 30
        '
        'seCasualPayRate
        '
        Me.seCasualPayRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seCasualPayRate.Enabled = False
        Me.seCasualPayRate.EnterMoveNextControl = True
        Me.seCasualPayRate.Location = New System.Drawing.Point(206, 513)
        Me.seCasualPayRate.MenuManager = Me.BarManager1
        Me.seCasualPayRate.Name = "seCasualPayRate"
        Me.seCasualPayRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seCasualPayRate.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.seCasualPayRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seCasualPayRate.Properties.EditFormat.FormatString = "{0:N2}"
        Me.seCasualPayRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seCasualPayRate.Size = New System.Drawing.Size(235, 20)
        Me.seCasualPayRate.StyleController = Me.LayoutControl1
        Me.seCasualPayRate.TabIndex = 29
        '
        'seEPF
        '
        Me.seEPF.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seEPF.Enabled = False
        Me.seEPF.EnterMoveNextControl = True
        Me.seEPF.Location = New System.Drawing.Point(206, 561)
        Me.seEPF.MenuManager = Me.BarManager1
        Me.seEPF.Name = "seEPF"
        Me.seEPF.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seEPF.Size = New System.Drawing.Size(235, 20)
        Me.seEPF.StyleController = Me.LayoutControl1
        Me.seEPF.TabIndex = 27
        '
        'seOverKgsRate
        '
        Me.seOverKgsRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seOverKgsRate.Enabled = False
        Me.seOverKgsRate.EnterMoveNextControl = True
        Me.seOverKgsRate.Location = New System.Drawing.Point(206, 537)
        Me.seOverKgsRate.MenuManager = Me.BarManager1
        Me.seOverKgsRate.Name = "seOverKgsRate"
        Me.seOverKgsRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seOverKgsRate.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.seOverKgsRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seOverKgsRate.Properties.EditFormat.FormatString = "{0:N2}"
        Me.seOverKgsRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seOverKgsRate.Size = New System.Drawing.Size(235, 20)
        Me.seOverKgsRate.StyleController = Me.LayoutControl1
        Me.seOverKgsRate.TabIndex = 25
        '
        'seKgsPerDay
        '
        Me.seKgsPerDay.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seKgsPerDay.Enabled = False
        Me.seKgsPerDay.EnterMoveNextControl = True
        Me.seKgsPerDay.Location = New System.Drawing.Point(545, 537)
        Me.seKgsPerDay.MenuManager = Me.BarManager1
        Me.seKgsPerDay.Name = "seKgsPerDay"
        Me.seKgsPerDay.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seKgsPerDay.Size = New System.Drawing.Size(229, 20)
        Me.seKgsPerDay.StyleController = Me.LayoutControl1
        Me.seKgsPerDay.TabIndex = 18
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule2.ErrorText = "This value is not valid"
        ConditionValidationRule2.Value1 = "0"
        Me.dxvpUpdate.SetValidationRule(Me.seKgsPerDay, ConditionValidationRule2)
        '
        'seOTRate
        '
        Me.seOTRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seOTRate.Enabled = False
        Me.seOTRate.EnterMoveNextControl = True
        Me.seOTRate.Location = New System.Drawing.Point(545, 489)
        Me.seOTRate.MenuManager = Me.BarManager1
        Me.seOTRate.Name = "seOTRate"
        Me.seOTRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seOTRate.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.seOTRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seOTRate.Properties.EditFormat.FormatString = "{0:N2}"
        Me.seOTRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seOTRate.Size = New System.Drawing.Size(229, 20)
        Me.seOTRate.StyleController = Me.LayoutControl1
        Me.seOTRate.TabIndex = 17
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule3.ErrorText = "This value is not valid"
        ConditionValidationRule3.Value1 = "0"
        Me.dxvpUpdate.SetValidationRule(Me.seOTRate, ConditionValidationRule3)
        '
        'seDayRate
        '
        Me.seDayRate.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seDayRate.Enabled = False
        Me.seDayRate.EnterMoveNextControl = True
        Me.seDayRate.Location = New System.Drawing.Point(206, 489)
        Me.seDayRate.MenuManager = Me.BarManager1
        Me.seDayRate.Name = "seDayRate"
        Me.seDayRate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seDayRate.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.seDayRate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.seDayRate.Properties.EditFormat.FormatString = "d"
        Me.seDayRate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.seDayRate.Size = New System.Drawing.Size(235, 20)
        Me.seDayRate.StyleController = Me.LayoutControl1
        Me.seDayRate.TabIndex = 16
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule4.ErrorText = "This value is not valid"
        ConditionValidationRule4.Value1 = "0"
        Me.dxvpUpdate.SetValidationRule(Me.seDayRate, ConditionValidationRule4)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.LayoutControlGroup4, Me.LayoutControlGroup2, Me.LayoutControlGroup3})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(888, 605)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(82, 585)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(778, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(90, 585)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Application Settings"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem4, Me.LayoutControlItem15, Me.LayoutControlItem13, Me.LayoutControlItem12, Me.LayoutControlItem17, Me.LayoutControlItem2, Me.EmptySpaceItem1})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(82, 446)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(696, 139)
        Me.LayoutControlGroup4.Text = "New Values"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.seDayRate
        Me.LayoutControlItem1.CustomizationFormText = "Day Rate"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem1.Text = "Day Rate"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.seCasualPayRate
        Me.LayoutControlItem4.CustomizationFormText = "Casual Pay Rate"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem4.Text = "Casual Pay Rate"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.seEPF
        Me.LayoutControlItem15.CustomizationFormText = "EPF "
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem15.Text = "EPF (%)"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.seOverKgsRate
        Me.LayoutControlItem13.CustomizationFormText = "Over Kgs Rate"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem13.Text = "Over Kgs Rate"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.seOTRate
        Me.LayoutControlItem12.CustomizationFormText = "OT Rate"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(339, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(333, 24)
        Me.LayoutControlItem12.Text = "OT Rate"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.seCasualOTPayRate
        Me.LayoutControlItem17.CustomizationFormText = "Casual OT Pay Rate"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(339, 24)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(333, 24)
        Me.LayoutControlItem17.Text = "Casual OT Pay Rate"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.seKgsPerDay
        Me.LayoutControlItem2.CustomizationFormText = "Kgs per Day"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(339, 48)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(333, 24)
        Me.LayoutControlItem2.Text = "Kgs per Day"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(339, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(333, 24)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(82, 69)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(696, 377)
        Me.LayoutControlGroup2.Text = " "
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.gcUpdateRates
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(672, 334)
        Me.LayoutControlItem10.Text = "LayoutControlItem10"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextToControlDistance = 0
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem5})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(82, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(696, 69)
        Me.LayoutControlGroup3.Text = "Selection Area"
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnDisplay
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(583, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(89, 26)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.cmbDesignation
        Me.LayoutControlItem8.CustomizationFormText = "Designation"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(390, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(193, 26)
        Me.LayoutControlItem8.Text = "Designation"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.deEndDate
        Me.LayoutControlItem6.CustomizationFormText = "End Date"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(192, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(198, 26)
        Me.LayoutControlItem6.Text = "End Date"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.deStartDate
        Me.LayoutControlItem5.CustomizationFormText = "Start Date"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(192, 26)
        Me.LayoutControlItem5.Text = "Start Date"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(96, 13)
        '
        'frmUpdateRatesBulk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 627)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "frmUpdateRatesBulk"
        Me.Text = "Settings"
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.gcUpdateRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvUpdateRates, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbDesignation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seCasualOTPayRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seCasualPayRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seEPF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seOverKgsRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seKgsPerDay.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seOTRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seDayRate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpSearch, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents dxvpUpdate As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents seKgsPerDay As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seOTRate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seDayRate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seOverKgsRate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seEPF As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seCasualOTPayRate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seCasualPayRate As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmbDesignation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents btnDisplay As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcUpdateRates As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvUpdateRates As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents dxvpSearch As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
End Class
