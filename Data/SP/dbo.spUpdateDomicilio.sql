CREATE PROCEDURE [dbo].[spUpdateDomicilio]
	@domID  int,
	@tipoAmbito int,
	@estado varchar(max),
	@asentamiento varchar(max),
	@vialidad int,
	@noExterior varchar(max),
	@munID int,
	@refVialidad varchar(max),
	@nomViali varchar(max),
	@noInterior varchar(max),
	@localidad varchar (max),
	@referenciaPos varchar(max),
	@cp varchar(max),
	@tipoAsentamiento int,
	@referencia varchar(max),
	@personaID int
AS
	BEGIN
		UPDATE Domicilio
		Set Tipo_AmbitoID = @tipoAmbito, estado = @estado, nombreasentamiento = @asentamiento, Tipo_VialidadID = @vialidad, noexterior = @noExterior, MunicipioID = @munID, referenciavialidad = @refVialidad, nombrevialidad = @nomViali, nointerior = @noInterior, localidad = @localidad, referenciaposterior = @referenciaPos, codigopostal = @cp, Tipo_AsentamientoID = @tipoAsentamiento, referenciaubicacion = @referencia, PersonaID = @personaID
		WHERE DomicilioID = @domID;
	END
RETURN 0