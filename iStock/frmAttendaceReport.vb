Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo

Public Class frmAttendaceReport


#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking

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
#End Region

#Region "Form Events"
    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'pgcAttendance.BestFitColumnArea()
    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub
#End Region

#Region "Populate Grid"
    Public Sub PopulateGrid()
        Try
            pgcAttendance.DataSource = CWBStock.GetAllStockItems().Tables(0)
        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub
#End Region

#Region "Print Preview"
    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPivotPreview(pgcAttendance, "Attendance Report")
    End Sub
#End Region

    Private Sub LoadYears()

        Dim list As New List(Of Integer)

        For index = 2013 To 2040
            list.Add(index)
        Next

        leYear.Properties.DataSource = list
        'leYear.Properties.Columns(0).Caption = "Year"

    End Sub

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
    End Sub

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        Dim currentDate As Date
        Dim selectedMonth, selectedYear As String
        selectedMonth = meMonth.EditValue
        selectedYear = leYear.EditValue
        currentDate = Convert.ToDateTime(selectedMonth + "-1-" + selectedYear)

        Dim ds As New DataSet

        ds = iStockDailyWorking.GetAttendanceReport(currentDate)
        pgcAttendance.DataSource = ds.Tables(0)



    End Sub
End Class