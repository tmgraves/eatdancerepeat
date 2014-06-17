CREATE TABLE [dbo].[TeamEvents](
	[TeamEventID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_TeamEvents] PRIMARY KEY CLUSTERED 
(
	[TeamEventID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_TeamEvents_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamEvents]  WITH CHECK ADD  CONSTRAINT [FK_TeamEvents_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[TeamEvents] CHECK CONSTRAINT [FK_TeamEvents_Events]
GO
/****** Object:  ForeignKey [FK_TeamEvents_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamEvents]  WITH CHECK ADD  CONSTRAINT [FK_TeamEvents_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[TeamEvents] CHECK CONSTRAINT [FK_TeamEvents_Teams]