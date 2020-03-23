CREATE PROCEDURE [dbo].[spDeleteAddress]
	@domID int,
	@persona int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM Domicilio WHERE DomicilioID = @domID;
		SELECT @contador = COUNT(DomicilioID) FROM Domicilio WHERE PersonaID = @persona;
	END
RETURN 