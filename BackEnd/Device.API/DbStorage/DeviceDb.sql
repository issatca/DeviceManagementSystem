IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DeviceManagement')
BEGIN
   CREATE DATABASE DeviceManagement;
END
GO

USE DeviceManagement

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users
    (
        id INT IDENTITY(1,1) PRIMARY KEY,
        name NVARCHAR(255) NOT NULL,
        mail NVARCHAR(255) NOT NULL,
        password NVARCHAR(255) NOT NULL,
        role NVARCHAR(100) NOT NULL,
        location NVARCHAR(100) NOT NULL
    );
END
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Devices]') AND type in (N'U'))
BEGIN
CREATE TABLE Devices
(
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    manufacturer NVARCHAR(255) NOT NULL,
    type NVARCHAR(50) NOT NULL,
    operating_system NVARCHAR(100) NOT NULL,
    os_version NVARCHAR(50) NOT NULL,
    processor NVARCHAR(100) NOT NULL,
    ram_amount INT NOT NULL,
    description NVARCHAR(MAX) NOT NULL,
    userID INT,
    CONSTRAINT fk_user FOREIGN KEY (userID) REFERENCES Users(id)
);
END
GO