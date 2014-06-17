CREATE TABLE [dbo].[Rehearsals](
	[RehearsalID] [int] IDENTITY(1,1) NOT NULL,
	[TeamID] [int] NOT NULL,
	[PlaceID] [int] NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_Rehearsals] PRIMARY KEY CLUSTERED 
(
	[RehearsalID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Rehearsals_Places]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Rehearsals]  WITH CHECK ADD  CONSTRAINT [FK_Rehearsals_Places] FOREIGN KEY([PlaceID])
REFERENCES [dbo].[Places] ([PlaceID])
GO

ALTER TABLE [dbo].[Rehearsals] CHECK CONSTRAINT [FK_Rehearsals_Places]
GO
/****** Object:  ForeignKey [FK_Rehearsals_Teams]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Rehearsals]  WITH CHECK ADD  CONSTRAINT [FK_Rehearsals_Teams] FOREIGN KEY([TeamID])
REFERENCES [dbo].[Teams] ([TeamID])
GO

ALTER TABLE [dbo].[Rehearsals] CHECK CONSTRAINT [FK_Rehearsals_Teams]