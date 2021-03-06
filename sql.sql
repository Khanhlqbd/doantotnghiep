USE [master]
GO

/****** Object:  Database [TourBookingDB]    Script Date: 6/13/2020 6:31:17 PM ******/
CREATE DATABASE [TourBookingDB] 
GO

USE [TourBookingDB]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AssignPositions]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssignPositions](
	[StaffID] [int] NOT NULL,
	[PositionID] [int] NOT NULL,
	[DepartmentID] [int] NOT NULL,
	[Desc] [nvarchar](max) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AssignPositions] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC,
	[PositionID] ASC,
	[DepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Banners]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banners](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[Desc] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Banners] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Desc] [nvarchar](550) NULL,
	[Phone] [nvarchar](50) NULL,
	[Mail] [nvarchar](150) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Departments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Feedbacks]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedbacks](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Comment] [nvarchar](550) NULL,
	[Member] [int] NOT NULL,
	[Rate] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Type] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Feedbacks] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MemberLevels]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberLevels](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Point] [float] NOT NULL,
	[Rank] [int] NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Desc] [nvarchar](550) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.MemberLevels] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Members]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](350) NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[Mail] [nvarchar](150) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[DateJoin] [datetime] NOT NULL,
	[Platform] [nvarchar](max) NULL,
	[BirthDay] [datetime] NULL,
	[AccumulatedPoints] [float] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[News]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Desc] [nvarchar](350) NULL,
	[Content] [nvarchar](max) NULL,
	[ViewNumber] [int] NOT NULL,
	[MetaTitle] [nvarchar](60) NULL,
	[MetaDesc] [nvarchar](160) NULL,
	[MetaKeyword] [nvarchar](260) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[OrderID] [bigint] NOT NULL,
	[StepID] [bigint] NOT NULL,
	[Rank] [int] NOT NULL,
	[IsLastStep] [bit] NOT NULL,
	[IsAccomplish] [bit] NOT NULL,
	[StepName] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.OrderDetails] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[StepID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Orders]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](16) NULL,
	[Tour] [bigint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Status] [int] NOT NULL,
	[IsPayment] [bit] NOT NULL,
	[Member] [int] NOT NULL,
	[FileParticipants] [nvarchar](2000) NULL,
	[Price] [float] NOT NULL,
	[Reduce] [float] NOT NULL,
	[Amount] [float] NOT NULL,
	[Step] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_dbo.Orders] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Positions]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Positions](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Desc] [nvarchar](550) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Positions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Promotions]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promotions](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](12) NULL,
	[Title] [nvarchar](250) NULL,
	[Avatar] [nvarchar](max) NULL,
	[Desc] [nvarchar](350) NULL,
	[Content] [nvarchar](max) NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[AmountReduced] [int] NOT NULL,
	[PercentReduced] [float] NOT NULL,
	[Type] [int] NOT NULL,
	[Staff] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[TourApply] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Promotions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Staffs]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Staffs](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Address] [nvarchar](350) NULL,
	[BirthDay] [datetime] NULL,
	[Phone] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[Mail] [nvarchar](150) NULL,
	[Account] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[CreateBy] [nvarchar](max) NULL,
	[ModifyDate] [datetime] NULL,
	[ModifyBy] [nvarchar](max) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Staffs] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Steps]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Steps](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Place] [nvarchar](350) NULL,
	[GuideName] [nvarchar](max) NULL,
	[Desc] [nvarchar](800) NULL,
	[Rank] [int] NOT NULL,
	[Tour] [bigint] NOT NULL,
	[Name] [nvarchar](250) NULL,
 CONSTRAINT [PK_dbo.Steps] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tours]    Script Date: 6/13/2020 6:31:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tours](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](350) NULL,
	[Title] [nvarchar](350) NULL,
	[Desc] [nvarchar](850) NULL,
	[PlaceStart] [nvarchar](350) NULL,
	[PlaceEnd] [nvarchar](350) NULL,
	[Content] [nvarchar](max) NULL,
	[DateStart] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[DescTime] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Tours] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202006081255430_start', N'TourBookingSolution.Services.Migrations.Configuration', 0x1F8B0800000000000400ED5DD96EDC38167D1FA0FFA1504F3D40DAB29D499009CADDF01237DC133B059793775A62D942B4D44894E3FAB679984F9A5F184AD4C24DA2285165B92204085C9478B8E86EBCE4E5FDDF7FFEBBF8E3D9F7664F308ADD3038991F1D1CCE6730B043C70D1E4EE6095AFFF661FEC7EFBFFC6DF1C9F19F67DF8AF7DEA6EFE19A417C327F4468F3D1B262FB11FA203EF05D3B0AE3708D0EECD0B780135AC78787FFB48E8E2C8821E6186B365BDC2601727D98FDC03FCFC3C0861B9400EF3A74A017E7E5F8C92A439DDD001FC61B60C393F95D98446761F81D7770157A09C2FD3958C1E8C9B5613C9F9D7A2EC07D5A416F3D9F8120081148DFF8F835862B1485B8CE061700EF6EBB81F8BD35F062988FE463F57ADB411D1EA783B2AA8A05949DC428F435018FDEE6B364F1D53BCDF5BC9C453C8F9FF07CA36D3AEA6C2E4FE6A771EC3E04CB307649037C931FCFBD287D5D3EE117008103F2AD0E58A437B3BAF7DF94E483A92CFDF766769E782889E04900131401EFCD6C99DC7BAEFD2FB8BD0BBFC3E024483C8F1E061E087EC614E0A265146E6084B6B7709D0F6E85C07A7D75319F59EA778B8EB77CFD026E40847C1820B1C2C2E27B5702F01D23537B15A0B7C7F3D90D1E26B8F760498F562308DDE33E38EC50FA21C5768180D90C7FF9F9EC1A3C7F86C1037A3C99E33FE7B34BF7193A45498EFA3570B1A8C1955094281B398F20401053122C9A4AFFBEC362A45DCDB3EDE05DC41CE1AEB75DBA486AEEA08B9802511217CD603EF52008141F7C6155E2A351A89C61F901A33EC284208C428874E16F35235193B2426104FF8478BC98489C2540084658535C39309B57D5973C7DC2F3110D4E300ADE3E7E773876AAACE45C1FCAAC5026EA6C419D772EF2E0E074A320CE77461A593E8641D3508C34720D5CAFA18D23238D4C2A74F42AF41242E71ED8DFFB88AA02633F04D5FB7F0C2AA8CE439FA88681A5C835F4EF61D4CFCEBEA5D8A2A3A52E652C4D90B4BA4E375A133F99A3CFF0097A7DE89F82D90F161858572F43B762808B100F5A9F266E41F0BD1F69A6FFEF87C130A9D9D1ABD9421AF71532937C69215F149C6DC6B63D759C08C671433B6F5FCF6A00CFB5D3D758D8C98AE2D4B6C3A4D97A3232E9208E7F849133743BA910FC0B6BC3DE26D2D203681D46FEE052F2CC8DD0E305D8EA8A71FCE1123FF1327E4ED57FDC53FF0F2AAD6FE08FB88FAC4EEBEF87A41E7831B41BAFCD383C9766D4C17918A0E6E5A399C17C73E18F9BA4FF12F21A22A0FACAEFCDAC7711507C8123630D611E52A88763236D4D96FDE82DFB2F91D3CFB0CF00266DD1CA75E634DAF5EF0DD04AFA195423DA81CB8B25D96EA2F72A5E822DED6B6C47F9C3B8122F5D0F2E41845CDBDD00CAFC9389CEC34323367CE4DAB0A795790B9DA437C8A94F2F595A81B4963E260ED48CEA28CDD87D0B7BB4CF381917A3372E705B7ED89BBF0B90FD60F01736328E4D1819D3B277A4CB5ECCCD113262C17D0A1C2338C47A208688D3CF065BC2C886025647AB467753563AD7EB756F88E1846FDEBFEE823703D80FA13BEDD80CEF229F767AF678A76732B6476F6CAF10DCF413F770B31FD27E60133B33B2085DF537B28CE02C3D6037895E338AE1CFC475A042D5EDC426FF60C4C1D6FF0896AEB3B5352B13E0EEAC9C3E9F58D944508819CE512D98CDB4A2E21A3306472A6A320938FCD1A1B4292C22F766759ECA7766EA5E7C759E920CAD81068C584A8D935DAF954DECAA340BED9474808BC54FF96170A90BE38BFB8CA89E6531545F63984BF2389F3CB6CB0479055121A49888613C05558748E8F6011F9D6C350392A84119501191A800A882BB642074009902A808BD90C154A11D0A10EAFCBA0C873925DF0AAA1E4509408E5E09B549B1A26EB6932EAB9DEFD12BAA3711486BD2289DED5294CA9DAF80C95C473288DC29A5AC0E37F2DAA91451544ECD1E59656254C958BB64E2F2D9C2223729E4050BABE6CA85C535D86CB0C4A4AE60C84B662B72FFC2F96F2BFDEB087C8261D9B1E45682B2B7654BD806020F907B4AB6022EDD284E1DC2E01EA482EDDCF185D744915533BF457B72A9C41B83D5FC17F5D2BFAB4F547729052FCC38DC6A862FF1A05321938D1F96BD14EE6A100066E93D19C00391CCA19B5A9FE7B84F7EC0155AAD71E80B0768A8A6AB13EAD1D86B0768BCA6BB159A11533B91454A4BDA23D0DE201A872ED7454BDD2F22D69960C23721D12E201A8B2ED745E3FB5595B6472A6C178EB0B2321165617114CEB39625F016B7C4E259B615431756813146CE8D097D06AEAB5837BD3C63E8B143B106A4118AB25D32D5AB2012DAF233462894C1A84F2C4D958721987C354F03E445BB24977CBB855130A44843C2653B218C74CB4A264DF0536B826A55668CC5CBC59C3E83D7571D86BDCB087786068B420DA2C9578C0CC94857914D28B70209DF6A12AFC804BAE44FCE4A30F22E2B190DC1321E0063344B3B0EF4C9B6B1F630949B07A6B36B0E578F6AC9AE084B6F81E0836942203B44340229991628935A629F77E272E30CDE99B777C5D6FD19AA3C3AC4AC718AC2DDDA9CC5091E1AA428DBA5E55A1ED061E6A428D49893F2040E332D65A99EA226D1D4BCB226A51A7D2AC3A9993E95A5ED91AAC360345255AA35DF7C043537F3FCE33D135FD91E8031D925436B21B9E4D5C6BB4E1E8B73A6DC2266170579617B1C3A2E9986A2CB759618657432BBCA288BF5B0C479AA4AF590CA08631EAC7C3019733FB531976F761A9387648F545F20D6D41BCAB5E0F0349C9568C8D46C139311A9C2B66633427F77801E7DD5CE6415DECB4C6855BC6B578B18E34BE3894F35EC3172EA8431C64891C6C23C8FE56596E67999863EF52546AF5F67F3BE906C186053B9C776B2FE46F2CB9B4D93074507EDA751BAD4E91E739C551E0AEAC05AF57547AB80A7458D8CF68BA8538EFC8BE2F658E5C9561AA92CD4557465ACA8A8EFCA471A6A9C0B4065F439F76C88DD9586F94F0FD509C796F64E7EE5C70A8DC92E324BFA72ABA6DEBEBB7FCD39032747F2908EE4C976DB43DB8D9C893628FAE0A693E493551B46F05171968259210BEB6DC22A232D39B34217278FB4E4B655F4D6E0541C2523BBAAE25D1A81FD37FCDBFBA45E887548448031D6C946A7CF3AF26AC3B08E9915C6383C1174C4A1C07779B9265A1654286065A5BB5F3D515181BC57567B74A6564F555C20FFE574052609D961E5B718C4D38C60C2DDACE3821D544C094147FC2B65EB7949F9BB0C3ACA037ED4C95F850820F2CA7C8627E7096B9B08CFE43646D027D1E3AB7F7BE79E9B916FF1C23508DC358C1109039F1F1FA61788315963C793C1D58A6387396BA74CE3CA7EB5BDCA959A1DFBEB9D29B50B8A2C4F6A379C2A9C3D780291FD08A25F7DF0FC771AA9DBDD350EFE1B71F1D2ED91AA8B627A754BBCAFA66BB7F8FB6B7A758B8DB3BE77551F4E37DB69079EEB778B44467BCA7B2274AFB5632E8EE835E1323A1723F047F211EBA26D5EED8764AEE63035FDCA4FFA4E1F93B95E4D0EAA8D49DF8426853CD2C79CA4ED2818551E35B30B36BD771F06E1542EF3A429BE626F87EF62A8D069263B193A0AA2D4BECF54DD894E2926F743E033D91BD75E08BA7CF0EAE6B02E1F9C38F9C6AF7226513E0A512E8B3679B5ECA7A4FD0E26077733AE14F6ED382C2EF6FEDA2EC263089B8DBBACD6D058F9BB690DC1F249073BAB4C3EE9602FEEE76F4DEE2A926A130D7653558309253190E435DB9683AC0277E923E820DEB85B0F7BF54F4CB7D749B4F1C9F6A4437DDFC1C46773EBC9C566375C2E959E9C76F4A127D36B14A697243AE4358B393A394C0D13E84E3D7D0772D1ED9758FFB224D0A51B42BE39351D0DE14DA8CB3427972C59AE394DB38CBE02B5E30298C92BD70D834D2BD706433FABDC7E2C995E8D8B7A525AA3505A4B7954C57E2BAE636DC53599FC7DC9974D35D6597573979977C691A61AEB740E429A68AC9B9AD3F3CB4BA7B9CA32D61160183123098278B52AF61579254D399A26EFE628BD9B930D350A1B4A8C7378CDE69390B1AA8FAE3682C364AC32251A850455C31A601FF4D7DE7D778EB5BD2D7A29A7F686E0E576785FFA522F193A80AAC9AC836E12923419DB13E572328D716522A4597AF195099F66C9DC31CF2AABD22ED606069C897AE994C414266C6FCA388B82EFB94448555B359992484004FEB4F7211E05E9B5906FC96A6EB4489A2434563C903552E6605280D3C9948406E887B246983C4D8A86AA744B4233D5235923540E2745134C2626A115E6A9AC2136CF53ABB61A1239D5B7A0066FCCF224036E9FFFA93EFD930CB74819A5406E6088665668CF0495D3B1316F94B4112AE794A295DC1B22B49097CBD08B54544AE454944A80D362396E96A34A014B0C36019614CB60F3EC553291D9224D951819B6B06EF1DA17EB1EF20B6B222CDB4A8805C60CA09D4E7E055ABC7315ACC342DCE311D13D2A5E916C886325094E23E4AE818DF0631B62699AA614FC06BC2455A998C39CABE04B823609C29216739CC704EB2FACE6F6B35C5C6C9F175F3619F9981802EEA69BEAF92FC159E27A4ED9EF4B892AAB814895566ECBE25EAD506AD33E6C4BA41BE19E8B3AA07CFAB0144FFD2A01BA83FE263D19147F0956E00976E9DBD7187E860FC0DE2EF300BF7A10F58760A77D71E1828708F8718E51D5C73F310D3BFEF3EFFF0753157F1F43AF0000, N'6.4.0')
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'202006100334247_update-06102020', N'TourBookingSolution.Services.Migrations.Configuration', 0x1F8B0800000000000400ED5D5B6FDCBA117E2FD0FFB0D8A716C8F1DA4E13A4C1FA1CF8121FF8344E165E27EFB4C4B585E8B29528C7FE6D7DE84FEA5F2825EA425294285EB496F70801022F257EA4C899E1CC909CF9DF7FFEBBFCED29F0678F304EBC283C991F1D1CCE67307422D70BEF4FE629DAFCF261FEDBAF7FFDCBF2931B3CCDBE97EFBDCDDEC335C3E464FE80D0F6E36291380F3000C941E0397194441B74E044C102B8D1E2F8F0F09F8BA3A305C410738C359B2D6FD2107901CC7FE09FE751E8C02D4A817F1DB9D04F8A72FC649DA3CEBE8000265BE0C093F96D94C66751F40377701DF929C2FD3958C3F8D17360329F9DFA1EC07D5A437F339F81308C10C8DEF8F82D816B1447B8CE161700FFF6790BF17B1BE027B0F8928FF5EB7D3FEAF038FBA8455DB18472D204458122E0D1DB6294167C75ADB19E57A388C7F1131E6FF49C7D753E9627F3D324F1EEC3559478A401BEC98FE77E9CBD2E1EF00B80C00199AB0316E9CDACEDFD3715F9602ACBFEBD999DA73E4A637812C214C5C07F335BA577BEE7FC0B3EDF463F607812A6BE4F7F06FE10FC8C29C045AB38DAC2183DDFC04DF1716B04369BAB8BF96C217FB7EC78CFD72FE016C42880216A56582EF8DE55007CC7C8D05E85E8EDF17CF6057F26B8F361458F8B4E10BAC72638ECA79821254E8980D90CCFFC7C760D9E3EC3F01E3D9CCCF19FF3D9A5F704DDB2A440FD167A58D4E04A284EA58D9CC71020882909964D657FDF6231D2AFE6D9F3E05DC41CE16D9E75BA486AEEA08B9802519A94CD603EF521082513BE5CD4E2A353A89C61F901631361421046214474F85BCE48D4A0AC5114C3DF21FE5E4C24EE0A200463BC525CB9301F57D94C9E3EE2F188072718096F1FBF3B1C3B55D672CE84326B94893A7B50E7AD877C3838DD4888F39D9546560F51D8F529561AB9069EDFD1C6919546A62574F44BE82584EE1D707E9888AA12633F04D5FB7F0C2AA8CEA3802C0D034B916B18DCC1D84CCFBEA1D84253531732962248565DA51BBD899F8CD167F8087D13FAA760F68305065EAB57915733C045843F5A9D266E40F8C38C34B3FFF743619896D9D12FB3A534361532937CE9215F249C6D47B73D75DD182649473B6F5F8F3580C7DA3555167662519C3A4E94766B4F56061D24C9CF2876876E2713827FE0D5D058455AF9006DA238185C4A9E79317AB800CFAA621C4F5C1AA47ECECFD9F29F18AEFF834AEB2FF0676222ABB3FAFB21A907368676E3B51987E7D2CE72701E85A8DB7CB4F331DF3DF8F34B6A6E425E430464B3FCDE8EBD8B8064068EAC35847948B23C1C5B696BD2EC47AFD97F8DB1E6748169C233F2215030A35839F2FEF4DCA35E23B8D55969AA36BA971BD9E492C64D30CC9D0957C96790A0AC2F6A642642CA74DC60EB7BC9832956D61F8931A4C3616ABC61CC15A3E087B16B52E778C03A973E0B72349B063346B3E20E66C5B92EBFAEC033ED87D765311B6EF64BCF872B1023CFF1B680328D446AC5E1A19DFDEF5A50691E0A8A3D071ADA7037D04D8D414E03DA21D00BA4B7FCB2715C6D5407D5C6EEB9DBA35DFC49751FBDEA8EDB0A2263FE2E41F683C15F584D39B6A1A64C4EA5913A953037C7C88A0EF82974ED1C2DC02C7BBADDFAC34B32A2A71095C735D4BD60ECC00696A6FEA47AB84238AB9B8D31C47062BEE89FBE88CF01F643BC4F3BAFC36F754D3BB67BBC633BA9F5A357EB8973C344DCC3ED7E48FB8195F99D9CA05BF9C0E96AC58EACFF3DF55C3880AB5C59A1FF60C5BF67BEA1A1EAEBEDCD9D04589F3BB3E71377DAB8AF65877364D6B69D56645C634FD4E436EAF0A7FAB2A6B011BB37A67DA6623043F7E2A67D4632A4E2C02B948E32636343A55BE466130F3C2C3CAA61C5A51E4C2EEE729278125D4EFC96C0420E27C5A7B35D26C86B884A11C35CC5C743507788C44438E0AFFD2FBA01C9755C115079D5570250DF9A1481D037332540E59D26114C7D674A02425D0C11E130D74F7A41B5A34801C899C6466D522CA94B1D4E1161304760FA40B58248AB77D15A6F2AAB5CF642947A53400293BB85441085C3495A1D6EC5B533F3455239D37F44958976259212953CA89E2D1724DA4951B05CB48445595E83ED168B4E2A4C4A51325B931829E7BFACD54386040463E12482C821556FAB96B03204EE21F7946C285C7A7192B995C11DC864E4B91B345E6B4ABF96F12DDB130B385E2BACC7BFAC97FD5D4F515BE0185E2E72B8F5085FE28FCEE455FEFDB0EA65239E4A036096C5B2013E8845CEDA4C0D3DC77D0A42AE903FECD58E430705A1A1BAC29BB4A3B1A14168BCAEF827DD8899C2C8226525FD11684F0F8D4397ABA265AE9526D6594397EF42A2DD3B34165DAE8AC6F7AB2EED8F54AA411C61E5654D94E582A3709EB5160DDEE26C2D9E657B3174A9605863E4422F5167E0B68A6DC3CB33861A3B94C6208D5096ED92A95E0591D04AA43542A1744F7562E9AA3C0CC114663D0D5014ED925C8AAD14668121450A122E574B19E9265054BB10A695600F5782DAC0B3C6E2955DA8CEE0ED558761EF2A0A05438365A102D114C62743324283B40BE5A641C2378AC4DB640255F227E720187997978C8660196782359AA57D10EA64DB597B18CA2D8247B03687A746B5647B84A5B7B0E1CEE942205B45340229990C946959629F6B71B97506D7E6ED5DB1B5394355C782181BA72CDCADCE599ECEA141CAB25D6AAED5E11B664CCA428531A94ED730C35295AA2DD424E201BF589352853E55210F983E55A5FD91EA835E34525DAA34DE7C94036EE4F9C77B26BEF2ED046BB24B84D6437289AB8DD74E1E8B73A6DA2B668D82A2B03F0E1D3B8086A2CB554C8C2A82006B6554C56A58CD71AA4BD590AA28003C58F56052E6FED4CA1CB36F6A4D2AD2DBADEAC2B1B376DB685737F5E9E16E0D11D0356BE4B23E3B6BA2E8015D28E6E61B7D5D9F91FD54B90A1A7D659FC5A39FA88D535323AE4BC745E1B6695B97AA77E73C7379299D9728680DF9363DA3343436EEBB11CC1D5E6A12B49DF6AB8BF42CE157C5BB7626366FD3D378CDA76A5CD9E448259B851CF2620C1652A420FD8A5BF38CFC2BCA1474CE406018066D76E10B4997010E5E181CB9503F6CF1F2A6C5E4655441FBD328A6D409387B9C551D9CD360ADF6BAA35DC227C35F44FBE5FD6E8EFCCBE2FE58D531701AA92A5453B58A1BDEBCBE5514AB2E9AD5BDEBE6DA593D525009B8CBDC8C6EC03D1B6237B3632EB343AC8D63827B270B8B63BCD6E42019257519D8526FDFB75BEC39DFA78D9B21376E263D700FF5407207C1A2E8C3E6B08EE413551BABE02B2E24739B8E6AD63775DD98913475F12ED53F737F6A7F7FD60B113AB92F638DD0F3AF53277471B56108DD8E6D310E1F047D31B7C17745B9225A7EF7B6819597EEDE6EA22ECFF21E5DE5AFB36537D5D767F999134512E942B2E36856719D0E2A641A17EAF857AAD68B92EA7775A1AEB8CC264F3EDEB8DD465E99CFF0E03CE2B522C623F99C2018901009EB7FFBE7BE97135FF9C23508BD0D4C108975303F3ECC42EC3159CBC793417C91242EB329294D23CECEDA5EE5EACE8FB41A67EAD64111E5E9D6C3A96336848F20761E40FCB7003CFD9D46D28BB9E4E2BF111714A03F521DE0C8A85BCD384BBADDE2E32E19758B0D4770E7C9264E35DBB606CF99854AC9694F1A0C45356C34131DC568C04574DE0C333192496CBB49F66A2792893F636BF8A553FA4E1D93090B280655C6A423F809218FD43127693B0A4615DF08DB059BDE79F783702A97F9D8165FB119187414153ACDB196A223214AE538BCF24E68A538DE0F81CF640FDEF811D099F03A3C9ECE841317DDF8979C49948F42948B6E52BD5AF693D2BE86CAC1457416C2BE1D87C6C5C65DD6111E43E86C5C90654BDFCAC754B604CB27BDD55E32F9A4B746DCCF47FBD61549AD896EF596AAC18452F392D46BD62D07B10277E923D0106F5C684FA3FE35D3BD6A89363ED9ABF053DF6BA8F86C6E57B1D8D4C3E552B98A69471D7A52BD46A17AB5DE761A6D16D452421AA541D50431B58B9A5950E5532942696640D5C1E1B39F2A50A86286D3BD5946E9F45C2D425695B5E940F29A6469C5BFC28A183DEAE67286EA10A5B9B7AA2D5BA878E5CAF385AA0AE39A7FB57621E948D69A0E1A2633A81E069B18B40F867A5ED0FD30E95FCD16CAA4548D42A95A896FEBECF7C277ACBCF04D26A929F9B2C922B5977E2EA384FE160D9F2CD2E8FB840921B5D65B613A48BD45536D174A3869752E484D80618496E07ACDAB5DB05F910FDE965B75F2E58FD2973F6964A3D0C89A37685EB33236C4F63A9346D096706B640D1C5621FBA06ECB9B7AF494BD376A7900F78664C57AB9297DC94D080D50399969721793FECDDA1E3E97286F8C964A23F7DD8B5B2A7CEEBB973A966CC139A896E5AE990E8AED4D75AFA7E45B2E3F5DDD564B023B7201074FCD5D84BF82F4BA91066FD1DD6899CBAED158F940D448951A4F024EE7B86B34403F1435C2A4CF93345467C16B34533F123542A5D69334C124C86BB4C23C1535C4A6DFEBD556477EBDF616E4E09DC9F744C0AA69F96459F9446DB059FDFAB4D59EB6AF155F8EDCC17CDD6CD79FE16A876567BE3F612354AE40492B85EFA3D142512E422F53084A91B31D190170562CC6CD730B4A608972D78025C522D822EBA0483CF7482FD8BCF5B85CDC604B17AF53E4175EB5B01CAD20961833844E36F83568F9CE55B889CAA5057F11DDA3F215C1610FBCA082D318791BE020FCD8815872673961BF033FCD965FCCCDEE55F83545DB1461A98EB99B0D10B45C74B79FE75064FBBCFCBACDC9C7C627E06E7A994EF0353C4B3DDFADFA7D2958365B20B205B2D07B71AFD628D37FEF9F2BA42F8D78296D40C5F0E11523F3A284E81606DBECD45BF2355C8347A8D3B76F09FC0CEF81F3BC2A2EAFB683C827821DF6E58507EE63102405465D1FFFC434EC064FBFFE1F5FB67F979FB80000, N'6.4.0')
INSERT [dbo].[AssignPositions] ([StaffID], [PositionID], [DepartmentID], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, 3, 1, NULL, CAST(N'2020-06-08 20:12:59.443' AS DateTime), N'admin', CAST(N'2020-06-08 20:12:59.443' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Banners] ON 

INSERT [dbo].[Banners] ([ID], [Avatar], [Desc], [Status]) VALUES (1, N'http://localhost:44351//Content/FileUploads/images/1.jpg', N'slider-1', 1)
INSERT [dbo].[Banners] ([ID], [Avatar], [Desc], [Status]) VALUES (2, N'http://localhost:44351//Content/FileUploads/images/2.jpg', N'slider-2', 1)
INSERT [dbo].[Banners] ([ID], [Avatar], [Desc], [Status]) VALUES (3, N'http://localhost:44351//Content/FileUploads/images/3.jpg', N'slider-3', 1)
INSERT [dbo].[Banners] ([ID], [Avatar], [Desc], [Status]) VALUES (4, N'http://localhost:44351//Content/FileUploads/images/4.jpg', N'slider-4', 1)
SET IDENTITY_INSERT [dbo].[Banners] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Phòng R&D', N'Phòng R&D', N'0123456789', N'demo@gmail.com', CAST(N'2020-06-08 20:10:27.193' AS DateTime), N'admin', CAST(N'2020-06-08 20:10:27.193' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Phòng Marketing', N'Phòng Marketing', N'0123456789', N'demo@gmail.com', CAST(N'2020-06-08 20:10:38.757' AS DateTime), N'admin', CAST(N'2020-06-08 20:10:38.757' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Phòng Kế Toán', N'Phòng Kế Toán', N'0123456789', N'demo@gmail.com', CAST(N'2020-06-08 20:10:50.700' AS DateTime), N'admin', CAST(N'2020-06-08 20:10:50.700' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (4, N'Phòng Điều Hành', N'Phòng Điều Hành', N'0123456789', N'demo@gmail.com', CAST(N'2020-06-08 20:11:12.653' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:12.653' AS DateTime), N'admin', 1)
INSERT [dbo].[Departments] ([ID], [Title], [Desc], [Phone], [Mail], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (5, N'Phòng Triển Khai', N'Phòng Triển Khai', N'0123456789', N'demo@gmail.com', CAST(N'2020-06-08 20:11:24.717' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:24.717' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[MemberLevels] ON 

INSERT [dbo].[MemberLevels] ([ID], [Point], [Rank], [Name], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, 0, 1, N'Thành Viên', N'Thành viên cơ bản của hệ thống', CAST(N'2020-06-08 20:13:29.453' AS DateTime), N'admin', CAST(N'2020-06-08 20:13:29.453' AS DateTime), N'admin', 1)
INSERT [dbo].[MemberLevels] ([ID], [Point], [Rank], [Name], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, 150000, 2, N'Thành Viên Đồng', N'Thành Viên Đồng', CAST(N'2020-06-08 20:13:46.870' AS DateTime), N'admin', CAST(N'2020-06-08 20:13:46.870' AS DateTime), N'admin', 1)
INSERT [dbo].[MemberLevels] ([ID], [Point], [Rank], [Name], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, 500000, 3, N'Thành Viên Vàng', N'Thành Viên Vàng', CAST(N'2020-06-08 20:13:58.483' AS DateTime), N'admin', CAST(N'2020-06-08 20:13:58.483' AS DateTime), N'admin', 1)
INSERT [dbo].[MemberLevels] ([ID], [Point], [Rank], [Name], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (4, 1500000, 4, N'Thành Viên Kim Cương', N'Thành Viên Kim Cương', CAST(N'2020-06-08 20:14:11.653' AS DateTime), N'admin', CAST(N'2020-06-08 20:14:11.653' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[MemberLevels] OFF
SET IDENTITY_INSERT [dbo].[Members] ON 

INSERT [dbo].[Members] ([ID], [Name], [Address], [Phone], [Gender], [Mail], [Account], [Password], [DateJoin], [Platform], [BirthDay], [AccumulatedPoints], [Status]) VALUES (1, N'Trần Lương Công Danh', N'123 Phú Lợi, P.Phú Lợi, Thủ Dầu Một, Bình Dương', N'0123456789', 1, N'demo@gmail.com', N'congdanh2020', N'123456', CAST(N'2020-06-10 16:43:03.067' AS DateTime), N'Web', NULL, 14725, 1)
SET IDENTITY_INSERT [dbo].[Members] OFF
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Kinh nghiệm khi du lịch Thái Lan', N'http://localhost:44351//Content/FileUploads/images/n2.jpeg', N'Kinh nghiệm khi du lịch Thái Lan', N'<p>đang cập nhật</p>
', 0, NULL, NULL, NULL, CAST(N'2020-06-10 15:27:10.730' AS DateTime), NULL, CAST(N'2020-06-10 15:27:10.730' AS DateTime), NULL, 1)
INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Kinh nghiệm khi du lịch Hàn Quốc', N'http://localhost:44351//Content/FileUploads/images/n1.jpg', N'Kinh nghiệm khi du lịch Hàn Quốc', N'<p>đang cập nhật</p>
', 0, NULL, NULL, NULL, CAST(N'2020-06-10 15:27:38.487' AS DateTime), NULL, CAST(N'2020-06-10 15:27:38.487' AS DateTime), NULL, 1)
INSERT [dbo].[News] ([ID], [Title], [Avatar], [Desc], [Content], [ViewNumber], [MetaTitle], [MetaDesc], [MetaKeyword], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Không biết tiếng Anh có đi du lịch nước ngoài được không', N'http://localhost:44351//Content/FileUploads/images/n3.jpg', N'Không biết tiếng Anh có đi du lịch nước ngoài được không', N'<p>đang cập nhật</p>
', 0, NULL, NULL, NULL, CAST(N'2020-06-10 15:28:02.047' AS DateTime), NULL, CAST(N'2020-06-10 15:28:02.047' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[News] OFF
INSERT [dbo].[OrderDetails] ([OrderID], [StepID], [Rank], [IsLastStep], [IsAccomplish], [StepName]) VALUES (4, 1, 1, 0, 1, N'Ngày 1')
INSERT [dbo].[OrderDetails] ([OrderID], [StepID], [Rank], [IsLastStep], [IsAccomplish], [StepName]) VALUES (4, 2, 2, 0, 0, N'Ngày 2')
INSERT [dbo].[OrderDetails] ([OrderID], [StepID], [Rank], [IsLastStep], [IsAccomplish], [StepName]) VALUES (4, 3, 3, 0, 0, N'Ngày 3')
INSERT [dbo].[OrderDetails] ([OrderID], [StepID], [Rank], [IsLastStep], [IsAccomplish], [StepName]) VALUES (4, 4, 4, 1, 0, N'Ngày 4-5')
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([ID], [Code], [Tour], [Date], [Status], [IsPayment], [Member], [FileParticipants], [Price], [Reduce], [Amount], [Step]) VALUES (4, N'110620ggjuym', 1, CAST(N'2020-06-11 15:49:32.150' AS DateTime), 1, 1, 1, NULL, 15500000, 775000, 14725000, 0)
SET IDENTITY_INSERT [dbo].[Orders] OFF
SET IDENTITY_INSERT [dbo].[Positions] ON 

INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Trường phòng', N'Trường phòng', CAST(N'2020-06-08 20:11:34.183' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:34.183' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'CEO', N'CEO', CAST(N'2020-06-08 20:11:38.923' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:38.923' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (3, N'Nhân viên', N'Nhân viên', CAST(N'2020-06-08 20:11:44.603' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:44.603' AS DateTime), N'admin', 1)
INSERT [dbo].[Positions] ([ID], [Title], [Desc], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (4, N'Phó phòng', N'Phó phòng', CAST(N'2020-06-08 20:11:52.583' AS DateTime), N'admin', CAST(N'2020-06-08 20:11:52.583' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Positions] OFF
SET IDENTITY_INSERT [dbo].[Promotions] ON 

INSERT [dbo].[Promotions] ([ID], [Code], [Title], [Avatar], [Desc], [Content], [StartDate], [EndDate], [AmountReduced], [PercentReduced], [Type], [Staff], [Status], [TourApply]) VALUES (2, N'100620-5dc4x', N'Giảm ngay 5% cho tất cả các Tour', N'http://localhost:44351/Content/FileUploads/images/p1.jpg', N'Giảm ngay 5% cho tất cả các Tour', N'<p>đang cập nhật</p>
', CAST(N'2020-06-02 00:00:00.000' AS DateTime), CAST(N'2020-10-31 00:00:00.000' AS DateTime), 0, 5, 2, 0, 1, NULL)
INSERT [dbo].[Promotions] ([ID], [Code], [Title], [Avatar], [Desc], [Content], [StartDate], [EndDate], [AmountReduced], [PercentReduced], [Type], [Staff], [Status], [TourApply]) VALUES (3, N'100620-6kws7', N'Khuyến mãi giảm 10% cho các Tour quốc tế', N'http://localhost:44351/Content/FileUploads/images/p2.jpg', N'Khuyến mãi giảm 10% cho các Tour quốc tế', N'<p>đang cập nhật</p>
', CAST(N'2020-07-01 00:00:00.000' AS DateTime), CAST(N'2020-09-30 00:00:00.000' AS DateTime), 0, 10, 2, 1, 1, N'4|')
SET IDENTITY_INSERT [dbo].[Promotions] OFF
SET IDENTITY_INSERT [dbo].[Staffs] ON 

INSERT [dbo].[Staffs] ([ID], [Name], [Address], [BirthDay], [Phone], [Gender], [Mail], [Account], [Password], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (1, N'Quản trị viên', N'Main', NULL, N'Main', 1, N'Main', N'admin', N'admin', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Staffs] ([ID], [Name], [Address], [BirthDay], [Phone], [Gender], [Mail], [Account], [Password], [CreateDate], [CreateBy], [ModifyDate], [ModifyBy], [Status]) VALUES (2, N'Trần Công A', N'Bình Dương - Việt Nam', CAST(N'1991-01-29 00:00:00.000' AS DateTime), N'0123456789', 1, N'demo@gmail.com', N'acong123', N'123456', CAST(N'2020-06-08 20:12:43.150' AS DateTime), N'admin', CAST(N'2020-06-08 20:12:43.150' AS DateTime), N'admin', 1)
SET IDENTITY_INSERT [dbo].[Staffs] OFF
SET IDENTITY_INSERT [dbo].[Steps] ON 

INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (1, N'Nha Trang', N'Hồng Thắm', N'Tham quan các khu vui chơi ở thành phố biển Nha Trang. Đi cáp treo tham quan Vinpearl', 1, 1, N'Ngày 1')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (2, N'Nha Trang', N'Hồng Thắm', N'Tham quan đảo Bình Ba ', 2, 1, N'Ngày 2')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (3, N'Phú Yên', N'Hồng Thắm', N'Di chuyển từ Nha Trang đến Phú Yên. Tham quan thành phố Tuy Hòa', 3, 1, N'Ngày 3')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (4, N'Đà Nẵng', N'Hồng Thắm', N'Tham quan Đà Nẵng', 4, 1, N'Ngày 4-5')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (5, N'Hồ Chí Minh', N'Mai Anh', N'Xuất phát từ Tp.HCM', 1, 2, N'Ngày 1')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (6, N'Nha Trang', N'Mai Anh', N'Tham quan các khu vui chơi ở Nha Trang', 2, 2, N'Ngày 2')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (7, N'Nha Trang', NULL, N'Nghỉ dưỡng tại Resort ABC', 3, 2, N'Ngày 3')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (8, N'Hồ Chí Minh', N'Công Định', N'Xuất phát', 1, 3, N'Ngày 1')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (9, N'Đà Lạt', N'Công Định', N'Mô tả', 2, 3, N'Ngày 2 - 3')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (10, N'Hồ Chí Minh', N'Thanh Tâm', N'Xuất phát', 1, 4, N'Ngày 1')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (11, N'Bangkok', N'Thanh Tâm', N'Tham quan biển ở Bangkok', 2, 4, N'Ngày 2 - 3')
INSERT [dbo].[Steps] ([ID], [Place], [GuideName], [Desc], [Rank], [Tour], [Name]) VALUES (12, N'Pattaya', N'Thanh Tâm', N'Di chuyển và nghỉ tại Pattaya(Thái)', 3, 4, N'Ngày 4-5')
SET IDENTITY_INSERT [dbo].[Steps] OFF
SET IDENTITY_INSERT [dbo].[Tours] ON 

INSERT [dbo].[Tours] ([ID], [Avatar], [Title], [Desc], [PlaceStart], [PlaceEnd], [Content], [DateStart], [EndDate], [DescTime], [Status], [Price]) VALUES (1, N'http://localhost:44351/Content/FileUploads/images/tours-travel1.jpg', N'Tour Nha Trang - Đà Nẵng 5N5D', N'Tour du lịch nghỉ dưỡng Nha Trang - Đà Nẵng 5 ngày 5 đêm dành cho 2 người trở lên.', N'Nha Trang', N'Đà Nẵng', N'<p>đang cập nhật</p>
', CAST(N'2020-07-01 00:00:00.000' AS DateTime), CAST(N'2020-07-06 00:00:00.000' AS DateTime), N'5 Ngày 5 Đêm', 1, 15500000)
INSERT [dbo].[Tours] ([ID], [Avatar], [Title], [Desc], [PlaceStart], [PlaceEnd], [Content], [DateStart], [EndDate], [DescTime], [Status], [Price]) VALUES (2, N'http://localhost:44351/Content/FileUploads/images/tours-travel2.jpg', N'Tour HCM - Nha Trang ', N'Tour HCM - Nha Trang ', N'Hồ Chí Minh', N'Nha Trang', N'<p>đang cập nhật</p>
', CAST(N'2020-07-08 00:00:00.000' AS DateTime), CAST(N'2020-07-11 00:00:00.000' AS DateTime), N'3N4D', 1, 8500000)
INSERT [dbo].[Tours] ([ID], [Avatar], [Title], [Desc], [PlaceStart], [PlaceEnd], [Content], [DateStart], [EndDate], [DescTime], [Status], [Price]) VALUES (3, N'http://localhost:44351/Content/FileUploads/images/tours-travel3.jpg', N'Tour HCM - Đà Lạt', N'Tour HCM - Đà Lạt', N'Hồ Chí Minh', N'Đà Lạt', N'<p>đang cập nhật</p>
', CAST(N'2020-07-06 00:00:00.000' AS DateTime), CAST(N'2020-07-09 00:00:00.000' AS DateTime), N'4N3D', 1, 7500000)
INSERT [dbo].[Tours] ([ID], [Avatar], [Title], [Desc], [PlaceStart], [PlaceEnd], [Content], [DateStart], [EndDate], [DescTime], [Status], [Price]) VALUES (4, N'http://localhost:44351/Content/FileUploads/images/tours-travel4.jpg', N'Tour Thái Lan', N'Tour Thái Lan', N'Hồ Chí Minh', N'Thái Lan', N'<p>đang cập nhật</p>
', CAST(N'2020-09-01 00:00:00.000' AS DateTime), CAST(N'2020-09-05 00:00:00.000' AS DateTime), N'5N4D', 1, 20000000)
SET IDENTITY_INSERT [dbo].[Tours] OFF
USE [master]
GO
ALTER DATABASE [TourBookingDB] SET  READ_WRITE 
GO
