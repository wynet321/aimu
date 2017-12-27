CREATE TABLE [dbo].[category](
	[id] [int] NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[role](
	[id] [int] NOT NULL,
	[name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[status](
	[id] [int] NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[tenant](
	[id] [int] IDENTITY(100000,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[shardName] [varchar](20) NOT NULL,
	[statusId] [int] NOT NULL,
	[categoryId] [int] NOT NULL,
	[createdDate] [date] NOT NULL,
	[enableWorkFlow] [bit] NOT NULL,
 CONSTRAINT [PK_tenant] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[cellphone] [varchar](11) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[password] [binary](32) NOT NULL,
	[passwordSalt] [binary](32) NOT NULL,
	[tenantId] [int] NOT NULL,
	[roleId] [int] NOT NULL,
	[storeId] [int] NOT NULL,
	[mail] [nvarchar](50) NULL,
	[memo] [nvarchar](100) NULL,
	[active] [bit] NOT NULL,
 CONSTRAINT [PK_user_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


insert into [user] values('13681395366','admin',0x0740FCD13ACFB6EA6E266A0D493E975D8A703A49255F20C9CBCEF8FA24E89CEE,0x26683548238A7F666CCBEDBDA933782707F74693C50535EE27C3FE510C0BBAA0,1,1,0,'','',1)

insert into [status] values(1,'试用')
insert into [status] values(2,'激活')
insert into [status] values(4,'失效')
insert into [status] values(8,'关闭')

insert into [role] values(1,'管理员')
insert into [role] values(2,'店员')
insert into [role] values(4,'供应')
insert into [role] values(8,'财务')
insert into [role] values(16,'客服')

insert into [category] values(1,'小企业版')
insert into [category] values(2,'企业版')