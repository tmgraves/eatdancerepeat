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
/****** Object:  Default [DF_Users_JoinDate]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_JoinDate]  DEFAULT (getdate()) FOR [JoinDate]