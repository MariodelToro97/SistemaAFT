CREATE PROCEDURE [dbo].[spUpdateDocumentoRepresentante]
	@id int,
	@tipoDoc varchar(max),
	@folio varchar(max),
	@fecha varchar(max),
	@repre int
AS
	BEGIN
		UPDATE documentoRepresentante
		SET tipoDocumento = @tipoDoc, folioDocumento = @folio, fechaDocumento = @fecha, RepresentanteID = @repre
		WHERE documentoRepresentanteID = @id;
	END	
RETURN 0
