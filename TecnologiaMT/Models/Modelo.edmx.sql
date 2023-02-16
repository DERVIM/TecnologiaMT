
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/04/2022 20:23:02
-- Generated from EDMX file: C:\Users\dervi\Desktop\TecnologiaMT\TecnologiaMT\Models\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TecnologiaMT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MarcaProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_MarcaProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoriaProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_CategoriaProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_CompraDetalleCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCompras] DROP CONSTRAINT [FK_CompraDetalleCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_RentaDetalleRenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleRentas] DROP CONSTRAINT [FK_RentaDetalleRenta];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoDetalleCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCompras] DROP CONSTRAINT [FK_ProductoDetalleCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_AsistenciaTecnicaDetallaAsistenciaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallaAsistenciaTecnicas] DROP CONSTRAINT [FK_AsistenciaTecnicaDetallaAsistenciaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_RazonSocialProveedor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Proveedores] DROP CONSTRAINT [FK_RazonSocialProveedor];
GO
IF OBJECT_ID(N'[dbo].[FK_RazonSocialCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_RazonSocialCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_EmpleadoCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoRenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rentas] DROP CONSTRAINT [FK_EmpleadoRenta];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoAsistenciaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaTecnicas] DROP CONSTRAINT [FK_EmpleadoAsistenciaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_ProveedorCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_ProveedorCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_RetencionCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_RetencionCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteRenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Rentas] DROP CONSTRAINT [FK_ClienteRenta];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteAsistenciaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaTecnicas] DROP CONSTRAINT [FK_ClienteAsistenciaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoCompra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compras] DROP CONSTRAINT [FK_TipoPagoCompra];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoAsistenciaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsistenciaTecnicas] DROP CONSTRAINT [FK_TipoPagoAsistenciaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_Estado_ProductoProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Productos] DROP CONSTRAINT [FK_Estado_ProductoProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoDetalleRenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleRentas] DROP CONSTRAINT [FK_ProductoDetalleRenta];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoDetallaAsistenciaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetallaAsistenciaTecnicas] DROP CONSTRAINT [FK_ProductoDetallaAsistenciaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoCuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas] DROP CONSTRAINT [FK_TipoPagoCuota];
GO
IF OBJECT_ID(N'[dbo].[FK_CuotaDetalleCuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleCuotas] DROP CONSTRAINT [FK_CuotaDetalleCuota];
GO
IF OBJECT_ID(N'[dbo].[FK_RentaCuota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cuotas] DROP CONSTRAINT [FK_RentaCuota];
GO
IF OBJECT_ID(N'[dbo].[FK_ventaDetalleVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVentas] DROP CONSTRAINT [FK_ventaDetalleVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_Empleadoventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_Empleadoventa];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoFacturaventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_TipoFacturaventa];
GO
IF OBJECT_ID(N'[dbo].[FK_EstadoFacturaventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_EstadoFacturaventa];
GO
IF OBJECT_ID(N'[dbo].[FK_Clienteventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_Clienteventa];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductoDetalleVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVentas] DROP CONSTRAINT [FK_ProductoDetalleVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_Retencionventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_Retencionventa];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoPagoventa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ventas] DROP CONSTRAINT [FK_TipoPagoventa];
GO
IF OBJECT_ID(N'[dbo].[FK_DescuentoDetalleVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleVentas] DROP CONSTRAINT [FK_DescuentoDetalleVenta];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Productos];
GO
IF OBJECT_ID(N'[dbo].[Categorias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categorias];
GO
IF OBJECT_ID(N'[dbo].[Marcas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Marcas];
GO
IF OBJECT_ID(N'[dbo].[ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ventas];
GO
IF OBJECT_ID(N'[dbo].[EstadoFacturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoFacturas];
GO
IF OBJECT_ID(N'[dbo].[DetalleVentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleVentas];
GO
IF OBJECT_ID(N'[dbo].[Compras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compras];
GO
IF OBJECT_ID(N'[dbo].[DetalleCompras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCompras];
GO
IF OBJECT_ID(N'[dbo].[Proveedores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Proveedores];
GO
IF OBJECT_ID(N'[dbo].[RazonSociales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RazonSociales];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Rentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Rentas];
GO
IF OBJECT_ID(N'[dbo].[DetalleRentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleRentas];
GO
IF OBJECT_ID(N'[dbo].[AsistenciaTecnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsistenciaTecnicas];
GO
IF OBJECT_ID(N'[dbo].[DetallaAsistenciaTecnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetallaAsistenciaTecnicas];
GO
IF OBJECT_ID(N'[dbo].[Retenciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Retenciones];
GO
IF OBJECT_ID(N'[dbo].[TipoPagos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoPagos];
GO
IF OBJECT_ID(N'[dbo].[TipoFacturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoFacturas];
GO
IF OBJECT_ID(N'[dbo].[Cuotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cuotas];
GO
IF OBJECT_ID(N'[dbo].[Estado_Productos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Estado_Productos];
GO
IF OBJECT_ID(N'[dbo].[DetalleCuotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleCuotas];
GO
IF OBJECT_ID(N'[dbo].[Descuentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Descuentos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Productos'
CREATE TABLE [dbo].[Productos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Prod] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL,
    [Modelo] nvarchar(30)  NOT NULL,
    [Num_Serie] nvarchar(30)  NOT NULL,
    [Stock] int  NOT NULL,
    [PrecioCompra] float  NOT NULL,
    [PrecioVenta] float  NOT NULL,
    [Pre_UniRenta] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(100)  NOT NULL,
    [MarcaId] int  NOT NULL,
    [CategoriaId] int  NOT NULL,
    [Estado_ProductoId] int  NOT NULL
);
GO

-- Creating table 'Categorias'
CREATE TABLE [dbo].[Categorias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Categoria] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Marcas'
CREATE TABLE [dbo].[Marcas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Marca] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'ventas'
CREATE TABLE [dbo].[ventas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Venta] nvarchar(10)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Total] float  NOT NULL,
    [EmpleadoId] int  NOT NULL,
    [TipoFacturaId] int  NOT NULL,
    [EstadoFacturaId] int  NOT NULL,
    [ClienteId] int  NOT NULL,
    [RetencionId] int  NOT NULL,
    [TipoPagoId] int  NOT NULL
);
GO

-- Creating table 'EstadoFacturas'
CREATE TABLE [dbo].[EstadoFacturas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_EstadoFac] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'DetalleVentas'
CREATE TABLE [dbo].[DetalleVentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] int  NOT NULL,
    [Subtotal] float  NOT NULL,
    [ventaId] int  NOT NULL,
    [ProductoId] int  NOT NULL,
    [DescuentoId] int  NOT NULL
);
GO

-- Creating table 'Compras'
CREATE TABLE [dbo].[Compras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Compra] nvarchar(10)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Total] float  NOT NULL,
    [EmpleadoId] int  NOT NULL,
    [ProveedorId] int  NOT NULL,
    [RetencionId] int  NOT NULL,
    [TipoPagoId] int  NOT NULL
);
GO

-- Creating table 'DetalleCompras'
CREATE TABLE [dbo].[DetalleCompras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [subtotal] float  NOT NULL,
    [Cantidad] int  NOT NULL,
    [CompraId] int  NOT NULL,
    [ProductoId] int  NOT NULL
);
GO

-- Creating table 'Proveedores'
CREATE TABLE [dbo].[Proveedores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Proveedor] nvarchar(10)  NOT NULL,
    [Identificacion] nvarchar(30)  NOT NULL,
    [Nombres] nvarchar(30)  NOT NULL,
    [Apellidos] nvarchar(30)  NOT NULL,
    [Telefono] int  NOT NULL,
    [Correo] nvarchar(40)  NOT NULL,
    [RazonSocialId] int  NOT NULL
);
GO

-- Creating table 'RazonSociales'
CREATE TABLE [dbo].[RazonSociales] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_RaSocial] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Emp] nvarchar(10)  NOT NULL,
    [Nombres] varchar(30)  NOT NULL,
    [Apellidos] varchar(30)  NOT NULL,
    [Cedula] nvarchar(16)  NOT NULL,
    [Telefono] int  NOT NULL,
    [Direccion] nvarchar(30)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Cli] nvarchar(10)  NOT NULL,
    [Nombres] nvarchar(30)  NOT NULL,
    [Apellidos] nvarchar(30)  NULL,
    [Identificacion] nvarchar(16)  NOT NULL,
    [Telefono] int  NOT NULL,
    [Direccion] nvarchar(30)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [RazonSocialId] int  NOT NULL
);
GO

-- Creating table 'Rentas'
CREATE TABLE [dbo].[Rentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Renta] nvarchar(10)  NOT NULL,
    [Total_Renta] float  NOT NULL,
    [Fecha_Inicio] datetime  NOT NULL,
    [Fecha_Final] datetime  NOT NULL,
    [EmpleadoId] int  NOT NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'DetalleRentas'
CREATE TABLE [dbo].[DetalleRentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] int  NOT NULL,
    [RentaId] int  NOT NULL,
    [ProductoId] int  NOT NULL
);
GO

-- Creating table 'AsistenciaTecnicas'
CREATE TABLE [dbo].[AsistenciaTecnicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_AsisTec] nvarchar(10)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Direccion] nvarchar(50)  NOT NULL,
    [Total] float  NOT NULL,
    [Descripcion] nvarchar(80)  NOT NULL,
    [EmpleadoId] int  NOT NULL,
    [ClienteId] int  NOT NULL,
    [TipoPagoId] int  NOT NULL
);
GO

-- Creating table 'DetallaAsistenciaTecnicas'
CREATE TABLE [dbo].[DetallaAsistenciaTecnicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrecioUnidad] nvarchar(max)  NOT NULL,
    [Cantidad] int  NOT NULL,
    [AsistenciaTecnicaId] int  NOT NULL,
    [ProductoId] int  NOT NULL
);
GO

-- Creating table 'Retenciones'
CREATE TABLE [dbo].[Retenciones] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Reten] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Porcentaje] float  NOT NULL
);
GO

-- Creating table 'TipoPagos'
CREATE TABLE [dbo].[TipoPagos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_TipoP] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'TipoFacturas'
CREATE TABLE [dbo].[TipoFacturas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_TipoFac] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'Cuotas'
CREATE TABLE [dbo].[Cuotas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Cuota] nvarchar(6)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [TotalAbonado] float  NOT NULL,
    [TipoPagoId] int  NOT NULL,
    [RentaId] int  NOT NULL
);
GO

-- Creating table 'Estado_Productos'
CREATE TABLE [dbo].[Estado_Productos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_EsPro] nvarchar(10)  NOT NULL,
    [Nombre] nvarchar(30)  NOT NULL,
    [Observacion] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'DetalleCuotas'
CREATE TABLE [dbo].[DetalleCuotas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Volumen_Impreso] nvarchar(max)  NOT NULL,
    [Subtotal] nvarchar(max)  NOT NULL,
    [CuotaId] int  NOT NULL
);
GO

-- Creating table 'Descuentos'
CREATE TABLE [dbo].[Descuentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cod_Desc] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Porcentaje] float  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [PK_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categorias'
ALTER TABLE [dbo].[Categorias]
ADD CONSTRAINT [PK_Categorias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Marcas'
ALTER TABLE [dbo].[Marcas]
ADD CONSTRAINT [PK_Marcas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [PK_ventas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoFacturas'
ALTER TABLE [dbo].[EstadoFacturas]
ADD CONSTRAINT [PK_EstadoFacturas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [PK_DetalleVentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [PK_Compras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleCompras'
ALTER TABLE [dbo].[DetalleCompras]
ADD CONSTRAINT [PK_DetalleCompras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [PK_Proveedores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RazonSociales'
ALTER TABLE [dbo].[RazonSociales]
ADD CONSTRAINT [PK_RazonSociales]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Rentas'
ALTER TABLE [dbo].[Rentas]
ADD CONSTRAINT [PK_Rentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleRentas'
ALTER TABLE [dbo].[DetalleRentas]
ADD CONSTRAINT [PK_DetalleRentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AsistenciaTecnicas'
ALTER TABLE [dbo].[AsistenciaTecnicas]
ADD CONSTRAINT [PK_AsistenciaTecnicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetallaAsistenciaTecnicas'
ALTER TABLE [dbo].[DetallaAsistenciaTecnicas]
ADD CONSTRAINT [PK_DetallaAsistenciaTecnicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Retenciones'
ALTER TABLE [dbo].[Retenciones]
ADD CONSTRAINT [PK_Retenciones]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoPagos'
ALTER TABLE [dbo].[TipoPagos]
ADD CONSTRAINT [PK_TipoPagos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoFacturas'
ALTER TABLE [dbo].[TipoFacturas]
ADD CONSTRAINT [PK_TipoFacturas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [PK_Cuotas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estado_Productos'
ALTER TABLE [dbo].[Estado_Productos]
ADD CONSTRAINT [PK_Estado_Productos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleCuotas'
ALTER TABLE [dbo].[DetalleCuotas]
ADD CONSTRAINT [PK_DetalleCuotas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Descuentos'
ALTER TABLE [dbo].[Descuentos]
ADD CONSTRAINT [PK_Descuentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MarcaId] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_MarcaProducto]
    FOREIGN KEY ([MarcaId])
    REFERENCES [dbo].[Marcas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MarcaProducto'
CREATE INDEX [IX_FK_MarcaProducto]
ON [dbo].[Productos]
    ([MarcaId]);
GO

-- Creating foreign key on [CategoriaId] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_CategoriaProducto]
    FOREIGN KEY ([CategoriaId])
    REFERENCES [dbo].[Categorias]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoriaProducto'
CREATE INDEX [IX_FK_CategoriaProducto]
ON [dbo].[Productos]
    ([CategoriaId]);
GO

-- Creating foreign key on [CompraId] in table 'DetalleCompras'
ALTER TABLE [dbo].[DetalleCompras]
ADD CONSTRAINT [FK_CompraDetalleCompra]
    FOREIGN KEY ([CompraId])
    REFERENCES [dbo].[Compras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompraDetalleCompra'
CREATE INDEX [IX_FK_CompraDetalleCompra]
ON [dbo].[DetalleCompras]
    ([CompraId]);
GO

-- Creating foreign key on [RentaId] in table 'DetalleRentas'
ALTER TABLE [dbo].[DetalleRentas]
ADD CONSTRAINT [FK_RentaDetalleRenta]
    FOREIGN KEY ([RentaId])
    REFERENCES [dbo].[Rentas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RentaDetalleRenta'
CREATE INDEX [IX_FK_RentaDetalleRenta]
ON [dbo].[DetalleRentas]
    ([RentaId]);
GO

-- Creating foreign key on [ProductoId] in table 'DetalleCompras'
ALTER TABLE [dbo].[DetalleCompras]
ADD CONSTRAINT [FK_ProductoDetalleCompra]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoDetalleCompra'
CREATE INDEX [IX_FK_ProductoDetalleCompra]
ON [dbo].[DetalleCompras]
    ([ProductoId]);
GO

-- Creating foreign key on [AsistenciaTecnicaId] in table 'DetallaAsistenciaTecnicas'
ALTER TABLE [dbo].[DetallaAsistenciaTecnicas]
ADD CONSTRAINT [FK_AsistenciaTecnicaDetallaAsistenciaTecnica]
    FOREIGN KEY ([AsistenciaTecnicaId])
    REFERENCES [dbo].[AsistenciaTecnicas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AsistenciaTecnicaDetallaAsistenciaTecnica'
CREATE INDEX [IX_FK_AsistenciaTecnicaDetallaAsistenciaTecnica]
ON [dbo].[DetallaAsistenciaTecnicas]
    ([AsistenciaTecnicaId]);
GO

-- Creating foreign key on [RazonSocialId] in table 'Proveedores'
ALTER TABLE [dbo].[Proveedores]
ADD CONSTRAINT [FK_RazonSocialProveedor]
    FOREIGN KEY ([RazonSocialId])
    REFERENCES [dbo].[RazonSociales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RazonSocialProveedor'
CREATE INDEX [IX_FK_RazonSocialProveedor]
ON [dbo].[Proveedores]
    ([RazonSocialId]);
GO

-- Creating foreign key on [RazonSocialId] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_RazonSocialCliente]
    FOREIGN KEY ([RazonSocialId])
    REFERENCES [dbo].[RazonSociales]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RazonSocialCliente'
CREATE INDEX [IX_FK_RazonSocialCliente]
ON [dbo].[Clientes]
    ([RazonSocialId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_EmpleadoCompra]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoCompra'
CREATE INDEX [IX_FK_EmpleadoCompra]
ON [dbo].[Compras]
    ([EmpleadoId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'Rentas'
ALTER TABLE [dbo].[Rentas]
ADD CONSTRAINT [FK_EmpleadoRenta]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoRenta'
CREATE INDEX [IX_FK_EmpleadoRenta]
ON [dbo].[Rentas]
    ([EmpleadoId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'AsistenciaTecnicas'
ALTER TABLE [dbo].[AsistenciaTecnicas]
ADD CONSTRAINT [FK_EmpleadoAsistenciaTecnica]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoAsistenciaTecnica'
CREATE INDEX [IX_FK_EmpleadoAsistenciaTecnica]
ON [dbo].[AsistenciaTecnicas]
    ([EmpleadoId]);
GO

-- Creating foreign key on [ProveedorId] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_ProveedorCompra]
    FOREIGN KEY ([ProveedorId])
    REFERENCES [dbo].[Proveedores]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProveedorCompra'
CREATE INDEX [IX_FK_ProveedorCompra]
ON [dbo].[Compras]
    ([ProveedorId]);
GO

-- Creating foreign key on [RetencionId] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_RetencionCompra]
    FOREIGN KEY ([RetencionId])
    REFERENCES [dbo].[Retenciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RetencionCompra'
CREATE INDEX [IX_FK_RetencionCompra]
ON [dbo].[Compras]
    ([RetencionId]);
GO

-- Creating foreign key on [ClienteId] in table 'Rentas'
ALTER TABLE [dbo].[Rentas]
ADD CONSTRAINT [FK_ClienteRenta]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteRenta'
CREATE INDEX [IX_FK_ClienteRenta]
ON [dbo].[Rentas]
    ([ClienteId]);
GO

-- Creating foreign key on [ClienteId] in table 'AsistenciaTecnicas'
ALTER TABLE [dbo].[AsistenciaTecnicas]
ADD CONSTRAINT [FK_ClienteAsistenciaTecnica]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteAsistenciaTecnica'
CREATE INDEX [IX_FK_ClienteAsistenciaTecnica]
ON [dbo].[AsistenciaTecnicas]
    ([ClienteId]);
GO

-- Creating foreign key on [TipoPagoId] in table 'Compras'
ALTER TABLE [dbo].[Compras]
ADD CONSTRAINT [FK_TipoPagoCompra]
    FOREIGN KEY ([TipoPagoId])
    REFERENCES [dbo].[TipoPagos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoCompra'
CREATE INDEX [IX_FK_TipoPagoCompra]
ON [dbo].[Compras]
    ([TipoPagoId]);
GO

-- Creating foreign key on [TipoPagoId] in table 'AsistenciaTecnicas'
ALTER TABLE [dbo].[AsistenciaTecnicas]
ADD CONSTRAINT [FK_TipoPagoAsistenciaTecnica]
    FOREIGN KEY ([TipoPagoId])
    REFERENCES [dbo].[TipoPagos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoAsistenciaTecnica'
CREATE INDEX [IX_FK_TipoPagoAsistenciaTecnica]
ON [dbo].[AsistenciaTecnicas]
    ([TipoPagoId]);
GO

-- Creating foreign key on [Estado_ProductoId] in table 'Productos'
ALTER TABLE [dbo].[Productos]
ADD CONSTRAINT [FK_Estado_ProductoProducto]
    FOREIGN KEY ([Estado_ProductoId])
    REFERENCES [dbo].[Estado_Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Estado_ProductoProducto'
CREATE INDEX [IX_FK_Estado_ProductoProducto]
ON [dbo].[Productos]
    ([Estado_ProductoId]);
GO

-- Creating foreign key on [ProductoId] in table 'DetalleRentas'
ALTER TABLE [dbo].[DetalleRentas]
ADD CONSTRAINT [FK_ProductoDetalleRenta]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoDetalleRenta'
CREATE INDEX [IX_FK_ProductoDetalleRenta]
ON [dbo].[DetalleRentas]
    ([ProductoId]);
GO

-- Creating foreign key on [ProductoId] in table 'DetallaAsistenciaTecnicas'
ALTER TABLE [dbo].[DetallaAsistenciaTecnicas]
ADD CONSTRAINT [FK_ProductoDetallaAsistenciaTecnica]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoDetallaAsistenciaTecnica'
CREATE INDEX [IX_FK_ProductoDetallaAsistenciaTecnica]
ON [dbo].[DetallaAsistenciaTecnicas]
    ([ProductoId]);
GO

-- Creating foreign key on [TipoPagoId] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [FK_TipoPagoCuota]
    FOREIGN KEY ([TipoPagoId])
    REFERENCES [dbo].[TipoPagos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoCuota'
CREATE INDEX [IX_FK_TipoPagoCuota]
ON [dbo].[Cuotas]
    ([TipoPagoId]);
GO

-- Creating foreign key on [CuotaId] in table 'DetalleCuotas'
ALTER TABLE [dbo].[DetalleCuotas]
ADD CONSTRAINT [FK_CuotaDetalleCuota]
    FOREIGN KEY ([CuotaId])
    REFERENCES [dbo].[Cuotas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuotaDetalleCuota'
CREATE INDEX [IX_FK_CuotaDetalleCuota]
ON [dbo].[DetalleCuotas]
    ([CuotaId]);
GO

-- Creating foreign key on [RentaId] in table 'Cuotas'
ALTER TABLE [dbo].[Cuotas]
ADD CONSTRAINT [FK_RentaCuota]
    FOREIGN KEY ([RentaId])
    REFERENCES [dbo].[Rentas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RentaCuota'
CREATE INDEX [IX_FK_RentaCuota]
ON [dbo].[Cuotas]
    ([RentaId]);
GO

-- Creating foreign key on [ventaId] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [FK_ventaDetalleVenta]
    FOREIGN KEY ([ventaId])
    REFERENCES [dbo].[ventas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ventaDetalleVenta'
CREATE INDEX [IX_FK_ventaDetalleVenta]
ON [dbo].[DetalleVentas]
    ([ventaId]);
GO

-- Creating foreign key on [EmpleadoId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_Empleadoventa]
    FOREIGN KEY ([EmpleadoId])
    REFERENCES [dbo].[Empleados]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Empleadoventa'
CREATE INDEX [IX_FK_Empleadoventa]
ON [dbo].[ventas]
    ([EmpleadoId]);
GO

-- Creating foreign key on [TipoFacturaId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_TipoFacturaventa]
    FOREIGN KEY ([TipoFacturaId])
    REFERENCES [dbo].[TipoFacturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoFacturaventa'
CREATE INDEX [IX_FK_TipoFacturaventa]
ON [dbo].[ventas]
    ([TipoFacturaId]);
GO

-- Creating foreign key on [EstadoFacturaId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_EstadoFacturaventa]
    FOREIGN KEY ([EstadoFacturaId])
    REFERENCES [dbo].[EstadoFacturas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstadoFacturaventa'
CREATE INDEX [IX_FK_EstadoFacturaventa]
ON [dbo].[ventas]
    ([EstadoFacturaId]);
GO

-- Creating foreign key on [ClienteId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_Clienteventa]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clienteventa'
CREATE INDEX [IX_FK_Clienteventa]
ON [dbo].[ventas]
    ([ClienteId]);
GO

-- Creating foreign key on [ProductoId] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [FK_ProductoDetalleVenta]
    FOREIGN KEY ([ProductoId])
    REFERENCES [dbo].[Productos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductoDetalleVenta'
CREATE INDEX [IX_FK_ProductoDetalleVenta]
ON [dbo].[DetalleVentas]
    ([ProductoId]);
GO

-- Creating foreign key on [RetencionId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_Retencionventa]
    FOREIGN KEY ([RetencionId])
    REFERENCES [dbo].[Retenciones]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Retencionventa'
CREATE INDEX [IX_FK_Retencionventa]
ON [dbo].[ventas]
    ([RetencionId]);
GO

-- Creating foreign key on [TipoPagoId] in table 'ventas'
ALTER TABLE [dbo].[ventas]
ADD CONSTRAINT [FK_TipoPagoventa]
    FOREIGN KEY ([TipoPagoId])
    REFERENCES [dbo].[TipoPagos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoPagoventa'
CREATE INDEX [IX_FK_TipoPagoventa]
ON [dbo].[ventas]
    ([TipoPagoId]);
GO

-- Creating foreign key on [DescuentoId] in table 'DetalleVentas'
ALTER TABLE [dbo].[DetalleVentas]
ADD CONSTRAINT [FK_DescuentoDetalleVenta]
    FOREIGN KEY ([DescuentoId])
    REFERENCES [dbo].[Descuentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DescuentoDetalleVenta'
CREATE INDEX [IX_FK_DescuentoDetalleVenta]
ON [dbo].[DetalleVentas]
    ([DescuentoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------