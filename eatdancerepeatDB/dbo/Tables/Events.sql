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
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[EventID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Events_Events]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Events] FOREIGN KEY([ParentEventID])
REFERENCES [dbo].[Events] ([EventID])
GO

ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Events]
GO
/****** Object:  Default [DF_Events_AllDay]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Events] ADD  CONSTRAINT [DF_Events_AllDay]  DEFAULT ((0)) FOR [AllDay]