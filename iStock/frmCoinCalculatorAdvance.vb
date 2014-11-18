Imports System.Text

Public Class frmCoinCalculatorAdvance


    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPreview(gcSummary, "Coin Change - " + lblTitle.Text)
    End Sub

    Public Function CreateDataSource() As DataTable

        Dim dt As New DataTable

        dt.Columns.Add("EmployeeName", GetType(String))
        dt.Columns.Add("BalancePay", GetType(Decimal))
        dt.Columns.Add("1000", GetType(Integer))
        dt.Columns.Add("500", GetType(Integer))
        dt.Columns.Add("100", GetType(Integer))
        dt.Columns.Add("50", GetType(Integer))
        dt.Columns.Add("20", GetType(Integer))
        dt.Columns.Add("10", GetType(Integer))
        dt.Columns.Add("5", GetType(Integer))
        dt.Columns.Add("2", GetType(Integer))
        dt.Columns.Add("1", GetType(Integer))

        Return dt

    End Function

    


End Class