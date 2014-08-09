<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class xrProfitnLoss
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcStockValue = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcTotalPurchases = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcTotalSales = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcTotalPurchasesCost = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow6 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcTotalExpenses = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow7 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcSalesProfit = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableCell18 = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow11 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell21 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcCashttoPay = New DevExpress.XtraReports.UI.XRTableCell
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow
        Me.XrTableCell19 = New DevExpress.XtraReports.UI.XRTableCell
        Me.xrtcCashtoReceive = New DevExpress.XtraReports.UI.XRTableCell
        Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand
        Me.xrlblAddress = New DevExpress.XtraReports.UI.XRLabel
        Me.xrlblTitle = New DevExpress.XtraReports.UI.XRLabel
        Me.xrlFromTo = New DevExpress.XtraReports.UI.XRLabel
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel
        Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand
        Me.XrPageInfo1 = New DevExpress.XtraReports.UI.XRPageInfo
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable1})
        Me.Detail.Height = 300
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable1
        '
        Me.XrTable1.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
                    Or DevExpress.XtraPrinting.BorderSide.Right) _
                    Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Location = New System.Drawing.Point(158, 0)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1, Me.XrTableRow3, Me.XrTableRow2, Me.XrTableRow4, Me.XrTableRow5, Me.XrTableRow6, Me.XrTableRow7, Me.XrTableRow8, Me.XrTableRow9, Me.XrTableRow11, Me.XrTableRow10})
        Me.XrTable1.Size = New System.Drawing.Size(325, 275)
        Me.XrTable1.StylePriority.UseBorders = False
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell1.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseTextAlignment = False
        Me.XrTableCell1.Text = "Description"
        Me.XrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell2.Location = New System.Drawing.Point(168, 0)
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell2.Size = New System.Drawing.Size(157, 25)
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseTextAlignment = False
        Me.XrTableCell2.Text = "Amount"
        Me.XrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.xrtcStockValue})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell5.Size = New System.Drawing.Size(168, 25)
        '
        'xrtcStockValue
        '
        Me.xrtcStockValue.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcStockValue.Location = New System.Drawing.Point(168, 0)
        Me.xrtcStockValue.Name = "xrtcStockValue"
        Me.xrtcStockValue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcStockValue.Size = New System.Drawing.Size(157, 25)
        Me.xrtcStockValue.StylePriority.UseFont = False
        Me.xrtcStockValue.StylePriority.UseTextAlignment = False
        Me.xrtcStockValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell3, Me.xrtcTotalPurchases})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell3.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell3.Text = "Total Purchases"
        '
        'xrtcTotalPurchases
        '
        Me.xrtcTotalPurchases.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcTotalPurchases.Location = New System.Drawing.Point(168, 0)
        Me.xrtcTotalPurchases.Name = "xrtcTotalPurchases"
        Me.xrtcTotalPurchases.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcTotalPurchases.Size = New System.Drawing.Size(157, 25)
        Me.xrtcTotalPurchases.StylePriority.UseFont = False
        Me.xrtcTotalPurchases.StylePriority.UseTextAlignment = False
        Me.xrtcTotalPurchases.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.xrtcTotalSales})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell7.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell7.Text = "Total Sales"
        '
        'xrtcTotalSales
        '
        Me.xrtcTotalSales.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcTotalSales.Location = New System.Drawing.Point(168, 0)
        Me.xrtcTotalSales.Name = "xrtcTotalSales"
        Me.xrtcTotalSales.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcTotalSales.Size = New System.Drawing.Size(157, 25)
        Me.xrtcTotalSales.StylePriority.UseFont = False
        Me.xrtcTotalSales.StylePriority.UseTextAlignment = False
        Me.xrtcTotalSales.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell9, Me.xrtcTotalPurchasesCost})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell9.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell9.Text = "Total Purchases Cost"
        '
        'xrtcTotalPurchasesCost
        '
        Me.xrtcTotalPurchasesCost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcTotalPurchasesCost.Location = New System.Drawing.Point(168, 0)
        Me.xrtcTotalPurchasesCost.Name = "xrtcTotalPurchasesCost"
        Me.xrtcTotalPurchasesCost.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcTotalPurchasesCost.Size = New System.Drawing.Size(157, 25)
        Me.xrtcTotalPurchasesCost.StylePriority.UseFont = False
        Me.xrtcTotalPurchasesCost.StylePriority.UseTextAlignment = False
        Me.xrtcTotalPurchasesCost.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow6
        '
        Me.XrTableRow6.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell11, Me.xrtcTotalExpenses})
        Me.XrTableRow6.Name = "XrTableRow6"
        Me.XrTableRow6.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell11.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell11.Text = "Total Expenses"
        '
        'xrtcTotalExpenses
        '
        Me.xrtcTotalExpenses.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcTotalExpenses.Location = New System.Drawing.Point(168, 0)
        Me.xrtcTotalExpenses.Name = "xrtcTotalExpenses"
        Me.xrtcTotalExpenses.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcTotalExpenses.Size = New System.Drawing.Size(157, 25)
        Me.xrtcTotalExpenses.StylePriority.UseFont = False
        Me.xrtcTotalExpenses.StylePriority.UseTextAlignment = False
        Me.xrtcTotalExpenses.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow7
        '
        Me.XrTableRow7.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell13, Me.XrTableCell14})
        Me.XrTableRow7.Name = "XrTableRow7"
        Me.XrTableRow7.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell13.Size = New System.Drawing.Size(168, 25)
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Location = New System.Drawing.Point(168, 0)
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell14.Size = New System.Drawing.Size(157, 25)
        Me.XrTableCell14.StylePriority.UseTextAlignment = False
        Me.XrTableCell14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell15, Me.xrtcSalesProfit})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell15.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell15.Text = "Sales Profit"
        '
        'xrtcSalesProfit
        '
        Me.xrtcSalesProfit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcSalesProfit.ForeColor = System.Drawing.Color.Green
        Me.xrtcSalesProfit.Location = New System.Drawing.Point(168, 0)
        Me.xrtcSalesProfit.Name = "xrtcSalesProfit"
        Me.xrtcSalesProfit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcSalesProfit.Size = New System.Drawing.Size(157, 25)
        Me.xrtcSalesProfit.StylePriority.UseFont = False
        Me.xrtcSalesProfit.StylePriority.UseForeColor = False
        Me.xrtcSalesProfit.StylePriority.UseTextAlignment = False
        Me.xrtcSalesProfit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell17, Me.XrTableCell18})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell17.Size = New System.Drawing.Size(168, 25)
        '
        'XrTableCell18
        '
        Me.XrTableCell18.Location = New System.Drawing.Point(168, 0)
        Me.XrTableCell18.Name = "XrTableCell18"
        Me.XrTableCell18.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell18.Size = New System.Drawing.Size(157, 25)
        Me.XrTableCell18.StylePriority.UseTextAlignment = False
        Me.XrTableCell18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        '
        'XrTableRow11
        '
        Me.XrTableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell21, Me.xrtcCashttoPay})
        Me.XrTableRow11.Name = "XrTableRow11"
        Me.XrTableRow11.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell21
        '
        Me.XrTableCell21.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell21.Name = "XrTableCell21"
        Me.XrTableCell21.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell21.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell21.Text = "Cash to Pay"
        Me.XrTableCell21.Visible = False
        '
        'xrtcCashttoPay
        '
        Me.xrtcCashttoPay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcCashttoPay.ForeColor = System.Drawing.Color.Red
        Me.xrtcCashttoPay.Location = New System.Drawing.Point(168, 0)
        Me.xrtcCashttoPay.Name = "xrtcCashttoPay"
        Me.xrtcCashttoPay.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcCashttoPay.Size = New System.Drawing.Size(157, 25)
        Me.xrtcCashttoPay.StylePriority.UseFont = False
        Me.xrtcCashttoPay.StylePriority.UseForeColor = False
        Me.xrtcCashttoPay.StylePriority.UseTextAlignment = False
        Me.xrtcCashttoPay.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrtcCashttoPay.Visible = False
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell19, Me.xrtcCashtoReceive})
        Me.XrTableRow10.Name = "XrTableRow10"
        Me.XrTableRow10.Size = New System.Drawing.Size(325, 25)
        '
        'XrTableCell19
        '
        Me.XrTableCell19.Location = New System.Drawing.Point(0, 0)
        Me.XrTableCell19.Name = "XrTableCell19"
        Me.XrTableCell19.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrTableCell19.Size = New System.Drawing.Size(168, 25)
        Me.XrTableCell19.Text = "Cash to Receive"
        Me.XrTableCell19.Visible = False
        '
        'xrtcCashtoReceive
        '
        Me.xrtcCashtoReceive.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.xrtcCashtoReceive.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.xrtcCashtoReceive.Location = New System.Drawing.Point(168, 0)
        Me.xrtcCashtoReceive.Name = "xrtcCashtoReceive"
        Me.xrtcCashtoReceive.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrtcCashtoReceive.Size = New System.Drawing.Size(157, 25)
        Me.xrtcCashtoReceive.StylePriority.UseFont = False
        Me.xrtcCashtoReceive.StylePriority.UseForeColor = False
        Me.xrtcCashtoReceive.StylePriority.UseTextAlignment = False
        Me.xrtcCashtoReceive.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
        Me.xrtcCashtoReceive.Visible = False
        '
        'PageHeader
        '
        Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.xrlblAddress, Me.xrlblTitle, Me.xrlFromTo, Me.XrLabel1})
        Me.PageHeader.Height = 171
        Me.PageHeader.Name = "PageHeader"
        Me.PageHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'xrlblAddress
        '
        Me.xrlblAddress.Location = New System.Drawing.Point(33, 33)
        Me.xrlblAddress.Name = "xrlblAddress"
        Me.xrlblAddress.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrlblAddress.Size = New System.Drawing.Size(575, 25)
        Me.xrlblAddress.StylePriority.UseTextAlignment = False
        Me.xrlblAddress.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'xrlblTitle
        '
        Me.xrlblTitle.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.xrlblTitle.Location = New System.Drawing.Point(158, 8)
        Me.xrlblTitle.Name = "xrlblTitle"
        Me.xrlblTitle.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrlblTitle.Size = New System.Drawing.Size(342, 25)
        Me.xrlblTitle.StylePriority.UseFont = False
        Me.xrlblTitle.StylePriority.UseTextAlignment = False
        Me.xrlblTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'xrlFromTo
        '
        Me.xrlFromTo.Location = New System.Drawing.Point(150, 134)
        Me.xrlFromTo.Name = "xrlFromTo"
        Me.xrlFromTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.xrlFromTo.Size = New System.Drawing.Size(350, 25)
        Me.xrlFromTo.StylePriority.UseTextAlignment = False
        Me.xrlFromTo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'XrLabel1
        '
        Me.XrLabel1.Font = New System.Drawing.Font("Tahoma", 16.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.Location = New System.Drawing.Point(242, 108)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.Size = New System.Drawing.Size(167, 25)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "Profit & Loss"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
        '
        'PageFooter
        '
        Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfo1})
        Me.PageFooter.Height = 42
        Me.PageFooter.Name = "PageFooter"
        Me.PageFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.PageFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrPageInfo1
        '
        Me.XrPageInfo1.Format = "Print on - {0:dd-MMM-yy H:mm}"
        Me.XrPageInfo1.Location = New System.Drawing.Point(25, 0)
        Me.XrPageInfo1.Name = "XrPageInfo1"
        Me.XrPageInfo1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
        Me.XrPageInfo1.Size = New System.Drawing.Size(216, 25)
        '
        'xrProfitnLoss
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeader, Me.PageFooter})
        Me.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version = "8.2"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
    Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow6 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow7 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell18 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell21 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell19 As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcStockValue As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcTotalPurchases As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcTotalSales As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcTotalPurchasesCost As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcTotalExpenses As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcSalesProfit As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcCashttoPay As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrtcCashtoReceive As DevExpress.XtraReports.UI.XRTableCell
    Public WithEvents xrlFromTo As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPageInfo1 As DevExpress.XtraReports.UI.XRPageInfo
    Public WithEvents xrlblTitle As DevExpress.XtraReports.UI.XRLabel
    Public WithEvents xrlblAddress As DevExpress.XtraReports.UI.XRLabel
End Class
