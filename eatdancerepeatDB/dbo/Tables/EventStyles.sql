CREATE TABLE [dbo].[EventStyles](
	[EventStyleID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[StyleID] [int] NOT NULL,
 CONSTRAINT [PK_EventStyles] PRIMARY KEY CLUSTERED 
(
	[EventStyleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_EventStyles_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventStyles]  WITH CHECK ADD  CONSTRAINT [FK_EventStyles_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[EventStyles] CHECK CONSTRAINT [FK_EventStyles_Events]
GO
/****** Object:  ForeignKey [FK_EventStyles_Styles]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventStyles]  WITH CHECK ADD  CONSTRAINT [FK_EventStyles_Styles] FOREIGN KEY([StyleID])
REFERENCES [dbo].[Styles] ([StyleID])
GO

ALTER TABLE [dbo].[EventStyles] CHECK CONSTRAINT [FK_EventStyles_Styles]