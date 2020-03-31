CREATE PROCEDURE [dbo].[spDeleteIntegrante]
	@intID int,
	@persona int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM Integrante WHERE IntegranteID = @intID;
		SELECT @contador = COUNT(IntegranteID) FROM Integrante WHERE PersonaID = @persona;
	END
RETURN 