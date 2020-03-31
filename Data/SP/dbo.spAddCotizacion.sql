CREATE PROCEDURE [dbo].[spAddCotizacion]
	@conc int,
	@subcon int,
	@uniMed varchar(max),
	@uniImp varchar(max),
	@canSol float,
	@costUni float,
	@apoPro float,
	@apoFed float,
	@apoEst float,
	@montApo float,
	@otroApo float,
	@invTot float,
	@desc varchar (max),
	@proyecto int,
	@idCot int OUTPUT
AS
	BEGIN
		INSERT INTO Cotizacion VALUES (@conc, @subcon, @uniMed, @uniImp, @canSol, @costUni, @apoPro, @apoFed, @apoEst, @montApo, @otroApo, @invTot, @desc, @proyecto);

		Select @idCot = CotizacionID 
		FROM Cotizacion 
		WHERE Concepto_ApoyoID = @conc AND
		Subconcepto_ApoyoID = @subcon AND
		Unidad_Medida = @uniMed AND
		Unidad_Impacto = @uniImp AND
		can_Sol = @canSol AND
		cos_Uni = @costUni AND
		apo_Pro = @apoPro AND
		apo_Fed = @apoFed AND
		apo_Est = @apoEst AND
		mon_Apo = @montApo AND
		otro_Apo = @otroApo AND
		inv_Total = @invTot AND
		Descripcion = @desc AND
		ProyectoID = @proyecto;
	END
RETURN 
