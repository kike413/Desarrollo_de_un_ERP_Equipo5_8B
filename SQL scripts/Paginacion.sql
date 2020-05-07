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
