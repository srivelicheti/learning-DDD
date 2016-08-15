CREATE TABLE [provider].[Site](
	[ID] [uniqueidentifier] NOT NULL,
	[SiteNumber] [Int] NOT NULL,
	[SiteName] [nvarchar](50) NOT NULL,
	[ContractStartDate] [date] NOT NULL,
	[ContractEndDate] [date] NULL,
	[StatusCode] [nchar](1) NOT NULL,
	[LicencingStatusCode] [nchar](1) NOT NULL,
	[LicenseNumber] [int] NULL,
	[IsWebEnabled] bit Not NULL default 1,
	[PhoneNumber] [nvarchar](13) NOT NULL,
	[AlternatePhoneNumber] [nvarchar](13) NULL,
	[SiteFacilityTypeCode] [nchar](2) NOT NULL,
	[SiteTypeCode] [nchar](1) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[ContactFirstName] [nvarchar](50) NOT NULL,
	[ContactLastName] [nvarchar](50) NOT NULL,
	[ContactPhoneNumber] [nvarchar](13) NOT NULL,
	[ContactAlternatePhoneNumber] [nvarchar](10) NULL,
	[ContactEmail] [nvarchar](50) NULL,
	[AddressLine1] [nvarchar](150) NOT NULL,
	[AddressLine2] [nvarchar](150) NULL,
	[City] [nvarchar](50) NOT NULL,
	[ZipCode] [nchar](5) NOT NULL,
	[CountyCode] [nchar](2) NOT NULL,
	[ZipExtension] [nchar](4) NULL,
	[CountyServedCode] [nchar](2) NOT NULL,
	[StateCode] [nchar](2) NOT NULL,
	[FirstInsertedBy] [nvarchar](50) NOT NULL,
	[FirstInsertedDateTime] DATETIME2(3) NOT NULL,
	[LastSavedBy] [nvarchar](50) NOT NULL,
	[LastSavedDateTime] DATETIME2(3) NOT NULL,
 CONSTRAINT [PK_Provider]].[SITE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[SiteNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]