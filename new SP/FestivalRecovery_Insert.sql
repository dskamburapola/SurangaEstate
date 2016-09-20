USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[FestivalRecovery_Insert]    Script Date: 07/24/2016 05:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[FestivalRecovery_Insert]

@EmployerId bigint,
    @IssueDate datetime,
    @AdvanceAmount decimal(18, 2),
    @CreatedBy bigint,
    @UpdatedBy bigint = NULL,
    @TermDeductionID bigint
   

AS

INSERT INTO [dbo].[tblFestivalRecovery] ([EmployerId], [IssueDate], [AdvanceAmount], [CreatedBy], [CreatedDate], [UpdatedBy], [UpdatedDate],[TermDeductionID])
	VALUES (@EmployerId, @IssueDate, @AdvanceAmount, @CreatedBy, GETDATE(), @UpdatedBy, GETDATE(),@TermDeductionID)

