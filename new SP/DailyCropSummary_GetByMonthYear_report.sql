USE [EstateLive]
GO
/****** Object:  StoredProcedure [dbo].[DailyCropSummary_GetByMonthYear_report]    Script Date: 8/21/2016 4:03:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[DailyCropSummary_GetByMonthYear_report] 
  
  @SelecteMonth int,
  @SelectedYear int,
  @TypeID int
 
  
    
AS 
	


	SELECT [DailyCropSummaryID], [Month], [Year], [AbbreviationID], day( CurrentDay) as CurrentDay, [FactoryCrop], [Rate] , 'Factory Weight (kg)' as [Description]
	FROM   [dbo].[tbleDailyCropSummary] 
	Where [Month]=@SelecteMonth AND [Year]=@SelectedYear AND [AbbreviationID]=@TypeID
	order by CurrentDay
