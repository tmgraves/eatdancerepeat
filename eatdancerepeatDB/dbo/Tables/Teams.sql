CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](200) NOT NULL,
	[Style] [varchar](50) NOT NULL,
	[SkillLevel] [varchar](50) NOT NULL,
	[Open] [bit] NOT NULL,
	[Public] [bit] NOT NULL,
	[ParentTeamID] [int] NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Teams_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Teams] FOREIGN KEY([ParentTeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Teams]
GO
/****** Object:  Default [DF_Teams_Open]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Teams] ADD  CONSTRAINT [DF_Teams_Open]  DEFAULT ((0)) FOR [Open]
GO
/****** Object:  Default [DF_Teams_Public]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Teams] ADD  CONSTRAINT [DF_Teams_Public]  DEFAULT ((0)) FOR [Public]