Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid
Imports DevExpress.Utils.Win
Imports DevExpress.XtraEditors.Popup

Public Class frmDailyCropSummary

#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings
    Private _iStockDailyCrop As iStockCommon.iStockDailyCropSummary

    Dim ds As New DataSet
#End Region

#Region "Constructor"

    Public ReadOnly Property CWBStock() As iStockCommon.iStockStock
        Get

            If _CWBStock Is Nothing Then
                _CWBStock = New iStockCommon.iStockStock()
            End If

            Return _CWBStock
        End Get
    End Property

    Public ReadOnly Property CWBSuppliers() As iStockCommon.iStockSuppliers
        Get

            If _CWBSuppliers Is Nothing Then
                _CWBSuppliers = New iStockCommon.iStockSuppliers()
            End If

            Return _CWBSuppliers
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

    Public ReadOnly Property iStockDailyCrop() As iStockCommon.iStockDailyCropSummary
        Get

            If _iStockDailyCrop Is Nothing Then
                _iStockDailyCrop = New iStockCommon.iStockDailyCropSummary
            End If

            Return _iStockDailyCrop
        End Get
    End Property
#End Region

#Region "Form Events"

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
        LoadTypes()
    End Sub

    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Print Preview"

#End Region

#Region "Populate Years"

    Private Sub LoadYears()

        Dim dict As New Dictionary(Of Integer, Integer)

        For index = 2013 To 2040
            dict.Add(index, index)
        Next

        leYear.Properties.DataSource = dict
        leYear.Properties.DisplayMember = "Key"
        leYear.Properties.ValueMember = "Key"


    End Sub


#End Region

#Region "Button Events"

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click
        Me.LoadGrid()
    End Sub


#End Region

#Region "Populate Types"

    Private Sub LoadTypes()


        Me.leType.Properties.DataSource = ECSSettings.GetAbbreviations.Tables(0)
        Me.leType.Properties.DisplayMember = "AbbreviationDesc"
        Me.leType.Properties.ValueMember = "AbbreviationID"

    End Sub

#End Region



    Private Sub sbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbUpdate.Click
        gvDailyCrop.PostEditor()


        Dim selectedMonth, selectedYear As Integer
        selectedMonth = meMonth.EditValue
        selectedYear = leYear.EditValue

        iStockDailyCrop.CurrentMonth = selectedMonth
        iStockDailyCrop.CurrentYear = selectedYear
        iStockDailyCrop.AbbreviationID = Convert.ToInt64(leType.EditValue)

        iStockDailyCrop.DeleteDailyCrop()

        For i As Integer = 0 To Me.gvDailyCrop.RowCount - 1

            If (Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn1) <> "") Then


                iStockDailyCrop.CurrentDate = Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn1)
                iStockDailyCrop.FactoryCrop = IIf(Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn3) = String.Empty, 0, Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn3))
                iStockDailyCrop.Rate = IIf(Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn4) = "", 0, Me.gvDailyCrop.GetRowCellDisplayText(i, GridColumn4))
                iStockDailyCrop.insertDailyCrop()
            End If
        Next



        Dim frm As New frmSavedOk
        frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
        frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
        frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
        frm.ShowDialog()

        Me.LoadGrid()



    End Sub

    Private Sub LoadGrid()

        If dxvpAttendaceReport.Validate Then

            Dim selectedMonth, selectedYear As Integer
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue

            iStockDailyCrop.CurrentMonth = selectedMonth
            iStockDailyCrop.CurrentYear = selectedYear
            iStockDailyCrop.AbbreviationID = Convert.ToInt64(leType.EditValue)

            ds = Me.iStockDailyCrop.GetDailyCropByMonthYear()

            Dim daysinmonth As Integer

            daysinmonth = System.DateTime.DaysInMonth(selectedYear, selectedMonth)

            If ds.Tables(0).Rows.Count = 0 Then


                For index = 1 To daysinmonth

                    Dim dr As DataRow
                    dr = ds.Tables(0).NewRow

                    dr("CurrentDay") = Convert.ToDateTime("" + index.ToString + "-" + selectedMonth.ToString + "-" + selectedYear.ToString)
                    ds.Tables(0).Rows.Add(dr)

                Next

            End If

            gcDailyCrop.DataSource = ds.Tables(0)


        End If
    End Sub

    Private Sub RepositoryItemDateEdit1_Popup(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.Popup
        Dim c As DateEditCalendar = TryCast((TryCast((TryCast(sender, IPopupControl)).PopupWindow, PopupDateEditForm)).Calendar, DateEditCalendar)
        c.DateTime = Convert.ToDateTime("01-" + meMonth.EditValue.ToString + "-" + leYear.EditValue.ToString)
    End Sub



    Private Sub RepositoryItemDateEdit1_EditValueChanging(sender As Object, e As ChangingEventArgs) Handles RepositoryItemDateEdit1.EditValueChanging


    End Sub

    Private Sub RepositoryItemDateEdit1_Enter(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.Enter

    End Sub

    Private Sub RepositoryItemDateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.EditValueChanged

    End Sub

    Private Sub gvDailyCrop_ShownEditor(sender As Object, e As EventArgs) Handles gvDailyCrop.ShownEditor
        ' gvDailyCrop.ActiveEditor.EditValue = Convert.ToDateTime("01-" + meMonth.EditValue.ToString + "-" + leYear.EditValue.ToString)
    End Sub

    Private Sub gvDailyCrop_CellValueChanging(sender As Object, e As Views.Base.CellValueChangedEventArgs) Handles gvDailyCrop.CellValueChanging
    End Sub

    Private Sub gvDailyCrop_FocusedColumnChanged(sender As Object, e As Views.Base.FocusedColumnChangedEventArgs) Handles gvDailyCrop.FocusedColumnChanged


    End Sub
End Class