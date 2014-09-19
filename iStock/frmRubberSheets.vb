
Imports iStockCommon.iStockDailyWorking
Imports iStockCommon.iStockConstants
Imports iStockCommon.iStockStock

Public Class frmRubberSheets

#Region "Properties"
    Private _iStockStock As iStockCommon.iStockStock
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings

#End Region

#Region "Constructors"

    Public ReadOnly Property iStockStock() As iStockCommon.iStockStock
        Get

            If _iStockStock Is Nothing Then
                _iStockStock = New iStockCommon.iStockStock
            End If

            Return _iStockStock
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
        Me.GetStockItems()




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

            '   Me.SaveDailyWorking()
        End If


    End Sub

    Private Sub bbNew_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        '  Me.ClearFormData()
    End Sub


#End Region


#Region "Get Working Category"
    Private Sub GetStockItems()

        Try

            Me.leItemIssues.Properties.DataSource = iStockStock.GetAllStockItems.Tables(0)
            Me.leItemIssues.Properties.DisplayMember = "Description"
            Me.leItemIssues.Properties.ValueMember = "StockID"


        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region


#Region "Get RubberLtrs By Date"
    Private Sub GetRubberLtrsByDate()

        Try

            If (deWorkingDate.EditValue IsNot Nothing) Then



                With iStockDailyWorking



                    .WorkingDate = deWorkingDate.EditValue
                    .GetRubberLtrByDate()

                    teRubberLtrs.Text = .RubberLtrs




                End With
            End If



        Catch ex As Exception

            Throw
        End Try


    End Sub
#End Region





    '#Region "Clear Form Data"
    '    Public Sub ClearFormData()

    '        Me.cmbWorkType.SelectedIndex = -1
    '        Me.leWorkCategory.EditValue = Nothing
    '        Me.leEmployee.EditValue = Nothing
    '        Me.cmbDays.Text = String.Empty
    '        Me.seQuantity.Text = 0
    '        Me.cmbWorkType.Focus()

    '    End Sub
    '#End Region

    '#Region "Delete Daily Working"
    '    Private Sub DeleteDailyWorking()

    '        Try
    '            With iStockDailyWorking
    '                '.DailyWorkingID = Me.gvDailyWorking.GetFocusedRowCellValue(GridColumn1)
    '                .DailyWorkingID = Convert.ToInt64(IIf(lblDeleteID.Text = String.Empty, 0, lblDeleteID.Text.ToString))
    '                .DailyWorkingDelete()
    '            End With


    '        Catch ex As SqlClient.SqlException
    '            Dim frm As New frmOk
    '            frm.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLE
    '            frm.lblTitle.Text = CWB_DELETE_ERROR_CONFIRMATION_TITLELABEL
    '            frm.lblDescription.Text = CWB_DELETE_ERROR_CONFIRMATION_DESCRIPTIONLABEL
    '            frm.ShowDialog()
    '        End Try

    '    End Sub
    '#End Region



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
        'Me.DailyWorkingGetByDate()
        Me.GetRubberLtrsByDate()
        seQuantity.Focus()
    End Sub

    Private Sub bbDelete_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        '   Me.DeleteDailyWorking()
    End Sub

    Private Sub leEmployee_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'teEmployeeName.Text = leEmployee.GetColumnValue("EmployerName")
    End Sub

    Private Sub leWorkCategory_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub seQuantity_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'MsgBox("Leave working")
        'Me.SaveDailyWorking()
        'Me.ClearFormData()

    End Sub

    

    

    

    Private Sub frmDailyWorkings_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
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




End Class