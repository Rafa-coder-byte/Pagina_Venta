
select * from USUARIO


INSERT INTO USUARIO(Id, Nombre, Apellidos, Correo, Clave)
VALUES ('55345678-1234-1234-1234-123456789012', 'test Rafa', 'test apellido', 'text@example.com', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae');


select * from CATEGORIA

INSERT INTO CATEGORIA(Id, Descripcion)
VALUES 
('11111111-1111-1111-1111-111111111112', 'Tecnologia'),
('22222222-2222-2222-2222-222222222223', 'Muebles'),
('33333333-3333-3333-3333-333333333334', 'Dormitorio'),
('44444444-4444-4444-4444-444444444445', 'Deportes');


select * from MARCA

INSERT INTO MARCA(Id, Descripcion)
VALUES 
('11111111-1111-4111-B111-111111111112', 'ZTEIE'),
('22222222-2222-4222-B222-222222222223', 'SAMSU'),
('33333333-3333-4333-B333-333333333334', 'HYUND'),
('44444444-4444-5444-B444-444444444445', 'HPTI'),
('55555555-cb9b-a7a7-b9b9-b9b9b9b9b960', 'CANONTE'), -- Este ya estaba bien
('66666666-d6d6-d6d6-d6d6-d6d6d6d6d670', 'RAMIRA TONTI'); -- Este también estaba bien


select * from DIR_CLIENTE
insert into DIR_CLIENTE(IdDirCliente, Pais, Provincia, Distrito, Direccion) values('1','Test Pais','Test Provincia','Test Distrito','Test Direccion')


UPDATE USUARIO SET Activo = 0 WHERE Id = '55345678-1234-1234-1234-123456789012';
-- Reemplaza {guid-del-usario} por el valor real del usuario que deseas actualizar


