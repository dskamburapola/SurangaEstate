Imports System
Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockTermDeductions
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockDailyWorking

Public Class frmTermDeductions

#Region "Variables"

    Dim dtm, dtx, firstDate As Date
    Dim dt As DataTable
    Dim dr As DataRow
    Dim ds As DataSet
    Dim ym As String

#End Region

#Region "Properties"
    Private _iStockEmployers As iStockCommon.iStockEmployers
    Private _iStockTermDeductions As iStockCommon.iStockTermDeductions
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking

#End Region

#Region "Constructors"

    Public ReadOnly Property iStockTermDeductions() As iStockCommon.iStockTermDeductions
        Get

            If _iStockTermDeductions Is Nothing Then
                _iStockTermDeductions = New iStockCommon.iStockTermDeductions
            End If

            Return _iStockTermDeductions
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

#End Region

#Region "Form Events"

    Private Sub frmTermDeductions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        Me.GetEmployeeForWork()

        Me.CreateDataTable()

        Me.deStartMonth.EditValue = Date.Today
        Me.deIssueDate.EditValue = Date.Today
        cmbDeductionType.Focus()

        'Me.deDate.EditValue = Date.Today


    End Sub

    Private Sub frmTermDeductions_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If

    End Sub
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

    End Sub
#End Region

#Region "Create Data Table"


    Public Sub CreateDataTable()

        dt = New DataTable("Terms")
        ds = New DataSet
        dt.Columns.Add("TDMonthName")
        dt.Columns.Add("TDInsAmount", System.Type.GetType("System.Decimal"))
        dt.Columns.Add("ActiveDate")
        ds.Tables.Add(dt)



        '  Me.gvPurchase.Columns("Stock Value").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpCompany.Validate Then

            If lblID.Text = String.Empty Then
                Me.SaveTermDeductions()
            Else
                Dim frm As New frmUpdateYesNo
                frm.peImage.Image = iStock.My.Resources.Resources.ImgUpdate
                frm.Text = CWB_UPDATE_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_UPDATE_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_UPDATE_CONFIRMATION_DESCRIPTIONLABEL


                If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                    Me.UpdateTermDeductions()
                    Me.ClearFormData()
                End If

            End If
        End If

    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        Me.ClearFormData()
    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        If Not lblID.Text = String.Empty Then
            Dim frm As New frmDeleteYesNo
            frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
            frm.lblDescription.ForeColor = Color.Red
            frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
            frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
            frm.Text = CWB_DELETE_CONFIRMATION_TITLE

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Me.DeleteRecord()
                Me.ClearFormData()
            End If
        End If
    End Sub

    Private Sub bbRefresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbRefresh.ItemClick
        With gvTermDeductioDetails
            .ClearColumnsFilter()
            .ClearGrouping()
            .ClearSelection()
            .ClearSorting()
        End With
    End Sub

    Private Sub bbPrint_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbPrint.ItemClick
        PrintPreview(gcTermDeductioDetails, "Festival Advance Report")
    End Sub

    Private Sub bbDisplaySelected_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDisplaySelected.ItemClick
        Me.DisplayRecord()
    End Sub
#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try
            'If cmbWorkType.Text <> String.Empty Then
            '    Select Case cmbWorkType.Text

            '        Case "CASUAL"
            '            iStockDailyWorking.WorkType = "CASUAL LABOUR"

            '        Case "PERMENANT"
            '            iStockDailyWorking.WorkType = "PERMANENT LABOUR"


            '    End Select
            'End If
            iStockDailyWorking.WorkType = "PERMANENT"
            Me.leEmployeeCode.Properties.DataSource = iStockDailyWorking.GetEmployeeForWork.Tables(0)
            Me.leEmployeeCode.Properties.DisplayMember = "EmployerName"
            Me.leEmployeeCode.Properties.ValueMember = "EmployerID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Get TermDeductions"
    Private Sub GetTermDeductions()

        Try

            Me.gcTermDeductioDetails.DataSource = iStockTermDeductions.GetTermDeductions.Tables(0)


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region

#Region "Save Term Deductions"
    Private Sub SaveTermDeductions()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            gvTermDeductions.PostEditor()

            With iStockTermDeductions

                .TDDate = Convert.ToDateTime(Me.deIssueDate.EditValue)
                .TDType = Me.cmbDeductionType.EditValue
                .EmployerID = Convert.ToInt64(Me.leEmployeeCode.EditValue)
                .TDAmount = Convert.ToDecimal(Me.seAmount.EditValue)
                .TDInstallments = Convert.ToInt64(Me.sePeriod.EditValue)
                .CreatedBy = UserID
                .UpdatedBy = UserID

                .InsertTermDeductions(_DB, _Transaction)

                For i As Integer = 0 To Me.gvTermDeductions.RowCount - 1

                    If Not gvTermDeductions.GetRowCellDisplayText(i, gvTermDeductions.Columns(0)) = "" Then
                        .TermDeductionID = .NewTermDeductionID
                        .TDMonthName = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn1)
                        .TDInsAmount = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn2)
                        .ActiveDate = Convert.ToDateTime(Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn15))

                        .InsertTermDeductionsDescription(_DB, _Transaction)
                    End If

                Next

            End With
            _Transaction.Commit()

            Dim frm As New frmSavedOk
            frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()


        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If


            Me.ClearFormData()
            Me.cmbWorkType.Focus()
        End Try




    End Sub
#End Region

