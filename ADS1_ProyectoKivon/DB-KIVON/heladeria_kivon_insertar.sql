

-- insertar roles = 4 roles
insert into rol (idRol, nombreRol) value(null, 'administrador');  -- ID = 1
insert into rol (idRol, nombreRol) value(null, 'contador');       -- ID = 2
insert into rol (idRol, nombreRol) value(null, 'mesero');         -- ID = 3
insert into rol (idRol, nombreRol) value(null, 'cajero');         -- ID = 4

-- insertar datos de la sucursal
insert into sucursal (idSucursal, nombreEmpresa, numeroSucursal, NIT, numeroAutorizacion, direccion) value(null, 'Heladeria Kivon', 1, '4836551', '1234510', 'esquina Paraguay y Colombia/ No 1023/ OTB Campos Verdes');

-- insertar telfonos de la sucursal
insert into telefonoSucursal (idTelefonoSucursal, idSucursal, numero) value(null, 1, 71737123); -- ID = 1
insert into telefonoSucursal (idTelefonoSucursal, idSucursal, numero) value(null, 1, 71737124); -- ID = 2
insert into telefonoSucursal (idTelefonoSucursal, idSucursal, numero) value(null, 1, 71737125); -- ID = 3

-- insertar categorias de porductos
insert into categoriaProducto (idCategoria, nombre) value(null, 'HELADO');        -- ID = 1
insert into categoriaProducto (idCategoria, nombre) value(null, 'SALTENHA');      -- ID = 2
insert into categoriaProducto (idCategoria, nombre) value(null, 'PORCION_TORTA'); -- ID = 3
insert into categoriaProducto (idCategoria, nombre) value(null, 'HAMBURGUESA');   -- ID = 4
insert into categoriaProducto (idCategoria, nombre) value(null, 'JUGO');          -- ID = 5
insert into categoriaProducto (idCategoria, nombre) value(null, 'GASEOSA');       -- ID = 6

-- insertar productos
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('HELADO-1', 1, 1, 'Helado Cono Simple', 6.00, '/imagenes_helados/1', '2 bolas a elección', 30, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('HELADO-2', 1, 1, 'Helado Cono Doble', 8.00, '/imagenes_helados/2', '3 bolas a eleccion', 30, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('SALTENHA-1', 1, 2, 'salteña de pollo', 6.50, '/imagenes_salteñas/1', 'salteña normal con pollo', 0, 'N');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('SALTENHA-2', 1, 2, 'salteña de carne', 6.50, '/imagenes_salteñas/2', 'salteña normal con carne de res', 0, 'N');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('PORCION_TORTA-1', 1, 3, 'selva negra', 10.00, '/imagenes_tortas/1', 'torta de chocolate + cubieta de chocolate derretido', 25, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('PORCION_TORTA-2', 1, 3, 'tropical', 11.00, '/imagenes_tortas/2', 'torta de vainilla + cubierta de crema blanca + trozos de frutilla + trozos de durazno', 15, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('HAMBURGUESA-1', 1, 4, 'hamburguesa simple', 20.00, '/imagenes_hamburguesas/1', '1 rebanada de carne de res + tomate + lechuga + pepinillos + queso derretido', 13, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('HAMBURGUESA-2', 1, 4, 'hamburguesa doble', 28.50, '/imagenes_hamburguesas/2', '2 rebanada de carne de res + tomate + lechuga + pepinillos + queso derretido', 27, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('JUGO-1', 1, 5, 'jugo de frutilla', 10.00, '/imagenes_jugos/1', 'jugo de frutilla con/sin leche', 0, 'N');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('JUGO-2', 1, 5, 'jugo de platano', 10.00, '/imagenes_jugos/2', 'jugo de platano con/sin leche', 26, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('GASEOSA-1', 1, 6, 'Coca-Cola', 15.00, '/imagenes_gaseosas/1', 'botella de 2 litros', 50, 'S');
insert into producto (idProducto, idSucursal, idCategoria, nombre, precio, imagen, descripcion, cantidad, estado)
value('GASEOSA-2', 1, 6, 'Sprite', 15.00, '/imagenes_gaseosas/2', 'botella de 2 litros', 43, 'S');

-- insertar usuarios
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 1, 1, 'Ismael', 'Jhaziel', 'Sarzuri', 'Rojas', '8333482', 'LP', '1998-08-30', '/fotos_usuarios/1', '77561348', 'isarzuri', 'isarzuri', TRUE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 2, 1, 'Carlos', 'Alberto', 'Ojeda', 'Vargas', '8333483', 'SC', '1997-01-15', '/fotos_usuarios/2', '77316431', 'cojeda', 'cojeda', TRUE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 3, 1, 'Jose Maria', '', 'Mendoza', 'Mamani', '8333484', 'LP', '1997-02-20', '/fotos_usuarios/3', '71767349', 'jmendoza', 'jmendoza', FALSE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 3, 1, 'Luis', '', 'Montaño', '', '8333485', 'LP', '1995-02-16', '/fotos_usuarios/4', '77966358', 'lmontaño', 'lmontaño', FALSE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 3, 1, 'Daniel', '', 'Resoalbe', '', '8333486', 'CB', '1998-06-30', '/fotos_usuarios/5', '71757468', 'dresoalbe', 'dresoalbe', FALSE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 4, 1, 'Yessica', 'Ester', 'Navarro', 'Suarez', '8333423', 'TJ', '1998-07-01', '/fotos_usuarios/6', '71753290', 'ynavarro', 'ynavarro', FALSE);
insert into usuario (idUsuario, idRol, idSucursal, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, CI,lugarExpedicion, fechaNacimiento, fotografia, numeroCelular, login, password, activo)
value(null, 4, 1, 'Dayana', 'Laura', 'Rico', 'Tellez', '83334811', 'CB', '1996-10-27', '/fotos_usuarios/7', '71700359', 'drico', 'drico', FALSE);

-- insertar referencia de usuarios (garantes)
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 1, 'Diana', 'Laura', 'Rico', 'Tellez', '71736543', '39485765', 'CB', '1996-07-30', '/fotos_garante/1');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 2, 'Yolanda', 'Ester', 'Navarro', 'Suarez', '71736295', '39485766', 'TJ', '1996-08-30', '/fotos_garante/2');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 3, 'Dario', '', 'Resoalbe', '', '71736001', '39485767', 'CB', '1996-09-30', '/fotos_garante/3');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 4, 'Lorgio', '', 'Montaño', '', '71736324', '39485768', 'LP', '1996-10-30', '/fotos_garante/4');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 5, 'Maria Jose', '', 'Mendoza', 'Mamani', '71736993', '39485769', 'LP', '1996-11-30', '/fotos_garante/5');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 6, 'Cesar', 'Alberto', 'Ojeda', 'Vargas', '71736994', '39485770', 'SC', '1996-12-30', '/fotos_garante/6');
insert into referenciaUsuario (idReferenciaUsuario, idUsuario, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno, numeroCelular, ci, lugarExpedicion, fechaNacimiento, fotografiaCarnet)
value(null, 7, 'Ignacio', 'Jhaziel', 'Sarzuri', 'Rojas', '71736377', '39485771', 'LP', '1996-01-30', '/fotos_garante/7');

