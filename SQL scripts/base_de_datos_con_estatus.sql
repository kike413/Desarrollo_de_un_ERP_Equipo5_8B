create database ERP2020
GO

USE ERP2020
GO
	----------------------------- MODULO RH -----------------------------

create table Estado(
	idEstado			integer identity(1,1) not null,
	nombre				varchar(60) not null,
	siglas				varchar(10) not null
	constraint Estado_PK primary key (idEstado)
)

create table Ciudades(
	idCiudad			integer identity(1,1) not null,
	nombre				varchar(80) not null,
	Estado_idEstado		integer not null
	constraint Ciudades_PK primary key (idCiudad),
	constraint Cudades_Estado_FK foreign key (Estado_idEstado) references Estado(idEstado)
)

create table Departamentos(
	idDepartamento		integer identity(1,1) not null,
	nombre				varchar(50) not null
	constraint Departamentos_PK primary key (idDepartamento)
)

create table Puestos(
	idPuesto			integer identity(1,1) not null,
	nombre				varchar(60) not null,
	salarioMinimo		float not null,
	salarioMaximo		float not null,
	constraint Puestos_PK primary key (idPuesto)
)

create table Empleados 
(
	idEmpleado			integer identity(1,1) not null,
	nombre				varchar (30) not null,
	apaterno			varchar (30),
	amaterno			varchar (30),
	sexo				char not null,
	fechaContratacion	date not null,
	fechaNacimiento		date not null,
	salario				float not null,
	nss					varchar(10) not null,
	estadoCivil			varchar(20) not null,
	diasVacaciones		integer not null,
	diasPermiso			integer not null,
	fotografia			varbinary(MAX) ,
	direccion			varchar(80) not null,
	colonia				varchar (50) not null,
	codigoPostal		varchar(5) not null,
	escolaridad			varchar(80) not null,
	porcentajeComision	float not null,
	idDepartamento		integer not null,
	idPuesto			integer not null,
	idCiudad			integer not null
	CONSTRAINT Empleados_PK PRIMARY KEY (idEmpleado),
	--constraint chk_Sexo check (sexo in ('F','M'))
	constraint Empleados_Departamentos_FK foreign key (idDepartamento) references departamentos(idDepartamento),
	constraint Empleados_Puestos_FK foreign key (idPuesto) references puestos(idPuesto),
	constraint Empleados_Ciudades_FK foreign key (idCiudad) references Ciudades(idCiudad)
)

create table HistorialPuestos(
	idEmpleado			integer not null,
	idPuesto			integer not null,
	idDepartamento		integer not null,
	fechaInicio			date not null,
	fechaFin			date,
	salario				float not null
	constraint FK_Historial_Empleados foreign key (idEmpleado) references Empleados (idEmpleado),
	constraint FK_Historial_Puestos foreign key (idPuesto) references Puestos (idPuesto),
	constraint FK_Historial_Departamentos foreign key (idDepartamento) references Departamentos (idDepartamento),
	constraint PK_HistorialPuestos primary key (idEmpleado,idPuesto,idDepartamento,fechaInicio)
	--constraint chk_fecha check (fechaFin>=fechaInicio)
)

create table DocumentacionEmpleado(
	idDocumento			integer identity(1,1) not null,
	nombreDocumento		varchar(80) not null,
	fechaEntrega		Date not null,
	documento			varbinary(max) not null,
	idEmpleado			integer not null
	constraint PK_DocumentacionEmpleado primary key (idDocumento),
	constraint FK_Documentacion_Empleado foreign key (idEmpleado) references Empleados(idEmpleado) 
)

create table Incapacidades(
	idIncapacidad		integer identity(1,1) not null,
	fechaInicio			date not null,
	fechaFin			date,
	enefermedad			varchar(90) not null,
	idEmpleado			integer not null
	constraint PK_Incapacidades primary key (idIncapacidad),
	constraint FK_Incapacidades_Empleado foreign key (idEmpleado) references Empleados (idEmpleado),
	--constraint chk_fechaIncapacidad check (fechaFin>=fechaInicio)
)

create table Horarios(
	idHorario			integer identity(1,1) not null,
	horaInicio			date not null,
	horaFin				date not null,
	dias				varchar(30) not null,
	idEmpleado			integer not null
	constraint PK_Horarios primary key (idHorario)
	constraint FK_Horarios_Empleado foreign key (idEmpleado) references Empleados (idEmpleado),
	--constraint chk_horario check (HoraFin>HoraInicio)
)

