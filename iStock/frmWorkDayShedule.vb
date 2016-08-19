Imports iStockCommon.iStockWorkDays
Imports iStockCommon.iStockConstants
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data
Imports System.Data.Common
Imports iStockCommon.iStockEnums


Public Class frmWorkDayShedule

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
        SetCWBWorkDayBarButtonNew(bbNew)
        SetCWBWorkDayBarButtonSave(bbSave)
        SetCWBWorkDayBarButtonClose(bbClose)


        Me.DisplayActiveYear()
        Me.PopulateGrid()


    End Sub
#End Region

#Region "Display Active year"
    Public Sub DisplayActiveYear()

        With CWBWorkDays
            .GetActiveYear()

            txtWorkDayID.Text = .WorkDayID
            txtYearName.Text = .YearName

        End With

    End Sub
#End Region

#Region "Delete WorkDay Description"
    Private Sub DeleteWorkDayDescription()

        Try
            With CWBWorkDays
                .WorkDayID = txtWorkDayID.Text
                .DeleteWorkDayDescription()
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


#Region "Populate Grid"
    Public Sub PopulateGrid()
        Try
            CWBWorkDays.WorkDayID = IIf(txtWorkDayID.Text = String.Empty, 0, Convert.ToInt32(txtWorkDayID.Text))

            gcWorkDay.DataSource = CWBWorkDays.GetMonthList.Tables(0)

        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Save WorkDay Description"
    Private Sub SaveWorkDayDescription()



        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            gvWorkDay.PostEditor()

            With CWBWorkDays


                For i As Integer = 0 To Me.gvWorkDay.RowCount
                    If Not gvWorkDay.GetRowCellDisplayText(i, gvWorkDay.Columns(0)) = "" Then

                        .WorkDayID = txtWorkDayID.Text
                        .MonthName = Me.gvWorkDay.GetRowCellDisplayText(i, GridColumn11)
                        .WorkDays = Convert.ToInt32(Me.gvWorkDay.GetRowCellDisplayText(i, GridColumn12))
                        .WorkDayDescriptionInsert(_DB, _Transaction)


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

        End Try
    End Sub
#End Region

#Region "Save WorkDay "
    Private Sub SaveWorkDay()



        Dim _Connection As DbConnection = Nothing
        Dim _Transaction As DbTransaction = Nothing

        Try


            Dim _DB As Database = DatabaseFactory.CreateDatabase(ISTOCK_DBCONNECTION_STRING)
            _Connection = _DB.CreateConnection
            _Connection.Open()
            _Transaction = _Connection.BeginTransaction()

            gvWorkDay.PostEditor()

            With CWBWorkDays

                .WorkDayID = Convert.ToInt64(txtWorkDayID.Text)
                .WorkDayUpdate(_DB, _Transaction)

                .YearName = Date.Now.Year
                .WorkDayInsert(_DB, _Transaction)

                For i As Integer = 0 To Me.gvWorkDay.RowCount
                    If Not gvWorkDay.GetRowCellDisplayText(i, gvWorkDay.Columns(0)) = "" Then

                        .WorkDayID = .NewWorkDayID
                        .MonthName = Me.gvWorkDay.GetRowCellDisplayText(i, GridColumn11)
                        .WorkDays = 0
                        .WorkDayDescriptionInsert(_DB, _Transaction)


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

        End Try
    End Sub
#End Region



    Private Sub bbNewYear_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbNew.ItemClick
        If Date.Now.Year.ToString = txtYearName.Text Then
            MessageBox.Show("Workday Shedule for Year " + Date.Now.Year.ToString + " already created.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf Convert.ToInt32(Date.Now.Year.ToString) = Convert.ToInt32(txtYearName.Text) + 1 Then

            Dim Result As Integer

            Result = MessageBox.Show("Do you want to create Workday Shedule for year " + Date.Now.Year.ToString + ". This process can not undo. Do you want to proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)

            'MsgBox(Result)

            If Result = vbYes Then

                'MsgBox("Proceed")
                Me.SaveWorkDay()
                Me.DisplayActiveYear()
                Me.PopulateGrid()
            End If




        Else

            MsgBox("Invalid Date criteria")
        End If
    End Sub

    Private Sub bbSave_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbSave.ItemClick
        Me.DeleteWorkDayDescription()
        Me.SaveWorkDayDescription()
    End Sub

    Private Sub bbClose_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles bbClose.ItemClick
        Me.Close()

    End Sub
End Class