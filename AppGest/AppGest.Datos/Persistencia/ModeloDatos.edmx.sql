
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 02/09/2013 01:58:18
-- Generated from EDMX file: D:\Datos\RONECIO\RFW\Code\rnc\AppGest\AppGest.Datos\Persistencia\ModeloDatos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PROD_LGP];
GO
IF SCHEMA_ID(N'LGP') IS NULL EXECUTE(N'CREATE SCHEMA [LGP]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[LGP].[FK_Reg_encabReg_Det]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_Reg_encabReg_Det];
GO
IF OBJECT_ID(N'[LGP].[FK_UsuarioReg_encab]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_UsuarioReg_encab];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Usuario] DROP CONSTRAINT [FK_PersonaUsuario];
GO
IF OBJECT_ID(N'[LGP].[FK_ConceptoReg_Det]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_ConceptoReg_Det];
GO
IF OBJECT_ID(N'[LGP].[FK_ConceptoReg_encab]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_ConceptoReg_encab];
GO
IF OBJECT_ID(N'[LGP].[FK_EBReg_Det3]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_EBReg_Det3];
GO
IF OBJECT_ID(N'[LGP].[FK_EBReg_Det4]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_EBReg_Det4];
GO
IF OBJECT_ID(N'[LGP].[FK_EBReg_Det5]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_EBReg_Det5];
GO
IF OBJECT_ID(N'[LGP].[FK_EBReg_Det6]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_EBReg_Det6];
GO
IF OBJECT_ID(N'[LGP].[FK_EBReg_Det7]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_EBReg_Det7];
GO
IF OBJECT_ID(N'[LGP].[FK_Persona_Reg_encab]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_Persona_Reg_encab];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_encab]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_PersonaReg_encab];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_encab1]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_PersonaReg_encab1];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_encab2]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_encab] DROP CONSTRAINT [FK_PersonaReg_encab2];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_Det]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_PersonaReg_Det];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_Det1]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_PersonaReg_Det1];
GO
IF OBJECT_ID(N'[LGP].[FK_PersonaReg_Det2]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[Reg_Det] DROP CONSTRAINT [FK_PersonaReg_Det2];
GO
IF OBJECT_ID(N'[LGP].[FK_Entidad_inherits_EB]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Entidad] DROP CONSTRAINT [FK_Entidad_inherits_EB];
GO
IF OBJECT_ID(N'[LGP].[FK_Usuario_inherits_Entidad]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Usuario] DROP CONSTRAINT [FK_Usuario_inherits_Entidad];
GO
IF OBJECT_ID(N'[LGP].[FK_Persona_inherits_Entidad]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Persona] DROP CONSTRAINT [FK_Persona_inherits_Entidad];
GO
IF OBJECT_ID(N'[LGP].[FK_Concepto_inherits_EB]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Concepto] DROP CONSTRAINT [FK_Concepto_inherits_EB];
GO
IF OBJECT_ID(N'[LGP].[FK_Cliente_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Cliente] DROP CONSTRAINT [FK_Cliente_inherits_Persona];
GO
IF OBJECT_ID(N'[LGP].[FK_Empleado_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Empleado] DROP CONSTRAINT [FK_Empleado_inherits_Persona];
GO
IF OBJECT_ID(N'[LGP].[FK_Vehiculo_inherits_Entidad]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Vehiculo] DROP CONSTRAINT [FK_Vehiculo_inherits_Entidad];
GO
IF OBJECT_ID(N'[LGP].[FK_Cochera_inherits_Entidad]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Cochera] DROP CONSTRAINT [FK_Cochera_inherits_Entidad];
GO
IF OBJECT_ID(N'[LGP].[FK_Empresa_inherits_Persona]', 'F') IS NOT NULL
    ALTER TABLE [LGP].[EB_Empresa] DROP CONSTRAINT [FK_Empresa_inherits_Persona];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[LGP].[EB]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB];
GO
IF OBJECT_ID(N'[LGP].[Reg_Det]', 'U') IS NOT NULL
    DROP TABLE [LGP].[Reg_Det];
GO
IF OBJECT_ID(N'[LGP].[Reg_encab]', 'U') IS NOT NULL
    DROP TABLE [LGP].[Reg_encab];
GO
IF OBJECT_ID(N'[LGP].[ConfMenu]', 'U') IS NOT NULL
    DROP TABLE [LGP].[ConfMenu];
GO
IF OBJECT_ID(N'[LGP].[EB_Entidad]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Entidad];
GO
IF OBJECT_ID(N'[LGP].[EB_Usuario]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Usuario];
GO
IF OBJECT_ID(N'[LGP].[EB_Persona]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Persona];
GO
IF OBJECT_ID(N'[LGP].[EB_Concepto]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Concepto];
GO
IF OBJECT_ID(N'[LGP].[EB_Cliente]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Cliente];
GO
IF OBJECT_ID(N'[LGP].[EB_Empleado]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Empleado];
GO
IF OBJECT_ID(N'[LGP].[EB_Vehiculo]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Vehiculo];
GO
IF OBJECT_ID(N'[LGP].[EB_Cochera]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Cochera];
GO
IF OBJECT_ID(N'[LGP].[EB_Empresa]', 'U') IS NOT NULL
    DROP TABLE [LGP].[EB_Empresa];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EB'
CREATE TABLE [LGP].[EB] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Alta] datetime  NOT NULL,
    [Baja] datetime  NULL,
    [Abreviatura] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NULL,
    [Observaciones] nvarchar(max)  NULL
);
GO

-- Creating table 'Reg_Det'
CREATE TABLE [LGP].[Reg_Det] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FechaAlta] datetime  NULL,
    [FechaBaja] datetime  NULL,
    [FechaModif] datetime  NULL,
    [Cantidad] decimal(18,5)  NULL,
    [Precio] decimal(18,5)  NULL,
    [Importe] decimal(18,5)  NULL,
    [ValNum1] decimal(18,5)  NULL,
    [ValNum2] decimal(18,5)  NULL,
    [ValNum3] decimal(18,5)  NULL,
    [ValNum4] decimal(18,5)  NULL,
    [ValText1] varchar(max)  NULL,
    [ValText2] varchar(max)  NULL,
    [ValText3] varchar(max)  NULL,
    [ValText4] varchar(max)  NULL,
    [Comentario] varchar(max)  NULL,
    [ValFecha1] datetime  NULL,
    [ValFecha2] datetime  NULL,
    [ValFecha3] datetime  NULL,
    [ValFecha4] datetime  NULL,
    [Reg_encab_Id] bigint  NOT NULL,
    [Concepto_Id] bigint  NULL,
    [ValLista1_Id] bigint  NULL,
    [ValLista2_Id] bigint  NULL,
    [ValLista3_Id] bigint  NULL,
    [ValLista4_Id] bigint  NULL,
    [UM_Id] bigint  NULL,
    [EntidadAfectada2_Id] bigint  NULL,
    [EntidadAfectada1_Id] bigint  NULL,
    [EntidadAfectada3_Id] bigint  NULL
);
GO

-- Creating table 'Reg_encab'
CREATE TABLE [LGP].[Reg_encab] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FechaAlta] datetime  NOT NULL,
    [FechaRegistro] datetime  NULL,
    [Comentario] varchar(max)  NULL,
    [FechaModif] datetime  NULL,
    [FechaBaja] datetime  NULL,
    [Usuario_Id] bigint  NULL,
    [Concepto_Id] bigint  NULL,
    [EntidadRegistro_Id] bigint  NULL,
    [EntidadEmpresa_Id] bigint  NULL,
    [EntidadResp_Id] bigint  NULL,
    [EntidadAfectada_Id] bigint  NULL
);
GO

-- Creating table 'ConfMenu'
CREATE TABLE [LGP].[ConfMenu] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Orden] nvarchar(max)  NOT NULL,
    [Paginas] nvarchar(max)  NOT NULL,
    [Grupos] nvarchar(max)  NOT NULL,
    [Items] nvarchar(max)  NOT NULL,
    [ImagenItem] nvarchar(max)  NOT NULL,
    [TagItem] nvarchar(max)  NOT NULL,
    [ToolTips] nvarchar(max)  NOT NULL,
    [AutoSize] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EB_Entidad'
CREATE TABLE [LGP].[EB_Entidad] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Usuario'
CREATE TABLE [LGP].[EB_Usuario] (
    [Clave] nvarchar(200)  NOT NULL,
    [Tipo] tinyint  NOT NULL,
    [Id] bigint  NOT NULL,
    [Persona_Id] bigint  NULL
);
GO

-- Creating table 'EB_Persona'
CREATE TABLE [LGP].[EB_Persona] (
    [Tipo] int  NOT NULL,
    [Contacto_Domicilio] nvarchar(max)  NULL,
    [Contacto_Telefono] nvarchar(200)  NULL,
    [Contacto_TelefonoTrabajo] nvarchar(200)  NULL,
    [Contacto_Movil] nvarchar(200)  NULL,
    [Contacto_Email] nvarchar(200)  NULL,
    [Nombre2] nvarchar(max)  NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Dni] int  NULL,
    [Lock] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Concepto'
CREATE TABLE [LGP].[EB_Concepto] (
    [Clase] int  NOT NULL,
    [Valor] int  NOT NULL,
    [DeSistema] bit  NOT NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Cliente'
CREATE TABLE [LGP].[EB_Cliente] (
    [NroCliente] int  NOT NULL,
    [CUIT] nvarchar(max)  NULL,
    [DomicilioFiscal] nvarchar(max)  NULL,
    [RazonSocial] nvarchar(max)  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Empleado'
CREATE TABLE [LGP].[EB_Empleado] (
    [CUIL] nvarchar(max)  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Vehiculo'
CREATE TABLE [LGP].[EB_Vehiculo] (
    [Modelo] nvarchar(max)  NULL,
    [Marca] nvarchar(max)  NULL,
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Cochera'
CREATE TABLE [LGP].[EB_Cochera] (
    [Id] bigint  NOT NULL
);
GO

-- Creating table 'EB_Empresa'
CREATE TABLE [LGP].[EB_Empresa] (
    [Id] bigint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'EB'
ALTER TABLE [LGP].[EB]
ADD CONSTRAINT [PK_EB]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [PK_Reg_Det]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [PK_Reg_encab]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConfMenu'
ALTER TABLE [LGP].[ConfMenu]
ADD CONSTRAINT [PK_ConfMenu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Entidad'
ALTER TABLE [LGP].[EB_Entidad]
ADD CONSTRAINT [PK_EB_Entidad]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Usuario'
ALTER TABLE [LGP].[EB_Usuario]
ADD CONSTRAINT [PK_EB_Usuario]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Persona'
ALTER TABLE [LGP].[EB_Persona]
ADD CONSTRAINT [PK_EB_Persona]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Concepto'
ALTER TABLE [LGP].[EB_Concepto]
ADD CONSTRAINT [PK_EB_Concepto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Cliente'
ALTER TABLE [LGP].[EB_Cliente]
ADD CONSTRAINT [PK_EB_Cliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Empleado'
ALTER TABLE [LGP].[EB_Empleado]
ADD CONSTRAINT [PK_EB_Empleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Vehiculo'
ALTER TABLE [LGP].[EB_Vehiculo]
ADD CONSTRAINT [PK_EB_Vehiculo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Cochera'
ALTER TABLE [LGP].[EB_Cochera]
ADD CONSTRAINT [PK_EB_Cochera]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EB_Empresa'
ALTER TABLE [LGP].[EB_Empresa]
ADD CONSTRAINT [PK_EB_Empresa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Reg_encab_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_Reg_encabReg_Det]
    FOREIGN KEY ([Reg_encab_Id])
    REFERENCES [LGP].[Reg_encab]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Reg_encabReg_Det'
CREATE INDEX [IX_FK_Reg_encabReg_Det]
ON [LGP].[Reg_Det]
    ([Reg_encab_Id]);
GO

-- Creating foreign key on [Usuario_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_UsuarioReg_encab]
    FOREIGN KEY ([Usuario_Id])
    REFERENCES [LGP].[EB_Usuario]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioReg_encab'
CREATE INDEX [IX_FK_UsuarioReg_encab]
ON [LGP].[Reg_encab]
    ([Usuario_Id]);
GO

-- Creating foreign key on [Persona_Id] in table 'EB_Usuario'
ALTER TABLE [LGP].[EB_Usuario]
ADD CONSTRAINT [FK_PersonaUsuario]
    FOREIGN KEY ([Persona_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaUsuario'
CREATE INDEX [IX_FK_PersonaUsuario]
ON [LGP].[EB_Usuario]
    ([Persona_Id]);
GO

-- Creating foreign key on [Concepto_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_ConceptoReg_Det]
    FOREIGN KEY ([Concepto_Id])
    REFERENCES [LGP].[EB_Concepto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConceptoReg_Det'
CREATE INDEX [IX_FK_ConceptoReg_Det]
ON [LGP].[Reg_Det]
    ([Concepto_Id]);
GO

-- Creating foreign key on [Concepto_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_ConceptoReg_encab]
    FOREIGN KEY ([Concepto_Id])
    REFERENCES [LGP].[EB_Concepto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ConceptoReg_encab'
CREATE INDEX [IX_FK_ConceptoReg_encab]
ON [LGP].[Reg_encab]
    ([Concepto_Id]);
GO

-- Creating foreign key on [ValLista1_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_EBReg_Det3]
    FOREIGN KEY ([ValLista1_Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBReg_Det3'
CREATE INDEX [IX_FK_EBReg_Det3]
ON [LGP].[Reg_Det]
    ([ValLista1_Id]);
GO

-- Creating foreign key on [ValLista2_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_EBReg_Det4]
    FOREIGN KEY ([ValLista2_Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBReg_Det4'
CREATE INDEX [IX_FK_EBReg_Det4]
ON [LGP].[Reg_Det]
    ([ValLista2_Id]);
GO

-- Creating foreign key on [ValLista3_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_EBReg_Det5]
    FOREIGN KEY ([ValLista3_Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBReg_Det5'
CREATE INDEX [IX_FK_EBReg_Det5]
ON [LGP].[Reg_Det]
    ([ValLista3_Id]);
GO

-- Creating foreign key on [ValLista4_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_EBReg_Det6]
    FOREIGN KEY ([ValLista4_Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBReg_Det6'
CREATE INDEX [IX_FK_EBReg_Det6]
ON [LGP].[Reg_Det]
    ([ValLista4_Id]);
GO

-- Creating foreign key on [UM_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_EBReg_Det7]
    FOREIGN KEY ([UM_Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EBReg_Det7'
CREATE INDEX [IX_FK_EBReg_Det7]
ON [LGP].[Reg_Det]
    ([UM_Id]);
GO

-- Creating foreign key on [EntidadRegistro_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_Persona_Reg_encab]
    FOREIGN KEY ([EntidadRegistro_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persona_Reg_encab'
CREATE INDEX [IX_FK_Persona_Reg_encab]
ON [LGP].[Reg_encab]
    ([EntidadRegistro_Id]);
GO

-- Creating foreign key on [EntidadEmpresa_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_PersonaReg_encab]
    FOREIGN KEY ([EntidadEmpresa_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_encab'
CREATE INDEX [IX_FK_PersonaReg_encab]
ON [LGP].[Reg_encab]
    ([EntidadEmpresa_Id]);
GO

-- Creating foreign key on [EntidadResp_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_PersonaReg_encab1]
    FOREIGN KEY ([EntidadResp_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_encab1'
CREATE INDEX [IX_FK_PersonaReg_encab1]
ON [LGP].[Reg_encab]
    ([EntidadResp_Id]);
GO

-- Creating foreign key on [EntidadAfectada_Id] in table 'Reg_encab'
ALTER TABLE [LGP].[Reg_encab]
ADD CONSTRAINT [FK_PersonaReg_encab2]
    FOREIGN KEY ([EntidadAfectada_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_encab2'
CREATE INDEX [IX_FK_PersonaReg_encab2]
ON [LGP].[Reg_encab]
    ([EntidadAfectada_Id]);
GO

-- Creating foreign key on [EntidadAfectada2_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_PersonaReg_Det]
    FOREIGN KEY ([EntidadAfectada2_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_Det'
CREATE INDEX [IX_FK_PersonaReg_Det]
ON [LGP].[Reg_Det]
    ([EntidadAfectada2_Id]);
GO

-- Creating foreign key on [EntidadAfectada1_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_PersonaReg_Det1]
    FOREIGN KEY ([EntidadAfectada1_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_Det1'
CREATE INDEX [IX_FK_PersonaReg_Det1]
ON [LGP].[Reg_Det]
    ([EntidadAfectada1_Id]);
GO

-- Creating foreign key on [EntidadAfectada3_Id] in table 'Reg_Det'
ALTER TABLE [LGP].[Reg_Det]
ADD CONSTRAINT [FK_PersonaReg_Det2]
    FOREIGN KEY ([EntidadAfectada3_Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonaReg_Det2'
CREATE INDEX [IX_FK_PersonaReg_Det2]
ON [LGP].[Reg_Det]
    ([EntidadAfectada3_Id]);
GO

-- Creating foreign key on [Id] in table 'EB_Entidad'
ALTER TABLE [LGP].[EB_Entidad]
ADD CONSTRAINT [FK_Entidad_inherits_EB]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Usuario'
ALTER TABLE [LGP].[EB_Usuario]
ADD CONSTRAINT [FK_Usuario_inherits_Entidad]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Entidad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Persona'
ALTER TABLE [LGP].[EB_Persona]
ADD CONSTRAINT [FK_Persona_inherits_Entidad]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Entidad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Concepto'
ALTER TABLE [LGP].[EB_Concepto]
ADD CONSTRAINT [FK_Concepto_inherits_EB]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Cliente'
ALTER TABLE [LGP].[EB_Cliente]
ADD CONSTRAINT [FK_Cliente_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Empleado'
ALTER TABLE [LGP].[EB_Empleado]
ADD CONSTRAINT [FK_Empleado_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Vehiculo'
ALTER TABLE [LGP].[EB_Vehiculo]
ADD CONSTRAINT [FK_Vehiculo_inherits_Entidad]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Entidad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Cochera'
ALTER TABLE [LGP].[EB_Cochera]
ADD CONSTRAINT [FK_Cochera_inherits_Entidad]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Entidad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'EB_Empresa'
ALTER TABLE [LGP].[EB_Empresa]
ADD CONSTRAINT [FK_Empresa_inherits_Persona]
    FOREIGN KEY ([Id])
    REFERENCES [LGP].[EB_Persona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------