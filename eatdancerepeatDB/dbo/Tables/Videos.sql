CREATE TABLE [dbo].[Videos](
	[VideoID] [int] IDENTITY(1,1) NOT NULL,
	[VideoName] [nvarchar](200) NOT NULL,
	[Link] [nvarchar](2000) NOT NULL,
	[PlaceID] [int] NULL,
	[UserID] [int] NULL,
	[EventID] [int] NULL,
	[TeamID] [int] NULL,
	[VideoDate] [date] NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[VideoID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Videos_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Events]
GO
/****** Object:  ForeignKey [FK_Videos_Places]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO

ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Places]
GO
/****** Object:  ForeignKey [FK_Videos_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Teams]
GO
/****** Object:  ForeignKey [FK_Videos_Users]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Users]
GO
/****** Object:  Default [DF_Videos_VideoDate]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Videos] ADD  CONSTRAINT [DF_Videos_VideoDate]  DEFAULT (getdate()) FOR [VideoDate]