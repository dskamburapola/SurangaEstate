USE [Estate]
GO
/****** Object:  StoredProcedure [dbo].[Abbreviation_GetAll]    Script Date: 07/24/2016 04:56:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Festivaladvance_GetAll]


AS

SELECT     TermDeductionID, 
TDType AS Description
--Description
FROM         tblTermDeductions