CREATE PROCEDURE [dbo].[spDeleteDocumentoRepresentante]
	@id int,
	@repre int,
	@contador int OUTPUT
AS
	BEGIN
		DELETE FROM documentoRepresentante WHERE documentoRepresentanteID = @id;
		SELECT @contador = COUNT(documentoRepresentanteID) FROM documentoRepresentante WHERE RepresentanteID = @repre;
	END	
RETURN 