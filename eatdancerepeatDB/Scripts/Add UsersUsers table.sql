/****** Object:  Table [dbo].[UsersUsers]    Script Date: 06/25/2014 18:39:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersUsers](
	[UserUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LinkUserID] [int] NOT NULL,
	[LinkStatus] [int] NULL,
	[LinkDate] [date] NOT NULL,
 CONSTRAINT [PK_UsersUsers] PRIMARY KEY CLUSTERED 
(
	[UserUserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Default [DF_UsersUsers_LinkDate]    Script Date: 06/25/2014 18:39:46 ******/
ALTER TABLE [dbo].[UsersUsers] ADD  CONSTRAINT [DF_UsersUsers_LinkDate]  DEFAULT (getdate()) FOR [LinkDate]
GO
/****** Object:  ForeignKey [FK_UsersUsers_Users]    Script Date: 06/25/2014 18:39:46 ******/
ALTER TABLE [dbo].[UsersUsers]  WITH CHECK ADD  CONSTRAINT [FK_UsersUsers_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UsersUsers] CHECK CONSTRAINT [FK_UsersUsers_Users]
GO
/****** Object:  ForeignKey [FK_UsersUsers_Users1]    Script Date: 06/25/2014 18:39:46 ******/
ALTER TABLE [dbo].[UsersUsers]  WITH CHECK ADD  CONSTRAINT [FK_UsersUsers_Users1] FOREIGN KEY([LinkUserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[UsersUsers] CHECK CONSTRAINT [FK_UsersUsers_Users1]
GO
