-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE ObtenerPostales
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Paises.Nombre AS NombrePais, Paises.Bandera, Grupos.Nombre AS NombreGrupo, Grupos.Descripcion, Postales.*
FROM     Grupos INNER JOIN
                  Postales ON Grupos.Id = Postales.IdGrupo INNER JOIN
                  Paises ON Postales.IdPais = Paises.Id
END