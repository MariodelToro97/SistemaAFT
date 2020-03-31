CREATE PROCEDURE [dbo].[spUpdateProyecto]
	@nombreproyecto VARCHAR (MAX),
	@tipoproyecto int,
	@objetivo VARCHAR (MAX),
	@fecha VARCHAR (MAX),
	@solicitudID int,
	@id int
AS
	BEGIN
		UPDATE Proyecto
		SET nombreProyecto = @nombreproyecto, Tipo_ProyectoID = @tipoproyecto, objetivo = @objetivo, fechaRecepcion = @fecha
		WHERE ProyectoID = @id;		
	END
RETURN 0
