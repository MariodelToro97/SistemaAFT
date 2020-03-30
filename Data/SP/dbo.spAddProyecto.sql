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
		SELECT @ID = ProyectoID FROM Proyecto WHERE nombreProyecto = @nombreproyecto AND Tipo_ProyectoID = @tipoproyecto AND objetivo = @objetivo AND fechaRecepcion = @fecha AND SolicitudID = @solicitudID;
	END
RETURN 