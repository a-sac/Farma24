
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomenda_has_Produto](
	[Encomenda] [int] NOT NULL,
	[Produto] [int] NOT NULL,
	[quantidade] [int] NOT NULL,
	[custo] [float] NOT NULL,
 CONSTRAINT [PK_Encomenda_has_Produto] PRIMARY KEY CLUSTERED 
(
	[Encomenda] ASC,
	[Produto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Encomendas]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encomendas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[estado] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NULL,
	[morada] [int] NOT NULL,
	[inicio] [datetime] NOT NULL,
	[fim] [datetime] NULL,
	[custoTotal] [float] NOT NULL,
	[detalhes] [nvarchar](600) NULL,
	[Fatura_referencia] [int] NULL,
 CONSTRAINT [PK_Encomendas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Faturas]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faturas](
	[referencia] [int] NOT NULL,
	[metodoPagamento] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Faturas] PRIMARY KEY CLUSTERED 
(
	[referencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Moradas]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Moradas](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cidade] [nvarchar](50) NOT NULL,
	[codPostal] [nvarchar](50) NOT NULL,
	[rua] [nvarchar](50) NOT NULL,
	[porta] [nvarchar](20) NOT NULL,
	[Utilizador_email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Moradas] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produtoes]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produtoes](
	[codBarras] [int] NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[categoria] [nvarchar](50) NOT NULL,
	[preco] [float] NOT NULL,
	[descricao] [nvarchar](600) NOT NULL,
	[imagem] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Produtoes] PRIMARY KEY CLUSTERED 
(
	[codBarras] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sysdiagrams]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sysdiagrams](
	[name] [nvarchar](128) NOT NULL,
	[principal_id] [int] NOT NULL,
	[diagram_id] [int] IDENTITY(1,1) NOT NULL,
	[version] [int] NULL,
	[definition] [varbinary](max) NULL,
 CONSTRAINT [PK_sysdiagrams] PRIMARY KEY CLUSTERED 
(
	[diagram_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilizadors]    Script Date: 5/13/2018 7:35:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilizadors](
	[email] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NOT NULL,
	[nome] [nvarchar](50) NOT NULL,
	[iban] [int] NULL,
	[contacto] [int] NULL,
	[role] [nvarchar](60) NOT NULL,
 CONSTRAINT [PK_Utilizadors] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Encomenda_has_Produto]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_has_Produto_Encomenda] FOREIGN KEY([Encomenda])
REFERENCES [dbo].[Encomendas] ([id])
GO
ALTER TABLE [dbo].[Encomenda_has_Produto] CHECK CONSTRAINT [FK_Encomenda_has_Produto_Encomenda]
GO
ALTER TABLE [dbo].[Encomenda_has_Produto]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_has_Produto_Produto] FOREIGN KEY([Produto])
REFERENCES [dbo].[Produtoes] ([codBarras])
GO
ALTER TABLE [dbo].[Encomenda_has_Produto] CHECK CONSTRAINT [FK_Encomenda_has_Produto_Produto]
GO
ALTER TABLE [dbo].[Encomendas]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Fatura] FOREIGN KEY([Fatura_referencia])
REFERENCES [dbo].[Faturas] ([referencia])
GO
ALTER TABLE [dbo].[Encomendas] CHECK CONSTRAINT [FK_Encomenda_Fatura]
GO
ALTER TABLE [dbo].[Encomendas]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Morada] FOREIGN KEY([morada])
REFERENCES [dbo].[Moradas] ([id])
GO
ALTER TABLE [dbo].[Encomendas] CHECK CONSTRAINT [FK_Encomenda_Morada]
GO
ALTER TABLE [dbo].[Encomendas]  WITH CHECK ADD  CONSTRAINT [FK_Encomenda_Utilizador] FOREIGN KEY([email])
REFERENCES [dbo].[Utilizadors] ([email])
GO
ALTER TABLE [dbo].[Encomendas] CHECK CONSTRAINT [FK_Encomenda_Utilizador]
GO
ALTER TABLE [dbo].[Moradas]  WITH CHECK ADD  CONSTRAINT [FK_Morada_Utilizador] FOREIGN KEY([Utilizador_email])
REFERENCES [dbo].[Utilizadors] ([email])
GO
ALTER TABLE [dbo].[Moradas] CHECK CONSTRAINT [FK_Morada_Utilizador]
GO

