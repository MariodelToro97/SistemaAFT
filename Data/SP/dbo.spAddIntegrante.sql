CREATE PROCEDURE [dbo].[spAddIntegrante]
	@curp VARCHAR (MAX),
	@nombre VARCHAR (MAX),
	@aPaterno VARCHAR (MAX),
	@aMaterno VARCHAR(MAX),
	@persona int
AS
	BEGIN
		INSERT INTO Integrante VALUES (@curp, @nombre, @aPaterno, @aMaterno, @persona);
	END
RETURN 0
