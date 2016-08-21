USE [EstateLive]
GO
/****** Object:  StoredProcedure [dbo].[ReportMonthly]    Script Date: 8/21/2016 10:16:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ReportMonthly]

  @IssueDate DATE
AS

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

DECLARE @TeaCropQty DECIMAL(18,2)
DECLARE @TeaRate DECIMAL(18,2)
DECLARE @TeaAmt DECIMAL(18,2)
DECLARE @TeaDeductions DECIMAL(18,2)

DECLARE @RubberLatextCropQty DECIMAL(18,2)
DECLARE @RubberLatexRate DECIMAL(18,2)
DECLARE @RubberLatexAmt DECIMAL(18,2)

DECLARE @RubberSheetQty DECIMAL(18,2)
DECLARE @RubberSheeRate DECIMAL(18,2)
DECLARE @RubberSheeAmt DECIMAL(18,2)

DECLARE @OtherAmt DECIMAL(18,2)
DECLARE @CropTotal DECIMAL(18,2)

DECLARE @EmployeeSalaryAmt DECIMAL(18,2)
DECLARE @EPF12Amt DECIMAL(18,2)
DECLARE @ETF3Amt DECIMAL(18,2)

DECLARE @PermanentAdvance DECIMAL(18,2)

DECLARE @OthersAmt DECIMAL(18,2)

DECLARE @WaterExp DECIMAL(18,2)

DECLARE @Total DECIMAL (18,2)

 SELECT @TeaCropQty=SUM(OI.Quantity),@TeaRate=MAX(OI.Rate), @TeaAmt=(SUM(OI.Amount))
		FROM tblOtherIncomes AS OI INNER JOIN
        tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID
        WHERE OIT.[Description]='TEA' 
        AND OI.OtherIncomeDate>=@IssueDate AND OI.OtherIncomeDate<=@maxDate
        GROUP BY OIT.[Description]
        
        SELECT @TeaDeductions=SUM(OI.Deduction)
		FROM tblOtherIncomes AS OI INNER JOIN
        tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID
        WHERE OIT.[Description]='TEA' 
        AND OI.OtherIncomeDate>=@IssueDate AND OI.OtherIncomeDate<=@maxDate
        GROUP BY OIT.[Description]

 SELECT @RubberLatextCropQty=SUM(OI.Quantity),@RubberLatexRate=MAX(OI.Rate), @RubberLatexAmt=(SUM(OI.Amount))
		FROM tblOtherIncomes AS OI INNER JOIN
        tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID
        WHERE OIT.[Description]='RUBBER LATEX' 
        AND OI.OtherIncomeDate>=@IssueDate AND OI.OtherIncomeDate<=@maxDate
        GROUP BY OIT.[Description]

 SELECT @RubberSheetQty=SUM(OI.Quantity),@RubberSheeRate=MAX(OI.Rate), @RubberSheeAmt=(SUM(OI.Amount))
		FROM tblOtherIncomes AS OI INNER JOIN
        tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID
        WHERE OIT.[Description]='RUBBER SHEETS' 
        AND OI.OtherIncomeDate>=@IssueDate AND OI.OtherIncomeDate<=@maxDate
        GROUP BY OIT.[Description]

 SELECT @OtherAmt=(SUM(OI.Amount))
		FROM tblOtherIncomes AS OI INNER JOIN
        tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID
        WHERE OIT.[Description]='INCOME OF SRATERGIC DEVELOPMENT PROJECTS' 
        AND OI.OtherIncomeDate>=@IssueDate AND OI.OtherIncomeDate<=@maxDate
        GROUP BY OIT.[Description]

SELECT @CropTotal=(ISNULL(@TeaAmt,0)+ISNULL(@RubberLatexAmt,0)+ISNULL(@RubberSheeAmt,0)+ISNULL(@OtherAmt,0))-(ISNULL(@TeaDeductions,0))




----Permanent Salary

DECLARE @permanenttotalSalary DECIMAL(18,2)
DECLARE @casulaSalary DECIMAL(18,2)
DECLARE @staffSalary DECIMAL(18,2)

DECLARE  @CalculatedListPermanent TABLE 
(
	EmployeeID BIGINT,
	TotalDays DECIMAL(18,2),	
	PluckingKgs DECIMAL(18,2),
	TappingL DECIMAL(18,2),
	OverKgs DECIMAL(18,2),
	PluckingOrTappingPay DECIMAL(18,2),
	OverKgsPay DECIMAL(18,2),	
	WCPay DECIMAL(18,2),
	DevalutionAllowance DECIMAL(18,2),
	GrandTotalPay DECIMAL(18,2),
	EPFAmount DECIMAL(18,2),
	PayChit DECIMAL(18,2),
	FestivalAdvance DECIMAL(18,2),
	CashAdvance DECIMAL(18,2),
	TotalDeductions DECIMAL(18,2),
	BalancePay DECIMAL(18,2),
	EPF_12 DECIMAL(18,2),
	EPF_20 DECIMAL(18,2),
	ETF_3 DECIMAL(18,2)
	
)

INSERT INTO @CalculatedListPermanent
EXEC ReportMonthlySubPermanent @IssueDate

SELECT @permanenttotalSalary=SUM(balancepay),@EPF12Amt=SUM(EPF_12),@ETF3Amt=SUM(ETF_3) FROM @CalculatedListPermanent


DECLARE @CalculatedListCasual TABLE
(
	EmployeeID BIGINT,
	TotalDays DECIMAL(18,2),	
	PluckingKgs DECIMAL(18,2),
	TappingL DECIMAL(18,2),
	OverKgs DECIMAL(18,2),
	DaysPay DECIMAL(18,2),
	OverKgsPay DECIMAL(18,2),		
	GrandTotalPay DECIMAL(18,2),	
	FestivalAdvance DECIMAL(18,2),
	CashAdvance DECIMAL(18,2),
	TotalDeductions DECIMAL(18,2),
	BalancePay DECIMAL(18,2)
	
)

INSERT INTO @CalculatedListCasual
EXEC ReportMonthlySubCasual @IssueDate

SELECT @casulaSalary=SUM(BalancePay) FROM @CalculatedListCasual

---------------------------------------------------------------------


DECLARE @CalculatedListStaff TABLE
(
	EmployeeID BIGINT,
	TotalDays DECIMAL(18,2),	
	GrandTotalPay DECIMAL(18,2),	
	
	CashAdvance DECIMAL(18,2),
	TotalDeductions DECIMAL(18,2),
	BalancePay DECIMAL(18,2)
	
)

INSERT INTO @CalculatedListStaff
EXEC ReportMonthlySubStaff @IssueDate

SELECT @staffSalary=SUM(BalancePay) FROM @CalculatedListStaff

----------------------------------------------------------------------



SET @EmployeeSalaryAmt =ISNULL(@permanenttotalSalary,0)+ISNULL(@casulaSalary,0)+isnull(@staffSalary,0)


SET @Total= ISNULL(@EmployeeSalaryAmt,0)+ISNULL(@EPF12Amt,0)+ISNULL(@ETF3Amt,0)

SELECT @OthersAmt=SUM(E.Amount) FROM  tblExpenses E WHERE E.ExpenseDate>=@IssueDate AND E.ExpenseDate<=@maxDate
SELECT @WaterExp=SUM(E.Amount) FROM  tblExpenses E WHERE E.ExpenseTypeID=4 AND E.ExpenseDate>=@IssueDate AND E.ExpenseDate<=@maxDate 


SELECT 
	 ISNULL(@TeaCropQty,0) AS TeaCropQty
	,ISNULL(@TeaRate,0) AS TeaRate
	,ISNULL(@TeaAmt,0) AS TeaAmt
	,ISNULL(@TeaDeductions,0) AS TeaDeductions 
	,ISNULL(@RubberLatextCropQty,0) AS RubberLatextCropQty 	
	,ISNULL(@RubberLatexRate,0) AS RubberLatexRate 
	,ISNULL(@RubberLatexAmt,0) AS RubberLatexAmt	
	,ISNULL(@RubberSheetQty,0)  AS RubberSheetQty
	,ISNULL(@RubberSheeRate,0) AS RubberSheeRate
	,ISNULL(@RubberSheeAmt,0) AS RubberSheeAmt	
	,ISNULL(@OtherAmt,0) AS OtherAmt 
	,ISNULL(@CropTotal,0) AS CropTotal 
	,ISNULL(@EmployeeSalaryAmt,0) AS EmployeeSalaryAmt 
	--,@AdminSalaryAmt
	,ISNULL(@EPF12Amt,0) AS  EPF12Amt
	,ISNULL(@ETF3Amt,0) AS  ETF3Amt
	--,@AllowanceAmt 
	,ISNULL(@OthersAmt,0) AS OthersAmt
	,ISNULL(@WaterExp,0) AS WaterExp
	,@Total AS Total


SELECT TOP 3  E.EmployerNo, E.EmployerName, ISNULL(SUM(DW.Quantity),0) AS  Quantity
FROM         tblAbbreviation AS A INNER JOIN
                      tblDailyWorking AS DW ON A.AbbreviationID = DW.AbbreviationID INNER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID
                      WHERE A.AbbreviationCode='P'
                      AND DW.WorkingDate >=@IssueDate AND DW.WorkingDate<= @maxDate
                      GROUP BY  E.EmployerNo, E.EmployerName
                      ORDER BY  SUM(DW.Quantity) DESC

SELECT TOP 3 E.EmployerNo, E.EmployerName, ISNULL(SUM(DW.Quantity),0) AS  Quantity
FROM         tblAbbreviation AS A INNER JOIN
                      tblDailyWorking AS DW ON A.AbbreviationID = DW.AbbreviationID INNER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID
                      WHERE A.AbbreviationCode='T'
                      AND DW.WorkingDate >=@IssueDate AND DW.WorkingDate<= @maxDate
                       GROUP BY  E.EmployerNo, E.EmployerName
                      ORDER BY  SUM(DW.Quantity) DESC
                      
SELECT TOP 3  E.EmployerNo, E.EmployerName, ISNULL(SUM(DW.Quantity),0) AS  Quantity
FROM         tblAbbreviation AS A INNER JOIN
                      tblDailyWorking AS DW ON A.AbbreviationID = DW.AbbreviationID INNER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID
                      WHERE A.AbbreviationCode='RS'
                      AND DW.WorkingDate >=@IssueDate AND DW.WorkingDate<= @maxDate
                     GROUP BY  E.EmployerNo, E.EmployerName
                      ORDER BY  SUM(DW.Quantity) DESC
                     

	

declare @WorkDays int
set @WorkDays = 0 
                      
SELECT        TOP (1) @WorkDays = WDD.WorkDays
FROM          tblWorkDays AS WD INNER JOIN
              tblWorkDaysDescription AS WDD ON WD.WorkDayID = WDD.WorkDayID
where		 WD.YearName = year(@IssueDate) and WDD.[MonthName] = datename(month,@IssueDate)			 

						 
if @WorkDays = 0 or @WorkDays is null
begin
set @WorkDays=1
end


SELECT TOP 5 DW.EmployeeID, E.EmployerNo, E.EmployerName, COUNT(DW.WorkedDays) AS WorkedDays, (COUNT(DW.WorkedDays) * 100 / @WorkDays) AS DaysAvg,
ISNULL(SUM(CASE A.AbbreviationCode WHEN 'P' THEN  DW.Quantity END),0) AS Plucking,
ISNULL(SUM(CASE A.AbbreviationCode WHEN 'T' THEN  DW.Quantity END),0) AS Tapping,
ISNULL(SUM(CASE A.AbbreviationCode WHEN 'RS' THEN  DW.Quantity END),0) AS RubberSheet
                    
FROM         tblDailyWorking AS DW INNER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID INNER JOIN
                      tblAbbreviation AS A ON DW.AbbreviationID = A.AbbreviationID
WHERE     
(DW.WorkType = N'CASUAL') AND
DW.WorkingDate >=@IssueDate AND DW.WorkingDate<= @maxDate
GROUP BY DW.EmployeeID, E.EmployerNo,E.EmployerName     
ORDER BY WorkedDays DESC



SELECT     SUM(ISNULL(CA.AdvanceAmount, 0)) AS Advance, EM.Designation
FROM         tblCashAdvance AS CA INNER JOIN
                      tblEmployers AS EM ON CA.EmployerId = EM.EmployerID
WHERE CA.IssueDate >=@IssueDate AND CA.IssueDate<= @maxDate
GROUP BY EM.Designation

SELECT     SUM(ISNULL(TD.TDAmount, 0)) AS FestivalAdvance, EM.Designation
FROM         tblTermDeductions AS TD INNER JOIN
                      tblEmployers AS EM ON TD.EmployerId = EM.EmployerID
WHERE TD.TDDate >=@IssueDate AND TD.TDDate<= @maxDate
GROUP BY EM.Designation

SELECT     SUM(ISNULL(EX.Amount, 0)) AS OtherExpense, EXT.Description
FROM         tblExpenses AS EX LEFT OUTER JOIN
                      tblExpenseTypes AS EXT ON EX.ExpenseTypeID = EXT.ExpenseTypeID
WHERE     (EX.ExpenseDate >= @IssueDate) AND (EX.ExpenseDate <= @maxDate)
GROUP BY EXT.Description


SELECT        Quantity as FW  FROM  tblOtherIncomes where OtherIncomeID=1 and OtherIncomeDate >=@IssueDate and OtherIncomeDate <= @maxDate

select sum(Quantity) as RW from tblDailyWorking where AbbreviationID=1 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays)  as PLUCKER from tblDailyWorking where AbbreviationID=1 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays) as SUNDRAY from tblDailyWorking where AbbreviationID not in (1,8,21,34) and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays) as WATCHER from tblDailyWorking where AbbreviationID=34 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate


select sum(WorkedDays) as STAFF from tblDailyWorking where AbbreviationID=21 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate
