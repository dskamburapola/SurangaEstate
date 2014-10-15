Public Class frmChart_income

#Region "Variables"

    Private _CWBOtherIncome As iStockCommon.iStockOtherIncome

#End Region

#Region "Constructor"

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

        End If
    End Sub

#End Region

End Class