create table AusenciasJustificadas(
	idAusencia			integer identity(1,1) not null,
	fechaSolicitud		date not null,
	fechaInicio			date not null,
	fechaFin			date not null,
	tipo				char not null, 
	idEmpleadoS			integer not null,
	idEmpleadoA			integer not null
	constraint PK_AusenciasJustificadas primary key(idAusencia),
	constraint FK_Ausencia_EmpleadosS foreign key (idEmpleadoS) references Empleados (idEmpleado),
	constraint FK_Ausencia_EmpleadosA foreign key (idEmpleadoA) references Empleados (idEmpleado),
	--constraint chk_fechaSolicitud check (fechaSolicitud>=fechaInicio),
	--constraint chk_fechaFin check (FechaFin>=fechaInicio)
)

create table Nominas (
	idNomina			integer not null,
	fechaPago date not null,
	totalP float not null,
	totalD float not null,
	cantidadNeta float not null,
	diasTrabajados integer not null,
	faltas integer not null,
	fechaInicio date not null,
	fechaFin date not null,
	idEmpleado integer not null
	constraint PK_Nominas primary key (idNomina)
	constraint FK_Nominas_Empleado foreign key (idEmpleado) references Empleados (idEmpleado),
	constraint chk_fechapagoNomina check (FechaPago>=fechaFin),
	constraint chk_fechafinNomina check (FechaFin>=fechaInicio),
)

create table Deducciones(
	idDeduccion integer not null,
	nombre varchar(30) not null,
	descripcion varchar(80) not null,
	porcentaje float not null
	constraint PK_Deducciones primary key(idDeduccion)
)

create table NominasDeducciones(
	idNomina integer not null,
	idDeduccion integer not null,
	importe float not null
	constraint PK_NominasDeducciones primary key (idNomina,idDeduccion)
	constraint FK_Nominas foreign key (idNomina) references Nominas (idNomina),
	constraint FK_Deducciones foreign key (idDeduccion) references Deducciones 
)

create table Percepciones(
	idPercepcion integer not null,
	nombre varchar(30) not null,
	descripcion varchar(80) not null,
	diasPagar integer not null
	constraint PK_Percepciones primary key (idPercepcion)
)

create table NominasPercepciones(
	idNomina integer not null,
	idPercepcion integer not null,
	importe float not null
	constraint PK_NominasPercepciones primary key (idNomina,idPercepcion)
	constraint FK_NominaPercepcion foreign key (idNomina) references Nominas(idNomina),
	constraint FK_Percepcion foreign key (idPercepcion) references Percepciones (idPercepcion)
)
go 

	----------------------------- MODULO COMPRAS -----------------------------
	
create table Productos(
idProducto integer not null identity(1,1),
nombre varchar(50) not null,
descripcion varchar(100) not null,
puntoReorden integer not null,
genero char not null,
precioCompra float not null,
precioVenta float not null,
estatus char not null default 'A',
materia varchar(100) not null,
idMarca integer not null,
idEstilo integer not null,
idCategoria integer not null 
)

create table ImagenesProducto(
idImagen integer identity(1,1) not null,
nombreImagen varchar(100) not null,
imagen image not null,
principal char not null,
idProducto integer not null
, estatus char not null default 'A'
)

create table Marcas(
idMarca integer not null identity(1,1),
nombre varchar(50) not null,
origen varchar(30) not null
, estatus char not null default 'A'
)

create table Estilos(
idEstilo integer not null identity(1,1),
nombre varchar(30) not null
, estatus char not null default 'A'
)

create table Categorias(
idCategoria integer not null identity(1,1),
nombre varchar(30)
, estatus char not null default 'A'
)

create table Colores(
idColor integer not null identity(1,1),
nombre varchar(30)
, estatus char not null default 'A'
)

create table DetalleProductos(
idProductoDetalle integer not null identity(1,1),
talla float not null,
existencia integer not null,
idColor integer not null,
idProducto integer not null
, estatus char not null default 'A'
)

create table Proveedores (
idProveedor integer identity(1,1) not null,
nombre varchar(80) not null,
telefono char(12) not null,
email varchar(100) not null,
direccion varchar(80) not null,
colonia varchar(50) not null,
codigoPostal varchar(5) not null,
idCiudad integer not null
, estatus char not null default 'A'
)

