<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMonthlyIncome
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
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.dxvpMonthlyReport = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.leYear = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.meMonth = New DevExpress.XtraScheduler.UI.MonthEdit()
        Me.sbGenerate = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpMonthlyReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.CustomizationFormText = "Month"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Month"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(52, 13)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.CustomizationFormText = "Select Month & Year"
        Me.LayoutControlGroup2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(158, 49)
        Me.LayoutControlGroup2.Text = "Select Month && Year"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "Select Month & Year"
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(158, 49)
        Me.LayoutControlGroup1.Text = "Select Month && Year"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup3
        Me.LayoutControl1.Size = New System.Drawing.Size(758, 459)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.CustomizationFormText = "LayoutControlGroup3"
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(758, 459)
        Me.LayoutControlGroup3.Text = "LayoutControlGroup3"
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.CustomizationFormText = "Select Month & Year"
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup4.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(654, 69)
        Me.LayoutControlGroup4.Text = "Select Month && Year"
        '
        'leYear
        '
        Me.leYear.Location = New System.Drawing.Point(207, 43)
        Me.leYear.Name = "leYear"
        Me.leYear.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.leYear.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Key", "Year")})
        Me.leYear.Properties.NullText = ""
        Me.leYear.Size = New System.Drawing.Size(113, 20)
        Me.leYear.StyleController = Me.LayoutControl2
        Me.leYear.TabIndex = 15
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Require"
        Me.dxvpMonthlyReport.SetValidationRule(Me.leYear, ConditionValidationRule2)
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.leYear)
        Me.LayoutControl2.Controls.Add(Me.meMonth)
        Me.LayoutControl2.Controls.Add(Me.sbGenerate)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup5
        Me.LayoutControl2.Size = New System.Drawing.Size(758, 459)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl1"
        '
        'meMonth
        '
        Me.meMonth.Location = New System.Drawing.Point(57, 43)
        Me.meMonth.Name = "meMonth"
        Me.meMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.meMonth.Size = New System.Drawing.Size(113, 20)
        Me.meMonth.StyleController = Me.LayoutControl2
        Me.meMonth.TabIndex = 14
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "Require"
        Me.dxvpMonthlyReport.SetValidationRule(Me.meMonth, ConditionValidationRule1)
        '
        'sbGenerate
        '
        Me.sbGenerate.Location = New System.Drawing.Point(324, 43)
        Me.sbGenerate.Name = "sbGenerate"
        Me.sbGenerate.Size = New System.Drawing.Size(146, 22)
        Me.sbGenerate.StyleController = Me.LayoutControl2
        Me.sbGenerate.TabIndex = 12
        Me.sbGenerate.Text = "Generate"
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem3, Me.LayoutControlGroup6, Me.EmptySpaceItem1})
        Me.LayoutControlGroup5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup5.Name = "Root"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(758, 459)
        Me.LayoutControlGroup5.Text = "Root"
        Me.LayoutControlGroup5.TextVisible = False
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(474, 0)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(264, 69)
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.CustomizationFormText = "Select Month & Year"
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem6, Me.LayoutControlItem2})
        Me.LayoutControlGroup6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup6.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(474, 69)
        Me.LayoutControlGroup6.Text = "Select Month && Year"
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.meMonth
        Me.LayoutControlItem1.CustomizationFormText = "Month"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem5"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Month"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(30, 13)
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
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(30, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.sbGenerate
        Me.LayoutControlItem2.CustomizationFormText = "LayoutControlItem1"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(300, 0)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem1"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(150, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "LayoutControlItem1"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 69)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(738, 370)
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'frmMonthlyIncome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 459)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "frmMonthlyIncome"
        Me.Text = "Monthly Report"
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpMonthlyReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.leYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.meMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents dxvpMonthlyReport As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents leYear As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents meMonth As DevExpress.XtraScheduler.UI.MonthEdit
    Friend WithEvents sbGenerate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
