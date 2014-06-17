CREATE TABLE [dbo].[TeamMembers](
	[TeamMemberID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[JoinDate] [date] NOT NULL,
	[Coach] [bit] NOT NULL,
 CONSTRAINT [PK_TeamMembers] PRIMARY KEY CLUSTERED 
(
	[TeamMemberID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_TeamMembers_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Teams]
GO
/****** Object:  ForeignKey [FK_TeamMembers_Users]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamMembers]  WITH CHECK ADD  CONSTRAINT [FK_TeamMembers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[TeamMembers] CHECK CONSTRAINT [FK_TeamMembers_Users]
GO
/****** Object:  Default [DF_TeamMembers_JoinDate]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamMembers] ADD  CONSTRAINT [DF_TeamMembers_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_TeamMembers_Coach]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[TeamMembers] ADD  CONSTRAINT [DF_TeamMembers_Coach]  DEFAULT ((0)) FOR [Coach]