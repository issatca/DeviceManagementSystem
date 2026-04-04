USE DeviceManagement;
GO

IF NOT EXISTS (SELECT 1 FROM Users WHERE name = 'John Doe' AND role = 'Admin')
    INSERT INTO Users (name, role, location) VALUES('John Doe','Admin','New York')

IF NOT EXISTS (SELECT 1 FROM Users WHERE name = 'Jane Smith' AND role = 'Technician')
    INSERT INTO Users (name, role, location) VALUES('Jane Smith','Technician','London')

IF NOT EXISTS (SELECT 1 FROM Users WHERE name = 'Clarissa Telescu' AND role = 'Student')
    INSERT INTO Users (name, role, location) VALUES('Clarissa Telescu','Student','Cluj-Napoca')
GO

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'device1')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('device1', 'Apple', 'phone', 'iOS', '17', 'A17 Pro', 8, 'Admin Primary Phone', (SELECT TOP 1 id FROM Users WHERE name = 'John Doe'));

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'device2')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('device2', 'Microsoft', 'tablet', 'Windows', '11', 'SQ3', 16, 'Admin Management Tablet', (SELECT TOP 1 id FROM Users WHERE name = 'John Doe'));

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'device3')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('device3', 'Samsung', 'tablet', 'Android', '14', 'Exynos 2200', 8, 'Field Diagnostic Tablet', (SELECT TOP 1 id FROM Users WHERE name = 'Jane Smith'));

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'device4')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('device4', 'Apple', 'tablet', 'iOS', '17', 'M2', 8, 'Backup Diagnostic Tablet', (SELECT TOP 1 id FROM Users WHERE name = 'Jane Smith'));

IF NOT EXISTS (SELECT 1 FROM Devices WHERE name = 'device5')
    INSERT INTO Devices (name, manufacturer, type, operating_system, os_version, processor, ram_amount, description, userID)
    VALUES ('device5', 'Google', 'phone', 'Android', '14', 'Tensor G3', 12, 'Student Research Phone', (SELECT TOP 1 id FROM Users WHERE name = 'Clarissa Telescu'));
GO