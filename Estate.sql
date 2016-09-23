USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[ FestivalRecovery_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ FestivalRecovery_Insert]

@EmployerId bigint,
    @IssueDate datetime,
    @AdvanceAmount decimal(18, 2),
    @CreatedBy bigint,
    @UpdatedBy bigint = NULL
   

AS

INSERT INTO [dbo].[tblFestivalRecovery] ([EmployerId], [IssueDate], [AdvanceAmount], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
	VALUES (@EmployerId, @IssueDate, @AdvanceAmount, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[AAA]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AAA]

@IssueDate DATE

AS


--Gettin last date of the month

DECLARE @maxDate DATE 
--DECLARE @IssueDate DATE

--set @IssueDate='2016-09-01'
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	BasicPay decimal(18,2),
	PayChit decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,BasicPay,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

isnull(SUM(TDW.NameDays),0) AS NameDays,
		 

isnull((SELECT  tblStaffPay.Amount  FROM  tblStaffPay 
	LEFT OUTER JOIN tblEmployers ON tblStaffPay.EmployerID = tblEmployers.EmployerID
	where PayDate>=@IssueDate and PayDate<=@maxDate 
	),0) AS BasicPay,

isnull(MAX(TDW.PayChit),0) as PayChit,

isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1
GROUP BY TD.EmployerID

),0) as FestivalAdvance,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.00) +
isnull(MAX(TDW.PayChit),0)+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(
isnull((SELECT  tblStaffPay.Amount  FROM  tblStaffPay 
	LEFT OUTER JOIN tblEmployers ON tblStaffPay.EmployerID = tblEmployers.EmployerID
		where PayDate>=@IssueDate and PayDate<=@maxDate 
	),0)
)

