Imports iStockCommon.iStockEmployers
Imports iStockCommon.iStockDailyWorking
Imports iStockCommon.iStockConstants

Public Class frmDailyWorkings

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
    
    Private Sub frmDailyWorkings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStartUpBarButton(bbSave, bbNew, bbDelete, bbClose, bbDisplaySelected, bbRefresh, bbPrint)
        Me.HideToolButtonsOnLoad()
        'Me.DisplayCompany()
        Me.GetWorkingCategory()


        Me.deWorkingDate.EditValue = Date.Now.ToShortDateString()

        '  MessageBox.Show(Me.deWorkingDate.EditValue)

    End Sub
    
#End Region

#Region "Hide Tool Buttons On Load"
    Public Sub HideToolButtonsOnLoad()

        Me.bbDisplaySelected.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'Me.bbDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbDelete.Enabled = False
        Me.bbRefresh.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        Me.bbNew.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
    End Sub
#End Region

#Region "Bar Button Events"
    Private Sub bbClose_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()
    End Sub

    Private Sub bbSave_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick

        If dxvpCompany.Validate Then
            Me.SaveDailyWorking()
        End If


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

#Region "Daily Working Get By Date"
    Private Sub DailyWorkingGetByDate()

        Try

            With iStockDailyWorking

                .WorkingDate = Me.deWorkingDate.EditValue
                gcDailyWorking.DataSource = .DailyWorkingGetByDate.Tables(0)




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
                .EmployeeID = lblID.Text.Trim
                .WorkedDays = Me.seWorkDays.Text.Trim
                .Quantity = Me.seQuantity.Text.Trim

                .InsertDailyWorking()

                Dim frm As New frmSavedOk
                frm.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLE
                frm.lblTitle.Text = CWB_SAVESUCCESS_CONFIRMATION_TITLELABEL
                frm.lblDescription.Text = CWB_SAVESUCCESS_CONFIRMATION_DESCRIPTIONLABEL
                frm.ShowDialog()
            End With

            Me.ClearFormData()
            Me.DailyWorkingGetByDate()

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try




    End Sub
#End Region


#Region "Clear Form Data"
    Public Sub ClearFormData()
        Me.lblID.Text = String.Empty
        Me.seEmployeeCode.Text = String.Empty
        Me.cmbWorkType.Text = String.Empty
        Me.teEmployeeName.Text = String.Empty
        Me.seWorkDays.Text = 0
        Me.seQuantity.Text = 0


    End Sub
#End Region

#Region "Dispay Employee Info"
    Public Sub DisplayEmployeeInfo()

        Try

            With iStockEmployers

                .EmployerNo = Me.seEmployeeCode.Text.Trim
                .EmployeeDetailsGetByEmployerNo()

                lblID.Text = .EmployerID


                teEmployeeName.Text = .EmployerName
                seWorkDays.Focus()


            End With

            If lblID.Text = String.Empty Then
                MsgBox("Invalid Reg No")
                seEmployeeCode.Focus()

            End If


        Catch ex As Exception
            MessageError(ex.ToString)

        End Try

    End Sub
#End Region

#Region "Delete Daily Working"
    Private Sub DeleteDailyWorking()

        Try
            With iStockDailyWorking
                .DailyWorkingID = Me.gvDailyWorking.GetFocusedRowCellValue(GridColumn1)
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
    
    Private Sub seEmployeeCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles seEmployeeCode.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(13) Then
            Me.DisplayEmployeeInfo()
        End If
    End Sub

    Private Sub deWorkingDate_EditValueChanged(sender As Object, e As EventArgs) Handles deWorkingDate.EditValueChanged
        Me.DailyWorkingGetByDate()

    End Sub

   
    Private Sub gcDailyWorking_DoubleClick(sender As Object, e As EventArgs) Handles gcDailyWorking.DoubleClick
        lblDeleteID.Text = Me.gvDailyWorking.GetFocusedRowCellValue(GridColumn1)
        Me.bbDelete.Enabled = True

    End Sub

    Private Sub bbDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbDelete.ItemClick
        Me.DeleteDailyWorking()
    End Sub

    
End Class