CREATE PROCEDURE [dbo].[spDeleteAddress]
	@domID int
AS
	BEGIN
		DELETE FROM Domicilio WHERE DomicilioID = @domID;
	END
RETURN 0
