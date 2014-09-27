Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockDailyWorking
Imports iStockCommon.iStockConstants

Public Class frmDailyWorkings

    Dim dt As DataTable
    Dim dr As DataRow
    Dim ds As DataSet



#Region "Properties"
    Private _iStockEmployers As iStockCommon.iStockEmployers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings

#End Region

#Region "Constructors"

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

        ' If dxvpDailyWorking.Validate Then

        Me.SaveDailyWorking()
        Me.DailyWorkingGetByDate()
        'End If


    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
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

#Region "Get Stock Items"
    Private Sub GetStockItems()

        Try

            Me.leStockItem.Properties.DataSource = iStockDailyWorking.StockGetAll.Tables(0)
            Me.leStockItem.Properties.DisplayMember = "Description"
            Me.leStockItem.Properties.ValueMember = "StockID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region


#Region "Create Data Table"

    Public Sub CreateDataTable()
        '------------------------------Grid 01
        dt = New DataTable("Rubber")
        ds = New DataSet
        dt.Columns.Add("EmployeeID") '0
        dt.Columns.Add("EmployerNo") '1
        dt.Columns.Add("EmployerName") '2
        dt.Columns.Add("StockID") '3
        dt.Columns.Add("Description") '4
        dt.Columns.Add("ItemQuantity") '5

        ds.Tables.Add(dt)
        gcRubberSheet.DataSource = ds
        gcRubberSheet.DataMember = "Rubber"

    End Sub

#End Region


#Region "Get Working Category For Rubber Sheets"
    Private Sub ClearRubberSheet()

        Try
            Me.deRubberSheet.EditValue = Date.Today
            Me.leRubberSheets.EditValue = Nothing
            Me.leRubberWorkers.EditValue = Nothing
            Me.cmbRubberDays.Text = String.Empty
            Me.leStockItem.EditValue = Nothing
            Me.seItems.Text = 0
            Me.gcRubberSheet.DataSource = Nothing
            Me.deRubberSheet.Focus()

        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region


#Region "Get Working Category For Rubber Sheets"
    Private Sub GetWorkingCategoryForRubberSheets()

        Try

            Me.leRubberSheets.Properties.DataSource = ECSSettings.GetAbbreviationsForRubberSheets.Tables(0)
            Me.leRubberSheets.Properties.DisplayMember = "AbbreviationDesc"
            Me.leRubberSheets.Properties.ValueMember = "AbbreviationID"


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

#Region "Get Employee For Work"
    Private Sub GetEmployeeForRubber()

        Try

            iStockDailyWorking.WorkType = "PERMANENT"
            Me.leRubberWorkers.Properties.DataSource = iStockDailyWorking.GetEmployeeForWork.Tables(0)
            Me.leRubberWorkers.Properties.DisplayMember = "EmployerNo"
            Me.leRubberWorkers.Properties.ValueMember = "EmployerID"


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




                End With
            End If



        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Daily Working Rubber Get By Date"
    Private Sub DailyWorkingRubberGetByID()

        Try

            '            If (deRubberSheet.EditValue IsNot Nothing) Then



            With iStockDailyWorking



                iStockDailyWorking.DailyWorkingID = Me.gvAllWorkings.GetFocusedRowCellValue(GridColumn26)
                gcRubberSheet.DataSource = .DailyWorkingRubberGetByID.Tables(0)




            End With
            ' End If



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

