USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[Festivaladvance_GetAll]    Script Date: 20/Aug/2016 9:52:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Festivaladvance_GetAll]

AS

SELECT        T.TermDeductionID, T.EmployerID, 

CAST(E.EmployerNo as nvarchar(20)) + ' - ' + E.EmployerName as TDdescription,

TDdescription AS Remarks

FROM            tblTermDeductions AS T INNER JOIN
                         tblEmployers AS E ON T.EmployerID = E.EmployerID


--(CAST(EmployerID as nvarchar(20)) +' - ' + TDdescription )AS Description