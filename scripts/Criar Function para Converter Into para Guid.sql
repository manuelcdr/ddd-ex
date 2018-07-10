SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Transact-SQL Scalar Function Syntax  
CREATE FUNCTION [dbo].[ConvertIntToGuid] ( @inteiro int )  
RETURNS uniqueidentifier  
AS
BEGIN
RETURN (SELECT cast(CONVERT(BINARY(16), REVERSE(CONVERT(BINARY(16), @inteiro))) as uniqueidentifier))
END
GO
