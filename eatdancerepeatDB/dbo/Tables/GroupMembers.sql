CREATE TABLE [dbo].[GroupMembers](
	[GroupMemberID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[JoinDate] [date] NOT NULL,
	[Admin] [bit] NOT NULL,
 CONSTRAINT [PK_GroupMembers] PRIMARY KEY CLUSTERED 
(
	[GroupMemberID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_GroupMembers_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers]  WITH CHECK ADD  CONSTRAINT [FK_GroupMembers_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[GroupMembers] CHECK CONSTRAINT [FK_GroupMembers_Groups]
GO
/****** Object:  ForeignKey [FK_GroupMembers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers]  WITH CHECK ADD  CONSTRAINT [FK_GroupMembers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[GroupMembers] CHECK CONSTRAINT [FK_GroupMembers_Users]
GO
/****** Object:  Default [DF_GroupMembers_JoinDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers] ADD  CONSTRAINT [DF_GroupMembers_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_GroupMembers_Admin]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers] ADD  CONSTRAINT [DF_GroupMembers_Admin]  DEFAULT ((0)) FOR [Admin]