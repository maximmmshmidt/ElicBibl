USE [ElecBiblioteck]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 13.06.2023 11:20:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Author] [nvarchar](50) NOT NULL,
	[NumberBook] [nvarchar](50) NOT NULL,
	[Summary] [nvarchar](250) NULL,
 CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([id], [Name], [Author], [NumberBook], [Summary]) VALUES (1, N'Му-Му', N'Тургенев', N'10', N'И. С. Тургенев написал рассказ «Муму» в 1852 году. Впервые произведение было опубликовано в 1854 году в журнале «Современник». Рассказ создан в рамка')
INSERT [dbo].[Book] ([id], [Name], [Author], [NumberBook], [Summary]) VALUES (2, N'Гари Потер', N'Джон Роу', N'8', N'Роман «Гарри Поттер и философский камень» Роулинг был написан в 1997 году, став первой из восьми книг о приключениях маленького волшебника Гарри Поттера. Узнав о')
INSERT [dbo].[Book] ([id], [Name], [Author], [NumberBook], [Summary]) VALUES (4, N'Война и мир', N'Лев Толстой', N'0', N'Роман Льва Николаевича Толстого «Война и мир» писался в 1863-1869 годах. Для ознакомления с основными сюжетными линиями романа, предлагаем учащимся 10 класса и всем, кто интересуется русской литературой, прочита')
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
