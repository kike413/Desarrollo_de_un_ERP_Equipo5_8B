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
@existencia integer,
@id int
as
update DetalleProductos set talla=@talla, existencia=@existencia where idProductoDetalle=@id
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





