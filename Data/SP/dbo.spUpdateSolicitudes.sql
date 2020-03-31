CREATE PROCEDURE [dbo].[spUpdateSolicitudes]
	@year int,
	@programa int,
	@componente int,
	@instancia int,
	@delegacion int,
	@estado VARCHAR (MAX),
	@id int
AS
	BEGIN
		Update Solicitud
		SET YearID = @year, ProgramaID = @programa, ComponenteID = @componente, Instancia_EjecutoraID = @instancia, DelegacionID = @delegacion, estado = @estado
		WHERE SolicitudID = @id;		
	END
RETURN 0
