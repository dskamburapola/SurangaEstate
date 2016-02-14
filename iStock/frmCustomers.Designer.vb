<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCustomers))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.bbSave = New DevExpress.XtraBars.BarButtonItem()
        Me.bbNew = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDelete = New DevExpress.XtraBars.BarButtonItem()
        Me.bbDisplaySelected = New DevExpress.XtraBars.BarButtonItem()
        Me.bbRefresh = New DevExpress.XtraBars.BarButtonItem()
        Me.bbPrint = New DevExpress.XtraBars.BarButtonItem()
        Me.bbClose = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.xTab1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.cbeSalutation = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.seCustomerNo = New DevExpress.XtraEditors.SpinEdit()
        Me.lblCustomerID = New DevExpress.XtraEditors.LabelControl()
        Me.teWebURL = New DevExpress.XtraEditors.TextEdit()
        Me.teEmail = New DevExpress.XtraEditors.TextEdit()
        Me.teFax = New DevExpress.XtraEditors.TextEdit()
        Me.teTelephone = New DevExpress.XtraEditors.TextEdit()
        Me.teAddressLine3 = New DevExpress.XtraEditors.TextEdit()
        Me.teAddressLine2 = New DevExpress.XtraEditors.TextEdit()
        Me.teAddressLine1 = New DevExpress.XtraEditors.TextEdit()
        Me.teCustomerName = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.gcCustomers = New DevExpress.XtraGrid.GridControl()
        Me.gvCustomers = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.dxvpCustomers = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.xTab1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.cbeSalutation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seCustomerNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teWebURL.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teTelephone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teAddressLine3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teAddressLine2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teAddressLine1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.teCustomerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.gcCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dxvpCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.bbSave, Me.bbNew, Me.bbDelete, Me.bbDisplaySelected, Me.bbRefresh, Me.bbClose, Me.bbPrint})
        Me.BarManager1.MainMenu = Me.Bar2
        Me.BarManager1.MaxItemId = 8
        '
        'Bar2
        '
        Me.Bar2.BarName = "Main menu"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.bbSave), New DevExpress.XtraBars.LinkPersistInfo(Me.bbNew), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.bbDisplaySelected), New DevExpress.XtraBars.LinkPersistInfo(Me.bbRefresh), New DevExpress.XtraBars.LinkPersistInfo(Me.bbPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.bbClose)})
        Me.Bar2.OptionsBar.AllowQuickCustomization = False
        Me.Bar2.OptionsBar.MultiLine = True
        Me.Bar2.OptionsBar.UseWholeRow = True
        Me.Bar2.Text = "Main menu"
        '
        'bbSave
        '
        Me.bbSave.Caption = "BarButtonItem1"
        Me.bbSave.Id = 0
        Me.bbSave.Name = "bbSave"
        '
        'bbNew
        '
        Me.bbNew.Caption = "BarButtonItem2"
        Me.bbNew.Id = 1
        Me.bbNew.Name = "bbNew"
        '
        'bbDelete
        '
        Me.bbDelete.Caption = "BarButtonItem3"
        Me.bbDelete.Id = 2
        Me.bbDelete.Name = "bbDelete"
        '
        'bbDisplaySelected
        '
        Me.bbDisplaySelected.Caption = "BarButtonItem4"
        Me.bbDisplaySelected.Id = 3
        Me.bbDisplaySelected.Name = "bbDisplaySelected"
        '
        'bbRefresh
        '
        Me.bbRefresh.Caption = "BarButtonItem5"
        Me.bbRefresh.Id = 4
        Me.bbRefresh.Name = "bbRefresh"
        '
        'bbPrint
        '
        Me.bbPrint.Caption = "BarButtonItem1"
        Me.bbPrint.Id = 7
        Me.bbPrint.Name = "bbPrint"
        '
        'bbClose
        '
        Me.bbClose.Caption = "BarButtonItem6"
        Me.bbClose.Id = 5
        Me.bbClose.Name = "bbClose"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(701, 44)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 433)
        Me.barDockControlBottom.Size = New System.Drawing.Size(701, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 44)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 389)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(701, 44)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 389)
        '
        'xTab1
        '
        Me.xTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.xTab1.Location = New System.Drawing.Point(0, 44)
        Me.xTab1.Name = "xTab1"
        Me.xTab1.SelectedTabPage = Me.XtraTabPage1
        Me.xTab1.Size = New System.Drawing.Size(701, 389)
        Me.xTab1.TabIndex = 4
        Me.xTab1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.LayoutControl1)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(695, 361)
        Me.XtraTabPage1.Text = "New Record"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.cbeSalutation)
        Me.LayoutControl1.Controls.Add(Me.seCustomerNo)
        Me.LayoutControl1.Controls.Add(Me.lblCustomerID)
        Me.LayoutControl1.Controls.Add(Me.teWebURL)
        Me.LayoutControl1.Controls.Add(Me.teEmail)
        Me.LayoutControl1.Controls.Add(Me.teFax)
        Me.LayoutControl1.Controls.Add(Me.teTelephone)
        Me.LayoutControl1.Controls.Add(Me.teAddressLine3)
        Me.LayoutControl1.Controls.Add(Me.teAddressLine2)
        Me.LayoutControl1.Controls.Add(Me.teAddressLine1)
        Me.LayoutControl1.Controls.Add(Me.teCustomerName)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(695, 361)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'cbeSalutation
        '
        Me.cbeSalutation.EnterMoveNextControl = True
        Me.cbeSalutation.Location = New System.Drawing.Point(91, 84)
        Me.cbeSalutation.Name = "cbeSalutation"
        Me.cbeSalutation.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbeSalutation.Properties.Items.AddRange(New Object() {"MR.", "MRS.", "MS.", "VEN."})
        Me.cbeSalutation.Size = New System.Drawing.Size(56, 20)
        Me.cbeSalutation.StyleController = Me.LayoutControl1
        Me.cbeSalutation.TabIndex = 1
        '
        'seCustomerNo
        '
        Me.seCustomerNo.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.seCustomerNo.EnterMoveNextControl = True
        Me.seCustomerNo.Location = New System.Drawing.Point(91, 60)
        Me.seCustomerNo.Name = "seCustomerNo"
        Me.seCustomerNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.seCustomerNo.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.seCustomerNo.Size = New System.Drawing.Size(86, 20)
        Me.seCustomerNo.StyleController = Me.LayoutControl1
        Me.seCustomerNo.TabIndex = 0
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.Greater
        ConditionValidationRule1.ErrorText = "Can not be Blank"
        ConditionValidationRule1.Value1 = 0
        Me.dxvpCustomers.SetValidationRule(Me.seCustomerNo, ConditionValidationRule1)
        '
        'lblCustomerID
        '
        Me.lblCustomerID.Location = New System.Drawing.Point(12, 43)
        Me.lblCustomerID.Name = "lblCustomerID"
        Me.lblCustomerID.Size = New System.Drawing.Size(671, 13)
        Me.lblCustomerID.StyleController = Me.LayoutControl1
        Me.lblCustomerID.TabIndex = 13
        Me.lblCustomerID.Visible = False
        '
        'teWebURL
        '
        Me.teWebURL.EnterMoveNextControl = True
        Me.teWebURL.Location = New System.Drawing.Point(429, 204)
        Me.teWebURL.Name = "teWebURL"
        Me.teWebURL.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teWebURL.Properties.MaxLength = 50
        Me.teWebURL.Size = New System.Drawing.Size(254, 20)
        Me.teWebURL.StyleController = Me.LayoutControl1
        Me.teWebURL.TabIndex = 9
        '
        'teEmail
        '
        Me.teEmail.EnterMoveNextControl = True
        Me.teEmail.Location = New System.Drawing.Point(91, 204)
        Me.teEmail.Name = "teEmail"
        Me.teEmail.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teEmail.Properties.MaxLength = 50
        Me.teEmail.Size = New System.Drawing.Size(255, 20)
        Me.teEmail.StyleController = Me.LayoutControl1
        Me.teEmail.TabIndex = 8
        '
        'teFax
        '
        Me.teFax.EnterMoveNextControl = True
        Me.teFax.Location = New System.Drawing.Point(429, 180)
        Me.teFax.Name = "teFax"
        Me.teFax.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teFax.Properties.MaxLength = 50
        Me.teFax.Size = New System.Drawing.Size(254, 20)
        Me.teFax.StyleController = Me.LayoutControl1
        Me.teFax.TabIndex = 7
        '
        'teTelephone
        '
        Me.teTelephone.EnterMoveNextControl = True
        Me.teTelephone.Location = New System.Drawing.Point(91, 180)
        Me.teTelephone.Name = "teTelephone"
        Me.teTelephone.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teTelephone.Properties.MaxLength = 50
        Me.teTelephone.Size = New System.Drawing.Size(255, 20)
        Me.teTelephone.StyleController = Me.LayoutControl1
        Me.teTelephone.TabIndex = 6
        '
        'teAddressLine3
        '
        Me.teAddressLine3.EnterMoveNextControl = True
        Me.teAddressLine3.Location = New System.Drawing.Point(91, 156)
        Me.teAddressLine3.Name = "teAddressLine3"
        Me.teAddressLine3.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teAddressLine3.Properties.MaxLength = 100
        Me.teAddressLine3.Size = New System.Drawing.Size(592, 20)
        Me.teAddressLine3.StyleController = Me.LayoutControl1
        Me.teAddressLine3.TabIndex = 5
        '
        'teAddressLine2
        '
        Me.teAddressLine2.EnterMoveNextControl = True
        Me.teAddressLine2.Location = New System.Drawing.Point(91, 132)
        Me.teAddressLine2.Name = "teAddressLine2"
        Me.teAddressLine2.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teAddressLine2.Properties.MaxLength = 100
        Me.teAddressLine2.Size = New System.Drawing.Size(592, 20)
        Me.teAddressLine2.StyleController = Me.LayoutControl1
        Me.teAddressLine2.TabIndex = 4
        '
        'teAddressLine1
        '
        Me.teAddressLine1.EnterMoveNextControl = True
        Me.teAddressLine1.Location = New System.Drawing.Point(91, 108)
        Me.teAddressLine1.Name = "teAddressLine1"
        Me.teAddressLine1.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teAddressLine1.Properties.MaxLength = 100
        Me.teAddressLine1.Size = New System.Drawing.Size(592, 20)
        Me.teAddressLine1.StyleController = Me.LayoutControl1
        Me.teAddressLine1.TabIndex = 3
        '
        'teCustomerName
        '
        Me.teCustomerName.EnterMoveNextControl = True
        Me.teCustomerName.Location = New System.Drawing.Point(151, 84)
        Me.teCustomerName.Name = "teCustomerName"
        Me.teCustomerName.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.teCustomerName.Properties.MaxLength = 50
        Me.teCustomerName.Size = New System.Drawing.Size(195, 20)
        Me.teCustomerName.StyleController = Me.LayoutControl1
        Me.teCustomerName.TabIndex = 2
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "Can not be Blank"
        Me.dxvpCustomers.SetValidationRule(Me.teCustomerName, ConditionValidationRule2)
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.CustomizationFormText = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.EmptySpaceItem1, Me.EmptySpaceItem2, Me.LayoutControlItem10, Me.EmptySpaceItem3, Me.LayoutControlItem11, Me.LayoutControlItem1, Me.EmptySpaceItem4})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(695, 361)
        Me.LayoutControlGroup1.Text = "LayoutControlGroup1"
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.teCustomerName
        Me.LayoutControlItem2.CustomizationFormText = "Customer Name"
        Me.LayoutControlItem2.Location = New System.Drawing.Point(139, 72)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(0, 22)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(54, 22)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 0)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(199, 24)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "LayoutControlItem2"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextToControlDistance = 0
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.teAddressLine1
        Me.LayoutControlItem3.CustomizationFormText = "Address Line1"
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem3.Text = "Address Line1"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.teAddressLine2
        Me.LayoutControlItem4.CustomizationFormText = "Address Line2"
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem4.Text = "Address Line2"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.teAddressLine3
        Me.LayoutControlItem5.CustomizationFormText = "Address Line3"
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(675, 24)
        Me.LayoutControlItem5.Text = "Address Line3"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.teTelephone
        Me.LayoutControlItem6.CustomizationFormText = "Telephone"
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(338, 24)
        Me.LayoutControlItem6.Text = "Telephone"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.teEmail
        Me.LayoutControlItem8.CustomizationFormText = "Email"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 192)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(338, 149)
        Me.LayoutControlItem8.Text = "Email"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.teFax
        Me.LayoutControlItem7.CustomizationFormText = "Fax"
        Me.LayoutControlItem7.Location = New System.Drawing.Point(338, 168)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(337, 24)
        Me.LayoutControlItem7.Text = "Fax"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.teWebURL
        Me.LayoutControlItem9.CustomizationFormText = "Web URL"
        Me.LayoutControlItem9.Location = New System.Drawing.Point(338, 192)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(337, 149)
        Me.LayoutControlItem9.Text = "Web URL"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(76, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.CustomizationFormText = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(338, 72)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(100, 20)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(337, 24)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.Text = "EmptySpaceItem1"
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.CustomizationFormText = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(338, 48)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(337, 24)
        Me.EmptySpaceItem2.Text = "EmptySpaceItem2"
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lblCustomerID
        Me.LayoutControlItem10.CustomizationFormText = "LayoutControlItem10"
        Me.LayoutControlItem10.Location = New System.Drawing.Point(0, 31)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(675, 17)
        Me.LayoutControlItem10.Text = "LayoutControlItem10"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextToControlDistance = 0
        Me.LayoutControlItem10.TextVisible = False
        Me.LayoutControlItem10.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.CustomizationFormText = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 0)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 31)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.ShowInCustomizationForm = False
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(675, 31)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.Text = "EmptySpaceItem3"
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.seCustomerNo
        Me.LayoutControlItem11.CustomizationFormText = "Customer No"
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(169, 24)
        Me.LayoutControlItem11.Text = "Customer No"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(76, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.cbeSalutation
        Me.LayoutControlItem1.CustomizationFormText = "Customer Name"
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(142, 31)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(136, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(139, 24)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "Customer Name"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(76, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.CustomizationFormText = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(169, 48)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(169, 24)
        Me.EmptySpaceItem4.Text = "EmptySpaceItem4"
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.gcCustomers)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(695, 361)
        Me.XtraTabPage2.Text = "History Data"
        '
        'gcCustomers
        '
        Me.gcCustomers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCustomers.Location = New System.Drawing.Point(0, 0)
        Me.gcCustomers.MainView = Me.gvCustomers
        Me.gcCustomers.Name = "gcCustomers"
        Me.gcCustomers.Size = New System.Drawing.Size(695, 361)
        Me.gcCustomers.TabIndex = 0
        Me.gcCustomers.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCustomers, Me.GridView2})
        '
        'gvCustomers
        '
        Me.gvCustomers.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12})
        Me.gvCustomers.GridControl = Me.gcCustomers
        Me.gvCustomers.Name = "gvCustomers"
        Me.gvCustomers.OptionsBehavior.Editable = False
        Me.gvCustomers.OptionsView.ColumnAutoWidth = False
        Me.gvCustomers.OptionsView.EnableAppearanceOddRow = True
        Me.gvCustomers.OptionsView.ShowAutoFilterRow = True
        Me.gvCustomers.OptionsView.ShowFooter = True
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "CustomerID"
        Me.GridColumn1.FieldName = "CustomerID"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Customer No"
        Me.GridColumn2.FieldName = "CustomerNo"
        Me.GridColumn2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)})
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 0
        Me.GridColumn2.Width = 120
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Customer Name"
        Me.GridColumn3.FieldName = "CustomerName"
        Me.GridColumn3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 150
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Address Line1"
        Me.GridColumn4.FieldName = "AddressLine1"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 2
        Me.GridColumn4.Width = 120
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Telephone"
        Me.GridColumn5.FieldName = "Telephone"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 3
        Me.GridColumn5.Width = 120
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Fax"
        Me.GridColumn6.FieldName = "Fax"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 4
        Me.GridColumn6.Width = 120
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Email"
        Me.GridColumn7.FieldName = "Email"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 5
        Me.GridColumn7.Width = 120
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "WebURL"
        Me.GridColumn8.FieldName = "WebURL"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 6
        Me.GridColumn8.Width = 120
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Created By"
        Me.GridColumn9.FieldName = "CreatedBy"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 7
        Me.GridColumn9.Width = 120
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Created Date"
        Me.GridColumn10.DisplayFormat.FormatString = "dd-MMM-yy h:mm tt"
        Me.GridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn10.FieldName = "CreatedDate"
        Me.GridColumn10.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 120
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Updated By"
        Me.GridColumn11.FieldName = "UpdatedBy"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 9
        Me.GridColumn11.Width = 120
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Updated Date"
        Me.GridColumn12.DisplayFormat.FormatString = "dd-MMM-yy h:mm tt"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn12.FieldName = "UpdatedDate"
        Me.GridColumn12.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 10
        Me.GridColumn12.Width = 120
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gcCustomers
        Me.GridView2.Name = "GridView2"
        '
        'frmCustomers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 433)
        Me.Controls.Add(Me.xTab1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCustomers"
        Me.Text = "Customers"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.xTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.xTab1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.cbeSalutation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seCustomerNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teWebURL.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teTelephone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teAddressLine3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teAddressLine2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teAddressLine1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.teCustomerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.gcCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dxvpCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents bbSave As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbNew As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDelete As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbDisplaySelected As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbRefresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents bbClose As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents xTab1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents gcCustomers As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCustomers As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents teCustomerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teAddressLine2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents teAddressLine1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teAddressLine3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teTelephone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents teWebURL As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lblCustomerID As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents dxvpCustomers As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents bbPrint As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents seCustomerNo As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents cbeSalutation As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