-
(((isnull(SUM( 0),0))*0.00) +
isnull(MAX(TDW.PayChit),0)+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay

FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='STAFF'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.NameDays,
						 XYZ.BasicPay,
						 XYZ.PayChit, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

GO
/****** Object:  StoredProcedure [dbo].[Abbreviation_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Abbreviation_Delete]

  @AbbreviationID bigint

AS

Update
	[dbo].[tblAbbreviation]
	set IsDeleted=1
	WHERE  [AbbreviationID] = @AbbreviationID

GO
/****** Object:  StoredProcedure [dbo].[Abbreviation_For_RubberSheets]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Abbreviation_For_RubberSheets]


AS

SELECT [AbbreviationID], [AbbreviationCode], [AbbreviationDesc] 
FROM   [dbo].[tblAbbreviation] 
WHERE [AbbreviationCode]='RS'

--SELECT [AbbreviationID], [AbbreviationCode], [AbbreviationDesc] 
--FROM   [dbo].[tblAbbreviation] 
--where [AbbreviationCode]='P' OR [AbbreviationCode]='T'

GO
/****** Object:  StoredProcedure [dbo].[Abbreviation_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Abbreviation_GetAll]


AS

SELECT [AbbreviationID], [AbbreviationCode], [AbbreviationDesc] 
FROM   [dbo].[tblAbbreviation] 
Where  isnull(IsDeleted,0) <>1

SELECT [AbbreviationID], [AbbreviationCode], [AbbreviationDesc] 
FROM   [dbo].[tblAbbreviation] 
where [AbbreviationCode]='P' OR [AbbreviationCode]='T'
AND  isnull(IsDeleted,0) <>1

GO
/****** Object:  StoredProcedure [dbo].[Abbreviation_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Abbreviation_Insert]

  @AbbreviationCode nvarchar(3) = NULL,
  @AbbreviationDesc nvarchar(50) = NULL,
  @IsProductionType nvarchar(50)  


AS

INSERT INTO [dbo].[tblAbbreviation] ([AbbreviationCode], [AbbreviationDesc],IsProductionType)
	VALUES (@AbbreviationCode, @AbbreviationDesc, @IsProductionType)

GO
/****** Object:  StoredProcedure [dbo].[All_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[All_Delete]

AS

Delete tblCollections
Delete tblPurchasesDescription
Delete tblPurchases
Delete tblSalesDescription
Delete tblSales
Delete tblSuppliers
Delete tblStock
Delete tblStockCategory
Delete tblExpenses
Delete tblExpenseTypes
Delete tblModels
Delete tblCustomers
Delete tblLogBook
Delete tblMessages
delete dbo.tblDailyWorkingFORSUMMARY
delete dbo.tblDailyWorkingDescription
delete dbo.tblDailyWorking
delete dbo.tblCashAdvance
delete dbo.ProductSale
delete dbo.tblLMB
delete dbo.tblLogBook
delete dbo.tblMessages
delete dbo.tblModels
delete dbo.tblOtherIncomes
delete dbo.tblOtherIncomeTypes
delete dbo.tblStock
delete dbo.tblStockCategory
delete dbo.tblSuppliers
delete dbo.tblTermDeductionDescription
delete dbo.tblTermDeductions
delete dbo.tblTEST
delete dbo.tblEmployers where EmployerID <>1

GO
/****** Object:  StoredProcedure [dbo].[AllInfosp]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AllInfosp]
	
AS

SELECT     tbl888.widx, tbl888.EmployerName, tbl888.Quantity, tbl888.EPF, tbl888.WorkingDate
FROM         tbl888   order by tbl888.widx

GO
/****** Object:  StoredProcedure [dbo].[Application_GetServerDateTime]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Application_GetServerDateTime]

	@ServerDateTime datetime output

AS
set @ServerDateTime=CAST( CONVERT( CHAR(8), GetDate(), 112) AS DATETIME)

GO
/****** Object:  StoredProcedure [dbo].[Attendance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attendance]

-- DECLARE  @StartDate date,
--DECLARE @EndDate date

 
AS 
  DECLARE  @StartDate date
DECLARE @EndDate date
  SET  @StartDate ='01-08-2014'
  SET @EndDate ='31-08-2014'
--select * from tblDailyWorking 



select EmployeeID,

--ISNULL((MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 1 THEN [WorkedDays] ELSE NULL END)),0) AS [1],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 2 THEN [WorkedDays] ELSE NULL END) AS [1],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 2 THEN [WorkedDays] ELSE NULL END) AS [2],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 3 THEN [WorkedDays] ELSE NULL END) AS [3],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 4 THEN [WorkedDays] ELSE NULL END) AS [4],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 5 THEN [WorkedDays] ELSE NULL END) AS [5],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 6 THEN [WorkedDays] ELSE NULL END) AS [6],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 7 THEN [WorkedDays] ELSE NULL END) AS [7],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 8 THEN [WorkedDays] ELSE NULL END) AS [8],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 9 THEN [WorkedDays] ELSE NULL END) AS [9],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 10 THEN [WorkedDays] ELSE NULL END) AS [10],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 11 THEN [WorkedDays] ELSE NULL END) AS [11],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 12 THEN [WorkedDays] ELSE NULL END) AS [12],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 13 THEN [WorkedDays] ELSE NULL END) AS [13],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 14 THEN [WorkedDays] ELSE NULL END) AS [11],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 15 THEN [WorkedDays] ELSE NULL END) AS [15],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 16 THEN [WorkedDays] ELSE NULL END) AS [16],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 17 THEN [WorkedDays] ELSE NULL END) AS [17],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 18 THEN [WorkedDays] ELSE NULL END) AS [18],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 19 THEN [WorkedDays] ELSE NULL END) AS [19],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 20 THEN [WorkedDays] ELSE NULL END) AS [20],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 21 THEN [WorkedDays] ELSE NULL END) AS [21],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 22 THEN [WorkedDays] ELSE NULL END) AS [22],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 23 THEN [WorkedDays] ELSE NULL END) AS [23],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 24 THEN [WorkedDays] ELSE NULL END) AS [24],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 25 THEN [WorkedDays] ELSE NULL END) AS [25],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 26 THEN [WorkedDays] ELSE NULL END) AS [26],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 27 THEN [WorkedDays] ELSE NULL END) AS [27],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 28 THEN [WorkedDays] ELSE NULL END) AS [28],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 29 THEN [WorkedDays] ELSE NULL END) AS [29],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 30 THEN [WorkedDays] ELSE NULL END) AS [30],
MAX(CASE WHEN DATEPART(DAY, WorkingDate) = 31 THEN [WorkedDays] ELSE NULL END) AS [31]

FROM tblDailyWorking

WHERE     convert(date, tblDailyWorking.WorkingDate,103) >= convert(date, @StartDate,103) AND convert(date, tblDailyWorking.WorkingDate,103) <= convert(date, @EndDate,103)

GROUP BY EmployeeID
ORDER BY EmployeeID

GO
/****** Object:  StoredProcedure [dbo].[Attendance_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attendance_Insert]

@AttendanceDate date = NULL,
    @EmployerID bigint = NULL,
    @Working decimal(1, 1) = NULL,
    @DayNo bigint = NULL   

AS


	INSERT INTO [dbo].[tblAttendance] ([AttendanceDate], [EmployerID], [Working], [DayNo])
	VALUES( @AttendanceDate, @EmployerID, @Working, DATEPART(DAY, @AttendanceDate))

GO
/****** Object:  StoredProcedure [dbo].[Attendance_Report_All_WorkCategory]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attendance_Report_All_WorkCategory]

@IssueDate DATE,
@MWA int

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Designation varchar(50),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code

INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Designation, WorkingDate, AbbreviatedCode)

SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Designation,  S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[WorkedDays]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1  AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.Designation, E.EmployerName, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName, S.Designation,  S.WorkingDate 



--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	MWA decimal(18,2),
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,MWA )
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull(SUM(TDW.WorkedDays),0))/@MWA AS MWA

FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.MWA
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

GO
/****** Object:  StoredProcedure [dbo].[Attendance_Report_By_WorkCategory]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Attendance_Report_By_WorkCategory]

@IssueDate DATE,
@MWA int,
@WorkCategoey nvarchar(20)
AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Designation varchar(50),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Designation, WorkingDate, AbbreviatedCode)

SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Designation,  S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[WorkedDays]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType=@WorkCategoey AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.Designation, E.EmployerName, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType=@WorkCategoey AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName, S.Designation,  S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	MWA decimal(18,2),
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,MWA )
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull(SUM(TDW.WorkedDays),0))/@MWA AS MWA

FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType=@WorkCategoey
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.MWA
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

GO
/****** Object:  StoredProcedure [dbo].[AttendanceTEST]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AttendanceTEST]

AS


SELECT 

[ ]      = isnull([EmployeeID], 'Total'),
  [1] = SUM(ISNULL([1],0)),
  [2] = SUM(ISNULL([2],0)),
  [3] = SUM(ISNULL([3],0)),
  [4] = SUM(ISNULL([4],0)),
  [5] = SUM(ISNULL([5],0)),
  [6] = SUM(ISNULL([6],0)),
  
  Total    = SUM(ISNULL([1],0)+ISNULL([2],0)+ISNULL([3],0)+ISNULL([4],0)+ISNULL([5],0)+ISNULL([6],0))
  
FROM (
    SELECT 
        EmployeeID, WorkedDays,DayName FROM tblTEST-- where EmpName='AAAAA'
) as s
PIVOT
(
    SUM([WorkedDays])
    FOR [DayName] IN ([1],[2],[3],[4],[5],[6])
)AS display


GROUP BY
  ROLLUP(EmployeeID)

GO
/****** Object:  StoredProcedure [dbo].[CashAdvance_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashAdvance_Delete]

@CashAdvanceId bigint

AS


	
	Delete from dbo.tblCashAdvance
	WHERE  [CashAdvanceId] = @CashAdvanceId

GO
/****** Object:  StoredProcedure [dbo].[CashAdvance_GetAll_ByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashAdvance_GetAll_ByDates]

  @StartDate date,
  @EndDate date
AS 
	  

SELECT     tblEmployers.EmployerNo, tblEmployers.EmployerName, tblCashAdvance.CashAdvanceId, tblCashAdvance.EmployerId, tblCashAdvance.IssueDate, 
                      tblCashAdvance.AdvanceAmount, tblCashAdvance.CreatedBy, tblCashAdvance.CreatedDate, tblCashAdvance.UpdatedBy, tblCashAdvance.UpdatedDate, 
                      tblUserLogin_1.UserName AS CreatedUser, tblUserLogin.UserName AS UpdatedUser
FROM         tblUserLogin LEFT OUTER JOIN
                      tblCashAdvance ON tblUserLogin.UserLoginID = tblCashAdvance.UpdatedBy RIGHT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblCashAdvance.CreatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblEmployers ON tblCashAdvance.EmployerId = tblEmployers.EmployerID
                      WHERE     convert(date, tblCashAdvance.IssueDate ,103) >= convert(date, @StartDate,103) AND convert(date, tblCashAdvance.IssueDate,103) <= convert(date, @EndDate,103)
ORDER BY tblCashAdvance.IssueDate

GO
/****** Object:  StoredProcedure [dbo].[CashAdvance_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashAdvance_Insert]

@EmployerId bigint,
    @IssueDate datetime,
    @AdvanceAmount decimal(18, 2),
    @CreatedBy bigint,
    @UpdatedBy bigint = NULL
   

AS

INSERT INTO [dbo].[tblCashAdvance] ([EmployerId], [IssueDate], [AdvanceAmount], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
	VALUES (@EmployerId, @IssueDate, @AdvanceAmount, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[CashRewards_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashRewards_Delete]

@CashRewardsId bigint

AS


	
	Delete from dbo.tblCashRewards
	WHERE  [CashRewardsId] = @CashRewardsId

GO
/****** Object:  StoredProcedure [dbo].[CashRewards_GetAll_ByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashRewards_GetAll_ByDates]

  @StartDate date,
  @EndDate date
AS 
	  

SELECT     tblEmployers.EmployerNo, tblEmployers.EmployerName, tblCashRewards.CashRewardsId, tblCashRewards.EmployerId, tblCashRewards.IssueDate, 
                      tblCashRewards.AdvanceAmount, tblCashRewards.CreatedBy, tblCashRewards.CreatedDate, tblCashRewards.UpdatedBy, tblCashRewards.UpdatedDate, 
                      tblUserLogin_1.UserName AS CreatedUser, tblUserLogin.UserName AS UpdatedUser
FROM         tblUserLogin LEFT OUTER JOIN
                      tblCashRewards ON tblUserLogin.UserLoginID = tblCashRewards.UpdatedBy RIGHT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblCashRewards.CreatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblEmployers ON tblCashRewards.EmployerId = tblEmployers.EmployerID
                      WHERE     convert(date, tblCashRewards.IssueDate ,103) >= convert(date, @StartDate,103) AND convert(date, tblCashRewards.IssueDate,103) <= convert(date, @EndDate,103)
ORDER BY tblCashRewards.IssueDate

GO
/****** Object:  StoredProcedure [dbo].[CashRewards_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CashRewards_Insert]

@EmployerId bigint,
    @IssueDate datetime,
    @AdvanceAmount decimal(18, 2),
    @CreatedBy bigint,
    @UpdatedBy bigint = NULL
   

AS

INSERT INTO [dbo].[tblCashRewards] ([EmployerId], [IssueDate], [AdvanceAmount], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate])
	VALUES (@EmployerId, @IssueDate, @AdvanceAmount, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[Charts_Attendance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Charts_Attendance]

@Month INT,
@Year INT

AS



BEGIN

--declare @Month INT
--declare @Year INT

--set @Month=9
--set @Year=2016


declare @IssueDate DATE
declare @MaxDate date
set @IssueDate = convert(date, CONVERT(varchar(10), @Year)+'/'+CONVERT(varchar(10), @Month)+'/'+'01')


SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]



select day( S.DateOfMonth) as MonthDay, X.EmpCount, (select count(*) from tblEmployers) EmpTotalCount from @DateList S
left outer join 

(
select day(WorkingDate) EmpDay,count(WorkingDate) as EmpCount from tblDailyWorking
where year(WorkingDate) =@Year and MONTH(WorkingDate) = @Month
group by day(WorkingDate)
) X on X.EmpDay =day( S.DateOfMonth)



END


GO
/****** Object:  StoredProcedure [dbo].[Charts_CropSummary]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Charts_CropSummary]

@Month INT,
@Year INT

AS



BEGIN

--declare @Month INT
--declare @Year INT

--set @Month=9
--set @Year=2016


declare @IssueDate DATE
declare @MaxDate date
set @IssueDate = convert(date, CONVERT(varchar(10), @Year)+'/'+CONVERT(varchar(10), @Month)+'/'+'01')


SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]


select day( S.DateOfMonth) as MonthDay, X.CropTotal as Plucking,Y.FactoryCrop from @DateList S

left outer join
(

select day(P.WorkingDate) as CropDay,A.AbbreviationDesc,sum(P.Quantity) as CropTotal from tbldailyworking P
inner join tblAbbreviation  A on A.AbbreviationID=P.AbbreviationID
where A.AbbreviationDesc ='PLUCKING'
AND  year(P.WorkingDate) =@Year and MONTH(P.WorkingDate) = @Month
group by day(P.WorkingDate), A.AbbreviationDesc

) X on X.CropDay=day( S.DateOfMonth)

left outer join
(
select day(DP.CurrentDay) as FactoryDay,sum(DP.FactoryCrop) as FactoryCrop from [dbo].[tbleDailyCropSummary] DP
inner join tblAbbreviation  A on A.AbbreviationID=DP.AbbreviationID
where A.AbbreviationDesc ='PLUCKING'
AND  year(DP.CurrentDay) =@Year and MONTH(DP.CurrentDay) = @Month
group by day(DP.CurrentDay)

) Y on Y.FactoryDay=day( S.DateOfMonth)



END







GO
/****** Object:  StoredProcedure [dbo].[Charts_Expense]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Charts_Expense]

@Month INT,
@Year INT

AS




	BEGIN



		
		select  'Balance Salary' as Description, 0  as Amount

		union all

		select  'Cash Advance' as Description, 0 as Amount
		
		union all

		select  'Festival Advance' as Description, 0  as Amount

		union all			

		--select  'Cash Rewards' as Description, 0  as Amount

		--union all

		select  'EPF 12%' as Description, 0  as Amount

		union all

		select  'EPF 3%' as Description, 0  as Amount
		
	

		union all

		SELECT    ET.[Description], sum(E.Amount) as Amount
		FROM      tblExpenses AS E INNER JOIN
				  tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
		WHERE	  YEAR(E.ExpenseDate)= @Year   and month(E.ExpenseDate)= @Month
		and 

		ET.[Description]  in ('WATER','ELECTRICITY','CASH REWARDS', 'MOTIVATION PAYMENTS')  
		group by ET.[Description]
	    

			union all

		SELECT    'Other' as Description, sum(E.Amount) as Amount
		FROM      tblExpenses AS E INNER JOIN
				  tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
		WHERE	  YEAR(E.ExpenseDate)= @Year   and month(E.ExpenseDate)= @Month
		and 
		ET.[Description] not in ('WATER','ELECTRICITY','CASH REWARDS', 'MOTIVATION PAYMENTS')  
		--group by ET.[Description]

	END

GO
/****** Object:  StoredProcedure [dbo].[Charts_Income]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Charts_Income]

@Month INT,
@Year INT

AS

--declare @Month INT
--declare @Year INT

--set @Month=9
--set @Year=2016


declare @expense decimal(18,2)
declare @Income decimal(18,2)
declare @profit decimal(18,2)

set @expense = (
		SELECT    sum(E.Amount) as Amount
		FROM      tblExpenses AS E INNER JOIN
				  tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
		WHERE	  YEAR(E.ExpenseDate)= @Year   and month(E.ExpenseDate)= @Month)




		
select 'Expenses' as Description, @expense as Amount
union all
select 'Income' as Description, 0 as Amount
union all
select 'Profit' as Description, 0 as Amount

		

GO
/****** Object:  StoredProcedure [dbo].[CheckRoll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckRoll]

as


DECLARE @IssueDate DATE
SET @IssueDate=  '2016-09-01'

declare @ea decimal
		 

--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	SmokingS decimal(18,2),
	OverKgs DECIMAL(18,2),
	LowerKgs DECIMAL(18,2),
	OverSheets DECIMAL(18,2),
	LowerSheets DECIMAL(18,2),
	OTHours DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	LowerKgsPay decimal(18,2),
	OverSheetsPay decimal(18,2),
	LowerSheetsPay decimal(18,2),
	SmokingSheetsPay decimal(18,2),	
	OTPay decimal(18,2),
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	EPFAmount decimal(18,2),
	PayChit decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	EPF_12 decimal(18,2),
	EPF_20 decimal(18,2),
	ETF_3 decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull(SUM(case abc.AbbreviationCode 
		when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) 
		when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) 
		when 'W' then WorkedDays
		when 'rs' then TDW.WorkedDays
		when 'SU' then TDW.WorkedDays
		 end),0)) AS NameDays,
		 
		 
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

isnull(SUM(TDW.OTHours),0) AS OTHours,

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0)) AS BasicPay,
		

--select * from tbldailyworking


--select *  from tblAbbreviation


isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as LowerSheetsPay,


isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,


(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.WCPayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.WCPayRate 
when 'W' then WorkedDays * TDW.WCPayRate
when 'rs' then TDW.WorkedDays * TDW.WCPayRate
when 'SU' then TDW.WorkedDays * TDW.WCPayRate
end),0)) AS WCPay,


isnull(0,0) as EvalutionAllowance,
--*******************************************
		 
		 
--*******************************************

-----------------------------------------------------------------------------------------

isnull((isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0)) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) +
(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.WCPayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.WCPayRate 
when 'W' then WorkedDays * TDW.WCPayRate
when 'rs' then TDW.WorkedDays * TDW.WCPayRate
when 'SU' then TDW.WorkedDays * TDW.WCPayRate
end),0)) + isnull(0,0),0) as GrandTotalPay,
-----------------------------------------------------------------------------------------

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.08 AS EPFAmount,

isnull(MAX(TDW.PayChit),0) as PayChit,

isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1
GROUP BY TD.EmployerID
                  

),0) as FestivalAdvance,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

----------------------------------------------------


((isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.08) +
isnull(MAX(TDW.PayChit),0)+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

----------------------------------------------------
--------------------------------------------------------------------------------------------------

(isnull((isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0)) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) +
(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.WCPayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.WCPayRate 
when 'W' then WorkedDays * TDW.WCPayRate
when 'rs' then TDW.WorkedDays * TDW.WCPayRate
when 'SU' then TDW.WorkedDays * TDW.WCPayRate
end),0)) + isnull(0,0),0) )

-
(((isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.08) +
isnull(MAX(TDW.PayChit),0)+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay,


--------------------------------------------------------------------------------------------------

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.12 AS EPF_12,

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.20 AS EPF_20,

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * TDW.DayRate
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * TDW.DayRate 
when 'W' then WorkedDays * TDW.DayRate
when 'rs' then TDW.WorkedDays * TDW.DayRate
when 'SU' then TDW.WorkedDays * TDW.DayRate
end),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.NameDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.SmokingS, 
						 XYZ.OverKgs, 
						 XYZ.LowerKgs,
						 XYZ.OverSheets,
						 XYZ.LowerSheets,
						 XYZ.OTHours,
						 XYZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.LowerKgsPay,
						 XYZ.OverSheetsPay,
						 XYZ.LowerSheetsPay,
						 XYZ.SmokingSheetsPay,	
						 XYZ.OTPay,
						 XYZ.WCPay, 
						 XYZ.EvalutionAllowance, 
						 XYZ.GrandTotalPay, 
						 XYZ.EPFAmount, 
						 XYZ.PayChit, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay,
						 XYZ.EPF_12,
						 XYZ.EPF_20,
						 XYZ.ETF_3  
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

GO
/****** Object:  StoredProcedure [dbo].[Collection_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Collection_Delete]
	@SystemID bigint,
	@TransactionTypeID bigint

AS

DELETE FROM [dbo].[tblCollections]
      WHERE [SystemID]=@SystemID  AND [TransactionTypeID]=@TransactionTypeID

GO
/****** Object:  StoredProcedure [dbo].[Collection_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Collection_GetAll]
	
AS

SELECT     tblCollections.CollectionID, tblCollections.SystemID, tblCollections.TransactionTypeID, tblCollections.PaymentTypeID, tblCollections.Date, 
                      tblCollections.Reference, tblCollections.Amount, tblLookupPaymentTypes.Description, tblLookupTransactionTypes.Description AS [Type]
FROM         tblCollections LEFT OUTER JOIN
                      tblLookupPaymentTypes ON tblCollections.PaymentTypeID = tblLookupPaymentTypes.PaymentTypeID LEFT OUTER JOIN
                      tblLookupTransactionTypes ON tblCollections.TransactionTypeID = tblLookupTransactionTypes.TransactionTypeID

GO
/****** Object:  StoredProcedure [dbo].[Collection_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Collection_GetByID]

	@SystemID bigint,
	@TransactionTypeID bigint

AS

SELECT     tblCollections.CollectionID, tblCollections.SystemID, tblCollections.TransactionTypeID, tblCollections.PaymentTypeID, tblCollections.Date, 
                      tblCollections.Reference, tblCollections.Amount, tblPaymentTypes.Description, tblTransactionTypes.Description AS [Type]
FROM         tblCollections LEFT OUTER JOIN
                      tblPaymentTypes ON tblCollections.PaymentTypeID = tblPaymentTypes.PaymentTypeID LEFT OUTER JOIN
                      tblTransactionTypes ON tblCollections.TransactionTypeID = tblTransactionTypes.TransactionTypeID
WHERE     (tblCollections.SystemID = @SystemID) AND (tblCollections.TransactionTypeID = @TransactionTypeID)

GO
/****** Object:  StoredProcedure [dbo].[Collection_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Collection_Insert]

@SystemID bigint
,@TransactionTypeID bigint
,@PaymentTypeID bigint
,@Date datetime
,@Reference nvarchar(50)
,@Amount money
	

AS

INSERT INTO [dbo].[tblCollections]
           ([SystemID]
           ,[TransactionTypeID]
           ,[PaymentTypeID]
           ,[Date]
           ,[Reference]
           ,[Amount])
     VALUES
			(
			 @SystemID 
			,@TransactionTypeID 
			,@PaymentTypeID 
			,@Date 
			,@Reference 
			,@Amount )

GO
/****** Object:  StoredProcedure [dbo].[Company_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Company_GetAll]

AS

SELECT [CompanyName]
      ,[Address1]
      ,[Address2]
      ,[Telephone]
      ,[Fax]
      ,[Email]
      ,[WebURL]
      ,[RegNo]
  FROM [dbo].[tblCompany]

GO
/****** Object:  StoredProcedure [dbo].[Company_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Company_Insert]

 @CompanyName nvarchar(150)
,@Address1 nvarchar(100)
,@Address2 nvarchar(100)
,@Telephone nvarchar(50)
,@Fax nvarchar(50)
,@Email nvarchar(50)
,@WebURL nvarchar(50)
,@RegNo nvarchar(50)


AS

if (select count(CompanyName) from tblCompany)>0

	begin
	UPDATE [dbo].[tblCompany]
	   SET [CompanyName] = @CompanyName
		  ,[Address1] = @Address1
		  ,[Address2] = @Address2
		  ,[Telephone] = @Telephone
		  ,[Fax] = @Fax
		  ,[Email] = @Email
		  ,[WebURL] = @WebURL
		  ,[RegNo] = @RegNo 
	 
	end

else



INSERT INTO [dbo].[tblCompany]
           ([CompanyName]
           ,[Address1]
           ,[Address2]
           ,[Telephone]
           ,[Fax]
           ,[Email]
           ,[WebURL]
           ,[RegNo])
     VALUES
           
           ( @CompanyName 
			,@Address1 
			,@Address2 
			,@Telephone 
			,@Fax 
			,@Email 
			,@WebURL 
			,@RegNo )

GO
/****** Object:  StoredProcedure [dbo].[Customers_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_Delete]

@CustomerID bigint

AS
update [tblCustomers]
set IsDeleted =1
WHERE [CustomerID]=@CustomerID

GO
/****** Object:  StoredProcedure [dbo].[Customers_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_GetAll]

AS

SELECT     tblCustomers.CustomerID, tblCustomers.CustomerNo, tblCustomers.Salutation, tblCustomers.CustomerName, tblCustomers.AddressLine1, 
                      tblCustomers.AddressLine2, tblCustomers.AddressLine3, tblCustomers.Telephone, tblCustomers.Fax, tblCustomers.Email, tblCustomers.WebURL, 
                      tblCustomers.CreatedDate, tblCustomers.UpdatedDate, tblUserLogin_1.UserName AS CreatedBy, tblUserLogin.UserName AS UpdatedBy
FROM         tblCustomers LEFT OUTER JOIN
                      tblUserLogin ON tblCustomers.UpdatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblCustomers.CreatedBy = tblUserLogin_1.UserLoginID
where isnull(IsDeleted,0) <>1                     
order by   tblCustomers.CustomerNo DESC

GO
/****** Object:  StoredProcedure [dbo].[Customers_GetByCustomerNo]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_GetByCustomerNo]

@CustomerNo bigint

AS

SELECT [CustomerID]
      ,[CustomerNo]
	  ,[Salutation]
      ,[CustomerName]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[AddressLine3]
      ,[Telephone]
      ,[Fax]
      ,[Email]
      ,[WebURL]
,[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate]
FROM [tblCustomers]
Where [CustomerNo]=@CustomerNo

GO
/****** Object:  StoredProcedure [dbo].[Customers_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_GetByID]

@CustomerID bigint

AS

SELECT [CustomerID]
      ,[CustomerNo]
		,[Salutation]
      ,[CustomerName]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[AddressLine3]
      ,[Telephone]
      ,[Fax]
      ,[Email]
      ,[WebURL]
,[CreatedBy],[CreatedDate],[UpdatedBy],[UpdatedDate]
FROM [tblCustomers]
Where [CustomerID]=@CustomerID

GO
/****** Object:  StoredProcedure [dbo].[Customers_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_Insert]
@CustomerId bigint,
@CustomerNo bigint,
@Salutation nvarchar(5),
@CustomerName nvarchar(100),
@AddressLine1 nvarchar(100),
@AddressLine2 nvarchar(100),
@AddressLine3 nvarchar(100),
@Telephone nvarchar(50),
@Fax nvarchar(50),
@Email nvarchar(50),
@WebURL nvarchar(50),
@CreatedBy bigint,
@UpdatedBy bigint

AS
IF EXISTS
(SELECT [CustomerID] from tblCustomers WHERE [CustomerID]=@CustomerID)
BEGIN
UPDATE [tblCustomers]
   SET [CustomerNo] = @CustomerNo
		,[Salutation]=@Salutation		
      ,[CustomerName] = @CustomerName
      ,[AddressLine1] = @AddressLine1
      ,[AddressLine2] = @AddressLine2
      ,[AddressLine3] = @AddressLine3
      ,[Telephone] = @Telephone
      ,[Fax] = @Fax
      ,[Email] = @Email
      ,[WebURL] = @WebURL
	  ,[UpdatedBy] = @UpdatedBy
	  ,[UpdatedDate] = getdate()
 WHERE [CustomerID]=@CustomerID
END

ELSE
BEGIN
INSERT INTO [tblCustomers]
           ([CustomerNo]
			,[Salutation]
           ,[CustomerName]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[AddressLine3]
           ,[Telephone]
           ,[Fax]
           ,[Email]
           ,[WebURL]
		   ,[CreatedBy]
		   ,[CreatedDate])
     VALUES
           (@CustomerNo 
			,@Salutation
           ,@CustomerName 
           ,@AddressLine1 
           ,@AddressLine2 
           ,@AddressLine3 
           ,@Telephone 
           ,@Fax 
           ,@Email 
           ,@WebURL
			,@CreatedBy
			,getdate())
END

GO
/****** Object:  StoredProcedure [dbo].[Customers_IsCustomerExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Customers_IsCustomerExists]

@CustomerNo bigint,
@IsExists INT output
AS

If Exists
(Select [CustomerNo] from tblCustomers Where [CustomerNo]=@CustomerNo )

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyCropSummary_Delete] 
    @Month int,
    @Year int,
    @AbbreviationID bigint
   
   
AS 

	DELETE [dbo].[tbleDailyCropSummary]
	WHERE  [MONTH] = @Month and [Year]=@Year and [AbbreviationID]=@AbbreviationID

GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_GetByMonthYear]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyCropSummary_GetByMonthYear] 
  
  @SelecteMonth int,
  @SelectedYear int,
  @TypeID int
  
  
    
AS 
	


	SELECT [DailyCropSummaryID], [Month], [Year], [AbbreviationID], CurrentDay, [FactoryCrop], [Rate] 
	FROM   [dbo].[tbleDailyCropSummary] 
	Where [Month]=@SelecteMonth AND [Year]=@SelectedYear AND [AbbreviationID]=@TypeID
	order by CurrentDay

GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_GetByMonthYear_report]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyCropSummary_GetByMonthYear_report] 
  
  @SelecteMonth int,
  @SelectedYear int,
  @TypeID int
 
  
    
AS 
	


	--SELECT [DailyCropSummaryID], [Month], [Year], [AbbreviationID], day( CurrentDay) as CurrentDay, [FactoryCrop], [Rate] , 'Factory Weight (kg)' as [Description]
	--FROM   [dbo].[tbleDailyCropSummary] 
	--Where [Month]=@SelecteMonth AND [Year]=@SelectedYear AND [AbbreviationID]=@TypeID
	--order by CurrentDay


	select Month(WorkingDate) as [Month],Year(WorkingDate) as [Year],[AbbreviationID],day( WorkingDate) as CurrentDay, sum(Quantity) as [FactoryCrop], 'Plucking Weight (kg)' as [Description]
	from tblDailyWorking
	Where  Month(WorkingDate)=@SelecteMonth AND Year(WorkingDate)=@SelectedYear AND [AbbreviationID]=@TypeID
	group by  Month(WorkingDate),Year(WorkingDate),[AbbreviationID],day( WorkingDate)

	union all
		
	SELECT  [Month], [Year], [AbbreviationID], day( CurrentDay) as CurrentDay, [FactoryCrop], 'Factory Weight (kg)' as [Description]
	FROM   [dbo].[tbleDailyCropSummary] 
	Where [Month]=@SelecteMonth AND [Year]=@SelectedYear AND [AbbreviationID]=@TypeID
	order by CurrentDay

GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyCropSummary_Insert] 
    @Month nvarchar(50),
    @Year numeric(18, 0) ,
    @AbbreviationID bigint ,
    @CurrentDay date ,
    @FactoryCrop decimal(18, 2) ,
    @Rate decimal(18, 2)
AS 
	

	
	INSERT INTO [dbo].[tbleDailyCropSummary] ([Month], [Year], [AbbreviationID],  [FactoryCrop], [Rate],CurrentDay)
	VALUES (@Month, @Year, @AbbreviationID,  @FactoryCrop, @Rate,@CurrentDay)

GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyCropSummary_Update] 
    @DailyCropSummaryID bigint,
    @Month nvarchar(50) ,
    @Year numeric(18, 0),
    @AbbreviationID bigint ,
    @CurrentDay date ,
    @FactoryCrop decimal(18, 2),
    @Rate decimal(18, 2) 
AS 
	

	UPDATE [dbo].[tbleDailyCropSummary]
	SET    [Month] = @Month, [Year] = @Year, [AbbreviationID] = @AbbreviationID, [CurrentDay] =@CurrentDay, [FactoryCrop] = @FactoryCrop, [Rate] = @Rate
	WHERE  [DailyCropSummaryID] = @DailyCropSummaryID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_CheckEmployerID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_CheckEmployerID]

  @EmployeeID bigint,
  @WorkingDate date,
  @IsExists INT output

AS 
	  
If Exists
(
select tblDailyWorking.EmployeeID FROM tblDailyWorking 

WHERE  tblDailyWorking.EmployeeID=@EmployeeID and   convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0
)
Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_CheckWorkDays]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_CheckWorkDays]

  @EmployeeID bigint,
  @WorkingDate date
--@IsExists INT output

AS 
	  
--If Exists
--(
--select tblDailyWorking.EmployeeID FROM tblDailyWorking 

--WHERE  tblDailyWorking.EmployeeID=@EmployeeID and   convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0
--)
--Set @IsExists=1

--Else

--Set @IsExists=2

SELECT     EmployeeID, sum(WorkedDays)as WorkedDays
FROM         tblDailyWorking
WHERE  tblDailyWorking.EmployeeID=@EmployeeID and   convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0
group by EmployeeID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_Delete]

@DailyWorkingID bigint

AS



	
	UPDATE    tblStock
	SET        CurrentStockBalance = CurrentStockBalance -
              (SELECT     (Quantity) 
              FROM          tblDailyWorking D
              WHERE      (StockID = D.StockID) AND (D.DailyWorkingID = @DailyWorkingID)
              )
              
	--UPDATE [dbo].[tblDailyWorking]
	--SET IsDeleted=1
	--WHERE  [DailyWorkingID] = @DailyWorkingID
	
	Delete from [dbo].[tblDailyWorking]
	WHERE  [DailyWorkingID] = @DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetAll_ByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetAll_ByDates]

  @StartDate date,
  @EndDate date
AS 
	  


--SELECT     tblDailyWorking.DailyWorkingID, tblDailyWorking.WorkingDate, tblDailyWorking.WorkType, tblAbbreviation.AbbreviationDesc, tblDailyWorking.AbbreviationID, 
--                      tblDailyWorking.EmployeeID, tblEmployers.EmployerNo, tblDailyWorking.WorkedDays, tblDailyWorking.Quantity, tblEmployers.EmployerName
--FROM         tblEmployers RIGHT OUTER JOIN
--                      tblDailyWorking ON tblEmployers.EmployerID = tblDailyWorking.EmployeeID LEFT OUTER JOIN
--                      tblAbbreviation ON tblDailyWorking.AbbreviationID = tblAbbreviation.AbbreviationID
--WHERE     convert(date, tblDailyWorking.WorkingDate,103) >= convert(date, @StartDate,103) AND convert(date, tblDailyWorking.WorkingDate,103) <= convert(date, @EndDate,103)
    

SELECT     DW.WorkingDate, DW.WorkType, A.AbbreviationDesc, DW.EmployeeID, E.EmployerNo, DW.WorkedDays, DW.Quantity, E.EmployerName, S.StockCode, S.Description
FROM         tblStock AS S RIGHT OUTER JOIN
                      tblDailyWorking AS DW ON S.StockID = DW.StockID LEFT OUTER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID LEFT OUTER JOIN
                      tblAbbreviation AS A ON DW.AbbreviationID = A.AbbreviationID
WHERE     (CONVERT(date, DW.WorkingDate, 103) >= CONVERT(date, @StartDate, 103)) AND (CONVERT(date, DW.WorkingDate, 103) <= CONVERT(date, @EndDate, 103))
ORDER BY DW.WorkingDate

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetAllForRateUpdate]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetAllForRateUpdate]

  @StartDate date,
  @EndDate date,
  @Designation nvarchar(20)
AS 
	  

SELECT     tblDailyWorking.WorkingDate, tblDailyWorking.WorkType, tblDailyWorking.EmployeeID, tblEmployers.EmployerNo, tblEmployers.EmployerName, 
                      tblDailyWorking.DayRate, tblDailyWorking.OTRate, tblDailyWorking.KgsPerDay, tblDailyWorking.OverKgRate, tblDailyWorking.EPF, tblDailyWorking.CasualPayRate, 
                      tblDailyWorking.CasualOTPayRate, tblDailyWorking.DailyWorkingID
FROM         tblEmployers RIGHT OUTER JOIN
                      tblDailyWorking ON tblEmployers.EmployerID = tblDailyWorking.EmployeeID
                      WHERE     convert(date, tblDailyWorking.WorkingDate,103) >= convert(date, @StartDate,103) AND convert(date, tblDailyWorking.WorkingDate,103) <= convert(date, @EndDate,103) and tblDailyWorking.WorkType=@Designation
ORDER BY tblDailyWorking.WorkingDate

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetAttendance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetAttendance]
@StartDate date,
@EndDate date


AS


SELECT     tblDailyWorking.WorkingDate, tblDailyWorking.EmployeeID, tblDailyWorking.WorkedDays
FROM         tblDailyWorking 
WHERE tblDailyWorking.WorkingDate between @StartDate AND @EndDate

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetBy_Date]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetBy_Date]

  @WorkingDate date
AS 
	  




SELECT     DW.DailyWorkingID, DW.WorkingDate, DW.WorkType, A.AbbreviationDesc, DW.AbbreviationID, DW.EmployeeID, E.EmployerNo, E.EmployerName, DW.WorkedDays, DW.Quantity, 
                      E.EmployerName AS Expr1, DW.IsDeleted, S.StockCode, S.Description
FROM         tblStock AS S RIGHT OUTER JOIN
                      tblDailyWorking AS DW ON S.StockID = DW.StockID LEFT OUTER JOIN
                      tblEmployers AS E ON DW.EmployeeID = E.EmployerID LEFT OUTER JOIN
                      tblAbbreviation AS A ON DW.AbbreviationID = A.AbbreviationID
WHERE     (CONVERT(date, DW.WorkingDate, 103) = CONVERT(date, @WorkingDate, 103)) AND (DW.IsDeleted = 0)

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetByID]

	@DailyWorkingID bigint

AS 
SELECT     DailyWorkingID, WorkingDate, AbbreviationID, EmployeeID, WorkedDays, WorkType, Quantity, DayRate, OTRate, KgsPerDay, OverKgRate, WCPayRate, 
                      DevalutionRate, DevaluationDays, PayChit, EPF, CasualPayRate, CasualOTPayRate, IsDeleted, CreatedBy, CreatedDate
FROM         tblDailyWorking

WHERE DailyWorkingID=@DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_GetRubber_ByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_GetRubber_ByDates]

  @StartDate date,
  @EndDate date
AS 
	  
SELECT     tblDailyWorking.WorkingDate, tblDailyWorking.WorkType, tblAbbreviation.AbbreviationDesc, tblDailyWorking.EmployeeID, tblEmployers.EmployerNo, 
                      tblDailyWorking.WorkedDays, tblDailyWorking.Quantity, tblEmployers.EmployerName, tblDailyWorking.DailyWorkingID
FROM         tblEmployers RIGHT OUTER JOIN
                      tblDailyWorking ON tblEmployers.EmployerID = tblDailyWorking.EmployeeID LEFT OUTER JOIN
                      tblAbbreviation ON tblDailyWorking.AbbreviationID = tblAbbreviation.AbbreviationID
WHERE  tblAbbreviation.AbbreviationCode='RS' and   convert(date, tblDailyWorking.WorkingDate,103) >= convert(date, @StartDate,103) AND convert(date, tblDailyWorking.WorkingDate,103) <= convert(date, @EndDate,103)
ORDER BY tblDailyWorking.WorkingDate

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_IfExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_IfExists]

  @EmployeeID bigint,
  @WorkingDate date

AS 

SELECT     EmployeeID, sum(WorkedDays)as WorkedDays
FROM         tblDailyWorking
WHERE  tblDailyWorking.EmployeeID=@EmployeeID and   convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0
group by EmployeeID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_Insert]

	@WorkingDate date = NULL,
    @WorkType nvarchar(10) = NULL,
    @AbbreviationID bigint = NULL,
    @EmployeeID bigint = NULL,
    @WorkedDays decimal(18, 2) = NULL,
    @OTHours decimal(18, 2) = NULL,
    @Quantity decimal(18, 2) = NULL,
    @DayRate decimal(18, 2) = NULL,
    @OTRate decimal(18, 2) = NULL,
    @KgsPerDay decimal(18, 2) = NULL,
    @KgsPerDayNotMandatory decimal(18, 2) = NULL,
    @OverKgRate decimal(18, 2) = NULL,
    @LowerKgRate decimal(18, 2) = NULL,
    @WCPayRate decimal(18, 2) = NULL,
    @DevalutionRate decimal(18, 2) = NULL,
    @DevaluationDays decimal(18, 2) = NULL,
    @PayChit decimal(18, 2) = NULL,
    @EPF decimal(18, 2) = NULL,
    @CasualPayRate decimal(18, 2) = NULL,
    @CasualOTPayRate decimal(18, 2) = NULL,
    @IsDeleted bit = NULL,
    @CreatedBy bigint = NULL,
    @CreatedDate datetime = NULL,
    @StockID bigint=null,
    @ETF  decimal(18, 2) = NULL,
    @OverKGUpperLimit decimal(18,2),
    @SheetsPerDay decimal(18,2),
    @OverSheetsUpperLimit decimal(18,2),
    @OverSheetsRate decimal(18,2),
    @LowerSheetsRate decimal(18,2),
    @SmokingSheetsPayRate decimal(18,2),
    @NameDays decimal(18,2)
    

AS

INSERT INTO [dbo].[tblDailyWorking]

(			
			[WorkingDate]
           ,[WorkType]
           ,[AbbreviationID]
           ,[EmployeeID]
           ,[WorkedDays]
           ,[OTHours]
           ,[Quantity]
           ,[DayRate]
           ,[OTRate]
           ,[KgsPerDay]
           ,[KgsPerDayNotMandatory]
           ,[OverKgRate]
           ,[LowerKgRate]
           ,[WCPayRate]
           ,[DevalutionRate]
           ,[DevaluationDays]
           ,[PayChit]
           ,[EPF]
           ,[CasualPayRate]
           ,[CasualOTPayRate]
           ,[IsDeleted]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[StockID]
           ,[ETF]
           ,[OverKGUpperLimit]
           ,[SheetsPerDay]
           ,[OverSheetsUpperLimit]
           ,[OverSheetsRate]
           ,[LowerSheetsRate]
           ,[SmokingSheetsPayRate]
           ,[NameDays])

-- ([WorkingDate], [WorkType], [AbbreviationID], [EmployeeID], [WorkedDays], [OTHours], [Quantity], [DayRate], [OTRate], [KgsPerDay], [OverKgRate], [WCPayRate], [DevalutionRate], [DevaluationDays], [PayChit], [EPF], [CasualPayRate], [CasualOTPayRate], [IsDeleted], [CreatedBy], [CreatedDate],[StockID] , [KgsPerDayNotMandatory], [ETF], [OverKGUpperLimit],[SheetsPerDay],[OverSheetsUpperLimit],[OverSheetsRate],[LowerSheetsRate],[SmokingSheetsPayRate])


VALUES (
@WorkingDate, 
@WorkType, 
@AbbreviationID, 
@EmployeeID, 
@WorkedDays, 
@OTHours, 
@Quantity, 
@DayRate, 
@OTRate, 
@KgsPerDay,
@KgsPerDayNotMandatory, 
@OverKgRate, 
@LowerKgRate,
@WCPayRate, 
@DevalutionRate, 
@DevaluationDays, 
@PayChit, 
@EPF, 
@CasualPayRate, 
@CasualOTPayRate, 
@IsDeleted, 
@CreatedBy,
GETDATE(),
@StockID, 
@ETF,
@OverKGUpperLimit,
@SheetsPerDay,
@OverSheetsUpperLimit,
@OverSheetsRate,
@LowerSheetsRate,
@SmokingSheetsPayRate,
@NameDays
)
	
	
if @StockID>0
Begin

UPDATE [tblStock] 
SET  [CurrentStockBalance]	 = isnull([CurrentStockBalance],0)+ @Quantity,
       [CurrentStockValue]=isnull([CurrentStockValue],0)+(SELECT isnull([PurchasingPrice],0)*@Quantity FROM tblStock WHERE [StockID]=@StockID)
WHERE 
	( [StockID]	 = @StockID)

End

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_InsertRubber]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[DailyWorking_InsertRubber]

 @WorkingDate date = NULL,
    @WorkType nvarchar(10) = NULL,
    @AbbreviationID bigint = NULL,
    @EmployeeID bigint = NULL,
    @WorkedDays decimal(18, 2) = NULL,
    @Quantity decimal(18, 2) = NULL,
    @DayRate decimal(18, 2) = NULL,
    @OTRate decimal(18, 2) = NULL,
    @KgsPerDay decimal(18, 2) = NULL,
    @OverKgRate decimal(18, 2) = NULL,
    @WCPayRate decimal(18, 2) = NULL,
    @DevalutionRate decimal(18, 2) = NULL,
    @DevaluationDays decimal(18, 2) = NULL,
    @PayChit decimal(18, 2) = NULL,
    @EPF decimal(18, 2) = NULL,
    @CasualPayRate decimal(18, 2) = NULL,
    @CasualOTPayRate decimal(18, 2) = NULL,
    @IsDeleted bit = NULL,
    @CreatedBy bigint = NULL,
    @CreatedDate datetime = NULL

AS

INSERT INTO [dbo].[tblDailyWorking] ([WorkingDate], [WorkType], [AbbreviationID], [EmployeeID], [WorkedDays], [Quantity], [DayRate], [OTRate], [KgsPerDay], [OverKgRate], [WCPayRate], [DevalutionRate], [DevaluationDays], [PayChit], [EPF], [CasualPayRate], [CasualOTPayRate], [IsDeleted], [CreatedBy], [CreatedDate])
	VALUES (@WorkingDate, @WorkType, @AbbreviationID, @EmployeeID, @WorkedDays, @Quantity, @DayRate, @OTRate, @KgsPerDay, @OverKgRate, @WCPayRate, @DevalutionRate, @DevaluationDays, @PayChit, @EPF, @CasualPayRate, @CasualOTPayRate, @IsDeleted, @CreatedBy,GETDATE())

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DailyWorking_Update] 
    @DailyWorkingID bigint,
    @WorkingDate date = NULL,
    @WorkType nvarchar(10) = NULL,
    @AbbreviationID bigint = NULL,
    @EmployeeID bigint = NULL,
    @WorkedDays decimal(18, 2) = NULL,
    @Quantity decimal(18, 2) = NULL,
    @DayRate decimal(18, 2) = NULL,
    @OTRate decimal(18, 2) = NULL,
    @KgsPerDay decimal(18, 2) = NULL,
    @OverKgRate decimal(18, 2) = NULL,
    @EPF decimal(18, 2) = NULL,
    @CasualPayRate decimal(18, 2) = NULL,
    @CasualOTPayRate decimal(18, 2) = NULL,
    @StockID bigint=null
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[tblDailyWorking]
	SET    [WorkingDate] = @WorkingDate, [WorkType] = @WorkType, [AbbreviationID] = @AbbreviationID, [EmployeeID] = @EmployeeID, [WorkedDays] = @WorkedDays, [Quantity] = @Quantity, [DayRate] = @DayRate, [OTRate] = @OTRate, [KgsPerDay] = @KgsPerDay, [OverKgRate] = @OverKgRate, [EPF] = @EPF, [CasualPayRate] = @CasualPayRate, [CasualOTPayRate] = @CasualOTPayRate, StockID=@StockID
	WHERE  [DailyWorkingID] = @DailyWorkingID
	


	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[DailyWorking_UpdateRate]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorking_UpdateRate]
	@DailyWorkingID bigint,
	--@StartDate date,
	--@EndDate date,
	--@WorkType nvarchar(10),	
	
	@DayRate money,
	@OTRate money,
	@KgsPerDay decimal,
	@OverKgRate money,
	@CasualPayRate money,
	@CasualOTPayRate money,
	@EPF bigint
	

AS


update tblDailyWorking

set
DayRate=@DayRate,
OTRate=@OTRate,
KgsPerDay=@KgsPerDay,
OverKgRate=@OverKgRate,
CasualPayRate=@CasualPayRate,
CasualOTPayRate=@CasualOTPayRate,
EPF=@EPF

WHERE DailyWorkingID=@DailyWorkingID
--where WorkingDate between @Startdate and @enddate
--WHERE convert(date, tblDailyWorking.WorkingDate,103) >= convert(date, @StartDate,103) AND convert(date, tblDailyWorking.WorkingDate,103) <= convert(date, @EndDate,103)

--WHERE convert(date, tblDailyWorking.WorkingDate,103) between convert(date, @StartDate,103) AND convert(date, @EndDate,103)

GO
/****** Object:  StoredProcedure [dbo].[DailyWorkingDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorkingDescription_Delete]

  @DailyWorkingID bigint
AS 
	
	DELETE
	FROM   [dbo].[tblDailyWorkingDescription] 
	WHERE DailyWorkingID=@DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[DailyWorkingDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorkingDescription_Insert]

--@DailyWorkingDescriptionID bigint,
    @DailyWorkingID bigint = NULL,
    @StockID bigint = NULL,
    @ItemQuantity decimal(18, 2) = NULL   

AS

	
	INSERT INTO [dbo].[tblDailyWorkingDescription] ([DailyWorkingID], [StockID], [ItemQuantity])
	values(  @DailyWorkingID, @StockID, @ItemQuantity)

GO
/****** Object:  StoredProcedure [dbo].[DailyWorkingRubber_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorkingRubber_Insert]

@DailyWorkingID bigint=NULL,
 @WorkingDate date = NULL,
    @WorkType nvarchar(10) = NULL,
    @AbbreviationID bigint = NULL,
    @EmployeeID bigint = NULL,
    @WorkedDays decimal(18, 2) = NULL,
    @Quantity decimal(18, 2) = NULL,
    @DayRate decimal(18, 2) = NULL,
    @OTRate decimal(18, 2) = NULL,
    @KgsPerDay decimal(18, 2) = NULL,
    @OverKgRate decimal(18, 2) = NULL,
    @WCPayRate decimal(18, 2) = NULL,
    @DevalutionRate decimal(18, 2) = NULL,
    @DevaluationDays decimal(18, 2) = NULL,
    @PayChit decimal(18, 2) = NULL,
    @EPF decimal(18, 2) = NULL,
    @CasualPayRate decimal(18, 2) = NULL,
    @CasualOTPayRate decimal(18, 2) = NULL,
    @IsDeleted bit = NULL,
    @CreatedBy bigint = NULL,
    @CreatedDate datetime = NULL,
    @CurrentDailyWorkingID bigint output

AS


IF EXISTS

		(SELECT [DailyWorkingID] from tblDailyWorking Where [DailyWorkingID]=@DailyWorkingID)

BEGIN
	UPDATE [dbo].[tblDailyWorking]
	SET    [WorkingDate] = @WorkingDate, [WorkType] = @WorkType, [AbbreviationID] = @AbbreviationID, [EmployeeID] = @EmployeeID, [WorkedDays] = @WorkedDays, [Quantity] = @Quantity, [DayRate] = @DayRate, [OTRate] = @OTRate, [KgsPerDay] = @KgsPerDay, [OverKgRate] = @OverKgRate, [WCPayRate] = @WCPayRate, [DevalutionRate] = @DevalutionRate, [DevaluationDays] = @DevaluationDays, [PayChit] = @PayChit, [EPF] = @EPF, [CasualPayRate] = @CasualPayRate, [CasualOTPayRate] = @CasualOTPayRate, [IsDeleted] = @IsDeleted, [CreatedBy] = @CreatedBy, [CreatedDate] = @CreatedDate
	WHERE  [DailyWorkingID] = @DailyWorkingID
	
set @CurrentDailyWorkingID=-1

		END

ELSE

Begin
		

INSERT INTO [dbo].[tblDailyWorking] ([WorkingDate], [WorkType], [AbbreviationID], [EmployeeID], [WorkedDays], [Quantity], [DayRate], [OTRate], [KgsPerDay], [OverKgRate], [WCPayRate], [DevalutionRate], [DevaluationDays], [PayChit], [EPF], [CasualPayRate], [CasualOTPayRate], [IsDeleted], [CreatedBy], [CreatedDate])
	VALUES (@WorkingDate, @WorkType, @AbbreviationID, @EmployeeID, @WorkedDays, @Quantity, @DayRate, @OTRate, @KgsPerDay, @OverKgRate, @WCPayRate, @DevalutionRate, @DevaluationDays, @PayChit, @EPF, @CasualPayRate, @CasualOTPayRate, @IsDeleted, @CreatedBy,GETDATE())
	
	
set @CurrentDailyWorkingID=SCOPE_IDENTITY()
End

GO
/****** Object:  StoredProcedure [dbo].[DailyWorkingRubberSheets_GetBy_ID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DailyWorkingRubberSheets_GetBy_ID]

  @DailyWorkingID bigint
AS 
	SELECT     tblDailyWorking.IsDeleted, tblDailyWorkingDescription.DailyWorkingDescriptionID, tblEmployers.EmployerNo, tblEmployers.EmployerName, 
                      tblDailyWorkingDescription.StockID, tblStock.Description, tblDailyWorkingDescription.ItemQuantity, tblDailyWorking.WorkingDate, 
                      tblDailyWorkingDescription.DailyWorkingID
FROM         tblEmployers RIGHT OUTER JOIN
                      tblDailyWorking RIGHT OUTER JOIN
                      tblDailyWorkingDescription ON tblDailyWorking.DailyWorkingID = tblDailyWorkingDescription.DailyWorkingID LEFT OUTER JOIN
                      tblStock ON tblDailyWorkingDescription.StockID = tblStock.StockID ON tblEmployers.EmployerID = tblDailyWorking.EmployeeID
                      
                      --WHERE     convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0
                       WHERE    tblDailyWorkingDescription.DailyWorkingID=@DailyWorkingID  AND tblDailyWorking.isdeleted=0

GO
/****** Object:  StoredProcedure [dbo].[delllll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[delllll]

@IssueDate DATE

AS



--DECLARE @IssueDate DATE
--SET @IssueDate=  '2014-03-01'

--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex VARCHAR(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT'],[' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
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

INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,DaysPay,OverKgsPay,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
(SELECT  TDW.EmployeeID, 
ISNULL(SUM(TDW.WorkedDays),0) AS TotalDays,
ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'P' THEN  TDW.Quantity  END)),0) AS PluckingKgs,
ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'T' THEN TDW.Quantity  END)),0) AS TappingL,

--ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) ELSE 0 END),0) AS OverKgs,
ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,


ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0) AS DaysPay,

--ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,
ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,


--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,
ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,


--ISNULL((SELECT SUM(TD.TDAmount) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--AND  ISNULL(TD.IsDeleted,0) <>1 
--GROUP BY TD.EmployerID

--),0) AS FestivalAdvance,

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,

ISNULL((
	SELECT SUM(CA.AdvanceAmount) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	GROUP BY CA.EmployerId
),0) AS CashAdvance,

ISNULL(

		(
	
						(isnull((
						SELECT ISNULL( SUM(FR.AdvanceAmount),0) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
						and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate
						group by FR.EmployerId),0)
						)

						+
						(isnull((
						SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
						AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
						GROUP BY CA.EmployerId),0)
						)

		)

,0) AS TotalDeductions,

ISNULL((

--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0)-
ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0)-
	
	ISNULL((

	(
		(isnull((
						SELECT ISNULL( SUM(FR.AdvanceAmount),0) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
						and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate
						group by FR.EmployerId),0)
						)
	)+
	(
	isnull((
	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
	GROUP BY CA.EmployerId),0)
	)

),0)

),0) AS BalancePay


FROM    tblDailyWorking TDW
INNER JOIN tblAbbreviation ABC ON TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
GROUP BY TDW.EmployeeID)


SELECT *  FROM #CalculatedList

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


---------------------------------------------------------------------

--USE [Estate]
--GO
--/****** Object:  StoredProcedure [dbo].[ReportMonthlySubCasual]    Script Date: 19/Jul/2016 10:35:16 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[ReportMonthlySubCasual]

--@IssueDate DATE

--AS



----DECLARE @IssueDate DATE
----SET @IssueDate=  '2014-03-01'

----Gettin last date of the month
--DECLARE @maxDate DATE
--SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

----Creating date from 1st of month to end of month
--DECLARE @DateList TABLE
--(
--	DateOfMonth DATE
--)

--;WITH [tmpData] AS (
--  SELECT CAST(@IssueDate AS DATE) AS dt
--  UNION ALL
--  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
--  INSERT INTO @DateList (DateOfMonth)
--  SELECT * FROM [tmpData]


--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--CREATE TABLE #CodeAggregatedList 
--(
--	EmployeeID BIGINT,
--	EmployeeNo INT,
--	EmployeeName VARCHAR(200),
--	Sex VARCHAR(20),
--	WorkingDate DATE,
--	AbbreviatedCode VARCHAR(1000)
--)

----Comma seperating abbreviation code
--INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
--SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

--(SELECT   STUFF(( SELECT  DISTINCT'],[' + [AbbreviationCode] FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
--) AS M

--WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]
--FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
--)
--AS S
--GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


----Creating dynamic pivot date list string 
--DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
--DECLARE @ColumnName AS VARCHAR(MAX)
 
--SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
--       + QUOTENAME(DateOfMonth)
--FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

----Calculate the month summary
--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

--CREATE TABLE #CalculatedList 
--(
--	EmployeeID BIGINT,
--	TotalDays DECIMAL(18,2),	
--	PluckingKgs DECIMAL(18,2),
--	TappingL DECIMAL(18,2),
--	OverKgs DECIMAL(18,2),
--	DaysPay DECIMAL(18,2),
--	OverKgsPay DECIMAL(18,2),		
--	GrandTotalPay DECIMAL(18,2),	
--	FestivalAdvance DECIMAL(18,2),
--	CashAdvance DECIMAL(18,2),
--	TotalDeductions DECIMAL(18,2),
--	BalancePay DECIMAL(18,2)
	
	
--)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,DaysPay,OverKgsPay,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
--(SELECT  TDW.EmployeeID, 
--ISNULL(SUM(TDW.WorkedDays),0) AS TotalDays,
--ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'P' THEN  TDW.Quantity  END)),0) AS PluckingKgs,
--ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'T' THEN TDW.Quantity  END)),0) AS TappingL,

----ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) ELSE 0 END),0) AS OverKgs,
--ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,


--ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0) AS DaysPay,

----ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,
--ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,


----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,
--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,


--ISNULL((SELECT SUM(TD.TDAmount) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--AND  ISNULL(TD.IsDeleted,0) <>1 
--GROUP BY TD.EmployerID

--),0) AS FestivalAdvance,

--ISNULL((
--	SELECT SUM(CA.AdvanceAmount) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	GROUP BY CA.EmployerId
--),0) AS CashAdvance,

--ISNULL((
	
--	(
--	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--	AND  ISNULL(TD.IsDeleted,0) <>1 
--	GROUP BY TD.EmployerID
--	)+
--	(
--	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	GROUP BY CA.EmployerId
--	)

--),0) AS TotalDeductions,

--ISNULL((

----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0)-
--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0)-
	
--	ISNULL((

--	(
--	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--	AND  ISNULL(TD.IsDeleted,0) <>1 
--	GROUP BY TD.EmployerID
--	)+
--	(
--	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	GROUP BY CA.EmployerId
--	)

--),0)

--),0) AS BalancePay


--FROM    tblDailyWorking TDW
--INNER JOIN tblAbbreviation ABC ON TDW.AbbreviationID=abc.AbbreviationID

--WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
--AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
--GROUP BY TDW.EmployeeID)


--SELECT *  FROM #CalculatedList

--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

GO
/****** Object:  StoredProcedure [dbo].[Employee_CalculateAdvance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_CalculateAdvance]

@EmployeeID bigint,
@IssueDate date

AS

--select * from dbo.tblDailyWorking where EmployeeID=2 AND WorkType='PERMENANT'


--declare @IssueDate date
--declare @EmployeeID bigint
--set @IssueDate='08-30-2014'
--set @EmployeeID=2


declare @startDate date
set @startDate=CONVERT(date,('1-'+ CONVERT(varchar(10), MONTH(@IssueDate))+'-'+CONVERT(varchar(10), YEAR(@IssueDate))),103)
select @startDate
 

--select SUM(WorkedDays) as CWorkedDays, sum(WorkedDays*ISNULL(CasualPayRate ,0))as CAmount, 'CASUAL' as [Type]

--from  dbo.tblDailyWorking DW
--where DW.EmployeeID=@EmployeeID AND
--CONVERT(date, DW.WorkingDate,103)>=CONVERT(date, @startDate,103) and
--convert(date, DW.WorkingDate, 103) <= CONVERT(date, @IssueDate, 103) and 
--Dw.WorkType='CASUAL'

select SUM(WorkedDays) as PWorkedDays, sum(WorkedDays*ISNULL(DayRate ,0))as PAmount,
sum((WorkedDays*ISNULL(DayRate ,0))*0.08)as EPF, 'PERMENANT' as [Type]


from  dbo.tblDailyWorking DW
where DW.EmployeeID=@EmployeeID AND
CONVERT(date, DW.WorkingDate,103)>=CONVERT(date, @startDate,103) and
convert(date, DW.WorkingDate, 103) <= CONVERT(date, @IssueDate, 103) and 
Dw.WorkType='PERMENANT'

SELECT     TDD.TDInsAmount as FestivalAdvance, TDD.ActiveDate, TD.EmployerID, TD.TDType
FROM       tblTermDeductions AS TD INNER JOIN
           tblTermDeductionDescription AS TDD ON TD.TermDeductionID = TDD.TermDeductionID
where TD.TDType='FESTIVAL' AND TDD.ActiveDate=@startDate AND
TD.EmployerID=@EmployeeID


SELECT     TDD.TDInsAmount as Loan, TDD.ActiveDate, TD.EmployerID, TD.TDType
FROM       tblTermDeductions AS TD INNER JOIN
           tblTermDeductionDescription AS TDD ON TD.TermDeductionID = TDD.TermDeductionID
where TD.TDType='LOAN' AND TDD.ActiveDate=@startDate AND
TD.EmployerID=@EmployeeID


SELECT     EmployerId, sum( AdvanceAmount)as  AdvanceAmount
FROM         tblCashAdvance CA
where CA.EmployerId=@EmployeeID AND
CONVERT(date, CA.IssueDate,103)>=CONVERT(date, @startDate,103) and
convert(date, CA.IssueDate, 103) <= CONVERT(date, @IssueDate, 103)
group by EmployerId

SELECT     EmployerID, LmbValue, EffectDate
FROM         tblLMB LB
where LB.EmployerID=@EmployeeID AND
CONVERT(date, LB.EffectDate,103)>=CONVERT(date, @startDate,103)

GO
/****** Object:  StoredProcedure [dbo].[Employee_GetAll_Workers]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_GetAll_Workers]
@Designation varchar(50)
AS


SELECT     EmployerID, EmployerNo, EmployerName, Designation
FROM         tblEmployers

where Designation=@Designation



SELECT     EmployerID, (convert(varchar(20),EmployerNo) + '  -  ' + EmployerName) as EmployerNo , Designation
FROM         tblEmployers

where Department=@Designation


GO
/****** Object:  StoredProcedure [dbo].[Employers_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_DeleteRow
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for deleting a specific row from tblEmployers table
-- ==========================================================================================
Create Procedure [dbo].[Employers_Delete]
	@EmployerID bigint
As
Begin
	Delete tblEmployers
	Where
		[EmployerID] = @EmployerID

End

GO
/****** Object:  StoredProcedure [dbo].[Employers_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectAll
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting all rows from tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_GetAll]
As
Begin
	SELECT     tblEmployers.EmployerID, tblEmployers.EmployerNo, tblEmployers.EmployerName, tblEmployers.EmployerImage, tblEmployers.AddressLine1, 
                      tblEmployers.AddressLine2, tblEmployers.AddressLine3, tblEmployers.DateOfBirth, tblEmployers.DateJoined, tblEmployers.Sex, tblEmployers.NICNo, 
                      tblEmployers.TelephoneNo, tblEmployers.Designation, tblEmployers.Department, tblEmployers.EmergencyContactPerson, tblEmployers.BasicSalary, 
                      tblEmployers.OTRate, tblEmployers.FixedAllowance, tblEmployers.OtherAllowance, tblEmployers.Deductions, tblEmployers.EPFNo, 
                      tblEmployers.CreatedDate, tblEmployers.UpdatedDate, tblUserLogin.UserName AS CreatedBy, tblUserLogin_1.UserName AS UpdatedBy
FROM         tblEmployers LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblEmployers.UpdatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblUserLogin ON tblEmployers.CreatedBy = tblUserLogin.UserLoginID
Order By EmployerNo DESC
End

GO
/****** Object:  StoredProcedure [dbo].[Employers_GetByByDesignation]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectRow
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting a specific row from tblEmployers table
-- ==========================================================================================
create Procedure [dbo].[Employers_GetByByDesignation]
	@Designation nvarchar(50)
As
Begin
	Select 
		[EmployerID],
		[EmployerNo],
		[EmployerName],
		[EmployerImage],
		[AddressLine1],
		[AddressLine2],
		[AddressLine3],
		[DateOfBirth],
		[DateJoined],
		[Sex],
		[NICNo],
		[TelephoneNo],
		[Designation],
		[Department],
		[EmergencyContactPerson],
		[BasicSalary],
		[OTRate],
		[FixedAllowance],
		[OtherAllowance],
		[Deductions],
		[EPFNo],
		[CreatedBy],
		[CreatedDate],
		[UpdatedBy],
		[UpdatedDate]
	From tblEmployers
	Where
		[Designation]= @Designation
End

GO
/****** Object:  StoredProcedure [dbo].[Employers_GetByEmployerNo]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectRow
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting a specific row from tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_GetByEmployerNo]
	@EmployerNo bigint
As
Begin
	Select 
		[EmployerID],
		[EmployerNo],
		[EmployerName],
		[EmployerImage],
		[AddressLine1],
		[AddressLine2],
		[AddressLine3],
		[DateOfBirth],
		[DateJoined],
		[Sex],
		[NICNo],
		[TelephoneNo],
		[Designation],
		[Department],
		[EmergencyContactPerson],
		[BasicSalary],
		[OTRate],
		[FixedAllowance],
		[OtherAllowance],
		[Deductions],
		[EPFNo],
		[CreatedBy],
		[CreatedDate],
		[UpdatedBy],
		[UpdatedDate]
	From tblEmployers
	Where
		[EmployerNo] = @EmployerNo
End

GO
/****** Object:  StoredProcedure [dbo].[Employers_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectRow
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting a specific row from tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_GetByID]
	@EmployerID bigint
As
Begin
	Select 
		[EmployerID],
		[EmployerNo],
		[EmployerName],
		[EmployerImage],
		[AddressLine1],
		[AddressLine2],
		[AddressLine3],
		[DateOfBirth],
		[DateJoined],
		[Sex],
		[NICNo],
		[TelephoneNo],
		[Designation],
		[Department],
		[EmergencyContactPerson],
		[BasicSalary],
		[OTRate],
		[FixedAllowance],
		[OtherAllowance],
		[Deductions],
		[EPFNo],
		[IsResigned],
		[ResignDate],
		[CreatedBy],
		[CreatedDate],
		[UpdatedBy],
		[UpdatedDate]
	From tblEmployers
	Where
		[EmployerID] = @EmployerID
End

GO
/****** Object:  StoredProcedure [dbo].[Employers_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_Insert
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for inserting values to tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_Insert]
	@EmployerID bigint,
	@EmployerNo bigint,
	@EmployerName nvarchar(100),
	@EmployerImage image,
	@AddressLine1 nvarchar(100),
	@AddressLine2 nvarchar(100),
	@AddressLine3 nvarchar(100),
	@DateOfBirth datetime,
	@DateJoined datetime,
	@Sex nvarchar(5),
	@NICNo nvarchar(20),
	@TelephoneNo nvarchar(50),
	@Designation nvarchar(50),
	@Department nvarchar(50),
	@EmergencyContactPerson nvarchar(100),
	@BasicSalary decimal (18,2),
	@OTRate decimal (18,2),
	@FixedAllowance decimal (18,2),
	@OtherAllowance decimal (18,2),
	@Deductions decimal (18,2),
	@EPFNo nvarchar(50),
	@IsResigned bit,
	@ResignDate date,
	@CreatedBy bigint,
	@UpdatedBy bigint
	
As

if exists

(Select [EmployerID] From tblEmployers Where [EmployerID]=@EmployerID)

	begin
Update tblEmployers
	Set
		[EmployerNo] = @EmployerNo,
		[EmployerName] = @EmployerName,
		[EmployerImage] = @EmployerImage,
		[AddressLine1] = @AddressLine1,
		[AddressLine2] = @AddressLine2,
		[AddressLine3] = @AddressLine3,
		[DateOfBirth] = @DateOfBirth,
		[DateJoined] = @DateJoined,
		[Sex] = @Sex,
		[NICNo] = @NICNo,
		[TelephoneNo] = @TelephoneNo,
		[Designation] = @Designation,
		[Department]=@Department,
		[EmergencyContactPerson] = @EmergencyContactPerson,
		[BasicSalary] = @BasicSalary,
		[OTRate] = @OTRate,
		[FixedAllowance] = @FixedAllowance,
		[OtherAllowance] = @OtherAllowance,
		[Deductions] = @Deductions,
		[EPFNo] = @EPFNo,
		[IsResigned]=@IsResigned,
		[ResignDate]=@ResignDate,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] =getdate()
	Where		
		[EmployerID] = @EmployerID

	end

else



Begin
	Insert Into tblEmployers
		([EmployerNo],[EmployerName],[EmployerImage],[AddressLine1],[AddressLine2],[AddressLine3],[DateOfBirth],[DateJoined],[Sex],[NICNo],[TelephoneNo],[Designation],[Department],[EmergencyContactPerson],[BasicSalary],[OTRate],[FixedAllowance],[OtherAllowance],[Deductions],[EPFNo],[CreatedBy],[CreatedDate])
	Values
		(@EmployerNo,@EmployerName,@EmployerImage,@AddressLine1,@AddressLine2,@AddressLine3,@DateOfBirth,@DateJoined,@Sex,@NICNo,@TelephoneNo,@Designation,@Department,@EmergencyContactPerson,@BasicSalary,@OTRate,@FixedAllowance,@OtherAllowance,@Deductions,@EPFNo,@CreatedBy,getdate())

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID

End

GO
/****** Object:  StoredProcedure [dbo].[Employers_IsEmployerExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employers_IsEmployerExists]

@EmployerNo bigint,
@Designation varchar(50),
@IsExists INT output
AS

If Exists
(Select [EmployerNo] from tblEmployers Where [EmployerNo]=@EmployerNo and Designation=@Designation)

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[Employers_Resigned_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectAll
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting all rows from tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_Resigned_GetAll]
As
Begin
	SELECT     tblEmployers.EmployerID, tblEmployers.EmployerNo, tblEmployers.EmployerName, tblEmployers.EmployerImage, tblEmployers.AddressLine1, 
                      tblEmployers.AddressLine2, tblEmployers.AddressLine3, tblEmployers.DateOfBirth, tblEmployers.ResignDate as DateJoined, tblEmployers.Sex, tblEmployers.NICNo, 
                      tblEmployers.TelephoneNo, tblEmployers.Designation, tblEmployers.Department, tblEmployers.EmergencyContactPerson, tblEmployers.BasicSalary, 
                      tblEmployers.OTRate, tblEmployers.FixedAllowance, tblEmployers.OtherAllowance, tblEmployers.Deductions, tblEmployers.EPFNo, 
                      tblEmployers.CreatedDate, tblEmployers.UpdatedDate, tblUserLogin.UserName AS CreatedBy, tblUserLogin_1.UserName AS UpdatedBy
FROM         tblEmployers LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblEmployers.UpdatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblUserLogin ON tblEmployers.CreatedBy = tblUserLogin.UserLoginID

where [IsResigned]=1
Order By EmployerNo DESC
End

GO
/****** Object:  StoredProcedure [dbo].[Employers_Working_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_SelectAll
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for selecting all rows from tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[Employers_Working_GetAll]
As
Begin
	SELECT     tblEmployers.EmployerID, tblEmployers.EmployerNo, tblEmployers.EmployerName, tblEmployers.EmployerImage, tblEmployers.AddressLine1, 
                      tblEmployers.AddressLine2, tblEmployers.AddressLine3, tblEmployers.DateOfBirth, tblEmployers.ResignDate as DateJoined, tblEmployers.Sex, tblEmployers.NICNo, 
                      tblEmployers.TelephoneNo, tblEmployers.Designation, tblEmployers.Department, tblEmployers.EmergencyContactPerson, tblEmployers.BasicSalary, 
                      tblEmployers.OTRate, tblEmployers.FixedAllowance, tblEmployers.OtherAllowance, tblEmployers.Deductions, tblEmployers.EPFNo, 
                      tblEmployers.CreatedDate, tblEmployers.UpdatedDate, tblUserLogin.UserName AS CreatedBy, tblUserLogin_1.UserName AS UpdatedBy
FROM         tblEmployers LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblEmployers.UpdatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblUserLogin ON tblEmployers.CreatedBy = tblUserLogin.UserLoginID

where [IsResigned]=0
Order By EmployerNo DESC
End

GO
/****** Object:  StoredProcedure [dbo].[Expense_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expense_GetByID]

@ExpenseID bigint

AS

SELECT        tblExpenses.ExpenseID, tblExpenses.ExpenseTypeID, tblExpenses.PaymentTypeID, tblExpenses.ExpenseDate, tblExpenses.Amount, tblExpenses.Note, tblExpenseTypes.Description AS ExpenseType, 
                         tblPaymentTypes.Description AS PaymentType, tblExpenses.CreatedBy, tblExpenses.CreatedDate, tblExpenses.UpdatedBy, tblExpenses.UpdatedDate, tblExpenses.Remarks
FROM            tblExpenses LEFT OUTER JOIN
                         tblExpenseTypes ON tblExpenses.ExpenseTypeID = tblExpenseTypes.ExpenseTypeID LEFT OUTER JOIN
                         tblPaymentTypes ON tblExpenses.PaymentTypeID = tblPaymentTypes.PaymentTypeID
Where [ExpenseID]=@ExpenseID

GO
/****** Object:  StoredProcedure [dbo].[Expenses_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expenses_Delete]

@ExpenseID bigint

AS

DELETE FROM [tblExpenses]
      WHERE [ExpenseID]=@ExpenseID

DELETE FROM tblCollections
	WHERE [SystemID]=@ExpenseID AND TransactionTypeID=3

GO
/****** Object:  StoredProcedure [dbo].[Expenses_GetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expenses_GetByDates]

@FromDate datetime,
@ToDate datetime

AS

SELECT        tblExpenses.ExpenseID, tblExpenses.ExpenseTypeID, tblExpenses.PaymentTypeID, tblExpenses.ExpenseDate, tblExpenses.Amount, tblExpenses.Note, tblExpenseTypes.Description AS ExpenseType, 
                         tblPaymentTypes.Description AS PaymentType, tblExpenses.CreatedDate, tblExpenses.UpdatedDate, tblUserLogin_1.UserName AS CreatedBy, tblUserLogin.UserName AS UpdatedBy, 
                         tblExpenses.Remarks
FROM            tblPaymentTypes RIGHT OUTER JOIN
                         tblExpenses LEFT OUTER JOIN
                         tblUserLogin ON tblExpenses.UpdatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
                         tblUserLogin AS tblUserLogin_1 ON tblExpenses.CreatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                         tblExpenseTypes ON tblExpenses.ExpenseTypeID = tblExpenseTypes.ExpenseTypeID ON tblPaymentTypes.PaymentTypeID = tblExpenses.PaymentTypeID
WHERE (tblExpenses.ExpenseDate>= @FromDate AND tblExpenses.ExpenseDate<=@ToDate)
Order By tblExpenses.ExpenseID DESC

GO
/****** Object:  StoredProcedure [dbo].[Expenses_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Expenses_Insert]

 @ExpenseID bigint
,@ExpenseTypeID bigint
,@PaymentTypeID bigint
,@ExpenseDate datetime
,@Amount money
,@Note nvarchar(100)
,@Remarks ntext
,@CurrentExpenseID bigint output
,@CreatedBy bigint
,@UpdatedBy bigint
AS


IF exists
(Select [ExpenseID] from tblExpenses  Where [ExpenseID]=@ExpenseID)
	
	begin
		UPDATE [tblExpenses]
		SET [ExpenseTypeID] = @ExpenseTypeID
		   ,[PaymentTypeID]=@PaymentTypeID	
		   ,[ExpenseDate] = @ExpenseDate
		   ,[Amount] =@Amount
		   ,[Note] = @Note
		   ,[Remarks]=@Remarks
			
			,[UpdatedBy]=@UpdatedBy
			,[UpdatedDate]=getdate()
		WHERE [ExpenseID]=@ExpenseID
		set @CurrentExpenseID=-1
	end


else

BEGIN
INSERT INTO [tblExpenses]
           ([ExpenseTypeID]
			,[PaymentTypeID]
           ,[ExpenseDate]
           ,[Amount]
           ,[Note]
		   ,[Remarks]
			,[CreatedBy]
			,[CreatedDate])
     VALUES
           (@ExpenseTypeID
			,@PaymentTypeID
           ,@ExpenseDate
           ,@Amount
           ,@Note
		   ,@Remarks
			,@CreatedBy
			,getdate())


set @CurrentExpenseID=scope_identity()
END

GO
/****** Object:  StoredProcedure [dbo].[ExpenseTypes_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExpenseTypes_Delete]

@Description nvarchar(50)

AS

DELETE FROM [dbo].[tblExpenseTypes]
      WHERE [Description]=@Description

GO
/****** Object:  StoredProcedure [dbo].[ExpenseTypes_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExpenseTypes_GetAll]



AS

SELECT [ExpenseTypeID]
      ,[Description]
  FROM [dbo].[tblExpenseTypes]

GO
/****** Object:  StoredProcedure [dbo].[ExpenseTypes_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExpenseTypes_Insert]

@Description nvarchar(50)
AS

if exists
(Select [Description] from tblExpenseTypes Where [Description]=@Description)

begin
UPDATE [dbo].[tblExpenseTypes]
   SET [Description] = @Description
 WHERE [Description]=@Description
end

else


INSERT INTO [dbo].[tblExpenseTypes]
           ([Description])
     VALUES
           
		(@Description)

GO
/****** Object:  StoredProcedure [dbo].[FestivalAdvance_By_Year]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FestivalAdvance_By_Year]

@Year int
AS

SELECT        EmployerID, TDDate, (cast(EmployerID as nvarchar(10)) +' - ' +TDdescription) as TDdescription , TermDeductionID
FROM            tblTermDeductions
where year(TDDate)=@Year
GO
/****** Object:  StoredProcedure [dbo].[Festivaladvance_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Festivaladvance_GetAll]

AS

SELECT        T.TermDeductionID, T.EmployerID, 

CAST(E.EmployerNo as nvarchar(20)) + ' - ' + E.EmployerName as TDdescription,

TDdescription AS Remarks

FROM            tblTermDeductions AS T INNER JOIN
                         tblEmployers AS E ON T.EmployerID = E.EmployerID


--(CAST(EmployerID as nvarchar(20)) +' - ' + TDdescription )AS Description
GO
/****** Object:  StoredProcedure [dbo].[FestivalRecovery_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FestivalRecovery_Delete]

@FestivalRecoveryId bigint

AS


	
	Delete from dbo.tblFestivalRecovery
	WHERE  [FestivalRecoveryId] = @FestivalRecoveryId

GO
/****** Object:  StoredProcedure [dbo].[FestivalRecovery_GetAll_ByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FestivalRecovery_GetAll_ByDates]

  @StartDate date,
  @EndDate date

AS

SELECT  tblEmployers.EmployerNo, tblEmployers.EmployerName, tblFestivalRecovery.FestivalRecoveryId, tblFestivalRecovery.EmployerId, tblFestivalRecovery.IssueDate, 
                      tblFestivalRecovery.AdvanceAmount, tblFestivalRecovery.CreatedBy, tblFestivalRecovery.CreatedDate, tblFestivalRecovery.UpdatedBy, 
                      tblFestivalRecovery.UpdatedDate, tblUserLogin_1.UserName AS CreatedUser, tblUserLogin.UserName AS UpdatedUser, tblTermDeductions.TDdescription
FROM         tblTermDeductions RIGHT OUTER JOIN
                      tblFestivalRecovery ON tblTermDeductions.TermDeductionID = tblFestivalRecovery.TermDeductionID RIGHT OUTER JOIN
                      tblUserLogin ON tblFestivalRecovery.UpdatedBy = tblUserLogin.UserLoginID RIGHT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblFestivalRecovery.CreatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblEmployers ON tblFestivalRecovery.EmployerId = tblEmployers.EmployerID
                      
                      WHERE     convert(date, tblFestivalRecovery.IssueDate ,103) >= convert(date, @StartDate,103) AND convert(date, tblFestivalRecovery.IssueDate,103) <= convert(date, @EndDate,103)
ORDER BY tblFestivalRecovery.IssueDate

GO
/****** Object:  StoredProcedure [dbo].[FestivalRecovery_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FestivalRecovery_Insert]

@EmployerId bigint,
    @IssueDate datetime,
    @AdvanceAmount decimal(18, 2),
    @CreatedBy bigint,
    @UpdatedBy bigint = NULL,
    @TermDeductionID bigint
   

AS

INSERT INTO [dbo].[tblFestivalRecovery] ([EmployerId], [IssueDate], [AdvanceAmount], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate],[TermDeductionID])
	VALUES (@EmployerId, @IssueDate, @AdvanceAmount, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE(),@TermDeductionID)


GO
/****** Object:  StoredProcedure [dbo].[FieldPerformance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FieldPerformance]
@IssueDate DATE
as


--DECLARE @IssueDate DATE
--SET @IssueDate=  '2016-01-01'

declare @ea decimal
		 

--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName

FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName  FROM tblDailyWorking DW1 
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND 
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	--WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	--DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName


--select * from #CodeAggregatedList

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

--DROP TABLE #CalculatedList 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
declare @TWD as int

set @TWD=(
SELECT         tblWorkDaysDescription.WorkDays
FROM            tblWorkDays INNER JOIN
                         tblWorkDaysDescription ON tblWorkDays.WorkDayID = tblWorkDaysDescription.WorkDayID

where tblWorkDays.YearName = year(@IssueDate) and tblWorkDaysDescription.MonthName=datename(month,@IssueDate)
)


CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	PLD decimal(18,2),
	PLQ decimal(18,2),
	TPD decimal(18,2),
	TPQ decimal(18,2),
	SRS decimal(18,2),
	SRQ decimal(18,2),
	WSU decimal (18,2),
	SPD decimal (18,2),
	SCD decimal (18,2),
	AVGD decimal (18,2)
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,PLD,PLQ,TPD,TPQ,SRS,SRQ,WSU,SPD,SCD,AVGD)
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.WorkedDays  end)),0) as PLD,
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PLQ,

isnull(SUM((case abc.AbbreviationCode when 'T' then  TDW.WorkedDays  end)),0) as TPD,
isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TPQ, 

isnull(SUM((case abc.AbbreviationCode when 'RS' then  TDW.WorkedDays  end)),0) as SRS,
isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SRQ, 


(
(isnull(SUM((case abc.AbbreviationCode when 'W' then  TDW.WorkedDays  end)),0))
+
(isnull(SUM((case abc.AbbreviationCode when 'SU' then  TDW.WorkedDays  end)),0))  
) as WSU,


isnull(SUM((case abc.AbbreviationCode when 'SP' then  TDW.WorkedDays  end)),0) as SPD,

isnull(SUM((case abc.AbbreviationCode when 'SC' then  TDW.WorkedDays  end)),0) as SCD,



((isnull(SUM(TDW.WorkedDays),0))/(@TWD))*100 AS AVGD



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0)<>1 and TDW.AbbreviationID not in (21,34)
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.PLD,
						 XYZ.PLQ,
						 XYZ.TPD,
						 XYZ.TPQ, 
						 XYZ.SRS, 
						 XYZ.SRQ,
						 XYZ.WSU,
						 XYZ.SPD,
						 XYZ.SCD,
						 XYZ.AVGD
  
						 FROM #CodeAggregatedList  AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

GO
/****** Object:  StoredProcedure [dbo].[Get_SelectedMonth_WorkDays]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Get_SelectedMonth_WorkDays]

 @MonthName nvarchar(50)
,@YearName nvarchar(50)
	

AS



SELECT * FROM tblWorkDaysDescription

WHERE MonthName=@MonthName AND
 
WorkDayID=(SELECT WorkDayID FROM tblWorkDays WHERE YearName=@YearName)

GO
/****** Object:  StoredProcedure [dbo].[GetRubberLtrsByDate]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRubberLtrsByDate]

  @WorkingDate date
AS 
	  




SELECT     sum(tblDailyWorking.Quantity)as RubberLtrs 
FROM tblDailyWorking
WHERE    tblDailyWorking.AbbreviationID=8 and convert(date, tblDailyWorking.WorkingDate,103) = convert(date, @WorkingDate,103) AND tblDailyWorking.isdeleted=0

GO
/****** Object:  StoredProcedure [dbo].[GetStaffPayByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_Insert
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for inserting values to tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[GetStaffPayByID]
	@StaffPayID bigint
As

SELECT     StaffPayID, EmployerID, PayDate, Amount,Department
FROM         tblStaffPay AS S

where StaffPayID=@StaffPayID
GO
/****** Object:  StoredProcedure [dbo].[Holyday_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Holyday_Delete]


@HolydayID  bigint

	

AS

delete  from tblHolyday where HolydayID=@HolydayID
GO
/****** Object:  StoredProcedure [dbo].[Holyday_Get_All]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Holyday_Get_All]


@YearName  nvarchar(50),
@MonthName  nvarchar(50)

	

AS

select HolydayID,HDate,Description from tblholyday where DATEPART(yyyy,Hdate)=@YearName 



select HolydayID,HDate,Description from tblholyday where DATEPART(yyyy,Hdate)=@YearName and  datename(month,Hdate)=@MonthName
GO
/****** Object:  StoredProcedure [dbo].[Holyday_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Holyday_Insert]


@HDate date,
@Description nvarchar(50),
@CreatedBy bigint


AS
BEGIN
INSERT INTO [tblHolyday]
           ([HDate],[Description],[CreatedBy],[CreatedDate])
     VALUES
	(@HDate,@Description,@CreatedBy,GETDATE())

	
END

GO
/****** Object:  StoredProcedure [dbo].[Holyday_IsExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Holyday_IsExists]

@WorkingDate date,
@IsExists INT output
AS

If Exists
(Select [Hdate] from tblHolyday Where [HDate]=@WorkingDate )

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[IncomeReoprt_ByMonth]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IncomeReoprt_ByMonth]

@OtherIncomeDate date

AS

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@OtherIncomeDate)+1,0))

SELECT        tblOtherIncomeTypes.Description, tblOtherIncomes.OtherIncomeDate, tblOtherIncomes.Note, tblOtherIncomes.Quantity, tblOtherIncomes.Rate, tblOtherIncomes.Amount, tblOtherIncomes.Deduction, 
                         tblOtherIncomes.OtherIncomeTypeID
FROM            tblOtherIncomes LEFT OUTER JOIN
                         tblOtherIncomeTypes ON tblOtherIncomes.OtherIncomeTypeID = tblOtherIncomeTypes.OtherIncomeTypeID
						 where tblOtherIncomes.OtherIncomeTypeID <> 2
						 
						 and tblOtherIncomes.OtherIncomeDate>=@OtherIncomeDate AND tblOtherIncomes.OtherIncomeDate<=@maxDate
						 


SELECT        tblOtherIncomeTypes.Description, tblOtherIncomes.OtherIncomeDate, tblOtherIncomes.Note, tblOtherIncomes.Quantity, tblOtherIncomes.Rate, tblOtherIncomes.Amount, tblOtherIncomes.Deduction, 
                         tblOtherIncomes.OtherIncomeTypeID
FROM            tblOtherIncomes LEFT OUTER JOIN
                         tblOtherIncomeTypes ON tblOtherIncomes.OtherIncomeTypeID = tblOtherIncomeTypes.OtherIncomeTypeID
						 where tblOtherIncomes.OtherIncomeTypeID = 2
						 
						 and tblOtherIncomes.OtherIncomeDate>=@OtherIncomeDate AND tblOtherIncomes.OtherIncomeDate<=@maxDate

GO
/****** Object:  StoredProcedure [dbo].[LogBook_getByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[LogBook_getByDates]
	@FromDate datetime,
	@ToDate datetime
As

	Select 
		[LogID],
		[UserName],
		[Password],
		[AttempDate],
		[IPAddress],
		[ComputerName]
	From tblLogBook

 WHERE [AttempDate]>=@FromDate AND [AttempDate]<=@ToDate

GO
/****** Object:  StoredProcedure [dbo].[LogBook_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[LogBook_Insert]
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@IPAddress nvarchar(50),
	@ComputerName nvarchar(50)
As
Begin
	Insert Into tblLogBook
		([UserName],[Password],[AttempDate],[IPAddress],[ComputerName])
	Values
		(@UserName,@Password,getdate(),@IPAddress,@ComputerName)

	

End

GO
/****** Object:  StoredProcedure [dbo].[Messages_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Messages_Delete]

@Message  nvarchar(500)

AS

DELETE FROM [tblMessages]
      WHERE [Message]=@Message

GO
/****** Object:  StoredProcedure [dbo].[Messages_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Messages_GetAll]


AS


SELECT [MessageID]
      ,[Message]
  FROM [tblMessages]

GO
/****** Object:  StoredProcedure [dbo].[Messages_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Messages_Insert]

@Message nvarchar(500)
AS


IF not EXISTS

	(SELECT [Message] FROM [tblMessages] WHERE [Message]=@Message)

begin
INSERT INTO [tblMessages]
           ([Message])
     VALUES
           (@Message)
end

GO
/****** Object:  StoredProcedure [dbo].[Models_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Models_Delete]

@Description nvarchar(50)

AS

DELETE FROM [tblModels]
      WHERE [Description]=@Description

GO
/****** Object:  StoredProcedure [dbo].[Models_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Models_GetAll]

as

SELECT [ModelID]
      ,[Description]
  FROM tblModels

GO
/****** Object:  StoredProcedure [dbo].[Models_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Models_Insert]

@Description nvarchar(50)

AS


IF not EXISTS

	(SELECT [Description] FROM tblModels WHERE [Description]=@Description)

begin
INSERT INTO [tblModels]
           ([Description])
     VALUES
           (@Description)
end

GO
/****** Object:  StoredProcedure [dbo].[Models_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Models_Update]

@ModelID bigint,
@Description nvarchar(50)

as

UPDATE [dbo].[tblModels]
   SET [Description] = @Description
 WHERE [ModelID]=@ModelID

GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MonthlyExpenses]
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
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate,E.Remarks
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
	 
	
	
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate,E.Remarks
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
	   and 	 E.Designation='Casual'
	   order by CA.IssueDate
GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses_Cal_Casual]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MonthlyExpenses_Cal_Casual]

@IssueDate DATE,
@daterange INT

AS



--DECLARE @IssueDate DATE
--SET @IssueDate=  '2015-06-01'
--declare @daterange int
--set @daterange=2


DECLARE @maxDate DATE

IF @daterange=1
BEGIN
SET @maxDate= DATEADD(d,14,@IssueDate)
END
ELSE IF @daterange=2
BEGIN
SET @IssueDate=DATEADD(d,15,@IssueDate)
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
END





--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]



--SELECT * FROM @DateList



IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex VARCHAR(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
	--ABB1.AbbreviationCode  
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList

--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	SmokingS decimal(18,2),
	OverKgs DECIMAL(18,2),
	LowerKgs DECIMAL(18,2),
	OverSheets DECIMAL(18,2),
	LowerSheets DECIMAL(18,2),
	OTHours DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	LowerKgsPay decimal(18,2),
	OverSheetsPay decimal(18,2),
	LowerSheetsPay decimal(18,2),
	SmokingSheetsPay decimal(18,2),	
	OTPay decimal(18,2),
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	CashRewards decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,CashRewards)
(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,


isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

isnull(SUM(TDW.OTHours),0) AS OTHours,

(isnull(SUM(TDW.NameDays * TDW.CasualPayRate),0)) AS BasicPay,

		

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

'0' as WCPay,
 

'0' as EvalutionAllowance,

-----------------------------------------------------------------------------------------
(
(isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)
--+
--(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
-- +
--(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
) as GrandTotalPay,



isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) 

+

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * 0
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * 0
when 'W' then WorkedDays * 0
when 'rs' then TDW.WorkedDays * 0
when 'SU' then TDW.WorkedDays * 0
end),0)) + isnull(0,0),0) )

-
(


isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)
 +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashRewards CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashRewards



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeNo, EmployeeName,
					
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 						 
						 XYZ.BalancePay,
						 XYZ.CashRewards
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


------------------------------------------------------------------


--USE [Estate]
--GO
--/****** Object:  StoredProcedure [dbo].[MonthlyExpenses_Cal_Casual]    Script Date: 19/Jul/2016 10:29:40 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[MonthlyExpenses_Cal_Casual]

--@IssueDate DATE,
--@daterange INT

--AS



----DECLARE @IssueDate DATE
----SET @IssueDate=  '2015-06-01'
----declare @daterange int
----set @daterange=2


--DECLARE @maxDate DATE

--IF @daterange=1
--BEGIN
--SET @maxDate= DATEADD(d,14,@IssueDate)
--END
--ELSE IF @daterange=2
--BEGIN
--SET @IssueDate=DATEADD(d,15,@IssueDate)
--SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
--END





----Creating date from 1st of month to end of month
--DECLARE @DateList TABLE
--(
--	DateOfMonth DATE
--)

--;WITH [tmpData] AS (
--  SELECT CAST(@IssueDate AS DATE) AS dt
--  UNION ALL
--  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
--  INSERT INTO @DateList (DateOfMonth)
--  SELECT * FROM [tmpData]



----SELECT * FROM @DateList



--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--CREATE TABLE #CodeAggregatedList 
--(
--	EmployeeID BIGINT,
--	EmployeeNo INT,
--	EmployeeName VARCHAR(200),
--	Sex VARCHAR(20),
--	WorkingDate DATE,
--	AbbreviatedCode VARCHAR(1000)
--)

----Comma seperating abbreviation code
--INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
--SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

--(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
--	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
--	--ABB1.AbbreviationCode  
	
--	FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
--) AS M

--WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
--FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
--)
--AS S
--GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


----select * from #CodeAggregatedList

----Creating dynamic pivot date list string 
--DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
--DECLARE @ColumnName AS VARCHAR(MAX)
 
--SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
--       + QUOTENAME(DateOfMonth)
--FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

----Calculate the month summary
--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

--CREATE TABLE #CalculatedList 
--(
--	EmployeeID BIGINT,
--	TotalDays decimal(18,2),
--	NameDays decimal(18,2),	
--	PluckingKgs decimal(18,2),
--	TappingL decimal(18,2),
--	SmokingS decimal(18,2),
--	OverKgs DECIMAL(18,2),
--	LowerKgs DECIMAL(18,2),
--	OverSheets DECIMAL(18,2),
--	LowerSheets DECIMAL(18,2),
--	OTHours DECIMAL(18,2),
--	BasicPay DECIMAL(18,2),
--	OverKgsPay decimal(18,2),	
--	LowerKgsPay decimal(18,2),
--	OverSheetsPay decimal(18,2),
--	LowerSheetsPay decimal(18,2),
--	SmokingSheetsPay decimal(18,2),	
--	OTPay decimal(18,2),
--	WCPay decimal(18,2),
--	EvalutionAllowance decimal(18,2),
--	GrandTotalPay decimal(18,2),
--	FestivalAdvance decimal(18,2),
--	CashAdvance decimal(18,2),
--	TotalDeductions decimal(18,2),
--	BalancePay decimal(18,2),
--	CashRewards decimal(18,2),
	
--)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,CashRewards)
--(

--SELECT  TDW.EmployeeID, 

--isnull(SUM(TDW.WorkedDays),0) AS TotalDays,


--isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
--isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

--isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

--isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

--isnull(SUM(TDW.OTHours),0) AS OTHours,

--(isnull(SUM(TDW.NameDays * TDW.CasualPayRate),0)) AS BasicPay,

		

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

--isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

--'0' as WCPay,
 

--'0' as EvalutionAllowance,

-------------------------------------------------------------------------------------------
--(
--(isnull(SUM(
-- TDW.NameDays * TDW.CasualPayRate
--),0 
--)
--)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
--+
--isnull(SUM(TDW.OTHours * TDW.OTRate),0)
----+
----(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
---- +
----(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
--) as GrandTotalPay,


--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
                  

--),0) as FestivalAdvance,

--isnull((
--	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as CashAdvance,

--+
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
--isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as TotalDeductions,

--(isnull((isnull(SUM(
-- TDW.NameDays * TDW.CasualPayRate
--),0 
--)
--) +
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

--isnull(SUM(TDW.OTHours * TDW.OTRate),0) 

--+

--(isnull(SUM(case abc.AbbreviationCode 
--when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * 0
--when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * 0
--when 'W' then WorkedDays * 0
--when 'rs' then TDW.WorkedDays * 0
--when 'SU' then TDW.WorkedDays * 0
--end),0)) + isnull(0,0),0) )

---
--(
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
--isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
--as BalancePay,

--isnull((
--	select SUM(CA.AdvanceAmount) from tblCashRewards CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as CashRewards



--FROM    tblDailyWorking TDW
--inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

--WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
--AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
--GROUP BY TDW.EmployeeID)

----select * from  #CalculatedList

--SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeNo, EmployeeName,
					
--						 XYZ.FestivalAdvance, 
--						 XYZ.CashAdvance, 						 
--						 XYZ.BalancePay,
--						 XYZ.CashRewards
--						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
--						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


--EXEC (@DynamicPivotQuery)


--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END


----USE [iStockV22]
----GO
----/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvanceCasual]    Script Date: 02/24/2016 05:05:44 ******/
----SET ANSI_NULLS ON
----GO
----SET QUOTED_IDENTIFIER ON
----GO
----ALTER PROCEDURE [dbo].[ReportAttendanceAdvanceCasual]

----@IssueDate DATE,
----@daterange INT

----AS



------DECLARE @IssueDate DATE
------SET @IssueDate=  '2015-06-01'
------declare @daterange int
------set @daterange=2


----DECLARE @maxDate DATE

----IF @daterange=1
----BEGIN
----SET @maxDate= DATEADD(d,14,@IssueDate)
----END
----ELSE IF @daterange=2
----BEGIN
----SET @IssueDate=DATEADD(d,14,@IssueDate)
----SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
----END





------Creating date from 1st of month to end of month
----DECLARE @DateList TABLE
----(
----	DateOfMonth DATE
----)

----;WITH [tmpData] AS (
----  SELECT CAST(@IssueDate AS DATE) AS dt
----  UNION ALL
----  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
----  INSERT INTO @DateList (DateOfMonth)
----  SELECT * FROM [tmpData]



------SELECT * FROM @DateList



----IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
----BEGIN
----    DROP TABLE #CodeAggregatedList
----END

----CREATE TABLE #CodeAggregatedList 
----(
----	EmployeeID BIGINT,
----	EmployeeNo INT,
----	EmployeeName VARCHAR(200),
----	Sex VARCHAR(20),
----	WorkingDate DATE,
----	AbbreviatedCode VARCHAR(1000)
----)

------Comma seperating abbreviation code
----INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
----SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

----(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

----(
----	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
----	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
----	--ABB1.AbbreviationCode  
	
----	FROM tblDailyWorking DW1 
----	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
----	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
----	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
----	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
----) AS M

----WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
----FROM 

----(
----	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
----	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
----	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
----	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
----	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
----)
----AS S
----GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


------select * from #CodeAggregatedList

------Creating dynamic pivot date list string 
----DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
----DECLARE @ColumnName AS VARCHAR(MAX)
 
----SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
----       + QUOTENAME(DateOfMonth)
----FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

------Calculate the month summary
----IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
----BEGIN
----    DROP TABLE #CalculatedList
----END

----CREATE TABLE #CalculatedList 
----(
----	EmployeeID BIGINT,
----	TotalDays DECIMAL(18,2),	
----	PluckingKgs DECIMAL(18,2),
----	TappingL DECIMAL(18,2),
----	OverKgs DECIMAL(18,2),
----	DaysPay DECIMAL(18,2),
----	OverKgsPay DECIMAL(18,2),		
----	GrandTotalPay DECIMAL(18,2),	
----	FestivalAdvance DECIMAL(18,2),
----	CashAdvance DECIMAL(18,2),
----	TotalDeductions DECIMAL(18,2),
----	BalancePay DECIMAL(18,2)
	
	
----)

----INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,DaysPay,OverKgsPay,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
----(SELECT  TDW.EmployeeID, 
----ISNULL(SUM(TDW.WorkedDays),0) AS TotalDays,
----ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'P' THEN  TDW.Quantity  END)),0) AS PluckingKgs,
----ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'T' THEN TDW.Quantity  END)),0) AS TappingL,

------ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) ELSE 0 END),0) AS OverKgs,
----ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,


----ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0) AS DaysPay,

------ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,
----ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,


------ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,
----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,


----ISNULL((SELECT SUM(TD.TDAmount) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
----AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
----AND  ISNULL(TD.IsDeleted,0) <>1 
----GROUP BY TD.EmployerID

----),0) AS FestivalAdvance,

----ISNULL((
----	SELECT SUM(CA.AdvanceAmount) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
----	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

----	GROUP BY CA.EmployerId
----),0) AS CashAdvance,

----ISNULL((
	
----	(
----	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
----	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
----	AND  ISNULL(TD.IsDeleted,0) <>1 
----	GROUP BY TD.EmployerID
----	)+
----	(
----	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
----	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
----	GROUP BY CA.EmployerId
----	)

----),0) AS TotalDeductions,

----ISNULL((

------ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0)-
----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0)-
	
----	ISNULL((

----	(
----	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
----	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
----	AND  ISNULL(TD.IsDeleted,0) <>1 
----	GROUP BY TD.EmployerID
----	)+
----	(
----	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
----	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
----	GROUP BY CA.EmployerId
----	)

----),0)

----),0) AS BalancePay


----FROM    tblDailyWorking TDW
----INNER JOIN tblAbbreviation ABC ON TDW.AbbreviationID=abc.AbbreviationID

----WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
----AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
----GROUP BY TDW.EmployeeID)

----SET @DynamicPivotQuery = 'SELECT PVTTable.*,XYZ.TotalDays, XYZ.PluckingKgs,XYZ.TappingL, XYZ.OverKgs, XYZ.DaysPay,XYZ.OverKgsPay, XYZ.GrandTotalPay,   XYZ.FestivalAdvance, XYZ.CashAdvance, XYZ.TotalDeductions, XYZ.BalancePay  FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
----						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


----EXEC (@DynamicPivotQuery)


----IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
----BEGIN
----    DROP TABLE #CodeAggregatedList
----END

----IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
----BEGIN
----    DROP TABLE #CalculatedList
----END

GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses_Cal_Permanent]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MonthlyExpenses_Cal_Permanent]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	EPFAmount decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	BalancePay decimal(18,2),
	CashRewards decimal(18,2),
	EPF_12 decimal(18,2),
	EPF_20 decimal(18,2),
	ETF_3 decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,EPFAmount,FestivalAdvance,CashAdvance,BalancePay,CashRewards,EPF_12,EPF_20,ETF_3)
(
SELECT  TDW.EmployeeID, 

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,


isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,


--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
                  

--),0) as FestivalAdvance,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

(isnull((isnull(SUM(TDW.NameDays * TDW.DayRate),0))

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0)



 +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) +

(isnull(SUM(TDW.NameDays * TDW.WCPayRate),0)) + isnull(0,0),0)

+
(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)

 )

-

(((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
isnull(MAX(TDW.PayChit),0)
+

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 


isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)

+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashRewards CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashRewards,
--------------------------------------------------------------------------------------------------

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeNo,EmployeeName ,						 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.BalancePay,
						 XYZ.CashRewards,
						 XYZ.EPF_12,						 
						 XYZ.ETF_3  
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses_Cal_Staff]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MonthlyExpenses_Cal_Staff]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	GrandTotalPay decimal(18,2),
	--EPFAmount decimal(18,2),
	--PayChit decimal(18,2),
	--FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2)
	--EPF_12 decimal(18,2),
	--EPF_20 decimal(18,2),
	--ETF_3 decimal(18,2),
	
)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,CashAdvance,TotalDeductions,BalancePay)

(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0)) as GrandTotalPay,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

--isnull(MAX(TDW.PayChit),0) as PayChit,


--isnull((
--	select SUM(FS.AdvanceAmount) from tblFestivalRecovery FS where FS.EmployerId=TDW.EmployeeID
--	and	FS.IssueDate >=@IssueDate AND FS.IssueDate <=@maxDate

--	group by FS.EmployerId
--),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,


(isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0)) as TotalDeductions,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0))

-
(
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)
) 
as BalancePay


--------------------------------------------------------------------------------------------------

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='STAFF'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeNo,EmployeeName, 
					
						 XYZ.CashAdvance, 
						
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


