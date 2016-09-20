USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[FestivalRecovery_GetAll_ByDates]    Script Date: 07/24/2016 06:26:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[FestivalRecovery_GetAll_ByDates]

  @StartDate date,
  @EndDate date

AS

SELECT  tblEmployers.EmployerNo, tblEmployers.EmployerName, tblFestivalRecovery.FestivalRecoveryId, tblFestivalRecovery.EmployerId, tblFestivalRecovery.IssueDate, 
                      tblFestivalRecovery.AdvanceAmount, tblFestivalRecovery.CreatedBy, tblFestivalRecovery.CreatedDate, tblFestivalRecovery.UpdatedBy, 
                      tblFestivalRecovery.UpdatedDate, tblUserLogin_1.UserName AS CreatedUser, tblUserLogin.UserName AS UpdatedUser, tblTermDeductions.Description
FROM         tblTermDeductions RIGHT OUTER JOIN
                      tblFestivalRecovery ON tblTermDeductions.TermDeductionID = tblFestivalRecovery.TermDeductionID RIGHT OUTER JOIN
                      tblUserLogin ON tblFestivalRecovery.UpdatedBy = tblUserLogin.UserLoginID RIGHT OUTER JOIN
                      tblUserLogin AS tblUserLogin_1 ON tblFestivalRecovery.CreatedBy = tblUserLogin_1.UserLoginID LEFT OUTER JOIN
                      tblEmployers ON tblFestivalRecovery.EmployerId = tblEmployers.EmployerID
                      
                      WHERE     convert(date, tblFestivalRecovery.IssueDate ,103) >= convert(date, @StartDate,103) AND convert(date, tblFestivalRecovery.IssueDate,103) <= convert(date, @EndDate,103)
ORDER BY tblFestivalRecovery.IssueDate
