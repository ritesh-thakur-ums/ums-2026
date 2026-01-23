CREATE DATABASE UMS_DB
GO

************************************
SELECT name
FROM sys.databases
WHERE name = 'UMS_DB';
***********************************
USE UMS_DB
GO

CREATE SCHEMA auth;
GO
*************************************
USE UMS_DB
GO

SELECT name
FROM sys.schemas
WHERE name = 'auth';
************************************

