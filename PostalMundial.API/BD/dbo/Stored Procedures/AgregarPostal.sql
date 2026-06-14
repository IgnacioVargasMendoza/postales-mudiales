-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.AgregarPostal
    @Id uniqueidentifier = NULL,
    @IdPais uniqueidentifier,
    @IdGrupo uniqueidentifier,
    @Numero int,
    @Tengo bit = 0,
    @Posicion varchar(max) = NULL,
    @FechaAgregada datetime = NULL,
    @Notas varchar(max) = NULL
AS
BEGIN
    BEGIN TRANSACTION;
        SET NOCOUNT ON; -- Avoid extra result sets
        SET XACT_ABORT ON; -- Ensure transaction aborts on error
        -- Insert the new postcard
        INSERT INTO dbo.Postales (Id, IdPais, IdGrupo, Numero, Tengo, Posicion, FechaAgregada, Notas)
        VALUES (@Id, @IdPais, @IdGrupo, @Numero, @Tengo, @Posicion, @FechaAgregada, @Notas);

        -- Return the inserted row joined to Paises and Grupos for convenience
        SELECT @Id as Id 
    COMMIT TRANSACTION;
END