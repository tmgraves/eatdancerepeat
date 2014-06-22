CREATE TABLE [dbo].[GroupEvents](
	[GroupEventID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[EventID] [int] NOT NULL,
 CONSTRAINT [PK_GroupEvents] PRIMARY KEY CLUSTERED 
(
	[GroupEventID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_GroupEvents_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupEvents]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvents_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[GroupEvents] CHECK CONSTRAINT [FK_GroupEvents_Events]
GO
/****** Object:  ForeignKey [FK_GroupEvents_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupEvents]  WITH CHECK ADD  CONSTRAINT [FK_GroupEvents_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[GroupEvents] CHECK CONSTRAINT [FK_GroupEvents_Groups]