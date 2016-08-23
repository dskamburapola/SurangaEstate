USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[Expenses_Insert]    Script Date: 23/08/2016 7:27:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Expenses_Insert]

 @ExpenseID bigint
,@ExpenseTypeID bigint
,@PaymentTypeID bigint
,@ExpenseDate datetime
,@Amount money
,@Note nvarchar(100)
,@Remarks ntext
,@CurrentExpenseID bigint output
,@CreatedBy bigint
,@UpdatedBy bigint
AS


IF exists
(Select [ExpenseID] from tblExpenses  Where [ExpenseID]=@ExpenseID)
	
	begin
		UPDATE [tblExpenses]
		SET [ExpenseTypeID] = @ExpenseTypeID
		   ,[PaymentTypeID]=@PaymentTypeID	
		   ,[ExpenseDate] = @ExpenseDate
		   ,[Amount] =@Amount
		   ,[Note] = @Note
		   ,[Remarks]=@Remarks
			
			,[UpdatedBy]=@UpdatedBy
			,[UpdatedDate]=getdate()
		WHERE [ExpenseID]=@ExpenseID
		set @CurrentExpenseID=-1
	end


else

BEGIN
INSERT INTO [tblExpenses]
           ([ExpenseTypeID]
			,[PaymentTypeID]
           ,[ExpenseDate]
           ,[Amount]
           ,[Note]
		   ,[Remarks]
			,[CreatedBy]
			,[CreatedDate])
     VALUES
           (@ExpenseTypeID
			,@PaymentTypeID
           ,@ExpenseDate
           ,@Amount
           ,@Note
		   ,@Remarks
			,@CreatedBy
			,getdate())


set @CurrentExpenseID=scope_identity()
END
