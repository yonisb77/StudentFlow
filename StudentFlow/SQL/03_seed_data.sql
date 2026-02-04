-- 03_testdata.sql
USE SkolaDB;
GO

-- Lägg till 10 studenter
INSERT INTO Studenter (Förnamn, Efternamn)
VALUES
('Anna','Andersson'),('Björn','Berg'),('Clara','Carlsson'),
('David','Dahl'),('Eva','Ek'),('Fredrik','Fors'),
('Gustav','Gustafsson'),('Hanna','Hedlund'),
('Isak','Isaksson'),('Johanna','Johansson');

-- Lägg till 6 kurser
INSERT INTO Kurser (Kursnamn)
VALUES
('Matematik'),('Svenska'),('Engelska'),
('Historia'),('Fysik'),('Kemi');

-- Lägg till 5 lärare
INSERT INTO Lärare (Förnamn, Efternamn)
VALUES
('Lars','Larsson'),('Maria','Magnusson'),
('Oskar','Olsson'),('Sara','Svensson'),
('Erik','Eklund');

-- Lägg till 3 klassrum
INSERT INTO Klassrum (Namn, MaxAntal)
VALUES
('A101',30),('B202',25),('C303',20);

-- Koppla kurser till klassrum
UPDATE Kurser SET KlassrumID = 1 WHERE KursID IN (1,2);
UPDATE Kurser SET KlassrumID = 2 WHERE KursID IN (3,4);
UPDATE Kurser SET KlassrumID = 3 WHERE KursID IN (5,6);

-- Lägg till registreringar (minst 25)
INSERT INTO Registreringar (StudentID, KursID, Betyg)
VALUES
(1,1,'G'),(1,2,'IG'),(1,3,'G'),(2,1,'G'),(2,2,'G'),
(2,4,'IG'),(3,2,'G'),(3,3,'G'),(3,5,'IG'),(4,1,'IG'),
(4,4,'G'),(4,6,'G'),(5,3,'G'),(5,5,'IG'),(5,6,'G'),
(6,1,'G'),(6,2,'G'),(6,4,'IG'),(7,2,'IG'),(7,3,'G'),
(7,5,'G'),(8,1,'G'),(8,3,'IG'),(8,6,'G'),(9,2,'G'),
(9,4,'IG'),(10,5,'G');
-- Totalt 27 registreringar

-- Koppla kurser till lärare
INSERT INTO KursLärare (KursID, LärareID)
VALUES
(1,1),(2,2),(3,3),(4,4),(5,5),(6,1),(1,2),(2,3);
