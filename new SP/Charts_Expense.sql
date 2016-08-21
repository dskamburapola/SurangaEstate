USE [EstateLive]
GO
/****** Object:  StoredProcedure [dbo].[Charts_Expense]    Script Date: 8/21/2016 1:39:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Charts_Expense]

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

