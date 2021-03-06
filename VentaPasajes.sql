create database [VentaPasajes]
go
USE [VentaPasajes]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 19/04/2017 03:13:41 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[PrimerNombre] [varchar](50) NOT NULL,
	[SegundoNombre] [varchar](50) NOT NULL,
	[ApellidoPaterno] [varchar](50) NOT NULL,
	[ApellidoMaterno] [varchar](50) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 19/04/2017 03:13:41 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[idPersona] [int] NOT NULL,
	[NombreUsuario] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

GO
INSERT [dbo].[Persona] ([idPersona], [PrimerNombre], [SegundoNombre], [ApellidoPaterno], [ApellidoMaterno], [DNI]) VALUES (1, N'Juan', N'Carlos', N'PErez', N'Rodriguez', N'12212121')
GO
INSERT [dbo].[Persona] ([idPersona], [PrimerNombre], [SegundoNombre], [ApellidoPaterno], [ApellidoMaterno], [DNI]) VALUES (2, N'Jose', N'Luis', N'Rodriguez', N'Perez', N'32323232')
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

GO
INSERT [dbo].[Usuario] ([idUsuario], [idPersona], [NombreUsuario], [Password], [Activo]) VALUES (1, 1, N'JPerez', N'123123', 1)
GO
INSERT [dbo].[Usuario] ([idUsuario], [idPersona], [NombreUsuario], [Password], [Activo]) VALUES (2, 2, N'JRodriguez', N'123456', 0)
GO
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Persona]
GO

select * from Usuario
go
select * from Persona


create procedure spVerificarAcceso
@prmstrUsuario varchar(20),
@prmstrPassword varchar(20)
as 
BEGIN
select u.idUsuario,u.NombreUsuario,u.Activo,p.idPersona,p.PrimerNombre,p.SegundoNombre,p.ApellidoPaterno,p.ApellidoMaterno,p.DNI
from Usuario u inner join Persona p on u.idPersona=p.idPersona where u.NombreUsuario= @prmstrUsuario and u.[Password]=@prmstrPassword
END

spVerificarAcceso 'jperez','123123'