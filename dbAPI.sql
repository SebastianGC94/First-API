
CREATE DATABASE dbAPI

USE dbAPI

CREATE TABLE CATEGORIA(
idCategoria int primary key identity (1,1),
descripcion varchar (100),
)

CREATE TABLE DATOS(
idDatos int primary key identity (1,1),
descripcion varchar (100),
)

CREATE TABLE PRODUCTOS(
idProducto int primary key identity (1,1),
codigo varchar (20),
descripcion varchar (50),
marca varchar (50),
idCategoria int,
precio decimal (10,2),
CONSTRAINT FK_IDCATEGORIA FOREIGN KEY (idCategoria) REFERENCES CATEGORIA (idCategoria),
)

CREATE TABLE USUARIOS(
idUsuario int primary key identity (1,1),
identificacion varchar (20),
nombre varchar (100),
apellido varchar (100),
direccion varchar (100),
correo varchar (100),
telefono varchar (10)
)

CREATE TABLE Orden (
    idOrden INT PRIMARY KEY ,
	descripcion VARCHAR(255),
	fecha DATETIME,
	idUsuario INT,
    FOREIGN KEY (idUsuario ) REFERENCES Usuarios(idUsuario )
);

CREATE TABLE DetallesOrden (
    idDetalle INT PRIMARY KEY,
    idOrden INT,
    idProducto INT,
    cantidad INT,
	precio decimal (10,2),
    FOREIGN KEY (idOrden ) REFERENCES Orden(idOrden ),
    FOREIGN KEY (idProducto ) REFERENCES Productos(idProducto )
);



INSERT INTO CATEGORIA (descripcion) values 
('Tecnología'),
('Hogar'),
('Accesorios')

INSERT INTO DATOS (descripcion) values 
('prueba')

INSERT INTO PRODUCTOS (codigo,descripcion,marca,idCategoria,precio) values 
('00001', 'Monitor Gaming', 'Asus', 1, 1500),
('00002', 'Lavadora', 'Haceb', 2, 1955)

INSERT INTO USUARIOS(identificacion,nombre,apellido,direccion,correo,telefono) values 
('123456789', 'Fabio', 'Rodriguez','Cra 25 #123','fabio@correo','12345')


INSERT INTO Orden(idOrden,descripcion,fecha,idUsuario) values 
(1,'Pedido # 1', 2023-05-02, 1)


INSERT INTO DetallesOrden(idDetalle,idOrden,idProducto,cantidad,precio) values 
(1, 1, 1,10,127850)





SELECT * FROM CATEGORIA
SELECT * FROM PRODUCTOS
SELECT * FROM USUARIOS
SELECT * FROM DATOS
SELECT * FROM Orden
SELECT * FROM DetallesOrden


/*SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'orden';

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'dbAPI';*/
