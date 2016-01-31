<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendaceReport
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
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim PivotGridStyleFormatCondition1 As DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition = New DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition()
        Dim PivotGridCustomTotal1 As DevExpress.XtraPivotGrid.PivotGridCustomTotal = New DevExpress.XtraPivotGrid.PivotGridCustomTotal()
        Dim PivotGridCustomTotal2 As DevExpress.XtraPivotGrid.PivotGridCustomTotal = New DevExpress.XtraPivotGrid.PivotGridCustomTotal()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule3 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cbeWorkType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.pgcAttendance = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.PivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField2 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField6 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField3 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField4 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField5 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField7 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.leYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.meMonth = New DevExpress.XtraScheduler.UI.MonthEdit()
        Me.sbGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.sbPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dxvpAttendaceReport = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cbeWorkType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pgcAttendance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpAttendaceReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cbeWorkType)
        Me.LayoutControl1.Controls.Add(Me.pgcAttendance)
        Me.LayoutControl1.Controls.Add(Me.leYear)
        Me.LayoutControl1.Controls.Add(Me.meMonth)
        Me.LayoutControl1.Controls.Add(Me.sbGenerate)
        Me.LayoutControl1.Controls.Add(Me.sbPrint)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(702, 502)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cbeWorkType
        '
        Me.cbeWorkType.Location = New System.Drawing.Point(379, 43)
        Me.cbeWorkType.Name = "cbeWorkType"
        Me.cbeWorkType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo), New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Clear", -1, True, True, False, DevExpress.XtraEditors.ImageLocation.MiddleCenter, Nothing, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, "", Nothing, Nothing, True)})
        Me.cbeWorkType.Properties.Items.AddRange(New Object() {"ALL", "CASUAL", "PERMANENT"})
        Me.cbeWorkType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.cbeWorkType.Size = New System.Drawing.Size(121, 20)
        Me.cbeWorkType.StyleController = Me.LayoutControl1
        Me.cbeWorkType.TabIndex = 17
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Require"
        Me.dxvpAttendaceReport.SetValidationRule(Me.cbeWorkType, ConditionValidationRule1)
        '
        'pgcAttendance
        '
        Me.pgcAttendance.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.PivotGridField1, Me.PivotGridField2, Me.PivotGridField6, Me.PivotGridField3, Me.PivotGridField4, Me.PivotGridField5, Me.PivotGridField7})
        PivotGridStyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Transparent
        PivotGridStyleFormatCondition1.Appearance.Options.UseForeColor = True
        PivotGridStyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        PivotGridStyleFormatCondition1.FieldName = ""
        PivotGridStyleFormatCondition1.Value1 = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.pgcAttendance.FormatConditions.AddRange(New DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition() {PivotGridStyleFormatCondition1})
        Me.pgcAttendance.Location = New System.Drawing.Point(12, 81)
        Me.pgcAttendance.Name = "pgcAttendance"
        Me.pgcAttendance.Size = New System.Drawing.Size(678, 374)
        Me.pgcAttendance.TabIndex = 16
        '
        'PivotGridField1
        '
        Me.PivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField1.AreaIndex = 0
        Me.PivotGridField1.Caption = "Employee No"
        Me.PivotGridField1.FieldName = "EmployerNo"
        Me.PivotGridField1.Name = "PivotGridField1"
        Me.PivotGridField1.Visible = False
        '
        'PivotGridField2
        '
        Me.PivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField2.AreaIndex = 0
        Me.PivotGridField2.Caption = "Employee Name"
        Me.PivotGridField2.FieldName = "EmployerName"
        Me.PivotGridField2.Name = "PivotGridField2"
        '
        'PivotGridField6
        '
        Me.PivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField6.AreaIndex = 1
        Me.PivotGridField6.Caption = "Sex"
        Me.PivotGridField6.FieldName = "Sex"
        Me.PivotGridField6.Name = "PivotGridField6"
        Me.PivotGridField6.Visible = False
        '
        'PivotGridField3
        '
        Me.PivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField3.AreaIndex = 0
        Me.PivotGridField3.Caption = "Total"
        Me.PivotGridField3.CellFormat.FormatString = "#.#"
        Me.PivotGridField3.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        PivotGridCustomTotal1.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
        Me.PivotGridField3.CustomTotals.AddRange(New DevExpress.XtraPivotGrid.PivotGridCustomTotal() {PivotGridCustomTotal1})
        Me.PivotGridField3.FieldName = "Attendance"
        Me.PivotGridField3.GrandTotalCellFormat.FormatString = "#.#"
        Me.PivotGridField3.GrandTotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField3.Name = "PivotGridField3"
        Me.PivotGridField3.Options.AllowRunTimeSummaryChange = True
        Me.PivotGridField3.TotalCellFormat.FormatString = "#.#"
        Me.PivotGridField3.TotalCellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField3.TotalsVisibility = DevExpress.XtraPivotGrid.PivotTotalsVisibility.CustomTotals
        Me.PivotGridField3.UnboundFieldName = "PivotGridField3"
        '
        'PivotGridField4
        '
        Me.PivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.PivotGridField4.AreaIndex = 0
        Me.PivotGridField4.Caption = "Day"
        Me.PivotGridField4.FieldName = "monthDate"
        Me.PivotGridField4.GroupIntervalNumericRange = 12
        Me.PivotGridField4.Name = "PivotGridField4"
        Me.PivotGridField4.UnboundFieldName = "PivotGridField4"
        Me.PivotGridField4.ValueFormat.FormatString = "n0"
        Me.PivotGridField4.ValueFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        '
        'PivotGridField5
        '
        Me.PivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField5.AreaIndex = 1
        Me.PivotGridField5.Caption = "(Avg %)"
        Me.PivotGridField5.CellFormat.FormatString = "#.#"
        Me.PivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        PivotGridCustomTotal2.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
        Me.PivotGridField5.CustomTotals.AddRange(New DevExpress.XtraPivotGrid.PivotGridCustomTotal() {PivotGridCustomTotal2})
        Me.PivotGridField5.FieldName = "Attendance"
        Me.PivotGridField5.Name = "PivotGridField5"
        Me.PivotGridField5.Options.ShowValues = False
        Me.PivotGridField5.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Average
        Me.PivotGridField5.UnboundFieldName = "PivotGridField5"
        Me.PivotGridField5.Visible = False
        '
        'PivotGridField7
        '
        Me.PivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField7.AreaIndex = 1
        Me.PivotGridField7.Caption = "Work Type"
        Me.PivotGridField7.FieldName = "WorkType"
        Me.PivotGridField7.Name = "PivotGridField7"
        '
        'leYear
        '
        Me.leYear.Location = New System.Drawing.Point(229, 43)
        Me.leYear.Name = "leYear"
        Me.leYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Year")})
        Me.leYear.Properties.NullText = ""
        Me.leYear.Size = New System.Drawing.Size(91, 20)
        Me.leYear.StyleController = Me.LayoutControl1
        Me.leYear.TabIndex = 15
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpAttendaceReport.SetValidationRule(Me.leYear, ConditionValidationRule2)
        '
        'meMonth
        '
        Me.meMonth.Location = New System.Drawing.Point(79, 43)
        Me.meMonth.Name = "meMonth"
        Me.meMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.meMonth.Size = New System.Drawing.Size(91, 20)
        Me.meMonth.StyleController = Me.LayoutControl1
        Me.meMonth.TabIndex = 14
        ConditionValidationRule3.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule3.ErrorText = "Require"
        Me.dxvpAttendaceReport.SetValidationRule(Me.meMonth, ConditionValidationRule3)
        '
        'sbGenerate
        '
        Me.sbGenerate.Location = New System.Drawing.Point(504, 43)
        Me.sbGenerate.Name = "sbGenerate"
        Me.sbGenerate.Size = New System.Drawing.Size(146, 22)
        Me.sbGenerate.StyleController = Me.LayoutControl1
        Me.sbGenerate.TabIndex = 12
        Me.sbGenerate.Text = "Generate"
        '
        'sbPrint
        '
        Me.sbPrint.Location = New System.Drawing.Point(12, 459)
        Me.sbPrint.Name = "sbPrint"
        Me.sbPrint.Size = New System.Drawing.Size(196, 31)
        Me.sbPrint.StyleController = Me.LayoutControl1
        Me.sbPrint.TabIndex = 6
        Me.sbPrint.Text = "Print"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem3, Me.LayoutControlGroup2, Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(702, 502)
        Me.LayoutControlGroup1.Text = "Root"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.sbPrint
        Me.LayoutControlItem3.CustomizationFormText = "LayoutControlItem3"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 447)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(200, 35)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(200, 35)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(682, 35)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "LayoutControlItem3"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextToControlDistance = 0
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(654, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(28, 69)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Select Month & Year"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(654, 69)
        Me.LayoutControlGroup2.Text = "Select Month && Year"
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.meMonth
        Me.LayoutControlItem5.CustomizationFormText = "Month"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Month"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(52, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.leYear
        Me.LayoutControlItem6.CustomizationFormText = "Year"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(150, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Year"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(52, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.sbGenerate
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(480, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "LayoutControlItem1"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextToControlDistance = 0
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cbeWorkType
        Me.LayoutControlItem4.CustomizationFormText = "Work Type"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(300, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(180, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(180, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(180, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Work Type"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(52, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.pgcAttendance
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 69)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(682, 378)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'frmAttendaceReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 502)
        Me.Controls.Add(Me.LayoutControl1)
        Me.KeyPreview = True
        Me.Name = "frmAttendaceReport"
        Me.Text = "Attendance Report"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cbeWorkType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pgcAttendance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpAttendaceReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents sbPrint As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem

    Friend WithEvents sbGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents leYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meMonth As DevExpress.XtraScheduler.UI.MonthEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dxvpAttendaceReport As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents pgcAttendance As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField2 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField3 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField4 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField5 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField6 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents cbeWorkType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PivotGridField7 As DevExpress.XtraPivotGrid.PivotGridField
End Class
