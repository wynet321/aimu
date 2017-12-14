CREATE TABLE [dbo].[customerChannel](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NOT NULL
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[customerCity](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_customerCity] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[customers](
	[brideName] [nvarchar](50) NULL,
	[brideContact] [nvarchar](50) NULL,
	[marryDay] [nvarchar](50) NULL,
	[infoChannel] [nvarchar](50) NULL,
	[reserveDate] [nvarchar](50) NULL,
	[reserveTime] [nvarchar](50) NULL,
	[tryDress] [nvarchar](50) NULL,
	[memo] [nvarchar](500) NULL,
	[scsj_jsg] [nvarchar](10) NULL,
	[scsj_cxsg] [nvarchar](50) NULL,
	[scsj_tz] [nvarchar](50) NULL,
	[scsj_xw] [nvarchar](50) NULL,
	[scsj_xxw] [nvarchar](50) NULL,
	[scsj_yw] [nvarchar](50) NULL,
	[scsj_dqw] [nvarchar](50) NULL,
	[scsj_tw] [nvarchar](50) NULL,
	[scsj_jk] [nvarchar](50) NULL,
	[scsj_jw] [nvarchar](50) NULL,
	[scsj_dbw] [nvarchar](50) NULL,
	[scsj_yddc] [nvarchar](50) NULL,
	[scsj_qyj] [nvarchar](50) NULL,
	[scsj_bpjl] [nvarchar](50) NULL,
	[hisreason] [nvarchar](500) NULL,
	[reservetimes] [int] NULL,
	[wangwangID] [nvarchar](50) NULL,
	[operatorName] [nvarchar](50) NULL,
	[jdgw] [nvarchar](50) NULL,
	[groomName] [nvarchar](50) NULL,
	[groomContact] [nvarchar](50) NULL,
	[address] [nvarchar](100) NULL,
	[retailerMemo] [nvarchar](500) NULL,
	[createDate] [date] NULL,
	[accountPayable] [nvarchar](50) NULL,
	[refund] [nvarchar](50) NULL,
	[fine] [nvarchar](50) NULL,
	[channelId] [tinyint] NULL,
	[partnerName] [nvarchar](30) NULL,
	[status] [tinyint] NOT NULL,
	[storeId] [int] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_customers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_jsg]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_cxsg]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_tz]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_xw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_xxw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_yw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_dqw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_tw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_jk]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_jw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_dbw]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_yddc]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_qyj]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [scsj_bpjl]
GO

ALTER TABLE [dbo].[customers] ADD  CONSTRAINT [DF__customers__reser__0697FACD]  DEFAULT ((0)) FOR [reservetimes]
GO

ALTER TABLE [dbo].[customers] ADD  CONSTRAINT [DF_customers_accountPayable]  DEFAULT ((0)) FOR [accountPayable]
GO

ALTER TABLE [dbo].[customers] ADD  CONSTRAINT [DF_customers_refund]  DEFAULT ((0)) FOR [refund]
GO

ALTER TABLE [dbo].[customers] ADD  DEFAULT ((0)) FOR [fine]
GO

