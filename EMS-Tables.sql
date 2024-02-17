USE [Event Management System]
GO

/****** Object:  Table [dbo].[Assets]    Script Date: 16-02-2024 11:00:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Assets](
	[AssetId] [int] IDENTITY(1,1) NOT NULL,
	[AssetName] [varchar](30) NULL,
	[AssetDescription] [varchar](100) NULL,
	[AssetCostPerDay] [money] NULL,
	[AssetStockAvailability] [int] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-----------------------------------------------------------------------------------------------------------------

USE [Event Management System]
GO

/****** Object:  Table [dbo].[EventAssets]    Script Date: 16-02-2024 11:00:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventAssets](
	[EventAssetId] [int] IDENTITY(1,1) NOT NULL,
	[EventBookingId] [int] NULL,
	[AssetId] [int] NULL,
	[Quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventAssetId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventAssets]  WITH CHECK ADD FOREIGN KEY([AssetId])
REFERENCES [dbo].[Assets] ([AssetId])
GO

ALTER TABLE [dbo].[EventAssets]  WITH CHECK ADD FOREIGN KEY([EventBookingId])
REFERENCES [dbo].[EventBookings] ([EventBookingId])
GO

-------------------------------------------------------------------------------------------------------------------------

USE [Event Management System]
GO

/****** Object:  Table [dbo].[EventBookings]    Script Date: 16-02-2024 11:01:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventBookings](
	[EventBookingId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [varchar](30) NULL,
	[MobileNumber] [varchar](15) NULL,
	[VenueId] [int] NULL,
	[EventDateTime] [datetime] NULL,
	[BookedHours] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EventBookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[EventBookings]  WITH CHECK ADD FOREIGN KEY([VenueId])
REFERENCES [dbo].[Venue] ([VenueId])
GO

-------------------------------------------------------------------------------------------------------------------------------

USE [Event Management System]
GO

/****** Object:  Table [dbo].[Venue]    Script Date: 16-02-2024 11:01:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venue](
	[VenueId] [int] IDENTITY(1,1) NOT NULL,
	[VenueName] [varchar](30) NULL,
	[VenueDescription] [varchar](30) NULL,
	[VenueCostPerHour] [money] NULL,
	[isDeleted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[VenueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

----------------------------------------------------------------------------------------------------------------------------------
