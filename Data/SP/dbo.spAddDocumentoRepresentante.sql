CREATE PROCEDURE [dbo].[spAddDocumentoRepresentante]
	@tipoDoc int,
	@folio varchar(max),
	@fecha varchar(max),
	@repre int,
	@ID INT OUTPUT
AS
	BEGIN
		INSERT INTO documentoRepresentante VALUES (@tipoDoc, @folio, @fecha, @repre);
		SELECT @ID = documentoRepresentanteID FROM documentoRepresentante WHERE Tipo_DocumentoID = @tipoDoc AND RepresentanteID = @repre AND fechaDocumento = @fecha AND folioDocumento = @folio 
	END	
RETURN 
