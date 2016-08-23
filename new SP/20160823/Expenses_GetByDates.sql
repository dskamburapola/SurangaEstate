USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[Expenses_GetByDates]    Script Date: 23/08/2016 7:26:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Expenses_GetByDates]

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
