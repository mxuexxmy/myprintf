USE [master]
GO
/****** Object:  Database [printing]    Script Date: 12/19/2020 2:58:17 PM ******/
CREATE DATABASE [printing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'printing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\printing.mdf' , SIZE = 10240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'printing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\printing_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [printing] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [printing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [printing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [printing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [printing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [printing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [printing] SET ARITHABORT OFF 
GO
ALTER DATABASE [printing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [printing] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [printing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [printing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [printing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [printing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [printing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [printing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [printing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [printing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [printing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [printing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [printing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [printing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [printing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [printing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [printing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [printing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [printing] SET RECOVERY FULL 
GO
ALTER DATABASE [printing] SET  MULTI_USER 
GO
ALTER DATABASE [printing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [printing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [printing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [printing] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'printing', N'ON'
GO
USE [printing]
GO
/****** Object:  Table [dbo].[tb_order_day]    Script Date: 12/19/2020 2:58:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_order_day](
	[id] [bigint] NOT NULL,
	[stats_day] [datetime] NULL,
	[print_number] [int] NULL,
	[total_amount] [float] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_tb_order_day] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_order_month]    Script Date: 12/19/2020 2:58:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_order_month](
	[id] [bigint] NOT NULL,
	[stats_month] [datetime] NULL,
	[print_number] [int] NULL,
	[total_amount] [float] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_tb_order_month] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_order_year]    Script Date: 12/19/2020 2:58:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_order_year](
	[id] [bigint] NOT NULL,
	[stats_year] [datetime] NULL,
	[print_number] [int] NULL,
	[total_amount] [float] NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_tb_order_year] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tb_print_order]    Script Date: 12/19/2020 2:58:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_print_order](
	[id] [bigint] NOT NULL,
	[user_name] [varchar](50) NULL,
	[user_qq] [varchar](50) NULL,
	[user_wxchat] [varchar](50) NULL,
	[user_phone] [varchar](50) NULL,
	[print_file_name] [varchar](50) NULL,
	[prinf_number] [int] NULL,
	[paper_number] [int] NULL,
	[amount] [float] NULL,
	[total_amount] [float] SPARSE  NULL,
	[note] [varchar](255) NULL,
	[order_status] [varchar](50) NULL,
	[address] [varchar](255) NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_tb_print_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 12/19/2020 2:58:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tb_user](
	[id] [bigint] NOT NULL,
	[user_name] [varchar](255) NULL,
	[password] [varchar](255) NULL,
	[user_phone] [varchar](20) NULL,
	[user_type] [int] NULL,
	[address] [varchar](255) NULL,
	[create_time] [datetime] NULL,
	[update_time] [datetime] NULL,
 CONSTRAINT [PK_tb_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_day', @level2type=N'COLUMN',@level2name=N'stats_day'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计每日打印的份数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_day', @level2type=N'COLUMN',@level2name=N'print_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计每日金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_day', @level2type=N'COLUMN',@level2name=N'total_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_day', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_day', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计月份' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_month', @level2type=N'COLUMN',@level2name=N'stats_month'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'月份数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_month', @level2type=N'COLUMN',@level2name=N'print_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_month', @level2type=N'COLUMN',@level2name=N'total_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_month', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_month', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_year', @level2type=N'COLUMN',@level2name=N'stats_year'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计年打印的份数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_year', @level2type=N'COLUMN',@level2name=N'print_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'统计年费用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_year', @level2type=N'COLUMN',@level2name=N'total_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_year', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_order_year', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印人的名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印人的QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'user_qq'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印人的微信' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'user_wxchat'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印人的电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'user_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印的文件名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'print_file_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印的份数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'prinf_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'打印的页数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'paper_number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'总的价格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'total_amount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'note'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'order_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_print_order', @level2type=N'COLUMN',@level2name=N'update_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'password'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1为系统管理员，2为管理，3为用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'user_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'create_time'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tb_user', @level2type=N'COLUMN',@level2name=N'update_time'
GO
USE [master]
GO
ALTER DATABASE [printing] SET  READ_WRITE 
GO
