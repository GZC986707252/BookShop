
/****** Object:  Database [BookShop]    Script Date: 2019/5/26 22:39:58 ******/
CREATE DATABASE BookShop
 ON 
( NAME = BookShop, 
	FILENAME = 'H:\VS_WorkSpace\BookShop\BookShop.Web\App_Data\BookShop.mdf' , 
	SIZE = 73728KB , 
	MAXSIZE = UNLIMITED, 
	FILEGROWTH = 1024KB )
 LOG ON 
( NAME = BookShop_log, 
	FILENAME = 'H:\VS_WorkSpace\BookShop\BookShop.Web\App_Data\BookShop_log.ldf' , 
	SIZE = 8192KB ,
	 MAXSIZE = 2048GB , 
	 FILEGROWTH = 1024KB )
COLLATE Chinese_PRC_CS_AS;
GO
Use BookShop;
GO
CREATE TABLE [dbo].[Category] (
    [CategoryId]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] NVARCHAR (80) NULL,
    PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

CREATE TABLE [dbo].[Books] (
    [BookId]     INT             IDENTITY (1, 1) NOT NULL,
    [CategoryId] INT             NOT NULL,
    [BookName]   NVARCHAR (80)   NULL,
    [ISBN]       NVARCHAR (80)   NULL,
    [Author]     NVARCHAR (80)   NULL,
    [PubHouse]   NVARCHAR (80)   NULL,
    [BookImage]  NVARCHAR (80)   NULL,
    [BookDescn]  NVARCHAR (255)  NULL,
    [ListPrice]  DECIMAL (10, 2) NULL,
    [Quantity]   INT             NOT NULL,
    [PraiseQty]  INT             NULL,
    PRIMARY KEY CLUSTERED ([BookId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([CategoryId])
);
CREATE TABLE [dbo].[UserInfo] (
    [UserId]    INT             IDENTITY (100, 1) NOT NULL,
    [UserName]  NVARCHAR (80)   NOT NULL,
    [UserPsd]   NVARCHAR (80)   NOT NULL,
    [PayPsd]    NVARCHAR (80)   NULL,
    [Email]     NVARCHAR (80)   NOT NULL,
    [UserAdd]   NVARCHAR (100)  NULL,
    [UserImage] IMAGE           NULL,
    [Amount]    DECIMAL (10, 2) NULL,
    [UserType]  NVARCHAR (5)    NOT NULL,
	[JoinDate] DATETIME NULL, 
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
CREATE TABLE [dbo].[Order] (
    [OrderId]     INT            IDENTITY (201900, 1) NOT NULL,
    [UserId]      INT            NOT NULL,
    [UserName]    NVARCHAR (80)  NOT NULL,
    [OrderDate]   DATETIME       NOT NULL,
    [UserAddress] NVARCHAR (255) NULL,
    [Zip]         NVARCHAR (6)   NULL,
    [Tel]         NVARCHAR (80)  NULL,
    [Status]      NVARCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([OrderId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserInfo] ([UserId]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[OrderItem] (
    [ItemId]     INT             IDENTITY (1, 1) NOT NULL,
    [OrderId]    INT             NOT NULL,
    [ProName]    NVARCHAR (80)   NULL,
    [ProPrice]   DECIMAL (10, 2) NULL,
    [ProQty]     INT             NOT NULL,
    [TotalPrice] DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([ItemId] ASC),
    FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[Comment] (
    [CommentId]   INT            IDENTITY (1, 1) NOT NULL,
    [BookId]      INT            NOT NULL,
    [UserId]      INT            NOT NULL,
    [TextContent] NVARCHAR (255) NULL,
    [ComDateTime] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([CommentId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserInfo] ([UserId]) ON DELETE CASCADE,
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[Collections] (
    [CollectionId] INT             IDENTITY (1, 1) NOT NULL,
    [BookId]       INT             NOT NULL,
    [UserId]       INT             NOT NULL,
    [BookName]     NVARCHAR (80)   NULL,
    [ListPrice]    DECIMAL (10, 2) NULL,
    PRIMARY KEY CLUSTERED ([CollectionId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserInfo] ([UserId]) ON DELETE CASCADE,
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]) ON DELETE CASCADE
);
CREATE TABLE [dbo].[CartItem] (
    [CartItemId] INT             IDENTITY (1, 1) NOT NULL,
    [UserId]     INT             NOT NULL,
    [BookId]     INT             NOT NULL,
    [ProName]    NVARCHAR (80)   NULL,
    [ProPrice]   DECIMAL (10, 2) NULL,
    [ProQty]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([CartItemId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserInfo] ([UserId]) ON DELETE CASCADE,
    FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([BookId]) ON DELETE CASCADE
);
GO
insert into Category values('小说');
insert into Category values('经营');
insert into Category values('社科');
insert into Category values('生活');
insert into Category values('教育');
insert into Category values('文艺');
