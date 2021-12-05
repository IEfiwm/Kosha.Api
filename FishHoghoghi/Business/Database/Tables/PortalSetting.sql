USE [PersonalPortal]
GO
/****** Object:  Table [dbo].[PortalSetting]    Script Date: 12/22/2019 1:40:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PortalSetting](
	[PortalSettingId] [bigint] IDENTITY(1,1) NOT NULL,
	[PhoneNumberSupport] [nvarchar](20) NULL,
 CONSTRAINT [PK_PortalSetting] PRIMARY KEY CLUSTERED 
(
	[PortalSettingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PortalSetting] ON 

INSERT [dbo].[PortalSetting] ([PortalSettingId], [PhoneNumberSupport]) VALUES (1, N'0265478955')
SET IDENTITY_INSERT [dbo].[PortalSetting] OFF
