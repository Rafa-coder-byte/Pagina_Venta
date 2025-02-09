
create database DBCarrito1

GO

USE DBCarrito1

GO

CREATE TABLE CATEGORIA(
Id int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),
)

go

CREATE TABLE MARCA(
Id int primary key identity,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),
)

go

CREATE TABLE PRODUCTO(
Id int primary key identity,
Nombre varchar(500),
Descripcion varchar(500),
IdMarca int references MARCA(Id),
IdCategoria int references CATEGORIA(Id),
Precio decimal(10,2) default 0,
Stock int,
RutaImagen varchar(100),
NombreImagen varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),
)

go

CREATE TABLE DIR_CLIENTE(
IdDirCliente varchar(4),
Pais varchar(50),
Provincia varchar(50),
Distrito varchar(50),
Direccion varchar(200),
)

go 

CREATE TABLE CLIENTE(
Id int primary key identity,
Nombre varchar(100),
Apellidos varchar(200),
Correo varchar(100),
Clave varchar(150),
Reestablecer bit default 1,
FechaRegistro datetime default getdate(),
)

go



CREATE TABLE CARRITO(
Id int primary key identity,
IdCliente int references CLIENTE(Id),
IdProducto int references PRODUCTO(Id),
Cantidad int,
)

go

CREATE TABLE VENTA(
Id int primary key identity,
IdCliente int references CLIENTE(Id),
TotalProducto int,
MontoTotal decimal(10,3),
Contacto varchar (50),
Telefono varchar(50),
Direccion varchar(500),
IdTransaccion varchar (50),
RutaImagen varchar(100),
FechaVenta datetime default getdate(),
)

go

CREATE TABLE DETALLE_VENTA(
Id int primary key identity,
IdVenta int references VENTA(Id),
IdProducto int references PRODUCTO(Id),
Cantidad int,
TotalDecimal decimal (10,2),
)

go

CREATE TABLE USUARIO(
Id int primary key identity,
Nombre varchar(100),
Apellidos varchar(200),
Correo varchar(100),
Clave varchar(150),
Activo bit default 1,
Reestablecer bit default 1,
FechaRegistro datetime default getdate(),
)

go


