USE <<Your database name>>

CREATE TABLE [dbo].[ParkingAreas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParkingAreaTypeId] [int] NOT NULL,
	[ParkingAreaName] [nvarchar](50) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[DateCreated] [nvarchar](50) NOT NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_ParkingAreas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingAreaTypes]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingAreaTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParkingAreaTypeDescription] [nvarchar](50) NOT NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_ParkingAreaTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParkingPermits]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParkingPermits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParkingAreaId] [int] NOT NULL,
	[EffectiveDate] [datetime] NOT NULL,
	[ExpirationDate] [datetime] NOT NULL,
	[LicensePlate] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[Inactive] [bit] NOT NULL,
 CONSTRAINT [PK_ParkingPermit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[v_ParkingAreas]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ParkingAreas]
AS
SELECT dbo.ParkingAreas.Id AS ParkingAreaID, dbo.ParkingAreas.ParkingAreaName, dbo.ParkingAreas.Latitude, dbo.ParkingAreas.Longitude, dbo.ParkingAreaTypes.ParkingAreaTypeDescription AS AreaDescription
FROM     dbo.ParkingAreas INNER JOIN
                  dbo.ParkingAreaTypes ON dbo.ParkingAreas.ParkingAreaTypeId = dbo.ParkingAreaTypes.Id

GO
/****** Object:  View [dbo].[v_ParkingPermits_by_Area]******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ParkingPermits_by_Area]
AS
SELECT dbo.ParkingPermits.Id AS PermitID, dbo.ParkingPermits.LicensePlate, dbo.ParkingPermits.EffectiveDate, dbo.ParkingPermits.ExpirationDate, dbo.ParkingAreas.ParkingAreaName
FROM     dbo.ParkingAreas INNER JOIN
                  dbo.ParkingAreaTypes ON dbo.ParkingAreas.ParkingAreaTypeId = dbo.ParkingAreaTypes.Id INNER JOIN
                  dbo.ParkingPermits ON dbo.ParkingAreas.Id = dbo.ParkingPermits.ParkingAreaId

GO
SET IDENTITY_INSERT [dbo].[ParkingAreas] ON 

INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (1, 1, N'Flamingo', 25.779575, -80.135651, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (2, 1, N'Belle Isle', 25.79082, -80.148139, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (3, 1, N'South Pointe', 25.768097, -80.135565, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (4, 1, N'Art Deco', 25.769016, -80.13226, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (5, 1, N'West Avenue', 25.779266, -80.140972, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (6, 2, N'17th Street Garage', 25.791915, -80.135436, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (7, 2, N'42nd Street Garage', 25.814085, -80.127872, N'5/31/2024', 0)
INSERT [dbo].[ParkingAreas] ([Id], [ParkingAreaTypeId], [ParkingAreaName], [Latitude], [Longitude], [DateCreated], [Inactive]) VALUES (8, 2, N'Fifth and Alton Garage', 25.775011, -80.140114, N'5/31/2024', 0)
SET IDENTITY_INSERT [dbo].[ParkingAreas] OFF
SET IDENTITY_INSERT [dbo].[ParkingAreaTypes] ON 

INSERT [dbo].[ParkingAreaTypes] ([Id], [ParkingAreaTypeDescription], [Inactive]) VALUES (1, N'Residential', 0)
INSERT [dbo].[ParkingAreaTypes] ([Id], [ParkingAreaTypeDescription], [Inactive]) VALUES (2, N'Garage', 0)
SET IDENTITY_INSERT [dbo].[ParkingAreaTypes] OFF
SET IDENTITY_INSERT [dbo].[ParkingPermits] ON 

INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (1, 1, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2024-12-31 00:00:00.000' AS DateTime), N'ABC123', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (2, 1, CAST(N'2024-05-01 00:00:00.000' AS DateTime), CAST(N'2024-12-31 00:00:00.000' AS DateTime), N'ABC345', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (4, 1, CAST(N'2024-05-01 00:00:00.000' AS DateTime), CAST(N'2024-12-31 00:00:00.000' AS DateTime), N'ABC567', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (6, 2, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2024-12-31 00:00:00.000' AS DateTime), N'ABC789', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (8, 3, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'EFG123', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (9, 3, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'EFG345', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (10, 4, CAST(N'2024-05-01 00:00:00.000' AS DateTime), CAST(N'2025-05-31 00:00:00.000' AS DateTime), N'EFG567', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (11, 5, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'EFG789', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (12, 5, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'HIJ123', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (13, 5, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'HIJ345', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (14, 6, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'HIJ567', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (15, 6, CAST(N'2024-07-01 00:00:00.000' AS DateTime), CAST(N'2025-07-31 00:00:00.000' AS DateTime), N'HIJ789', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (16, 6, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'KLM123', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (17, 7, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'KLM345', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (18, 7, CAST(N'2024-07-01 00:00:00.000' AS DateTime), CAST(N'2025-07-31 00:00:00.000' AS DateTime), N'KJM567', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (19, 8, CAST(N'2024-06-01 00:00:00.000' AS DateTime), CAST(N'2025-06-30 00:00:00.000' AS DateTime), N'KLM789', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[ParkingPermits] ([Id], [ParkingAreaId], [EffectiveDate], [ExpirationDate], [LicensePlate], [DateCreated], [Inactive]) VALUES (20, 8, CAST(N'2024-07-01 00:00:00.000' AS DateTime), CAST(N'2025-07-31 00:00:00.000' AS DateTime), N'NOP123', CAST(N'2024-05-01 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[ParkingPermits] OFF
ALTER TABLE [dbo].[ParkingAreas] ADD  CONSTRAINT [DF_ParkingAreas_IsDeleted]  DEFAULT ((0)) FOR [Inactive]
GO
ALTER TABLE [dbo].[ParkingAreaTypes] ADD  CONSTRAINT [DF_ParkingAreaTypes_Inactive]  DEFAULT ((0)) FOR [Inactive]
GO
ALTER TABLE [dbo].[ParkingAreas]  WITH CHECK ADD  CONSTRAINT [FK_ParkingAreas_ParkingAreaTypes] FOREIGN KEY([ParkingAreaTypeId])
REFERENCES [dbo].[ParkingAreaTypes] ([Id])
GO
ALTER TABLE [dbo].[ParkingAreas] CHECK CONSTRAINT [FK_ParkingAreas_ParkingAreaTypes]
GO
ALTER TABLE [dbo].[ParkingPermits]  WITH CHECK ADD  CONSTRAINT [FK_ParkingPermits_ParkingAreas] FOREIGN KEY([ParkingAreaId])
REFERENCES [dbo].[ParkingAreas] ([Id])
GO
ALTER TABLE [dbo].[ParkingPermits] CHECK CONSTRAINT [FK_ParkingPermits_ParkingAreas]
GO