-- insertar clientes
insert into cliente(idCliente, idSucursal, ci, nit, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno)
value(null, 1, '14478528 LP', '4241642', 'Lupita', 'Carmen', 'Valencia', 'Torrico');
insert into cliente(idCliente, idSucursal, ci, nit, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno)
value(null, 1, '14478555 CB', '8281682', 'Tomas', 'Abel', 'Centeno', 'Raldez');
insert into cliente(idCliente, idSucursal, ci, nit, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno)
value(null, 1, '14478587 CB', '9291692', 'Rodrigo', 'Salomon', 'Neruda', 'Marquez');
insert into cliente(idCliente, idSucursal, ci, nit, primerNombre, segundoNombre, apellidoPaterno, apellidoMaterno)
value(null, 1, '14478587', '123456', 'Rodrigo', 'Salo', 'Neruda', 'Marquez');

-- insertar pedidos
insert into pedido (idPedido, idUsuario, idSucursal, fechaPedido, horaPedido)
value(null, 3, 1, now(), now());
insert into pedido (idPedido, idUsuario, idSucursal, fechaPedido, horaPedido)
value(null, 3, 1, now(), now());
insert into pedido (idPedido, idUsuario, idSucursal, fechaPedido, horaPedido)
value(null, 5, 1, now(), now());

-- insertar detalle de los pedidos
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(1, 'HELADO-1', 2, 6.00);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(1, 'HAMBURGUESA-1', 1, 20.00);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(2, 'JUGO-1', 3, 10.00);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(2, 'SALTENHA-2', 3, 6.50);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(3, 'JUGO-2', 3, 10.00);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(3, 'SALTENHA-2', 3, 6.50);
insert into detallePedido (idPedido, idProducto, cantidad, precio)
value(3, 'HELADO-2', 1, 8.00);

-- insertar ventas
insert into venta (idVenta, idPedido, idCliente, idSucursal, idUsuario, montoTotalVenta, fechaVenta, horaVenta)
value(null, 1, 3, 1, 6, 32.00, now(), now());
insert into venta (idVenta, idPedido, idCliente, idSucursal, idUsuario, montoTotalVenta, fechaVenta, horaVenta)
value(null, 2, 2, 1, 7, 49.50, now(), now());
insert into venta (idVenta, idPedido, idCliente, idSucursal, idUsuario, montoTotalVenta, fechaVenta, horaVenta)
value(null, 3, 1, 1, 6, 57.50, now(), now());

-- insertar facturas
insert into factura (idFactura, idVenta, idSucursal, numeroFactura, codigoControl, fechaLimiteEmision)
value(null, 2, 1, 1, 48364836, '2017-12-31');
insert into factura (idFactura, idVenta, idSucursal, numeroFactura, codigoControl, fechaLimiteEmision)
value(null, 1, 1, 2, 48364836, '2017-12-31');
insert into factura (idFactura, idVenta, idSucursal, numeroFactura, codigoControl, fechaLimiteEmision)
value(null, 3, 1, 3, 48364836, '2017-12-31');


