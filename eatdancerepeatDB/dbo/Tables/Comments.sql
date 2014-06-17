CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PlaceID] [int] NULL,
	[EventID] [int] NULL,
	[TeamID] [int] NULL,
	[PictureID] [int] NULL,
	[VideoID] [int] NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CommentDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Comments_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Events]
GO
/****** Object:  ForeignKey [FK_Comments_Pictures]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Pictures] FOREIGN KEY([PictureID])
REFERENCES [dbo].[Pictures] ([PictureID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Pictures]
GO
/****** Object:  ForeignKey [FK_Comments_Places]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Places]
GO
/****** Object:  ForeignKey [FK_Comments_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Teams]
GO
/****** Object:  ForeignKey [FK_Comments_Users]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
/****** Object:  ForeignKey [FK_Comments_Videos]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Videos] FOREIGN KEY([VideoID])
REFERENCES [dbo].[Videos] ([VideoID])
GO

ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Videos]
GO
/****** Object:  Default [DF_Comments_CommentDateTime]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_CommentDateTime]  DEFAULT (getdate()) FOR [CommentDateTime]