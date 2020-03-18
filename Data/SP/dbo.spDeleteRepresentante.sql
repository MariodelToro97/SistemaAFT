CREATE PROCEDURE [dbo].[spDeleteRepresentante]
	@intID int
AS
	BEGIN
		DELETE FROM Representante WHERE RepresentanteID = @intID;
	END
RETURN 0
