CREATE TABLE [dbo].[Reviews](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[AuthorUserID] [int] NOT NULL,
	[Review] [nvarchar](max) NOT NULL,
	[ReviewDate] [datetime] NOT NULL,
	[Stars] [float] NOT NULL,
	[EventID] [int] NULL,
	[UserID] [int] NULL,
	[PlaceID] [int] NULL,
	[GroupID] [int] NULL,
	[StyleID] [int] NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Reviews_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Events]
GO
/****** Object:  ForeignKey [FK_Reviews_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Groups]
GO
/****** Object:  ForeignKey [FK_Reviews_Places]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Places]
GO
/****** Object:  ForeignKey [FK_Reviews_Styles]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Styles] FOREIGN KEY([StyleID])
REFERENCES [dbo].[Styles] ([StyleID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Styles]
GO
/****** Object:  ForeignKey [FK_Reviews_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users] FOREIGN KEY([AuthorUserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users]
GO
/****** Object:  ForeignKey [FK_Reviews_Users1]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Users1] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Users1]