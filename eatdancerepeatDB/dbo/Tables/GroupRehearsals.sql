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