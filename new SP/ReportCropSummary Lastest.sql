USE [EstateLive2]
GO
/****** Object:  StoredProcedure [dbo].[ReportCropSummary]    Script Date: 9/14/2016 9:08:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ReportCropSummary]

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