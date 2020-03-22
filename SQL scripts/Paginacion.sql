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
