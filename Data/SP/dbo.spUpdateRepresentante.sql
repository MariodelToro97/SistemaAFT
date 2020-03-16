CREATE PROCEDURE [dbo].[spUpdateRepresentante]
	@id INT,
	@curp VARCHAR(MAX),
	@nombre varchar(max),
	@aPaterno varchar(max),
	@aMaterno varchar(max),
	@persona int
AS
	BEGIN
		UPDATE Representante
		SET CURP = @curp, nombre = @nombre, apellido_paterno = @aPaterno, apellido_materno = @aMaterno, PersonaID = @persona
		WHERE RepresentanteID = @id;
	END
RETURN 0