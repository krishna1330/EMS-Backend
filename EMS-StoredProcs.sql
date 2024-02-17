USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[AddAsset]    Script Date: 16-02-2024 11:02:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

    
CREATE proc [dbo].[AddAsset]         
 @assetName VARCHAR(20),       
    @assetDescription VARCHAR(100),       
    @assetCostPerDay money,      
    @assetStockAvailability VARCHAR(100)      
AS      
BEGIN      
    
insert into Assets(AssetName, AssetDescription, AssetCostPerDay, AssetStockAvailability, isDeleted)    
values (@assetName, @assetDescription, @assetCostPerDay, @assetStockAvailability, 0)    
    
end
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[AddVenue]    Script Date: 16-02-2024 11:02:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddVenue]          
    @venueName VARCHAR(20),         
    @venueDescription VARCHAR(100),         
    @venueCostPerHour MONEY    
AS        
BEGIN        
    INSERT INTO Venue (VenueName, VenueDescription, VenueCostPerHour, isDeleted)      
    VALUES (@venueName, @venueDescription, @venueCostPerHour, 0)      
END
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[DeleteAsset]    Script Date: 16-02-2024 11:03:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[DeleteAsset]
    @assetId INT
	as begin
	update Assets set isDeleted = 1 where AssetId = @assetId
	end
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[DeleteVenue]    Script Date: 16-02-2024 11:03:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[DeleteVenue]  
    @venueId INT  
 as begin  
 update Venue set isDeleted = 1 where VenueId = @venueId  
 end
GO


USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[EditAsset]    Script Date: 16-02-2024 11:03:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditAsset] 
    @assetId INT, 
    @assetName VARCHAR(20), 
    @assetDescription VARCHAR(100), 
    @assetCostPerDay money,
    @assetStockAvailability VARCHAR(100)
AS
BEGIN
    UPDATE Assets 
    SET 
        AssetName = @assetName, 
        AssetDescription = @assetDescription,
        AssetCostPerDay = @assetCostPerDay, 
        AssetStockAvailability = @assetStockAvailability
    WHERE AssetId = @assetId;
END
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[EditVenue]    Script Date: 16-02-2024 11:03:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditVenue]   
    @venueId INT,   
    @venueName VARCHAR(20),   
    @venueDescription VARCHAR(100),   
    @venueCostPerHour money
AS  
BEGIN  
    UPDATE Venue   
    SET   
        VenueName = @venueName,   
        VenueDescription = @venueDescription,  
        VenueCostPerHour = @venueCostPerHour
    WHERE VenueId = @venueId;  
END 
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[GetAllAssets]    Script Date: 16-02-2024 11:04:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetAllAssets]  
as begin  
select AssetId, AssetName, AssetDescription, AssetCostPerDay, AssetStockAvailability from Assets  
where isDeleted = 0
end
GO


USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[GetBookings]    Script Date: 16-02-2024 11:04:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[GetBookings]
as begin
select eb.EventBookingId, eb.CustomerName, eb.MobileNumber, v.VenueName, eb.VenueId, eb.EventDateTime, eb.BookedHours from EventBookings eb
join Venue v
on eb.VenueId = v.VenueId
end
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[GetVenues]    Script Date: 16-02-2024 11:04:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[GetVenues]    
as begin    
select VenueId, VenueName, VenueDescription, VenueCostPerHour from Venue    
where isDeleted = 0  
end
GO

USE [Event Management System]
GO

/****** Object:  StoredProcedure [dbo].[AddEventAsset]    Script Date: 17-02-2024 15:39:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddEventAsset] @eventBookingId int, @assetId int, @quantity int
as begin
insert into EventAssets(EventBookingId, AssetId, Quantity)
values(@eventBookingId, @assetId, @quantity)
end
GO