CREATE TABLE [dbo].[customerStatus](
	[id] [tinyint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_customerStatus] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[customerStore](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](30) NOT NULL,
	[cityId] [tinyint] NOT NULL,
 CONSTRAINT [PK_customerStore] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[customerTryDressList](
	[wdId] [nvarchar](50) NULL,
	[wdSize] [nvarchar](50) NULL,
	[tryDressDate] [nvarchar](50) NULL,
	[memo] [nvarchar](500) NULL,
	[wd_price] [nvarchar](50) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[customerId] [int] NOT NULL,
 CONSTRAINT [PK_customerTryDressList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[dress](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[wd_id] [varchar](100) NOT NULL,
	[wd_size] [varchar](100) NOT NULL,
	[wd_price] [varchar](100) NULL,
	[wd_listing_date] [varchar](100) NULL,
	[wd_count] [int] NULL,
	[wd_realtime_count] [int] NULL,
	[storeId] [int] NOT NULL,
 CONSTRAINT [PK_dress] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[dressDefinition](
	[wd_id] [varchar](100) NOT NULL,
	[wd_date] [varchar](100) NULL,
	[wd_big_category] [varchar](100) NULL,
	[wd_litter_category] [varchar](100) NULL,
	[wd_factory] [varchar](100) NULL,
	[wd_color] [varchar](100) NULL,
	[cpml_ls] [varchar](100) NULL,
	[cpml_ws] [varchar](100) NULL,
	[cpml_duan] [varchar](100) NULL,
	[cpml_zs] [varchar](100) NULL,
	[cpml_other] [varchar](100) NULL,
	[cpbx_yw] [varchar](100) NULL,
	[cpbx_ppq] [varchar](100) NULL,
	[cpbx_ab] [varchar](100) NULL,
	[cpbx_dq] [varchar](100) NULL,
	[cpbx_qdhc] [varchar](100) NULL,
	[bwcd_qd] [varchar](100) NULL,
	[bwcd_xtw] [varchar](100) NULL,
	[bwcd_ztw] [varchar](100) NULL,
	[bwcd_ctw] [varchar](100) NULL,
	[bwcd_hhtw] [varchar](100) NULL,
	[cplx_mx] [varchar](100) NULL,
	[cplx_sv] [varchar](100) NULL,
	[cplx_yzj] [varchar](100) NULL,
	[cplx_dd] [varchar](100) NULL,
	[cplx_dj] [varchar](100) NULL,
	[cplx_gb] [varchar](100) NULL,
	[cplx_yl] [varchar](100) NULL,
	[cplx_ll] [varchar](100) NULL,
	[lxys_bd] [varchar](100) NULL,
	[lxys_ll] [varchar](100) NULL,
	[lxys_lb] [varchar](100) NULL,
	[memo] [varchar](1000) NULL,
	[emergency_period] [varchar](10) NULL,
	[normal_period] [varchar](10) NULL,
	[is_renew] [varchar](10) NULL,
	[settlementPrice] [money] NULL,
	[attribute] [int] NOT NULL,
 CONSTRAINT [PK__weddingD__E2B997A31ED998B2] PRIMARY KEY CLUSTERED 
(
	[wd_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[dressDefinition] ADD  DEFAULT ((0)) FOR [attribute]
GO

CREATE TABLE [dbo].[dressImage](
	[wd_id] [varchar](100) NOT NULL,
	[pic_id] [tinyint] NOT NULL,
	[pic_img] [image] NULL,
	[thumbnail] [image] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[order](
	[orderAmountafter] [money] NOT NULL,
	[depositAmount] [money] NOT NULL,
	[totalAmount] [money] NOT NULL,
	[memo] [nvarchar](500) NULL,
	[deliveryType] [nvarchar](10) NULL,
	[address] [nvarchar](100) NULL,
	[getDate] [date] NULL,
	[returnDate] [date] NULL,
	[createdDate] [date] NULL,
	[flowId] [int] NULL,
	[storeId] [int] NOT NULL,
	[customerId] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[order] ADD  DEFAULT ((0)) FOR [orderAmountafter]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT ((0)) FOR [depositAmount]
GO

ALTER TABLE [dbo].[order] ADD  DEFAULT ((0)) FOR [totalAmount]
GO

CREATE TABLE [dbo].[orderDetail](
	[orderType] [nvarchar](50) NULL,
	[wd_id] [varchar](100) NULL,
	[wd_size] [varchar](100) NULL,
	[wd_color] [varchar](100) NULL,
	[wd_image] [image] NULL,
	[orderId] [int] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[orderFlow](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[statusId] [int] NOT NULL,
	[changeReason] [varchar](100) NULL,
	[customizedPrice] [money] NOT NULL,
	[expressNumberToStore] [varchar](20) NULL,
	[expressNumberToFactory] [varchar](20) NULL,
	[expressNumberToCustomer] [varchar](20) NULL,
	[parentId] [int] NOT NULL,
 CONSTRAINT [PK_orderFlow1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[orderFlow] ADD  CONSTRAINT [DF_orderFlow1_customizedPrice]  DEFAULT ((0)) FOR [customizedPrice]
GO

CREATE TABLE [dbo].[orderStatus](
	[id] [int] NOT NULL,
	[name] [nvarchar](20) NOT NULL,
	[userRole] [int] NULL,
	[preStatusId] [int] NULL,
 CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[role](
	[id] [int] NOT NULL,
	[name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[user](
	[u_id] [int] NULL,
	[u_name] [varchar](50) NULL,
	[u_password] [varchar](50) NULL,
	[u_level] [int] NULL,
	[u_memo] [varchar](100) NULL,
	[u_address] [varchar](100) NULL,
	[u_tel] [varchar](100) NULL,
	[storeId] [int] NOT NULL,
	[enableWorkFlow] [bit] NOT NULL
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[user] ADD  DEFAULT ((0)) FOR [enableWorkFlow]
GO

insert into customerCity values('北京');
insert into customerCity values('天津');
insert into customerCity values('沈阳');
insert into customerCity values('成都');
insert into customerCity values('乌鲁木齐');
insert into customerCity values('重庆');
insert into customerCity values('哈尔滨');
insert into customerCity values('昆明');
insert into customerCity values('长沙');
insert into customerCity values('胜芳');
insert into customerCity values('齐齐哈尔');
insert into customerCity values('包头');
insert into customerCity values('平顶山');
insert into customerCity values('徐州');

insert into customerStatus values('新客户')
insert into customerStatus values('预约失败')
insert into customerStatus values('预约成功')
insert into customerStatus values('客户流失')
insert into customerStatus values('到店未成交')
insert into customerStatus values('交定金款式未定')
insert into customerStatus values('已全款款式未定')
insert into customerStatus values('交定金款式已定')
insert into customerStatus values('已全款款式已定') 
insert into customerStatus values('服务完成')
insert into customerStatus values('已取件')

insert into [dbo].[customerChannel] values(1,'淘宝')
insert into [dbo].[customerChannel] values(2,'大众点评')
insert into [dbo].[customerChannel] values(3,'异业合作')
insert into [dbo].[customerChannel] values(4,'回客')
insert into [dbo].[customerChannel] values(5,'老客户转介绍')
insert into [dbo].[customerChannel] values(6,'微博')
insert into [dbo].[customerChannel] values(7,'微信')
insert into [dbo].[customerChannel] values(8,'京东')
insert into [dbo].[customerChannel] values(9,'天猫')
insert into [dbo].[customerChannel] values(10,'婚博会')
insert into [dbo].[customerChannel] values(11,'其他')

insert into role values(1,'管理员')
insert into role values(2,'店员')
insert into role values(4,'供应')
insert into role values(8,'财务')
insert into role values(16,'客服')

insert into [dbo].[orderStatus] values(1,'新订单',3,0)
insert into [dbo].[orderStatus] values(2,'待报价',7,1)
insert into [dbo].[orderStatus] values(4,'待收款',11,3)
insert into [dbo].[orderStatus] values(8,'已收款',7,4)
insert into [dbo].[orderStatus] values(16,'生产中',7,8)
insert into [dbo].[orderStatus] values(32,'已发货',3,16)
insert into [dbo].[orderStatus] values(64,'已到店',3,65568)
insert into [dbo].[orderStatus] values(128,'已取消',3,2)
insert into [dbo].[orderStatus] values(256,'已完成',3,98368)
insert into [dbo].[orderStatus] values(512,'修改待报价',7,32832)
insert into [dbo].[orderStatus] values(1024,'修改待收款',11,512)
insert into [dbo].[orderStatus] values(2048,'修改已收款',7,1024)
insert into [dbo].[orderStatus] values(4096,'修改返厂中',7,2561)
insert into [dbo].[orderStatus] values(8192,'修改生产中',7,4096)
insert into [dbo].[orderStatus] values(16384,'修改已发货',3,8192)
insert into [dbo].[orderStatus] values(32768,'修改已到店',3,16384)
insert into [dbo].[orderStatus] values(65536,'修改已取消',3,512)

GO