GO
/****** Object:  StoredProcedure [dbo].[MonthlyExpenses_Chart]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[MonthlyExpenses_Chart]
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
			--  and E.Designation='PERMANENT'





	--EPF & ETF
	
	SELECT   EmployeeName ,EPF_12 FROM @tempPermanent
	
	SELECT   EmployeeName , ETF_3 FROM @tempPermanent
	
	
	--expenses
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate
	FROM       tblExpenses AS E INNER JOIN
               tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
	WHERE     (E.ExpenseDate >= @ReportDate) AND (E.ExpenseDate <= @maxDate)
	AND ET.[Description]<> 'MIX' 
	AND ET.[Description]<> 'PEON'
	AND ET.[Description]<> 'MACHINE CHARGES' 
	
	order by ET.[Description]
	
	
		
	SET @maxDateKP= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@ReportDate)+1,0))


SELECT        tblEmployers.EmployerNo, tblEmployers.EmployerName as EmployeeName, sum(isnull(tblCashAdvance.AdvanceAmount,0)) as StaffAdvance
FROM            tblCashAdvance INNER JOIN
                         tblEmployers ON tblCashAdvance.EmployerId = tblEmployers.EmployerID
where Designation='STAFF' AND IssueDate>=@ReportDate and IssueDate<=@maxDateKP 
group by tblEmployers.EmployerNo, tblEmployers.EmployerName
	 
	
	
	SELECT     E.Amount, E.Note, ET.[Description], E.ExpenseDate
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

			  SELECT     sum(E.Amount)as OtherExs
	FROM       tblExpenses AS E INNER JOIN
               tblExpenseTypes AS ET ON E.ExpenseTypeID = ET.ExpenseTypeID
	WHERE     (E.ExpenseDate >= @ReportDate) AND (E.ExpenseDate <= @maxDate)
	AND ET.[Description]= 'MIX' 
	or ET.[Description]= 'PEON'
	AND ET.[Description]<> 'MACHINE CHARGES' 
GO
/****** Object:  StoredProcedure [dbo].[OtherIncome_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncome_GetByID]

@OtherIncomeID bigint

AS

SELECT     OI.OtherIncomeID, OI.OtherIncomeTypeID, OI.PaymentTypeID, OI.OtherIncomeDate, OI.Amount, OI.Note, OIT.Description AS OtherIncomeType, 
                      PT.Description AS PaymentType, OI.CreatedBy, OI.CreatedDate, OI.UpdatedBy, OI.UpdatedDate, OI.Rate, OI.Quantity, OI.Deduction
FROM         tblOtherIncomes AS OI LEFT OUTER JOIN
                      tblOtherIncomeTypes AS OIT ON OI.OtherIncomeTypeID = OIT.OtherIncomeTypeID LEFT OUTER JOIN
                      tblPaymentTypes AS PT ON OI.PaymentTypeID = PT.PaymentTypeID
WHERE     (OI.OtherIncomeID = @OtherIncomeID)

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomes_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomes_Delete]

@OtherIncomeID bigint

AS

UPDATE    tblStock
SET        CurrentStockBalance = CurrentStockBalance +
              (SELECT     (Quantity) 
              FROM          tblOtherIncomes OT
              WHERE       (OT.OtherIncomeID = @OtherIncomeID)
			  --WHERE      (StockID = OT.StockID) AND (OT.OtherIncomeID = @OtherIncomeID)
              )

DELETE FROM [tblOtherIncomes]
      WHERE [OtherIncomeID]=@OtherIncomeID

--DELETE FROM tblCollections
--	WHERE [SystemID]=@OtherIncomeID AND TransactionTypeID=3

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomes_GetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomes_GetByDates]

@FromDate datetime,
@ToDate datetime

AS
SELECT     OI.OtherIncomeID, OI.OtherIncomeTypeID, OI.PaymentTypeID, OI.OtherIncomeDate, OI.Amount, OI.Note, OIT.Description AS OtherIncomeType, 
                      PT.Description AS PaymentType, OI.CreatedDate, OI.UpdatedDate, tblUserLogin_1.UserName AS CreatedBy, tblUserLogin.UserName AS UpdatedBy, OI.Rate, 
                      OI.Quantity
FROM         tblOtherIncomeTypes AS OIT RIGHT OUTER JOIN
                      tblOtherIncomes AS OI LEFT OUTER JOIN
                      tblUserLogin ON OI.UpdatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON OI.CreatedBy = tblUserLogin_1.UserLoginID ON OIT.OtherIncomeTypeID = OI.OtherIncomeTypeID LEFT OUTER JOIN
                      tblPaymentTypes AS PT ON OI.PaymentTypeID = PT.PaymentTypeID
WHERE     (OI.OtherIncomeDate >= @FromDate) AND (OI.OtherIncomeDate <= @ToDate)
ORDER BY OI.OtherIncomeID DESC




--SELECT     OI.OtherIncomeID, OI.OtherIncomeTypeID, OI.PaymentTypeID, OI.OtherIncomeDate, OI.Amount, OI.Note, OIT.Description AS OtherIncomeType, 
--                      PT.Description AS PaymentType, OI.CreatedDate, OI.UpdatedDate, tblUserLogin_1.UserName AS CreatedBy, tblUserLogin.UserName AS UpdatedBy, OI.Rate, 
--                      OI.Quantity, S.StockCode, S.Description
--FROM         tblOtherIncomeTypes AS OIT RIGHT OUTER JOIN
--                      tblOtherIncomes AS OI LEFT OUTER JOIN
--                      tblStock AS S ON OI.StockID = S.StockID LEFT OUTER JOIN
--                      tblUserLogin ON OI.UpdatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
--                      tblUserLogin AS tblUserLogin_1 ON OI.CreatedBy = tblUserLogin_1.UserLoginID ON OIT.OtherIncomeTypeID = OI.OtherIncomeTypeID LEFT OUTER JOIN
--                      tblPaymentTypes AS PT ON OI.PaymentTypeID = PT.PaymentTypeID
--WHERE     (OI.OtherIncomeDate >= @FromDate) AND (OI.OtherIncomeDate <= @ToDate)
--ORDER BY OI.OtherIncomeID DESC

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomes_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomes_Insert]

 @OtherIncomeID BIGINT
,@OtherIncomeTypeID BIGINT
,@PaymentTypeID BIGINT
,@OtherIncomeDate DATETIME
,@Amount DECIMAL(18,2)
,@Rate DECIMAL(18,2)
,@Quantity DECIMAL(18,2)
,@Note NTEXT
,@CurrentOtherIncomeID BIGINT OUTPUT
,@CreatedBy BIGINT
,@UpdatedBy BIGINT
,@Deduction DECIMAL
AS


IF EXISTS
(SELECT [OtherIncomeID] FROM tblOtherIncomes  WHERE [OtherIncomeID]=@OtherIncomeID)
	
	BEGIN
	
	--UPDATE    tblStock
	--	SET        CurrentStockBalance = ISNULL(CurrentStockBalance,0) +
 --       (SELECT     ISNULL((OT.Quantity),0) 
 --       FROM          tblOtherIncomes OT
 --       WHERE      (StockID = OT.StockID) AND (OT.OtherIncomeID = @OtherIncomeID)
 --       ),
 --       CurrentStockValue=ISNULL([CurrentStockValue],0) + (SELECT ISNULL([PurchasingPrice],0)* (SELECT     ISNULL((OT.Quantity),0) 
 --       FROM          tblOtherIncomes OT
 --       WHERE      (StockID = OT.StockID) AND (OT.OtherIncomeID = @OtherIncomeID)
 --       ))
     
       
	--	UPDATE [tblStock] 
	--	SET  [CurrentStockBalance]	 = ISNULL([CurrentStockBalance],0)- @Quantity,
	--			   [CurrentStockValue]= ISNULL([CurrentStockValue],0)-(SELECT ISNULL([PurchasingPrice],0)* ISNULL(@Quantity,0) FROM tblStock WHERE [StockID]=@StockID)
	--	WHERE 
	--			( [StockID]	 = @StockID)

	
		UPDATE [tblOtherIncomes]
		SET [OtherIncomeTypeID] = @OtherIncomeTypeID
		   ,[PaymentTypeID]=@PaymentTypeID	
		   ,[OtherIncomeDate] = @OtherIncomeDate
		   ,[Amount] =@Amount
		   ,[Rate] =@Rate
		   ,[Quantity] =@Quantity
		   ,[Note] = @Note			
		   ,[UpdatedBy]=@UpdatedBy
		   ,[UpdatedDate]=GETDATE()
		   ,[Deduction]=@Deduction
		WHERE [OtherIncomeID]=@OtherIncomeID
		SET @CurrentOtherIncomeID=-1
		
			
		
		
		
	
		
	END


ELSE

BEGIN
INSERT INTO [tblOtherIncomes]
           ([OtherIncomeTypeID]
			,[PaymentTypeID]
           ,[OtherIncomeDate]
           ,[Amount]
           ,[Rate]
           ,[Quantity]
           ,[Note]
		   ,[CreatedBy]
		   ,[CreatedDate]
		   ,Deduction)
     VALUES
           (@OtherIncomeTypeID
			,@PaymentTypeID
           ,@OtherIncomeDate
           ,@Amount
           ,@Rate
           ,@Quantity
           ,@Note
		   ,@CreatedBy
		   ,GETDATE()
		   ,@Deduction)


			--IF @StockID>0
			--BEGIN

			--UPDATE [tblStock] 
			--SET  [CurrentStockBalance]	 = ISNULL([CurrentStockBalance],0)- @Quantity,
			--	   [CurrentStockValue]= ISNULL([CurrentStockValue],0)-(SELECT ISNULL([PurchasingPrice],0)* ISNULL(@Quantity,0) FROM tblStock WHERE [StockID]=@StockID)
			--WHERE 
			--	( [StockID]	 = @StockID)

			--END

SET @CurrentOtherIncomeID=SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomeTypes_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomeTypes_Delete]

@Description nvarchar(50)

AS

DELETE FROM [dbo].[tblOtherIncomeTypes]
WHERE [Description]=@Description

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomeTypes_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomeTypes_GetAll]



AS

SELECT [OtherIncomeTypeID]
      ,[Description]
  FROM [dbo].[tblOtherIncomeTypes]

GO
/****** Object:  StoredProcedure [dbo].[OtherIncomeTypes_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OtherIncomeTypes_Insert]

@Description nvarchar(50)
AS

if exists
(Select [Description] from tblOtherIncomeTypes Where [Description]=@Description)

begin
UPDATE [dbo].[tblOtherIncomeTypes]
   SET [Description] = @Description
 WHERE [Description]=@Description
end

else


INSERT INTO [dbo].[tblOtherIncomeTypes]
           ([Description])
     VALUES
           
		(@Description)

GO
/****** Object:  StoredProcedure [dbo].[ProfotAndLoss_GetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ProfotAndLoss_GetByDates]

@FromDate datetime,
@ToDate datetime,
@StockValue decimal(18,2) output, 
@TotalPurchases decimal(18,2) output,
@TotalSales decimal(18,2) output,
@TotalPurchaseCost decimal(18,2) output,
@TotalExpenses decimal(18,2) output,
@TotalCashtoPay decimal(18,2) output,
@TotalCashtoReceive decimal(18,2) output
AS

set @StockValue = (select sum([CurrentStockValue]) from tblStock  )
set @TotalPurchases= (select sum([Grandtotal]) from tblPurchases where PurchaseDate>=@FromDate and PurchaseDate<=@ToDate)
set @TotalSales=(select sum([GrandTotal]) from tblSales where SalesDate>=@FromDate and SalesDate<=@ToDate)
set @TotalPurchaseCost=(select sum([PurchaseCost]) from vwPurchasingCost Where SalesDate>=@FromDate and SalesDate<=@ToDate)
set @TotalExpenses = (select sum([Amount]) from tblExpenses where ExpenseDate>=@FromDate and ExpenseDate<=@ToDate)

set @TotalCashtoPay= (select sum([Balance]) from vwPurchasesUnsettled)
set @TotalCashtoReceive=(select sum([Balance]) from vwSalesUnsettled)

GO
/****** Object:  StoredProcedure [dbo].[PurchaseOrder_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseOrder_Insert]

 @PurchaseOrderID bigint
,@SupplierID  bigint
,@ReferenceNo nvarchar(20)
,@PurchaseOrderDate datetime
,@Note ntext
,@CurrentPurchaseOrderID bigint output
AS

if exists
(select @PurchaseOrderID from  [tblPurchaseOrder] Where PurchaseOrderID=@PurchaseOrderID )

begin

UPDATE [dbo].[tblPurchaseOrder]
   SET [SupplierID] = @SupplierID
      ,[ReferenceNo] = @ReferenceNo
      ,[PurchaseOrderDate] = @PurchaseOrderDate
      ,[Note] = @Note
 WHERE PurchaseOrderID=@PurchaseOrderID

end

else




INSERT INTO [dbo].[tblPurchaseOrder]
           ([SupplierID]
           ,[ReferenceNo]
           ,[PurchaseOrderDate]
           ,[Note])
     VALUES
           (@SupplierID
			,@ReferenceNo
           ,@PurchaseOrderDate
           ,@Note)

set @CurrentPurchaseOrderID=SCOPE_IDENTITY()

GO
/****** Object:  StoredProcedure [dbo].[PurchaseOrderDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseOrderDescription_Delete]

@PurchaseOrderID bigint

AS

DELETE FROM [dbo].[tblPurchaseOrderDescription]
      WHERE PurchaseOrderID=@PurchaseOrderID

GO
/****** Object:  StoredProcedure [dbo].[PurchaseOrderDescription_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseOrderDescription_GetByID]

@PurchaseOrderID bigint

AS

SELECT     tblPurchaseOrderDescription.PurchaseOrderID, tblPurchaseOrderDescription.StockID, tblPurchaseOrderDescription.RequiredQuantity, 
                      tblStock.StockCode, tblStock.Description
FROM         tblPurchaseOrderDescription LEFT OUTER JOIN
                      tblStock ON tblPurchaseOrderDescription.StockID = tblStock.StockID
WHERE     (tblPurchaseOrderDescription.PurchaseOrderID = @PurchaseOrderID)

GO
/****** Object:  StoredProcedure [dbo].[PurchaseOrderDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchaseOrderDescription_Insert]

@PurchaseOrderID bigint
,@StockID bigint
,@RequiredQuantity float

AS

INSERT INTO [dbo].[tblPurchaseOrderDescription]
           ([PurchaseOrderID]
           ,[StockID]
           ,[RequiredQuantity])
     VALUES
           (@PurchaseOrderID
           ,@StockID
           ,@RequiredQuantity)

GO
/****** Object:  StoredProcedure [dbo].[Purchases_GetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Purchases_GetByDates] 

@FromDate datetime,
@ToDate datetime

AS

SELECT     tblPurchases.PurchaseID, tblPurchases.SupplierID, tblPurchases.ReferenceNo, tblPurchases.PurchaseDate, tblPurchases.Total, tblPurchases.Paid, 
                      tblSuppliers.SupplierNo, tblSuppliers.SupplierName, tblPurchases.Tax, tblPurchases.Discount, tblPurchases.CreatedDate, tblPurchases.UpdatedDate, 
                      tblUserLogin.UserName AS CreatedBy, tblUserLogin_1.UserName AS UpdatedBy, tblPurchases.GrandTotal, tblPurchases.PurchaseNo, 
                      vwPurchasesCollection.AmountPaid, vwPurchasesCollection.Balance, tblPurchases.Percentage
FROM         tblUserLogin RIGHT OUTER JOIN
                      vwPurchasesCollection RIGHT OUTER JOIN
                      tblPurchases ON vwPurchasesCollection.PurchaseID = tblPurchases.PurchaseID LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblPurchases.UpdatedBy = tblUserLogin_1.UserLoginID ON 
                      tblUserLogin.UserLoginID = tblPurchases.CreatedBy LEFT OUTER JOIN
                      tblSuppliers ON tblPurchases.SupplierID = tblSuppliers.SupplierID
WHERE     (tblPurchases.PurchaseDate >= @FromDate) AND (tblPurchases.PurchaseDate <= @ToDate)
order by tblPurchases.PurchaseID desc

GO
/****** Object:  StoredProcedure [dbo].[Purchases_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Purchases_GetByID]
	@PurchaseID bigint

AS 



SELECT     tblPurchases.PurchaseID, tblPurchases.SupplierID, tblPurchases.ReferenceNo, tblPurchases.PurchaseDate, tblPurchases.Total, 
                      tblPurchases.Percentage, tblPurchases.Tax, tblPurchases.Discount, tblPurchases.Note, tblPurchases.Paid, tblPurchases.CreatedBy, 
                      tblPurchases.CreatedDate, tblPurchases.UpdatedBy, tblPurchases.UpdatedDate, tblPurchases.GrandTotal, tblPurchases.PurchaseNo
FROM         tblPurchases INNER JOIN
                      tblSuppliers ON tblPurchases.SupplierID = tblSuppliers.SupplierID
WHERE     (tblPurchases.PurchaseID = @PurchaseID)

GO
/****** Object:  StoredProcedure [dbo].[Purchases_GetStockItemsByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Purchases_GetStockItemsByDates]


@FromDate datetime,
@ToDate datetime


AS 

SELECT     P.PurchaseID, P.PurchaseNo, P.PurchaseDate, S.SupplierName, PD.StockID, PD.UnitPrice, PD.Quantity, PD.BagWeight, PD.NoOfBags, PD.Discount, PD.Value, 
                      ST.StockCode, ST.[Description]
FROM         tblPurchases AS P INNER JOIN
                      tblPurchasesDescription AS PD ON P.PurchaseID = PD.PurchaseID INNER JOIN
                      tblSuppliers AS S ON P.SupplierID = S.SupplierID INNER JOIN
                      tblStock AS ST ON PD.StockID = ST.StockID
WHERE     (P.PurchaseDate >= @FromDate) AND (P.PurchaseDate <= @ToDate)  
Order by P.PurchaseID ASC

GO
/****** Object:  StoredProcedure [dbo].[Purchases_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Purchases_Insert]
	(@PurchaseID bigint,
	 @SupplierID 	bigint,
	 @ReferenceNo 	NVARCHAR(20),
	 @PurchaseDate 	DATETIME,
	 @Total 	MONEY,
	 @Percentage	MONEY,
	 @Tax		MONEY,
	 @Discount 	MONEY,
	 @GrandTotal MONEY,
	 @Note 	NTEXT,
	 @Paid 	BIT,
	 @CurrentPurchaseID bigint output,
	@CreatedBy Bigint,
	@UpdatedBy Bigint)

AS 
IF EXISTS

		(SELECT [PurchaseID] from tblPurchases Where [PurchaseID]=@PurchaseID)


		BEGIN
		Update tblPurchases
		Set
		[SupplierID] = @SupplierID,
		[ReferenceNo] = @ReferenceNo,
		[PurchaseDate] = @PurchaseDate,
		[Total] = @Total,
		[Percentage] = @Percentage,
		[Tax] = @Tax,
		[Discount] = @Discount,
		[GrandTotal]=@GrandTotal,
		[Note] = @Note,
		[Paid] = @Paid,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = getdate()
	Where		
		[PurchaseID] = @PurchaseID

set @CurrentPurchaseID=-1

		END

ELSE

Begin

Declare @PurchaseNo bigint
set @PurchaseNo=(Select count(SupplierID)+1 from tblPurchases)

INSERT INTO [tblPurchases] 
	 ([SupplierID],
		[PurchaseNo],
	 [ReferenceNo],
	 [PurchaseDate],
	 [Total],
	 [Percentage],
	 [Tax],
	 [Discount],
	 [GrandTotal],
	 [Note],
	 [Paid],[CreatedBy],[CreatedDate]) 
 
VALUES 
	(@SupplierID,
	@PurchaseNo,
     @ReferenceNo,
	 @PurchaseDate,
	 @Total,
	 @Percentage,
	 @Tax,
	 @Discount,
	 @GrandTotal,
	 @Note,
	 @Paid,@CreatedBy,getdate())

set @CurrentPurchaseID=SCOPE_IDENTITY()
End

GO
/****** Object:  StoredProcedure [dbo].[Purchases_SetAsPaid]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Purchases_SetAsPaid]
	@PurchaseID bigint,
	@UpdatedBy bigint
	

AS 
	

		Update tblPurchases
		Set
		[Paid] = 1,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = getdate()
	Where		
		[PurchaseID] = @PurchaseID

GO
/****** Object:  StoredProcedure [dbo].[Purchases_Settled_Bills]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Purchases_Settled_Bills]


 AS

SELECT     tblPurchases.PurchaseID, tblSuppliers.SupplierName, tblPurchases.PurchaseDate, tblPurchases.Total, tblPurchases.Tax, tblPurchases.Discount,
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections
                            WHERE      (TransactionTypeID = 1) AND (SystemID = tblPurchases.PurchaseID)) AS AmountPaid, 
                      tblPurchases.Total - tblPurchases.Discount -
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections AS tblCollections_1
                            WHERE      (TransactionTypeID = 1) AND (SystemID = tblPurchases.PurchaseID)) AS Balance, tblSuppliers.SupplierNo, tblPurchases.GrandTotal
FROM         tblPurchases LEFT OUTER JOIN
                      tblSuppliers ON tblSuppliers.SupplierID = tblPurchases.SupplierID
WHERE     (tblPurchases.Paid = 1)
ORDER BY tblPurchases.PurchaseID

GO
/****** Object:  StoredProcedure [dbo].[Purchases_Unsettled_Bills]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Purchases_Unsettled_Bills]


 AS
SELECT     tblPurchases.PurchaseID, tblSuppliers.SupplierName, tblPurchases.PurchaseDate, tblPurchases.Total, tblPurchases.Tax, tblPurchases.Discount,
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections
                            WHERE      (TransactionTypeID = 1) AND (SystemID = tblPurchases.PurchaseID)) AS AmountPaid, 
                      tblPurchases.Total - tblPurchases.Discount -
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections AS tblCollections_1
                            WHERE      (TransactionTypeID = 1) AND (SystemID = tblPurchases.PurchaseID)) AS Balance, tblSuppliers.SupplierNo, tblPurchases.GrandTotal
FROM         tblPurchases LEFT OUTER JOIN
                      tblSuppliers ON tblSuppliers.SupplierID = tblPurchases.SupplierID
WHERE     (tblPurchases.Paid = 0)
ORDER BY tblPurchases.PurchaseID

GO
/****** Object:  StoredProcedure [dbo].[PurchasesDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchasesDescription_Delete]
	@PurchaseID Bigint
 AS

DELETE FROM tblPurchasesDescription WHERE [PurchaseID]=@PurchaseID

GO
/****** Object:  StoredProcedure [dbo].[PurchasesDescription_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchasesDescription_GetByID]

@PurchaseID bigint

AS 	

SELECT		tblPurchasesDescription.PurchaseID, 
			tblPurchasesDescription.StockID, 
			tblPurchasesDescription.UnitPrice, 
			tblPurchasesDescription.Quantity, 
            tblPurchasesDescription.Discount, 
            tblPurchasesDescription.Value, tblStock.StockCode, tblStock.[Description],
			tblPurchasesDescription.NoOfBags,
			tblPurchasesDescription.BagWeight
FROM         tblPurchasesDescription LEFT OUTER JOIN
                      tblStock ON tblPurchasesDescription.StockID = tblStock.StockID
WHERE     (tblPurchasesDescription.PurchaseID = @PurchaseID)

GO
/****** Object:  StoredProcedure [dbo].[PurchasesDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PurchasesDescription_Insert]
	(@PurchaseID bigint,
	 @StockID bigint,
	 @Unit_Price 	MONEY,
	 @Quantity 	FLOAT,
	 @BagWeight FLOAT,
	 @NoOfBags FLOAT,
	 @Discount 	MONEY,
	 @Value 	MONEY)

AS


 INSERT INTO [tblPurchasesDescription]
	 ([StockID],
	 [PurchaseID],
	 [UnitPrice],
	 [Quantity],
	 [BagWeight],
	 [NoOfBags],
	 [Discount],
	 [Value]) 
 
VALUES 
	( @StockID,
	 @PurchaseID,
	 @Unit_Price,
	 @Quantity,
	 @BagWeight,
	 @NoOfBags,
	 @Discount,
	 @Value)

GO
/****** Object:  StoredProcedure [dbo].[Quotation_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Quotation_Delete]
	(@Quotation_No	[nvarchar](20))

AS DELETE [tblQuotation]

WHERE 
	( [Quotation No]	 = @Quotation_No)

GO
/****** Object:  StoredProcedure [dbo].[Quotation_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Quotation_Insert]
	
	
	
	
	@Quotation_No NVARCHAR(20), 
	@Customer_Name NVARCHAR(100)	, 
	@Address1 NVARCHAR(100), 
	@Address2 NVARCHAR(100), 
	@Address3 NVARCHAR(100), 
	@Age INT, 
	@Date DATETIME, 
	@Occupation NVARCHAR(50), 
	@Firm NVARCHAR(50), 
	@Frame MONEY, 
	@Lense MONEY, 
	@Others MONEY, 
	@Total MONEY, 
	@Valid_Days INT , 
	@Prescription NVARCHAR(50), 
	@Remarks NTEXT
	
    
AS 

IF EXISTS

	(SELECT [Quotation No] FROM [tblQuotation] WHERE [Quotation No]=@Quotation_No)

	BEGIN
	UPDATE [tblQuotation] 	
	SET  
	
	[Quotation No]=@Quotation_No, 
	[Customer Name]=@Customer_Name, 
	Address1=@Address1,
	Address2=@Address2, 
	Address3=@Address3, 
	Age=@Age, 
	Date=@Date, 
	Occupation=@Occupation, 
	Firm=@Firm, 
	Frame=@Frame, 
	Lense=@Lense, 
	Others=@Total, 
	Total=@Total, 
	[Valid Days]=@Valid_Days, 
	Prescription=@Prescription, 
	Remarks=@Remarks
		
	WHERE 
			[Quotation No]= @Quotation_No
	END

ELSE

INSERT INTO [tblQuotation]
	([Quotation No], 
	[Customer Name],
	[Address1],
	[Address2],
	[Address3],
	[Age],
	[Date],
	[Occupation],
	[Firm],
	[Frame],
	[Lense],
	[Others],
	[Total],
	[Valid Days],
	[Prescription],
	[Remarks]) 
VALUES  
	  
	(@Quotation_No,
	@Customer_Name,
	@Address1,
	@Address2,
	@Address3,
	@Age, 
	@Date,
	@Occupation,
	@Firm,
	@Frame, 
	@Lense,
	@Others,
	@Total ,
	@Valid_Days,
	@Prescription,
	@Remarks)

GO
/****** Object:  StoredProcedure [dbo].[Quotation_SelectByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Quotation_SelectByID]
	@Quotation_No [nvarchar](20)

AS 
SELECT 
[Quotation No], 
	[Customer Name],
	[Address1],
	[Address2],
	[Address3],
	[Age],
	[Date],
	[Occupation],
	[Firm],
	[Frame],
	[Lense],
	[Others],
	[Total],
	[Valid Days],
	[Prescription],
	[Remarks]
FROM tblQuotation
WHERE [Quotation No]=@Quotation_No

GO
/****** Object:  StoredProcedure [dbo].[RecoverySummary]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecoverySummary]

-- @year int
@TermDeductionID bigint

AS
--Select 

--E.EPFNo, 
--E.Designation, 
--E.EmployerNo,
--E.EmployerName,
--TD.TDAmount as Amount,  Z.*,'' as Remarks from tblEmployers E
--inner join  [dbo].[tblTermDeductions] TD on TD.EmployerID=E.EmployerID


--inner join (

--select * from 
--(
--	select TermDeductionID, LEFT(DATENAME(MONTH,[IssueDate]),3) MN,AdvanceAmount from [tblFestivalRecovery]
--)	as X

--pivot (max(AdvanceAmount) for MN in ([May1],[Jun],[Jul],[Aug],[Sep],[Oct],[Nov],[Dec],[Jan],[Feb],[Mar])) as Y
--) Z on TD.TermDeductionID = Z.TermDeductionID

SELECT        

tblFestivalRecovery.TermDeductionID, 
tblFestivalRecovery.IssueDate, 
tblFestivalRecovery.AdvanceAmount, 
tblTermDeductions.TDAmount


FROM            
tblFestivalRecovery INNER JOIN tblTermDeductions ON tblFestivalRecovery.TermDeductionID = tblTermDeductions.TermDeductionID

where tblFestivalRecovery.TermDeductionID=@TermDeductionID

order by tblFestivalRecovery.IssueDate
GO
/****** Object:  StoredProcedure [dbo].[ReportAttendance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportAttendance]

@IssueDate DATE,
@WorkType nvarchar(50)=''

AS


--DECLARE @IssueDate DATE
--declare @WorkType nvarchar(50)
--SET @IssueDate='2014-06-01'
--set @WorkType=''

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


DECLARE @DateList TABLE
(
	monthDate DATE
)

;WITH [sample] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM sample s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (monthDate)
  SELECT * FROM [sample]


DECLARE @CodeList TABLE
(
	EmployeeID BIGINT,
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(10)
)

INSERT INTO @CodeList (EmployeeID,WorkingDate,AbbreviatedCode)
SELECT DW1.EmployeeID,DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
where isnull(dw1.IsDeleted,0)<>1 and (DW1.WorkType=@WorkType or @WorkType='')


SELECT DATEPART(DAY,CLX.monthDate) AS monthDate,TT.Sex, TT.EmployerNo, TT.EmployerName, (CASE  WHEN TT.EmployerName IS NULL THEN 0 ELSE TT.WorkedDays END) Attendance, TT.WorkType    FROM @DateList CLX

LEFT OUTER JOIN 

(

SELECT  E.EmployerNo, E.EmployerName, E.Sex,

DW.WorkedDays, 
DW.WorkingDate,dw.WorkType FROM tblEmployers E
LEFT OUTER JOIN tblDailyWorking DW ON DW.EmployeeID=E.EmployerID where isnull(dw.IsDeleted,0)<>1 and (dw.WorkType=@WorkType or @WorkType='')
--inner joi

--(

--SELECT S.EmployeeID, S.WorkingDate,

--(SELECT  STUFF(( SELECT  '],[' + [AbbreviatedCode] FROM @CodeList  WHERE EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]

--FROM @CodeList AS S
--GROUP BY S.EmployeeID,  S.WorkingDate 

--) P ON P.EmployeeID=E.EmployerID and P.WorkingDate=DW.WorkingDate


) TT ON CLX.monthDate=TT.WorkingDate
where EmployerName Is not null

GO
/****** Object:  StoredProcedure [dbo].[ReportAttendance_AllCategory]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportAttendance_AllCategory]

@IssueDate DATE
--@WorkType nvarchar(50)=''

AS


--DECLARE @IssueDate DATE
--declare @WorkType nvarchar(50)
--SET @IssueDate='2014-06-01'
--set @WorkType=''

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


DECLARE @DateList TABLE
(
	monthDate DATE
)

;WITH [sample] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM sample s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (monthDate)
  SELECT * FROM [sample]


DECLARE @CodeList TABLE
(
	EmployeeID BIGINT,
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(10)
)

INSERT INTO @CodeList (EmployeeID,WorkingDate,AbbreviatedCode)
SELECT DW1.EmployeeID,DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
where isnull(dw1.IsDeleted,0)<>1 --and (DW1.WorkType=@WorkType or @WorkType='')


SELECT DATEPART(DAY,CLX.monthDate) AS monthDate,TT.Sex, TT.EmployerNo, TT.EmployerName, (CASE  WHEN TT.EmployerName IS NULL THEN 0 ELSE TT.WorkedDays END) Attendance, TT.WorkType    FROM @DateList CLX

LEFT OUTER JOIN 

(

SELECT  E.EmployerNo, E.EmployerName, E.Sex,

DW.WorkedDays, 
DW.WorkingDate,dw.WorkType FROM tblEmployers E
LEFT OUTER JOIN tblDailyWorking DW ON DW.EmployeeID=E.EmployerID where isnull(dw.IsDeleted,0)<>1 --and (dw.WorkType=@WorkType or @WorkType='')
--inner joi

--(

--SELECT S.EmployeeID, S.WorkingDate,

--(SELECT  STUFF(( SELECT  '],[' + [AbbreviatedCode] FROM @CodeList  WHERE EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]

--FROM @CodeList AS S
--GROUP BY S.EmployeeID,  S.WorkingDate 

--) P ON P.EmployeeID=E.EmployerID and P.WorkingDate=DW.WorkingDate


) TT ON CLX.monthDate=TT.WorkingDate
where EmployerName Is not null

GO
/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportAttendanceAdvance]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	SmokingS decimal(18,2),
	OverKgs DECIMAL(18,2),
	LowerKgs DECIMAL(18,2),
	OverSheets DECIMAL(18,2),
	LowerSheets DECIMAL(18,2),
	OTHours DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	LowerKgsPay decimal(18,2),
	OverSheetsPay decimal(18,2),
	LowerSheetsPay decimal(18,2),
	SmokingSheetsPay decimal(18,2),	
	OTPay decimal(18,2),
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	EPFAmount decimal(18,2),
	PayChit decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	EPF_12 decimal(18,2),
	EPF_20 decimal(18,2),
	ETF_3 decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)
(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

isnull(SUM(TDW.OTHours),0) AS OTHours,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0)) AS BasicPay,


isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)   as WCPay,
 

(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end) as EvalutionAllowance,

((isnull(SUM( TDW.NameDays * TDW.DayRate),0)) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)
+
(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
 +
(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)) as GrandTotalPay,




-----------------------------------------------------------------------------------------

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

isnull(MAX(TDW.PayChit),0) as PayChit,

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID

--),0) as FestivalAdvance,

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
isnull(MAX(TDW.PayChit),0)
+

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(TDW.NameDays * TDW.DayRate),0))

 +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) +

(isnull(SUM(TDW.NameDays * TDW.WCPayRate),0)) + isnull(0,0),0)
+
--Evalution
(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
 )

-
(((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
isnull(MAX(TDW.PayChit),0)+

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)

+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay,


--------------------------------------------------------------------------------------------------

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.NameDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.SmokingS, 
						 XYZ.OverKgs, 
						 XYZ.LowerKgs,
						 XYZ.OverSheets,
						 XYZ.LowerSheets,
						 XYZ.OTHours,
						 XYZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.LowerKgsPay,
						 XYZ.OverSheetsPay,
						 XYZ.LowerSheetsPay,
						 XYZ.SmokingSheetsPay,	
						 XYZ.OTPay,
						 XYZ.WCPay, 
						 XYZ.EvalutionAllowance, 
						 XYZ.GrandTotalPay, 
						 XYZ.EPFAmount, 
						 XYZ.PayChit, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay,
						 XYZ.EPF_12,
						 XYZ.EPF_20,
						 XYZ.ETF_3  
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


-------------------------------------------------------------------------

--USE [Estate]
--GO
--/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvance]    Script Date: 19/Jul/2016 10:33:13 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[ReportAttendanceAdvance]

--@IssueDate DATE

--AS


----Gettin last date of the month
--DECLARE @maxDate DATE
--SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

----Creating date from 1st of month to end of month
--DECLARE @DateList TABLE
--(
--	DateOfMonth DATE
--)

--;WITH [tmpData] AS (
--  SELECT CAST(@IssueDate AS DATE) AS dt
--  UNION ALL
--  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
--  INSERT INTO @DateList (DateOfMonth)
--  SELECT * FROM [tmpData]

----select * from @DateList

--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--CREATE TABLE #CodeAggregatedList 
--(
--	EmployeeID BIGINT,
--	EmployeeNo INT,
--	EmployeeName VARCHAR(200),
--	Sex varchar(20),
--	WorkingDate DATE,
--	AbbreviatedCode VARCHAR(1000)
--)

----Comma seperating abbreviation code
--INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
--SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

--(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
--   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
--   --ABB1.AbbreviationCode
	
--	FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
--) AS M

--WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
--FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
--)
--AS S
--GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


----select * from #CodeAggregatedList





----Creating dynamic pivot date list string 
--DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
--DECLARE @ColumnName AS VARCHAR(MAX)
 
--SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
--       + QUOTENAME(DateOfMonth)
--FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



----Calculate the month summary
--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

--CREATE TABLE #CalculatedList 
--(
--	EmployeeID BIGINT,
--	TotalDays decimal(18,2),
--	NameDays decimal(18,2),	
--	PluckingKgs decimal(18,2),
--	TappingL decimal(18,2),
--	SmokingS decimal(18,2),
--	OverKgs DECIMAL(18,2),
--	LowerKgs DECIMAL(18,2),
--	OverSheets DECIMAL(18,2),
--	LowerSheets DECIMAL(18,2),
--	OTHours DECIMAL(18,2),
--	BasicPay DECIMAL(18,2),
--	OverKgsPay decimal(18,2),	
--	LowerKgsPay decimal(18,2),
--	OverSheetsPay decimal(18,2),
--	LowerSheetsPay decimal(18,2),
--	SmokingSheetsPay decimal(18,2),	
--	OTPay decimal(18,2),
--	WCPay decimal(18,2),
--	EvalutionAllowance decimal(18,2),
--	GrandTotalPay decimal(18,2),
--	EPFAmount decimal(18,2),
--	PayChit decimal(18,2),
--	FestivalAdvance decimal(18,2),
--	CashAdvance decimal(18,2),
--	TotalDeductions decimal(18,2),
--	BalancePay decimal(18,2),
--	EPF_12 decimal(18,2),
--	EPF_20 decimal(18,2),
--	ETF_3 decimal(18,2),
	
--)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)
--(SELECT  TDW.EmployeeID, 

--isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

--isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
--isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

--isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

--isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

--isnull(SUM(TDW.OTHours),0) AS OTHours,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0)) AS BasicPay,


--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

--isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

--(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)   as WCPay,
 

--(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end) as EvalutionAllowance,

--((isnull(SUM( TDW.NameDays * TDW.DayRate),0)) 
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
--+
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
--+
--isnull(SUM(TDW.OTHours * TDW.OTRate),0)
--+
--(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
-- +
--(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)) as GrandTotalPay,




-------------------------------------------------------------------------------------------

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

--isnull(MAX(TDW.PayChit),0) as PayChit,

----isnull((SELECT     SUM(TDD.TDInsAmount)
----FROM         tblTermDeductionDescription AS TDD INNER JOIN
----                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
----WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
----AND isnull(TD.IsDeleted,0) <> 1
----GROUP BY TD.EmployerID

----),0) as FestivalAdvance,

--isnull((
--	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
--	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

--	group by FR.EmployerId
--),0) as FestivalAdvance,


--isnull((
--	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as CashAdvance,

--((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
--isnull(MAX(TDW.PayChit),0)+
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
--isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as TotalDeductions,

--(isnull((isnull(SUM(TDW.NameDays * TDW.DayRate),0))

-- +
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

--isnull(SUM(TDW.OTHours * TDW.OTRate),0) +

--(isnull(SUM(TDW.NameDays * TDW.WCPayRate),0)) + isnull(0,0),0)
--+
----Evalution
--(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
-- )

---
--(((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
--isnull(MAX(TDW.PayChit),0)+
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
--isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
--as BalancePay,


----------------------------------------------------------------------------------------------------

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


--FROM    tblDailyWorking TDW
--inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

--WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
--AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
--GROUP BY TDW.EmployeeID)

----select * from  #CalculatedList

--SET @DynamicPivotQuery = 'SELECT PVTTable.*,
--						 XYZ.TotalDays,
--						 XYZ.NameDays,
--						 XYZ.PluckingKgs,
--						 XYZ.TappingL,
--						 XYZ.SmokingS, 
--						 XYZ.OverKgs, 
--						 XYZ.LowerKgs,
--						 XYZ.OverSheets,
--						 XYZ.LowerSheets,
--						 XYZ.OTHours,
--						 XYZ.BasicPay,
--						 XYZ.OverKgsPay, 
--						 XYZ.LowerKgsPay,
--						 XYZ.OverSheetsPay,
--						 XYZ.LowerSheetsPay,
--						 XYZ.SmokingSheetsPay,	
--						 XYZ.OTPay,
--						 XYZ.WCPay, 
--						 XYZ.EvalutionAllowance, 
--						 XYZ.GrandTotalPay, 
--						 XYZ.EPFAmount, 
--						 XYZ.PayChit, 
--						 XYZ.FestivalAdvance, 
--						 XYZ.CashAdvance, 
--						 XYZ.TotalDeductions, 
--						 XYZ.BalancePay,
--						 XYZ.EPF_12,
--						 XYZ.EPF_20,
--						 XYZ.ETF_3  
--						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
--						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


--EXEC (@DynamicPivotQuery)


--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

GO
/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvanceCasual]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportAttendanceAdvanceCasual]

@IssueDate DATE,
@daterange INT

AS

--DECLARE @IssueDate DATE
--SET @IssueDate=  '2015-10-01'
--declare @daterange int
--set @daterange=1


declare @festivalDate date
set @festivalDate =@IssueDate

DECLARE @maxDate DATE

IF @daterange=1
BEGIN
SET @maxDate= DATEADD(d,14,@IssueDate)
END
ELSE IF @daterange=2
BEGIN
SET @IssueDate=DATEADD(d,15,@IssueDate)
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
END


--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]



--SELECT * FROM @DateList



IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex VARCHAR(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
	--ABB1.AbbreviationCode  
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList

--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	SmokingS decimal(18,2),
	OverKgs DECIMAL(18,2),
	LowerKgs DECIMAL(18,2),
	OverSheets DECIMAL(18,2),
	LowerSheets DECIMAL(18,2),
	OTHours DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	LowerKgsPay decimal(18,2),
	OverSheetsPay decimal(18,2),
	LowerSheetsPay decimal(18,2),
	SmokingSheetsPay decimal(18,2),	
	OTPay decimal(18,2),
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,


isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

isnull(SUM(TDW.OTHours),0) AS OTHours,

(isnull(SUM(TDW.NameDays * TDW.CasualPayRate),0)) AS BasicPay,

		

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

'0' as WCPay,
 

'0' as EvalutionAllowance,

-----------------------------------------------------------------------------------------
(
(isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)

) as GrandTotalPay,




--isnull((SELECT     SUM(TDD.TDInsAmount) FROM  tblTermDeductionDescription AS TDD INNER JOIN tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.ActiveDate >=@IssueDate AND TDD.ActiveDate <=@maxDate)
--AND (TD.EmployerID = TDW.EmployeeID) AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
                
--),0) as FestivalAdvance,


(Case when @daterange =1 then 0 else 
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) end) as FestivalAdvance,




isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

+
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID

--WHERE     (TDD.ActiveDate >=@IssueDate AND TDD.ActiveDate <=@maxDate) AND (TD.EmployerID = TDW.EmployeeID)

--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

(Case when @daterange =1 then 0 else 
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) end)
+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) 

+

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * 0
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * 0
when 'W' then WorkedDays * 0
when 'rs' then TDW.WorkedDays * 0
when 'SU' then TDW.WorkedDays * 0
end),0)) + isnull(0,0),0) )

-
(
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

(Case when @daterange =1 then 0 else 
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) end)

+


isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.NameDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.SmokingS, 
						 XYZ.OverKgs, 
						 XYZ.LowerKgs,
						 XYZ.OverSheets,
						 XYZ.LowerSheets,
						 XYZ.OTHours,
						 XYZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.LowerKgsPay,
						 XYZ.OverSheetsPay,
						 XYZ.LowerSheetsPay,
						 XYZ.SmokingSheetsPay,	
						 XYZ.OTPay,
						 XYZ.WCPay, 
						 XYZ.EvalutionAllowance, 
						 XYZ.GrandTotalPay, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END
GO
/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvanceCasual222]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportAttendanceAdvanceCasual222]

@IssueDate DATE,
@daterange INT

AS



--DECLARE @IssueDate DATE
--SET @IssueDate=  '2015-06-01'
--declare @daterange int
--set @daterange=2


DECLARE @maxDate DATE

IF @daterange=0
begin
	SET @IssueDate=DATEADD(d,1,@IssueDate)
	SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
end
else IF @daterange=1
BEGIN
	SET @maxDate= DATEADD(d,14,@IssueDate)
END
ELSE IF @daterange=2
BEGIN
	SET @IssueDate=DATEADD(d,15,@IssueDate)
	SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
END





--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]



--SELECT * FROM @DateList



IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex VARCHAR(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
	--ABB1.AbbreviationCode  
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList

--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	NameDays decimal(18,2),	
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	SmokingS decimal(18,2),
	OverKgs DECIMAL(18,2),
	LowerKgs DECIMAL(18,2),
	OverSheets DECIMAL(18,2),
	LowerSheets DECIMAL(18,2),
	OTHours DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	LowerKgsPay decimal(18,2),
	OverSheetsPay decimal(18,2),
	LowerSheetsPay decimal(18,2),
	SmokingSheetsPay decimal(18,2),	
	OTPay decimal(18,2),
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,NameDays,PluckingKgs,TappingL,SmokingS,OverKgs,LowerKgs,OverSheets,LowerSheets,OTHours,BasicPay,OverKgsPay,LowerKgsPay,OverSheetsPay,LowerSheetsPay,SmokingSheetsPay,OTPay, WCPay,EvalutionAllowance,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,


isnull(SUM(TDW.NameDays),0) AS NameDays,
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM((case abc.AbbreviationCode when 'RS' then TDW.Quantity  end)),0) as SmokingS,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerKgs,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) ELSE 0 END),0) AS OverSheets,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) ELSE 0 END),0) AS LowerSheets,

isnull(SUM(TDW.OTHours),0) AS OTHours,

(isnull(SUM(TDW.NameDays * TDW.CasualPayRate),0)) AS BasicPay,

		

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) as LowerKgsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) as OverSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) as LowerSheetsPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) as SmokingSheetsPay,

isnull(SUM(TDW.OTHours * TDW.OTRate),0) AS OTPay,

'0' as WCPay,
 

'0' as EvalutionAllowance,

-----------------------------------------------------------------------------------------
(
(isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)
--+
--(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
-- +
--(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
) as GrandTotalPay,


--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
                  

--),0) as FestivalAdvance,

--********************************************************************************

--isnull((SELECT     SUM(TDD.TDInsAmount) FROM         tblTermDeductionDescription AS TDD INNER JOIN tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID

--WHERE     (TDD.ActiveDate >=@IssueDate AND TDD.ActiveDate <=@maxDate)
 
--AND (TD.EmployerID = TDW.EmployeeID) AND isnull(TD.IsDeleted,0) <> 1

--GROUP BY TD.EmployerID
                  

--),0) as FestivalAdvance,
--***************************************************************************
isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

+
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID

--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
WHERE     (TDD.ActiveDate >=@IssueDate AND TDD.ActiveDate <=@maxDate) AND (TD.EmployerID = TDW.EmployeeID)

AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) 

+

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * 0
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * 0
when 'W' then WorkedDays * 0
when 'rs' then TDW.WorkedDays * 0
when 'SU' then TDW.WorkedDays * 0
end),0)) + isnull(0,0),0) )

-
(
isnull((SELECT     SUM(TDD.TDInsAmount)
FROM         tblTermDeductionDescription AS TDD INNER JOIN
tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) +
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.NameDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.SmokingS, 
						 XYZ.OverKgs, 
						 XYZ.LowerKgs,
						 XYZ.OverSheets,
						 XYZ.LowerSheets,
						 XYZ.OTHours,
						 XYZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.LowerKgsPay,
						 XYZ.OverSheetsPay,
						 XYZ.LowerSheetsPay,
						 XYZ.SmokingSheetsPay,	
						 XYZ.OTPay,
						 XYZ.WCPay, 
						 XYZ.EvalutionAllowance, 
						 XYZ.GrandTotalPay, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


--USE [iStockV22]
--GO
--/****** Object:  StoredProcedure [dbo].[ReportAttendanceAdvanceCasual]    Script Date: 02/24/2016 05:05:44 ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[ReportAttendanceAdvanceCasual]

--@IssueDate DATE,
--@daterange INT

--AS



----DECLARE @IssueDate DATE
----SET @IssueDate=  '2015-06-01'
----declare @daterange int
----set @daterange=2


--DECLARE @maxDate DATE

--IF @daterange=1
--BEGIN
--SET @maxDate= DATEADD(d,14,@IssueDate)
--END
--ELSE IF @daterange=2
--BEGIN
--SET @IssueDate=DATEADD(d,14,@IssueDate)
--SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))
--END





----Creating date from 1st of month to end of month
--DECLARE @DateList TABLE
--(
--	DateOfMonth DATE
--)

--;WITH [tmpData] AS (
--  SELECT CAST(@IssueDate AS DATE) AS dt
--  UNION ALL
--  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
--  INSERT INTO @DateList (DateOfMonth)
--  SELECT * FROM [tmpData]



----SELECT * FROM @DateList



--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--CREATE TABLE #CodeAggregatedList 
--(
--	EmployeeID BIGINT,
--	EmployeeNo INT,
--	EmployeeName VARCHAR(200),
--	Sex VARCHAR(20),
--	WorkingDate DATE,
--	AbbreviatedCode VARCHAR(1000)
--)

----Comma seperating abbreviation code
--INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
--SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

--(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
--	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
--	--ABB1.AbbreviationCode  
	
--	FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
--) AS M

--WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
--FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
--)
--AS S
--GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


----select * from #CodeAggregatedList

----Creating dynamic pivot date list string 
--DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
--DECLARE @ColumnName AS VARCHAR(MAX)
 
--SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
--       + QUOTENAME(DateOfMonth)
--FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

----Calculate the month summary
--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

--CREATE TABLE #CalculatedList 
--(
--	EmployeeID BIGINT,
--	TotalDays DECIMAL(18,2),	
--	PluckingKgs DECIMAL(18,2),
--	TappingL DECIMAL(18,2),
--	OverKgs DECIMAL(18,2),
--	DaysPay DECIMAL(18,2),
--	OverKgsPay DECIMAL(18,2),		
--	GrandTotalPay DECIMAL(18,2),	
--	FestivalAdvance DECIMAL(18,2),
--	CashAdvance DECIMAL(18,2),
--	TotalDeductions DECIMAL(18,2),
--	BalancePay DECIMAL(18,2)
	
	
--)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,DaysPay,OverKgsPay,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
--(SELECT  TDW.EmployeeID, 
--ISNULL(SUM(TDW.WorkedDays),0) AS TotalDays,
--ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'P' THEN  TDW.Quantity  END)),0) AS PluckingKgs,
--ISNULL(SUM((CASE abc.AbbreviationCode WHEN 'T' THEN TDW.Quantity  END)),0) AS TappingL,

----ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) ELSE 0 END),0) AS OverKgs,
--ISNULL(SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,


--ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0) AS DaysPay,

----ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,
--ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) AS OverKgsPay,


----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,
--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0) AS GrandTotalPay,


--ISNULL((SELECT SUM(TD.TDAmount) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--AND  ISNULL(TD.IsDeleted,0) <>1 
--GROUP BY TD.EmployerID

--),0) AS FestivalAdvance,

--ISNULL((
--	SELECT SUM(CA.AdvanceAmount) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	GROUP BY CA.EmployerId
--),0) AS CashAdvance,

--ISNULL((
	
--	(
--	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--	AND  ISNULL(TD.IsDeleted,0) <>1 
--	GROUP BY TD.EmployerID
--	)+
--	(
--	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	GROUP BY CA.EmployerId
--	)

--),0) AS TotalDeductions,

--ISNULL((

----ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0)),0)-
--ISNULL(( ISNULL(SUM(TDW.WorkedDays*TDW.CasualPayRate),0)+ISNULL((SUM(CASE WHEN abc.AbbreviationCode= 'P' AND  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0)),0)-
	
--	ISNULL((

--	(
--	SELECT ISNULL(SUM(TD.TDAmount),0) FROM tblTermDeductions TD WHERE TD.EmployerID=TDW.EmployeeID
--	AND	TD.TDDate >=@IssueDate AND TD.TDDate <=@maxDate
--	AND  ISNULL(TD.IsDeleted,0) <>1 
--	GROUP BY TD.EmployerID
--	)+
--	(
--	SELECT ISNULL( SUM(CA.AdvanceAmount),0) FROM tblCashAdvance CA WHERE CA.EmployerId=TDW.EmployeeID
--	AND	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	GROUP BY CA.EmployerId
--	)

--),0)

--),0) AS BalancePay


--FROM    tblDailyWorking TDW
--INNER JOIN tblAbbreviation ABC ON TDW.AbbreviationID=abc.AbbreviationID

--WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
--AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
--GROUP BY TDW.EmployeeID)

--SET @DynamicPivotQuery = 'SELECT PVTTable.*,XYZ.TotalDays, XYZ.PluckingKgs,XYZ.TappingL, XYZ.OverKgs, XYZ.DaysPay,XYZ.OverKgsPay, XYZ.GrandTotalPay,   XYZ.FestivalAdvance, XYZ.CashAdvance, XYZ.TotalDeductions, XYZ.BalancePay  FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
--						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


--EXEC (@DynamicPivotQuery)


--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

GO
/****** Object:  StoredProcedure [dbo].[ReportCropSummary]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportCropSummary]

--@AbreviationID BIGINT



AS

--DECLARE @AbreviationID BIGINT
--SET @AbreviationID=1

SELECT       DCS.Year as YEAR, DATENAME(MM,  DCS.CurrentDay) as MONTH, sum( DCS.FactoryCrop) as Crop, 
(sum( DCS.Rate*DCS.FactoryCrop)/(select sum( x.Rate*x.FactoryCrop) from tbleDailyCropSummary x where x.Month =DCS.Month and x.Year = DCS.Year  ))*100 Average, 

DCS.Month as MonthNo,  A.AbbreviationCode
FROM	tbleDailyCropSummary AS DCS INNER JOIN
tblAbbreviation AS A ON DCS.AbbreviationID = A.AbbreviationID
group by DCS.Month,DCS.Year, A.AbbreviationCode, DATENAME(MM,  DCS.CurrentDay)


--SELECT 
-- DATEPART(YEAR, DW.WorkingDate) AS YEAR,
-- DATENAME(MM, DW.WorkingDate) AS MONTH, 
-- --SUM(DW.Quantity) AS Crop, 
--(  select sum([FactoryCrop]) from [tbleDailyCropSummary]
--  where [Year]=DATEPART(YEAR, DW.WorkingDate) and [Month] =  Month( DW.WorkingDate) and [AbbreviationID]=AB.AbbreviationID
--  group by [Month],[Year],[AbbreviationID] ) as Crop,

--  ((  select sum([FactoryCrop] * Rate) from [tbleDailyCropSummary]
--  where [Year]=DATEPART(YEAR, DW.WorkingDate) and [Month] =  Month( DW.WorkingDate) and [AbbreviationID]=AB.AbbreviationID
--  group by [Month],[Year],[AbbreviationID] ) / 
--  (  select sum([FactoryCrop] * Rate) from [tbleDailyCropSummary]
--  where [Year]=DATEPART(YEAR, DW.WorkingDate) and [Month] =  Month( DW.WorkingDate) and [AbbreviationID]=AB.AbbreviationID
--  group by [Month],[Year] ) )*100 as Average ,

-- CONVERT(int, DATEPART(m,DW.WorkingDate)) AS MonthNo, 
-- AB.AbbreviationCode
--FROM            tblDailyWorking AS DW INNER JOIN
--                         tblAbbreviation AS AB ON DW.AbbreviationID = AB.AbbreviationID
--WHERE        (ISNULL(DW.IsDeleted, 0) <> 1) and  AB.AbbreviationCode in ('P', 'T', 'RS','SC' ) 
--GROUP BY DATEPART(YEAR, DW.WorkingDate), DATENAME(MM, DW.WorkingDate), DATEPART(month, DW.WorkingDate), AB.AbbreviationCode,AB.[AbbreviationID]
--ORDER BY YEAR, DATEPART(month, DW.WorkingDate)








--select * from [tbleDailyCropSummary]

--select * from tblAbbreviation
GO
/****** Object:  StoredProcedure [dbo].[ReportCropSummaryByMonthly]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportCropSummaryByMonthly]

@IssueDate DATE


AS


--DECLARE @IssueDate DATE
--SET @IssueDate=  '2014-09-01'

--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

SELECT     E.EmployerNo, E.EmployerName, E.Sex, E.Designation, DW.Quantity, DW.WorkingDate, ABB.AbbreviationCode,
(case AbbreviationCode when 'T' then Quantity  end) as Tapping,
(case AbbreviationCode when 'P' then Quantity  end) as Plucking,
(case AbbreviationCode when 'RS' then Quantity  end) as Sheets,
(case AbbreviationCode when 'SC' then Quantity  end) as Scrap
FROM   tblDailyWorking AS DW INNER JOIN
       tblEmployers AS E ON DW.EmployeeID = E.EmployerID 
       INNER JOIN tblAbbreviation AS ABB ON DW.AbbreviationID = ABB.AbbreviationID
       
       
WHERE     (DW.Quantity > 0) AND (ISNULL(DW.IsDeleted, 0) <> 1) AND (DW.WorkingDate >= @IssueDate) AND (DW.WorkingDate <= @maxDate)

GO
/****** Object:  StoredProcedure [dbo].[ReportFieldPerformance]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportFieldPerformance]

@AbreviationID BIGINT,
@IssueDate DATE

AS

--DECLARE @AbreviationID BIGINT
--SET @AbreviationID=1

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


SELECT      E.EmployerNo, E.EmployerName, ISNULL(SUM(DW.Quantity),0) AS Quantity
FROM         tblDailyWorking AS DW 
			INNER JOIN tblEmployers AS E ON DW.EmployeeID = E.EmployerID
WHERE DW.AbbreviationID=@AbreviationID AND  ISNULL(DW.IsDeleted,0) <>1
AND (DW.WorkingDate >= @IssueDate) AND (DW.WorkingDate <= @maxDate) 
GROUP BY  E.EmployerNo, E.EmployerName
order by Quantity DESC

GO
/****** Object:  StoredProcedure [dbo].[ReportMonthly]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportMonthly]

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
ISNULL(SUM(CASE A.AbbreviationCode WHEN 'RS' THEN  DW.Quantity END),0) AS RubberSheet,
ISNULL(SUM(CASE A.AbbreviationCode WHEN 'SC' THEN  DW.Quantity END),0) AS Scrapping
                    
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


--SELECT        Quantity as FW  FROM  tblOtherIncomes where OtherIncomeID=1 and OtherIncomeDate >=@IssueDate and OtherIncomeDate <= @maxDate


SELECT sum(FactoryCrop) as FW FROM tbleDailyCropSummary where AbbreviationID=1 and CurrentDay >=@IssueDate and CurrentDay <= @maxDate

select sum(Quantity) as RW from tblDailyWorking where AbbreviationID=1 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays)  as PLUCKER from tblDailyWorking where AbbreviationID=1 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays) as SUNDRAY from tblDailyWorking where AbbreviationID not in (1,8,21,34) and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

select sum(WorkedDays) as WATCHER from tblDailyWorking where AbbreviationID=34 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate


select sum(WorkedDays) as STAFF from tblDailyWorking where AbbreviationID=21 and WorkingDate   >=@IssueDate and WorkingDate <= @maxDate

SELECT        tblOtherIncomes.Note, tblOtherIncomes.Amount
FROM            tblOtherIncomes INNER JOIN
                         tblOtherIncomeTypes ON tblOtherIncomes.OtherIncomeTypeID = tblOtherIncomeTypes.OtherIncomeTypeID
where tblOtherIncomeTypes.OtherIncomeTypeID=2 and OtherIncomeDate >=@IssueDate and OtherIncomeDate <= @maxDate



SELECT        tblWorkDays.WorkDayID, tblWorkDays.YearName, tblWorkDaysDescription.MonthName, tblWorkDaysDescription.WorkDays
FROM            tblWorkDays INNER JOIN
                         tblWorkDaysDescription ON tblWorkDays.WorkDayID = tblWorkDaysDescription.WorkDayID

where tblWorkDays.YearName = year(@IssueDate) and tblWorkDaysDescription.MonthName=datename(month,@IssueDate)


SELECT        Note, Amount
FROM            tblExpenses
where ExpenseTypeID=13 and  ExpenseDate >=@IssueDate and ExpenseDate <= @maxDate
GO
/****** Object:  StoredProcedure [dbo].[ReportMonthlySubCasual]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportMonthlySubCasual]

@IssueDate DATE
--@daterange INT

AS


declare @festivalDate date
set @festivalDate =@IssueDate

DECLARE @maxDate DATE



SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]



--SELECT * FROM @DateList



IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex VARCHAR(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
	(CASE	ABB1.AbbreviationCode WHEN 'P' THEN CONVERT(VARCHAR(10), DW1.[Quantity]) ELSE ABB1.AbbreviationCode END) AS AbbreviationCode
	--ABB1.AbbreviationCode  
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='CASUAL' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList

--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	OverKgs DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	GrandTotalPay decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,BasicPay,OverKgsPay,GrandTotalPay,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay)
(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,
		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

(isnull(SUM(TDW.NameDays * TDW.CasualPayRate),0)) AS BasicPay,

		

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

-----------------------------------------------------------------------------------------
(
(isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)

) as GrandTotalPay,


(
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) ) as FestivalAdvance,

isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

+

(
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) )
+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(
 TDW.NameDays * TDW.CasualPayRate
),0 
)
) +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) 

+

(isnull(SUM(case abc.AbbreviationCode 
when 'P' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end)  * 0
when 'T' then (Case when TDW.Quantity>TDW.KgsPerDay then  1 else 0  end) * 0
when 'W' then WorkedDays * 0
when 'rs' then TDW.WorkedDays * 0
when 'SU' then TDW.WorkedDays * 0
end),0)) + isnull(0,0),0) )

-
(
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

(
isnull((SELECT  SUM(AdvanceAmount) FROM  tblFestivalRecovery AS FR WHERE  (FR.IssueDate >=@festivalDate AND FR.IssueDate <=@maxDate) AND (FR.EmployerID = TDW.EmployeeID) GROUP BY FR.EmployerID ),0) )

+


isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='CASUAL'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeID,
						 XYZ.TotalDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.OverKgs, 
						 xyZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.GrandTotalPay, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END
GO
/****** Object:  StoredProcedure [dbo].[ReportMonthlySubPermanent]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportMonthlySubPermanent]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	PluckingKgs decimal(18,2),
	TappingL decimal(18,2),
	OverKgs DECIMAL(18,2),
	BasicPay DECIMAL(18,2),
	OverKgsPay decimal(18,2),	
	WCPay decimal(18,2),
	EvalutionAllowance decimal(18,2),
	GrandTotalPay decimal(18,2),
	EPFAmount decimal(18,2),
	PayChit decimal(18,2),
	FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2),
	EPF_12 decimal(18,2),
	EPF_20 decimal(18,2),
	ETF_3 decimal(18,2),
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,BasicPay,OverKgsPay, WCPay,EvalutionAllowance,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)

(SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

		 
isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,

isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0)) AS BasicPay,

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,

(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)   as WCPay,
 

(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end) as EvalutionAllowance,

((isnull(SUM( TDW.NameDays * TDW.DayRate),0)) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) 
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0)
+
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0)
+
isnull(SUM(TDW.OTHours * TDW.OTRate),0)
+
(isnull(SUM(TDW.NameDays),0))*( select WCPay from tblSettings)
 +
(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)) as GrandTotalPay,




-----------------------------------------------------------------------------------------

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

isnull(MAX(TDW.PayChit),0) as PayChit,

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID

--),0) as FestivalAdvance,

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,

((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
isnull(MAX(TDW.PayChit),0)
+

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)
--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as TotalDeductions,

(isnull((isnull(SUM(TDW.NameDays * TDW.DayRate),0))

 +
isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)<TDW.KgsPerDay THEN (TDW.Quantity) * TDW.LowerKgRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)>TDW.OverSheetsUpperLimit THEN (TDW.Quantity-TDW.OverSheetsUpperLimit) * TDW.OverSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'T' and  (Quantity)<TDW.SheetsPerDay THEN (TDW.Quantity) * TDW.LowerSheetsRate ELSE 0 END)),0) +

isnull((SUM(CASE WHEN abc.AbbreviationCode= 'RS' THEN TDW.Quantity * TDW.SmokingSheetsPayRate ELSE 0 END)),0) +

isnull(SUM(TDW.OTHours * TDW.OTRate),0) +

(isnull(SUM(TDW.NameDays * TDW.WCPayRate),0)) + isnull(0,0),0)
+
--Evalution
(case when (isnull(SUM(TDW.NameDays),0))>( select IncentiveDays from tblSettings)  then ((isnull(SUM(TDW.NameDays),0))*(select EvalutionAllowance from tblSettings)) else 0 end)
 )

-
(((isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08) +
isnull(MAX(TDW.PayChit),0)+

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1 GROUP BY TD.EmployerID),0) 

isnull((
	select SUM(FR.AdvanceAmount) from tblFestivalRecovery FR where FR.EmployerId=TDW.EmployeeID
	and	FR.IssueDate >=@IssueDate AND FR.IssueDate <=@maxDate

	group by FR.EmployerId
),0)

+
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)) 
as BalancePay,


--------------------------------------------------------------------------------------------------

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeID,
						 XYZ.TotalDays,
						 XYZ.PluckingKgs,
						 XYZ.TappingL,
						 XYZ.OverKgs, 
						 XYZ.BasicPay,
						 XYZ.OverKgsPay, 
						 XYZ.WCPay, 
						 XYZ.EvalutionAllowance, 
						 XYZ.GrandTotalPay, 
						 XYZ.EPFAmount, 
						 XYZ.PayChit, 
						 XYZ.FestivalAdvance, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay,
						 XYZ.EPF_12,
						 XYZ.EPF_20,
						 XYZ.ETF_3  
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


-----------------------------------------------------------------------

--USE [Estate]
--GO
--/****** Object:  StoredProcedure [dbo].[ReportMonthlySubPermanent]    Script Date: 19/Jul/2016 10:36:23 AM ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--ALTER PROCEDURE [dbo].[ReportMonthlySubPermanent]

--@IssueDate DATE

--AS

----DECLARE @IssueDate DATE
----SET @IssueDate= '2014-05-01' 


----Gettin last date of the month
--DECLARE @maxDate DATE
--SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

----Creating date from 1st of month to end of month
--DECLARE @DateList TABLE
--(
--	DateOfMonth DATE
--)

--;WITH [tmpData] AS (
--  SELECT CAST(@IssueDate AS DATE) AS dt
--  UNION ALL
--  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
--  INSERT INTO @DateList (DateOfMonth)
--  SELECT * FROM [tmpData]


--IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CodeAggregatedList
--END

--CREATE TABLE #CodeAggregatedList 
--(
--	EmployeeID BIGINT,
--	EmployeeNo INT,
--	EmployeeName VARCHAR(200),
--	Sex VARCHAR(20),
--	WorkingDate DATE,
--	AbbreviatedCode VARCHAR(1000)
--)

----Comma seperating abbreviation code
--INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
--SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

--(SELECT   STUFF(( SELECT  DISTINCT'],[' + [AbbreviationCode] FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
--) AS M

--WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]
--FROM 

--(
--	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
--	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
--	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
--	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='PERMANENT' AND
--	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
--)
--AS S
--GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


----Creating dynamic pivot date list string 
--DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
--DECLARE @ColumnName AS VARCHAR(MAX)
 
--SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
--       + QUOTENAME(DateOfMonth)
--FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth

----Calculate the month summary
--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

--CREATE TABLE #CalculatedList 
--(
--	EmployeeID BIGINT,
--	TotalDays decimal(18,2),	
--	PluckingKgs decimal(18,2),
--	TappingL decimal(18,2),
--	OverKgs DECIMAL(18,2),
--	PluckingOrTappingPay DECIMAL(18,2),
--	OverKgsPay decimal(18,2),	
--	WCPay decimal(18,2),
--	DevalutionAllowance decimal(18,2),
--	GrandTotalPay decimal(18,2),
--	EPFAmount decimal(18,2),
--	PayChit decimal(18,2),
--	FestivalAdvance decimal(18,2),
--	CashAdvance decimal(18,2),
--	TotalDeductions decimal(18,2),
--	BalancePay decimal(18,2),
--	EPF_12 decimal(18,2),
--	EPF_20 decimal(18,2),
--	ETF_3 decimal(18,2),
	
--)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,PluckingKgs,TappingL,OverKgs,PluckingOrTappingPay,OverKgsPay,WCPay,DevalutionAllowance,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)
--(SELECT  TDW.EmployeeID, 
--isnull(SUM(TDW.WorkedDays),0) AS TotalDays,
--isnull(SUM((case abc.AbbreviationCode when 'P' then  TDW.Quantity  end)),0) as PluckingKgs,
--isnull(SUM((case abc.AbbreviationCode when 'T' then TDW.Quantity  end)),0) as TappingL,

----isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) ELSE 0 END),0) AS OverKgs,
--isnull(SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) ELSE 0 END),0) AS OverKgs,

--isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) AS TappingOrPluckingsPay,

----isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,
--isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0) as OverKgsPay,


--isnull(SUM(TDW.WorkedDays*TDW.WCPayRate),0) AS WCPay,
--isnull((case when SUM(TDW.WorkedDays)>=MAX( TDW.DevaluationDays) then SUM(TDW.WorkedDays)* max(TDW.DevalutionRate) end),0) AS DevalutionAllowance,

----isnull(( isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) + isnull(SUM(TDW.WorkedDays*isnull(TDW.WCPayRate,0)) ,0)+ISNULL((case when SUM(TDW.WorkedDays)>=isnull(MAX( TDW.DevaluationDays),0) then  isnull(SUM(TDW.WorkedDays),0)* isnull(max(TDW.DevalutionRate),0) end),0))+isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.KgsPerDay THEN (TDW.Quantity-TDW.KgsPerDay) * TDW.OverKgRate ELSE 0 END)),0),0) as GrandTotalPay,
--isnull(( isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) + isnull(SUM(TDW.WorkedDays*isnull(TDW.WCPayRate,0)) ,0)+ISNULL((case when SUM(TDW.WorkedDays)>=isnull(MAX( TDW.DevaluationDays),0) then  isnull(SUM(TDW.WorkedDays),0)* isnull(max(TDW.DevalutionRate),0) end),0))+isnull((SUM(CASE WHEN abc.AbbreviationCode= 'P' and  (Quantity)>TDW.OverKGUpperLimit THEN (TDW.Quantity-TDW.OverKGUpperLimit) * TDW.OverKgRate ELSE 0 END)),0),0) as GrandTotalPay,


--isnull((( SUM( isnull(TDW.WorkedDays,0)* isnull(TDW.DayRate,0))* isnull(MAX(TDW.EPF),0))/100),0) as EPFAmount,
--isnull(MAX(TDW.PayChit),0) as PayChit,

--isnull((SELECT     SUM(TDD.TDInsAmount)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--                      tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
                  

--),0) as FestivalAdvance,

--isnull((
--	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

--	group by CA.EmployerId
--),0) as CashAdvance,

--isnull((
--	isnull(((SUM(TDW.WorkedDays*TDW.DayRate)*MAX(TDW.EPF))/100),0)+
--	isnull(MAX(TDW.PayChit),0)+
--	(
--	SELECT   isnull(  SUM(TDD.TDInsAmount),0)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--          tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
--	)+
--	(
--	isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	group by CA.EmployerId),0)
--	)

--),0) as TotalDeductions,

--isnull((

--isnull(( isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) + isnull(SUM(TDW.WorkedDays*isnull(TDW.WCPayRate,0)) ,0)+ISNULL((case when SUM(TDW.WorkedDays)>=isnull(MAX( TDW.DevaluationDays),0) then  isnull(SUM(TDW.WorkedDays),0)* isnull(max(TDW.DevalutionRate),0) end),0)),0)-
	
--	isnull((
--	isnull(((SUM(TDW.WorkedDays*TDW.DayRate)*MAX(TDW.EPF))/100),0)+
--	isnull(MAX(TDW.PayChit),0)+
--	(
--	SELECT   isnull(  SUM(TDD.TDInsAmount),0)
--FROM         tblTermDeductionDescription AS TDD INNER JOIN
--          tblTermDeductions AS TD ON TDD.TermDeductionID = TD.TermDeductionID
--WHERE     (TDD.TDMonthName = LEFT(DATENAME(month, @IssueDate), 3) + '-' + CONVERT(varchar(10), YEAR(@IssueDate))) AND (TD.EmployerID = TDW.EmployeeID)
--AND isnull(TD.IsDeleted,0) <> 1
--GROUP BY TD.EmployerID
--	)+
--	(
--	isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
--	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate
--	group by CA.EmployerId),0)
--	)

--),0)

--),0) as BalancePay,
--((isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) * 12.00)/100) as EPF_12,
--((isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) * 20.00)/100) as EPF_20,
--((isnull(SUM(TDW.WorkedDays*TDW.DayRate),0) * 3.00)/100) as ETF_3


--FROM    tblDailyWorking TDW
--inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

--WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
--AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='PERMANENT'
--GROUP BY TDW.EmployeeID)


--SELECT *  FROM #CalculatedList

--IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
--BEGIN
--    DROP TABLE #CalculatedList
--END

GO
/****** Object:  StoredProcedure [dbo].[ReportMonthlySubStaff]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportMonthlySubStaff]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	GrandTotalPay decimal(18,2),
	--EPFAmount decimal(18,2),
	--PayChit decimal(18,2),
	--FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2)
	--EPF_12 decimal(18,2),
	--EPF_20 decimal(18,2),
	--ETF_3 decimal(18,2),
	
)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,CashAdvance,TotalDeductions,BalancePay)

(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0)) as GrandTotalPay,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

--isnull(MAX(TDW.PayChit),0) as PayChit,


--isnull((
--	select SUM(FS.AdvanceAmount) from tblFestivalRecovery FS where FS.EmployerId=TDW.EmployeeID
--	and	FS.IssueDate >=@IssueDate AND FS.IssueDate <=@maxDate

--	group by FS.EmployerId
--),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,


(isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0)) as TotalDeductions,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0))

-
(
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)
) 
as BalancePay


--------------------------------------------------------------------------------------------------

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='STAFF'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.EmployeeID,
						 XYZ.TotalDays,
						 XYZ.GrandTotalPay, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


GO
/****** Object:  StoredProcedure [dbo].[Routes_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Routes_Delete] 
    @RouteID int
AS 
	
	UPDATE [dbo].[tblRoutes]
	SET [IsActive]=0
	WHERE  [RouteID] = @RouteID

GO
/****** Object:  StoredProcedure [dbo].[Routes_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Routes_GetAll] 
   
AS 
	

	SELECT [RouteID], [RouteName] 
	FROM   [dbo].[tblRoutes] 
	WHERE IsActive=1

GO
/****** Object:  StoredProcedure [dbo].[Routes_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Routes_GetByID] 
   @RouteID int
AS 
	

	SELECT [RouteID], [RouteName] 
	FROM   [dbo].[tblRoutes] 
	WHERE IsActive=1 AND [RouteID]=@RouteID

GO
/****** Object:  StoredProcedure [dbo].[Routes_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Routes_Insert] 
    @RouteID INT,
    @RouteName NVARCHAR(50)
AS 
	
	IF EXISTS(SELECT * FROM [tblRoutes] WHERE RouteID=@RouteID)
	
	BEGIN
		UPDATE [dbo].[tblRoutes]
		SET    [RouteName] = @RouteName
		WHERE  [RouteID] = @RouteID
	END
		
	ELSE
	
	BEGIN
		INSERT INTO [dbo].[tblRoutes] 
		([RouteName], [IsActive])
		VALUES (@RouteName,1)
		
	END

GO
/****** Object:  StoredProcedure [dbo].[Routes_IsExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Routes_IsExists] 
	@RouteID int  
AS 
	

	SELECT [RouteID], [RouteName] 
	FROM   [dbo].[tblRoutes] 
	WHERE IsActive=1

GO
/****** Object:  StoredProcedure [dbo].[RubberSheetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RubberSheetByDates]

@DailyWorkingID bigint

AS


	UPDATE [dbo].[tblDailyWorking]
	SET IsDeleted=1
	WHERE  [DailyWorkingID] = @DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[Sales_GetByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_GetByDates]

@FromDate datetime,
@ToDate datetime

AS
SELECT     tblSales.SalesID, tblSales.CustomerID, tblSales.ReferenceNo, tblSales.SalesDate, tblSales.Total, tblSales.Percentage, tblSales.Tax, tblSales.Discount,
                       tblSales.Note, tblSales.Paid, tblCustomers.CustomerName, tblSales.CreatedDate, tblSales.UpdatedDate, 
                       tblCustomers.CustomerNo, tblUserLogin.UserName AS CreatedBy, 
                      tblUserLogin_1.UserName AS UpdatedBy, tblSales.SalesNo, tblSales.GrandTotal, 
                      vwSalesCollection.AmountPaid, 
                      vwSalesCollection.Balance, tblSales.MessageID, tblMessages.Message
FROM         vwSalesCollection RIGHT OUTER JOIN
                      tblSales LEFT OUTER JOIN
                      tblMessages ON tblSales.MessageID = tblMessages.MessageID ON vwSalesCollection.SalesID = tblSales.SalesID LEFT OUTER JOIN

                      
                      tblUserLogin AS tblUserLogin_1 ON tblSales.UpdatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblUserLogin ON tblSales.CreatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
                      tblCustomers ON tblSales.CustomerID = tblCustomers.CustomerID
WHERE     (tblSales.SalesDate >= @FromDate) AND (tblSales.SalesDate <= @ToDate)
ORDER BY tblSales.SalesID desc

GO
/****** Object:  StoredProcedure [dbo].[Sales_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_GetByID]

@SalesID bigint

AS

SELECT     SalesID, CustomerID, ReferenceNo, SalesDate, Total, Percentage, Tax, Discount, Note, Paid, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, 
                       SalesNo, GrandTotal, MessageID
FROM         tblSales
WHERE     (SalesID = @SalesID)

GO
/****** Object:  StoredProcedure [dbo].[Sales_GetByReferenceNoCustomerAndDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_GetByReferenceNoCustomerAndDates]


@FromDate datetime,
@ToDate datetime,
@CustomerID bigint,
@ReferenceNo nvarchar(20)


AS


SELECT     tblSales.SalesID, tblSales.SalesNo, tblCustomers.CustomerName, tblCustomers.CustomerNo, tblCustomers.Salutation, tblCustomers.CustomerID, 
                      tblSales.ReferenceNo, tblSales.SalesDate, tblSales.Total, tblSales.Percentage, tblSales.Tax, tblSales.Discount, tblSales.GrandTotal
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblSales.CustomerID = tblCustomers.CustomerID
WHERE     (tblSales.ReferenceNo = @ReferenceNo AND tblCustomers.CustomerID= @CustomerID AND tblSales.SalesDate>=@FromDate AND tblSales.SalesDate<=@ToDate )
Order By tblSales.SalesID, tblSales.SalesNo ASC


SELECT     tblSales.SalesID, tblSales.SalesNo, tblCustomers.CustomerName, tblCustomers.CustomerNo, tblCustomers.Salutation, tblCustomers.CustomerID, 
                      tblSales.ReferenceNo, tblSales.SalesDate, tblSales.Total, tblSales.Percentage, tblSales.Tax, tblSales.Discount, tblSales.GrandTotal
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblSales.CustomerID = tblCustomers.CustomerID
WHERE     (tblSales.CustomerID = @CustomerID AND tblSales.SalesDate>=@FromDate AND tblSales.SalesDate<=@ToDate )
Order By tblSales.SalesID, tblSales.SalesNo ASC




SELECT     tblSales.SalesID, tblSales.SalesNo, tblCustomers.CustomerName, tblCustomers.CustomerNo, tblCustomers.Salutation, tblCustomers.CustomerID, 
                      tblSales.ReferenceNo, tblSales.SalesDate, tblSales.Total, tblSales.Percentage, tblSales.Tax, tblSales.Discount, tblSales.GrandTotal
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblSales.CustomerID = tblCustomers.CustomerID
WHERE     (tblSales.ReferenceNo = @ReferenceNo AND  tblSales.SalesDate>=@FromDate AND tblSales.SalesDate<=@ToDate )
Order By tblSales.SalesID, tblSales.SalesNo ASC

GO
/****** Object:  StoredProcedure [dbo].[Sales_GetStockItemsByDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_GetStockItemsByDates]


@FromDate datetime,
@ToDate datetime


AS 

SELECT     S.SalesID, S.SalesNo, S.SalesDate, C.CustomerName, SD.StockID, SD.UnitPrice, SD.Quantity, SD.BagWeight, SD.NoOfBags, SD.Discount, SD.Value, ST.StockCode, 
                      ST.[Description]
FROM         tblSales AS S INNER JOIN
                      tblSalesDescription AS SD ON S.SalesID = SD.SalesID INNER JOIN
                      tblCustomers AS C ON S.CustomerID = C.CustomerID INNER JOIN
                      tblStock AS ST ON SD.StockID = ST.StockID
WHERE     (S.SalesDate >= @FromDate) AND (S.SalesDate <= @ToDate)
ORDER BY S.SalesID

GO
/****** Object:  StoredProcedure [dbo].[Sales_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_Insert]
	(@SalesID BIGINT,
	 @CustomerID 	BIGINT,
	 @ReferenceNo 	NVARCHAR(20),
	 @SalesDate 	DATETIME,

	 @Total 	MONEY,
	 @Percentage	MONEY,
	@GrandTotal MONEY,
	 @Tax		MONEY,
	 @Discount 	MONEY,
	 @Note 	NTEXT,
	 @Paid 	BIT,
	@MessageID BIGINT,
	 @CurrentSalesID BIGINT OUTPUT
	 ,@CreatedBy BIGINT
	,@UpdatedBy BIGINT)

AS 
IF EXISTS
		(SELECT [SalesID] FROM tblSales WHERE [SalesID]=@SalesID)


		BEGIN
		UPDATE [tblSales] 

		SET  [CustomerID]	 = @CustomerID,
			 [ReferenceNo]	 = @ReferenceNo,
			 [SalesDate]	 = @SalesDate,
			
			 [Total]	 = @Total,
			 [Discount]	 = @Discount,
			[GrandTotal]=@GrandTotal,
			 [Percentage]=@Percentage,
			 [Tax]=@Tax,
			
			 [Note]	 = @Note,
			 [Paid]	 = @Paid,
	
	 
		[MessageID]=@MessageID
			,[UpdatedBy] = @UpdatedBy
			,[UpdatedDate] = GETDATE()
		
		WHERE 
			( [SalesID]	 = @SalesID)

		SET @CurrentSalesID=-1
		END

ELSE
BEGIN
DECLARE @SalesNo BIGINT
SET @SalesNo=(SELECT COUNT(CustomerID)+1 FROM tblSales)
INSERT INTO [tblSales] 
	 ([CustomerID],
		[SalesNo],
	 [ReferenceNo],
	 [SalesDate],
	
	 [Total],
	 [Percentage],
	 [Tax],
	 [Discount],

		
	[GrandTotal],
	 [Note],
	 [Paid],

[MessageID],
  [CreatedBy]
 ,[CreatedDate]) 
 
VALUES 
	(@CustomerID,
	@SalesNo,
     @ReferenceNo,
	 @SalesDate,
	
	 @Total,
	 @Percentage,
	 @Tax,
	 @Discount,
	 @GrandTotal,
	 @Note,
	 @Paid,
	
	@MessageID,
	@CreatedBy
		,GETDATE())
SET @CurrentSalesID=SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [dbo].[Sales_SetAsPaid]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_SetAsPaid]
	@SalesID bigint,
	@UpdatedBy bigint
	

AS 
	

		Update tblSales
		Set
		[Paid] = 1,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = getdate()
	Where		
		[SalesID] = @SalesID

GO
/****** Object:  StoredProcedure [dbo].[Sales_Settled_Bills]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sales_Settled_Bills]


 AS

SELECT     tblSales.SalesID, tblCustomers.CustomerName, tblSales.SalesDate, tblSales.Total, tblSales.Tax, tblSales.Discount,
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS AmountPaid, tblSales.Total - tblSales.Discount -
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections AS tblCollections_1
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS Balance, tblCustomers.CustomerNo, tblSales.GrandTotal, 
                      tblSales.SalesNo
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblCustomers.CustomerID = tblSales.CustomerID
WHERE     (tblSales.Paid = 1)
ORDER BY tblSales.SalesID

GO
/****** Object:  StoredProcedure [dbo].[Sales_Unsettled_Bills]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sales_Unsettled_Bills]


 AS

SELECT     tblSales.SalesID, tblCustomers.CustomerName, tblSales.SalesDate, tblSales.Total, tblSales.Tax, tblSales.Discount,
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS AmountPaid, tblSales.Total - tblSales.Discount -
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections AS tblCollections_1
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS Balance, tblCustomers.CustomerNo, tblSales.GrandTotal, 
                      tblSales.CustomerID, tblSales.SalesNo
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblCustomers.CustomerID = tblSales.CustomerID
WHERE     (tblSales.Paid = 0)
ORDER BY tblSales.SalesID

GO
/****** Object:  StoredProcedure [dbo].[Sales_Unsettled_Bills_GeyByCustomerIDAndDates]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sales_Unsettled_Bills_GeyByCustomerIDAndDates]

@CustomerID bigint,
@FromDate datetime,
@ToDate datetime
 AS
SELECT     tblSales.SalesID, tblCustomers.CustomerName, tblSales.SalesDate, tblSales.Total, tblSales.Tax, tblSales.Discount,
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS AmountPaid, tblSales.Total - tblSales.Discount -
                          (SELECT     ISNULL(SUM(Amount), 0.00) AS Expr1
                            FROM          tblCollections AS tblCollections_1
                            WHERE      (TransactionTypeID = 2) AND (SystemID = tblSales.SalesID)) AS Balance, tblCustomers.CustomerNo, tblSales.GrandTotal, 
                      tblSales.CustomerID, tblSales.ReferenceNo, tblSales.SalesNo
FROM         tblSales LEFT OUTER JOIN
                      tblCustomers ON tblCustomers.CustomerID = tblSales.CustomerID
WHERE     (tblSales.Paid = 0) AND (tblCustomers.CustomerID = @CustomerID) AND tblSales.SalesDate>=@FromDate AND tblSales.SalesDate<=@ToDate
ORDER BY tblSales.SalesID

GO
/****** Object:  StoredProcedure [dbo].[Sales_UpdateDiscount]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Sales_UpdateDiscount]
	@SalesID bigint,
	@Percentage money,
	@Discount money,
	@GrandTotal money,
	@UpdatedBy bigint
	

AS 
	

		Update tblSales
		Set
		[Percentage] = @Percentage,
		[Discount]=@Discount,
		[GrandTotal]=@GrandTotal,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = getdate()
	Where		
		[SalesID] = @SalesID

GO
/****** Object:  StoredProcedure [dbo].[SalesDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesDescription_Delete]

@SalesID bigint

AS

DELETE FROM [dbo].[tblSalesDescription]
      WHERE [SalesID]=@SalesID

GO
/****** Object:  StoredProcedure [dbo].[SalesDescription_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesDescription_GetByID]

@SalesID bigint

AS

SELECT     tblSalesDescription.SalesID, tblSalesDescription.StockID, tblSalesDescription.UnitPrice, tblSalesDescription.Quantity, tblSalesDescription.Discount, 
           tblSalesDescription.Value, tblStock.StockCode, tblStock.Description, tblSalesDescription.PurchasingPrice,
		   tblSalesDescription.BagWeight, tblSalesDescription.NoOfBags	                      
                      
FROM         tblSalesDescription LEFT OUTER JOIN
                      tblStock ON tblSalesDescription.StockID = tblStock.StockID
WHERE     (tblSalesDescription.SalesID = @SalesID)

GO
/****** Object:  StoredProcedure [dbo].[SalesDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SalesDescription_Insert] 
@SalesID bigint,
@StockID bigint,
@UnitPrice money,
@PurchasingPrice money,
@Quantity float,
@BagWeight FLOAT,
@NoOfBags FLOAT,
@Discount money,
@Value money
AS

INSERT INTO [dbo].[tblSalesDescription]
           ([SalesID]
           ,[StockID]
           ,[UnitPrice]
		   ,[PurchasingPrice]	
           ,[Quantity]
           ,[BagWeight]
		   ,[NoOfBags]
           ,[Discount]
           ,[Value])
     VALUES
          (
			@SalesID ,
			@StockID ,
			@UnitPrice ,
			@PurchasingPrice,
			@Quantity ,
			 @BagWeight,
			@NoOfBags,
			@Discount ,
			@Value )

GO
/****** Object:  StoredProcedure [dbo].[Settings_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Settings_GetAll]

AS

SELECT     SettingsID, DayRate, OTRate, CasualPayRate, CasualOTPayRate, PayChitCost, EvalutionAllowance, IncentiveDays, WCPay, EPF, ETF, KgsPerDay, 
                      KgsPerDayNotMandatory, OverKgRate, OverKGUpperLimit, LowerKgRate, SheetsPerDay, OverSheetsRate, OverSheetsUpperLimit, LowerSheetsRate, CreatedBy, 
                      CreatedDate, UpdatedBy, UpdatedDate, SmokingSheetsPayRate
FROM         tblSettings
GO
/****** Object:  StoredProcedure [dbo].[Settings_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Settings_Insert]



	@DayRate decimal(18,2) = NULL,
    @OTRate decimal(18,2) = NULL,    
    @CasualPayRate	decimal(18,2)=NULL,
	@CasualOTPayRate	decimal(18,2)=NULL,
	@PayChitCost decimal(18,2) = NULL,
    @EvalutionAllowance decimal(18,2) = NULL,
    @IncentiveDays decimal(18,2) = NULL, 
	@WCPay	decimal(18,2)=NULL,
	@EPF	decimal(18,2)=NULL,
	@ETF	decimal(18,2)=NULL,
	@KgsPerDay decimal(18,2) = NULL,
    @KgsPerDayNotMandatory decimal(18,2)= null,
    @OverKgRate	decimal(18,2)=NULL,
	@OverKGUpperLimit decimal(18,2)=null,
	@LowerKgRate decimal(18,2)=NULL,
	@SheetsPerDay decimal(18,2) = NULL,
    @OverSheetsRate decimal(18,2)= null,
    @OverSheetsUpperLimit decimal(18,2) = NULL,   
    @LowerSheetsRate decimal(18,2)=null,
	@SmokingSheetsPayRate decimal(18,2)=null,
	@CreatedBy	bigint=NULL,
	@CreatedDate	datetime=NULL,
	@UpdatedBy	bigint=NULL,
	@UpdatedDate	datetime=NULL




    
	
AS

if (select count(paychitcost) from tblSettings )>0

	begin
	UPDATE [dbo].[tblSettings]
	
	SET    
	[DayRate] = @DayRate, 
	[OTRate] = @OTRate,
	[CasualPayRate]=@CasualPayRate,
	[CasualOTPayRate]=@CasualOTPayRate,
	[PayChitCost] = @PayChitCost, 
	[EvalutionAllowance] = @EvalutionAllowance, 
	[IncentiveDays] = @IncentiveDays, 
	[WCPay]=@WCPay,
	[EPF]=@EPF,
	[ETF]=@ETF, 
	[KgsPerDay] = @KgsPerDay, 
	[KgsPerDayNotMandatory] =@KgsPerDayNotMandatory,
	[OverKgRate]=@OverKgRate,
	[OverKGUpperLimit]=@OverKGUpperLimit,
	[LowerKgRate]=@LowerKgRate,
	[SheetsPerDay]=@SheetsPerDay,
	[OverSheetsRate]=@OverSheetsRate,
	[OverSheetsUpperLimit]=@OverSheetsUpperLimit,
	[LowerSheetsRate]=@LowerSheetsRate,
	[SmokingSheetsPayRate]=@SmokingSheetsPayRate,
	[UpdatedBy]=@UpdatedBy,
	[UpdatedDate]=GETDATE()
	
	end

else

INSERT INTO [dbo].[tblSettings] 
(

[DayRate],[OTRate],[CasualPayRate],[CasualOTPayRate],[PayChitCost],[EvalutionAllowance],
[IncentiveDays],[WCPay],[EPF],[ETF],[KgsPerDay],[KgsPerDayNotMandatory],[OverKgRate],[OverKGUpperLimit],
[LowerKgRate],[SheetsPerDay],[OverSheetsRate],[OverSheetsUpperLimit],[SmokingSheetsPayRate],[LowerSheetsRate],[CreatedBy],[CreatedDate]

)

VALUES
(  
@DayRate,@OTRate,@CasualPayRate,@CasualOTPayRate,@PayChitCost,@EvalutionAllowance,
@IncentiveDays,@WCPay,@EPF,@ETF,@KgsPerDay,@KgsPerDayNotMandatory,@OverKgRate,@OverKGUpperLimit,
@LowerKgRate,@SheetsPerDay,@OverSheetsRate,@OverSheetsUpperLimit,@SmokingSheetsPayRate,@LowerSheetsRate,@CreatedBy,GETDATE()
)
         

GO
/****** Object:  StoredProcedure [dbo].[StaffPay_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StaffPay_Delete]
	@StaffPayID	bigint

AS DELETE tblStaffPay

WHERE 
	StaffPayID=@StaffPayID

GO
/****** Object:  StoredProcedure [dbo].[StaffPay_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_Insert
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for inserting values to tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[StaffPay_GetAll]
	
As

SELECT     S.StaffPayID, S.EmployerID, E.EmployerNo, E.EmployerName, S.PayDate, S.Amount
FROM         tblEmployers AS E RIGHT OUTER JOIN
                      tblStaffPay AS S ON E.EmployerID = S.EmployerID
GO
/****** Object:  StoredProcedure [dbo].[StaffPay_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblEmployers_Insert
-- Author:	Mehdi Keramati
-- Create date:	10/2/2009 3:59:01 PM
-- Description:	This stored procedure is intended for inserting values to tblEmployers table
-- ==========================================================================================
CREATE Procedure [dbo].[StaffPay_Insert]
	@StaffPayID bigint,
	@EmployerID bigint,
	@PayDate datetime,
	@Amount decimal(18,2),
	@CreatedBy bigint,
	@UpdatedBy bigint,
	@Department nvarchar(20)
	
As

if exists

(Select [StaffPayID] From tblStaffPay Where [StaffPayID]=@StaffPayID)

	begin
Update tblStaffPay
	Set
		[EmployerID] = @EmployerID,
		[PayDate] = @PayDate,
		[Amount] = @Amount,
		[Department]=@Department,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] =getdate()
	Where		
		[StaffPayID] = @StaffPayID

	end

else



Begin
	Insert Into tblStaffPay
		([EmployerID],[PayDate],[Amount],[Department],[CreatedBy],[CreatedDate])
	Values
		(@EmployerID,@PayDate,@Amount, @Department,@CreatedBy,getdate())
		

	Declare @ReferenceID int
	Select @ReferenceID = @@IDENTITY

	Return @ReferenceID

End


select * from tblStaffPay
GO
/****** Object:  StoredProcedure [dbo].[StaffPaysheet]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StaffPaysheet]

@IssueDate DATE

AS


--Gettin last date of the month
DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))

--Creating date from 1st of month to end of month
DECLARE @DateList TABLE
(
	DateOfMonth DATE
)

;WITH [tmpData] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM tmpData s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (DateOfMonth)
  SELECT * FROM [tmpData]

--select * from @DateList

IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

CREATE TABLE #CodeAggregatedList 
(
	EmployeeID BIGINT,
	EmployeeNo INT,
	EmployeeName VARCHAR(200),
	Sex varchar(20),
	WorkingDate DATE,
	AbbreviatedCode VARCHAR(1000)
)

--Comma seperating abbreviation code
INSERT INTO #CodeAggregatedList (EmployeeID, EmployeeNo, EmployeeName, Sex, WorkingDate, AbbreviatedCode)
SELECT S.EmployeeID,S.EmployerNo, S.EmployerName, S.Sex, S.WorkingDate, 

(SELECT   STUFF(( SELECT  DISTINCT',' + [AbbreviationCode] FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName, E.Sex, DW1.WorkingDate,  
	
   (case	ABB1.AbbreviationCode when 'P' then convert(varchar(10), DW1.[Quantity]) else ABB1.AbbreviationCode end) as AbbreviationCode
   --ABB1.AbbreviationCode
	
	FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
	
) AS M

WHERE WorkingDate=S.WorkingDate AND EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 1, '') + '') AS [AbbreviatedCode]
FROM 

(
	SELECT DW1.EmployeeID, E.EmployerNo, E.EmployerName,E.Sex, DW1.WorkingDate,  ABB1.AbbreviationCode  FROM tblDailyWorking DW1 
	INNER JOIN tblAbbreviation ABB1 ON ABB1.AbbreviationID=DW1.AbbreviationID
	INNER JOIN tblEmployers E ON DW1.EmployeeID=E.EmployerID
	WHERE ISNULL( DW1.IsDeleted,0) <> 1 AND WorkType='STAFF' AND
	DW1.WorkingDate >=@IssueDate AND DW1.WorkingDate <=@maxDate
)
AS S
GROUP BY S.EmployeeID, S.EmployerNo, S.EmployerName,S.Sex, S.WorkingDate 


--select * from #CodeAggregatedList





--Creating dynamic pivot date list string 
DECLARE @DynamicPivotQuery AS VARCHAR(MAX)
DECLARE @ColumnName AS VARCHAR(MAX)
 
SELECT @ColumnName= ISNULL(@ColumnName + ',','') 
       + QUOTENAME(DateOfMonth)
FROM (SELECT DateOfMonth FROM @DateList) AS DateOfMonth



--Calculate the month summary
IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END

CREATE TABLE #CalculatedList 
(
	EmployeeID BIGINT,
	TotalDays decimal(18,2),
	GrandTotalPay decimal(18,2),
	--EPFAmount decimal(18,2),
	--PayChit decimal(18,2),
	--FestivalAdvance decimal(18,2),
	CashAdvance decimal(18,2),
	TotalDeductions decimal(18,2),
	BalancePay decimal(18,2)
	--EPF_12 decimal(18,2),
	--EPF_20 decimal(18,2),
	--ETF_3 decimal(18,2),
	
)

--INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,EPFAmount,PayChit,FestivalAdvance,CashAdvance,TotalDeductions,BalancePay,EPF_12,EPF_20,ETF_3)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,GrandTotalPay,CashAdvance,TotalDeductions,BalancePay)

(

SELECT  TDW.EmployeeID, 

isnull(SUM(TDW.WorkedDays),0) AS TotalDays,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0)) as GrandTotalPay,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.08 AS EPFAmount,

--isnull(MAX(TDW.PayChit),0) as PayChit,


--isnull((
--	select SUM(FS.AdvanceAmount) from tblFestivalRecovery FS where FS.EmployerId=TDW.EmployeeID
--	and	FS.IssueDate >=@IssueDate AND FS.IssueDate <=@maxDate

--	group by FS.EmployerId
--),0) as FestivalAdvance,


isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0) as CashAdvance,


(isnull((
	select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
	and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate

	group by CA.EmployerId
),0)) as TotalDeductions,

(isnull((
	select SUM(SP.Amount) from tblStaffPay SP where SP.EmployerId=TDW.EmployeeID
	and	SP.PayDate >=@IssueDate AND SP.PayDate <=@maxDate

	group by SP.EmployerId
),0))

-
(
isnull((select SUM(CA.AdvanceAmount) from tblCashAdvance CA where CA.EmployerId=TDW.EmployeeID
and	CA.IssueDate >=@IssueDate AND CA.IssueDate <=@maxDate group by CA.EmployerId ),0)
) 
as BalancePay


--------------------------------------------------------------------------------------------------

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.12 AS EPF_12,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.20 AS EPF_20,

--(isnull(SUM( TDW.NameDays * TDW.DayRate),0))*0.03 AS ETF_3


FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 AND TDW.WorkType='STAFF'
GROUP BY TDW.EmployeeID)

--select * from  #CalculatedList

SET @DynamicPivotQuery = 'SELECT PVTTable.*,
						 XYZ.TotalDays,
						 XYZ.GrandTotalPay, 
						 XYZ.CashAdvance, 
						 XYZ.TotalDeductions, 
						 XYZ.BalancePay
						 FROM #CodeAggregatedList as X PIVOT ( MAX(X.AbbreviatedCode) FOR X.WorkingDate IN (' + @ColumnName + ')) AS PVTTable
						 Inner join #CalculatedList XYZ ON  XYZ.EmployeeID=PVTTable.EmployeeID '


EXEC (@DynamicPivotQuery)


IF OBJECT_ID(N'tempdb..#CodeAggregatedList') IS NOT NULL
BEGIN
    DROP TABLE #CodeAggregatedList
END

IF OBJECT_ID(N'tempdb..#CalculatedList') IS NOT NULL
BEGIN
    DROP TABLE #CalculatedList
END


GO
/****** Object:  StoredProcedure [dbo].[Stock_AddFromSales]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_AddFromSales]
		@SalesID bigint


AS 
	
IF  NOT  EXISTS
	(SELECT [SalesID] FROM tblSales WHERE [SalesID]=@SalesID)
	return 1

else

	begin
	UPDATE [tblStock]

	SET tblStock.[CurrentStockBalance] = tblStock.[CurrentStockBalance] + (SELECT sum( tblSalesDescription.[Quantity]) From tblSalesDescription Where tblStock.[StockID] =tblSalesDescription.[StockID] AND tblSalesDescription.[SalesID]=@SalesID),

	tblStock.[CurrentStockValue]= tblStock.[CurrentStockValue]+(SELECT  sum( [PurchasingPrice]*tblSalesDescription.[Quantity]) From tblSalesDescription Where tblStock.[StockID] =tblSalesDescription.[StockID] AND tblSalesDescription.[SalesID]=@SalesID  )

 FROM tblStock,tblSalesDescription Where tblStock.[StockID] =tblSalesDescription.[StockID] AND tblSalesDescription.[SalesID]=@SalesID
	end

GO
/****** Object:  StoredProcedure [dbo].[Stock_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_Delete]
	@StockID BIGINT
AS
UPDATE tblStock
SET IsDeleted=1
WHERE [StockID]=@StockID

GO
/****** Object:  StoredProcedure [dbo].[Stock_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_GetAll]

AS

SELECT     tblStock.StockID, tblStock.StockCode, tblStock.Description, tblStock.StockCategoryID, tblStock.PurchasingPrice, tblStock.StockType, tblStock.SalesPrice, 
                      tblStock.SupplierID, tblStock.ReorderLevel, tblStock.OpeningStockBalance, tblStock.OpeningStockValue, tblStock.CurrentStockBalance, 
                      tblStock.CurrentStockValue, tblStock.CreatedDate, tblStock.UpdatedDate, tblStockCategory.Name AS CatagoryName, 
                      tblUserLogin.UserName AS CreatedBy, tblUserLogin_1.UserName AS UpdatedBy, tblSuppliers.SupplierID AS Expr1, tblSuppliers.SupplierName
FROM         tblUserLogin RIGHT OUTER JOIN
                      tblSuppliers RIGHT OUTER JOIN
                      tblStock ON tblSuppliers.SupplierID = tblStock.SupplierID LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblStock.UpdatedBy = tblUserLogin_1.UserLoginID ON 
                      tblUserLogin.UserLoginID = tblStock.CreatedBy LEFT OUTER JOIN
                      tblStockCategory ON tblStock.StockCategoryID = tblStockCategory.StockCategoryID
where isnull(tblStock.IsDeleted,0) <>1                      
ORDER BY tblStock.StockCode

GO
/****** Object:  StoredProcedure [dbo].[Stock_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_GetByID]
	@StockID bigint

AS 
	
	
	SELECT [StockID]
      ,[StockCode]
      ,[Description]
      ,[StockCategoryID]
	  ,[Stocktype]
      ,[PurchasingPrice]
      ,[SalesPrice]
      ,[SupplierID]
      ,[ReorderLevel]
      ,[OpeningStockBalance]
      ,[OpeningStockValue]
      ,[CurrentStockBalance]
      ,[CurrentStockValue]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[UpdatedBy]
      ,[UpdatedDate]
  FROM [tblStock] WHERE [StockID]=@StockID

GO
/****** Object:  StoredProcedure [dbo].[Stock_GetByStockCode]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_GetByStockCode]
	@StockCode nvarchar(20)

AS 
	
	
	SELECT [StockID]
      ,[StockCode]
      ,[Description]
      ,[StockCategoryID]
	  ,[Stocktype]
      ,[PurchasingPrice]
      ,[SalesPrice]
      ,[SupplierID]
      ,[ReorderLevel]
      ,[OpeningStockBalance]
      ,[OpeningStockValue]
      ,[CurrentStockBalance]
      ,[CurrentStockValue]
      ,[CreatedBy]
      ,[CreatedDate]
      ,[UpdatedBy]
      ,[UpdatedDate]
  FROM [tblStock] WHERE [StockCode]=@StockCode
  and ISNULL(IsDeleted,0) <>1

GO
/****** Object:  StoredProcedure [dbo].[Stock_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_Insert]
	
@StockID bigint,	
@StockCode NVARCHAR(20),
@Description NVARCHAR(150),
@StockCategoryID  bigint,
@StockType nvarchar(50),
@PurchasingPrice MONEY,
@SalesPrice MONEY,
@SupplierID bigint,
@ReorderLevel DECIMAL(18,2),
@OpeningStockBalance DECIMAL(18,2),
@OpeningStockValue MONEY,
@CurrentStockBalance Decimal(18,2),
@CurrentStockValue Money,
@CreatedBy Bigint,
@UpdatedBy Bigint
	
	
    
AS 

IF EXISTS

	(SELECT [StockID] FROM [tblStock] WHERE [StockID]=@StockID)

	BEGIN
		Update tblStock
	Set
		[StockCode] = @StockCode,
		[Description] = @Description,
		[StockCategoryID] = @StockCategoryID,
		[StockType]=@StockType,
		[PurchasingPrice] = @PurchasingPrice,
		[SalesPrice] = @SalesPrice,
		[SupplierID] = @SupplierID,
		[ReorderLevel] = @ReorderLevel,
		[OpeningStockBalance] = @OpeningStockBalance,
		[OpeningStockValue] = @OpeningStockValue,
		[CurrentStockBalance] = @CurrentStockBalance,
		[CurrentStockValue] = @CurrentStockValue,
		[UpdatedBy] = @UpdatedBy,
		[UpdatedDate] = getdate()
	Where		
		[StockID] = @StockID

	END

ELSE

	Insert Into tblStock
		([StockCode],[Description],[StockCategoryID],[StockType],[PurchasingPrice],[SalesPrice],[SupplierID],[ReorderLevel],[OpeningStockBalance],[OpeningStockValue],[CurrentStockBalance],[CurrentStockValue],[CreatedBy],[CreatedDate])
	Values
		(@StockCode,@Description,@StockCategoryID,@StockType,@PurchasingPrice,@SalesPrice,@SupplierID,@ReorderLevel,@OpeningStockBalance,@OpeningStockValue,@CurrentStockBalance,@CurrentStockValue,@CreatedBy,getdate())

GO
/****** Object:  StoredProcedure [dbo].[Stock_IsStockExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_IsStockExists]

@StockCode nvarchar(20),
@IsExists INT output
AS

If Exists
(Select [StockCode] from tblStock Where [StockCode]=@StockCode)

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[Stock_ItemsToOrder]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_ItemsToOrder]

AS

SELECT     tblStock.StockID, tblStock.StockCode, tblStock.Description, tblStock.StockCategoryID, tblStock.PurchasingPrice, tblStock.StockType, tblStock.SalesPrice, 
                      tblStock.SupplierID, tblStock.ReorderLevel, tblStock.OpeningStockBalance, tblStock.OpeningStockValue, tblStock.CurrentStockBalance, 
                      tblStock.CurrentStockValue, tblStock.CreatedBy, tblStock.CreatedDate, tblStock.UpdatedBy, tblStock.UpdatedDate, 
                      tblStockCategory.Name AS CategoryName, tblSuppliers.SupplierName
FROM         tblStock LEFT OUTER JOIN
                      tblStockCategory ON tblStock.StockCategoryID = tblStockCategory.StockCategoryID LEFT OUTER JOIN
                      tblSuppliers ON tblStock.SupplierID = tblSuppliers.SupplierID
WHERE     (tblStock.StockType = 'STOCK ITEM') AND (tblStock.CurrentStockBalance <= tblStock.ReorderLevel)

GO
/****** Object:  StoredProcedure [dbo].[Stock_RemoveFromPurchase]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_RemoveFromPurchase]

		@PurchaseID bigint
AS 

IF NOT EXISTS

	(SELECT PurchaseID FROM tblPurchases WHERE PurchaseID=@PurchaseID)
	RETURN 1
ELSE



	UPDATE [tblStock]
	SET 
	tblStock.[CurrentStockBalance] = (tblStock.[CurrentStockBalance] - (SELECT SUM( tblPurchasesDescription.[Quantity]) 
	From tblPurchasesDescription 
	WHERE tblStock.[StockID] =tblPurchasesDescription.StockID AND tblPurchasesDescription.PurchaseID=@PurchaseID GROUP BY PurchaseID)) 

	,tblStock.[CurrentStockValue]= (tblStock.[CurrentStockValue]-(SELECT SUM( tblPurchasesDescription.[UnitPrice]*tblPurchasesDescription.[Quantity] )
	FROM tblPurchasesDescription 
	WHERE tblStock.[StockID] =tblPurchasesDescription.StockID AND tblPurchasesDescription.PurchaseID=@PurchaseID GROUP BY tblPurchasesDescription.PurchaseID,tblPurchasesDescription.[UnitPrice])) 

	FROM tblStock,tblPurchasesDescription 
	WHERE tblStock.[StockID] =tblPurchasesDescription.StockID AND tblPurchasesDescription.PurchaseID=@PurchaseID

GO
/****** Object:  StoredProcedure [dbo].[Stock_RemoveFromRubberSheet]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_RemoveFromRubberSheet]

		@DailyWorkingID bigint
AS 

IF NOT EXISTS

	(SELECT DailyWorkingID FROM tblDailyWorking  WHERE DailyWorkingID=@DailyWorkingID)
	RETURN 1
ELSE



	UPDATE [tblStock]
	SET 
	tblStock.[CurrentStockBalance] = (tblStock.[CurrentStockBalance] - (SELECT SUM(tblDailyWorkingDescription.[ItemQuantity])
	From tblDailyWorkingDescription  
	WHERE tblStock.[StockID] =tblDailyWorkingDescription.StockID AND tblDailyWorkingDescription.DailyWorkingID=@DailyWorkingID GROUP BY DailyWorkingID)) 

	--,tblStock.[CurrentStockValue]= (tblStock.[CurrentStockValue]-(SELECT SUM( tblDailyWorkingDescription.[UnitPrice]*tblDailyWorkingDescription.[ItemQuantity] )
	--FROM tblDailyWorkingDescription 
	--WHERE tblStock.[StockID] =tblDailyWorkingDescription.StockID AND tblDailyWorkingDescription.DailyWorkingID=@DailyWorkingID GROUP BY tblDailyWorkingDescription.DailyWorkingID,tblDailyWorkingDescription.[UnitPrice])) 

	FROM tblStock,tblDailyWorkingDescription 
	WHERE tblStock.[StockID] =tblDailyWorkingDescription.StockID AND tblDailyWorkingDescription.DailyWorkingID=@DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[Stock_UpdateByPurchase]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_UpdateByPurchase]
	(
	 @StockID	bigint,
	 @StockBalance 	decimal(18,2))

AS

UPDATE [tblStock] 
SET  [CurrentStockBalance]	 = [CurrentStockBalance]+ @StockBalance,
       [CurrentStockValue]=[CurrentStockValue]+(SELECT [PurchasingPrice]*@StockBalance FROM tblStock WHERE [StockID]=@StockID)
WHERE 
	( [StockID]	 = @StockID)

GO
/****** Object:  StoredProcedure [dbo].[Stock_UpdateBySales]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_UpdateBySales]
	(
	 @StockID 	bigint,
	 @StockBalance 	float)

AS

UPDATE [tblStock] 
SET  [CurrentStockBalance]	 = [CurrentStockBalance]- @StockBalance,
       [CurrentStockValue]=[CurrentStockValue]-(SELECT [PurchasingPrice]*@StockBalance FROM tblStock WHERE [StockID]=@StockID)
WHERE 
	( [StockID]	 = @StockID)

GO
/****** Object:  StoredProcedure [dbo].[Stock_UpdateRubberProducts]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Stock_UpdateRubberProducts]
	(
	 @StockID	bigint,
	 @StockBalance 	decimal(18,2))

AS

UPDATE [tblStock] 
SET  [CurrentStockBalance]	 = isnull([CurrentStockBalance],0)+ @StockBalance
   --    [CurrentStockValue]=[CurrentStockValue]+(SELECT [PurchasingPrice]*@StockBalance FROM tblStock WHERE [StockID]=@StockID)
WHERE 
	( [StockID]	 = @StockID)

GO
/****** Object:  StoredProcedure [dbo].[StockCategory_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StockCategory_Delete]

@Name nvarchar(100)

AS

DELETE FROM [dbo].[tblStockCategory]
      WHERE [Name]=@Name

GO
/****** Object:  StoredProcedure [dbo].[StockCategory_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StockCategory_GetAll]

as

SELECT [StockCategoryID]
      ,[Name]
  FROM [dbo].[tblStockCategory]

GO
/****** Object:  StoredProcedure [dbo].[StockCategory_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StockCategory_Insert]

@Name nvarchar(100)

AS


IF not EXISTS

	(SELECT [Name] FROM tblStockCategory WHERE [Name]=@Name)

begin
INSERT INTO [dbo].[tblStockCategory]
           ([Name])
     VALUES
           (@Name)
end

GO
/****** Object:  StoredProcedure [dbo].[StockCategory_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StockCategory_Update]

@StockCategoryID bigint,
@Name nvarchar(100)

as

UPDATE [dbo].[tblStockCategory]
   SET [Name] = @Name
 WHERE [StockCategoryID]=@StockCategoryID

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_Delete]
@SupplierID Bigint
AS

Update [tblSuppliers]
set IsDeleted=1
WHERE [SupplierID]=@SupplierID

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_GetAll]

AS
SELECT     tblSuppliers.SupplierID, tblSuppliers.SupplierNo, tblSuppliers.Salutation, tblSuppliers.SupplierName, tblSuppliers.AddressLine1, 
                      tblSuppliers.AddressLine2, tblSuppliers.AddressLine3, tblSuppliers.Telephone, tblSuppliers.Estate, tblSuppliers.AccountNo, tblSuppliers.Bank, 
                      tblSuppliers.CreatedDate, tblSuppliers.UpdatedDate, tblUserLogin_1.UserName AS CreatedBy, tblUserLogin.UserName AS UpdatedBy
FROM         tblSuppliers LEFT OUTER JOIN
                      tblUserLogin ON tblSuppliers.UpdatedBy = tblUserLogin.UserLoginID LEFT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblSuppliers.CreatedBy = tblUserLogin_1.UserLoginID
WHERE ISNULL(IsDeleted,0) <>1                      
ORDER BY tblSuppliers.SupplierNo DESC

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_GetByID]

@SupplierID bigint

AS
SELECT [SupplierID]
      ,[SupplierNo]
	  ,[Salutation]
      ,[SupplierName]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[AddressLine3]
      ,[Telephone]
      ,[Estate]
      ,[AccountNo]
      ,[Bank]
		,[CreatedBy],[CreatedDate],[UpdatedBy], [UpdatedDate]
  FROM [tblSuppliers]
WHERE [SupplierID]=@SupplierID

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_GetBySupplierNo]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_GetBySupplierNo]

@SupplierNo bigint

AS
SELECT [SupplierID]
      ,[SupplierNo]
	  ,[Salutation]
      ,[SupplierName]
      ,[AddressLine1]
      ,[AddressLine2]
      ,[AddressLine3]
      ,[Telephone]
      ,[Estate]
      ,[AccountNo]
      ,[Bank]
		,[CreatedBy],[CreatedDate],[UpdatedBy], [UpdatedDate]
  FROM [tblSuppliers]
WHERE [SupplierNo]=@SupplierNo

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_Insert]

  @SupplierID bigint
 ,@SupplierNo bigint
,@Salutation nvarchar(5)
 ,@SupplierName nvarchar(100)
 ,@AddressLine1 nvarchar(100)
 ,@AddressLine2 nvarchar(100)
 ,@AddressLine3 nvarchar(100)
 ,@Telephone nvarchar(50)
 ,@Estate nvarchar(50)
 ,@AccountNo nvarchar(50)
 ,@Bank nvarchar(50)
 ,@CreatedBy bigint
 ,@UpdatedBy bigint


AS

IF EXISTS
(SELECT [SupplierID] FROM tblSuppliers WHERE [SupplierID]=@SupplierID)
BEGIN

UPDATE [tblSuppliers]
   SET [SupplierNo] = @SupplierNo
	  ,[Salutation]=@Salutation
      ,[SupplierName] = @SupplierName
      ,[AddressLine1] = @AddressLine1
      ,[AddressLine2] = @AddressLine2
      ,[AddressLine3] = @AddressLine3
      ,[Telephone] = @Telephone
      ,[Estate] = @Estate
      ,[AccountNo] = @AccountNo
      ,[Bank] = @Bank
	  ,[UpdatedBy] = @UpdatedBy
	  ,[UpdatedDate] = getdate()
 WHERE [SupplierID]=@SupplierID
END


ELSE
BEGIN
INSERT INTO [tblSuppliers]
           ([SupplierNo]
			,[Salutation]
           ,[SupplierName]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[AddressLine3]
           ,[Telephone]
           ,[Estate]
           ,[AccountNo]
           ,[Bank]
		   ,[CreatedBy]
		   ,[CreatedDate])
     VALUES
         (@SupplierNo 
		,@Salutation
		,@SupplierName 
		,@AddressLine1 
		,@AddressLine2 
		,@AddressLine3 
		,@Telephone 
		,@Estate 
		,@AccountNo 
		,@Bank
		,@CreatedBy
		,getdate())
END

GO
/****** Object:  StoredProcedure [dbo].[Suppliers_IsSupplierExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Suppliers_IsSupplierExists]

@SupplierNo bigint,
@IsExists INT output
AS

If Exists
(Select [SupplierNo] from tblSuppliers Where [SupplierNo]=@SupplierNo )

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[tblDailyWorkingDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblDailyWorkingDescription_Delete]
	@DailyWorkingID Bigint
 AS

DELETE FROM tblDailyWorkingDescription  WHERE DailyWorkingID=@DailyWorkingID

GO
/****** Object:  StoredProcedure [dbo].[tblStock_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[tblStock_GetAll]
as
SELECT     StockID, StockCode, Description, StockCategoryID, StockType, PurchasingPrice, SalesPrice, SupplierID, ReorderLevel, OpeningStockBalance, OpeningStockValue, 
                      CurrentStockBalance, CurrentStockValue, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate, IsDeleted
FROM         tblStock

GO
/****** Object:  StoredProcedure [dbo].[TermDeductionDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductionDescription_Delete]

  @TermDeductionDescriptionID bigint
AS 
	
	DELETE
	FROM   [dbo].[tblTermDeductionDescription]
	WHERE  [TermDeductionDescriptionID] = @TermDeductionDescriptionID

GO
/****** Object:  StoredProcedure [dbo].[TermDeductionDescription_DeleteByTermDeductionID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductionDescription_DeleteByTermDeductionID]

  @TermDeductionID bigint
AS 
	
	DELETE
	FROM   [dbo].[tblTermDeductionDescription]
	WHERE  [TermDeductionID] = @TermDeductionID

GO
/****** Object:  StoredProcedure [dbo].[TermDeductionDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductionDescription_Insert]
	@ActiveDate date =NULL,
    @TermDeductionID bigint = NULL,
    @TDMonthName varchar(10) = NULL,
    @TDInsAmount money = NULL
    --@ActiveDate date =NULL
    
AS 
	--declare @ActiveDate date
	--set @ActiveDate=CONVERT(date,('1-'+ CONVERT(varchar(10), MONTH(@TDDate))+'-'+CONVERT(varchar(10), YEAR(@TDDate))),103)

	INSERT INTO [dbo].[tblTermDeductionDescription] ([TermDeductionID], [TDMonthName], [TDInsAmount],[ActiveDate])
	values (@TermDeductionID, @TDMonthName, @TDInsAmount,@ActiveDate)
	
--select * from tblTermDeductionDescription

GO
/****** Object:  StoredProcedure [dbo].[TermDeductions_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductions_Delete]

    @TermDeductionID bigint
AS 
	


	UPDATE [dbo].[tblTermDeductions]
	SET IsDeleted=1
	WHERE  [TermDeductionID] = @TermDeductionID

GO
/****** Object:  StoredProcedure [dbo].[TermDeductions_GetByTermDeductionID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductions_GetByTermDeductionID]

    @TermDeductionID bigint
AS 
	

	SELECT     
	tblTermDeductions.TermDeductionID, 
	tblTermDeductions.TDDate, 
	tblTermDeductions.TDType, 
	tblTermDeductions.EmployerID, 
	tblTermDeductions.TDAmount, 
	tblTermDeductions.TDInstallments, 
	tblTermDeductions.TDdescription,
	tblTermDeductions.CreatedBy, 
	tblTermDeductions.CreatedDate, 
	tblTermDeductions.UpdatedBy, 
	tblTermDeductions.UdatedDate, 
    tblEmployers.EmployerName,
    tblemployers.Designation

    
FROM         tblTermDeductions LEFT OUTER JOIN
                      tblEmployers ON tblTermDeductions.EmployerID = tblEmployers.EmployerID

where tblTermDeductions.TermDeductionID=@TermDeductionID 
and isnull(isdeleted,0) <>1

GO
/****** Object:  StoredProcedure [dbo].[TermDeductions_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductions_Insert]

@TDDate date = NULL,
    @TDType nvarchar(10) = NULL,
    @EmployerID bigint = NULL,
    @TDAmount money = NULL,
    @TDInstallments bigint = NULL,
	@TDdescription nvarchar(200)=NULL,
    @CreatedBy bigint = NULL,
     @UpdatedBy bigint = NULL,
  	@NewTermDeductionID bigint Output

AS

INSERT INTO [dbo].[tblTermDeductions] ([TDDate], [TDType], [EmployerID], [TDAmount], [TDInstallments],[TDdescription], [CreatedBy], [CreatedDate], [UpdatedBy], [UdatedDate])
 VALUES (@TDDate, @TDType, @EmployerID, @TDAmount, @TDInstallments,@TDdescription, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE())
 
	 Select @NewTermDeductionID = @@IDENTITY

	Return @NewTermDeductionID

GO
/****** Object:  StoredProcedure [dbo].[TermDeductions_SelectAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductions_SelectAll]

  --  @TermDeductionID bigint
AS 
	

	SELECT     
	tblTermDeductions.TermDeductionID, 
	tblTermDeductions.TDDate, 
	tblTermDeductions.TDType, 
	tblTermDeductions.EmployerID, 
	tblTermDeductions.TDAmount, 
	tblTermDeductions.TDInstallments, 
	tblTermDeductions.TDdescription,
	tblTermDeductions.CreatedBy, 
	tblTermDeductions.CreatedDate, 
	tblTermDeductions.UpdatedBy, 
	tblTermDeductions.UdatedDate, 
    tblEmployers.EmployerName,
    tblemployers.EmployerNo
    
FROM         tblTermDeductions inner join
                      tblEmployers ON tblTermDeductions.EmployerID = tblEmployers.EmployerID
and isnull(isdeleted,0) <>1      
order by   tblTermDeductions.TDDate DESC

GO
/****** Object:  StoredProcedure [dbo].[TermDeductions_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductions_Update]

    @TermDeductionID bigint,
    @TDDate date = NULL,
    @TDType nvarchar(10) = NULL,
    @EmployerID bigint = NULL,
    @TDAmount money = NULL,
    @TDInstallments bigint = NULL,
	@TDdescription nvarchar(200) = NULL,
    @CreatedBy bigint = NULL,
    @CreatedDate datetime = NULL,
    @UpdatedBy bigint = NULL,
    @UdatedDate datetime = NULL
AS 
	

	UPDATE [dbo].[tblTermDeductions]
	SET    [TDDate] = @TDDate, [TDType] = @TDType, [EmployerID] = @EmployerID, [TDAmount] = @TDAmount, [TDInstallments] = @TDInstallments, [TDdescription]=@TDdescription,  [CreatedBy] = @CreatedBy, [CreatedDate] = GETDATE(), [UpdatedBy] = @UpdatedBy, [UdatedDate] = GETDATE()
	WHERE  [TermDeductionID] = @TermDeductionID

GO
/****** Object:  StoredProcedure [dbo].[TermDeductionsDescription_GetByTermDeductionID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TermDeductionsDescription_GetByTermDeductionID]

       @TermDeductionID bigint
AS 
	
	SELECT [TermDeductionDescriptionID], [TermDeductionID], [TDMonthName], [TDInsAmount],ActiveDate 
	FROM   [dbo].[tblTermDeductionDescription] 
	WHERE  ([TermDeductionID] = @TermDeductionID )

GO
/****** Object:  StoredProcedure [dbo].[testAttendanae]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[testAttendanae]

@IssueDate DATE

AS


--DECLARE @IssueDate DATE
--SET @IssueDate=  '08-01-2014'

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@IssueDate)+1,0))


DECLARE @DateList TABLE
(
	monthDate DATE
)

;WITH [sample] AS (
  SELECT CAST(@IssueDate AS DATE) AS dt
  UNION ALL
  SELECT DATEADD(dd, 1, dt) FROM sample s WHERE DATEADD(dd, 1, dt) <= CAST(@maxDate AS DATE))
  INSERT INTO @DateList (monthDate)
  SELECT * FROM [sample]


declare @CodeList table
(
	EmployeeID bigint,
	WorkingDate date,
	AbbreviatedCode varchar(10)
)

insert into @CodeList (EmployeeID,WorkingDate,AbbreviatedCode)
select DW1.EmployeeID,DW1.WorkingDate,  ABB1.AbbreviationCode  from tblDailyWorking DW1 
inner join tblAbbreviation ABB1 on ABB1.AbbreviationID=DW1.AbbreviationID


select  CLX.monthDate, TT.EmployerNo, TT.EmployerName, TT.AbbreviatedCode from @DateList CLX

left outer join 

(

select  E.EmployerNo, E.EmployerName,DW.WorkedDays, DW.WorkingDate, P.AbbreviatedCode from tblEmployers E
left outer join tblDailyWorking DW on DW.EmployeeID=E.EmployerID
inner join 

(

SELECT S.EmployeeID, S.WorkingDate,

(SELECT  STUFF(( SELECT  '],[' + [AbbreviatedCode] FROM @CodeList  WHERE EmployeeID=S.EmployeeID  FOR XML PATH('')), 1, 2, '') + ']') AS [AbbreviatedCode]

FROM @CodeList AS S
GROUP BY S.EmployeeID,  S.WorkingDate 

) P ON P.EmployeeID=E.EmployerID and P.WorkingDate=DW.WorkingDate


) TT on CLX.monthDate=TT.WorkingDate

GO
/****** Object:  StoredProcedure [dbo].[uDynamicPivot]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uDynamicPivot](
                 @sourcedata varchar(8000),
                 @Pivot_On_Source_Column varchar(2000), 
                 @Pivot_Value_Aggregate varchar(10), 
                 @Pivot_Value_Column varchar(2000), 
                 @Pivot_Column_List varchar(2000),
                 @PivotOrderby varchar(200))

AS 
BEGIN

   declare @columns varchar(max)
   declare @column_output varchar(max)
   declare @GrandTotalColumn varchar(max)
   declare @sql nvarchar(max)

   set @sql = N'set @columns = substring((select '', [''+convert(varchar,'+@Pivot_Column_List+')+'']'' from '+@sourcedata+' group by '+@Pivot_Column_List+' order by '+@Pivot_Column_List+' for xml path('''')),2,8000)'
   execute sp_executesql @sql,
                         N'@columns varchar(max) output',
                         @columns=@columns output 

   set @sql = N'set @column_output = substring((select '', ISNULL([''+convert(varchar,'+@Pivot_Column_List+')+''],0) AS [''+convert(varchar,'+@Pivot_Column_List+')+'']'' from '+@sourcedata+' group by '+@Pivot_Column_List+' order by '+@Pivot_Column_List+' for xml path('''')),2,8000)'
   execute sp_executesql @sql,
                         N'@column_output varchar(max) output',
                         @column_output=@column_output output 

   set @sql = N'set @GrandTotalColumn = substring((select ''+ ISNULL([''+convert(varchar,'+@Pivot_Column_List+')+''],0)''  from '+@sourcedata+' group by '+@Pivot_Column_List+' order by '+@Pivot_Column_List+' for xml path('''')),2,8000)'
   execute sp_executesql @sql,
                         N'@GrandTotalColumn varchar(max) output',
                         @GrandTotalColumn=@GrandTotalColumn output 

   set @sql = N'SELECT '+@Pivot_On_Source_Column+','+@column_output+','+@GrandTotalColumn+' AS RowGrandTotal FROM 
       (SELECT '+@Pivot_On_Source_Column+','+@Pivot_Column_List+','+@Pivot_Value_Column+' from '+@sourcedata+') src
       PIVOT
       ('+@Pivot_Value_Aggregate+'('+@Pivot_Value_Column+') FOR '+@Pivot_Column_List+' IN ('+@columns+') ) pvt
       ORDER BY '+@PivotOrderby+''
   --execute sp_executesql @sql
   print @sql

END

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblUserLogin_DeleteRow
-- Author:	Mehdi Keramati
-- Create date:	10/18/2009 9:27:56 PM
-- Description:	This stored procedure is intended for deleting a specific row from tblUserLogin table
-- ==========================================================================================
Create Procedure [dbo].[UserLogin_Delete]
	@UserLoginID bigint
As
Begin
	Delete tblUserLogin
	Where
		[UserLoginID] = @UserLoginID

End

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_GetAll]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblUserLogin_SelectAll
-- Author:	Mehdi Keramati
-- Create date:	10/18/2009 9:27:56 PM
-- Description:	This stored procedure is intended for selecting all rows from tblUserLogin table
-- ==========================================================================================
CREATE Procedure [dbo].[UserLogin_GetAll]
As
Begin
	SELECT     tblUserLogin.UserLoginID, tblUserLogin.EmployerID, tblUserLogin.UserType, tblUserLogin.UserName, tblUserLogin.Password, 
                      tblUserLogin.CreatedBy, tblUserLogin.CreatedDate, tblUserLogin.UpdatedBy, tblUserLogin.UpdatedDate, tblEmployers.EmployerName, 
                      tblEmployers.EmployerNo
FROM         tblUserLogin INNER JOIN
                      tblEmployers ON tblUserLogin.EmployerID = tblEmployers.EmployerID
End

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_GetByID]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblUserLogin_SelectRow
-- Author:	Mehdi Keramati
-- Create date:	10/18/2009 9:27:56 PM
-- Description:	This stored procedure is intended for selecting a specific row from tblUserLogin table
-- ==========================================================================================
CREATE Procedure [dbo].[UserLogin_GetByID]
	@UserLoginID bigint
As
Begin
	Select 
		[UserLoginID],
		[EmployerID],
		[UserType],
		[UserName],
		[Password],
		[CreatedBy],
		[CreatedDate],
		[UpdatedBy],
		[UpdatedDate]
	From tblUserLogin
	Where
		[UserLoginID] = @UserLoginID
End

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_GetByUserNameAndPassword]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblUserLogin_SelectRow
-- Author:	Mehdi Keramati
-- Create date:	10/18/2009 9:27:56 PM
-- Description:	This stored procedure is intended for selecting a specific row from tblUserLogin table
-- ==========================================================================================
CREATE Procedure [dbo].[UserLogin_GetByUserNameAndPassword]
	@UserName nvarchar(50),
	@Password nvarchar(50)
	

As



Begin	
	Select 
			[UserLoginID],
			[EmployerID],
			[UserType],
			[UserName],
			[Password],
			[CreatedBy],
			[CreatedDate],
			[UpdatedBy],
			[UpdatedDate]
		From tblUserLogin
		Where
			[UserName] = @UserName AND [Password]=@Password
	
	End

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==========================================================================================
-- Entity Name:	sp_tblUserLogin_Insert
-- Author:	Mehdi Keramati
-- Create date:	10/18/2009 9:27:56 PM
-- Description:	This stored procedure is intended for inserting values to tblUserLogin table
-- ==========================================================================================
CREATE Procedure [dbo].[UserLogin_Insert]
	@UserLoginID bigint,
	@EmployerID bigint,
	@UserType nvarchar(50),
	@UserName nvarchar(50),
	@Password nvarchar(50),
	@CreatedBy bigint,
	@UpdatedBy bigint
As

IF Exists
(SELECT [USerLoginID] FROM tblUserLogin WHERE [UserLoginID]=@UserLoginID)



Begin
	Update tblUserLogin
	Set
		[EmployerID] = @EmployerID,
		[UserType] = @UserType,
		[UserName] = @UserName,
		[Password] = @Password,
		[UpdatedBy]=@UpdatedBy,
		[UpdatedDate]=getdate()
	Where		
		[UserLoginID] = @UserLoginID

End

ELSE


Begin
	Insert Into tblUserLogin
		([EmployerID],[UserType],[UserName],[Password],[CreatedBy],[CreatedDate])
	Values
		(@EmployerID,@UserType,@UserName,@Password,@CreatedBy,getdate())

End

GO
/****** Object:  StoredProcedure [dbo].[UserLogin_IsUserNameExists]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserLogin_IsUserNameExists]

@UserName nvarchar(50),
@IsExists INT output
AS

If Exists
(Select [UserName] from tblUserLogin Where [UserName]=@UserName)

Set @IsExists=1

Else

Set @IsExists=2

GO
/****** Object:  StoredProcedure [dbo].[usp_TermDeductionsUpdate]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_TermDeductionsUpdate] 
    @TermDeductionID bigint,
    @TDDate date = NULL,
    @TDType nvarchar(10) = NULL,
    @EmployerID bigint = NULL,
    @TDAmount money = NULL,
    @TDInstallments bigint = NULL,    
    @UpdatedBy bigint = NULL
    
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN

	UPDATE [dbo].[tblTermDeductions]
	SET    [TDDate] = @TDDate, [TDType] = @TDType, [EmployerID] = @EmployerID, [TDAmount] = @TDAmount, [TDInstallments] = @TDInstallments,  [UpdatedBy] = @UpdatedBy, [UdatedDate] = GETDATE()
	WHERE  [TermDeductionID] = @TermDeductionID
	


	COMMIT

GO
/****** Object:  StoredProcedure [dbo].[WorkDays_GetActiveYear]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDays_GetActiveYear]

AS

SELECT        WorkDayID, YearName, MonthStatus
FROM            tblWorkDays
WHERE        (MonthStatus = 'A')
GO
/****** Object:  StoredProcedure [dbo].[WorkDays_GetMonthList]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDays_GetMonthList]

@WorkDayID bigint
AS

SELECT     WorkDaysDescriptionID, WorkDayID, MonthName, WorkDays
FROM         tblWorkDaysDescription
where WorkDayID=@WorkDayID
GO
/****** Object:  StoredProcedure [dbo].[WorkDays_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDays_Insert]

--@WorkDayID bigint,
@YearName nvarchar(5),
@CreatedBy bigint,

@NewWorkDayID bigint output

AS
BEGIN
INSERT INTO [tblWorkDays]
           ([YearName],[MonthStatus],[CreatedBy],[CreatedDate])
     VALUES
	(@YearName,'A',@CreatedBy,GETDATE())

	SET @NewWorkDayID=scope_identity()

END

GO
/****** Object:  StoredProcedure [dbo].[WorkDays_Update]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDays_Update]

@WorkDayID bigint,
@UpdatedBy bigint

AS

UPDATE [tblWorkDays]
   SET [MonthStatus]='P'
	  ,[UpdatedBy] = @UpdatedBy
	  ,[UpdatedDate] = getdate()

 WHERE [WorkDayID]=@WorkDayID


GO
/****** Object:  StoredProcedure [dbo].[WorkDaysDescription_Delete]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDaysDescription_Delete]

@WorkDayID bigint

AS

DELETE FROM tblWorkDaysDescription WHERE WorkDayID=@WorkDayID


GO
/****** Object:  StoredProcedure [dbo].[WorkDaysDescription_Insert]    Script Date: 9/23/2016 5:56:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkDaysDescription_Insert]

@WorkDayID bigint,
@MonthName nvarchar(20),
@WorkDays bigint

AS


INSERT INTO tblWorkDaysDescription (WorkDayID, MonthName, WorkDays)VALUES(@WorkDayID, @MonthName, @WorkDays)
GO
