USE [QLTV]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 09/01/2020 11:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UseName] [char](50) NOT NULL,
	[PasswordID] [char](20) NOT NULL,
	[Email] [char](50) NULL,
	[Permission] [char](10) NULL,
 CONSTRAINT [Pk_Ac] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 09/01/2020 11:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[IDBook] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Author] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[Publisher] [nvarchar](50) NULL,
	[Amount] [int] NULL,
 CONSTRAINT [Pk_Bk] PRIMARY KEY CLUSTERED 
(
	[IDBook] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookitem]    Script Date: 09/01/2020 11:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookitem](
	[IDBook] [int] NOT NULL,
	[IDUser] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Borrowed] [date] NULL,
	[Duedate] [date] NULL,
	[Bkstatus] [char](20) NULL,
 CONSTRAINT [Pk_Bit] PRIMARY KEY CLUSTERED 
(
	[IDBook] ASC,
	[IDUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([ID], [UseName], [PasswordID], [Email], [Permission]) VALUES (1, N'admin                                             ', N'123                 ', N'admin.com                                         ', N'admin     ')
INSERT [dbo].[Account] ([ID], [UseName], [PasswordID], [Email], [Permission]) VALUES (2, N'linh                                              ', N'123                 ', N'linh                                              ', N'User      ')
INSERT [dbo].[Account] ([ID], [UseName], [PasswordID], [Email], [Permission]) VALUES (3, N'You                                               ', N'123                 ', N'You.vn                                            ', N'User      ')
INSERT [dbo].[Account] ([ID], [UseName], [PasswordID], [Email], [Permission]) VALUES (15, N'Babie                                             ', N'123                 ', N'Babie.com                                         ', N'User      ')
INSERT [dbo].[Account] ([ID], [UseName], [PasswordID], [Email], [Permission]) VALUES (17, N'eat                                               ', N'123                 ', N'eat                                               ', N'User      ')
SET IDENTITY_INSERT [dbo].[Account] OFF
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (1, N'OOP', N'KHTN', N'Giáo trình', N'NXB KH-KT', 2)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (2, N'CTDL và Giải thuật', N'KHTN', N'Giáo trình', N'NXB KH-KT', 6)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (3, N'ASP .Net MVC 5', N'Adam Freeman', N'CNTT', N'Apress', 5)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (4, N'Blockchain', N'Nhiều tác giả', N'CNTT', N'NXB HN', 7)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (5, N'AI', N'KHTN', N'Giáo trình', N'NXB KH-KT', 5)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (6, N'Đường băng', N'Tony', N'Kỹ năng sống', N'NXB HN', 8)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (7, N'Hạ đỏ', N'Nguyễn Nhật Ánh', N'Văn học', N'NXB Trẻ', 13)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (8, N'Truyện kiều', N'Nguyễn Du', N'Truyện', N'NXB Trẻ', 3)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (9, N'Ngồi khóc trên cây', N'Nguyễn Nhật Ánh', N'Văn học', N'NXB Trẻ', 2)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (10, N'Bạn thực sự có tài', N'Tina Seelig', N'Tâm lý', N'NXB Trẻ', 4)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (11, N'Đánh bại phố wall', N'Peter Lynch', N'Kinh tế', N'NXB Lao động', 2)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (12, N'Good to great', N'Jim Collins', N'Kinh tế', N'NXB Trẻ', 4)
INSERT [dbo].[Book] ([IDBook], [Title], [Author], [Category], [Publisher], [Amount]) VALUES (14, N'Mắt biết', N'Nguyễn Nhật Ánh', N'Văn học', N'NXB HCM', 3)
INSERT [dbo].[Bookitem] ([IDBook], [IDUser], [Title], [Borrowed], [Duedate], [Bkstatus]) VALUES (1, 3, N'OOP', CAST(N'2019-12-26' AS Date), CAST(N'2020-01-08' AS Date), N'Out of date         ')
INSERT [dbo].[Bookitem] ([IDBook], [IDUser], [Title], [Borrowed], [Duedate], [Bkstatus]) VALUES (7, 2, N'Hạ đỏ', CAST(N'2019-12-27' AS Date), CAST(N'2020-01-09' AS Date), N'Out of date         ')
INSERT [dbo].[Bookitem] ([IDBook], [IDUser], [Title], [Borrowed], [Duedate], [Bkstatus]) VALUES (8, 3, N'ASP .Net MVC 5', CAST(N'2019-12-28' AS Date), CAST(N'2020-01-10' AS Date), N'Being borrowed      ')
INSERT [dbo].[Bookitem] ([IDBook], [IDUser], [Title], [Borrowed], [Duedate], [Bkstatus]) VALUES (10, 1, N'Bạn thực sự có tài', CAST(N'2020-01-08' AS Date), CAST(N'2020-01-22' AS Date), N'Being borrowed      ')
INSERT [dbo].[Bookitem] ([IDBook], [IDUser], [Title], [Borrowed], [Duedate], [Bkstatus]) VALUES (14, 2, N'Mắt biết', CAST(N'2020-01-08' AS Date), CAST(N'2020-01-22' AS Date), N'Being borrowed      ')
ALTER TABLE [dbo].[Bookitem]  WITH CHECK ADD  CONSTRAINT [Fk_Bit_Ac] FOREIGN KEY([IDUser])
REFERENCES [dbo].[Account] ([ID])
GO
ALTER TABLE [dbo].[Bookitem] CHECK CONSTRAINT [Fk_Bit_Ac]
GO
ALTER TABLE [dbo].[Bookitem]  WITH CHECK ADD  CONSTRAINT [Fk_Bit_Bk] FOREIGN KEY([IDBook])
REFERENCES [dbo].[Book] ([IDBook])
GO
ALTER TABLE [dbo].[Bookitem] CHECK CONSTRAINT [Fk_Bit_Bk]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateamout]    Script Date: 09/01/2020 11:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[spUpdateamout]
@idbook int,
@getamount int
as
begin
	Update Book set Amount = Amount- @getamount where IDBook =@idbook
end
GO
/****** Object:  StoredProcedure [dbo].[spUpdatestatus]    Script Date: 09/01/2020 11:29:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spUpdatestatus]
as
begin
	if exists (select * from Bookitem where Duedate < GETDATE())
	begin 
		update Bookitem set Bkstatus = 'Out of date' where Duedate < GETDATE()
	end
end
GO
