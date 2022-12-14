CREATE DATABASE facturacion_db
GO
USE facturacion_db
GO

CREATE TABLE usuarios(
	id_usuario int IDENTITY(1,1) NOT NULL,
	nombre varchar(255) NOT NULL,
	contraseña varchar(255) NOT NULL
 CONSTRAINT pk_id_usuario PRIMARY KEY (id_usuario) 
)

INSERT usuarios VALUES ('Tomas', '1234')
INSERT usuarios VALUES ('Maria', '351351')
INSERT usuarios VALUES ('Javier', '11111')

create proc SP_LOGIN
	@nombre varchar(255),
	@contraseña varchar(255),
	@correcto int out
as
begin 
	declare @resultado int
	select @resultado=count(*) from usuarios
	where nombre=@nombre and contraseña=@contraseña
	if @resultado>=1
		set @correcto = 1
	else
		set @correcto = 0
end

--base de datos:
CREATE TABLE articulos(
	id_articulo int IDENTITY(1,1) NOT NULL,
	articulo varchar(255) NOT NULL,
	precio money NOT NULL
 CONSTRAINT pk_id_articulo PRIMARY KEY (id_articulo) 
)

SET IDENTITY_INSERT articulos ON
INSERT articulos (id_articulo, articulo, precio) VALUES (1, N'lapicera', 110)
INSERT articulos (id_articulo, articulo, precio) VALUES (2, N'goma', 50)
INSERT articulos (id_articulo, articulo, precio) VALUES (3, N'lapiz', 100)
INSERT articulos (id_articulo, articulo, precio) VALUES (4, N'sacapuntas', 70)
SET IDENTITY_INSERT articulos OFF

CREATE TABLE formas_pago(
	id_forma_pago int IDENTITY(1,1) NOT NULL,
	forma_pago varchar(255) NOT NULL,
 CONSTRAINT pk_id_forma_pago PRIMARY KEY (	id_forma_pago )
) 

SET IDENTITY_INSERT formas_pago ON
INSERT formas_pago (id_forma_pago, forma_pago) VALUES (1, N'efectivo')
INSERT formas_pago (id_forma_pago, forma_pago) VALUES (2, N'tarjeta')
INSERT formas_pago (id_forma_pago, forma_pago) VALUES (3, N'transferencia')
SET IDENTITY_INSERT formas_pago OFF

CREATE TABLE facturas(
	factura_nro int IDENTITY(1,1) NOT NULL,
	fecha datetime NOT NULL,
	id_forma_pago int  NOT NULL,
	cliente varchar(255) NOT NULL,
	activa bit NOT NULL
	CONSTRAINT pk_factura_nro PRIMARY KEY (	factura_nro ),
	CONSTRAINT fk_factura_forma_pago foreign KEY (	id_forma_pago )
	references formas_pago (id_forma_pago)
) 

SET IDENTITY_INSERT facturas ON
INSERT facturas (factura_nro, fecha, id_forma_pago, cliente, activa) VALUES (1, '2/07/2022', 3, 'Pablo Londra',1 )
INSERT facturas (factura_nro, fecha, id_forma_pago, cliente, activa) VALUES (2, '5/04/2022', 2, 'Javier Milei',1 )
INSERT facturas (factura_nro, fecha, id_forma_pago, cliente, activa) VALUES (3, '12/09/2020', 1, 'Lucas Castel',1 )
INSERT facturas (factura_nro, fecha, id_forma_pago, cliente, activa) VALUES (4, '9/04/2022', 2, 'Tomas Lopez',1 )
INSERT facturas (factura_nro, fecha, id_forma_pago, cliente, activa) VALUES (5, '16/09/2021', 1, 'Tristana Lundra',1 )
SET IDENTITY_INSERT facturas OFF

CREATE TABLE detalles_factura(
	id_detalle int identity(1,1),
	factura_nro int NOT NULL,
	id_articulo int NOT NULL,
	cantidad int NOT NULL,
	CONSTRAINT pk_id_detalle PRIMARY KEY (	id_detalle),
	CONSTRAINT fk_detalle_factura foreign KEY (	factura_nro )
	references facturas (factura_nro),
	CONSTRAINT fk_detalle_articulo foreign KEY (	id_articulo )
	references articulos (id_articulo)
) 

