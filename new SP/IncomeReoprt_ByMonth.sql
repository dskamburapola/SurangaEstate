USE [EstateLive]
GO
/****** Object:  StoredProcedure [dbo].[IncomeReoprt_ByMonth]    Script Date: 8/21/2016 10:45:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[IncomeReoprt_ByMonth]

@OtherIncomeDate date

AS

DECLARE @maxDate DATE
SET @maxDate= DATEADD(s,-1,DATEADD(mm, DATEDIFF(m,0,@OtherIncomeDate)+1,0))


SELECT        tblOtherIncomeTypes.Description, tblOtherIncomes.OtherIncomeDate, tblOtherIncomes.Note, tblOtherIncomes.Quantity, tblOtherIncomes.Rate, 
                         tblOtherIncomes.Amount, tblOtherIncomes.Deduction
FROM            tblOtherIncomes LEFT OUTER JOIN
                         tblOtherIncomeTypes ON tblOtherIncomes.OtherIncomeTypeID = tblOtherIncomeTypes.OtherIncomeTypeID

						 where tblOtherIncomes.OtherIncomeDate>=@OtherIncomeDate AND tblOtherIncomes.OtherIncomeDate<=@maxDate

						 and tblOtherIncomeTypes.Description <>'INCOME OF SRATERGIC DEVELOPMENT PROJECTS'

