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
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule4 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
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
        Me.gcHoliday = New DevExpress.XtraGrid.GridControl()
        Me.gvHoliday = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblLowerKgRate = New DevExpress.XtraEditors.LabelControl()
        Me.lblSmokingSheetsPayRate = New System.Windows.Forms.Label()
        Me.lblLowerSheetsRate = New System.Windows.Forms.Label()
        Me.lblOverSheetsRate = New System.Windows.Forms.Label()
        Me.lblOverSheetsUpperLimit = New System.Windows.Forms.Label()
        Me.lblSheetsPerDay = New System.Windows.Forms.Label()
        Me.seOTHours = New DevExpress.XtraEditors.SpinEdit()
        Me.lblOverKgUpperLimit = New DevExpress.XtraEditors.LabelControl()
        Me.lblETF = New DevExpress.XtraEditors.LabelControl()
        Me.lblDeleteID = New DevExpress.XtraEditors.LabelControl()
        Me.lblKgsPerDayNotMandatory = New DevExpress.XtraEditors.LabelControl()
        Me.leStock = New DevExpress.XtraEditors.LookUpEdit()
        Me.lblPayChit = New DevExpress.XtraEditors.LabelControl()
        Me.lblIncentiveRate = New DevExpress.XtraEditors.LabelControl()
        Me.lblIncentiveDays = New DevExpress.XtraEditors.LabelControl()
        Me.lblWCPay = New DevExpress.XtraEditors.LabelControl()
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
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemButtonEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.RepositoryItemImageEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit()
        Me.deWorkingDate = New DevExpress.XtraEditors.DateEdit()
        Me.seDays = New DevExpress.XtraEditors.SpinEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.deStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.deEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.btnDisplay = New System.Windows.Forms.Button()
        Me.gcAllWorkings = New DevExpress.XtraGrid.GridControl()
        Me.gvAllWorkings = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.DateEdit1 = New DevExpress.XtraEditors.DateEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leWorkCategory.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.gcHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvHoliday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seOTHours.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leStock.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seQuantity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDailyWorking, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deWorkingDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deWorkingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seDays.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcAllWorkings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvAllWorkings, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
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
        Me.barDockControlTop.Size = New System.Drawing.Size(846, 22)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 610)
        Me.barDockControlBottom.Size = New System.Drawing.Size(846, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 588)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(846, 22)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 588)
        '
        'leWorkCategory
        '
        Me.leWorkCategory.EnterMoveNextControl = True
        Me.leWorkCategory.Location = New System.Drawing.Point(195, 60)
        Me.leWorkCategory.MenuManager = Me.BarManager1
        Me.leWorkCategory.Name = "leWorkCategory"
        Me.leWorkCategory.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leWorkCategory.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AbbreviationID", "AbbreviationID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("AbbreviationDesc", "Work Category")})
        Me.leWorkCategory.Properties.NullText = ""
        Me.leWorkCategory.Size = New System.Drawing.Size(172, 20)
        Me.leWorkCategory.StyleController = Me.LayoutControl1
        Me.leWorkCategory.TabIndex = 2
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.leWorkCategory, ConditionValidationRule3)
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.gcHoliday)
        Me.LayoutControl1.Controls.Add(Me.lblLowerKgRate)
        Me.LayoutControl1.Controls.Add(Me.lblSmokingSheetsPayRate)
        Me.LayoutControl1.Controls.Add(Me.lblLowerSheetsRate)
        Me.LayoutControl1.Controls.Add(Me.lblOverSheetsRate)
        Me.LayoutControl1.Controls.Add(Me.lblOverSheetsUpperLimit)
        Me.LayoutControl1.Controls.Add(Me.lblSheetsPerDay)
        Me.LayoutControl1.Controls.Add(Me.seOTHours)
        Me.LayoutControl1.Controls.Add(Me.lblOverKgUpperLimit)
        Me.LayoutControl1.Controls.Add(Me.lblETF)
        Me.LayoutControl1.Controls.Add(Me.lblDeleteID)
        Me.LayoutControl1.Controls.Add(Me.lblKgsPerDayNotMandatory)
        Me.LayoutControl1.Controls.Add(Me.leStock)
        Me.LayoutControl1.Controls.Add(Me.lblPayChit)
        Me.LayoutControl1.Controls.Add(Me.lblIncentiveRate)
        Me.LayoutControl1.Controls.Add(Me.lblIncentiveDays)
        Me.LayoutControl1.Controls.Add(Me.lblWCPay)
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
        Me.LayoutControl1.Controls.Add(Me.seDays)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsFocus.EnableAutoTabOrder = False
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(840, 560)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'gcHoliday
        '
        Me.gcHoliday.Location = New System.Drawing.Point(181, 409)
        Me.gcHoliday.MainView = Me.gvHoliday
        Me.gcHoliday.MenuManager = Me.BarManager1
        Me.gcHoliday.Name = "gcHoliday"
        Me.gcHoliday.Size = New System.Drawing.Size(647, 139)
        Me.gcHoliday.TabIndex = 38
        Me.gcHoliday.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvHoliday})
        '
        'gvHoliday
        '
        Me.gvHoliday.GridControl = Me.gcHoliday
        Me.gvHoliday.Name = "gvHoliday"
        '
        'lblLowerKgRate
        '
        Me.lblLowerKgRate.Location = New System.Drawing.Point(209, 437)
        Me.lblLowerKgRate.Name = "lblLowerKgRate"
        Me.lblLowerKgRate.Size = New System.Drawing.Size(64, 13)
        Me.lblLowerKgRate.StyleController = Me.LayoutControl1
        Me.lblLowerKgRate.TabIndex = 36
        Me.lblLowerKgRate.Text = "LowerKgRate"
        '
        'lblSmokingSheetsPayRate
        '
        Me.lblSmokingSheetsPayRate.Location = New System.Drawing.Point(209, 354)
        Me.lblSmokingSheetsPayRate.Name = "lblSmokingSheetsPayRate"
        Me.lblSmokingSheetsPayRate.Size = New System.Drawing.Size(64, 79)
        Me.lblSmokingSheetsPayRate.TabIndex = 35
        Me.lblSmokingSheetsPayRate.Text = "SmokingSheetsPayRate"
        '
        'lblLowerSheetsRate
        '
        Me.lblLowerSheetsRate.Location = New System.Drawing.Point(277, 497)
        Me.lblLowerSheetsRate.Name = "lblLowerSheetsRate"
        Me.lblLowerSheetsRate.Size = New System.Drawing.Size(527, 20)
        Me.lblLowerSheetsRate.TabIndex = 34
        Me.lblLowerSheetsRate.Text = "LowerSheetsRate"
        '
        'lblOverSheetsRate
        '
        Me.lblOverSheetsRate.Location = New System.Drawing.Point(12, 497)
        Me.lblOverSheetsRate.Name = "lblOverSheetsRate"
        Me.lblOverSheetsRate.Size = New System.Drawing.Size(193, 20)
        Me.lblOverSheetsRate.TabIndex = 33
        Me.lblOverSheetsRate.Text = "OverSheetsRate"
        '
        'lblOverSheetsUpperLimit
        '
        Me.lblOverSheetsUpperLimit.Location = New System.Drawing.Point(277, 473)
        Me.lblOverSheetsUpperLimit.Name = "lblOverSheetsUpperLimit"
        Me.lblOverSheetsUpperLimit.Size = New System.Drawing.Size(527, 20)
        Me.lblOverSheetsUpperLimit.TabIndex = 32
        Me.lblOverSheetsUpperLimit.Text = "OverSheetsUpperLimit"
        '
        'lblSheetsPerDay
        '
        Me.lblSheetsPerDay.Location = New System.Drawing.Point(12, 473)
        Me.lblSheetsPerDay.Name = "lblSheetsPerDay"
        Me.lblSheetsPerDay.Size = New System.Drawing.Size(193, 20)
        Me.lblSheetsPerDay.TabIndex = 31
        Me.lblSheetsPerDay.Text = "SheetsPerDay"
        '
        'seOTHours
        '
        Me.seOTHours.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seOTHours.EnterMoveNextControl = True
        Me.seOTHours.Location = New System.Drawing.Point(768, 36)
        Me.seOTHours.MenuManager = Me.BarManager1
        Me.seOTHours.Name = "seOTHours"
        Me.seOTHours.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seOTHours.Size = New System.Drawing.Size(50, 20)
        Me.seOTHours.StyleController = Me.LayoutControl1
        Me.seOTHours.TabIndex = 5
        '
        'lblOverKgUpperLimit
        '
        Me.lblOverKgUpperLimit.Location = New System.Drawing.Point(446, 439)
        Me.lblOverKgUpperLimit.Name = "lblOverKgUpperLimit"
        Me.lblOverKgUpperLimit.Size = New System.Drawing.Size(358, 13)
        Me.lblOverKgUpperLimit.StyleController = Me.LayoutControl1
        Me.lblOverKgUpperLimit.TabIndex = 30
        '
        'lblETF
        '
        Me.lblETF.Location = New System.Drawing.Point(446, 456)
        Me.lblETF.Name = "lblETF"
        Me.lblETF.Size = New System.Drawing.Size(358, 13)
        Me.lblETF.StyleController = Me.LayoutControl1
        Me.lblETF.TabIndex = 29
        '
        'lblDeleteID
        '
        Me.lblDeleteID.Location = New System.Drawing.Point(181, 392)
        Me.lblDeleteID.Name = "lblDeleteID"
        Me.lblDeleteID.Size = New System.Drawing.Size(647, 13)
        Me.lblDeleteID.StyleController = Me.LayoutControl1
        Me.lblDeleteID.TabIndex = 28
        '
        'lblKgsPerDayNotMandatory
        '
        Me.lblKgsPerDayNotMandatory.Location = New System.Drawing.Point(446, 371)
        Me.lblKgsPerDayNotMandatory.Name = "lblKgsPerDayNotMandatory"
        Me.lblKgsPerDayNotMandatory.Size = New System.Drawing.Size(358, 13)
        Me.lblKgsPerDayNotMandatory.StyleController = Me.LayoutControl1
        Me.lblKgsPerDayNotMandatory.TabIndex = 27
        '
        'leStock
        '
        Me.leStock.Location = New System.Drawing.Point(768, 60)
        Me.leStock.MenuManager = Me.BarManager1
        Me.leStock.Name = "leStock"
        Me.leStock.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leStock.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("StockCode", "Stock Code"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "Description")})
        Me.leStock.Properties.NullText = ""
        Me.leStock.Size = New System.Drawing.Size(50, 20)
        Me.leStock.StyleController = Me.LayoutControl1
        Me.leStock.TabIndex = 25
        '
        'lblPayChit
        '
        Me.lblPayChit.Location = New System.Drawing.Point(181, 422)
        Me.lblPayChit.Name = "lblPayChit"
        Me.lblPayChit.Size = New System.Drawing.Size(24, 13)
        Me.lblPayChit.StyleController = Me.LayoutControl1
        Me.lblPayChit.TabIndex = 24
        '
        'lblIncentiveRate
        '
        Me.lblIncentiveRate.Location = New System.Drawing.Point(181, 439)
        Me.lblIncentiveRate.Name = "lblIncentiveRate"
        Me.lblIncentiveRate.Size = New System.Drawing.Size(24, 13)
        Me.lblIncentiveRate.StyleController = Me.LayoutControl1
        Me.lblIncentiveRate.TabIndex = 23
        '
        'lblIncentiveDays
        '
        Me.lblIncentiveDays.Location = New System.Drawing.Point(446, 405)
        Me.lblIncentiveDays.Name = "lblIncentiveDays"
        Me.lblIncentiveDays.Size = New System.Drawing.Size(358, 13)
        Me.lblIncentiveDays.StyleController = Me.LayoutControl1
        Me.lblIncentiveDays.TabIndex = 22
        '
        'lblWCPay
        '
        Me.lblWCPay.Location = New System.Drawing.Point(446, 422)
        Me.lblWCPay.Name = "lblWCPay"
        Me.lblWCPay.Size = New System.Drawing.Size(358, 13)
        Me.lblWCPay.StyleController = Me.LayoutControl1
        Me.lblWCPay.TabIndex = 21
        '
        'lblCasualOTPayRate
        '
        Me.lblCasualOTPayRate.Location = New System.Drawing.Point(181, 405)
        Me.lblCasualOTPayRate.Name = "lblCasualOTPayRate"
        Me.lblCasualOTPayRate.Size = New System.Drawing.Size(24, 13)
        Me.lblCasualOTPayRate.StyleController = Me.LayoutControl1
        Me.lblCasualOTPayRate.TabIndex = 19
        '
        'lblCasualPayRate
        '
        Me.lblCasualPayRate.Location = New System.Drawing.Point(181, 388)
        Me.lblCasualPayRate.Name = "lblCasualPayRate"
        Me.lblCasualPayRate.Size = New System.Drawing.Size(24, 13)
        Me.lblCasualPayRate.StyleController = Me.LayoutControl1
        Me.lblCasualPayRate.TabIndex = 18
        '
        'lblEPF
        '
        Me.lblEPF.Location = New System.Drawing.Point(181, 456)
        Me.lblEPF.Name = "lblEPF"
        Me.lblEPF.Size = New System.Drawing.Size(24, 13)
        Me.lblEPF.StyleController = Me.LayoutControl1
        Me.lblEPF.TabIndex = 17
        '
        'lblOverKgsRate
        '
        Me.lblOverKgsRate.Location = New System.Drawing.Point(446, 388)
        Me.lblOverKgsRate.Name = "lblOverKgsRate"
        Me.lblOverKgsRate.Size = New System.Drawing.Size(358, 13)
        Me.lblOverKgsRate.StyleController = Me.LayoutControl1
        Me.lblOverKgsRate.TabIndex = 16
        '
        'leEmployee
        '
        Me.leEmployee.EnterMoveNextControl = True
        Me.leEmployee.Location = New System.Drawing.Point(540, 12)
        Me.leEmployee.MenuManager = Me.BarManager1
        Me.leEmployee.Name = "leEmployee"
        Me.leEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leEmployee.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.leEmployee.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerID", "EmployerID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerNo", "EmployerNo"), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("EmployerName", "EmployerName")})
        Me.leEmployee.Properties.NullText = ""
        Me.leEmployee.Size = New System.Drawing.Size(278, 20)
        Me.leEmployee.StyleController = Me.LayoutControl1
        Me.leEmployee.TabIndex = 3
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.leEmployee, ConditionValidationRule1)
        '
        'lblOTRate
        '
        Me.lblOTRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblOTRate.Location = New System.Drawing.Point(181, 371)
        Me.lblOTRate.Name = "lblOTRate"
        Me.lblOTRate.Size = New System.Drawing.Size(24, 13)
        Me.lblOTRate.StyleController = Me.LayoutControl1
        Me.lblOTRate.TabIndex = 13
        '
        'lblDayRate
        '
        Me.lblDayRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblDayRate.Location = New System.Drawing.Point(181, 354)
        Me.lblDayRate.Name = "lblDayRate"
        Me.lblDayRate.Size = New System.Drawing.Size(24, 13)
        Me.lblDayRate.StyleController = Me.LayoutControl1
        Me.lblDayRate.TabIndex = 12
        '
        'seQuantity
        '
        Me.seQuantity.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seQuantity.EnterMoveNextControl = True
        Me.seQuantity.Location = New System.Drawing.Point(540, 60)
        Me.seQuantity.MenuManager = Me.BarManager1
        Me.seQuantity.Name = "seQuantity"
        Me.seQuantity.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seQuantity.Size = New System.Drawing.Size(55, 20)
        Me.seQuantity.StyleController = Me.LayoutControl1
        Me.seQuantity.TabIndex = 6
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.seQuantity, ConditionValidationRule2)
        '
        'lblKgsPerDay
        '
        Me.lblKgsPerDay.Location = New System.Drawing.Point(446, 354)
        Me.lblKgsPerDay.Name = "lblKgsPerDay"
        Me.lblKgsPerDay.Size = New System.Drawing.Size(358, 13)
        Me.lblKgsPerDay.StyleController = Me.LayoutControl1
        Me.lblKgsPerDay.TabIndex = 15
        '
        'cmbWorkType
        '
        Me.cmbWorkType.EnterMoveNextControl = True
        Me.cmbWorkType.Location = New System.Drawing.Point(195, 36)
        Me.cmbWorkType.MenuManager = Me.BarManager1
        Me.cmbWorkType.Name = "cmbWorkType"
        Me.cmbWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cmbWorkType.Properties.Items.AddRange(New Object() {"STAFF", "CASUAL", "PERMANENT"})
        Me.cmbWorkType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cmbWorkType.Size = New System.Drawing.Size(172, 20)
        Me.cmbWorkType.StyleController = Me.LayoutControl1
        Me.cmbWorkType.TabIndex = 1
        ConditionValidationRule4.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule4.ErrorText = "Require"
        Me.dxvpDailyWorking.SetValidationRule(Me.cmbWorkType, ConditionValidationRule4)
        '
        'gcDailyWorking
        '
        Me.gcDailyWorking.Location = New System.Drawing.Point(26, 84)
        Me.gcDailyWorking.MainView = Me.gvDailyWorking
        Me.gcDailyWorking.MenuManager = Me.BarManager1
        Me.gcDailyWorking.Name = "gcDailyWorking"
        Me.gcDailyWorking.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1, Me.RepositoryItemButtonEdit2, Me.RepositoryItemImageEdit1})
        Me.gcDailyWorking.Size = New System.Drawing.Size(792, 266)
        Me.gcDailyWorking.TabIndex = 7
        Me.gcDailyWorking.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDailyWorking})
        '
        'gvDailyWorking
        '
        Me.gvDailyWorking.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn20, Me.GridColumn19, Me.GridColumn16})
        Me.gvDailyWorking.GridControl = Me.gcDailyWorking
        Me.gvDailyWorking.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", Me.GridColumn8, "{0:N2}")})
        Me.gvDailyWorking.Name = "gvDailyWorking"
        Me.gvDailyWorking.OptionsView.EnableAppearanceOddRow = True
        Me.gvDailyWorking.OptionsView.ShowFooter = True
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
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Stock Code"
        Me.GridColumn20.FieldName = "StockCode"
        Me.GridColumn20.Name = "GridColumn20"
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Description"
        Me.GridColumn19.FieldName = "Description"
        Me.GridColumn19.Name = "GridColumn19"
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
        'RepositoryItemButtonEdit2
        '
        Me.RepositoryItemButtonEdit2.AutoHeight = False
        Me.RepositoryItemButtonEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit2.Name = "RepositoryItemButtonEdit2"
        '
        'RepositoryItemImageEdit1
        '
        Me.RepositoryItemImageEdit1.AutoHeight = False
        Me.RepositoryItemImageEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemImageEdit1.Name = "RepositoryItemImageEdit1"
        '
        'deWorkingDate
        '
        Me.deWorkingDate.EditValue = Nothing
        Me.deWorkingDate.EnterMoveNextControl = True
        Me.deWorkingDate.Location = New System.Drawing.Point(195, 12)
        Me.deWorkingDate.MenuManager = Me.BarManager1
        Me.deWorkingDate.Name = "deWorkingDate"
        Me.deWorkingDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deWorkingDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deWorkingDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deWorkingDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deWorkingDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deWorkingDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deWorkingDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deWorkingDate.Size = New System.Drawing.Size(172, 20)
        Me.deWorkingDate.StyleController = Me.LayoutControl1
        Me.deWorkingDate.TabIndex = 0
        '
        'seDays
        '
        Me.seDays.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seDays.Location = New System.Drawing.Point(540, 36)
        Me.seDays.MenuManager = Me.BarManager1
        Me.seDays.Name = "seDays"
        Me.seDays.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seDays.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.seDays.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.seDays.Properties.MaxValue = New Decimal(New Integer() {2, 0, 0, 0})
        Me.seDays.Properties.NullText = "0"
        Me.seDays.Size = New System.Drawing.Size(55, 20)
        Me.seDays.StyleController = Me.LayoutControl1
        Me.seDays.TabIndex = 4
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem4, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlGroup3, Me.LayoutControlItem11, Me.LayoutControlItem8, Me.LayoutControlItem6, Me.LayoutControlItem24, Me.LayoutControlItem21, Me.EmptySpaceItem5, Me.LayoutControlItem28, Me.LayoutControlItem36})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(840, 560)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.deWorkingDate
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(14, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(345, 24)
        Me.LayoutControlItem1.Text = "Date"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(166, 13)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(810, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(10, 342)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(14, 342)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem4"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcDailyWorking
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(14, 72)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(796, 270)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.cmbWorkType
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(14, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(345, 24)
        Me.LayoutControlItem3.Text = "Work Type"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.leWorkCategory
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(14, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(345, 24)
        Me.LayoutControlItem4.Text = "Work Category"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.ExpandButtonVisible = True
        Me.LayoutControlGroup3.Expanded = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9, Me.LayoutControlItem19, Me.LayoutControlItem20, Me.LayoutControlItem23, Me.LayoutControlItem26, Me.LayoutControlItem5, Me.LayoutControlItem22, Me.LayoutControlItem17, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.LayoutControlItem10, Me.LayoutControlItem18, Me.LayoutControlItem25, Me.EmptySpaceItem3, Me.LayoutControlItem27, Me.LayoutControlItem29, Me.LayoutControlItem30, Me.LayoutControlItem31, Me.LayoutControlItem32, Me.LayoutControlItem33, Me.LayoutControlItem34})
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 342)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(820, 28)
        Me.LayoutControlGroup3.Text = "Settings"
        Me.LayoutControlGroup3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.lblDayRate
        Me.LayoutControlItem9.CustomizationFormText = "LayoutControlItem9"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem9.Text = "Day Pay Rate (Rs.)"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.lblCasualPayRate
        Me.LayoutControlItem19.CustomizationFormText = "LayoutControlItem19"
        Me.LayoutControlItem19.Location = New System.Drawing.Point(0, 34)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem19.Text = "Casual Pay Rate (Rs.)"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.lblCasualOTPayRate
        Me.LayoutControlItem20.CustomizationFormText = "LayoutControlItem20"
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 51)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem20.Text = "Casual OT Pay Rate (Rs.)"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.lblPayChit
        Me.LayoutControlItem23.CustomizationFormText = "LayoutControlItem23"
        Me.LayoutControlItem23.Location = New System.Drawing.Point(0, 68)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem23.Text = "Pay Chit Cost (Rs.)"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.lblKgsPerDayNotMandatory
        Me.LayoutControlItem26.CustomizationFormText = "Kgs Per day not mandatory"
        Me.LayoutControlItem26.Location = New System.Drawing.Point(265, 17)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem26.Text = "Per Kg rate If not mandatory (Rs.)"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.lblWCPay
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(265, 68)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem5.Text = "WC Pay Rate (Rs.)"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.lblIncentiveRate
        Me.LayoutControlItem22.CustomizationFormText = "LayoutControlItem22"
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 85)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem22.Text = "Evaluation Allowance (Rs.)"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.lblOverKgsRate
        Me.LayoutControlItem17.CustomizationFormText = "LayoutControlItem17"
        Me.LayoutControlItem17.Location = New System.Drawing.Point(265, 34)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem17.Text = "Over Kgs Rate (Rs.)"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.lblIncentiveDays
        Me.LayoutControlItem15.CustomizationFormText = "LayoutControlItem15"
        Me.LayoutControlItem15.Location = New System.Drawing.Point(265, 51)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem15.Text = "Evaluation Margin (Days)"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.lblKgsPerDay
        Me.LayoutControlItem16.CustomizationFormText = "LayoutControlItem16"
        Me.LayoutControlItem16.Location = New System.Drawing.Point(265, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem16.Text = "Mandatory margin per Day (Kgs)"
        Me.LayoutControlItem16.TextLocation = DevExpress.Utils.Locations.[Default]
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lblOTRate
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 17)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem10.Text = "OT Pay Rate (Rs.)"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.lblEPF
        Me.LayoutControlItem18.CustomizationFormText = "LayoutControlItem18"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(0, 102)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(197, 17)
        Me.LayoutControlItem18.Text = "EPF (%)"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.lblETF
        Me.LayoutControlItem25.CustomizationFormText = "ETF (%)"
        Me.LayoutControlItem25.Location = New System.Drawing.Point(265, 102)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem25.Text = "ETF (%)"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(166, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(197, 100)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(68, 67)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.lblOverKgUpperLimit
        Me.LayoutControlItem27.CustomizationFormText = "OverKgUpper Limit"
        Me.LayoutControlItem27.Location = New System.Drawing.Point(265, 85)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(531, 17)
        Me.LayoutControlItem27.Text = "OverKgUpper Limit"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.lblSheetsPerDay
        Me.LayoutControlItem29.CustomizationFormText = "LayoutControlItem29"
        Me.LayoutControlItem29.Location = New System.Drawing.Point(0, 119)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(197, 24)
        Me.LayoutControlItem29.Text = "LayoutControlItem29"
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem29.TextToControlDistance = 0
        Me.LayoutControlItem29.TextVisible = False
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.lblOverSheetsUpperLimit
        Me.LayoutControlItem30.CustomizationFormText = "LayoutControlItem30"
        Me.LayoutControlItem30.Location = New System.Drawing.Point(265, 119)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(531, 24)
        Me.LayoutControlItem30.Text = "LayoutControlItem30"
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem30.TextToControlDistance = 0
        Me.LayoutControlItem30.TextVisible = False
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.lblOverSheetsRate
        Me.LayoutControlItem31.CustomizationFormText = "LayoutControlItem31"
        Me.LayoutControlItem31.Location = New System.Drawing.Point(0, 143)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(197, 24)
        Me.LayoutControlItem31.Text = "LayoutControlItem31"
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem31.TextToControlDistance = 0
        Me.LayoutControlItem31.TextVisible = False
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.lblLowerSheetsRate
        Me.LayoutControlItem32.CustomizationFormText = "LayoutControlItem32"
        Me.LayoutControlItem32.Location = New System.Drawing.Point(265, 143)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(531, 24)
        Me.LayoutControlItem32.Text = "LayoutControlItem32"
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem32.TextToControlDistance = 0
        Me.LayoutControlItem32.TextVisible = False
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.lblSmokingSheetsPayRate
        Me.LayoutControlItem33.CustomizationFormText = "LayoutControlItem33"
        Me.LayoutControlItem33.Location = New System.Drawing.Point(197, 0)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(68, 83)
        Me.LayoutControlItem33.Text = "LayoutControlItem33"
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem33.TextToControlDistance = 0
        Me.LayoutControlItem33.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.lblLowerKgRate
        Me.LayoutControlItem34.CustomizationFormText = "LayoutControlItem34"
        Me.LayoutControlItem34.Location = New System.Drawing.Point(197, 83)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(68, 17)
        Me.LayoutControlItem34.Text = "LayoutControlItem34"
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem34.TextToControlDistance = 0
        Me.LayoutControlItem34.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.leEmployee
        Me.LayoutControlItem11.CustomizationFormText = "Employee"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(359, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(451, 24)
        Me.LayoutControlItem11.Text = "Employee"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.seQuantity
        Me.LayoutControlItem8.CustomizationFormText = "Quantity"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(359, 48)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(228, 24)
        Me.LayoutControlItem8.Text = "Quantity"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.seDays
        Me.LayoutControlItem6.CustomizationFormText = "Days"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(359, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(228, 24)
        Me.LayoutControlItem6.Text = "Days"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.leStock
        Me.LayoutControlItem24.CustomizationFormText = "Stock"
        Me.LayoutControlItem24.Location = New System.Drawing.Point(587, 48)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(223, 24)
        Me.LayoutControlItem24.Text = "Stock"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(166, 13)
        Me.LayoutControlItem24.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.lblDeleteID
        Me.LayoutControlItem21.CustomizationFormText = "LayoutControlItem21"
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 380)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(820, 17)
        Me.LayoutControlItem21.Text = "LayoutControlItem21"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(166, 13)
        Me.LayoutControlItem21.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.CustomizationFormText = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(0, 370)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(820, 10)
        Me.EmptySpaceItem5.Text = "EmptySpaceItem5"
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.seOTHours
        Me.LayoutControlItem28.CustomizationFormText = "OT Hours"
        Me.LayoutControlItem28.Location = New System.Drawing.Point(587, 24)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(223, 24)
        Me.LayoutControlItem28.Text = "OT Hours"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(166, 13)
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.gcHoliday
        Me.LayoutControlItem36.CustomizationFormText = "LayoutControlItem36"
        Me.LayoutControlItem36.Location = New System.Drawing.Point(0, 397)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(820, 143)
        Me.LayoutControlItem36.Text = "LayoutControlItem36"
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(166, 13)
        Me.LayoutControlItem36.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.deStartDate)
        Me.LayoutControl2.Controls.Add(Me.deEndDate)
        Me.LayoutControl2.Controls.Add(Me.btnDisplay)
        Me.LayoutControl2.Controls.Add(Me.gcAllWorkings)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup2
        Me.LayoutControl2.Size = New System.Drawing.Size(840, 560)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'deStartDate
        '
        Me.deStartDate.EditValue = Nothing
        Me.deStartDate.Location = New System.Drawing.Point(66, 43)
        Me.deStartDate.MenuManager = Me.BarManager1
        Me.deStartDate.Name = "deStartDate"
        Me.deStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deStartDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deStartDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deStartDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deStartDate.Size = New System.Drawing.Size(104, 20)
        Me.deStartDate.StyleController = Me.LayoutControl2
        Me.deStartDate.TabIndex = 5
        '
        'deEndDate
        '
        Me.deEndDate.EditValue = Nothing
        Me.deEndDate.Location = New System.Drawing.Point(216, 43)
        Me.deEndDate.MenuManager = Me.BarManager1
        Me.deEndDate.Name = "deEndDate"
        Me.deEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.deEndDate.Properties.DisplayFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.EditFormat.FormatString = "dd-MMM-yy"
        Me.deEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.deEndDate.Properties.Mask.EditMask = "dd-MMM-yy"
        Me.deEndDate.Properties.VistaTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.deEndDate.Size = New System.Drawing.Size(104, 20)
        Me.deEndDate.StyleController = Me.LayoutControl2
        Me.deEndDate.TabIndex = 6
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(324, 43)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(146, 22)
        Me.btnDisplay.TabIndex = 7
        Me.btnDisplay.Text = "Process"
        Me.btnDisplay.UseVisualStyleBackColor = True
        '
        'gcAllWorkings
        '
        Me.gcAllWorkings.Location = New System.Drawing.Point(12, 81)
        Me.gcAllWorkings.MainView = Me.gvAllWorkings
        Me.gcAllWorkings.MenuManager = Me.BarManager1
        Me.gcAllWorkings.Name = "gcAllWorkings"
        Me.gcAllWorkings.Size = New System.Drawing.Size(816, 467)
        Me.gcAllWorkings.TabIndex = 4
        Me.gcAllWorkings.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvAllWorkings})
        '
        'gvAllWorkings
        '
        Me.gvAllWorkings.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn17, Me.GridColumn18})
        Me.gvAllWorkings.GridControl = Me.gcAllWorkings
        Me.gvAllWorkings.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "WorkedDays", Me.GridColumn14, "{0:N2}")})
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
        Me.GridColumn9.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Work Type"
        Me.GridColumn10.FieldName = "WorkType"
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 1
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Work Category"
        Me.GridColumn11.FieldName = "AbbreviationDesc"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.AllowEdit = False
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Employee Code"
        Me.GridColumn12.FieldName = "EmployerNo"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.AllowEdit = False
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 3
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Employee Name"
        Me.GridColumn13.FieldName = "EmployerName"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.AllowEdit = False
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 4
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Worked Days"
        Me.GridColumn14.DisplayFormat.FormatString = "{0:n2}"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "WorkedDays"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
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
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:n2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 6
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Stock Code"
        Me.GridColumn17.FieldName = "StockCode"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 7
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Description"
        Me.GridColumn18.FieldName = "Description"
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 8
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "LayoutControlGroup2"
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.EmptySpaceItem1, Me.LayoutControlGroup4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(840, 560)
        Me.LayoutControlGroup2.Text = "LayoutControlGroup2"
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.gcAllWorkings
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 69)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(820, 471)
        Me.LayoutControlItem7.Text = "LayoutControlItem7"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextToControlDistance = 0
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(474, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(346, 69)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Select Date Range"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem12, Me.LayoutControlItem14, Me.LayoutControlItem13})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(474, 69)
        Me.LayoutControlGroup4.Text = "Select Date Range"
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.btnDisplay
        Me.LayoutControlItem12.CustomizationFormText = "LayoutControlItem12"
        Me.LayoutControlItem12.Location = New System.Drawing.Point(300, 0)
        Me.LayoutControlItem12.MaxSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem12.MinSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem12.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem12.Text = "LayoutControlItem12"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextToControlDistance = 0
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.deEndDate
        Me.LayoutControlItem14.CustomizationFormText = "To"
        Me.LayoutControlItem14.Location = New System.Drawing.Point(150, 0)
        Me.LayoutControlItem14.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem14.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem14.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem14.Text = "To"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(39, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.deStartDate
        Me.LayoutControlItem13.CustomizationFormText = "From To"
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem13.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem13.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem13.Text = "From To"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(39, 13)
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 22)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(846, 588)
        Me.XtraTabControl1.TabIndex = 9
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(840, 560)
        Me.XtraTabPage1.Text = "Add New"
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.LayoutControl2)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(840, 560)
        Me.XtraTabPage2.Text = "History Data"
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
        Me.ClientSize = New System.Drawing.Size(846, 610)
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
        CType(Me.gcHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvHoliday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seOTHours.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leStock.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seQuantity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcDailyWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDailyWorking, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemImageEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deWorkingDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deWorkingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seDays.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.deStartDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties.VistaTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcAllWorkings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvAllWorkings, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
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
    Friend WithEvents gcAllWorkings As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvAllWorkings As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents deEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DateEdit1 As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
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
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblPayChit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblIncentiveRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblIncentiveDays As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWCPay As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents leStock As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemButtonEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepositoryItemImageEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Friend WithEvents lblKgsPerDayNotMandatory As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblDeleteID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lblETF As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblOverKgUpperLimit As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents seDays As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents seOTHours As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblLowerSheetsRate As System.Windows.Forms.Label
    Friend WithEvents lblOverSheetsRate As System.Windows.Forms.Label
    Friend WithEvents lblOverSheetsUpperLimit As System.Windows.Forms.Label
    Friend WithEvents lblSheetsPerDay As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblSmokingSheetsPayRate As System.Windows.Forms.Label
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents lblLowerKgRate As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcHoliday As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvHoliday As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
End Class
