CREATE PROCEDURE [dbo].[spDeleteIntegrante]
	@intID int
AS
	BEGIN
		DELETE FROM Integrante WHERE IntegranteID = @intID;
	END
RETURN 0
