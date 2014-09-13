<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDailyWorkings
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
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule5 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDisplaySelected = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.dxvpDailyWorking = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.leWorkCategory = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cmbDays = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblDeleteID = New DevExpress.XtraEditors.LabelControl()
        Me.lblCasualOTPayRate = New DevExpress.XtraEditors.LabelControl()
        Me.lblCasualPayRate = New DevExpress.XtraEditors.LabelControl()
        Me.lblEPF = New DevExpress.XtraEditors.LabelControl()
        Me.lblOverKgsRate = New DevExpress.XtraEditors.LabelControl()
        Me.leEmployee = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblOTRate = New DevExpress.XtraEditors.LabelControl()
        Me.lblDayRate = New DevExpress.XtraEditors.LabelControl()
        Me.seQuantity = New DevExpress.XtraEditors.SpinEdit()
        Me.lblKgsPerDay = New DevExpress.XtraEditors.LabelControl()
        Me.cmbWorkType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.gcDailyWorking = New DevExpress.XtraGrid.GridControl()
        Me.gvDailyWorking = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.deWorkingDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.gcAllWorkings = New DevExpress.XtraGrid.GridControl()
        Me.gvAllWorkings = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leWorkCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cmbDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deWorkingDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deWorkingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAllWorkings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAllWorkings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDisplaySelected), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose)})
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
        'bbDelete
        '
        Me.bbDelete.Caption = "Delete"
        Me.bbDelete.Id = 4
        Me.bbDelete.Name = "bbDelete"
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
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
        'leWorkCategory
        '
        Me.leWorkCategory.EnterMoveNextControl = True
        Me.leWorkCategory.Location = New System.Drawing.Point(157, 60)
        Me.leWorkCategory.MenuManager = Me.BarManager1
        Me.leWorkCategory.Name = "leWorkCategory"
        Me.leWorkCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leWorkCategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AbbreviationID", "AbbreviationID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AbbreviationDesc", "Work Category")})
        Me.leWorkCategory.Properties.NullText = ""
        Me.leWorkCategory.Size = New System.Drawing.Size(191, 20)
        Me.leWorkCategory.StyleController = Me.LayoutControl1
        Me.leWorkCategory.TabIndex = 2
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule4.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.leWorkCategory, ConditionValidationRule4)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cmbDays)
        Me.LayoutControl1.Controls.Add(Me.lblDeleteID)
        Me.LayoutControl1.Controls.Add(Me.lblCasualOTPayRate)
        Me.LayoutControl1.Controls.Add(Me.lblCasualPayRate)
        Me.LayoutControl1.Controls.Add(Me.lblEPF)
        Me.LayoutControl1.Controls.Add(Me.lblOverKgsRate)
        Me.LayoutControl1.Controls.Add(Me.leEmployee)
        Me.LayoutControl1.Controls.Add(Me.lblOTRate)
        Me.LayoutControl1.Controls.Add(Me.lblDayRate)
        Me.LayoutControl1.Controls.Add(Me.seQuantity)
        Me.LayoutControl1.Controls.Add(Me.lblKgsPerDay)
        Me.LayoutControl1.Controls.Add(Me.leWorkCategory)
        Me.LayoutControl1.Controls.Add(Me.cmbWorkType)
        Me.LayoutControl1.Controls.Add(Me.gcDailyWorking)
        Me.LayoutControl1.Controls.Add(Me.deWorkingDate)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cmbDays
        '
        Me.cmbDays.Location = New System.Drawing.Point(457, 36)
        Me.cmbDays.MenuManager = Me.BarManager1
        Me.cmbDays.Name = "cmbDays"
        Me.cmbDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbDays.Properties.Items.AddRange(New Object() {"0.5", "1.0"})
        Me.cmbDays.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbDays.Size = New System.Drawing.Size(192, 20)
        Me.cmbDays.StyleController = Me.LayoutControl1
        Me.cmbDays.TabIndex = 4
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.cmbDays, ConditionValidationRule1)
        '
        'lblDeleteID
        '
        Me.lblDeleteID.Appearance.BackColor = System.Drawing.Color.Yellow
        Me.lblDeleteID.Location = New System.Drawing.Point(260, 331)
        Me.lblDeleteID.Name = "lblDeleteID"
        Me.lblDeleteID.Size = New System.Drawing.Size(0, 13)
        Me.lblDeleteID.StyleController = Me.LayoutControl1
        Me.lblDeleteID.TabIndex = 20
        '
        'lblCasualOTPayRate
        '
        Me.lblCasualOTPayRate.Appearance.BackColor = System.Drawing.Color.Fuchsia
        Me.lblCasualOTPayRate.Location = New System.Drawing.Point(610, 331)
        Me.lblCasualOTPayRate.Name = "lblCasualOTPayRate"
        Me.lblCasualOTPayRate.Size = New System.Drawing.Size(63, 13)
        Me.lblCasualOTPayRate.StyleController = Me.LayoutControl1
        Me.lblCasualOTPayRate.TabIndex = 19
        '
        'lblCasualPayRate
        '
        Me.lblCasualPayRate.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCasualPayRate.Location = New System.Drawing.Point(567, 331)
        Me.lblCasualPayRate.Name = "lblCasualPayRate"
        Me.lblCasualPayRate.Size = New System.Drawing.Size(39, 13)
        Me.lblCasualPayRate.StyleController = Me.LayoutControl1
        Me.lblCasualPayRate.TabIndex = 18
        '
        'lblEPF
        '
        Me.lblEPF.Appearance.BackColor = System.Drawing.Color.Gray
        Me.lblEPF.Location = New System.Drawing.Point(480, 331)
        Me.lblEPF.Name = "lblEPF"
        Me.lblEPF.Size = New System.Drawing.Size(83, 13)
        Me.lblEPF.StyleController = Me.LayoutControl1
        Me.lblEPF.TabIndex = 17
        '
        'lblOverKgsRate
        '
        Me.lblOverKgsRate.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOverKgsRate.Location = New System.Drawing.Point(419, 331)
        Me.lblOverKgsRate.Name = "lblOverKgsRate"
        Me.lblOverKgsRate.Size = New System.Drawing.Size(57, 13)
        Me.lblOverKgsRate.StyleController = Me.LayoutControl1
        Me.lblOverKgsRate.TabIndex = 16
        '
        'leEmployee
        '
        Me.leEmployee.EnterMoveNextControl = True
        Me.leEmployee.Location = New System.Drawing.Point(457, 12)
        Me.leEmployee.MenuManager = Me.BarManager1
        Me.leEmployee.Name = "leEmployee"
        Me.leEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leEmployee.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.leEmployee.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerID", "EmployerID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerNo", "EmployerNo"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerName", "EmployerName")})
        Me.leEmployee.Properties.NullText = ""
        Me.leEmployee.Size = New System.Drawing.Size(192, 20)
        Me.leEmployee.StyleController = Me.LayoutControl1
        Me.leEmployee.TabIndex = 3
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.leEmployee, ConditionValidationRule2)
        '
        'lblOTRate
        '
        Me.lblOTRate.Appearance.BackColor = System.Drawing.Color.Teal
        Me.lblOTRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblOTRate.Location = New System.Drawing.Point(123, 331)
        Me.lblOTRate.Name = "lblOTRate"
        Me.lblOTRate.Size = New System.Drawing.Size(133, 13)
        Me.lblOTRate.StyleController = Me.LayoutControl1
        Me.lblOTRate.TabIndex = 13
        '
        'lblDayRate
        '
        Me.lblDayRate.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblDayRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDayRate.Location = New System.Drawing.Point(24, 331)
        Me.lblDayRate.Name = "lblDayRate"
        Me.lblDayRate.Size = New System.Drawing.Size(95, 13)
        Me.lblDayRate.StyleController = Me.LayoutControl1
        Me.lblDayRate.TabIndex = 12
        '
        'seQuantity
        '
        Me.seQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seQuantity.EnterMoveNextControl = True
        Me.seQuantity.Location = New System.Drawing.Point(457, 60)
        Me.seQuantity.MenuManager = Me.BarManager1
        Me.seQuantity.Name = "seQuantity"
        Me.seQuantity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seQuantity.Size = New System.Drawing.Size(192, 20)
        Me.seQuantity.StyleController = Me.LayoutControl1
        Me.seQuantity.TabIndex = 6
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.seQuantity, ConditionValidationRule3)
        '
        'lblKgsPerDay
        '
        Me.lblKgsPerDay.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblKgsPerDay.Location = New System.Drawing.Point(264, 347)
        Me.lblKgsPerDay.Name = "lblKgsPerDay"
        Me.lblKgsPerDay.Size = New System.Drawing.Size(151, 13)
        Me.lblKgsPerDay.StyleController = Me.LayoutControl1
        Me.lblKgsPerDay.TabIndex = 15
        '
        'cmbWorkType
        '
        Me.cmbWorkType.EnterMoveNextControl = True
        Me.cmbWorkType.Location = New System.Drawing.Point(157, 36)
        Me.cmbWorkType.MenuManager = Me.BarManager1
        Me.cmbWorkType.Name = "cmbWorkType"
        Me.cmbWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWorkType.Properties.Items.AddRange(New Object() {"CASUAL", "PERMENANT"})
        Me.cmbWorkType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbWorkType.Size = New System.Drawing.Size(191, 20)
        Me.cmbWorkType.StyleController = Me.LayoutControl1
        Me.cmbWorkType.TabIndex = 1
        ConditionValidationRule5.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule5.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.cmbWorkType, ConditionValidationRule5)
        '
        'gcDailyWorking
        '
        Me.gcDailyWorking.Location = New System.Drawing.Point(52, 84)
        Me.gcDailyWorking.MainView = Me.gvDailyWorking
        Me.gcDailyWorking.MenuManager = Me.BarManager1
        Me.gcDailyWorking.Name = "gcDailyWorking"
        Me.gcDailyWorking.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.gcDailyWorking.Size = New System.Drawing.Size(597, 212)
        Me.gcDailyWorking.TabIndex = 7
        Me.gcDailyWorking.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDailyWorking})
        '
        'gvDailyWorking
        '
        Me.gvDailyWorking.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn16})
        Me.gvDailyWorking.GridControl = Me.gcDailyWorking
        Me.gvDailyWorking.Name = "gvDailyWorking"
        Me.gvDailyWorking.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "DailyWorkingID"
        Me.GridColumn1.FieldName = "DailyWorkingID"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowFocus = False
        Me.GridColumn1.OptionsColumn.AllowSize = False
        Me.GridColumn1.Width = 106
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Date"
        Me.GridColumn2.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "WorkingDate"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.AllowFocus = False
        Me.GridColumn2.OptionsColumn.AllowSize = False
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 76
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Work Type"
        Me.GridColumn3.FieldName = "WorkType"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowFocus = False
        Me.GridColumn3.OptionsColumn.AllowSize = False
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 76
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Work Category"
        Me.GridColumn4.FieldName = "AbbreviationDesc"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowFocus = False
        Me.GridColumn4.OptionsColumn.AllowSize = False
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 76
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Employee No"
        Me.GridColumn5.FieldName = "EmployerNo"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.AllowFocus = False
        Me.GridColumn5.OptionsColumn.AllowSize = False
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 45
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Employee Name"
        Me.GridColumn6.FieldName = "EmployerName"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.AllowFocus = False
        Me.GridColumn6.OptionsColumn.AllowSize = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 122
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Days"
        Me.GridColumn7.FieldName = "WorkedDays"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.AllowFocus = False
        Me.GridColumn7.OptionsColumn.AllowSize = False
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 64
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Quantity"
        Me.GridColumn8.FieldName = "Quantity"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.AllowFocus = False
        Me.GridColumn8.OptionsColumn.AllowSize = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 84
        '
        'GridColumn16
        '
        Me.GridColumn16.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 7
        Me.GridColumn16.Width = 36
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", 20, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Global.iStock.My.Resources.Resources.remove, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        '
        'deWorkingDate
        '
        Me.deWorkingDate.EditValue = Nothing
        Me.deWorkingDate.EnterMoveNextControl = True
        Me.deWorkingDate.Location = New System.Drawing.Point(157, 12)
        Me.deWorkingDate.MenuManager = Me.BarManager1
        Me.deWorkingDate.Name = "deWorkingDate"
        Me.deWorkingDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deWorkingDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deWorkingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deWorkingDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deWorkingDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deWorkingDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deWorkingDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deWorkingDate.Size = New System.Drawing.Size(191, 20)
        Me.deWorkingDate.StyleController = Me.LayoutControl1
        Me.deWorkingDate.TabIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem4, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlGroup3, Me.LayoutControlItem11, Me.LayoutControlItem8, Me.LayoutControlItem6})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.deWorkingDate
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(40, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem1.Text = "Date"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(102, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(641, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(36, 288)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(40, 288)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem4"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcDailyWorking
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(40, 72)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(601, 216)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmbWorkType
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(40, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem3.Text = "Work Type"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.leWorkCategory
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(40, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(300, 24)
        Me.LayoutControlItem4.Text = "Work Category"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem10, Me.LayoutControlItem9, Me.LayoutControlItem16, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem21})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 288)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(677, 76)
        Me.LayoutControlGroup3.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lblOTRate
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(99, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(137, 33)
        Me.LayoutControlItem10.Text = "LayoutControlItem10"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextToControlDistance = 0
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.lblDayRate
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(99, 33)
        Me.LayoutControlItem9.Text = "LayoutControlItem9"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextToControlDistance = 0
        Me.LayoutControlItem9.TextVisible = False
        Me.LayoutControlItem9.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.lblKgsPerDay
        Me.LayoutControlItem16.CustomizationFormText = "LayoutControlItem16"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(240, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(155, 33)
        Me.LayoutControlItem16.Text = "LayoutControlItem16"
        Me.LayoutControlItem16.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.lblOverKgsRate
        Me.LayoutControlItem17.CustomizationFormText = "LayoutControlItem17"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(395, 0)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(61, 33)
        Me.LayoutControlItem17.Text = "LayoutControlItem17"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextToControlDistance = 0
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.lblEPF
        Me.LayoutControlItem18.CustomizationFormText = "LayoutControlItem18"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(456, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(87, 33)
        Me.LayoutControlItem18.Text = "LayoutControlItem18"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem18.TextToControlDistance = 0
        Me.LayoutControlItem18.TextVisible = False
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.lblCasualPayRate
        Me.LayoutControlItem19.CustomizationFormText = "LayoutControlItem19"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(543, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(43, 33)
        Me.LayoutControlItem19.Text = "LayoutControlItem19"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextToControlDistance = 0
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.lblCasualOTPayRate
        Me.LayoutControlItem20.CustomizationFormText = "LayoutControlItem20"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(586, 0)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(67, 33)
        Me.LayoutControlItem20.Text = "LayoutControlItem20"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem20.TextToControlDistance = 0
        Me.LayoutControlItem20.TextVisible = False
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.lblDeleteID
        Me.LayoutControlItem21.CustomizationFormText = "LayoutControlItem21"
        Me.LayoutControlItem21.Location = New System.Drawing.Point(236, 0)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(4, 33)
        Me.LayoutControlItem21.Text = "LayoutControlItem21"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem21.TextToControlDistance = 0
        Me.LayoutControlItem21.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.leEmployee
        Me.LayoutControlItem11.CustomizationFormText = "Employee"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(340, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(301, 24)
        Me.LayoutControlItem11.Text = "Employee"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.seQuantity
        Me.LayoutControlItem8.CustomizationFormText = "Quantity"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(340, 48)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(301, 24)
        Me.LayoutControlItem8.Text = "Quantity"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(102, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.cmbDays
        Me.LayoutControlItem6.CustomizationFormText = "Days"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(340, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(301, 24)
        Me.LayoutControlItem6.Text = "Days"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(102, 13)
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
        Me.LayoutControl2.Controls.Add(Me.LayoutControl4)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.btnDisplay)
        Me.LayoutControl4.Controls.Add(Me.deEndDate)
        Me.LayoutControl4.Controls.Add(Me.deStartDate)
        Me.LayoutControl4.Controls.Add(Me.gcAllWorkings)
        Me.LayoutControl4.Location = New System.Drawing.Point(12, 12)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.Root = Me.Root
        Me.LayoutControl4.Size = New System.Drawing.Size(673, 360)
        Me.LayoutControl4.TabIndex = 4
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(417, 36)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(146, 26)
        Me.btnDisplay.TabIndex = 7
        Me.btnDisplay.Text = "Display"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Location = New System.Drawing.Point(270, 36)
        Me.deEndDate.MenuManager = Me.BarManager1
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deEndDate.Size = New System.Drawing.Size(143, 20)
        Me.deEndDate.StyleController = Me.LayoutControl4
        Me.deEndDate.TabIndex = 6
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(70, 36)
        Me.deStartDate.MenuManager = Me.BarManager1
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deStartDate.Size = New System.Drawing.Size(143, 20)
        Me.deStartDate.StyleController = Me.LayoutControl4
        Me.deStartDate.TabIndex = 5
        '
        'gcAllWorkings
        '
        Me.gcAllWorkings.Location = New System.Drawing.Point(12, 71)
        Me.gcAllWorkings.MainView = Me.gvAllWorkings
        Me.gcAllWorkings.MenuManager = Me.BarManager1
        Me.gcAllWorkings.Name = "gcAllWorkings"
        Me.gcAllWorkings.Size = New System.Drawing.Size(649, 277)
        Me.gcAllWorkings.TabIndex = 4
        Me.gcAllWorkings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAllWorkings})
        '
        'gvAllWorkings
        '
        Me.gvAllWorkings.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15})
        Me.gvAllWorkings.GridControl = Me.gcAllWorkings
        Me.gvAllWorkings.Name = "gvAllWorkings"
        Me.gvAllWorkings.OptionsView.EnableAppearanceEvenRow = True
        Me.gvAllWorkings.OptionsView.ShowAutoFilterRow = True
        Me.gvAllWorkings.OptionsView.ShowFooter = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Working Date"
        Me.GridColumn9.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn9.FieldName = "WorkingDate"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowFocus = False
        Me.GridColumn9.OptionsColumn.AllowMove = False
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "WorkType"
        Me.GridColumn10.FieldName = "WorkType"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.AllowFocus = False
        Me.GridColumn10.OptionsColumn.AllowMove = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Work Category"
        Me.GridColumn11.FieldName = "AbbreviationDesc"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowFocus = False
        Me.GridColumn11.OptionsColumn.AllowMove = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Employee Code"
        Me.GridColumn12.FieldName = "EmployerNo"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.OptionsColumn.AllowFocus = False
        Me.GridColumn12.OptionsColumn.AllowMove = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "EmployerName"
        Me.GridColumn13.FieldName = "EmployerName"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.AllowFocus = False
        Me.GridColumn13.OptionsColumn.AllowMove = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "WorkedDays"
        Me.GridColumn14.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "WorkedDays"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.AllowFocus = False
        Me.GridColumn14.OptionsColumn.AllowMove = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WorkedDays", "{0:n2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 5
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Quantity"
        Me.GridColumn15.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "Quantity"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.AllowFocus = False
        Me.GridColumn15.OptionsColumn.AllowMove = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 6
        '
        'Root
        '
        Me.Root.CustomizationFormText = "Root"
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12, Me.LayoutControlGroup4})
        Me.Root.Location = New System.Drawing.Point(0, 0)
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(673, 360)
        Me.Root.Text = "Root"
        Me.Root.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.gcAllWorkings
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(0, 59)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(653, 281)
        Me.LayoutControlItem12.Text = "LayoutControlItem12"
        Me.LayoutControlItem12.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextToControlDistance = 0
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Select date range"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15, Me.EmptySpaceItem1, Me.LayoutControlItem14, Me.LayoutControlItem13})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2)
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(653, 59)
        Me.LayoutControlGroup4.Text = "Select date range"
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.btnDisplay
        Me.LayoutControlItem15.CustomizationFormText = "LayoutControlItem15"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(400, 0)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(150, 50)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(150, 30)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(150, 30)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Text = "LayoutControlItem15"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextToControlDistance = 0
        Me.LayoutControlItem15.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(550, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(93, 30)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.deEndDate
        Me.LayoutControlItem14.CustomizationFormText = "LayoutControlItem14"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(200, 0)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(200, 30)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "End Date"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.deStartDate
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(200, 30)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "Start Date"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(50, 13)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(697, 384)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup2"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.LayoutControl4
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(677, 364)
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'DateEdit1
        '
        Me.DateEdit1.EditValue = Nothing
        Me.DateEdit1.Location = New System.Drawing.Point(0, 0)
        Me.DateEdit1.MenuManager = Me.BarManager1
        Me.DateEdit1.Name = "DateEdit1"
        Me.DateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.DateEdit1.Size = New System.Drawing.Size(100, 20)
        Me.DateEdit1.TabIndex = 2
        '
        'frmDailyWorkings
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
        Me.Name = "frmDailyWorkings"
        Me.Text = "Daily Workings"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpDailyWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leWorkCategory.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cmbDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDailyWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDailyWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deWorkingDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deWorkingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAllWorkings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAllWorkings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dxvpDailyWorking As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents leWorkCategory As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents cmbWorkType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents gcDailyWorking As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvDailyWorking As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents deWorkingDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents seQuantity As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblDayRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblOTRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents leEmployee As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents gcAllWorkings As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAllWorkings As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents lblOverKgsRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblKgsPerDay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblEPF As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblCasualOTPayRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblCasualPayRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents lblDeleteID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents cmbDays As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
End Class