#Region "Update Term Deductions"
    Private Sub UpdateTermDeductions()

        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            gvTermDeductions.PostEditor()

            With iStockTermDeductions

                .TermDeductionID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
                .TDDate = Convert.ToDateTime(Me.deIssueDate.EditValue)
                .TDType = Me.cmbDeductionType.EditValue
                .EmployerID = Convert.ToInt64(Me.leEmployeeCode.EditValue)
                .TDAmount = Convert.ToDecimal(Me.seAmount.EditValue)
                .TDInstallments = Convert.ToInt64(Me.sePeriod.EditValue)
                .UpdatedBy = UserID

                .UpdateTermDeductions(_DB, _Transaction)

                .DeleteTermDeductionDescriptionByTermDeductionID(_DB, _Transaction)

                For i As Integer = 0 To Me.gvTermDeductions.RowCount - 1

                    If Not gvTermDeductions.GetRowCellDisplayText(i, gvTermDeductions.Columns(0)) = "" Then
                        .TermDeductionID = .TermDeductionID
                        .TDMonthName = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn1)
                        .TDInsAmount = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn2)
                        .ActiveDate = Convert.ToDateTime(Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn15))
                        .InsertTermDeductionsDescription(_DB, _Transaction)
                    End If

                Next

            End With
            _Transaction.Commit()

            Dim frm As New frmSavedOk
            frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
            frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
            frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
            frm.ShowDialog()


        Catch ex As Exception
            _Transaction.Rollback()
            MessageError(ex.ToString)
        Finally
            If _Connection.State = ConnectionState.Open Then
                _Connection.Close()
            End If


            Me.ClearFormData()
            Me.cmbWorkType.Focus()
        End Try




    End Sub
#End Region

#Region "Editor events"

    Private Sub leEmployeeCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leEmployeeCode.EditValueChanged
        teEmployeeName.Text = leEmployeeCode.GetColumnValue("EmployerName")
    End Sub

    Private Sub deStartMonth_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles deStartMonth.KeyPress
        If e.KeyChar = Chr(13) Then

            gcTermDeductions.DataSource = Nothing
            Me.CreateDataTable()

            dtx = Me.deStartMonth.EditValue
            dtm = dtx.AddMonths(-1)

            '  MsgBox(dtm)
            For i As Integer = 1 To Convert.ToInt64(Me.sePeriod.EditValue)
                dr = dt.NewRow
                firstDate = New DateTime(dtm.Year, dtm.Month, 1)

                dr(0) = Format(dtm.AddMonths(1), "MMM-yyyy")
                ' dr(0) = ym
                dr(1) = Convert.ToDecimal(seAmount.EditValue) / Convert.ToDecimal(sePeriod.EditValue)
                dr(2) = Format(firstDate.AddMonths(1), "dd-MMM-yyyy")


                dt.Rows.Add(dr)

                'MessageBox.Show(DateTime(dtm.Year, dtm.Month, 1))
                '   Dim firstDate As Date = New DateTime(dtm.Year, dtm.Month, 1)

                dtm = dtm.AddMonths(1)
            Next

            gcTermDeductions.DataSource = ds.Tables(0)


        End If
    End Sub


#End Region

#Region "Tab control events"

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                Me.ShowToolButtonsOnHistoryTabChange()
                Me.GetTermDeductions()


        End Select

    End Sub

#End Region

#Region "Grid Events"

    Private Sub gcTermDeductioDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcTermDeductioDetails.DoubleClick
        Me.DisplayRecord()
    End Sub


#End Region

#Region "Dispay Record"
    Public Sub DisplayRecord()

        Try
            If gvTermDeductioDetails.RowCount > 0 And Not gvTermDeductioDetails.IsFilterRow(gvTermDeductioDetails.FocusedRowHandle) Then
                XtraTabControl1.SelectedTabPageIndex = 0

                With iStockTermDeductions

                    lblID.Text = Me.gvTermDeductioDetails.GetFocusedRowCellValue(GridColumn3)

                    .TermDeductionID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))

                    .GetTermDeductionsByID()

                    'lblRegNo.Text = .EmpID
                    deIssueDate.EditValue = .TDDate
                    cmbDeductionType.Text = .TDType
                    leEmployeeCode.EditValue = .EmployerID
                    seAmount.EditValue = FormatNumber(.TDAmount, 2, TriState.True)
                    sePeriod.EditValue = .TDInstallments

                End With

                Me.PopulateInstallmentGrid()


            End If
        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

#Region "Populate Installment Grid"
    Public Sub PopulateInstallmentGrid()

        Try


            iStockTermDeductions.TermDeductionID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))

            gcTermDeductions.DataSource = iStockTermDeductions.GetInstallmentsByID.Tables(0)





        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "ClearFormData"

    Public Sub ClearFormData()

        deIssueDate.EditValue = Date.Today
        cmbDeductionType.Text = String.Empty
        leEmployeeCode.Properties.DataSource = Nothing
        teEmployeeName.Text = String.Empty
        deStartMonth.EditValue = Date.Today()
        seAmount.Text = 0
        sePeriod.Text = 0
        gcTermDeductions.DataSource = Nothing
        cmbWorkType.Text = String.Empty
        leEmployeeCode.EditValue = Nothing
        lblID.Text = String.Empty
        Me.GetEmployeeForWork()
        Me.leEmployeeCode.Focus()

    End Sub
#End Region

#Region "Show Tool Buttons On History Tab change"
    Public Sub ShowToolButtonsOnHistoryTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Show Tool Buttons On New Record Tab change"
    Public Sub ShowToolButtonsOnNewRecordTabChange()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbSave.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
        Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
    End Sub
#End Region

#Region "Delete Record"

    Private Sub DeleteRecord()

        With iStockTermDeductions
            .TermDeductionID = Convert.ToInt64(IIf(lblID.Text = String.Empty, 0, lblID.Text))
            .DeleteTermDescriptionByID()
        End With

    End Sub

#End Region




End Class