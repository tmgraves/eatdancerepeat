CREATE TABLE [dbo].[Promoters](
	[UserID] [int] NOT NULL,
	[ContactEmail] [varchar](200) NOT NULL,
	[Website] [varchar](2000) NOT NULL,
	[FacebookPage] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Promoters] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)
)
GO
/****** Object:  ForeignKey [FK_Promoters_Users]    Script Date: 06/27/2014 20:21:56 ******/
ALTER TABLE [dbo].[Promoters]  WITH CHECK ADD  CONSTRAINT [FK_Promoters_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Promoters] CHECK CONSTRAINT [FK_Promoters_Users]
GO