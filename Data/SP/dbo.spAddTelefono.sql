CREATE PROCEDURE [dbo].[spAddIntegrante]
	@numero VARCHAR (MAX),
	@CompaniaID int,
	@Tipo_TelefonoID int,
	@persona int,
	@ID int OUTPUT
AS
	BEGIN
		INSERT INTO Telefono VALUES (@numero, @CompaniaID, @Tipo_TelefonoID, @persona);
		SELECT @ID = TelefonoID FROM Telefono WHERE PersonaID = @persona;

	END
RETURN 0