create table ContactosProveedor(
idContacto integer not null identity(1,1),
nombre varchar(80) not null,
telefono char(12) not null,
email varchar(100)not null,
idProveedor integer not null
, estatus char not null default 'A',
)

create table CuentasProveedor(
idProveedor integer not null,
noCuenta varchar(10) not null,
banco varchar(30) not null
, estatus char not null default 'A'
)

create table Pedidos(
idPedido integer not null identity(1,1),
fechaRegistro date not null default getdate(),
fechaRecepcion date not null,
totalPagar float not null,
cantidadPagada float not null,
estatus char not null default 'A',
idProveedor integer not null,
idEmpleado integer not null 
)

create table PedidoDetalle(
idPedido integer not null ,
idProductoDetalle integer not null,
cantPedida integer not null,
precioUnitario float not null,
subtotal float not null,
cantRecibida integer not null,
cantRechazada integer not null,
cantAceptada float not null
, estatus char not null default 'A'
)

create table FormasPago(
idFormaPago integer not null identity(1,1),
nombre varchar(20)
, estatus char not null default 'A'
)

create table PagosCompras(
idPago integer not null identity(1,1),
fecha date not null default getdate(),
importe float not null,
idPedido integer not null,
idFormaPago integer not null
, estatus char not null default 'A'
)

create table ProductosProveedor(
idProducto integer not null,
idProveedor integer not null,
diasRetardo integer not null,
precioEstandar float not null,
precioUltimaCompra float not null,
cantMinPedir integer not null,
cantMaxPedir integer not null
, estatus char not null default 'A'
)

Go
/**************************
	Restricciones Modulo Compras
***************************/
----- Proveedores -----
alter table Proveedores add constraint Proveedores_PK primary key(idProveedor)

----- ContactosProveedor -----
alter table ContactosProveedor add constraint ContactosProveedor_PK primary key (idContacto)
alter table ContactosProveedor add constraint ContactosProveedor_Proveedores_FK foreign key (idProveedor)
references Proveedores(idProveedor)

----- CuentasProveedor -----
alter table CuentasProveedor add constraint CuentasProveedor_PK primary key (idProveedor,noCuenta,banco)
alter table CuentasProveedor add constraint CuentasProveedor_Proveedores_FK foreign key (idProveedor)
references Proveedores(idProveedor)

----- Marcas -----
alter table Marcas add constraint Marcas_PK primary key(idMarca)

----- Estilos -----
alter table Estilos add constraint Estilos_PK primary key (idEstilo)

----- Categorias -----
alter table Categorias add constraint Categorias_PK primary key (idCategoria)

----- Colores -----
alter table Colores add constraint Colores_PK primary key (idColor)

----- Productos -----
alter table Productos add constraint Productos_PK primary key (idProducto)
alter table Productos add constraint Productos_Marcas_FK foreign key(idMarca) references Marcas(idMarca)
alter table Productos add constraint Productos_Estilo_FK foreign key(idEstilo) references Estilos(idEstilo)
alter table Productos add constraint Productos_Categorias_FK foreign key(idCategoria) references Categorias(idCategoria)

----- ImagenesProducto -----
alter table ImagenesProducto add constraint ImagenesProducto_PK primary key(idImagen)
alter table ImagenesProducto add constraint ImagenesProducto_Producto_FK foreign key(idProducto) references Productos(idProducto)

----- DetalleProductos -----
alter table DetalleProductos add constraint DetalleProductos_PK primary key (idProductoDetalle)
alter table DetalleProductos add constraint DetalleProductos_Color_FK foreign key(idColor) references Colores(idColor)
alter table DetalleProductos add constraint DetalleProductos_Productos_FK foreign key(idProducto) references Productos(idProducto)

----- Pedidos ----- 
alter table Pedidos add constraint Pedidos_PK primary key(idPedido)
alter table Pedidos add constraint Pedidos_Proveedores_FK foreign key(idProveedor) references Proveedores(idProveedor)

----- PedidoDetalle -----
alter table PedidoDetalle add constraint PedidoDetalle_PK primary key (idPedido,idProductoDetalle)
alter table PedidoDetalle add constraint PedidoDetalle_DetalleProducto_FK foreign key (idProductoDetalle) references DetalleProductos(idProductoDetalle)
alter table PedidoDetalle add constraint PedidoDetalle_Pedidos_FK foreign key (idPedido) references Pedidos(idPedido)

