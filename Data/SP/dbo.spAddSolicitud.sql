CREATE PROCEDURE [dbo].spAddSolicitud
	@year int,
	@programa int,
	@componente int,
	@instancia int,
	@delegacion int,
	@estado VARCHAR (MAX),
	@persona int,
	@ID int OUTPUT
AS
	BEGIN
		INSERT INTO Solicitud VALUES (@year, @programa, @componente, @instancia, @delegacion, @estado, @persona);
		SELECT TOP 1 @ID = SolicitudID FROM Solicitud WHERE YearID = @year AND ProgramaID = @programa AND ComponenteID = @componente AND 
		Instancia_EjecutoraID = @instancia AND DelegacionID = @delegacion AND estado = @estado AND PersonaID = @persona ORDER BY SolicitudID DESC;
	END
RETURN 