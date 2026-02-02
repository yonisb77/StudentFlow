-- 04_crud_exempel.sql
USE SkolaDB;
GO

-- INSERT
INSERT INTO Studenter (Förnamn, Efternamn) VALUES ('Kalle','Karlsson');

-- SELECT
SELECT * FROM Studenter;

-- UPDATE
UPDATE Studenter SET Efternamn='Karlqvist' WHERE StudentID=11;

-- DELETE
DELETE FROM Studenter WHERE StudentID=11;
