
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/10/2018 23:45:31
-- Generated from EDMX file: C:\Users\sergi\OneDrive\Documentos\Farma24\Farma24\Farma24.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Farma24DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Encomenda_Fatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encomendas] DROP CONSTRAINT [FK_Encomenda_Fatura];
GO
IF OBJECT_ID(N'[dbo].[FK_Encomenda_has_Produto_Encomenda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encomenda_has_Produto] DROP CONSTRAINT [FK_Encomenda_has_Produto_Encomenda];
GO
IF OBJECT_ID(N'[dbo].[FK_Encomenda_has_Produto_Produto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encomenda_has_Produto] DROP CONSTRAINT [FK_Encomenda_has_Produto_Produto];
GO
IF OBJECT_ID(N'[dbo].[FK_Encomenda_Morada]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encomendas] DROP CONSTRAINT [FK_Encomenda_Morada];
GO
IF OBJECT_ID(N'[dbo].[FK_Encomenda_Utilizador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Encomendas] DROP CONSTRAINT [FK_Encomenda_Utilizador];
GO
IF OBJECT_ID(N'[dbo].[FK_Morada_Utilizador]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Moradas] DROP CONSTRAINT [FK_Morada_Utilizador];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Encomenda_has_Produto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Encomenda_has_Produto];
GO
IF OBJECT_ID(N'[dbo].[Encomendas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Encomendas];
GO
IF OBJECT_ID(N'[dbo].[Faturas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faturas];
GO
IF OBJECT_ID(N'[dbo].[Moradas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Moradas];
GO
IF OBJECT_ID(N'[dbo].[Produtoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Produtoes];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Utilizadors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Utilizadors];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Encomendas'
CREATE TABLE [dbo].[Encomendas] (
    [id] int  NOT NULL,
    [estado] nvarchar(50)  NOT NULL,
    [email] nvarchar(50)  NULL,
    [morada] int  NOT NULL,
    [inicio] datetime  NOT NULL,
    [fim] datetime  NULL,
    [custoTotal] float  NOT NULL,
    [detalhes] nvarchar(600)  NULL,
    [Fatura_referencia] int  NULL
);
GO

-- Creating table 'Encomenda_has_Produto'
CREATE TABLE [dbo].[Encomenda_has_Produto] (
    [Encomenda] int  NOT NULL,
    [Produto] int  NOT NULL,
    [quantidade] int  NOT NULL,
    [custo] float  NOT NULL
);
GO

-- Creating table 'Faturas'
CREATE TABLE [dbo].[Faturas] (
    [referencia] int  NOT NULL,
    [metodoPagamento] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Moradas'
CREATE TABLE [dbo].[Moradas] (
    [id] int  NOT NULL,
    [cidade] nvarchar(50)  NOT NULL,
    [codPostal] nvarchar(50)  NOT NULL,
    [rua] nvarchar(50)  NOT NULL,
    [porta] nvarchar(20)  NOT NULL,
    [Utilizador_email] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Produtoes'
CREATE TABLE [dbo].[Produtoes] (
    [codBarras] int  NOT NULL,
    [nome] nvarchar(50)  NOT NULL,
    [categoria] nvarchar(50)  NOT NULL,
    [preco] float  NOT NULL,
    [descricao] nvarchar(600)  NOT NULL,
    [imagem] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Utilizadors'
CREATE TABLE [dbo].[Utilizadors] (
    [email] nvarchar(50)  NOT NULL,
    [password] nvarchar(50)  NOT NULL,
    [nome] nvarchar(50)  NOT NULL,
    [iban] int  NULL,
    [contacto] int  NULL,
    [role] nvarchar(60)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Encomendas'
ALTER TABLE [dbo].[Encomendas]
ADD CONSTRAINT [PK_Encomendas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Encomenda], [Produto] in table 'Encomenda_has_Produto'
ALTER TABLE [dbo].[Encomenda_has_Produto]
ADD CONSTRAINT [PK_Encomenda_has_Produto]
    PRIMARY KEY CLUSTERED ([Encomenda], [Produto] ASC);
GO

-- Creating primary key on [referencia] in table 'Faturas'
ALTER TABLE [dbo].[Faturas]
ADD CONSTRAINT [PK_Faturas]
    PRIMARY KEY CLUSTERED ([referencia] ASC);
GO

-- Creating primary key on [id] in table 'Moradas'
ALTER TABLE [dbo].[Moradas]
ADD CONSTRAINT [PK_Moradas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [codBarras] in table 'Produtoes'
ALTER TABLE [dbo].[Produtoes]
ADD CONSTRAINT [PK_Produtoes]
    PRIMARY KEY CLUSTERED ([codBarras] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [email] in table 'Utilizadors'
ALTER TABLE [dbo].[Utilizadors]
ADD CONSTRAINT [PK_Utilizadors]
    PRIMARY KEY CLUSTERED ([email] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Fatura_referencia] in table 'Encomendas'
ALTER TABLE [dbo].[Encomendas]
ADD CONSTRAINT [FK_Encomenda_Fatura]
    FOREIGN KEY ([Fatura_referencia])
    REFERENCES [dbo].[Faturas]
        ([referencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Encomenda_Fatura'
CREATE INDEX [IX_FK_Encomenda_Fatura]
ON [dbo].[Encomendas]
    ([Fatura_referencia]);
GO

-- Creating foreign key on [Encomenda] in table 'Encomenda_has_Produto'
ALTER TABLE [dbo].[Encomenda_has_Produto]
ADD CONSTRAINT [FK_Encomenda_has_Produto_Encomenda]
    FOREIGN KEY ([Encomenda])
    REFERENCES [dbo].[Encomendas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [morada] in table 'Encomendas'
ALTER TABLE [dbo].[Encomendas]
ADD CONSTRAINT [FK_Encomenda_Morada]
    FOREIGN KEY ([morada])
    REFERENCES [dbo].[Moradas]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Encomenda_Morada'
CREATE INDEX [IX_FK_Encomenda_Morada]
ON [dbo].[Encomendas]
    ([morada]);
GO

-- Creating foreign key on [email] in table 'Encomendas'
ALTER TABLE [dbo].[Encomendas]
ADD CONSTRAINT [FK_Encomenda_Utilizador]
    FOREIGN KEY ([email])
    REFERENCES [dbo].[Utilizadors]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Encomenda_Utilizador'
CREATE INDEX [IX_FK_Encomenda_Utilizador]
ON [dbo].[Encomendas]
    ([email]);
GO

-- Creating foreign key on [Produto] in table 'Encomenda_has_Produto'
ALTER TABLE [dbo].[Encomenda_has_Produto]
ADD CONSTRAINT [FK_Encomenda_has_Produto_Produto]
    FOREIGN KEY ([Produto])
    REFERENCES [dbo].[Produtoes]
        ([codBarras])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Encomenda_has_Produto_Produto'
CREATE INDEX [IX_FK_Encomenda_has_Produto_Produto]
ON [dbo].[Encomenda_has_Produto]
    ([Produto]);
GO

-- Creating foreign key on [Utilizador_email] in table 'Moradas'
ALTER TABLE [dbo].[Moradas]
ADD CONSTRAINT [FK_Morada_Utilizador]
    FOREIGN KEY ([Utilizador_email])
    REFERENCES [dbo].[Utilizadors]
        ([email])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Morada_Utilizador'
CREATE INDEX [IX_FK_Morada_Utilizador]
ON [dbo].[Moradas]
    ([Utilizador_email]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------