USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[RecoverySummary]    Script Date: 9/19/2016 9:04:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[RecoverySummary]

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