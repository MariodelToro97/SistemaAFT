CREATE PROCEDURE [dbo].[spDeleteCotizacion]
	@intID int,
	@proyecto int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM Cotizacion WHERE CotizacionID = @intID;
		SELECT @contador = COUNT(CotizacionID) FROM Cotizacion WHERE ProyectoID= @proyecto;
	END
RETURN