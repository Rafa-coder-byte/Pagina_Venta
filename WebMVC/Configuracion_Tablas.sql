
create database DBCarrito0

GO

USE DBCarrito0

GO

CREATE TABLE CATEGORIA(
Id UNIQUEIDENTIFIER PRIMARY KEY,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),
)

go

CREATE TABLE MARCA(
Id UNIQUEIDENTIFIER PRIMARY KEY,
Descripcion varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),
)

go

CREATE TABLE PRODUCTO(
Id UNIQUEIDENTIFIER PRIMARY KEY,
Nombre varchar(500),
Descripcion varchar(500),
IdMarca UNIQUEIDENTIFIER NOT NULL,
IdCategoria UNIQUEIDENTIFIER NOT NULL,
Precio decimal(10,2) default 0,
Stock int,
RutaImagen varchar(100),
NombreImagen varchar(100),
Activo bit default 1,
FechaRegistro datetime default getdate(),

CONSTRAINT FK_PRODUCTO_MARCA FOREIGN KEY (IdMarca) REFERENCES MARCA(Id),
    CONSTRAINT FK_PRODUCTO_CATEGORIA FOREIGN KEY (IdCategoria) REFERENCES CATEGORIA(Id)
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
Id UNIQUEIDENTIFIER PRIMARY KEY,
Nombre varchar(100),
Apellidos varchar(200),
Correo varchar(100),
Clave varchar(150),
Reestablecer bit default 1,
FechaRegistro datetime default getdate(),
)

go



CREATE TABLE CARRITO (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    IdCliente UNIQUEIDENTIFIER NOT NULL,
    IdProducto UNIQUEIDENTIFIER NOT NULL,
    Cantidad int,

    CONSTRAINT FK_CARRITO_CLIENTE FOREIGN KEY (IdCliente) REFERENCES CLIENTE(Id),
    CONSTRAINT FK_CARRITO_PRODUCTO FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(Id)
);
go

CREATE TABLE VENTA(
Id UNIQUEIDENTIFIER PRIMARY KEY,
IdCliente UNIQUEIDENTIFIER NOT NULL,
TotalProducto int,
MontoTotal decimal(10,3),
Contacto varchar (50),
Telefono varchar(50),
Direccion varchar(500),
IdTransaccion varchar (50),
RutaImagen varchar(100),
FechaVenta datetime default getdate(),

CONSTRAINT FK_VENTA_CLIENTE FOREIGN KEY (IdCliente) REFERENCES CLIENTE(Id)
);

go

CREATE TABLE DETALLE_VENTA(
Id UNIQUEIDENTIFIER PRIMARY KEY,
IdVenta UNIQUEIDENTIFIER NOT NULL,
IdProducto UNIQUEIDENTIFIER NOT NULL, 
Cantidad int,
TotalDecimal decimal (10,2),

CONSTRAINT FK_DETALLE_VENTA_VENTA FOREIGN KEY (IdVenta) REFERENCES VENTA(Id),
CONSTRAINT FK_DETALLE_VENTA_PRODUCTO FOREIGN KEY (IdProducto) REFERENCES PRODUCTO(Id)
);

go

CREATE TABLE USUARIO(
Id UNIQUEIDENTIFIER PRIMARY KEY,
Nombre varchar(100),
Apellidos varchar(200),
Correo varchar(100),
Clave varchar(150),
Activo bit default 1,
Reestablecer bit default 1,
FechaRegistro datetime default getdate(),
)

go


