-- 05_queries_joins.sql
USE SkolaDB;
GO

-- 1. JOIN: Studenter med deras registreringar
SELECT s.Förnamn, s.Efternamn, k.Kursnamn, r.Betyg
FROM Studenter s
JOIN Registreringar r ON s.StudentID = r.StudentID
JOIN Kurser k ON r.KursID = k.KursID;

-- 2. JOIN: Kurser med lärare
SELECT k.Kursnamn, l.Förnamn, l.Efternamn
FROM Kurser k
JOIN KursLärare kl ON k.KursID = kl.KursID
JOIN Lärare l ON kl.LärareID = l.LärareID;

-- 3. JOIN: Kurser med klassrum
SELECT k.Kursnamn, kr.Namn AS Klassrum
FROM Kurser k
JOIN Klassrum kr ON k.KlassrumID = kr.KlassrumID;

-- 4. JOIN: Studenter med kurser och lärare
SELECT s.Förnamn, s.Efternamn, k.Kursnamn, l.Förnamn AS LärareFörnamn
FROM Studenter s
JOIN Registreringar r ON s.StudentID = r.StudentID
JOIN Kurser k ON r.KursID = k.KursID
JOIN KursLärare kl ON k.KursID = kl.KursID
JOIN Lärare l ON kl.LärareID = l.LärareID;

-- 5. GROUP BY: antal studenter per kurs
SELECT k.Kursnamn, COUNT(r.StudentID) AS AntalStudenter
FROM Kurser k
JOIN Registreringar r ON k.KursID = r.KursID
GROUP BY k.Kursnamn;

-- 6. GROUP BY: antal kurser per lärare
SELECT l.Förnamn, l.Efternamn, COUNT(kl.KursID) AS AntalKurser
FROM Lärare l
JOIN KursLärare kl ON l.LärareID = kl.LärareID
GROUP BY l.Förnamn, l.Efternamn;

-- 7. WHERE + ORDER BY: Studenter med IG
SELECT s.Förnamn, s.Efternamn, k.Kursnamn, r.Betyg
FROM Registreringar r
JOIN Studenter s ON r.StudentID = s.StudentID
JOIN Kurser k ON r.KursID = k.KursID
WHERE r.Betyg='IG'
ORDER BY s.Efternamn, s.Förnamn;

-- 8. Rapport: senaste 20 registreringar
SELECT TOP 20 s.Förnamn, s.Efternamn, k.Kursnamn, r.Betyg, r.SkapadDatum
FROM Registreringar r
JOIN Studenter s ON r.StudentID = s.StudentID
JOIN Kurser k ON r.KursID = k.KursID
ORDER BY r.SkapadDatum DESC;
