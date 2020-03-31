CREATE PROCEDURE [dbo].[spAddRepresentante]
	@curp VARCHAR (MAX),
	@nombre VARCHAR (MAX),
	@aPaterno VARCHAR (MAX),
	@aMaterno VARCHAR(MAX),
	@persona int,
	@ID int OUTPUT
AS
	BEGIN
		IF NOT EXISTS(SELECT * FROM Representante WHERE CURP = @CURP)
			BEGIN
				INSERT INTO Representante VALUES (@curp, @nombre, @aPaterno, @aMaterno, @persona);
				SELECT @ID = RepresentanteID FROM Representante WHERE CURP = @CURP;
			END
		
	END
RETURN