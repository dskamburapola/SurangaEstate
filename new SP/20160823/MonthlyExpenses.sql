USE [EstateAugust]
GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses]    Script Date: 27/Aug/2016 5:15:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[MonthlyExpenses]
 @ReportDate DATE
AS

--Permanent section
--declare @ReportDate DATE
--set @ReportDate = '2016-10-01'

DECLARE @maxDateKP DATE
DECLARE @maxDate DATE

DECLARE @tempPermanent TABLE(EmployeeNo bigint,EmployeeName nvarchar(100),FestivalAdvance decimal(18,2),CashAdvance decimal(18,2),  BalancePay DECIMAL(18,2), CashRewards decimal(18,2), EPF_12 decimal(18,2), ETF_3 decimal(18,2))
INSERT INTO @tempPermanent(EmployeeNo,EmployeeName,FestivalAdvance,CashAdvance,BalancePay,CashRewards,EPF_12,ETF_3)
EXEC	[dbo].[MonthlyExpenses_Cal_Permanent] @IssueDate =@ReportDate

--Permanent Total
	
	SELECT  ISNULL(SUM(BalancePay),0) AS PermenentTotal FROM @tempPermanent
	
-- [select * from @tempPermanent]

--Casual Total 1-15
DECLARE @tempCasual1to15 TABLE(EmployeeNo bigint,EmployeeName nvarchar(100),FestivalAdvance decimal(18,2),CashAdvance decimal(18,2), BalancePay DECIMAL(18,2),CashRewards decimal(18,2))
INSERT INTO @tempCasual1to15(EmployeeNo,EmployeeName,FestivalAdvance,CashAdvance,BalancePay, CashRewards)
EXEC	[dbo].[MonthlyExpenses_Cal_Casual] @IssueDate = @ReportDate, @daterange =1
	
--Cacual total 1-15
	
SELECT  ISNULL(SUM(BalancePay),0) AS CasualTotalto15 FROM @tempCasual1to15
	

DECLARE @tempCasual15toEOM TABLE(EmployeeNo bigint,EmployeeName nvarchar(100),FestivalAdvance decimal(18,2),CashAdvance decimal(18,2), BalancePay DECIMAL(18,2),CashRewards decimal(18,2))
INSERT INTO @tempCasual15toEOM(EmployeeNo,EmployeeName,FestivalAdvance,CashAdvance,BalancePay,CashRewards)
EXEC	[dbo].[MonthlyExpenses_Cal_Casual] @IssueDate = @ReportDate, @daterange =2

	--Cacual total 15-EOM
	--select * from @tempCasual
	SELECT  ISNULL(SUM(BalancePay),0) AS CasualTotal5toEOM FROM @tempCasual15toEOM
	
	cy91x2
--********************************************************************************************************	
	
--	declare @ReportDate DATE
--set @ReportDate = '2016-10-01'

DECLARE @tempStaff TABLE(EmployeeNo bigint,EmployeeName nvarchar(100),CashAdvance decimal(18,2),  BalancePay DECIMAL(18,2))
INSERT INTO @tempStaff(EmployeeNo,EmployeeName,CashAdvance,BalancePay)
EXEC	[dbo].[MonthlyExpenses_Cal_Staff] @IssueDate =@ReportDate


SELECT  ISNULL(SUM(BalancePay),0) AS KPB FROM @tempStaff


SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@ReportDate)+1,0))


--select  EmployeeNo , EmployeeName , CashAdvance from @tempPermanent
--where CashAdvance>0

SELECT  CA.IssueDate, CA.AdvanceAmount, E.EmployerNo, E.EmployerName as EmployeeName
FROM   tblCashAdvance AS CA INNER JOIN
       tblEmployers AS E ON CA.EmployerId = E.EmployerID
	   Where  CA.IssueDate >=@ReportDate and  CA.IssueDate <=@maxDate
	   and 	 E.Designation='PERMANENT'
	   order by CA.IssueDate
	
