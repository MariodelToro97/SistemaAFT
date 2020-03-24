CREATE PROCEDURE [dbo].spAddProyecto
	@nombreproyecto VARCHAR (MAX),
	@tipoproyecto int,
	@objetivo VARCHAR (MAX),
	@fecha VARCHAR (MAX),
	@solicitudID int,
	@ID int OUTPUT
AS
	BEGIN
		INSERT INTO Proyecto VALUES (@nombreproyecto, @tipoproyecto, @objetivo, @fecha, @solicitudID);
		SELECT @ID = ProyectoID FROM Proyecto;

	END
RETURN 0