Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

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
        pgcAttendance.BestFitColumnArea()
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

        Dim dict As New Dictionary(Of Integer, Integer)

        For index = 2013 To 2040
            dict.Add(index, index)
        Next

        leYear.Properties.DataSource = dict
        leYear.Properties.DisplayMember = "Key"
        leYear.Properties.ValueMember = "Key"


    End Sub

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
    End Sub

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click

        If dxvpAttendaceReport.Validate Then

            Dim currentDate As Date
            Dim selectedMonth, selectedYear As String
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue
            currentDate = Convert.ToDateTime(selectedMonth + "-1-" + selectedYear)

            Dim ds As New DataSet

            ds = iStockDailyWorking.GetAttendanceReport(currentDate)
            pgcAttendance.DataSource = ds.Tables(0)

            'PivotGridField2.FilterValues.ShowBlanks = False


            Dim medianCustomTotal As New PivotGridCustomTotal(DevExpress.Data.PivotGrid.PivotSummaryType.Custom)
            medianCustomTotal.Tag = "Median"
            medianCustomTotal.Format.FormatString = "{0} Median"
            medianCustomTotal.Format.FormatType = DevExpress.Utils.FormatType.Custom
            PivotGridField3.CustomTotals.Add(medianCustomTotal)
            PivotGridField3.TotalsVisibility = PivotTotalsVisibility.CustomTotals

        End If


    End Sub

    Private Sub pgcAttendance_CustomUnboundFieldData(ByVal sender As System.Object, ByVal e As DevExpress.XtraPivotGrid.CustomFieldDataEventArgs) Handles pgcAttendance.CustomUnboundFieldData
      
    End Sub

    Private Sub pgcAttendance_CustomCellValue(ByVal sender As System.Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellValueEventArgs) Handles pgcAttendance.CustomCellValue
        If e.ColumnCustomTotal Is Nothing AndAlso e.RowCustomTotal Is Nothing Then
            Return
        End If

        Dim summaryValues As ArrayList = GetSummaryValues(e)
        Dim customTotalName As String = GetCustomTotalName(e)

        e.Value = GetCustomTotalValue(summaryValues, customTotalName)

    End Sub

    Private Function GetCustomTotalName(ByVal e As PivotCellValueEventArgs) As String
        Return If(e.ColumnCustomTotal IsNot Nothing, e.ColumnCustomTotal.Tag.ToString(), _
                  e.RowCustomTotal.Tag.ToString())
    End Function

    Private Function GetSummaryValues(ByVal e As PivotCellValueEventArgs) As ArrayList
        Dim values As New ArrayList()

        ' Creates a summary data source.
        Dim sds As PivotSummaryDataSource = e.CreateSummaryDataSource()

        ' Iterates through summary data source records
        ' and copies summary values to an array.
        For i As Integer = 0 To sds.RowCount - 1
            Dim value As Object = sds.GetValue(i, e.DataField)
            If value Is Nothing Then
                Continue For
            End If
            values.Add(value)
        Next i

        ' Sorts summary values.
        values.Sort()

        ' Returns the summary values array.
        Return values
    End Function

    Private Function GetCustomTotalValue(ByVal values As ArrayList, _
                                        ByVal customTotalName As String) As Object

        ' Returns a null value if the provided array is empty.
        If values.Count = 0 Then
            Return Nothing
        End If

        ' If the Median Custom Total should be calculated,
        ' calls the GetMedian method.
        If customTotalName = "Median" Then
            Return GetMedian(values)
        End If

       

        ' Otherwise, returns a null value.
        Return Nothing
    End Function


    Private Function GetMedian(ByVal values As ArrayList) As Decimal
        If values.Count > 0 Then
            If values.Count Mod 2 = 0 Then
                Return (CDec(values(CInt(values.Count / 2 - 1))) + _
                        CDec(values(CInt(values.Count / 2)))) / 2
            Else
                Return CDec(values(CInt(Math.Truncate(values.Count / 2))))
            End If
        End If
        Return 0
    End Function

End Class