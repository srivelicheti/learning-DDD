 
 CREATE TABLE [provider].[SiteHoliday](
	[ID] [uniqueidentifier] primary key  NOT NULL,
	[SiteID] [uniqueidentifier] NOT NULL Foreign key References [provider].[Site] (ID),
	[HolidayDate] [date] NOT NULL,
	[HolidayName] [varchar](100) NOT NULL,
	[CalendarYearDate] [nchar](4) NOT NULL,
	[FirstInsertedByID] [varchar](128) NOT NULL,
	[FirstInsertedDateTime] [datetime] NOT NULL,
	[LastSavedByID] [varchar](128) NOT NULL,
	[LastSavedDateTime] [datetime] NOT NULL)