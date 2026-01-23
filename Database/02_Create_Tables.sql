USE UMS_DB
GO

CREATE TABLE auth.avUsers
(UserId INT IDENTITY(1,1) PRIMARY KEY,
FirstName NVARCHAR(100) NOT NULL,
LastName NVARCHAR(100) NOT NULL,
Email NVARCHAR(256) NOT NULL UNIQUE,
PasswordHash NVARCHAR(500) NOT NULL,
IsActive BIT NOT NULL DEFAULT 1,
CreatedOn DATETIME2 NOT NULL DEFAULT GETDATE(),
CreatedBy NVARCHAR(100),
UpdatedOn DATETIME2 NULL,
UpdatedBy NVARCHAR(100)
);
***********************************
USE UMS_DB
GO

CREATE TABLE auth.avRoles
(RoleId INT IDENTITY(1,1) PRIMARY KEY,
RoleName NVARCHAR(50) NOT NULL UNIQUE
);

***********************************
USE UMS_DB
GO

CREATE TABLE auth.avUserRoles
(UserRoleId INT IDENTITY(1,1) PRIMARY KEY,
UserId INT NOT NULL,
RoleId INT NOT NULL,
CONSTRAINT FK_avUserRoles_avUsers FOREIGN KEY(UserId) REFERENCES auth.avUsers(UserId),
CONSTRAINT FK_avUserRoles_avRoles FOREIGN KEY(RoleId) REFERENCES auth.avRoles(RoleId),
CONSTRAINT UQ_UserRole UNIQUE (UserId,RoleId)
);
