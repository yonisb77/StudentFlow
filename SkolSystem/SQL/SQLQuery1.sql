-- 01_skapa_databas.sql
-- Skapa databasen och sätt kontext

IF DB_ID('SkolaDB') IS NOT NULL
    DROP DATABASE SkolaDB;
GO

CREATE DATABASE SkolaDB;
GO

USE SkolaDB;
GO
