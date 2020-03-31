CREATE PROCEDURE [dbo].[spDeleteTelefono]
	@intID int,
	@persona int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM Telefono WHERE TelefonoID = @intID;
		SELECT @contador = COUNT(TelefonoID) FROM Telefono WHERE PersonaID= @persona;
	END
RETURN 