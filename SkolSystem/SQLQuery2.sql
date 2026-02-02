-- 02_skapa_tabeller.sql
-- Skapa tabeller med PK, FK, constraints och default

USE SkolaDB;
GO

-- Studenter
CREATE TABLE Studenter (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    Förnamn NVARCHAR(50) NOT NULL,
    Efternamn NVARCHAR(50) NOT NULL,
    SkapadDatum DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Kurser
CREATE TABLE Kurser (
    KursID INT IDENTITY(1,1) PRIMARY KEY,
    Kursnamn NVARCHAR(100) NOT NULL,
    SkapadDatum DATETIME NOT NULL DEFAULT GETDATE(),
    KlassrumID INT NULL
);
GO

-- Klassrum
CREATE TABLE Klassrum (
    KlassrumID INT IDENTITY(1,1) PRIMARY KEY,
    Namn NVARCHAR(50) NOT NULL,
    MaxAntal INT NOT NULL,
    SkapadDatum DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Lärare
CREATE TABLE Lärare (
    LärareID INT IDENTITY(1,1) PRIMARY KEY,
    Förnamn NVARCHAR(50) NOT NULL,
    Efternamn NVARCHAR(50) NOT NULL,
    SkapadDatum DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- Registreringar (många-till-många mellan Studenter och Kurser)
CREATE TABLE Registreringar (
    RegistreringID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    KursID INT NOT NULL,
    Betyg CHAR(2) NULL CHECK (Betyg IN ('IG','G')),
    SkapadDatum DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Registreringar_Studenter FOREIGN KEY (StudentID)
        REFERENCES Studenter(StudentID) ON DELETE CASCADE,
    CONSTRAINT FK_Registreringar_Kurser FOREIGN KEY (KursID)
        REFERENCES Kurser(KursID) ON DELETE CASCADE
);
GO

-- KursLärare (många-till-många mellan Kurser och Lärare)
CREATE TABLE KursLärare (
    KursLärareID INT IDENTITY(1,1) PRIMARY KEY,
    KursID INT NOT NULL,
    LärareID INT NOT NULL,
    CONSTRAINT FK_KursLärare_Kurser FOREIGN KEY (KursID)
        REFERENCES Kurser(KursID) ON DELETE CASCADE,
    CONSTRAINT FK_KursLärare_Lärare FOREIGN KEY (LärareID)
        REFERENCES Lärare(LärareID) ON DELETE CASCADE
);
GO

-- Koppla Kurser till Klassrum (1:N)
ALTER TABLE Kurser
ADD CONSTRAINT FK_Kurser_Klassrum FOREIGN KEY (KlassrumID)
REFERENCES Klassrum(KlassrumID);
GO
