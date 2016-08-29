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

Public Class frmFactoryWeight

#Region "Variables"
    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings
    Private _iStockDailyCrop As iStockCommon.iStockDailyCropSummary
    Dim dtholiday As New DataTable
    Dim listDays As New List(Of String)
    Private _CWBWorkDays As iStockCommon.iStockWorkDays
    Dim a, b As Decimal
    Dim ds As New DataSet
#End Region

#Region "Constructor"

    Public ReadOnly Property CWBWorkDays() As iStockCommon.iStockWorkDays
        Get

            If _CWBWorkDays Is Nothing Then
                _CWBWorkDays = New iStockCommon.iStockWorkDays()
            End If

            Return _CWBWorkDays
        End Get
    End Property
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
        txtExcess.Text = Math.Abs(a - b)


    End Sub


#End Region

#Region "Populate Types"

    Private Sub LoadTypes()


        Me.leType.Properties.DataSource = ECSSettings.GetAbbreviations.Tables(0)
        Me.leType.Properties.DisplayMember = "AbbreviationDesc"
        Me.leType.Properties.ValueMember = "AbbreviationID"

    End Sub

#End Region

    Private Sub sbUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub LoadGrid()

        If dxvpAttendaceReport.Validate Then

            Dim selectedMonth, selectedYear As Integer
            selectedMonth = meMonth.EditValue
            selectedYear = leYear.EditValue

            iStockDailyCrop.CurrentMonth = selectedMonth
            iStockDailyCrop.CurrentYear = selectedYear
            iStockDailyCrop.AbbreviationID = Convert.ToInt64(leType.EditValue)

            ds = Me.iStockDailyCrop.GetDailyCropByMonthYearReport()
            pgcFactoryWeight.DataSource = ds.Tables(0)
            pgcFactoryWeight.BestFitColumnArea()


            CWBWorkDays.YearName = selectedYear
            CWBWorkDays.MonthName = meMonth.Text
            dtholiday = CWBWorkDays.GetHolyDaysAll.Tables(1)

            For Each row As DataRow In dtholiday.Rows
                listDays.Add(Convert.ToDateTime(row("Hdate")).Day.ToString)
            Next

        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPivotPreview(pgcFactoryWeight, "Factory Weight " + meMonth.Text + "/" + leYear.Text)
    End Sub

    Private Sub pgcFactoryWeight_CustomDrawFieldValue(sender As Object, e As PivotCustomDrawFieldValueEventArgs) Handles pgcFactoryWeight.CustomDrawFieldValue

        e.Appearance.BackColor = Color.AliceBlue

        'If listDays.Contains(e.Column.Caption) Then

        '    e.Column.AppearanceCell.BackColor = Color.Red
        '    e.DisplayText = e.DisplayText.Replace(".00", "")
        '    e.DisplayText = e.DisplayText.Replace(".50", ".5")

        'Else
        '    If (e.DisplayText = String.Empty) Then
        '        e.DisplayText = "ab"
        '    ElseIf IsNumeric(e.DisplayText) Then
        '        e.DisplayText = e.DisplayText.Replace(".00", "")
        '        e.DisplayText = e.DisplayText.Replace(".50", ".5")
        '    End If
        'End If

    End Sub

    Private Sub pgcFactoryWeight_CustomAppearance(sender As Object, e As PivotCustomAppearanceEventArgs) Handles pgcFactoryWeight.CustomAppearance


        For Each item As String In listDays

            If (e.GetFieldValue(PivotGridField1) = item) Then
                e.Appearance.BackColor = Color.Red
            End If


        Next



    End Sub

    Private Sub pgcFactoryWeight_CustomDrawCell(sender As Object, e As PivotCustomDrawCellEventArgs) Handles pgcFactoryWeight.CustomDrawCell

    End Sub

    Private Sub pgcFactoryWeight_CustomCellDisplayText(sender As Object, e As PivotCellDisplayTextEventArgs) Handles pgcFactoryWeight.CustomCellDisplayText


        If (e.ColumnValueType = PivotGridValueType.GrandTotal) Then


            If (e.GetColumnGrandTotal(e.DataField) IsNot Nothing) Then
                If (e.RowFieldIndex = 0) Then

                    If (e.GetColumnGrandTotal(e.DataField) <> 0) Then
                        a = e.GetColumnGrandTotal(e.DataField).ToString

                    End If

                End If

                If (e.RowFieldIndex = 1) Then
                    If (e.GetColumnGrandTotal(e.DataField) <> 0) Then
                        b = e.GetColumnGrandTotal(e.DataField)
                    End If

                End If




            End If


        End If



    End Sub
End Class