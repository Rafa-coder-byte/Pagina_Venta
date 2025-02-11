
select *from USUARIO

CREATE PROCEDURE sp_RegistrarUsuario(
@nombre VARCHAR(100),
@apellidos VARCHAR(200),
@correo VARCHAR(100),
@clave VARCHAR(150),
@activo bit,
@Mensaje VARCHAR(500) output,
@Resultado UNIQUEIDENTIFIER output
)

AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE correo = @correo)
        BEGIN TRY
		
            DECLARE @_guid UNIQUEIDENTIFIER = NEWID();

            INSERT INTO USUARIO (id,nombre, apellidos, correo,clave,activo)
            VALUES (@_guid, @nombre, @apellidos, @correo,@clave,@activo);

			-- Almacena el GUID generado en la variable de salida.
            SET @Resultado = @_guid;
            PRINT 'Usuario registrado correctamente.';
        END TRY
        BEGIN CATCH
            DECLARE @ErrorMessage NVARCHAR(MAX);
            SET @ErrorMessage = ERROR_MESSAGE();
            RAISERROR (@ErrorMessage, 16, 1);
        END CATCH;
    ELSE 
        Set @Mensaje = 'El correo del usuario ya existe'
		END;
GO


CREATE PROCEDURE sp_EditarUsuario(
@id UNIQUEIDENTIFIER,
@nombre VARCHAR(100),
@apellidos VARCHAR(200),
@correo VARCHAR(100),
@activo bit,
@Mensaje VARCHAR(500) output,
@Resultado bit output
)

AS
BEGIN
          SET @Resultado=0
    IF NOT EXISTS (SELECT 1 FROM USUARIO WHERE correo = @correo and id != @id)
        BEGIN TRY
		
          update top (1) USUARIO set
		  Nombre = @nombre,
		  Apellidos = @apellidos,
		  Correo = @correo,
		  Activo = @activo
		  where id=@id

		  SET @Resultado=1
            PRINT 'Usuario registrado correctamente.';
        END TRY
        BEGIN CATCH
            DECLARE @ErrorMessage NVARCHAR(MAX);
            SET @ErrorMessage = ERROR_MESSAGE();
            RAISERROR (@ErrorMessage, 16, 1);
        END CATCH;
    ELSE 
        Set @Mensaje = 'El correo del usuario ya existe'
		END;
GO