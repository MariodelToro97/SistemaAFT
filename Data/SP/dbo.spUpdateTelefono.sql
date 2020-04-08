CREATE PROCEDURE [dbo].[spUpdateTelefono]
	@id INT,
	@numero VARCHAR(MAX),
	@CompaniaID int,
	@Tipo_TelefonoID int,
	@persona int,
	@notificacion bit,
	@tel int OUTPUT
AS
	BEGIN
		IF NOT EXISTS(SELECT * FROM Telefono WHERE numero = @numero)
			BEGIN
				UPDATE Telefono
				SET numero = @numero, CompaniaID = @CompaniaID, Tipo_TelefonoID = @Tipo_TelefonoID, PersonaID = @persona, notificacion = @notificacion
				WHERE TelefonoID = @id;
				SELECT @tel = TelefonoID FROM Telefono WHERE TelefonoID = @id;
			END
		ELSE
			BEGIN
				IF EXISTS(SELECT * FROM Telefono WHERE numero = @numero AND TelefonoID = @id AND PersonaID = @persona)
				BEGIN
					UPDATE Telefono
					SET numero = @numero, CompaniaID = @CompaniaID, Tipo_TelefonoID = @Tipo_TelefonoID, PersonaID = @persona, notificacion = @notificacion
					WHERE TelefonoID = @id;
					SELECT @tel = TelefonoID FROM Telefono WHERE TelefonoID = @id;
				END
			END
	END
RETURN