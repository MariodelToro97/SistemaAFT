CREATE PROCEDURE [dbo].[spAddTelefono]
	@numero VARCHAR (MAX),
	@CompaniaID int,
	@Tipo_TelefonoID int,
	@persona int,
	@ID int OUTPUT
AS
	BEGIN
		IF NOT EXISTS(SELECT * FROM Telefono WHERE numero = @numero)
			BEGIN
				INSERT INTO Telefono VALUES (@numero, @CompaniaID, @Tipo_TelefonoID, @persona);
				SELECT @ID = TelefonoID FROM Telefono WHERE numero = @numero;
			END
	END
RETURN