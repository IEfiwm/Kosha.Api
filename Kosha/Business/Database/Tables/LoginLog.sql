USE [PersonalPortal]
GO

/****** Object:  Table [dbo].[LoginLog]    Script Date: 4/19/2020 4:23:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LoginLog](
	[UserName] [nvarchar](50) NULL,
	[Login_At] [nvarchar](50) NULL,
	[Mac_Address] [nvarchar](1000) NULL
) ON [PRIMARY]
GO


