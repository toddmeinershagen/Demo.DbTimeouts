IF OBJECT_ID('dbo.DelayInSeconds','P') IS NOT NULL  
    DROP PROCEDURE dbo.DelayInSeconds;  
GO  
CREATE PROCEDURE dbo.DelayInSeconds   
    (  
		@delayInSeconds int = 0
    )  
AS  
	DECLARE @returnInfo varchar(255)  
 
	BEGIN  
		declare @delayLength varchar(8) = '00:00:' + right('00' + cast(@delayInSeconds as char(2)), 2)
		WAITFOR DELAY @delayLength;  
		SELECT @returnInfo = 'A total time of ' + @delayLength + ', hh:mm:ss, has elapsed! Your time is up.'   
		PRINT @returnInfo;
	END;  
GO 