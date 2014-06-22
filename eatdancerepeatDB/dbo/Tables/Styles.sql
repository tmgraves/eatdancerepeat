CREATE TABLE [dbo].[Styles](
	[StyleID] [int] IDENTITY(1,1) NOT NULL,
	[Style] [nvarchar](200) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Styles] PRIMARY KEY CLUSTERED 
(
	[StyleID] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF)
)