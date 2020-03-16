CREATE PROCEDURE [dbo].[spAddIntegrante]
	@numero VARCHAR (MAX),
	@CompaniaID int,
	@Tipo_TelefonoID int,
	@persona int
AS
	BEGIN
		INSERT INTO Telefono VALUES (@numero, @CompaniaID, @Tipo_TelefonoID, @persona);
	END
RETURN 0
