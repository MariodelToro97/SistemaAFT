CREATE PROCEDURE [dbo].[spAddDomicilio]
	@tipoAmbito int,
	@estado varchar(max),
	@asentamiento varchar(max),
	@vialidad int,
	@noExterior varchar(max),
	@munID varchar(max),
	@refVialidad varchar(max),
	@nomViali varchar(max),
	@noInterior varchar(max),
	@localidad varchar (max),
	@referenciaPos varchar(max),
	@cp varchar(max),
	@tipoAsentamiento int,
	@referencia varchar(max),
	@personaID int,
	@ID int OUTPUT
AS
	BEGIN
		INSERT INTO Domicilio VALUES (@tipoAmbito, @estado, @asentamiento, @vialidad, @noExterior, @munID, @refVialidad, @nomViali, @noInterior, @localidad, @referenciaPos, @cp, @tipoAsentamiento, @referencia, @personaID);
		SELECT @ID = DomicilioID FROM Domicilio WHERE PersonaID = @personaID;

	END
RETURN 0