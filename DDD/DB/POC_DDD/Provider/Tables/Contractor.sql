﻿CREATE TABLE [provider].[Contractor] (
    [ID] [uniqueidentifier] NOT NULL,
	[ContractorName] [nvarchar](50) NOT NULL,
	[DoingBusinessAs] [nvarchar](50) NOT NULL,
	[ContractStartDate] [date] NOT NULL,
	[ContractEndDate] [date] NULL,
	[Status] [nchar](1) NOT NULL,
	[PhoneNumber] [nvarchar](13) NOT NULL,
	[AlternatePhoneNumber] [nvarchar](13) NULL,
	[Type] [nchar](1) NOT NULL,
	[EinNumber] [nvarchar](11) NOT Null UNIQUE,
	[SuffixCode] [nchar](2) NULL,
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
	[ZipExntension] [nchar](4) NULL,
	[StateCode] [nchar](2) NOT NULL,
	[FirstInsertedBy] [nvarchar](50) NOT NULL,
	[FirstInsertedDateTime] DATETIME2(3) NOT NULL,
	[LastSavedBy] [nvarchar](50) NOT NULL,
	[LastSavedDateTime] DATETIME2(3) NOT NULL,
    [RowVersion] ROWVERSION NOT NULL, 
    CONSTRAINT [PK_Provider]].[Contractor] PRIMARY KEY CLUSTERED ([ID] ASC)
);

