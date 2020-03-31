CREATE PROCEDURE [dbo].[spAddIntegrante]
	@curp VARCHAR (MAX),
	@nombre VARCHAR (MAX),
	@aPaterno VARCHAR (MAX),
	@aMaterno VARCHAR(MAX),
	@persona int,
	@ID int OUTPUT

AS
	BEGIN
		INSERT INTO Integrante VALUES (@curp, @nombre, @aPaterno, @aMaterno, @persona);
		SELECT @ID = IntegranteID FROM Integrante WHERE PersonaID = @persona;
	END
RETURN 0