----- FormasPago -----
alter table FormasPago add constraint FormasPago_PK primary key (idFormaPago)

----- Pagos -----
alter table PagosCompras add constraint PagosCompras_PK primary key(idPago)
alter table PagosCompras add constraint PagosCompras_Pedidos_FK foreign key (idPedido) references Pedidos(idPedido)
alter table PagosCompras add constraint PagosCompras_FormasPago_FK foreign key(idFormaPago) references FormasPago(idFormaPago)

----- ProductosProveedor -----
alter table ProductosProveedor add constraint ProductosProveedor_PK primary key(idProducto,idProveedor)
alter table ProductosProveedor add constraint ProductosProveedor_Productos_FK foreign key(idProducto) references Productos(idProducto)
alter table ProductosProveedor add constraint ProductosProveedor_Proveedores_FK foreign key(idProveedor) references Proveedores(idProveedor)

GO


	----------------------------- MODULO VENTAS -----------------------------

CREATE TABLE [Clientes] (
  [idCliente]				INTEGER NOT NULL IDENTITY(1, 1),
  [direccion]				VARCHAR(80) NOT NULL,
  [codidoPostal]			CHAR(5) NOT NULL,
  [rfc]						CHAR(13) NOT NULL,
  [telefono]				CHAR(12) NOT NULL,
  [email]					VARCHAR(100) NOT NULL,
  [tipo]					CHAR NOT NULL,
  [idCiudad]				INTEGER NOT NULL,
  CONSTRAINT Clientes_PK primary key (idCliente)
)

CREATE TABLE [ClienteIndividual] (
  [idCliente]				INTEGER NOT NULL,
  [nombre]					VARCHAR(30) NOT NULL,
  [apaterno]				VARCHAR(30) NOT NULL,
  [amaterno]				VARCHAR(30) NOT NULL,
  [sexo]					CHAR NOT NULL,
  CONSTRAINT FK_ClienteIndividual_Clientes FOREIGN KEY ([idCliente]) REFERENCES [Clientes] ([idCliente]),
  CONSTRAINT PK_ClienteIndividual PRIMARY KEY ([idCliente])
)
 

CREATE TABLE [ClienteTienda] (
  [idCliente]				INTEGER NOT NULL,
  [nombre]					VARCHAR(60) NOT NULL,
  [Contacto]				VARCHAR(90) NOT NULL,
  [limiteCredito]			FLOAT NOT NULL,
  CONSTRAINT FK_ClienteTienda_Clientes FOREIGN KEY ([idCliente]) REFERENCES [Clientes] ([idCliente]),
  CONSTRAINT PK_ClienteTienda PRIMARY KEY ([idCliente])
)


CREATE TABLE [Ventas] (
  [idVenta]					INTEGER NOT NULL IDENTITY(1, 1),
  [fecha]					DATE NOT NULL,
  [totalPagar]				FLOAT NOT NULL,
  [cantPagada]				FLOAT NOT NULL,
  [comentarios]				VARCHAR(100) NOT NULL,
  [estatus]					CHAR NOT NULL,
  [idCliente]				INTEGER NOT NULL,
  [idEmpleado] INTEGER NOT NULL,
  CONSTRAINT PK_Ventas PRIMARY KEY (idVenta),
  CONSTRAINT FK_Ventas_Clientes FOREIGN KEY ([idCliente]) REFERENCES [Clientes] ([idCliente]),
  CONSTRAINT FK_Ventas_Empleados FOREIGN KEY (idEmpleado) REFERENCES Empleados(idEmpleado)
)


create table VentasDetalle(
	idVentaDetalle			int IDENTITY(1, 1),
	precioUnitario			float not null,
	cantidad				float not null,
	subtotal				float not null,
	idVenta					int not null,
	idProductoDetalle		int not null,
	constraint PK_VentasDetalle primary key (idVentaDetalle),
	constraint FK_VentasDetalle_Venta foreign key (idVenta) references Ventas(idVenta),
	constraint FK_VentasDetalle_DetalleProductos foreign key (idProductoDetalle) references DetalleProductos(idProductoDetalle)
)

create table PagosVentas(
	idPago					int not null IDENTITY(1, 1),
	fecha					date not null,
	importe					float not null,
	idVenta					int not null,
	idFormaPago				int not null,
	constraint PK_PagosVentas primary key (idPago),
	constraint FK_agos_Ventas foreign key (idVenta) references Ventas (idVenta),
	constraint FK_Pagos_Ventas foreign key (idFormaPago) references FormasPago (idFormaPago),
)

