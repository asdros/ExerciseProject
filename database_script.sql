CREATE DATABASE [Subtitles_manager]
GO
USE [Subtitles_manager]
GO
/****** Object:  Table [dbo].[Director]    Script Date: 17.06.2021 20:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Director](
	[Id] [uniqueidentifier] NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 17.06.2021 20:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[YearOfProduction] [int] NOT NULL,
	[OriginalSoundtrack] [nvarchar](20) NOT NULL,
	[Genre] [nvarchar](20) NOT NULL,
	[DirectorID] [uniqueidentifier] NOT NULL,
	[Description] [nvarchar](2000) NULL,
	[OtherTitles] [nvarchar](100) NULL,
	[CreatedAt] [datetime] NOT NULL,
	[PosterId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__Movie__3214EC0773F5C48A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subtitles]    Script Date: 17.06.2021 20:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subtitles](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[Language] [nvarchar](50) NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
	[AddedOn] [datetime] NOT NULL,
	[SubtitlesFileId] [uniqueidentifier] NULL,
 CONSTRAINT [PK__Subtitle__3214EC07186D079E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadedFile]    Script Date: 17.06.2021 20:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadedFile](
	[IdFile] [uniqueidentifier] NOT NULL,
	[Filename] [nvarchar](100) NOT NULL,
	[FileData] [varchar](max) NULL,
 CONSTRAINT [PK_File] PRIMARY KEY CLUSTERED 
(
	[IdFile] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Director] ADD  CONSTRAINT [DF_Director_Id]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Movie] ADD  CONSTRAINT [DF__Movie__Id__6FE99F9F]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[Subtitles] ADD  CONSTRAINT [DF__Subtitles__Id__70DDC3D8]  DEFAULT (newid()) FOR [Id]
GO
ALTER TABLE [dbo].[UploadedFile] ADD  CONSTRAINT [DF__File__Id__6EF57B66]  DEFAULT (newid()) FOR [IdFile]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Director] FOREIGN KEY([DirectorID])
REFERENCES [dbo].[Director] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Director]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_File] FOREIGN KEY([PosterId])
REFERENCES [dbo].[UploadedFile] ([IdFile])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_File]
GO
ALTER TABLE [dbo].[Subtitles]  WITH CHECK ADD  CONSTRAINT [FK_Subtitles_File] FOREIGN KEY([SubtitlesFileId])
REFERENCES [dbo].[UploadedFile] ([IdFile])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subtitles] CHECK CONSTRAINT [FK_Subtitles_File]
GO
ALTER TABLE [dbo].[Subtitles]  WITH CHECK ADD  CONSTRAINT [FK_Subtitles_Movie] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movie] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Subtitles] CHECK CONSTRAINT [FK_Subtitles_Movie]
GO
