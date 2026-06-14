CREATE PROCEDURE dbo.EliminarPostal
    @Id uniqueidentifier
AS
BEGIN
    BEGIN TRANSACTION;
        SET NOCOUNT ON;
        SET XACT_ABORT ON;

        DELETE FROM dbo.Postales
        WHERE (Postales.Id = @Id) 
        SELECT @Id AS Id
    COMMIT TRANSACTION;
END;