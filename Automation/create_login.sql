USE [master]
GO
/****** Object:  Login [suvoda_user]    Script Date: 7/20/2017 3:07:29 PM ******/
CREATE LOGIN [suvoda_user] WITH PASSWORD=N'suvoda01', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER SERVER ROLE [sysadmin] ADD MEMBER [suvoda_user]
GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER [suvoda_user]
GO



USE [Nadezda.Salauyova];  
GO

/****** Object:  User [suvoda_user]    Script Date: 7/20/2017 3:12:59 PM ******/
CREATE USER [suvoda_user] FOR LOGIN [suvoda_user] WITH DEFAULT_SCHEMA=[dbo]
GO