CREATE DATABASE PositionSharing;
GO

USE PositionSharing;
GO
CREATE LOGIN SecureExecuter   
	WITH PASSWORD = 'k6UwAf4K*puBTEb^';  
CREATE USER SecureExecuter FOR LOGIN SecureExecuter;  
GO
GO
USE PositionSharing;
CREATE TABLE GroupTable(
	GroupName NVARCHAR(255) NOT NULL,
	GroupKey NVARCHAR(255) NOT NULL,
	PRIMARY KEY(GroupKey),
);
CREATE TABLE UserTable(
	UserGroupKey NVARCHAR(255) NOT NULL,
	GroupKey NVARCHAR(255) NOT NULL,
	PRIMARY KEY(UserGroupKey),
	FOREIGN KEY (GroupKey) REFERENCES GroupTable(GroupKey),
);
GO

CREATE PROCEDURE SPInsertGroup @name NVARCHAR(255), @GroupKey NVARCHAR(255)
AS
	INSERT INTO GroupTable(GroupName,GroupKey) VALUES (@name,@GroupKey);
GO

CREATE PROCEDURE SPContainsGroup @GroupKey NVARCHAR(255)
AS
	SELECT 1 FROM GroupTable where @GroupKey = GroupKey 
GO

CREATE PROCEDURE SPAddUserToGroup @GroupKey NVARCHAR(255), @UserGroupKey NVARCHAR(255)
AS
	INSERT INTO UserTable (GroupKey, UserGroupKey) VALUES (@GroupKey, @UserGroupKey)
GO

CREATE PROCEDURE SPDeleteUser @GroupKey NVARCHAR(255), @UserGroupKey NVARCHAR(255)
AS
	DELETE FROM UserTable WHERE UserGroupKey = @UserGroupKey AND GroupKey = @GroupKey
GO
USE PositionSharing;
GRANT EXECUTE ON dbo.SPInsertGroup TO SecureExecuter;
GRANT EXECUTE ON dbo.SPContainsGroup TO SecureExecuter;
GRANT EXECUTE ON dbo.SPAddUserToGroup TO SecureExecuter;
GRANT EXECUTE ON dbo.SPDeleteUser TO SecureExecuter;