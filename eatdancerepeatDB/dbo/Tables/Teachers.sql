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
/****** Object:  ForeignKey [FK_Teachers_Users]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Teachers]  WITH CHECK ADD  CONSTRAINT [FK_Teachers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO

ALTER TABLE [dbo].[Teachers] CHECK CONSTRAINT [FK_Teachers_Users]
GO
/****** Object:  Default [DF_Teachers_Experience]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Teachers] ADD  CONSTRAINT [DF_Teachers_Experience]  DEFAULT ((0)) FOR [Experience]