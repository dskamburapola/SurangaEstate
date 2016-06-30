Imports System.Threading
Imports System.Globalization

Public Class frmMain

#Region "Form Events"

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DevExpress.Skins.SkinManager.EnableFormSkins()
        DevExpress.LookAndFeel.LookAndFeelHelper.ForceDefaultLookAndFeelChanged()
        bsiLoggedUser.Caption = UserName + " - [" + UserType + "]"
        Me.ShowAppInformation()
        Me.RibbonControl.Minimized = True

        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
        ' Sets the UI culture to French (France)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-GB")


    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

#End Region

#Region "Bar Button Events"
    Private Sub BarButtonItem33_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem33.ItemClick
        ShowIStockForm(frmChart_Expenses)
    End Sub
    Private Sub BarButtonItem32_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem32.ItemClick
        ShowIStockForm(frmChart_income)
    End Sub
    Private Sub BarButtonItem31_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem31.ItemClick
        ShowIStockForm(frmCoinCalculator)
    End Sub

    Private Sub BarButtonItem1_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        ShowIStockForm(frmSuppliers)
    End Sub

    Private Sub BarButtonItem2_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        ShowIStockForm(frmCustomers)
    End Sub

    Private Sub BarButtonItem3_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        ShowIStockForm(frmStock)
    End Sub

    Private Sub BarButtonItem4_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        ShowIStockForm(frmDailyWorkings)
    End Sub

    Private Sub BarButtonItem5_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        ShowIStockForm(frmTermDeductions)
    End Sub

    Private Sub BarButtonItem6_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        ShowIStockForm(frmCashAdvance)
    End Sub

    Private Sub BarButtonItem10_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        ShowIStockForm(frmReceivePayments)
    End Sub

    Private Sub BarButtonItem11_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        ShowIStockForm(frmEmployers)
    End Sub

    Private Sub BarButtonItem12_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        ShowIStockForm(frmUserLogins)
    End Sub

    Private Sub BarButtonItem7_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        ShowIStockForm(frmStockBalance)
    End Sub

    Private Sub BarButtonItem8_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        ShowIStockForm(frmItemstoOrder)
    End Sub

    Private Sub BarButtonItem9_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        ShowIStockForm(frmProfitLoss)
    End Sub

    Private Sub BarButtonItem13_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        ShowIStockForm(frmExpenses)
    End Sub

    Private Sub BarButtonItem14_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        ShowIStockForm(frmCompany)
    End Sub

    Private Sub BarButtonItem15_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        ShowIStockForm(frmCustomerSummary)
    End Sub

    Private Sub BarButtonItem16_ItemClick_1(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        ShowIStockForm(frmDailySummary)
    End Sub

    Private Sub BarButtonItem17_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        ShowIStockForm(frmLogBookSummary)
    End Sub

    Private Sub BarButtonItem18_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        ShowIStockForm(frmBulkSettlement)
    End Sub

    Private Sub BarButtonItem22_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem22.ItemClick
        Application.Exit()
    End Sub

    Private Sub BarButtonItem21_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem21.ItemClick
        Application.Restart()
    End Sub

    Private Sub BarButtonItem23_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem23.ItemClick
        ShowIStockForm(frmRoles)
    End Sub

    Private Sub BarButtonItem20_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem20.ItemClick
        ShowIStockForm(frmSettings)
    End Sub

    Private Sub BarButtonItem24_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem24.ItemClick
        ShowIStockForm(frmAttendaceReport)
    End Sub

    Private Sub BarButtonItem25_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem25.ItemClick
        ShowIStockForm(frmCheckRoll)
    End Sub
    Private Sub BarButtonItem27_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem27.ItemClick
        ShowIStockForm(frmUpdateRatesBulk)
    End Sub

    Private Sub BarButtonItem26_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem26.ItemClick
        ShowIStockForm(frmCropSummaryReport)
    End Sub

    Private Sub BarButtonItem28_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem28.ItemClick
        ShowIStockForm(frmCropSummaryMonthlyReport)
    End Sub

    Private Sub BarButtonItem29_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem29.ItemClick
        ShowIStockForm(frmCheckRollCasualReport)
    End Sub

    Private Sub BarButtonItem30_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem30.ItemClick
        ShowIStockForm(frmOtherIncome)
    End Sub
    Private Sub BarButtonItem34_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem34.ItemClick
        ShowIStockForm(frmFieldPerformance)
    End Sub
#End Region

#Region "Show App Information"

    Private Sub ShowAppInformation()
        Try
            ' Set the title of the form.
            Dim ApplicationTitle As String
            If My.Application.Info.Title <> "" Then
                ApplicationTitle = My.Application.Info.Title
            Else
                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If
            Me.Text = ApplicationTitle

            Dim informationSuperToolTip As DevExpress.Utils.SuperToolTip = New DevExpress.Utils.SuperToolTip
            Dim ToolTipTitleItemTitle As DevExpress.Utils.ToolTipTitleItem = New DevExpress.Utils.ToolTipTitleItem

            informationSuperToolTip.Items.Add(ToolTipTitleItemTitle)
            Me.bsiInformation.SuperTip = informationSuperToolTip

            With Me.bsiInformation
                .SuperTip = informationSuperToolTip
                .SuperTip.Items.AddTitle(My.Application.Info.ProductName)
                .SuperTip.Items.AddSeparator()
                .SuperTip.Items.AddTitle(String.Format("Version {0}", My.Application.Info.Version.ToString))
                .SuperTip.Items.Add(My.Application.Info.Copyright + vbCrLf)
                .SuperTip.Items.Add(My.Application.Info.CompanyName)
            End With


        Catch ex As Exception
            MessageError(ex.ToString)
        End Try
    End Sub

#End Region
   
    Private Sub BarButtonItem35_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem35.ItemClick

        ShowIStockForm(frmMonthlyReport)


    End Sub

    Private Sub BarButtonItem36_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem36.ItemClick
        ShowIStockForm(frmOverallSalaryReport)
    End Sub

    Private Sub BarButtonItem37_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem37.ItemClick
        ShowIStockForm(frmDailyCropSummary)
    End Sub

    Private Sub BarButtonItem38_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem38.ItemClick
        ShowIStockForm(frmWorkDayShedule)
    End Sub

    Private Sub BarButtonItem39_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem39.ItemClick
        ShowIStockForm(frmMonthlyExpenses)
    End Sub

    Private Sub BarButtonItem40_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem40.ItemClick
        ShowIStockForm(frmStaffSalary)
    End Sub

    Private Sub BarButtonItem41_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem41.ItemClick
        ShowIStockForm(frmHolidayShedule)
    End Sub

    Private Sub BarButtonItem42_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem42.ItemClick
        ShowIStockForm(frmFestivalRecovery)
    End Sub

    Private Sub BarButtonItem43_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem43.ItemClick
        ShowIStockForm(frmMonthlyIncome)
    End Sub

    Private Sub BarButtonItem44_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem44.ItemClick
        ShowIStockForm(frmChart_Attendance)
    End Sub

    Private Sub BarButtonItem45_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem45.ItemClick
        ShowIStockForm(frmChart_CropSummary)
    End Sub
End Class