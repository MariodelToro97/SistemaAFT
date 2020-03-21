CREATE PROCEDURE [dbo].[spDeleteDocumentoRepresentante]
	@id int
AS
	BEGIN
		DELETE FROM documentoRepresentante WHERE documentoRepresentanteID = @id;
	END	
RETURN 0
