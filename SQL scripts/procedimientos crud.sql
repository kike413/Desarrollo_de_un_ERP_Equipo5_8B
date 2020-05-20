use ERP2020
/*
	PROCEDIMIENTOS ESTILOS
*/
--- Procedimiento almacenado para hacer update a estilos ---
create proc EditarEstilos
@nombre varchar(30),
@id int
as
update Estilos set nombre=@nombre where idEstilo=@id
go


--- Procedimiento almacenado para hacer DELETE a estilos ---
create proc EliminarEstilos
@id int
as
update Estilos set estatus='I' where idEstilo=@id
go

/*
	PROCEDIMIENTOS Marcas
*/
--- Procedimiento almacenado para hacer update a marcas ---
create proc EditarMarcas
@nombre varchar(50),
@origen varchar(30),
@id int
as
update Marcas set nombre=@nombre where idMarca=@id
go


--- Procedimiento almacenado para hacer DELETE a Marcas ---
create proc EliminarMarcas
@id int
as
update Marcas set estatus='I' where idMarca=@id
go

/************
************/
--------------------------------------------Contenido de la pagina Principal--------------------------------------------------------------------

--- Procedimiento almacenado para hacer update Nombre de la pagina principal ---
create proc EditarNombreUsuario
@nombre varchar(30),
@id int
as
update Usuarios set nombre=@nombre where idUsuario=@id
go

--- Procedimiento almacenado para hacer update Estatus de la pagina principal ---
create proc EditarEstatusUsuario
@estatus CHAR,
@id int
as
update Usuarios set estatus=@estatus where idUsuario=@id
go

--- Procedimiento almacenado para hacer update Tipo de la pagina principal ---
create proc EditarTipoUsuario
@tipo varchar(30),
@id int
as
update Usuarios set tipo=@tipo where idUsuario=@id
go




--- Procedimiento almacenado para hacer select Nombre de la pagina principal ---
create proc SeleccionarNombreUsuario
@nombre varchar(30),
@id int
as
select idUsuario from Usuarios where idUsuario=@id
go

--- Procedimiento almacenado para hacer select Estatus de la pagina principal ---
create proc SeleccionarEstatusUsuario
@estatus CHAR,
@id int
as
select estatus from Usuarios where idUsuario=@id
go

--- Procedimiento almacenado para hacer select Tipo de la pagina principal ---
create proc SeleccionarTipoUsuario
@tipo varchar(30),
@id int
as
select tipo from Usuarios where idUsuario=@id
go

/******************
procedimientos colores
******************/

create proc EditarColores
@nombre varchar(30),
@id int
as
update Colores set nombre=@nombre where idColor=@id
go



--- Procedimiento almacenado para hacer DELETE a estilos ---
create proc EliminarColores
@id int
as
update Colores set estatus='I' where idColor=@id
go


/*
	Procedimientos categorías
*/

create proc EditarCategoria
@nombre varchar(30),
@id int
as
update Categorias set nombre=@nombre where idCategoria=@id
go



--- Procedimiento almacenado para hacer DELETE a estilos ---
create proc EliminarCategoria
@id int
as
update Categorias set estatus='I' where idCategoria=@id
go


/*
 I= inactivo A = activo
*/

--------------------------Detalle Productos
create proc EditarDetalleProductos
@talla float,
@existencia int,
@idColor int,
@idProducto int,
@id int
as
update DetalleProductos set talla=@talla, existencia=@existencia , idColor=@idColor, idProducto=@idProducto where idProductoDetalle=@id
go



create proc EliminarDetalleProductos
@id int
as
update DetalleProductos set estatus='I' where idProductoDetalle=@id
go

/*
	Procedimientos productos
*/

create proc EditarProducto
@nombre varchar(50),
@descripcion varchar(100),
@puntoReorden integer,
@genero char,
@precioCompra float,
@precioVenta float,
@material varchar(100),
@idMarca integer,
@idEstilo integer,
@idCategoria integer,
@id int
as
update Productos set nombre=@nombre,descripcion=@descripcion,
puntoReorden=@puntoReorden,genero=@genero,precioCompra=@precioCompra,materia=@material,idMarca=@idMarca,
idEstilo=@idEstilo,idCategoria=@idCategoria where idProducto=@id
go



--- Procedimiento almacenado para hacer DELETE a estilos ---
create proc EliminarProducto
@id int
as
update Productos set estatus='I' where idProducto=@id
go

/*
	Procedimientos proveedores
*/

create proc EditarProveedores
@nombre varchar(80),
@telefono varchar(12),
@email varchar(100),
@direccion varchar(80),
@colonia varchar(50),
@codigopostal varchar(5),
@idCiudad int,
@id int
as
update Proveedores set nombre=@nombre,telefono=@telefono,
email=@email,direccion=@direccion,colonia=@colonia,codigoPostal=@codigopostal,idCiudad=@idCiudad where idProveedor=@id
go



--- Procedimiento almacenado para hacer DELETE a estilos ---
create proc EliminarProvedores
@id int
as
update Proveedores set estatus='I' where idProveedor=@id
go



/*
	Procedimientos pedidos
*/
select * from pedidos
create proc EditarPedidos
@fechaRegistro date,
@fechaRecepcion date,
@totalPagar float,
@cantidadPagada float,
@idProveedor int,
@idEmpleado int,
@id int
as
update Pedidos set fechaRegistro=@fechaRegistro,fechaRecepcion=@fechaRecepcion,totalPagar=@totalPagar,
cantidadPagada=@cantidadPagada,idProveedor=@idProveedor,idEmpleado=@idEmpleado where idPedido=@id
go

/*procedimiento para mostrar en el COMBOBOX los proveedores*/
create proc ListarProveedores
as
select * from Proveedores where estatus='A' order by nombre asc
go

/*procedimiento para mostrar en el COMBOBOX los empleados*/
create proc ListarEmpleados
as
select * from Empleados order by nombre asc
go
--- Procedimiento almacenado para hacer DELETE a pedidos ---
create proc EliminarPedidos
@id int
as
update Pedidos set estatus='I' where idPedido=@id
go


--------------------------Productos Proveedor
create proc EditarProductosProveedor
@diasRetardo int,
@precioEstandar float,
@precioUltimaCompra float,
@cantMinPedir int,
@cantMaxPedir int,
@idProducto int,
@idProveedor int
as
update ProductosProveedor set diasRetardo=@diasRetardo, precioEstandar=@precioEstandar , precioUltimaCompra=@precioUltimaCompra, cantMinPedir=@cantMinPedir, cantMaxPedir=@cantMaxPedir where idProducto=@idProducto and idProveedor=@idProveedor
go



create proc EliminarProductosProveedor
@idProducto int,
@idProveedor int
as
update ProductosProveedor set estatus='I' where idProducto=@idProducto and idProveedor=@idProveedor
go

/*
	Procedimientos Cuentas Proveedor
*/
select * from CuentasProveedor

create proc EditarCuentasProveedor
@noCuenta varchar(10),
@banco varchar(30),
@id int
as
update CuentasProveedor set noCuenta=@noCuenta,banco=@banco where idProveedor=@id
go


/*procedimiento para mostrar en el COMBOBOX los proveedores*/
create proc EliminarCuentaProveedor
@idProveedor int,
@noCuenta varchar(10),
@banco varchar(30)
as
update CuentasProveedor set estatus='I' where idProveedor=@idProveedor and noCuenta=@noCuenta and banco=@banco
go




