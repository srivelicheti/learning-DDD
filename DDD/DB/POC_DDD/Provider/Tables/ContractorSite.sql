
CREATE TABLE [provider].[ContractorSite](
	[ID] [uniqueidentifier] primary key NOT NULL,
	[ContractorID] [uniqueidentifier] NOT NULL Foreign key References [provider].[Contractor] (ID),
	[SiteID] [uniqueidentifier] NOT NULL Foreign key References [provider].[Site] (ID),
	[RelationshipStatusCode] [char](1) NOT NULL,
	[ArrangedCareTypeCode] [char](1) NOT NULL,
	[AttendanceEntryIndicator] bit Not NULL default 0,
	[RelationshipEffectiveDate] [date] NOT NULL,
	[RelationshipEndDate] [date] NULL,
	[FirstInsertedByID] [varchar](128) NOT NULL,
	[FirstInsertedDateTime] [datetime] NOT NULL,
	[LastSavedByID] [varchar](128) NOT NULL,
	[LastSavedDateTime] [datetime] NOT NULL)