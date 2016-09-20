<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecoverySummary
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
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtBalance = New DevExpress.XtraEditors.TextEdit()
        Me.txtFestivalAmount = New DevExpress.XtraEditors.TextEdit()
        Me.gcRecovery = New DevExpress.XtraGrid.GridControl()
        Me.gvRecovery = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.leFestival = New DevExpress.XtraEditors.LookUpEdit()
        Me.gcFieldPerfomance = New DevExpress.XtraGrid.GridControl()
        Me.gvFieldPerformance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdMay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdJun = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdJul = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdAug = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdSep = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdOct = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdNov = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdDec = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdJan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdFeb = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdRemarks = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.leYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.sbPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.dxvpFieldPerformance = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtBalance.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFestivalAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcRecovery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRecovery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leFestival.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gcFieldPerfomance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvFieldPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpFieldPerformance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtBalance)
        Me.LayoutControl1.Controls.Add(Me.txtFestivalAmount)
        Me.LayoutControl1.Controls.Add(Me.gcRecovery)
        Me.LayoutControl1.Controls.Add(Me.leFestival)
        Me.LayoutControl1.Controls.Add(Me.gcFieldPerfomance)
        Me.LayoutControl1.Controls.Add(Me.leYear)
        Me.LayoutControl1.Controls.Add(Me.sbPrint)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1268, 666)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtBalance
        '
        Me.txtBalance.EditValue = "0.00"
        Me.txtBalance.Location = New System.Drawing.Point(111, 269)
        Me.txtBalance.Name = "txtBalance"
        Me.txtBalance.Properties.Appearance.Options.UseTextOptions = True
        Me.txtBalance.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtBalance.Size = New System.Drawing.Size(471, 20)
        Me.txtBalance.StyleController = Me.LayoutControl1
        Me.txtBalance.TabIndex = 25
        '
        'txtFestivalAmount
        '
        Me.txtFestivalAmount.EditValue = "0.00"
        Me.txtFestivalAmount.Location = New System.Drawing.Point(111, 79)
        Me.txtFestivalAmount.Name = "txtFestivalAmount"
        Me.txtFestivalAmount.Properties.Appearance.Options.UseTextOptions = True
        Me.txtFestivalAmount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtFestivalAmount.Size = New System.Drawing.Size(475, 20)
        Me.txtFestivalAmount.StyleController = Me.LayoutControl1
        Me.txtFestivalAmount.TabIndex = 23
        '
        'gcRecovery
        '
        Me.gcRecovery.Location = New System.Drawing.Point(12, 103)
        Me.gcRecovery.MainView = Me.gvRecovery
        Me.gcRecovery.Name = "gcRecovery"
        Me.gcRecovery.Size = New System.Drawing.Size(1244, 162)
        Me.gcRecovery.TabIndex = 22
        Me.gcRecovery.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvRecovery})
        '
        'gvRecovery
        '
        Me.gvRecovery.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7})
        Me.gvRecovery.GridControl = Me.gcRecovery
        Me.gvRecovery.Name = "gvRecovery"
        Me.gvRecovery.OptionsView.ShowFooter = True
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "TermDeductionID"
        Me.GridColumn4.FieldName = "TermDeductionID"
        Me.GridColumn4.Name = "GridColumn4"
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Recovery Date"
        Me.GridColumn5.FieldName = "IssueDate"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "AdvanceAmount"
        Me.GridColumn6.FieldName = "AdvanceAmount"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdvanceAmount", "{0:n2}")})
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "TDAmount"
        Me.GridColumn7.FieldName = "TDAmount"
        Me.GridColumn7.Name = "GridColumn7"
        '
        'leFestival
        '
        Me.leFestival.Location = New System.Drawing.Point(323, 43)
        Me.leFestival.Name = "leFestival"
        Me.leFestival.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leFestival.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TermDeductionID", "TermDeductionID", 20, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TDdescription", "TDdescription")})
        Me.leFestival.Properties.NullText = ""
        Me.leFestival.Size = New System.Drawing.Size(251, 20)
        Me.leFestival.StyleController = Me.LayoutControl1
        Me.leFestival.TabIndex = 21
        '
        'gcFieldPerfomance
        '
        Me.gcFieldPerfomance.Location = New System.Drawing.Point(111, 293)
        Me.gcFieldPerfomance.MainView = Me.gvFieldPerformance
        Me.gcFieldPerfomance.Name = "gcFieldPerfomance"
        Me.gcFieldPerfomance.Size = New System.Drawing.Size(1145, 326)
        Me.gcFieldPerfomance.TabIndex = 20
        Me.gcFieldPerfomance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvFieldPerformance})
        '
        'gvFieldPerformance
        '
        Me.gvFieldPerformance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn14, Me.GridColumn1, Me.GridColumn3, Me.GridColumn15, Me.grdMay, Me.grdJun, Me.grdJul, Me.grdAug, Me.grdSep, Me.grdOct, Me.grdNov, Me.grdDec, Me.grdJan, Me.grdFeb, Me.grdRemarks})
        Me.gvFieldPerformance.GridControl = Me.gcFieldPerfomance
        Me.gvFieldPerformance.Name = "gvFieldPerformance"
        Me.gvFieldPerformance.OptionsBehavior.Editable = False
        Me.gvFieldPerformance.OptionsView.ShowFooter = True
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "EPF NO"
        Me.GridColumn2.FieldName = "EPFNo"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Work Type"
        Me.GridColumn14.FieldName = "Designation"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 1
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Employee No"
        Me.GridColumn1.FieldName = "EmployerNo"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 2
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Name of Employee"
        Me.GridColumn3.FieldName = "EmployerName"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:N2}")})
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Amount (Rs)"
        Me.GridColumn15.DisplayFormat.FormatString = "F2"
        Me.GridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn15.FieldName = "Amount"
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "{0:F2}")})
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        '
        'grdMay
        '
        Me.grdMay.Caption = "MAY"
        Me.grdMay.FieldName = "May"
        Me.grdMay.Name = "grdMay"
        Me.grdMay.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdMay.Visible = True
        Me.grdMay.VisibleIndex = 5
        '
        'grdJun
        '
        Me.grdJun.Caption = "JUN"
        Me.grdJun.FieldName = "Jun"
        Me.grdJun.Name = "grdJun"
        Me.grdJun.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdJun.Visible = True
        Me.grdJun.VisibleIndex = 6
        '
        'grdJul
        '
        Me.grdJul.Caption = "JUL"
        Me.grdJul.FieldName = "Jul"
        Me.grdJul.Name = "grdJul"
        Me.grdJul.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdJul.Visible = True
        Me.grdJul.VisibleIndex = 7
        '
        'grdAug
        '
        Me.grdAug.Caption = "AUG"
        Me.grdAug.FieldName = "Aug"
        Me.grdAug.Name = "grdAug"
        Me.grdAug.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdAug.Visible = True
        Me.grdAug.VisibleIndex = 8
        '
        'grdSep
        '
        Me.grdSep.Caption = "SEP"
        Me.grdSep.FieldName = "Sep"
        Me.grdSep.Name = "grdSep"
        Me.grdSep.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdSep.Visible = True
        Me.grdSep.VisibleIndex = 9
        '
        'grdOct
        '
        Me.grdOct.Caption = "OCT"
        Me.grdOct.FieldName = "Oct"
        Me.grdOct.Name = "grdOct"
        Me.grdOct.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdOct.Visible = True
        Me.grdOct.VisibleIndex = 10
        '
        'grdNov
        '
        Me.grdNov.Caption = "NOV"
        Me.grdNov.FieldName = "Nov"
        Me.grdNov.Name = "grdNov"
        Me.grdNov.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdNov.Visible = True
        Me.grdNov.VisibleIndex = 11
        '
        'grdDec
        '
        Me.grdDec.Caption = "DEC"
        Me.grdDec.FieldName = "Dec"
        Me.grdDec.Name = "grdDec"
        Me.grdDec.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdDec.Visible = True
        Me.grdDec.VisibleIndex = 12
        '
        'grdJan
        '
        Me.grdJan.Caption = "JAN"
        Me.grdJan.FieldName = "Jan"
        Me.grdJan.Name = "grdJan"
        Me.grdJan.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdJan.Visible = True
        Me.grdJan.VisibleIndex = 13
        '
        'grdFeb
        '
        Me.grdFeb.Caption = "FEB"
        Me.grdFeb.FieldName = "Feb"
        Me.grdFeb.Name = "grdFeb"
        Me.grdFeb.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)})
        Me.grdFeb.Visible = True
        Me.grdFeb.VisibleIndex = 14
        '
        'grdRemarks
        '
        Me.grdRemarks.Caption = "Remarks"
        Me.grdRemarks.FieldName = "Remarks"
        Me.grdRemarks.Name = "grdRemarks"
        Me.grdRemarks.Visible = True
        Me.grdRemarks.VisibleIndex = 15
        '
        'leYear
        '
        Me.leYear.Location = New System.Drawing.Point(123, 43)
        Me.leYear.Name = "leYear"
        Me.leYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Year")})
        Me.leYear.Properties.NullText = ""
        Me.leYear.Size = New System.Drawing.Size(97, 20)
        Me.leYear.StyleController = Me.LayoutControl1
        Me.leYear.TabIndex = 15
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpFieldPerformance.SetValidationRule(Me.leYear, ConditionValidationRule2)
        '
        'sbPrint
        '
        Me.sbPrint.Location = New System.Drawing.Point(12, 623)
        Me.sbPrint.Name = "sbPrint"
        Me.sbPrint.Size = New System.Drawing.Size(196, 31)
        Me.sbPrint.StyleController = Me.LayoutControl1
        Me.sbPrint.TabIndex = 6
        Me.sbPrint.Text = "Print"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem3, Me.LayoutControlGroup2, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.EmptySpaceItem1, Me.EmptySpaceItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1268, 666)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.sbPrint
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 611)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(200, 35)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(200, 35)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1248, 35)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        Me.LayoutControlItem3.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(578, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(670, 67)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Select Tapping or Plucking"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(578, 67)
        Me.LayoutControlGroup2.Text = "Select  Year"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.leYear
        Me.LayoutControlItem6.CustomizationFormText = "Type"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(120, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(200, 24)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Year"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.leFestival
        Me.LayoutControlItem4.CustomizationFormText = "LayoutControlItem4"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(200, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(354, 24)
        Me.LayoutControlItem4.Text = "Type"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.gcFieldPerfomance
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 281)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(1248, 330)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(96, 13)
        Me.LayoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.gcRecovery
        Me.LayoutControlItem5.CustomizationFormText = "LayoutControlItem5"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 91)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1248, 166)
        Me.LayoutControlItem5.Text = "LayoutControlItem5"
        Me.LayoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextToControlDistance = 0
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtFestivalAmount
        Me.LayoutControlItem7.CustomizationFormText = "LayoutControlItem7"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 67)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(578, 24)
        Me.LayoutControlItem7.Text = "Paid Amount"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(96, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtBalance
        Me.LayoutControlItem9.CustomizationFormText = "Balance"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 257)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(574, 24)
        Me.LayoutControlItem9.Text = "Balance"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(96, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(578, 67)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(670, 24)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(574, 257)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(674, 24)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmRecoverySummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1268, 666)
        Me.Controls.Add(Me.LayoutControl1)
        Me.KeyPreview = True
        Me.Name = "frmRecoverySummary"
        Me.Text = "Festival Recovery Summary"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtBalance.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFestivalAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcRecovery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRecovery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leFestival.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gcFieldPerfomance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvFieldPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpFieldPerformance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents sbPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem

    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents leYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dxvpFieldPerformance As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents gcFieldPerfomance As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvFieldPerformance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdMay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdJun As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdJul As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdAug As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdSep As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdOct As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdNov As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdDec As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdJan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdFeb As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdRemarks As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents leFestival As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gcRecovery As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvRecovery As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtFestivalAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtBalance As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
End Class
