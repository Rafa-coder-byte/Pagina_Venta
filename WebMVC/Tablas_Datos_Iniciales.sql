
select * from USUARIO
insert into USUARIO(Nombre,Apellidos,Correo, Clave) values('test nombre', 'test apellido', 'text@example.com', 'ecd71870d1963316a97e3ac3408c9835ad8cf0f3c1bc703527c30265534f75ae')


select * from CATEGORIA
insert into CATEGORIA(Descripcion)  values
('Tecnologia'),
('Muebles'),
('Dormitorio'),
('Deportes')


select * from MARCA
insert into MARCA(Descripcion)  values
('ZTEIE'),
('SAMSU'),
('HYUND'),
('HPTI'),
('CANONTE'),
('RAMIRA TONTI')

   

select * from DIR_CLIENTE
insert into DIR_CLIENTE(IdDirCliente, Pais, Provincia, Distrito, Direccion) values('1','Test Pais','Test Provincia','Test Distrito','Test Direccion')