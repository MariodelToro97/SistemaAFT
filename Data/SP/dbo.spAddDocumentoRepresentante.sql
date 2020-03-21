CREATE PROCEDURE [dbo].[spAddDocumentoRepresentante]
	@tipoDoc varchar(max),
	@folio varchar(max),
	@fecha varchar(max),
	@repre int
AS
	BEGIN
		INSERT INTO documentoRepresentante VALUES (@tipoDoc, @folio, @fecha, @repre);
	END	
RETURN 0
