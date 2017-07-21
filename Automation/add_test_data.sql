USE [Nadezda.Salauyova];  
GO

------------------ [Country] -------------------

INSERT INTO [dbo].[Country]
           ([CountryName])
     VALUES
           ('Romania'  --<CountryName, nchar(50),>
		   )

		   INSERT INTO [dbo].[Country]
           ([CountryName])
     VALUES
           ('USA'  --<CountryName, nchar(50),>
		   )

		      INSERT INTO [dbo].[Country]
           ([CountryName])
     VALUES
           ('UK'  --<CountryName, nchar(50),>
		   )

		   		      INSERT INTO [dbo].[Country]
           ([CountryName])
     VALUES
           ('Russia'  --<CountryName, nchar(50),>
		   )
		   
		   
		   
--------------- [Depot] -------------------	
	   
		   INSERT INTO [dbo].[Depot]
           ([DepotName]
           ,[DepotLocation])
     VALUES
           ('Depot1' --<DepotName, nchar(50),>
           , 1 --<DepotLocation, int,>
		   )

		   INSERT INTO [dbo].[Depot]
           ([DepotName]
           ,[DepotLocation])
     VALUES
           ('Depot2' --<DepotName, nchar(50),>
           , 2 --<DepotLocation, int,>
		   )
		   
		   
  		   INSERT INTO [dbo].[Depot]
           ([DepotName]
           ,[DepotLocation])
     VALUES
           ('Depot3' --<DepotName, nchar(50),>
           , 1 --<DepotLocation, int,>
		   )

		   INSERT INTO [dbo].[Depot]
           ([DepotName]
           ,[DepotLocation])
     VALUES
           ('Depot4' --<DepotName, nchar(50),>
           , 2 --<DepotLocation, int,>
		   )
		   
		   
		   
-------------------- [DrugType] -------------------		
   
		   INSERT INTO [dbo].[DrugType]
           ([DrugTypeName]
           ,[Weight])
     VALUES
           ('Type1' --<DrugTypeName, nchar(250),>
           ,22.5 --<Weight, numeric(16,2),>		   
		   )

		   INSERT INTO [dbo].[DrugType]
           ([DrugTypeName]
           ,[Weight])
     VALUES
           ('Type2' --<DrugTypeName, nchar(250),>
           ,0.5 --<Weight, numeric(16,2),>		   
		   )

		   		   INSERT INTO [dbo].[DrugType]
           ([DrugTypeName]
           ,[Weight])
     VALUES
           ('Type3' --<DrugTypeName, nchar(250),>
           ,0.25 --<Weight, numeric(16,2),>		   
		   )
		   
		   
---------------------- [DrugUnit] -------------------		   
	 
GO  
CREATE PROCEDURE dbo.PopulateDrugUnits  
AS 

declare @counter int;

set @counter = 1;  
  WHILE (@counter < 51)  
BEGIN  
  INSERT INTO [dbo].[DrugUnit]
           ([PickNumber]
           ,[DrugTypeId]
           ,[DepotId])
     VALUES
           (@counter -- <PickNumber, int,>
           ,1 -- <DrugTypeId, int,>
           ,null -- <DepotId, int,>
		   )
		   set @counter = @counter + 1
 		   
END  

set @counter = 1;
 WHILE (@counter < 51)  
BEGIN  
  INSERT INTO [dbo].[DrugUnit]
           ([PickNumber]
           ,[DrugTypeId]
           ,[DepotId])
     VALUES
           (@counter -- <PickNumber, int,>
           ,2 -- <DrugTypeId, int,>
           ,null -- <DepotId, int,>
		   ) 
		   set @counter = @counter + 1
		   
END  

set @counter = 1;
 WHILE (@counter < 51)  
BEGIN  
  INSERT INTO [dbo].[DrugUnit]
           ([PickNumber]
           ,[DrugTypeId]
           ,[DepotId])
     VALUES
           (@counter -- <PickNumber, int,>
           ,3 -- <DrugTypeId, int,>
           ,null -- <DepotId, int,>
		   ) 
		   set @counter = @counter + 1
END


GO 

exec  dbo.PopulateDrugUnits

GO

DROP PROCEDURE IF EXISTS dbo.PopulateDrugUnits
		 
GO