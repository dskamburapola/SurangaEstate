Public Class frmChart_income

#Region "Variables"

    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome
    Private _CWBCharts As iStockCommon.iStockCharts

#End Region

#Region "Constructor"

    Public ReadOnly Property CWBCharts() As iStockCommon.iStockCharts
        Get

            If _CWBCharts Is Nothing Then
                _CWBCharts = New iStockCommon.iStockCharts
            End If

            Return _CWBCharts
        End Get
    End Property

    Public ReadOnly Property CWBOtherIncome() As iStockCommon.iStockOtherIncome
        Get

            If _CWBOtherIncome Is Nothing Then
                _CWBOtherIncome = New iStockCommon.iStockOtherIncome()
            End If

            Return _CWBOtherIncome
        End Get
    End Property

#End Region

#Region "Form Events"

    Private Sub frmChart_income_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.LoadYears()

    End Sub

    Private Sub frmChart_income_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        PopulateOtherIncomeTypesLookup()
    End Sub

    Private Sub frmChart_income_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(27) Then
            Me.Close()
        End If
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

#Region "Populate OtherIncomeTypes Lookup"
    Public Sub PopulateOtherIncomeTypesLookup()

        Try
            With lupOtherIncomeType
                .Properties.DataSource = CWBOtherIncome.OtherIncomeTypesGetAll().Tables(0)
                .Properties.DisplayMember = "Description"
                .Properties.ValueMember = "OtherIncomeTypeID"

            End With


        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Editor Events"

    Private Sub sbProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbProcess.Click
        If dxvpCommon.Validate Then
            Me.BindChart()
        End If
    End Sub

    Private Sub lupOtherIncomeType_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles lupOtherIncomeType.ButtonClick
        If e.Button.Index = 1 Then
            lupOtherIncomeType.EditValue = Nothing
        End If
    End Sub

    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintChartPreview(Chart, "Income chart")
    End Sub
#End Region

#Region "Bind Chart"

    Private Sub BindChart()


        CWBCharts.IncomeType = lupOtherIncomeType.EditValue
        CWBCharts.Year = leYear.EditValue
        Chart.DataSource = CWBCharts.ChartIncome().Tables(0)

        Chart.SeriesDataMember = "Description"
        Chart.SeriesTemplate.ArgumentDataMember = "Month"
        Chart.SeriesTemplate.ValueDataMembers.AddRange(New String() {"Amount"})

        Dim ct As New DevExpress.XtraCharts.ChartTitle
        ct.Text = lupOtherIncomeType.Text + " " + leYear.Text
        Chart.Titles.Clear()
        Chart.Titles.Add(ct)
      
    End Sub

#End Region

   
    
End Class