Imports System.Text

Public Class frmCoinCalculator

    Private Sub sbCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbCalculate.Click

        Dim cointval() As Integer = {1, 2, 5, 10, 20, 50, 100, 500, 1000, 5000}
        Dim numofCoinUsed(10) As Integer
        Dim amountToCal As Integer
        amountToCal = Convert.ToDecimal(seAmount.EditValue)

        Dim remainingAmount As Integer

        remainingAmount = amountToCal

        For currentCoin As Integer = 9 To 0 Step -1

            Dim currentCoinIndex As Integer
            currentCoinIndex = 0


            Dim x As Decimal

            x = (remainingAmount / cointval(currentCoin))

            currentCoinIndex = IIf(x < 1, 0, Math.Abs(Math.Floor(x)))

            numofCoinUsed(currentCoin) = currentCoinIndex

            remainingAmount = remainingAmount - (currentCoinIndex * cointval(currentCoin))

            If (remainingAmount = 0) Then
                Continue For
            End If

        Next

        Dim dt As New DataTable

        dt.Columns.Add("Coin")
        dt.Columns.Add("Qty")

        dt.Rows.Add("5000", numofCoinUsed(9).ToString)
        dt.Rows.Add("1000", numofCoinUsed(8).ToString)
        dt.Rows.Add("500", numofCoinUsed(7).ToString)
        dt.Rows.Add("100", numofCoinUsed(6).ToString)
        dt.Rows.Add("50", numofCoinUsed(5).ToString)
        dt.Rows.Add("20", numofCoinUsed(4).ToString)
        dt.Rows.Add("10", numofCoinUsed(3).ToString)
        dt.Rows.Add("5", numofCoinUsed(2).ToString)
        dt.Rows.Add("2", numofCoinUsed(1).ToString)
        dt.Rows.Add("1", numofCoinUsed(0).ToString)

        gcCoin.DataSource = dt



    End Sub

    Private Sub sbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sbPrint.Click
        PrintPreview(gcCoin, "Coin Change Report")
    End Sub

End Class