#Region "Daily Working Get All By Dates"
    Private Sub DailyWorkingGetRubberByDates()

        Try


            With iStockDailyWorking

                .StartDate = deStartDate.EditValue
                .EndDate = deEndDate.EditValue
                gcAllWorkings.DataSource = .DailyWorkingGetRubberByDates.Tables(0)

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

                    Case Else
                        .KgsPerDay = 0
                        .OverKgRate = 0

                End Select


                .EPF = Convert.ToDecimal(lblEPF.Text.Trim)

                Select Case cmbWorkType.Text

                    Case "PERMANENT"
                        .DayRate = Convert.ToDecimal(lblDayRate.Text.Trim)
                        .OTRate = Convert.ToDecimal(lblOTRate.Text.Trim)

                        .CasualPayRate = 0
                        .CasualOTPayRate = 0
                      
                    Case "CASUAL"
                        .DayRate = 0
                        .OTRate = 0


                        .CasualPayRate = Convert.ToDecimal(lblCasualPayRate.Text.Trim)
                        .CasualOTPayRate = Convert.ToDecimal(lblCasualOTPayRate.Text.Trim)


                End Select
                .WCPay = Convert.ToDecimal(lblWCPay.Text)
                .IncentiveDays = Convert.ToDecimal(lblIncentiveDays.Text)
                .IncentiveRate = Convert.ToDecimal(lblIncentiveRate.Text)
                .PayChitCost = Convert.ToDecimal(lblPayChit.Text)

                .IsDeleted = 0
                .CreatedBy = UserID

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

#Region "Save Rubber Working"
    Private Sub SaveRubberWorking()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try
            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            gvRubberSheet.PostEditor()
            '     gvRubberSheet.MoveLast()


            With iStockDailyWorking
                .DailyWorkingID = Convert.ToInt64(IIf(lblRubberID.Text = String.Empty, 0, lblRubberID.Text))
                .WorkingDate = Me.deRubberSheet.EditValue
                .WorkType = "PERMANENT"
                .AbbreviationID = Me.leRubberSheets.EditValue
                .EmployeeID = leRubberWorkers.EditValue 'lblID.Text.Trim
                .WorkedDays = Me.cmbRubberDays.Text.Trim
                .Quantity = Val(Me.GridColumn33.SummaryText)
                .DayRate = Convert.ToDecimal(lblDayRate.Text.Trim)
                .OTRate = Convert.ToDecimal(lblOTRate.Text.Trim)
                .KgsPerDay = 0
                .OverKgRate = 0
                .WCPay = Convert.ToDecimal(lblWCPay.Text)
                .IncentiveDays = Convert.ToDecimal(lblIncentiveDays.Text)
                .IncentiveRate = Convert.ToDecimal(lblIncentiveRate.Text)
                .PayChitCost = Convert.ToDecimal(lblPayChit.Text)
                .EPF = Convert.ToDecimal(lblEPF.Text.Trim)
                .CasualPayRate = 0
                .CasualOTPayRate = 0
                .IsDeleted = 0
                .CreatedBy = UserID

                .InsertRubberWorking(_DB, _Transaction)
              
                For i As Integer = 0 To Me.gvRubberSheet.RowCount
                    If Not gvRubberSheet.GetRowCellDisplayText(i, gvRubberSheet.Columns(1)) = "" Then
                        .CurrentDailyWorkingID = .CurrentDailyWorkingID
                        .StockID = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn31))
                        .ItemQuantity = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn33))
                        .InsertRubberWorkingDescription(_DB, _Transaction)

                        ' Update Main Stock
                        .StockID = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn31))
                        .ItemQuantity = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn33))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next
                _Transaction.Commit()

                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With


            ' Me.DailyWorkingGetByDate()
            Me.ClearFormData()

        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If

        End Try




    End Sub
#End Region

