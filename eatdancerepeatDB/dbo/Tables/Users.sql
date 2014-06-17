CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JoinDate] [date] NOT NULL,
	[Teacher] [bit] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  Default [DF_Users_JoinDate]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]
GO
/****** Object:  Default [DF_Users_Teacher]    Script Date: 06/17/2014 02:51:17 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Teacher]  DEFAULT ((0)) FOR [Teacher]