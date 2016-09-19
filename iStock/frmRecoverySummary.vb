Imports iStockCommon.iStockStock
Imports iStockCommon.iStockSuppliers
Imports iStockCommon.iStockConstants
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraPivotGrid

Public Class frmRecoverySummary

#Region "Variables"

    Private _CWBStock As iStockCommon.iStockStock
    Private _CWBSuppliers As iStockCommon.iStockSuppliers
    Private _iStockDailyWorking As iStockCommon.iStockDailyWorking
    Private _ECSSettings As iStockCommon.iStockSettings

#End Region

#Region "Constructor"

    Public ReadOnly Property ECSSettings() As iStockCommon.iStockSettings
        Get

            If _ECSSettings Is Nothing Then
                _ECSSettings = New iStockCommon.iStockSettings
            End If

            Return _ECSSettings
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
#End Region

#Region "Form Events"

    Private Sub frmAttendaceReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadYears()
    End Sub

    Private Sub frmStockBalance_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        'LoadTypes()
    End Sub

    Private Sub frmStockBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.Chr(27) Then
            Me.Close()
        End If
    End Sub

#End Region

#Region "Print Preview"
    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPreview(gcFieldPerfomance, "Festival Recovery - " + leYear.Text)
    End Sub
#End Region

#Region "Button Events"

    Private Sub sbGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbGenerate.Click


        Dim selectedYear As String

        selectedYear = leYear.EditValue


        Me.leFestival.Properties.DataSource = iStockDailyWorking.LoadFestivalAdvance(selectedYear)
        Me.leFestival.Properties.DisplayMember = "TDdescription"
        Me.leFestival.Properties.ValueMember = "TermDeductionID"

        MsgBox("OKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKKK")
        'If dxvpFieldPerformance.Validate Then

        '    Dim currentDate As Date
        '    Dim selectedYear As String

        '    selectedYear = leYear.EditValue
        '    ' currentDate = Convert.ToDateTime("01-" + "October-" + selectedYear)


        '    Dim ds As New DataSet

        '    ds = iStockDailyWorking.RecoverySummary(selectedYear)
        '    gcFieldPerfomance.DataSource = ds.Tables(0)
        '    gvFieldPerformance.BestFitColumns()


        '    Dim Total As String
        '    Total = Convert.ToDecimal(grdMay.SummaryText) + Convert.ToDecimal(grdMay.SummaryText) + Convert.ToDecimal(grdJun.SummaryText) + Convert.ToDecimal(grdJul.SummaryText) + Convert.ToDecimal(grdAug.SummaryText) + Convert.ToDecimal(grdSep.SummaryText) + Convert.ToDecimal(grdOct.SummaryText) + Convert.ToDecimal(grdNov.SummaryText) + Convert.ToDecimal(grdDec.SummaryText) + Convert.ToDecimal(grdJan.SummaryText) + Convert.ToDecimal(grdFeb.SummaryText)


        '    Dim item As GridColumnSummaryItem = New GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom, "Remarks", Total.ToString)
        '    gvFieldPerformance.Columns("Remarks").Summary.Add(item)

        'End If


    End Sub


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



   
    Private Sub leYear_EditValueChanged(sender As Object, e As EventArgs) Handles leYear.EditValueChanged
        Dim selectedYear As String

        selectedYear = leYear.EditValue


        Me.leFestival.Properties.DataSource = iStockDailyWorking.LoadFestivalAdvance(selectedYear).Tables(0)
        Me.leFestival.Properties.DisplayMember = "TDdescription"
        Me.leFestival.Properties.ValueMember = "TermDeductionID"

    End Sub

    Private Sub leFestival_EditValueChanged(sender As Object, e As EventArgs) Handles leFestival.EditValueChanged

        Dim ds As New DataSet
        Dim a As Integer

        a = Convert.ToInt32(leFestival.EditValue.ToString)
        ds = iStockDailyWorking.RecoveryDetails(a)

        If ds.Tables(0).Rows.Count <> 0 Then

            txtFestivalAmount.Text = FormatNumber(ds.Tables(0).Rows(0)(3).ToString, 2, TriState.True)


            Dim b As Decimal

            b = Val(GridColumn6.SummaryText)
            txtRecovery.Text = FormatNumber(b, 2, TriState.True)

            txtBalance.Text = FormatNumber(Val(txtFestivalAmount.Text) - Val(txtRecovery.Text), 2, TriState.True)

            gcRecovery.DataSource = ds.Tables(0)
            gvRecovery.BestFitColumns()


        End If


    End Sub
End Class