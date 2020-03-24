CREATE PROCEDURE [dbo].spAddSolicitud
	@year int,
	@programa int,
	@componente int,
	@instancia int,
	@delegacion int,
	@estado VARCHAR (MAX),
	@ID int OUTPUT
AS
	BEGIN
		INSERT INTO Solicitud VALUES (@year, @programa, @componente, @instancia, @delegacion, @estado);
		SELECT @ID = SolicitudID FROM Solicitud;

	END
RETURN 0