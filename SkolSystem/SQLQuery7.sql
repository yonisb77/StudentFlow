-- 07_säkerhet.sql
USE SkolaDB;
GO

-- Skapa roll och user
CREATE ROLE SkolaReader;
GO

CREATE LOGIN SkolaAppLogin WITH PASSWORD='StarktLösenord123!';
CREATE USER SkolaAppUser FOR LOGIN SkolaAppLogin;
ALTER ROLE SkolaReader ADD MEMBER SkolaAppUser;
GO

-- Ge SELECT på views
GRANT SELECT ON vw_StudenterPublic TO SkolaReader;
GRANT SELECT ON vw_RegistreringarRapport TO SkolaReader;
GO
