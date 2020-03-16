CREATE PROCEDURE [dbo].[spUpdateIntegrante]
	@id INT,
	@curp VARCHAR(MAX),
	@nombre varchar(max),
	@aPaterno varchar(max),
	@aMaterno varchar(max),
	@persona int
AS
	BEGIN
		UPDATE Integrante
		SET CURP = @curp, nombre = @nombre, apellido_paterno = @aPaterno, apellido_materno = @aMaterno, PersonaID = @persona
		WHERE IntegranteID = @id;
	END
RETURN 0
