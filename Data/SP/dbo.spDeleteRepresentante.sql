CREATE PROCEDURE [dbo].[spDeleteRepresentante]
	@intID int,
	@persona int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM Representante WHERE RepresentanteID = @intID;
		SELECT @contador = COUNT(RepresentanteID) FROM Representante WHERE PersonaID = @persona;
	END
RETURN 0