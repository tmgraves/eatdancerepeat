/****** Object:  Table [dbo].[Places]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Places](
	[PlaceID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceType] [varchar](50) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[Address2] [nvarchar](200) NULL,
	[City] [nvarchar](100) NULL,
	[State] [nvarchar](50) NULL,
	[Zip] [nvarchar](50) NULL,
	[Country] [varchar](50) NULL,
 CONSTRAINT [PK_Places] PRIMARY KEY CLUSTERED 
(
	[PlaceID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Users]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JoinDate] [date] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupType] [varchar](50) NOT NULL,
	[GroupName] [nvarchar](200) NOT NULL,
	[GroupDescription] [nvarchar](max) NULL,
	[SkillLevel] [int] NOT NULL,
	[FacebookLink] [nvarchar](2000) NULL,
	[Public] [bit] NOT NULL,
	[ParentGroupID] [int] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Styles]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Styles](
	[StyleID] [int] IDENTITY(1,1) NOT NULL,
	[Style] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Styles] PRIMARY KEY CLUSTERED 
(
	[StyleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[GroupStyles]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Dancers]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dancers](
	[UserID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_Dancers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Events]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[EventID] [int] IDENTITY(1,1) NOT NULL,
	[EventType] [nvarchar](50) NOT NULL,
	[EventName] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[AllDay] [bit] NOT NULL,
	[Link] [varchar](2000) NULL,
	[Cost] [money] NULL,
	[LocationType] [varchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Address2] [nvarchar](200) NULL,
	[City] [nvarchar](200) NULL,
	[State] [nvarchar](200) NULL,
	[Zip] [varchar](50) NULL,
	[Country] [varchar](100) NULL,
	[ParentEventID] [int] NULL,
	[Frequency] [int] NULL,
	[DaysOfWeek] [varchar](200) NULL,
	[GroupID] [int] NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[GroupRehearsals]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupRehearsals](
	[GroupRehearsalID] [int] IDENTITY(1,1) NOT NULL,
	[GroupID] [int] NOT NULL,
	[PlaceID] [int] NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_GroupRehearsals] PRIMARY KEY CLUSTERED 
(
	[GroupRehearsalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[GroupMembers]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Teachers]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[UserID] [int] NOT NULL,
	[Experience] [int] NOT NULL,
	[Resume] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[PictureID] [int] IDENTITY(1,1) NOT NULL,
	[PictureName] [nvarchar](200) NULL,
	[PostUserID] [int] NOT NULL,
	[UserID] [int] NULL,
	[PlaceID] [int] NULL,
	[EventID] [int] NULL,
	[GroupID] [int] NULL,
	[Link] [nvarchar](2000) NULL,
	[PictureDate] [date] NOT NULL,
 CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED 
(
	[PictureID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[GroupEvents]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[EventStyles]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[EventMembers]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Reviews]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  Table [dbo].[Videos]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Videos](
	[VideoID] [int] IDENTITY(1,1) NOT NULL,
	[VideoName] [nvarchar](200) NOT NULL,
	[Link] [nvarchar](2000) NOT NULL,
	[PlaceID] [int] NULL,
	[UserID] [int] NULL,
	[EventID] [int] NULL,
	[GroupID] [int] NULL,
	[StyleID] [int] NULL,
	[VideoDate] [date] NOT NULL,
 CONSTRAINT [PK_Videos] PRIMARY KEY CLUSTERED 
(
	[VideoID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 06/21/2014 22:12:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PlaceID] [int] NULL,
	[EventID] [int] NULL,
	[GroupID] [int] NULL,
	[PictureID] [int] NULL,
	[VideoID] [int] NULL,
	[StyleID] [int] NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[CommentDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Default [DF_Comments_CommentDateTime]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_CommentDateTime]  DEFAULT (getdate()) FOR [CommentDateTime]
GO
/****** Object:  Default [DF_EventMembers_Organizer]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventMembers] ADD  CONSTRAINT [DF_EventMembers_Organizer]  DEFAULT ((0)) FOR [Organizer]
GO
/****** Object:  Default [DF_EventMembers_JoinDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventMembers] ADD  CONSTRAINT [DF_EventMembers_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_Events_AllDay]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_AllDay]  DEFAULT ((0)) FOR [AllDay]
GO
/****** Object:  Default [DF_GroupMembers_JoinDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers] ADD  CONSTRAINT [DF_GroupMembers_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_GroupMembers_Admin]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupMembers] ADD  CONSTRAINT [DF_GroupMembers_Admin]  DEFAULT ((0)) FOR [Admin]
GO
/****** Object:  Default [DF_Groups_SkillLevel]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_SkillLevel]  DEFAULT ((1)) FOR [SkillLevel]
GO
/****** Object:  Default [DF_Groups_Public]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_Public]  DEFAULT ((1)) FOR [Public]
GO
/****** Object:  Default [DF_Pictures_PictureDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures] ADD  CONSTRAINT [DF_Pictures_PictureDate]  DEFAULT (getdate()) FOR [PictureDate]
GO
/****** Object:  Default [DF_Teachers_Experience]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF_Teachers_Experience]  DEFAULT ((0)) FOR [Experience]
GO
/****** Object:  Default [DF_Users_JoinDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_Videos_VideoDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos] ADD  CONSTRAINT [DF_Videos_VideoDate]  DEFAULT (getdate()) FOR [VideoDate]
GO
/****** Object:  ForeignKey [FK_Comments_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Events]
GO
/****** Object:  ForeignKey [FK_Comments_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Groups]
GO
/****** Object:  ForeignKey [FK_Comments_Pictures]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Pictures] FOREIGN KEY([PictureID])
REFERENCES [dbo].[Pictures] ([PictureID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Pictures]
GO
/****** Object:  ForeignKey [FK_Comments_Places]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Places]
GO
/****** Object:  ForeignKey [FK_Comments_Styles]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Styles] FOREIGN KEY([StyleID])
REFERENCES [dbo].[Styles] ([StyleID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Styles]
GO
/****** Object:  ForeignKey [FK_Comments_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
/****** Object:  ForeignKey [FK_Comments_Videos]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Videos] FOREIGN KEY([VideoID])
REFERENCES [dbo].[Videos] ([VideoID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Videos]
GO
/****** Object:  ForeignKey [FK_Dancers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Dancers]  WITH CHECK ADD  CONSTRAINT [FK_Dancers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Dancers] CHECK CONSTRAINT [FK_Dancers_Users]
GO
/****** Object:  ForeignKey [FK_EventMembers_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventMembers]  WITH CHECK ADD  CONSTRAINT [FK_EventMembers_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[EventMembers] CHECK CONSTRAINT [FK_EventMembers_Events]
GO
/****** Object:  ForeignKey [FK_EventMembers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[EventMembers]  WITH CHECK ADD  CONSTRAINT [FK_EventMembers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[EventMembers] CHECK CONSTRAINT [FK_EventMembers_Users]
GO
/****** Object:  ForeignKey [FK_Events_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Events] FOREIGN KEY([ParentEventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Events]
GO
/****** Object:  ForeignKey [FK_Events_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Groups]
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
/****** Object:  ForeignKey [FK_GroupRehearsals_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupRehearsals]  WITH CHECK ADD  CONSTRAINT [FK_GroupRehearsals_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[GroupRehearsals] CHECK CONSTRAINT [FK_GroupRehearsals_Groups]
GO
/****** Object:  ForeignKey [FK_GroupRehearsals_Places]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[GroupRehearsals]  WITH CHECK ADD  CONSTRAINT [FK_GroupRehearsals_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO
ALTER TABLE [dbo].[GroupRehearsals] CHECK CONSTRAINT [FK_GroupRehearsals_Places]
GO
/****** Object:  ForeignKey [FK_Groups_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Groups] FOREIGN KEY([ParentGroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Groups]
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
GO
/****** Object:  ForeignKey [FK_Pictures_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Events]
GO
/****** Object:  ForeignKey [FK_Pictures_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Groups]
GO
/****** Object:  ForeignKey [FK_Pictures_Places]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Places]
GO
/****** Object:  ForeignKey [FK_Pictures_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Users]
GO
/****** Object:  ForeignKey [FK_Pictures_Users1]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Users1] FOREIGN KEY([PostUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Users1]
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
GO
/****** Object:  ForeignKey [FK_Teachers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Users]
GO
/****** Object:  ForeignKey [FK_Videos_Events]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Events] FOREIGN KEY([EventID])
REFERENCES [dbo].[Events] ([EventID])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Events]
GO
/****** Object:  ForeignKey [FK_Videos_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Groups] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Groups]
GO
/****** Object:  ForeignKey [FK_Videos_Places]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Places]
GO
/****** Object:  ForeignKey [FK_Videos_Styles]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Styles] FOREIGN KEY([StyleID])
REFERENCES [dbo].[Styles] ([StyleID])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Styles]
GO
/****** Object:  ForeignKey [FK_Videos_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Videos]  WITH CHECK ADD  CONSTRAINT [FK_Videos_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Videos] CHECK CONSTRAINT [FK_Videos_Users]
GO