#Region "Update Rubber Working"
    Private Sub UpdateRubberWorking()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try
            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            gvRubberSheet.PostEditor()
            '     gvRubberSheet.MoveLast()


            With iStockDailyWorking
                .DailyWorkingID = Convert.ToInt64(IIf(lblRubberID.Text = String.Empty, 0, lblRubberID.Text))
                .WorkingDate = Me.deRubberSheet.EditValue
                .WorkType = "PERMANENT"
                .AbbreviationID = Me.leRubberSheets.EditValue
                .EmployeeID = leRubberWorkers.EditValue 'lblID.Text.Trim
                .WorkedDays = Me.cmbRubberDays.Text.Trim
                .Quantity = Val(Me.GridColumn33.SummaryText)
                .DayRate = Convert.ToDecimal(lblDayRate.Text.Trim)
                .OTRate = Convert.ToDecimal(lblOTRate.Text.Trim)
                .KgsPerDay = 0
                .OverKgRate = 0
                .WCPay = Convert.ToDecimal(lblWCPay.Text)
                .IncentiveDays = Convert.ToDecimal(lblIncentiveDays.Text)
                .IncentiveRate = Convert.ToDecimal(lblIncentiveRate.Text)
                .PayChitCost = Convert.ToDecimal(lblPayChit.Text)
                .EPF = Convert.ToDecimal(lblEPF.Text.Trim)
                .CasualPayRate = 0
                .CasualOTPayRate = 0
                .IsDeleted = 0
                .CreatedBy = UserID

                .InsertRubberWorking(_DB, _Transaction)
                .RemoveRubberSheetsFromStock(_DB, _Transaction)
                .RubberDescriptionDelete(_DB, _Transaction)

                For i As Integer = 0 To Me.gvRubberSheet.RowCount
                    If Not gvRubberSheet.GetRowCellDisplayText(i, gvRubberSheet.Columns(1)) = "" Then
                        .CurrentDailyWorkingID = .CurrentDailyWorkingID
                        .StockID = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn31))
                        .ItemQuantity = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn33))
                        .InsertRubberWorkingDescription(_DB, _Transaction)

                        ' Update Main Stock
                        .StockID = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn31))
                        .ItemQuantity = Val(Me.gvRubberSheet.GetRowCellDisplayText(i, GridColumn33))
                        .UpdateStock(_DB, _Transaction)


                    End If

                Next
                _Transaction.Commit()

                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With


            '  Me.DailyWorkingGetByDate()
            Me.ClearFormData()

        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If

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
                Me.lblIncentiveRate.Text = .DevalutionAllowance
                Me.lblPayChit.Text = .PayChitCost


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
                Me.GetWorkingCategoryForRubberSheets()
                Me.GetStockItems()
                '       Me.CreateDataTable()
                'iStockDailyWorking.WorkType = "PERMANENT"

                Me.GetEmployeeForRubber()
                Me.deRubberSheet.EditValue = Date.Today
                Me.deRubberSheet.Focus()
                SendKeys.Send("{HOME}+{END}")

            Case 2
                Me.ShowToolButtonsOnHistoryTabChange()

        End Select
    End Sub

#End Region

#Region "Editors Events"

    Private Sub deWorkingDate_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles deWorkingDate.EditValueChanged, DateEdit2.EditValueChanged
        Me.DailyWorkingGetByDate()

    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        Me.DeleteDailyWorking()
    End Sub

    Private Sub leEmployee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leEmployee.EditValueChanged, LookUpEdit1.EditValueChanged
        'teEmployeeName.Text = leEmployee.GetColumnValue("EmployerName")
    End Sub

    Private Sub leWorkCategory_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leWorkCategory.EditValueChanged, LookUpEdit2.EditValueChanged

    End Sub

    Private Sub seQuantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox("Leave working")
        'Me.SaveDailyWorking()
        'Me.ClearFormData()

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        '  MsgBox(rgSummaryType.EditValue)
        Select Case rgSummaryType.EditValue

            Case "D"
                Me.DailyWorkingGetAllByDates()

            Case "R"
                Me.DailyWorkingGetRubberByDates()
        End Select


    End Sub

    Private Sub RepositoryItemButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemButtonEdit1.Click, RepositoryItemButtonEdit2.Click

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

    Private Sub seQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles seQuantity.KeyPress, SpinEdit1.KeyPress


    End Sub

    Private Sub frmDailyWorkings_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub cmbDays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbDays.KeyPress, ComboBoxEdit1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.DailyWorkingIfExists()
        End If
    End Sub

    Private Sub cmbWorkType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbWorkType.SelectedIndexChanged, ComboBoxEdit2.SelectedIndexChanged
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

