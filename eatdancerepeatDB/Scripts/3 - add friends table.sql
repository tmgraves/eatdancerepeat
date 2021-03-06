CREATE TABLE [dbo].[Friendships](
	[FriendshipID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FriendUserID] [int] NOT NULL,
	[FriendStatus] [int] NULL,
 CONSTRAINT [PK_Friendships] PRIMARY KEY CLUSTERED 
(
	[FriendshipID] ASC
)
)
GO
/****** Object:  ForeignKey [FK_Friendships_Users]    Script Date: 06/27/2014 20:21:56 ******/
ALTER TABLE [dbo].[Friendships]  WITH CHECK ADD  CONSTRAINT [FK_Friendships_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
/****** Object:  ForeignKey [FK_Friendships_Users]    Script Date: 06/27/2014 20:21:56 ******/
ALTER TABLE [dbo].[Friendships]  WITH CHECK ADD  CONSTRAINT [FK_Friendships_Users1] FOREIGN KEY([FriendUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
