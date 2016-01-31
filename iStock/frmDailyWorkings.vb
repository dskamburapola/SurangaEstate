Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockDailyWorking
Imports iStockCommon.iStockConstants

Public Class frmDailyWorkings


#Region "Properties"

    Private _iStockEmployers As iStockCommon.iStockEmployers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings
    Dim _iStockItems As iStockCommon.iStockStock

#End Region

#Region "Constructors"

    Public ReadOnly Property iStockItems() As iStockCommon.iStockStock
        Get

            If _iStockItems Is Nothing Then
                _iStockItems = New iStockCommon.iStockStock
            End If

            Return _iStockItems
        End Get
    End Property

    Public ReadOnly Property iStockEmployers() As iStockCommon.iStockEmployers
        Get

            If _iStockEmployers Is Nothing Then
                _iStockEmployers = New iStockCommon.iStockEmployers
            End If

            Return _iStockEmployers
        End Get
    End Property

    Public ReadOnly Property iStockDailyWorking() As iStockCommon.iStockDailyWorking
        Get

            If _iStockDailyWorking Is Nothing Then
                _iStockDailyWorking = New iStockCommon.iStockDailyWorking
            End If

            Return _iStockDailyWorking
        End Get
    End Property

    Public ReadOnly Property ECSSettings() As iStockCommon.iStockSettings
        Get

            If _ECSSettings Is Nothing Then
                _ECSSettings = New iStockCommon.iStockSettings
            End If

            Return _ECSSettings
        End Get
    End Property
#End Region

#Region "Form Events"

    Private Sub frmDailyWorkings_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        'Me.DisplayCompany()
        Me.GetWorkingCategory()
        'Me.GetEmployeeForWork()
        Me.DisplaySettings()

        Me.deWorkingDate.EditValue = Date.Today
        Me.deStartDate.EditValue = Date.Today
        Me.deEndDate.EditValue = Date.Today

        Me.deWorkingDate.Focus()

        '  MessageBox.Show(Me.deWorkingDate.EditValue)



    End Sub

    Private Sub frmDailyWorkings_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.PopulateStockItemsGridLookup()

    End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Enabled = False
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Bar Button Events"

    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpDailyWorking.Validate Then

            Me.SaveDailyWorking()
        End If


    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        PrintPreview(gcAllWorkings, "Daily Workings")
    End Sub

#End Region