#Region "Dispay Record"
    Public Sub DisplayRecord(ByVal id As Long)


        With iStockDailyWorking
            .DailyWorkingID = id
            .GetRubberSheetsByID()
            lblDailyWorkingID.Text = .DailyWorkingID
            '     lblSystemNo.Text = "System No - " + .PurchaseNo.ToString
            deRubberSheet.EditValue = .WorkingDate
            leRubberSheets.EditValue = .AbbreviationID
            leRubberWorkers.EditValue = .EmployeeID
            cmbRubberDays.Text = .WorkedDays

            Me.DailyWorkingRubberGetByID()

        End With
        XtraTabControl1.SelectedTabPageIndex = 1
    End Sub
#End Region




    Private Sub seItems_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles seItems.KeyPress
            If e.KeyChar = Chr(13) Then

                dr = dt.NewRow
                'MsgBox("Start : " & i)

                dr(0) = Me.leRubberWorkers.EditValue
                dr(1) = Me.leRubberWorkers.GetColumnValue("EmployerNo")
                dr(2) = Me.leRubberWorkers.GetColumnValue("EmployerName")
                dr(3) = Me.leStockItem.EditValue
                dr(4) = Me.leStockItem.GetColumnValue("Description")
                dr(5) = Me.seItems.Text

                dt.Rows.Add(dr)

                'If dxvpDailyWorking.Validate Then
                '    Me.SaveDailyWorking()
            'End If
            Me.leStockItem.Focus()
            SendKeys.Send("{HOME}+{END}")
            End If

    End Sub


    Private Sub bbSaveRubber_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSaveRubber.ItemClick
        MsgBox(lblDailyWorkingID.Text)
        ' If dxvpDailyWorking.Validate Then

        If lblDailyWorkingID.Text = String.Empty Then

            Me.SaveRubberWorking()
            Me.ClearRubberSheet()
        Else

            Dim frm As New frmUpdateYesNo
            frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
            frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Me.UpdateRubberWorking()
                Me.ClearRubberSheet()
            End If

        End If


        '  End If

    End Sub

    Private Sub deRubberSheet_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles deRubberSheet.EditValueChanged
        ' Me.DailyWorkingRubberGetByDate()
    End Sub

 
    Private Sub deRubberSheet_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles deRubberSheet.KeyPress

        If Asc(e.KeyChar) = 13 Then
            Me.leRubberSheets.Focus()
            Me.CreateDataTable()

            '   Me.DailyWorkingRubberGetByDate()

        End If
    End Sub

    Private Sub leRubberSheets_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles leRubberSheets.KeyPress

        If Asc(e.KeyChar) = 13 Then
            Me.leRubberWorkers.Focus()


        End If

    End Sub

    Private Sub leRubberWorkers_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles leRubberWorkers.KeyPress

        If Asc(e.KeyChar) = 13 Then
            Me.cmbRubberDays.Focus()

        End If

    End Sub

    Private Sub leStockItem_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles leStockItem.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.seItems.Focus()
            SendKeys.Send("{HOME}+{END}")


        End If
    End Sub

    Private Sub cmbRubberDays_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbRubberDays.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.leStockItem.Focus()

        End If
    End Sub

    
    Private Sub gcAllWorkings_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcAllWorkings.DoubleClick
        Select Case rgSummaryType.EditValue

            Case "D"
                MsgBox("Not Allowed")

            Case "R"
                Me.DisplayRecord(Me.gvAllWorkings.GetFocusedRowCellValue(GridColumn26))
        End Select

    End Sub

    Private Sub leRubberWorkers_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leRubberWorkers.EditValueChanged

    End Sub
End Class