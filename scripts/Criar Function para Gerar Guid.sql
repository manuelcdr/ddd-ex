SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
 
CREATE FUNCTION [dbo].[fnc_getNextGUID]()
RETURNS uniqueidentifier
AS
BEGIN  
 
    return
        (
            select
                    [newID] = [COMB]
            from  [Constant].[vw_GUID]
        )
END
GO
