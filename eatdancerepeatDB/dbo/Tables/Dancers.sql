CREATE TABLE [dbo].[Dancers](
	[UserID] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_Dancers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Dancers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Dancers]  WITH CHECK ADD  CONSTRAINT [FK_Dancers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Dancers] CHECK CONSTRAINT [FK_Dancers_Users]