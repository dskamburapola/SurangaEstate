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
    Dim dtm, dtx As Date
    Dim dt As DataTable
    Dim dr As DataRow
    Dim ds As DataSet
    Dim ym As String


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
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Create Data Table"


    Public Sub CreateDataTable()

        dt = New DataTable("Terms")
        ds = New DataSet
        dt.Columns.Add("TDMonthName") '0
        dt.Columns.Add("TDInsAmount") '1
        

        ds.Tables.Add(dt)
        gcTermDeductions.DataSource = ds
        gcTermDeductions.DataMember = "Terms"


        '  Me.gvPurchase.Columns("Stock Value").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum



    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        'MsgBox(deStartMonth.EditValue & "  +  " & deStartMonth.Text)

         'If dxvpCompany.Validate Then
        '    '      Me.SaveCompany()
        'End If
        Me.SaveTermDeductions()

    End Sub
#End Region

#Region "Get Employee For Work"
    Private Sub GetEmployeeForWork()

        Try

            Me.leEmployeeCode.Properties.DataSource = iStockDailyWorking.GetEmployeeForWork.Tables(0)
            Me.leEmployeeCode.Properties.DisplayMember = "EmployerNo"
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

                .TDDate = Convert.ToDateTime(Me.deIssueDate.Text)
                .TDType = Me.cmbDeductionType.Text
                .EmployerID = Convert.ToInt64(Me.leEmployeeCode.EditValue)
                .TDAmount = Convert.ToDecimal(Me.seAmount.Text)
                .TDInstallments = Convert.ToInt64(Me.sePeriod.Text)
                .CreatedBy = UserID
                .UpdatedBy = UserID



                .InsertTermDeductions(_DB, _Transaction)

                For i As Integer = 0 To Me.gvTermDeductions.RowCount

                    If Not gvTermDeductions.GetRowCellDisplayText(i, gvTermDeductions.Columns(0)) = "" Then
                        .TermDeductionID = .NewTermDeductionID
                        .TDMonthName = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn1)
                        .TDInsAmount = Me.gvTermDeductions.GetRowCellDisplayText(i, GridColumn2)

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
            Me.cmbDeductionType.Focus()
        End Try




    End Sub
#End Region

    'Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ' MsgBox(dtm.AddMonths(1))

    '    For i As Integer = 1 To Convert.ToInt64(Me.seTerms.Text)
    '        dr = dt.NewRow

    '        dr(0) = Format(dtm.AddMonths(1), "d")

    '        dr(1) = Convert.ToDecimal(seAmount.Text) / Convert.ToDecimal(seTerms.Text)
    '        dt.Rows.Add(dr)

    '        dtm = dtm.AddMonths(1)
    '    Next

    'End Sub

    
    
    Private Sub leEmployeeCode_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles leEmployeeCode.EditValueChanged
        teEmployeeName.Text = leEmployeeCode.GetColumnValue("EmployerName")
    End Sub

    Private Sub sePeriod_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sePeriod.Leave

        

    End Sub

    Private Sub deStartMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles deStartMonth.Leave
        gcTermDeductions.DataSource = Nothing
        Me.CreateDataTable()

        dtx = Me.deStartMonth.EditValue
        dtm = dtx.AddMonths(-1)

        '  MsgBox(dtm)
        For i As Integer = 1 To Convert.ToInt64(Me.sePeriod.EditValue)
            dr = dt.NewRow

            dr(0) = Format(dtm.AddMonths(1), "MMM-yyyy")
            ' dr(0) = ym
            dr(1) = Convert.ToDecimal(seAmount.EditValue) / Convert.ToDecimal(sePeriod.EditValue)
            dt.Rows.Add(dr)

            dtm = dtm.AddMonths(1)
        Next

    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        Select Case e.Page.TabControl.SelectedTabPageIndex
            Case 0
                '  Me.ShowToolButtonsOnNewRecordTabChange()
            Case 1
                ' Me.ShowToolButtonsOnHistoryTabChange()
                Me.GetTermDeductions()


        End Select

    End Sub

    Private Sub gcTermDeductioDetails_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gcTermDeductioDetails.DoubleClick
        Me.DisplayRecord()
    End Sub

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
                    deIssueDate.Text = .TDDate
                    cmbDeductionType.Text = .TDType
                    leEmployeeCode.EditValue = .EmployerID
                    seAmount.Text = FormatNumber(.TDAmount, 2, TriState.True)
                    sePeriod.Text = .TDInstallments

                End With

                Me.PopulateInstallmentGrid()

                deIssueDate.Focus()
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
        leEmployeeCode.EditValue = 0
        leEmployeeCode.Text = String.Empty
        teEmployeeName.Text = String.Empty
        deStartMonth.EditValue = Date.Today()

        seAmount.Text = 0
        sePeriod.Text = 0
        gcTermDeductions.DataSource = Nothing


    End Sub
#End Region


End Class