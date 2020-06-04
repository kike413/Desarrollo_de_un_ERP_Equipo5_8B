/**
Paginación estilos
**/
create function paginacion_estilos (@pagina int)
returns table
as return
select * from Estilos where estatus='A' order by idEstilo offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación marcas
**/
create function paginacion_marcas (@pagina int)
returns table
as return
select * from Marcas where estatus='A' order by idMarca offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación categorias
**/
create function paginacion_categorias (@pagina int)
returns table
as return
select * from Categorias where estatus='A' order by idCategoria offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación colores
**/
create function paginacion_colores (@pagina int)
returns table
as return
select * from Colores where estatus='A' order by idColor offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación productos
**/
create function paginacion_productos (@pagina int)
returns table
as return
select p.idProducto,p.nombre,p.descripcion,p.puntoReorden,p.genero,
p.precioCompra,p.precioVenta,p.estatus,p.materia,m.nombre as marca,e.nombre as estilo,c.nombre as categoria
from Productos p
join Categorias c
on p.idCategoria=c.idCategoria
join Estilos e
on p.idEstilo=e.idEstilo
join Marcas m
on m.idMarca=p.idMarca
where c.idCategoria=p.idCategoria and e.idEstilo=p.idEstilo and p.idMarca=m.idMarca and p.estatus='A'
order by p.idProducto offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación provedor
**/
create function paginacion_proveedores (@pagina int)
returns table
as return
select p.idProveedor,p.nombre,p.telefono,p.email,p.direccion,p.colonia,p.codigoPostal,c.nombre as ciudad 
from Proveedores p 
join Ciudades c
on p.idCiudad=c.idCiudad
where c.idCiudad=p.idCiudad and p.estatus='A' order by idProveedor offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
/**
Paginación detalle producto
**/
create function paginacion_detalleproducto (@pagina int)
returns table
as return
select d.idProductoDetalle,d.talla,d.existencia,c.nombre as Color,p.nombre as Producto
from DetalleProductos d
join Colores c
on d.idColor=c.idColor
join Productos p
on p.idProducto=d.idProducto
where c.idColor=d.idColor and p.idProducto=d.idProducto and d.estatus='A'
order by d.idProductoDetalle offset (@pagina+-1)*10 
rows fetch next 10 rows only
go

/**
Paginación pedidos
**/
create function paginacion_pedidos (@pagina int)
returns table
as return
select  p.idPedido,p.fechaRegistro,p.fechaRecepcion,p.totalPagar,p.cantidadPagada,prov.nombre as Proveedor,emp.nombre as Empleado
from pedidos p
join proveedores prov
on p.idProveedor=prov.idProveedor
join Empleados emp
on p.idEmpleado=emp.idEmpleado
where p.idProveedor=prov.idProveedor and p.idEmpleado=emp.idEmpleado and p.estatus='A'
order by p.idPedido offset (@pagina+-1)*10 
rows fetch next 10 rows only
go

/**
Paginación Productos Proveedor
**/
create function paginacion_productosProveedor (@pagina int)
returns table
as return
select pd.idProducto as Productos, pv.idProveedor as Proveedor,pd.nombre as Producto, pp.diasRetardo, pp.precioEstandar, pp.precioUltimaCompra, pp.cantMinPedir, pp.cantMaxPedir
from ProductosProveedor pp
join Proveedores pv
on pp.idProveedor=pv.idProveedor
join Productos pd
on pp.idProducto=pd.idProducto
where pp.idProveedor=pv.idProveedor and pp.idProducto=pd.idProducto and pp.estatus='A'
order by pp.idProveedor offset (@pagina+-1)*10 
rows fetch next 10 rows only
go


/**
Paginación cuentasProveedor
**/
create function paginacion_cuentasProveedor (@pagina int)
returns table
as return
select p.nombre as Proveedor, c.noCuenta, c.banco, c.estatus
from CuentasProveedor c
join Proveedores p
on p.idProveedor=c.idProveedor
where p.idProveedor = c.idProveedor
order by p.idProveedor offset (@pagina+-1)*10 
rows fetch next 10 rows only
go

drop function paginacion_PedidoDetalle
/**
Paginación Pedido Detalle
**/
create function paginacion_PedidoDetalle (@pagina int)
returns table
as return
select p.idPedido as Pedido, f.idProductoDetalle as DetalleProductos, pd.cantPedida,pd.precioUnitario,pd.subtotal,pd.cantRecibida, pd.cantRechazada,pd.cantAceptada
from PedidoDetalle pd
join Pedidos p
on pd.idPedido=p.idPedido
join DetalleProductos f
on f.idProductoDetalle=pd.idProductoDetalle
where pd.idPedido=p.idPedido and f.idProductoDetalle=pd.idProductoDetalle and pd.estatus='A'
order by pd.idProductoDetalle offset (@pagina+-1)*10 
rows fetch next 10 rows only
go


/**
Paginación PagosCompras
**/
create function paginacion_PagosCompras (@pagina int)
returns table
as return
select pc.idPago, pc.fecha, pc.importe,  p.idPedido as idPedido, fp.idFormaPago as idFormaPago, fp.nombre as nombre
from PagosCompras pc
join Pedidos p
on pc.idPedido=p.idPedido
join FormasPago fp
on pc.idFormaPago=fp.idFormaPago
where pc.idPedido=p.idPedido and pc.idFormaPago=fp.idFormaPago and pc.estatus='A'
order by pc.idPago offset (@pagina+-1)*10 
rows fetch next 10 rows only
go

/**
Paginación FormasPago
**/
create function paginacion_FormasPago (@pagina int)
returns table
as return
select fp.idFormaPago, fp.nombre from FormasPago fp
where fp.estatus='A'
order by fp.idFormaPago offset (@pagina+-1)*10 
rows fetch next 10 rows only
go

drop function paginacion_ContactosProveedor

/**
Paginación Contactos Proveedor
**/
create function paginacion_ContactosProveedor (@pagina int)
returns table
as return
select cp.idContacto, cp.nombre,cp.telefono,cp.email, p.idProveedor as idProveedor
from ContactosProveedor cp
join Proveedores p
on cp.idProveedor=p.idProveedor
where cp.idProveedor=p.idProveedor and cp.estatus='A'
order by cp.idContacto offset (@pagina+-1)*10 
rows fetch next 10 rows only
go
