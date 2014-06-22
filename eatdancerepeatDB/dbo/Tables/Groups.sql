CREATE TABLE [dbo].[Groups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupType] [varchar](50) NOT NULL,
	[GroupName] [nvarchar](200) NOT NULL,
	[GroupDescription] [nvarchar](max) NULL,
	[SkillLevel] [int] NOT NULL,
	[FacebookLink] [nvarchar](2000) NULL,
	[Public] [bit] NOT NULL,
	[ParentGroupID] [int] NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)
GO
/****** Object:  ForeignKey [FK_Groups_Groups]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups]  WITH CHECK ADD  CONSTRAINT [FK_Groups_Groups] FOREIGN KEY([ParentGroupID])
REFERENCES [dbo].[Groups] ([GroupID])
GO

ALTER TABLE [dbo].[Groups] CHECK CONSTRAINT [FK_Groups_Groups]
GO
/****** Object:  Default [DF_Groups_SkillLevel]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_SkillLevel]  DEFAULT ((1)) FOR [SkillLevel]
GO
/****** Object:  Default [DF_Groups_Public]    Script Date: 06/21/2014 22:12:56 ******/
ALTER TABLE [dbo].[Groups] ADD  CONSTRAINT [DF_Groups_Public]  DEFAULT ((1)) FOR [Public]