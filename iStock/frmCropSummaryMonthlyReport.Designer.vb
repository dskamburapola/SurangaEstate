<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCropSummaryMonthlyReport
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
        Dim PivotGridStyleFormatCondition1 As DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition = New DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition()
        Dim PivotGridStyleFormatCondition2 As DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition = New DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition()
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.PivotGridField4 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField6 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.pgcCropSummaryMonthly = New DevExpress.XtraPivotGrid.PivotGridControl()
        Me.PivotGridField1 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField2 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField3 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField7 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField5 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.meMonth = New DevExpress.XtraScheduler.UI.MonthEdit()
        Me.leYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.sbGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.sbPrint = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.dxvpAttendaceReport = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.PivotGridField8 = New DevExpress.XtraPivotGrid.PivotGridField()
        Me.PivotGridField9 = New DevExpress.XtraPivotGrid.PivotGridField()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.pgcCropSummaryMonthly, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpAttendaceReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PivotGridField4
        '
        Me.PivotGridField4.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField4.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField4.Appearance.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PivotGridField4.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField4.AreaIndex = 0
        Me.PivotGridField4.Caption = "T"
        Me.PivotGridField4.CellFormat.FormatString = "{0:N2}"
        Me.PivotGridField4.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField4.FieldName = "Tapping"
        Me.PivotGridField4.GroupInterval = DevExpress.XtraPivotGrid.PivotGroupInterval.Custom
        Me.PivotGridField4.Name = "PivotGridField4"
        Me.PivotGridField4.Options.ShowTotals = False
        Me.PivotGridField4.UnboundFieldName = "PivotGridField4"
        '
        'PivotGridField6
        '
        Me.PivotGridField6.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField6.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField6.Appearance.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PivotGridField6.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField6.AreaIndex = 1
        Me.PivotGridField6.Caption = "P"
        Me.PivotGridField6.CellFormat.FormatString = "{0:N2}"
        Me.PivotGridField6.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField6.FieldName = "Plucking"
        Me.PivotGridField6.Name = "PivotGridField6"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.pgcCropSummaryMonthly)
        Me.LayoutControl1.Controls.Add(Me.meMonth)
        Me.LayoutControl1.Controls.Add(Me.leYear)
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
        'pgcCropSummaryMonthly
        '
        Me.pgcCropSummaryMonthly.Fields.AddRange(New DevExpress.XtraPivotGrid.PivotGridField() {Me.PivotGridField1, Me.PivotGridField2, Me.PivotGridField3, Me.PivotGridField7, Me.PivotGridField5, Me.PivotGridField6, Me.PivotGridField4, Me.PivotGridField8, Me.PivotGridField9})
        PivotGridStyleFormatCondition1.Appearance.ForeColor = System.Drawing.Color.Transparent
        PivotGridStyleFormatCondition1.Appearance.Options.UseForeColor = True
        PivotGridStyleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        PivotGridStyleFormatCondition1.Field = Me.PivotGridField4
        PivotGridStyleFormatCondition1.FieldName = "PivotGridField4"
        PivotGridStyleFormatCondition1.Value1 = New Decimal(New Integer() {0, 0, 0, 131072})
        PivotGridStyleFormatCondition2.Appearance.ForeColor = System.Drawing.Color.Transparent
        PivotGridStyleFormatCondition2.Appearance.Options.UseForeColor = True
        PivotGridStyleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal
        PivotGridStyleFormatCondition2.Field = Me.PivotGridField6
        PivotGridStyleFormatCondition2.FieldName = "PivotGridField6"
        PivotGridStyleFormatCondition2.Value1 = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.pgcCropSummaryMonthly.FormatConditions.AddRange(New DevExpress.XtraPivotGrid.PivotGridStyleFormatCondition() {PivotGridStyleFormatCondition1, PivotGridStyleFormatCondition2})
        Me.pgcCropSummaryMonthly.Location = New System.Drawing.Point(12, 81)
        Me.pgcCropSummaryMonthly.Name = "pgcCropSummaryMonthly"
        Me.pgcCropSummaryMonthly.Size = New System.Drawing.Size(678, 374)
        Me.pgcCropSummaryMonthly.TabIndex = 18
        '
        'PivotGridField1
        '
        Me.PivotGridField1.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField1.AreaIndex = 0
        Me.PivotGridField1.Caption = "EmployerNo"
        Me.PivotGridField1.FieldName = "EmployerNo"
        Me.PivotGridField1.Name = "PivotGridField1"
        '
        'PivotGridField2
        '
        Me.PivotGridField2.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField2.AreaIndex = 1
        Me.PivotGridField2.Caption = "EmployerName"
        Me.PivotGridField2.FieldName = "EmployerName"
        Me.PivotGridField2.Name = "PivotGridField2"
        '
        'PivotGridField3
        '
        Me.PivotGridField3.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField3.AreaIndex = 2
        Me.PivotGridField3.Caption = "Sex"
        Me.PivotGridField3.FieldName = "Sex"
        Me.PivotGridField3.Name = "PivotGridField3"
        '
        'PivotGridField7
        '
        Me.PivotGridField7.Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        Me.PivotGridField7.AreaIndex = 3
        Me.PivotGridField7.Caption = "Type"
        Me.PivotGridField7.FieldName = "Designation"
        Me.PivotGridField7.Name = "PivotGridField7"
        '
        'PivotGridField5
        '
        Me.PivotGridField5.Appearance.Header.Options.UseTextOptions = True
        Me.PivotGridField5.Appearance.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PivotGridField5.Appearance.Header.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PivotGridField5.Area = DevExpress.XtraPivotGrid.PivotArea.ColumnArea
        Me.PivotGridField5.AreaIndex = 0
        Me.PivotGridField5.Caption = "Day"
        Me.PivotGridField5.CellFormat.FormatString = "dd"
        Me.PivotGridField5.CellFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.PivotGridField5.FieldName = "WorkingDate"
        Me.PivotGridField5.Name = "PivotGridField5"
        Me.PivotGridField5.ValueFormat.FormatString = "dd"
        Me.PivotGridField5.ValueFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        '
        'meMonth
        '
        Me.meMonth.Location = New System.Drawing.Point(57, 43)
        Me.meMonth.Name = "meMonth"
        Me.meMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.meMonth.Size = New System.Drawing.Size(113, 20)
        Me.meMonth.StyleController = Me.LayoutControl1
        Me.meMonth.TabIndex = 17
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Require"
        Me.dxvpAttendaceReport.SetValidationRule(Me.meMonth, ConditionValidationRule1)
        '
        'leYear
        '
        Me.leYear.Location = New System.Drawing.Point(207, 43)
        Me.leYear.Name = "leYear"
        Me.leYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Year")})
        Me.leYear.Properties.NullText = ""
        Me.leYear.Size = New System.Drawing.Size(113, 20)
        Me.leYear.StyleController = Me.LayoutControl1
        Me.leYear.TabIndex = 15
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpAttendaceReport.SetValidationRule(Me.leYear, ConditionValidationRule2)
        '
        'sbGenerate
        '
        Me.sbGenerate.Location = New System.Drawing.Point(324, 43)
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
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(474, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(208, 69)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Select Tapping or Plucking"
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem6, Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(474, 69)
        Me.LayoutControlGroup2.Text = "Select Month && Year"
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.leYear
        Me.LayoutControlItem6.CustomizationFormText = "Type"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(150, 0)
        Me.LayoutControlItem6.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.Text = "Year"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.sbGenerate
        Me.LayoutControlItem1.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(300, 0)
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
        Me.LayoutControlItem4.Control = Me.meMonth
        Me.LayoutControlItem4.CustomizationFormText = "Month"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.Text = "Month"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.pgcCropSummaryMonthly
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem2"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 69)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(682, 378)
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'PivotGridField8
        '
        Me.PivotGridField8.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField8.AreaIndex = 2
        Me.PivotGridField8.Caption = "RS"
        Me.PivotGridField8.CellFormat.FormatString = "{0:N2}"
        Me.PivotGridField8.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField8.FieldName = "Sheets"
        Me.PivotGridField8.Name = "PivotGridField8"
        '
        'PivotGridField9
        '
        Me.PivotGridField9.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea
        Me.PivotGridField9.AreaIndex = 3
        Me.PivotGridField9.Caption = "SC"
        Me.PivotGridField9.CellFormat.FormatString = "{0:N2}"
        Me.PivotGridField9.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PivotGridField9.FieldName = "Scrap"
        Me.PivotGridField9.Name = "PivotGridField9"
        '
        'frmCropSummaryMonthlyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 502)
        Me.Controls.Add(Me.LayoutControl1)
        Me.KeyPreview = True
        Me.Name = "frmCropSummaryMonthlyReport"
        Me.Text = "Monthly Crop Summary Report"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.pgcCropSummaryMonthly, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents dxvpAttendaceReport As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents meMonth As DevExpress.XtraScheduler.UI.MonthEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents pgcCropSummaryMonthly As DevExpress.XtraPivotGrid.PivotGridControl
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents PivotGridField1 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField2 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField3 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField4 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField5 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField6 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField7 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField8 As DevExpress.XtraPivotGrid.PivotGridField
    Friend WithEvents PivotGridField9 As DevExpress.XtraPivotGrid.PivotGridField
End Class
