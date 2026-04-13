USE DeviceManagement;
GO

IF NOT EXISTS (SELECT 1 FROM Users WHERE mail = 'djohn@prologis.com')
    INSERT INTO Users (name, mail, password, role, location)
    VALUES ('John Doe', 'djohn@prologis.com', 'Abcdef5657!', 'Team Lead', 'Santa Barbara');

IF NOT EXISTS (SELECT 1 FROM Users WHERE mail = 'clarissa.telescu@stud.ubbcluj.ro')
    INSERT INTO Users (name, mail, password, role, location)
    VALUES ('Clarissa Telescu', 'clarissa.telescu@stud.ubbcluj.ro', 'Anaaremere2212??', 'Student', 'Cluj-Napoca');

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'iPhone 13' AND manufacturer = 'Apple')    
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('iPhone 13', 'Apple', 'Phone', 'iOS', '15.0', 'A15 Bionic', 4, 'Standard black model', 7);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Galaxy S22' AND manufacturer = 'Samsung')    
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Galaxy S22', 'Samsung', 'Phone', 'Android', '12.0', 'Snapdragon 8 Gen 1', 8, 'Work phone', 7);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Pixel 7' AND manufacturer = 'Google')    
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Pixel 7', 'Google', 'Phone', 'Android', '13.0', 'Tensor G2', 8, 'Testing device', 8);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'iPad Air' AND manufacturer = 'Apple')    
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('iPad Air', 'Apple', 'Tablet', 'iPadOS', '16.1', 'M1', 8, 'Design tablet', 8);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Surface Pro 9' AND manufacturer = 'Microsoft')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Surface Pro 9', 'Microsoft', 'Tablet', 'Windows', '11', 'SQ3', 16, 'Portable workstation', 8);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Tab S8' AND manufacturer = 'Samsung')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Tab S8', 'Samsung', 'Tablet', 'Android', '12.0', 'Snapdragon 8 Gen 1', 8, 'Media tablet', NULL);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Xperia 5 IV' AND manufacturer = 'Sony')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Xperia 5 IV', 'Sony', 'Phone', 'Android', '12.0', 'Snapdragon 8 Gen 1', 8, 'Photography focus', NULL);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Redmi Note 11' AND manufacturer = 'Xiaomi')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Redmi Note 11', 'Xiaomi', 'Phone', 'Android', '11.0', 'Snapdragon 680', 4, 'Budget testing', NULL);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'OnePlus 10T' AND manufacturer = 'OnePlus')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('OnePlus 10T', 'OnePlus', 'Phone', 'Android', '12.0', 'Snapdragon 8+ Gen 1', 16, 'High performance', NULL);

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'Nokia T20' AND manufacturer = 'Nokia')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('Nokia T20', 'Nokia', 'Tablet', 'Android', '11.0', 'Unisoc T610', 4, 'Rugged tablet', NULL);