create table Devoluciones(
	idDevolucion			int not null IDENTITY(1, 1),
	fecha					date not null,
	idProductoDetalle		int not null,
	cantidad				int not null,
	precioUnitario			float not null,
	total					float not null,
	motivo					varchar(200) not null,
	idVenta					int not null,
	constraint PK_Devoluciones primary key (idDevolucion),
	constraint FK_Devoluciones_Ventas foreign key (idVenta) references Ventas (idVenta)
)

create table Facturas(
	folio					int IDENTITY(1,1) not null,
	subtotal				float not null,
	iva						float not null,
	total					float not null,
	nombreDocXML			varchar(100) not null,
	documentoXML			Varbinary(Max)  not null,
	nombreDocPDF			varchar(100) not null,
	documentoPDF			Varbinary(Max) not null,
	idVenta					int not null,
	constraint PK_Factura primary key (folio),
	constraint FK_Facturas_Ventas foreign key (idVenta) references Ventas (idVenta)
)


create table UnidadesTransporte(
	idUnidadTransporte		int not null IDENTITY(1, 1),
	placas					varchar(10) not null,
	marca					varchar(80) not null,
	modelo					varchar(80) not null,
	anio					int,
	capacidad				int not null
	constraint PK_UnidadesTransporte primary key (idUnidadTransporte)
)

create table Envios(
	idEnvio int not null IDENTITY(1, 1),
	fechaSalida date not null,
	idUnidadTransporte int not null,
	constraint PK_Envios primary key (idEnvio),
	constraint Fk_Envios_UnidadesTransporte foreign key (idUnidadTransporte) references UnidadesTransporte(idUnidadTransporte)
)

create table Tripulacion(
	idEmpleado int not null IDENTITY(1, 1),
	idEnvio int not null,
	rol varchar(20),
	constraint PK_Tripulacion primary key (idEnvio),
	constraint Fk_Tripulacion foreign key (idEnvio) references Envios(idEnvio)
)


create table EnviosVentas(
	idEnvio int not null,
	idVenta int not null,
	fechaEntregaPlaneada date,
	fechaEntregaREal date,
	constraint Pk_EV primary key (idEnvio, idVenta) ,
	constraint Fk_EVE foreign key (idEnvio) references Envios(idEnvio)
	--constraint Fk_EVV foreign key (idVenta) references Ventas(idVenta)
)

create table Ofertas(
	idOferta int not null IDENTITY(1,1) primary key,
	nombre varchar(50) not null,
	descripcion varchar(200) not null,
	porDescuento float not null,
	fechaInicio date not null,
	fechaFin date not null,
    canMinProducto int not null,
    estatus char not null
)
  
create table OfertasProductos(
    idProducto int not null,
    idOferta int not null,
    constraint PK_OfertasProductos primary key (idProducto, idOferta),
    CONSTRAINT FK_OfertasProductos_Ofertas FOREIGN KEY (idOferta) REFERENCES Ofertas(idOferta),
    constraint FK_OfertasProductos_Producto foreign key (idProducto) references Productos(idProducto)
)
    
create table VentasOfertas(
    idVentaDetalle int not null,
    idVentaProducto int not null,
	idProducto int not null,
    idOferta int not null,
    constraint PK_VentaOferta primary key(idVentaDetalle,idVentaProducto,idOferta),
    CONSTRAINT FK_VentasOfertas_OfertasProductos FOREIGN KEY (idProducto,idOferta) REFERENCES OfertasProductos(idProducto,idOferta),
    CONSTRAINT FK_VentasOfertas_VentasDetalle FOREIGN KEY (idVentaDetalle) REFERENCES VentasDetalle(idVentaDetalle)
)
GO

CREATE TABLE Usuarios
(
    idUsuario INT PRIMARY KEY NOT NULL,
    nombre VARCHAR(30) NOT NULL,
    contraseña INT NOT NULL,
    estatus CHAR NOT NULL,
    tipo CHAR NOT NULL,
    fechaRegistro DATE NOT NULL,
    fotoPerfil VARBINARY(MAX),
    idEmpleado INT NOT NULL FOREIGN KEY REFERENCES "Empleados" (idEmpleado)
);
