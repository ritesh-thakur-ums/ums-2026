USE UMS_DB
GO

INSERT INTO auth.avRoles(RoleName)
VALUES ('Admin'), ('User');
***********************************
USE UMS_DB
GO

SELECT * FROM auth.avUsers;
SELECT * FROM auth.avRoles;
SELECT * FROM auth.avUserRoles;