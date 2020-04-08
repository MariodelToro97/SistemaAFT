CREATE PROCEDURE [dbo].[spUpdateCotizacion]
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
	@id int
AS
	BEGIN
		UPDATE Cotizacion
		SET Concepto_ApoyoID = @conc, Subconcepto_ApoyoID = @subcon, Unidad_Medida = @uniMed, Unidad_Impacto = @uniImp, can_Sol = @canSol, cos_Uni = @costUni, apo_Pro = @apoPro,
		apo_Fed = @apoFed, apo_Est = @apoEst, mon_Apo = @montApo, otro_Apo = @otroApo, inv_Total = @invTot, Descripcion = @desc
		where CotizacionID = @id;		
	END
RETURN