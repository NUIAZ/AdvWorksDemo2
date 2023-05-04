CREATE PROCEDURE [dbo].[INSERT_AuditSample]
	@TitleNumberInput int, @OutputRowCount int
AS

INSERT INTO [dbo].[AuditSample]
           ([TitleNumberInput]
           ,[OutputRowCount]
           )
     VALUES
           (@TitleNumberInput
           ,@OutputRowCount)