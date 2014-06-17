CREATE TABLE [dbo].[Pictures](
	[PictureID] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](200) NULL,
	[UserID] [int] NULL,
	[PlaceID] [int] NULL,
	[EventID] [int] NULL,
	[TeamID] [int] NULL,
	[Link] [nvarchar](2000) NULL,
	[PictureDate] [date] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[PictureID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Pictures_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Events]
GO
/****** Object:  ForeignKey [FK_Pictures_Places]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO

ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Places]
GO
/****** Object:  ForeignKey [FK_Pictures_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Teams]
GO
/****** Object:  ForeignKey [FK_Pictures_Users]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Users]
GO
/****** Object:  Default [DF_Pictures_PictureDate]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Pictures] ADD  CONSTRAINT [DF_Pictures_PictureDate]  DEFAULT (getdate()) FOR [PictureDate]