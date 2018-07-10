SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE view [Constant].[vw_GUID]
with schemabinding
as
 
    select
      
         [EMPTY]
            =
                CAST(
                        '00000000-0000-0000-0000-000000000000'
                        AS UNIQUEIDENTIFIER
                    )               
 
        , [COMB]
            =
                CAST(
                          CAST(NEWID() AS BINARY(10)) 
                        + CAST(GETDATE() AS BINARY(6)) 
                        AS UNIQUEIDENTIFIER
                    )
GO
