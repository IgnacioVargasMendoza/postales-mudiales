-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE dbo.EditarPostal
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
    BEGIN TRANSACTION
        SET NOCOUNT ON; -- Avoid extra result sets
        SET XACT_ABORT ON; -- Ensure transaction aborts on error
        -- Insert the new postcard
        UPDATE dbo.Postales
        SET
            IdPais = COALESCE(@IdPais, IdPais),
            IdGrupo = COALESCE(@IdGrupo, IdGrupo),
            Numero = COALESCE(@Numero, Numero),
            Tengo = COALESCE(@Tengo, Tengo),
            Posicion = COALESCE(@Posicion, Posicion),
            FechaAgregada = COALESCE(@FechaAgregada, FechaAgregada),
            Notas = COALESCE(@Notas, Notas)
        WHERE Id = @Id;

        -- Return the inserted row joined to Paises and Grupos for convenience
        SELECT @Id AS Id
    COMMIT TRANSACTION
END