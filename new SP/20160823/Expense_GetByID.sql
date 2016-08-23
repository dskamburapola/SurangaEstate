USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[Expense_GetByID]    Script Date: 23/08/2016 7:26:04 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Expense_GetByID]

@ExpenseID bigint

AS

SELECT        tblExpenses.ExpenseID, tblExpenses.ExpenseTypeID, tblExpenses.PaymentTypeID, tblExpenses.ExpenseDate, tblExpenses.Amount, tblExpenses.Note, tblExpenseTypes.Description AS ExpenseType, 
                         tblPaymentTypes.Description AS PaymentType, tblExpenses.CreatedBy, tblExpenses.CreatedDate, tblExpenses.UpdatedBy, tblExpenses.UpdatedDate, tblExpenses.Remarks
FROM            tblExpenses LEFT OUTER JOIN
                         tblExpenseTypes ON tblExpenses.ExpenseTypeID = tblExpenseTypes.ExpenseTypeID LEFT OUTER JOIN
                         tblPaymentTypes ON tblExpenses.PaymentTypeID = tblPaymentTypes.PaymentTypeID
Where [ExpenseID]=@ExpenseID
