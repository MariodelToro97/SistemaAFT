CREATE PROCEDURE [dbo].[spAddPersona]
	@CURP varchar(max),
	@rfc varchar (max),
	@nombre varchar(max),
	@aPaterno varchar(max),
	@aMaterno varchar(max),
	@correo varchar (max),
	@nacimiento varchar(max),
	@nacionalidad smallint,
	@genero smallint,
	@civil smallint,
	@identidad smallint,
	@identificacion varchar(max),
	@persona smallint, /*Tipo de persona*/
	@etnia smallint,
	@discapacidad INT,
	@suri varchar(max),
	@moral varchar(max),
	@actEcon int,
	@fecha_con varchar(max),
	@folio varchar(max),
	@notario int,
	@ID int OUTPUT
AS
	BEGIN

		IF (@persona = 1) /* PERSONA FÍSICA */
		BEGIN
			IF NOT EXISTS(SELECT * FROM Persona WHERE CURP = @CURP)
				BEGIN
					INSERT INTO Persona VALUES (@CURP, @rfc, @nombre, @aPaterno, @aMaterno, @correo, @nacimiento, @nacionalidad, @genero, @civil, @identidad, @identificacion, @persona, @etnia, @discapacidad, @suri, @moral, GETDATE(), @actEcon, @fecha_con, @folio, @notario);
					SELECT @ID = PersonaID FROM Persona WHERE CURP = @CURP;
				END
		END

		ELSE	/* PERSONA MORAL */
			BEGIN
				IF NOT EXISTS(SELECT * FROM Persona WHERE RFC = @rfc)
				BEGIN
					INSERT INTO Persona VALUES (@CURP, @rfc, @nombre, @aPaterno, @aMaterno, @correo, @nacimiento, @nacionalidad, @genero, @civil, @identidad, @identificacion, @persona, @etnia, @discapacidad, @suri, @moral, GETDATE(), @actEcon, @fecha_con, @folio, @notario);
					SELECT @ID = PersonaID FROM Persona WHERE RFC = @rfc;
				END
			END
	END
	RETURN