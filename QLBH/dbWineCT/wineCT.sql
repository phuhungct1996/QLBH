USE [wineCT]
GO
/****** Object:  Table [dbo].[dangNhap]    Script Date: 10/10/2017 19:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dangNhap](
	[taiKhoan] [nvarchar](20) NOT NULL,
	[matKhau] [nvarchar](20) NULL,
 CONSTRAINT [PK_dangNhap] PRIMARY KEY CLUSTERED 
(
	[taiKhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
