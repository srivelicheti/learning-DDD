	CREATE TABLE [provider].[SiteRate](
	[ID] [uniqueidentifier] primary key NOT NULL,
	[SiteID] [uniqueidentifier] NOT NULL Foreign key References [provider].[Site] (ID),
	[EffectiveDate] [date] NOT NULL,
	[AgeCode] [int] NOT NULL,
	[RegularCareWeeklyRate] [decimal](5, 2) NULL,
	[SpecialCareWeeklyRate] [decimal](5, 2) NULL,
	[RegularCareDailyRate] [decimal](5, 2) NULL,
	[SpecialCareDailyRate] [decimal](5, 2) NULL,
	[FirstInsertedByID] [varchar](128) NOT NULL,
	[FirstInsertedDateTime] [datetime] NOT NULL,
	[LastSavedByID] [varchar](128) NOT NULL,
	[LastSavedDateTime] [datetime] NOT NULL,
	[LogicalDeleteIndicator] bit NOT NULL)