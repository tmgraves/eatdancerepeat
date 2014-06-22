CREATE TABLE [dbo].[GroupStyles](
	[GroupStyleID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[StyleID] [int] NOT NULL,
 CONSTRAINT [PK_GroupStyles] PRIMARY KEY CLUSTERED 
(
	[GroupStyleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_GroupStyles_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupStyles]  WITH CHECK ADD  CONSTRAINT [FK_GroupStyles_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[GroupStyles] CHECK CONSTRAINT [FK_GroupStyles_Groups]
GO
/****** Object:  ForeignKey [FK_GroupStyles_Styles]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupStyles]  WITH CHECK ADD  CONSTRAINT [FK_GroupStyles_Styles] FOREIGN KEY([StyleID])
REFERENCES [dbo].[Styles] ([StyleID])
GO

ALTER TABLE [dbo].[GroupStyles] CHECK CONSTRAINT [FK_GroupStyles_Styles]