SET IDENTITY_INSERT detalles_factura ON
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (1, 1, 1, 5)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (2, 2, 3, 60)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (3, 2, 3, 30)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (4, 3, 2, 50)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (5, 4, 4, 50)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (6, 5, 3, 20)
INSERT detalles_factura (id_detalle, factura_nro, id_articulo, cantidad) VALUES (7, 5, 1, 100)
SET IDENTITY_INSERT detalles_factura OFF
go

CREATE PROCEDURE SP_CONSULTAR_ARTICULOS
AS
BEGIN
	
	SELECT * from articulos;
END
GO
exec SP_CONSULTAR_ARTICULOS

CREATE PROCEDURE SP_CONSULTAR_FORMAS_PAGO
AS
BEGIN
	
	SELECT * from formas_pago;
END
GO

CREATE PROCEDURE SP_PROXIMO_ID
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(facturas.factura_nro)+1  FROM facturas);
END
GO


create PROCEDURE SP_INSERTAR_MAESTRO
	@forma_pago int, 
	@fecha datetime, 
	@cliente varchar(255), 
	@factura_nro int OUTPUT
AS
BEGIN
	INSERT INTO facturas(fecha,id_forma_pago, cliente, activa)
    VALUES (@fecha, @forma_pago, @cliente, 1);
    
    SET @factura_nro = SCOPE_IDENTITY();

END
GO


create PROCEDURE SP_INSERTAR_DETALLE
	@factura_nro int,
	@id_articulo int, 
	@cantidad int
AS
BEGIN
	INSERT INTO detalles_factura(factura_nro, id_articulo, cantidad)
    VALUES (@factura_nro, @id_articulo, @cantidad);
  
END
GO

create PROCEDURE SP_CONSULTAR_MAESTRO
	@fecha_1 datetime,
	@fecha_2 datetime,
	@cliente varchar(255)=''
AS
BEGIN
	SELECT factura_nro,fecha,forma_pago,facturas.id_forma_pago,cliente from facturas 
	join formas_pago on facturas.id_forma_pago = formas_pago.id_forma_pago
	where activa = 1 and facturas.fecha between @fecha_1 and @fecha_2 and  cliente LIKE '%' + @cliente + '%'
	order by 2
END
GO


create PROCEDURE SP_CONSULTAR_MAESTRO_DETALLE
	@factura_nro int
AS
BEGIN
	SELECT facturas.factura_nro,cliente, facturas.id_forma_pago ,fecha,
	detalles_factura.id_articulo ,articulo, cantidad, precio 
	from facturas
	join formas_pago on facturas.id_forma_pago = formas_pago.id_forma_pago
	join detalles_factura on facturas.factura_nro = detalles_factura.factura_nro
	join articulos on detalles_factura.id_articulo = articulos.id_articulo
	where facturas.factura_nro = @factura_nro;
END
GO

create PROCEDURE SP_DESACTIVAR_MAESTRO
	@factura_nro int
AS
BEGIN
	update facturas
	set activa = 0
	where factura_nro = @factura_nro;
END
GO


create PROCEDURE SP_MODIFICAR_MAESTRO
	@factura_nro int,
	@forma_pago int, 
	@fecha datetime, 
	@cliente varchar(255) 
AS
BEGIN
	update facturas
	set id_forma_pago = @forma_pago,
		fecha = @fecha,
		cliente = @cliente
	where factura_nro = @factura_nro;
END
GO

create PROCEDURE SP_CONSULTAR_VENTAS_ARTICULOS
	@fecha_1 datetime,
	@fecha_2 datetime
AS
BEGIN
	SELECT facturas.factura_nro, facturas.fecha, forma_pago, cliente, sum(cantidad) cantidad, sum(precio*cantidad)total 
	from facturas
	join formas_pago on facturas.id_forma_pago = formas_pago.id_forma_pago
	join detalles_factura on facturas.factura_nro = detalles_factura.factura_nro
	join articulos on detalles_factura.id_articulo = articulos.id_articulo
	where facturas.fecha between @fecha_1 and @fecha_2 and facturas.activa = 1
	group by facturas.factura_nro, facturas.fecha, forma_pago, cliente
	order by facturas.fecha;
END
GO