--select EmployeeNo , EmployeeName , CashAdvance from @tempCasual1to15 where CashAdvance>0
--union all
--select EmployeeNo , EmployeeName , CashAdvance from @tempCasual15toEOM where CashAdvance>0

SELECT  CA.IssueDate, CA.AdvanceAmount, E.EmployerNo, E.EmployerName as EmployeeName
FROM   tblCashAdvance AS CA INNER JOIN
       tblEmployers AS E ON CA.EmployerId = E.EmployerID
	   Where  CA.IssueDate >=@ReportDate and  CA.IssueDate <=@maxDate
	   and 	 E.Designation='STAFF'
	   order by CA.IssueDate


SELECT        E.EmployerNo, E.EmployerName, TD.TDDate, TD.TDAmount
FROM          tblTermDeductions AS TD INNER JOIN
              tblEmployers AS E ON TD.EmployerID = E.EmployerID
			  Where  TD.TDDate >=@ReportDate and  TD.TDDate <=@maxDate
			  and E.Designation='PERMANENT'





	--EPF & ETF
	
	SELECT   EmployeeName ,EPF_12 FROM @tempPermanent
	
	SELECT   EmployeeName , ETF_3 FROM @tempPermanent
	
	
	--expenses
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate, E.Remarks
	FROM       tblExpenses AS E INNER JOIN
               tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
	WHERE     (E.ExpenseDate >= @ReportDate) AND (E.ExpenseDate <= @maxDate)
	
	AND ET.[Description]<> 'MACHINE CHARGES' order by ET.[Description]
	
	
	--SELECT  'K.P.Santiyago' as EmployeeName, 5000 AS KPA

	SET @maxDateKP= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@ReportDate)+1,0))


SELECT        tblEmployers.EmployerNo, tblEmployers.EmployerName as EmployeeName, sum(isnull(tblCashAdvance.AdvanceAmount,0)) as StaffAdvance
FROM            tblCashAdvance INNER JOIN
                         tblEmployers ON tblCashAdvance.EmployerId = tblEmployers.EmployerID
where Designation='STAFF' AND IssueDate>=@ReportDate and IssueDate<=@maxDateKP 
group by tblEmployers.EmployerNo, tblEmployers.EmployerName
	 
	
	
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate, E.Remarks
	FROM       tblExpenses AS E INNER JOIN
               tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
	WHERE     (E.ExpenseDate >= @ReportDate) AND (E.ExpenseDate <= @maxDate)
	
	AND ET.[Description]= 'MACHINE CHARGES'

	--cash Rewards





	select  EmployeeNo , EmployeeName , CashRewards from @tempPermanent where CashRewards>0
	UNION ALL		
	select EmployeeNo , EmployeeName , CashRewards from @tempCasual1to15 where CashRewards>0
	UNION ALL
	select EmployeeNo , EmployeeName , CashRewards from @tempCasual15toEOM where CashRewards>0

	--union all
	--select '0','0','0'
	SELECT        E.EmployerNo, E.EmployerName, TD.TDDate, TD.TDAmount
FROM          tblTermDeductions AS TD INNER JOIN
              tblEmployers AS E ON TD.EmployerID = E.EmployerID
			  Where  TD.TDDate >=@ReportDate and  TD.TDDate <=@maxDate
			  and E.Designation='CASUAL'

	SELECT        E.EmployerNo, E.EmployerName, TD.TDDate, TD.TDAmount
FROM          tblTermDeductions AS TD INNER JOIN
              tblEmployers AS E ON TD.EmployerID = E.EmployerID
			  Where  TD.TDDate >=@ReportDate and  TD.TDDate <=@maxDate
			  and E.Designation='STAFF'

SELECT  CA.IssueDate, CA.AdvanceAmount, E.EmployerNo, E.EmployerName as EmployeeName
FROM   tblCashAdvance AS CA INNER JOIN
       tblEmployers AS E ON CA.EmployerId = E.EmployerID
	   Where  CA.IssueDate >=@ReportDate and  CA.IssueDate <=@maxDate
	   and 	 E.Designation='CASUAL'
	   order by CA.IssueDate