#Region "Get Working Category"
    Private Sub GetWorkingCategory()

        Try

            Me.leWorkCategory.Properties.DataSource = ECSSettings.GetAbbreviations.Tables(0)
            Me.leWorkCategory.Properties.DisplayMember = "AbbreviationDesc"
            Me.leWorkCategory.Properties.ValueMember = "AbbreviationID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try
           
            iStockDailyWorking.WorkType = cmbWorkType.Text.Trim
            Me.leEmployee.Properties.DataSource = iStockDailyWorking.GetEmployeeForWork.Tables(0)
            Me.leEmployee.Properties.DisplayMember = "EmployerNo"
            Me.leEmployee.Properties.ValueMember = "EmployerID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Daily Working Get By Date"
    Private Sub DailyWorkingGetByDate()

        Try

            If (deWorkingDate.EditValue IsNot Nothing) Then



                With iStockDailyWorking



                    .WorkingDate = deWorkingDate.EditValue
                    gcDailyWorking.DataSource = .DailyWorkingGetByDate.Tables(0)

                    gvDailyWorking.Columns("AbbreviationDesc").Group()
                    gvDailyWorking.ExpandAllGroups()


                End With
            End If



        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Daily Working Get All By Dates"
    Private Sub DailyWorkingGetAllByDates()

        Try


            With iStockDailyWorking

                .StartDate = deStartDate.EditValue
                .EndDate = deEndDate.EditValue
                gcAllWorkings.DataSource = .DailyWorkingGetAllByDates.Tables(0)

            End With




        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Save Daily Working"
    Private Sub SaveDailyWorking()

        Try
            With iStockDailyWorking

                .WorkingDate = Me.deWorkingDate.EditValue
                .WorkType = Me.cmbWorkType.Text.Trim
                .AbbreviationID = Me.leWorkCategory.EditValue
                .EmployeeID = leEmployee.EditValue 'lblID.Text.Trim
                .WorkedDays = Me.cmbDays.Text.Trim
                .Quantity = Me.seQuantity.Text.Trim

                Select Case leWorkCategory.Text
                    Case "PLUCKING"

                        .KgsPerDay = Convert.ToDecimal(lblKgsPerDay.Text.Trim)
                        .OverKgRate = Convert.ToDecimal(lblOverKgsRate.Text.Trim)
                        .KgsPerDayNotMandatory = Convert.ToDecimal(lblKgsPerDayNotMandatory.Text.Trim)
                        .OverKGUpperLimit = Convert.ToDecimal(lblOverKgUpperLimit.Text.Trim)

                    Case Else
                        .KgsPerDay = 0
                        .OverKgRate = 0

                End Select


                .EPF = Convert.ToDecimal(lblEPF.Text.Trim)
                .ETF = Convert.ToDecimal(lblETF.Text.Trim)

                Select Case cmbWorkType.Text

                    Case "PERMANENT"
                        .DayRate = Convert.ToDecimal(lblDayRate.Text.Trim)
                        .OTRate = Convert.ToDecimal(lblOTRate.Text.Trim)

                        .CasualPayRate = 0
                        .CasualOTPayRate = 0
                        .WCPay = Convert.ToDecimal(lblWCPay.Text)
                        .IncentiveDays = Convert.ToDecimal(lblIncentiveDays.Text)
                        .IncentiveRate = Convert.ToDecimal(lblIncentiveRate.Text)
                        .PayChitCost = Convert.ToDecimal(lblPayChit.Text)

                    Case "CASUAL"
                        .DayRate = 0
                        .OTRate = 0


                        .CasualPayRate = Convert.ToDecimal(lblCasualPayRate.Text.Trim)
                        .CasualOTPayRate = Convert.ToDecimal(lblCasualOTPayRate.Text.Trim)

                        .WCPay = 0
                        .IncentiveDays = 0
                        .IncentiveRate = 0
                        .PayChitCost = 0


                       

                End Select

                .IsDeleted = 0
                .CreatedBy = UserID
                .StockID = leStock.EditValue
                .InsertDailyWorking()

                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With


            Me.DailyWorkingGetByDate()
            Me.ClearFormData()

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try




    End Sub
#End Region

#Region "Display Settings"
    Private Sub DisplaySettings()
        Try
            With ECSSettings
                .GetSettings()

                Me.lblDayRate.Text = .DayRate
                Me.lblOTRate.Text = .OTRate
                Me.lblKgsPerDay.Text = .KgsPerDay
                Me.lblCasualPayRate.Text = .CasualPayRate
                Me.lblCasualOTPayRate.Text = .CasualOTPayRate
                Me.lblEPF.Text = .EPF
                Me.lblOverKgsRate.Text = .OverKgRate
                Me.lblWCPay.Text = .WCPay
                Me.lblIncentiveDays.Text = .IncentiveDays
                Me.lblIncentiveRate.Text = .EvalutionAllowance
                Me.lblPayChit.Text = .PayChitCost
                Me.lblKgsPerDayNotMandatory.Text = .KgsPerDayNotMandatory
                Me.lblETF.Text = .ETF
                Me.lblOverKgUpperLimit.Text = .OverKGUpperLimit
            End With
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try


    End Sub
#End Region

#Region "Clear Form Data"
    Public Sub ClearFormData()

        Me.cmbWorkType.SelectedIndex = -1
        Me.leWorkCategory.EditValue = Nothing
        Me.leEmployee.EditValue = Nothing
        Me.cmbDays.Text = String.Empty
        Me.seQuantity.Text = 0
        Me.leStock.EditValue = Nothing
        Me.cmbWorkType.Focus()

    End Sub
#End Region

#Region "Delete Daily Working"
    Private Sub DeleteDailyWorking()

        Try
            With iStockDailyWorking
                '.DailyWorkingID = Me.gvDailyWorking.GetFocusedRowCellValue(GridColumn1)
                .DailyWorkingID = Convert.ToInt64(IIf(lblDeleteID.Text = String.Empty, 0, lblDeleteID.Text.ToString))
                .DailyWorkingDelete()
            End With


        Catch ex As SqlClient.SqlException
            Dim frm As New frmOk
            frm.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_DELETE_ERROR_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()
        End Try

    End Sub
#End Region

#Region "Daily Working IfExists"
    Public Sub DailyWorkingIfExists()

        Try


            With iStockDailyWorking
                .CheckDays = 0
                .CheckEmployeeID = 0

                .EmployeeID = Me.leEmployee.EditValue
                .WorkingDate = Convert.ToDateTime(Me.deWorkingDate.Text)

                .DailyWorkingIfExists()

                If Me.leEmployee.EditValue = .CheckEmployeeID Then

                    If .CheckDays = 1 Then
                        MsgBox("Employee Already Exists. Multiple Days Not Allowed")

                    ElseIf .CheckDays = 0.5 And cmbDays.Text = 0.5 Then
                        '  MsgBox("0.5 day allowed")
                        seQuantity.Focus()
                    Else
                        MsgBox("Employee Already Worked as 0.5 Day. 01 Day Not Allowed")

                    End If

                Else
                    'MsgBox("no")
                    Me.seQuantity.Focus()

                End If
            End With



        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

#Region "Tab Events"

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()


        End Select
    End Sub

#End Region

#Region "Editors Events"

    Private Sub deWorkingDate_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles deWorkingDate.EditValueChanged
        Me.DailyWorkingGetByDate()

    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        Me.DeleteDailyWorking()
    End Sub

    Private Sub leEmployee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leEmployee.EditValueChanged
        'teEmployeeName.Text = leEmployee.GetColumnValue("EmployerName")
    End Sub

    Private Sub leWorkCategory_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leWorkCategory.EditValueChanged

    End Sub

    Private Sub seQuantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox("Leave working")
        'Me.SaveDailyWorking()
        'Me.ClearFormData()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Me.DailyWorkingGetAllByDates()

    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemButtonEdit1.Click

        lblDeleteID.Text = (Me.gvDailyWorking.GetFocusedRowCellValue(GridColumn1))

        If Not lblDeleteID.Text = String.Empty Then
            Dim frm As New frmDeleteYesNo
            frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
            frm.lblDescription.ForeColor = Color.Red
            frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
            frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
            frm.Text = CWB_DELETE_CONFIRMATION_TITLE

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Me.DeleteDailyWorking()
                Me.DailyWorkingGetByDate()

            End If
        End If




    End Sub

    Private Sub seQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles seQuantity.KeyPress

        If e.KeyChar = Chr(13) Then
            If dxvpDailyWorking.Validate Then
                Me.SaveDailyWorking()
            End If
        End If

    End Sub

    Private Sub frmDailyWorkings_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbDays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDays.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.DailyWorkingIfExists()
        End If
    End Sub

    Private Sub cmbWorkType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkType.SelectedIndexChanged
        Me.GetEmployeeForWork()
    End Sub

#End Region

#Region "Show/Display bar button"

    Public Sub ShowToolButtonsOnNewRecordTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        'Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub

    Public Sub ShowToolButtonsOnHistoryTabChange()

        'Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub

#End Region
  
#Region "Populate Stock Items Grid Lookup"
    Public Sub PopulateStockItemsGridLookup()

        Try
            With leStock
                .Properties.DataSource = iStockItems.GetAllStockItems.Tables(0)
                .Properties.DisplayMember = "StockCode"
                .Properties.ValueMember = "StockID"
            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region
    

  





End Class