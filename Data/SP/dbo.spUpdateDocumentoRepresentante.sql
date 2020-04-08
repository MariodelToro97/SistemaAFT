CREATE PROCEDURE [dbo].[spUpdateDocumentoRepresentante]
	@id int,
	@tipoDoc smallint,
	@folio varchar(max),
	@fecha varchar(max),
	@docu int OUTPUT
AS
	BEGIN
		UPDATE documentoRepresentante
		SET Tipo_DocumentoID = @tipoDoc, folioDocumento = @folio, fechaDocumento = @fecha
		WHERE documentoRepresentanteID = @id;

		SELECT @docu = documentoRepresentanteID FROM documentoRepresentante WHERE documentoRepresentanteID = @id;
	END	
RETURN 