CREATE PROCEDURE [dbo].[spUpdateTelefono]
	@id INT,
	@numero VARCHAR(MAX),
	@CompaniaID int,
	@Tipo_TelefonoID int,
	@persona int,
	@tel int OUTPUT
AS
	BEGIN
		IF NOT EXISTS(SELECT * FROM Telefono WHERE numero = @numero)
			BEGIN
				UPDATE Telefono
				SET numero = @numero, CompaniaID = @CompaniaID, Tipo_TelefonoID = @Tipo_TelefonoID, PersonaID = @persona
				WHERE TelefonoID = @id;
				SELECT @tel = TelefonoID FROM Telefono WHERE TelefonoID = @id;
			END
	END
RETURN