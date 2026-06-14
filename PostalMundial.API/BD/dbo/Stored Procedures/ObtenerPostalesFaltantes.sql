-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.ObtenerPostalesFaltantes
AS
BEGIN
    SET NOCOUNT ON;

    -- Select postales not owned and apply optional filters
    SELECT p.Nombre    AS NombrePais,
           p.Bandera,
           g.Nombre    AS NombreGrupo,
           g.Descripcion,
           ps.Id,
           ps.IdPais,
           ps.IdGrupo,
           ps.Numero,
           ps.Tengo,
           ps.Posicion,
           ps.FechaAgregada,
           ps.Notas
    FROM dbo.Postales ps
    JOIN dbo.Paises p ON ps.IdPais = p.Id
    JOIN dbo.Grupos g ON ps.IdGrupo = g.Id
    WHERE ps.Tengo = 0 -- postcards not owned
    ORDER BY ps.Numero;
END;