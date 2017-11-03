DROP DATABASE IF EXISTS kivon;
CREATE DATABASE kivon;
USE kivon

-- crear tabla "rol"

CREATE TABLE ROL(
    idRol int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    nombreRol varchar(30) not null
) ENGINE=InnoDB;

-- crear tabla "sucursal"

CREATE TABLE sucursal(
    idSucursal int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    nit varchar(20) not null,
    nombreEmpresa varchar(30) not null,
    numeroSucursal int UNIQUE not null,
    numeroAutorizacion varchar(15) not null,
    direccion varchar(50) not null
) ENGINE=InnoDB;

-- crear tabla "telefono de sucursal"

CREATE TABLE telefonoSucursal(
    idTelefonoSucursal int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    idSucursal int UNSIGNED not null,
    numero int not null,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "categoria de productos"

CREATE TABLE categoriaProducto(
    idCategoria int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    nombre varchar(30) not null
) ENGINE=InnoDB;

-- crear tabla "productos"

CREATE TABLE producto(
    idProducto varchar(20) not null PRIMARY KEY,
    idSucursal int UNSIGNED not null,
    idCategoria int UNSIGNED not null,
    nombre varchar(30) not null,
    precio float not null,
    imagen varchar(200) not null,
    descripcion varchar(100) not null,
    cantidad int not null,
    estado ENUM("S","N") not null,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idCategoria) REFERENCES categoriaProducto(idCategoria) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "usuario"

CREATE TABLE usuario(
    idUsuario INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    idRol INT UNSIGNED NOT NULL,
    idSucursal INT UNSIGNED NOT NULL,
    primerNombre VARCHAR(20) NOT NULL,
    segundoNombre VARCHAR(20),
    apellidoPaterno VARCHAR(20) NOT NULL,
    apellidoMaterno VARCHAR(20),
    ci VARCHAR(12) UNIQUE NOT NULL,
    lugarExpedicion VARCHAR(15) NOT NULL,
    fechaNacimiento DATE NOT NULL,
    fotografia VARCHAR(30),
    numeroCelular INT NOT NULL,
    login VARCHAR(20) UNIQUE NOT NULL,
    password VARCHAR(20) NOT NULL,
    activo BOOLEAN NOT NULL,
    FOREIGN KEY(idRol) REFERENCES rol(idRol) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "referencia de usuarios"

CREATE TABLE referenciaUsuario(
    idReferenciaUsuario INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    idUsuario INT UNSIGNED NOT NULL,
    primerNombre VARCHAR(20) NOT NULL,
    segundoNombre VARCHAR(20),
    apellidoPaterno VARCHAR(20) NOT NULL,
    apellidoMaterno VARCHAR(20),
    numeroCelular INT NOT NULL,
    ci VARCHAR(12) UNIQUE NOT NULL,
    lugarExpedicion VARCHAR(15) NOT NULL,
    fechaNacimiento DATE NOT NULL,
    fotografiaCarnet VARCHAR(30),
    FOREIGN KEY(idUsuario) REFERENCES usuario(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "cliente"

CREATE TABLE cliente(
    idCliente INT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    idSucursal INT UNSIGNED NOT NULL,
    ci VARCHAR(15) UNIQUE NOT NULL,
    nit VARCHAR(20) UNIQUE NOT NULL,
    primerNombre VARCHAR(20) NOT NULL,
    segundoNombre VARCHAR(20),
    apellidoPaterno VARCHAR(20) NOT NULL,
    apellidoMaterno VARCHAR(20),
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "pedido"

CREATE TABLE pedido(
    idPedido int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    idUsuario int UNSIGNED not null,
    idSucursal int UNSIGNED not null,
    fechaPedido date not null,
    horaPedido time not null,
    FOREIGN KEY(idUsuario) REFERENCES usuario(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "detalle de pedido"

CREATE TABLE detallePedido(
	idPedido int UNSIGNED not null,
	idProducto varchar(20) not null,
	cantidad int not null,
    precio float not null,
    FOREIGN KEY(idPedido) REFERENCES pedido(idPedido) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idProducto) REFERENCES producto(idProducto) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "venta"

CREATE TABLE venta(
    idVenta int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    idPedido int UNSIGNED not null,
    idCliente int UNSIGNED not null,
    idSucursal int UNSIGNED not null,
    idUsuario int UNSIGNED not null,
    montoTotalVenta float not null,
    fechaVenta date not null,
    horaVenta time not null,
    FOREIGN KEY(idPedido) REFERENCES pedido(idPedido) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idCliente) REFERENCES cliente(idCliente) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idUsuario) REFERENCES usuario(idUsuario) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;

-- crear tabla "factura"

CREATE TABLE factura(
    idFactura int UNSIGNED not null AUTO_INCREMENT PRIMARY KEY,
    idVenta int UNSIGNED not null,
    idSucursal int UNSIGNED not null,
    numeroFactura int not null,
    codigoControl int not null,
    fechaLimiteEmision date not null,
    FOREIGN KEY(idVenta) REFERENCES venta(idVenta) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(idSucursal) REFERENCES sucursal(idSucursal) ON UPDATE CASCADE ON DELETE CASCADE
) ENGINE=InnoDB;



