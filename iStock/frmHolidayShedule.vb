Imports iStockCommon.iStockWorkDays
Imports iStockCommon.iStockConstants
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockEnums
Imports System.Xml
Imports System.Globalization


Public Class frmHolidayShedule

#Region "Variables"
    Private _CWBWorkDays As iStockCommon.iStockWorkDays

    Dim _CWBEnums As iStockCommon.iStockEnums
#End Region

#Region "Constructors"

    Public ReadOnly Property CWBWorkDays() As iStockCommon.iStockWorkDays
        Get

            If _CWBWorkDays Is Nothing Then
                _CWBWorkDays = New iStockCommon.iStockWorkDays()
            End If

            Return _CWBWorkDays
        End Get
    End Property
    Public ReadOnly Property CWBEnums() As iStockCommon.iStockEnums
        Get

            If _CWBEnums Is Nothing Then
                _CWBEnums = New iStockCommon.iStockEnums
            End If

            Return _CWBEnums
        End Get
    End Property



#End Region

#Region "Form Events"
    Private Sub frmExpenses_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

    Private Sub frmExpenses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SetCWBWorkDayBarButtonClose(bbClose)


        Me.DisplayActiveYear()
        Me.PopulateGrid()


    End Sub
#End Region

#Region "Display Active year"
    Public Sub DisplayActiveYear()

        With CWBWorkDays
            .GetActiveYear()


            lblYear.Text = .YearName

        End With

    End Sub
#End Region




#Region "Populate Grid"
    Public Sub PopulateGrid()
        Try
            CWBWorkDays.YearName = lblYear.Text
            CWBWorkDays.MonthName = ""

            gcHoliday.DataSource = CWBWorkDays.GetHolyDaysAll.Tables(0)

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Populate Grid By Months"
    Public Sub PopulateGridByMonths()
        Try
            CWBWorkDays.YearName = lblYear.Text
            CWBWorkDays.MonthName = cmbMonths.Text

            gcHoliday.DataSource = CWBWorkDays.GetHolyDaysAll.Tables(1)

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region


    Private Sub SaveHoliday()



        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()


            With CWBWorkDays

                .HDate = deHoliday.EditValue
                .Description = txtDescription.Text
                .CreatedBy = UserID

                .HolyDayInsert(_DB, _Transaction)



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

        End Try
    End Sub


#Region "Delete Holiday"
    Private Sub DeleteHoliday()

        Try
            With CWBWorkDays

                .HolyDayID = Convert.ToInt64(IIf(txtDeleteID.Text = String.Empty, 0, txtDeleteID.Text.ToString))
                .HolydayDelete()
                PopulateGridByMonths()
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


    Private Sub RepositoryItemButtonEdit1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepositoryItemButtonEdit1.Click

        txtDeleteID.Text = (Me.gvHoliday.GetFocusedRowCellValue(GridColumn14))

        If Not txtDeleteID.Text = String.Empty Then
            Dim frm As New frmDeleteYesNo
            frm.lblTitle.Text = CWB_DELETE_CONFIRMATION_TITLELABEL
            frm.lblDescription.ForeColor = Color.Red
            frm.peImage.Image = iStock.My.Resources.Resources.ImgDelete
            frm.lblDescription.Text = CWB_DELETE_CONFIRMATION_DESCRIPTIONLABEL
            frm.Text = CWB_DELETE_CONFIRMATION_TITLE

            If frm.ShowDialog = Windows.Forms.DialogResult.Yes Then
                Me.DeleteHoliday()
                Me.PopulateGridByMonths()

            End If
        End If




    End Sub

    Private Sub bbClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()

    End Sub

    Private Sub btnMarkHoliday_Click(sender As Object, e As EventArgs) Handles btnMarkHoliday.Click
        Me.SaveHoliday()
        Me.PopulateGrid()
    End Sub


    Private Sub cmbMonths_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonths.SelectedIndexChanged
        PopulateGridByMonths()

        deHoliday.EditValue = New DateTime(DateTime.Now.Year, DateTime.ParseExact(cmbMonths.Text, "MMMM", CultureInfo.CurrentCulture).Month, 1)
    End Sub

    Private Sub gcHoliday_Click(sender As Object, e As EventArgs) Handles gcHoliday.Click

    End Sub
End Class