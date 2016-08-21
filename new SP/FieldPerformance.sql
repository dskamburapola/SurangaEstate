USE [EstateLive]
GO
/****** Object:  StoredProcedure [dbo].[FieldPerformance]    Script Date: 8/21/2016 4:08:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[FieldPerformance]
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
	
)

INSERT INTO #CalculatedList (EmployeeID,TotalDays,PLD,PLQ,TPD,TPQ,SRS,SRQ,WSU,SPD,SCD)
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

isnull(SUM((case abc.AbbreviationCode when 'SC' then  TDW.WorkedDays  end)),0) as SCD



FROM    tblDailyWorking TDW
inner join tblAbbreviation ABC on TDW.AbbreviationID=abc.AbbreviationID

WHERE	TDW.WorkingDate >=@IssueDate AND TDW.WorkingDate <=@maxDate
AND  ISNULL(TDW.IsDeleted,0) <>1 --AND TDW.WorkType='PERMANENT'
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
						 XYZ.SCD
  
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
