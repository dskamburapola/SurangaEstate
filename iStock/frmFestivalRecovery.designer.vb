<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFestivalRecovery
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
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
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
        Me.dxvpCashAdvance = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.sePaybleAmount = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.leFestival = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblDeleteID = New System.Windows.Forms.Label()
        Me.cmbWorkType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.leEmployee = New DevExpress.XtraEditors.LookUpEdit()
        Me.deIssueDate = New DevExpress.XtraEditors.DateEdit()
        Me.teEmployeeName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem9 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem10 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem11 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem12 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem13 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem14 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem15 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem16 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem17 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.xTab1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.gcCashAdvance = New DevExpress.XtraGrid.GridControl()
        Me.gvCashAdvance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpCashAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sePaybleAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.leFestival.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deIssueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deIssueDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teEmployeeName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xTab1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.gcCashAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCashAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.barDockControlTop.Size = New System.Drawing.Size(857, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 434)
        Me.barDockControlBottom.Size = New System.Drawing.Size(857, 0)
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
        Me.barDockControlRight.Location = New System.Drawing.Point(857, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 412)
        '
        'sePaybleAmount
        '
        Me.sePaybleAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.sePaybleAmount.Location = New System.Drawing.Point(277, 166)
        Me.sePaybleAmount.MenuManager = Me.BarManager1
        Me.sePaybleAmount.Name = "sePaybleAmount"
        Me.sePaybleAmount.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.sePaybleAmount.Properties.Appearance.Options.UseFont = True
        Me.sePaybleAmount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.sePaybleAmount.Properties.DisplayFormat.FormatString = "{0:N2}"
        Me.sePaybleAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.sePaybleAmount.Size = New System.Drawing.Size(375, 30)
        Me.sePaybleAmount.StyleController = Me.LayoutControl1
        Me.sePaybleAmount.TabIndex = 16
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.NotEquals
        ConditionValidationRule1.ErrorText = "This value is not valid"
        ConditionValidationRule1.Value1 = "0"
        Me.dxvpCashAdvance.SetValidationRule(Me.sePaybleAmount, ConditionValidationRule1)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.leFestival)
        Me.LayoutControl1.Controls.Add(Me.lblDeleteID)
        Me.LayoutControl1.Controls.Add(Me.cmbWorkType)
        Me.LayoutControl1.Controls.Add(Me.sePaybleAmount)
        Me.LayoutControl1.Controls.Add(Me.leEmployee)
        Me.LayoutControl1.Controls.Add(Me.deIssueDate)
        Me.LayoutControl1.Controls.Add(Me.teEmployeeName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(851, 384)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'leFestival
        '
        Me.leFestival.Location = New System.Drawing.Point(277, 46)
        Me.leFestival.MenuManager = Me.BarManager1
        Me.leFestival.Name = "leFestival"
        Me.leFestival.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leFestival.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TermDeductionID", "TermDeductionID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TDdescription", "Employee Info"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerID", "EmployerID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Remarks", "Description")})
        Me.leFestival.Properties.NullText = ""
        Me.leFestival.Size = New System.Drawing.Size(375, 20)
        Me.leFestival.StyleController = Me.LayoutControl1
        Me.leFestival.TabIndex = 28
        '
        'lblDeleteID
        '
        Me.lblDeleteID.Location = New System.Drawing.Point(12, 12)
        Me.lblDeleteID.Name = "lblDeleteID"
        Me.lblDeleteID.Size = New System.Drawing.Size(827, 20)
        Me.lblDeleteID.TabIndex = 27
        '
        'cmbWorkType
        '
        Me.cmbWorkType.Location = New System.Drawing.Point(277, 70)
        Me.cmbWorkType.MenuManager = Me.BarManager1
        Me.cmbWorkType.Name = "cmbWorkType"
        Me.cmbWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWorkType.Properties.Items.AddRange(New Object() {"CASUAL", "PERMANENT", "STAFF"})
        Me.cmbWorkType.Size = New System.Drawing.Size(375, 20)
        Me.cmbWorkType.StyleController = Me.LayoutControl1
        Me.cmbWorkType.TabIndex = 26
        '
        'leEmployee
        '
        Me.leEmployee.Location = New System.Drawing.Point(277, 118)
        Me.leEmployee.MenuManager = Me.BarManager1
        Me.leEmployee.Name = "leEmployee"
        Me.leEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leEmployee.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerID", "EmployerID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerNo", "Employee No"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerName", "Employer Name")})
        Me.leEmployee.Properties.NullText = ""
        Me.leEmployee.Size = New System.Drawing.Size(375, 20)
        Me.leEmployee.StyleController = Me.LayoutControl1
        Me.leEmployee.TabIndex = 13
        '
        'deIssueDate
        '
        Me.deIssueDate.EditValue = Nothing
        Me.deIssueDate.EnterMoveNextControl = True
        Me.deIssueDate.Location = New System.Drawing.Point(277, 94)
        Me.deIssueDate.MenuManager = Me.BarManager1
        Me.deIssueDate.Name = "deIssueDate"
        Me.deIssueDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deIssueDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deIssueDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deIssueDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deIssueDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deIssueDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deIssueDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deIssueDate.Size = New System.Drawing.Size(375, 20)
        Me.deIssueDate.StyleController = Me.LayoutControl1
        Me.deIssueDate.TabIndex = 12
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "This value is not valid"
        Me.dxvpCashAdvance.SetValidationRule(Me.deIssueDate, ConditionValidationRule2)
        '
        'teEmployeeName
        '
        Me.teEmployeeName.EnterMoveNextControl = True
        Me.teEmployeeName.Location = New System.Drawing.Point(277, 142)
        Me.teEmployeeName.Name = "teEmployeeName"
        Me.teEmployeeName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.teEmployeeName.Properties.Appearance.Options.UseBackColor = True
        Me.teEmployeeName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teEmployeeName.Size = New System.Drawing.Size(375, 20)
        Me.teEmployeeName.StyleController = Me.LayoutControl1
        Me.teEmployeeName.TabIndex = 11
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.EmptySpaceItem7, Me.EmptySpaceItem8, Me.EmptySpaceItem9, Me.EmptySpaceItem10, Me.EmptySpaceItem11, Me.EmptySpaceItem12, Me.EmptySpaceItem13, Me.EmptySpaceItem14, Me.EmptySpaceItem15, Me.EmptySpaceItem16, Me.EmptySpaceItem17, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem13, Me.LayoutControlItem11, Me.LayoutControlItem19, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(851, 384)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 24)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(0, 31)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(831, 10)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(180, 190)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(651, 174)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(644, 170)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(187, 20)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.CustomizationFormText = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(644, 160)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(187, 10)
        Me.EmptySpaceItem5.Text = "EmptySpaceItem5"
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.CustomizationFormText = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(644, 150)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(187, 10)
        Me.EmptySpaceItem6.Text = "EmptySpaceItem6"
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.CustomizationFormText = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(644, 140)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(187, 10)
        Me.EmptySpaceItem7.Text = "EmptySpaceItem7"
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.CustomizationFormText = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(644, 130)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(187, 10)
        Me.EmptySpaceItem8.Text = "EmptySpaceItem8"
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem9
        '
        Me.EmptySpaceItem9.AllowHotTrack = False
        Me.EmptySpaceItem9.CustomizationFormText = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Location = New System.Drawing.Point(644, 34)
        Me.EmptySpaceItem9.Name = "EmptySpaceItem9"
        Me.EmptySpaceItem9.Size = New System.Drawing.Size(187, 96)
        Me.EmptySpaceItem9.Text = "EmptySpaceItem9"
        Me.EmptySpaceItem9.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem10
        '
        Me.EmptySpaceItem10.AllowHotTrack = False
        Me.EmptySpaceItem10.CustomizationFormText = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Location = New System.Drawing.Point(0, 190)
        Me.EmptySpaceItem10.Name = "EmptySpaceItem10"
        Me.EmptySpaceItem10.Size = New System.Drawing.Size(180, 174)
        Me.EmptySpaceItem10.Text = "EmptySpaceItem10"
        Me.EmptySpaceItem10.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem11
        '
        Me.EmptySpaceItem11.AllowHotTrack = False
        Me.EmptySpaceItem11.CustomizationFormText = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Location = New System.Drawing.Point(0, 180)
        Me.EmptySpaceItem11.Name = "EmptySpaceItem11"
        Me.EmptySpaceItem11.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem11.Text = "EmptySpaceItem11"
        Me.EmptySpaceItem11.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem12
        '
        Me.EmptySpaceItem12.AllowHotTrack = False
        Me.EmptySpaceItem12.CustomizationFormText = "EmptySpaceItem12"
        Me.EmptySpaceItem12.Location = New System.Drawing.Point(0, 170)
        Me.EmptySpaceItem12.Name = "EmptySpaceItem12"
        Me.EmptySpaceItem12.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem12.Text = "EmptySpaceItem12"
        Me.EmptySpaceItem12.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem13
        '
        Me.EmptySpaceItem13.AllowHotTrack = False
        Me.EmptySpaceItem13.CustomizationFormText = "EmptySpaceItem13"
        Me.EmptySpaceItem13.Location = New System.Drawing.Point(0, 160)
        Me.EmptySpaceItem13.Name = "EmptySpaceItem13"
        Me.EmptySpaceItem13.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem13.Text = "EmptySpaceItem13"
        Me.EmptySpaceItem13.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem14
        '
        Me.EmptySpaceItem14.AllowHotTrack = False
        Me.EmptySpaceItem14.CustomizationFormText = "EmptySpaceItem14"
        Me.EmptySpaceItem14.Location = New System.Drawing.Point(0, 150)
        Me.EmptySpaceItem14.Name = "EmptySpaceItem14"
        Me.EmptySpaceItem14.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem14.Text = "EmptySpaceItem14"
        Me.EmptySpaceItem14.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem15
        '
        Me.EmptySpaceItem15.AllowHotTrack = False
        Me.EmptySpaceItem15.CustomizationFormText = "EmptySpaceItem15"
        Me.EmptySpaceItem15.Location = New System.Drawing.Point(0, 140)
        Me.EmptySpaceItem15.Name = "EmptySpaceItem15"
        Me.EmptySpaceItem15.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem15.Text = "EmptySpaceItem15"
        Me.EmptySpaceItem15.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem16
        '
        Me.EmptySpaceItem16.AllowHotTrack = False
        Me.EmptySpaceItem16.CustomizationFormText = "EmptySpaceItem16"
        Me.EmptySpaceItem16.Location = New System.Drawing.Point(0, 130)
        Me.EmptySpaceItem16.Name = "EmptySpaceItem16"
        Me.EmptySpaceItem16.Size = New System.Drawing.Size(180, 10)
        Me.EmptySpaceItem16.Text = "EmptySpaceItem16"
        Me.EmptySpaceItem16.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem17
        '
        Me.EmptySpaceItem17.AllowHotTrack = False
        Me.EmptySpaceItem17.CustomizationFormText = "EmptySpaceItem17"
        Me.EmptySpaceItem17.Location = New System.Drawing.Point(0, 34)
        Me.EmptySpaceItem17.Name = "EmptySpaceItem17"
        Me.EmptySpaceItem17.Size = New System.Drawing.Size(180, 96)
        Me.EmptySpaceItem17.Text = "EmptySpaceItem17"
        Me.EmptySpaceItem17.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.teEmployeeName
        Me.LayoutControlItem8.CustomizationFormText = "Reg No"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(180, 130)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem8.Text = "Employee Name"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(82, 13)
        Me.LayoutControlItem8.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.deIssueDate
        Me.LayoutControlItem9.CustomizationFormText = "Issue Date"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(180, 82)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem9.Text = "Recovery Date"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.leEmployee
        Me.LayoutControlItem10.CustomizationFormText = "Employee Code"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(180, 106)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem10.Text = "Employee Code"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(82, 13)
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.sePaybleAmount
        Me.LayoutControlItem13.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(180, 154)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(464, 36)
        Me.LayoutControlItem13.Text = "Amount"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.cmbWorkType
        Me.LayoutControlItem11.CustomizationFormText = "WorkType"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(180, 58)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem11.Text = "WorkType"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(82, 13)
        Me.LayoutControlItem11.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.lblDeleteID
        Me.LayoutControlItem19.CustomizationFormText = "LayoutControlItem19"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(831, 24)
        Me.LayoutControlItem19.Text = "LayoutControlItem19"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem19.TextToControlDistance = 0
        Me.LayoutControlItem19.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.leFestival
        Me.LayoutControlItem1.CustomizationFormText = "Festival Advance"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(180, 34)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem1.Text = "Festival Advance"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(82, 13)
        '
        'xTab1
        '
        Me.xTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xTab1.Location = New System.Drawing.Point(0, 22)
        Me.xTab1.Name = "xTab1"
        Me.xTab1.SelectedTabPage = Me.XtraTabPage1
        Me.xTab1.Size = New System.Drawing.Size(857, 412)
        Me.xTab1.TabIndex = 9
        Me.xTab1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(851, 384)
        Me.XtraTabPage1.Text = "This Month Advance"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LayoutControl4)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(851, 384)
        Me.XtraTabPage2.Text = "History Data"
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.gcCashAdvance)
        Me.LayoutControl4.Controls.Add(Me.btnDisplay)
        Me.LayoutControl4.Controls.Add(Me.deEndDate)
        Me.LayoutControl4.Controls.Add(Me.deStartDate)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.Root = Me.Root
        Me.LayoutControl4.Size = New System.Drawing.Size(851, 384)
        Me.LayoutControl4.TabIndex = 5
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'gcCashAdvance
        '
        Me.gcCashAdvance.Location = New System.Drawing.Point(12, 81)
        Me.gcCashAdvance.MainView = Me.gvCashAdvance
        Me.gcCashAdvance.MenuManager = Me.BarManager1
        Me.gcCashAdvance.Name = "gcCashAdvance"
        Me.gcCashAdvance.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        Me.gcCashAdvance.Size = New System.Drawing.Size(827, 291)
        Me.gcCashAdvance.TabIndex = 3
        Me.gcCashAdvance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCashAdvance})
        '
        'gvCashAdvance
        '
        Me.gvCashAdvance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5})
        Me.gvCashAdvance.GridControl = Me.gcCashAdvance
        Me.gvCashAdvance.Name = "gvCashAdvance"
        Me.gvCashAdvance.OptionsView.EnableAppearanceOddRow = True
        Me.gvCashAdvance.OptionsView.ShowAutoFilterRow = True
        Me.gvCashAdvance.OptionsView.ShowFooter = True
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "FestivalRecoveryId"
        Me.GridColumn9.FieldName = "FestivalRecoveryId"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.OptionsColumn.AllowFocus = False
        Me.GridColumn9.OptionsColumn.AllowMove = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "EmployerId"
        Me.GridColumn10.FieldName = "EmployerId"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.AllowFocus = False
        Me.GridColumn10.OptionsColumn.AllowMove = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Issue Date"
        Me.GridColumn11.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn11.FieldName = "IssueDate"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.OptionsColumn.AllowFocus = False
        Me.GridColumn11.OptionsColumn.AllowMove = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
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
        Me.GridColumn12.VisibleIndex = 2
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Employee Name"
        Me.GridColumn13.FieldName = "EmployerName"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.OptionsColumn.AllowFocus = False
        Me.GridColumn13.OptionsColumn.AllowMove = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Amount"
        Me.GridColumn14.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "AdvanceAmount"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.OptionsColumn.AllowFocus = False
        Me.GridColumn14.OptionsColumn.AllowMove = False
        Me.GridColumn14.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WorkedDays", "{0:n2}")})
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "CreatedBy"
        Me.GridColumn15.FieldName = "CreatedUser"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.AllowEdit = False
        Me.GridColumn15.OptionsColumn.AllowFocus = False
        Me.GridColumn15.OptionsColumn.AllowMove = False
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n2}")})
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "CreatedDate"
        Me.GridColumn1.FieldName = "CreatedDate"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "UpdatedBy"
        Me.GridColumn2.FieldName = "UpdatedUser"
        Me.GridColumn2.Name = "GridColumn2"
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "UpdatedDate"
        Me.GridColumn3.FieldName = "UpdatedDate"
        Me.GridColumn3.Name = "GridColumn3"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "GridColumn4"
        Me.GridColumn4.ColumnEdit = Me.RepositoryItemButtonEdit1
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 5
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Delete", 20, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Global.iStock.My.Resources.Resources.remove, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        Me.RepositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Description"
        Me.GridColumn5.FieldName = "Description"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(324, 43)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(146, 22)
        Me.btnDisplay.TabIndex = 2
        Me.btnDisplay.Text = "Process"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Location = New System.Drawing.Point(201, 43)
        Me.deEndDate.MenuManager = Me.BarManager1
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deEndDate.Size = New System.Drawing.Size(119, 20)
        Me.deEndDate.StyleController = Me.LayoutControl4
        Me.deEndDate.TabIndex = 1
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(51, 43)
        Me.deStartDate.MenuManager = Me.BarManager1
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deStartDate.Size = New System.Drawing.Size(119, 20)
        Me.deStartDate.StyleController = Me.LayoutControl4
        Me.deStartDate.TabIndex = 0
        '
        'Root
        '
        Me.Root.CustomizationFormText = "Root"
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup2, Me.EmptySpaceItem4, Me.LayoutControlItem14})
        Me.Root.Location = New System.Drawing.Point(0, 0)
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(851, 384)
        Me.Root.Text = "Root"
        Me.Root.TextVisible = False
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Select Date Range"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem17, Me.LayoutControlItem15, Me.LayoutControlItem16})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(474, 69)
        Me.LayoutControlGroup2.Text = "Select Date Range"
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.btnDisplay
        Me.LayoutControlItem17.CustomizationFormText = "LayoutControlItem15"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(300, 0)
        Me.LayoutControlItem17.MaxSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem17.MinSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem17.Name = "LayoutControlItem15"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem17.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem17.Text = "Select Date Range"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem17.TextToControlDistance = 0
        Me.LayoutControlItem17.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.deEndDate
        Me.LayoutControlItem15.CustomizationFormText = "LayoutControlItem14"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(150, 0)
        Me.LayoutControlItem15.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem15.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem15.Name = "LayoutControlItem14"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem15.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem15.Text = "To"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(24, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.deStartDate
        Me.LayoutControlItem16.CustomizationFormText = "LayoutControlItem13"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem16.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem16.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem16.Name = "LayoutControlItem13"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem16.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem16.Text = "From"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(24, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(474, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(357, 69)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem4"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.gcCashAdvance
        Me.LayoutControlItem14.CustomizationFormText = "LayoutControlItem14"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 69)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(831, 295)
        Me.LayoutControlItem14.Text = "LayoutControlItem14"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextToControlDistance = 0
        Me.LayoutControlItem14.TextVisible = False
        '
        'frmFestivalRecovery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 434)
        Me.Controls.Add(Me.xTab1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "frmFestivalRecovery"
        Me.Text = "Festival Advance Recovery"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpCashAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sePaybleAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.leFestival.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deIssueDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deIssueDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teEmployeeName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xTab1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.gcCashAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCashAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dxvpCashAdvance As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents xTab1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents sePaybleAmount As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents leEmployee As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents deIssueDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents teEmployeeName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem9 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem10 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem11 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem12 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem13 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem14 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem15 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem16 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem17 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents gcCashAdvance As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCashAdvance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cmbWorkType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents lblDeleteID As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents leFestival As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
End Class
