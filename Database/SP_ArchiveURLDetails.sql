SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Ramya>
-- Create date: <23 July 2022>
-- Description:	<Archiving the URLDetails Table>
-- =============================================
CREATE PROCEDURE SP_ArchiveURLDetails
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	BEGIN TRANSACTION 
	
	BEGIN TRY
		--Archive Data from URLDetails and Insert into ARC_URLDetails
		INSERT INTO [dbo].[Arc_URLDetails]
			   ([Id]
			   ,[LongURL]
			   ,[ShortURL]
			   ,[CreatedDate])
		 SELECT [Id]
			  ,[LongURL]
			  ,[ShortURL]
			  ,[CreatedDate]
		  FROM [URLShortner].[dbo].[URLDetails]
		  WHERE [CreatedDate] < DATEADD(year, -2, GETDATE()) ORDER BY [CreatedDate] ASC

		--Delete Archived Data from URLDetails 
		DELETE FROM [dbo].[URLDetails]
      WHERE [CreatedDate] < DATEADD(year, -2, GETDATE())
	END TRY
	BEGIN CATCH
		 ROLLBACK TRANSACTION
		 SELECT   
			ERROR_NUMBER() AS ErrorNumber  
			,ERROR_MESSAGE() AS ErrorMessage;
	END CATCH

	COMMIT TRANSACTION;

END
GO
