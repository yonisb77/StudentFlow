-- 06_views.sql
USE SkolaDB;
GO

-- Public view: döljer SkapadDatum
CREATE VIEW vw_StudenterPublic AS
SELECT StudentID, Förnamn, Efternamn
FROM Studenter;
GO

-- Report view: för appen
CREATE VIEW vw_RegistreringarRapport AS
SELECT s.Förnamn, s.Efternamn, k.Kursnamn, r.Betyg, r.SkapadDatum
FROM Registreringar r
JOIN Studenter s ON r.StudentID = s.StudentID
JOIN Kurser k ON r.KursID = k.KursID;
GO
