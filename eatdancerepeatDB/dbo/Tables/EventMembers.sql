CREATE TABLE [dbo].[EventMembers](
	[EventMemberID] [int] IDENTITY(1,1) NOT NULL,
	[EventID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[AttendeeStatus] [int] NOT NULL,
	[Organizer] [bit] NOT NULL,
	[JoinDate] [date] NOT NULL,
 CONSTRAINT [PK_EventMembers] PRIMARY KEY CLUSTERED 
(
	[EventMemberID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_EventMembers_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[EventMembers]  WITH CHECK ADD  CONSTRAINT [FK_EventMembers_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[EventMembers] CHECK CONSTRAINT [FK_EventMembers_Events]
GO
/****** Object:  ForeignKey [FK_EventMembers_Users]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[EventMembers]  WITH CHECK ADD  CONSTRAINT [FK_EventMembers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[EventMembers] CHECK CONSTRAINT [FK_EventMembers_Users]
GO
/****** Object:  Default [DF_EventMembers_Organizer]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[EventMembers] ADD  CONSTRAINT [DF_EventMembers_Organizer]  DEFAULT ((0)) FOR [Organizer]
GO
/****** Object:  Default [DF_EventMembers_JoinDate]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[EventMembers] ADD  CONSTRAINT [DF_EventMembers_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]