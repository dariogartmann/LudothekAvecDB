CREATE DATABASE LudothekDb;
GO

USE LudothekDb;
GO

-- Verband
CREATE TABLE dbo.Verband
   (VerbandKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,  
    Name varchar(255) NOT NULL,  
    Region varchar(255) NOT NULL);
GO  

-- Filiale
CREATE TABLE dbo.Filiale
   (FilialKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,  
    Vereinsname varchar(255) NOT NULL,  
    Strasse varchar(255) NOT NULL,
    Ort varchar(255) NOT NULL,
    PLZ INT NOT NULL,
    FK_Verband UNIQUEIDENTIFIER NOT NULL, 

    FOREIGN KEY (FK_Verband) REFERENCES dbo.Verband (VerbandKeyGUID));
GO  

-- Mitarbeiter
CREATE TABLE dbo.Mitarbeiter 
   (AHVNummer INT PRIMARY KEY NOT NULL,
    Vorname varchar(255) NOT NULL,  
    Nachname varchar(255) NOT NULL,  
    Strasse varchar(255) NOT NULL,  
    Ort varchar(255) NOT NULL,  
    PLZ INT NOT NULL,  
    IstFilialleiter BIT NOT NULL DEFAULT 0,
    IstStellvertreter BIT NOT NULL DEFAULT 0,
    IstVerbandvorstandsmitglied BIT NOT NULL DEFAULT 0,
    IstFilialvorstandsmitglied BIT NOT NULL DEFAULT 0,
    FK_Filiale UNIQUEIDENTIFIER NOT NULL, 

    FOREIGN KEY (FK_Filiale) REFERENCES dbo.Filiale (FilialKeyGUID));
GO

-- Kunde
CREATE TABLE dbo.Kunde 
   (KundenKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Vorname varchar(255) NOT NULL,  
    Nachname varchar(255) NOT NULL,  
    Geburtsdatum date NOT NULL,  
    Strasse varchar(255) NOT NULL,  
    Ort varchar(255) NOT NULL,  
    PLZ INT NOT NULL,  
    IstFilialvorstandsmitglied BIT NOT NULL DEFAULT 0,
    FK_Filiale UNIQUEIDENTIFIER NOT NULL, 

    FOREIGN KEY (FK_Filiale)REFERENCES dbo.Filiale (FilialKeyGUID));
GO

-- Tarifkategorie
CREATE TABLE dbo.Tarifkategorie 
   (TarifkategorieKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Bezeichnung varchar(255) NOT NULL,  
    Preis DECIMAL NOT NULL); 
GO

-- Spiel
CREATE TABLE dbo.Spiel
   (SpielKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    EANNummer INT NOT NULL,  
    Name varchar(255) NOT NULL,  
    FK_Tarifkategorie UNIQUEIDENTIFIER NOT NULL,
    Spielkategorie VARCHAR(255) NOT NULL CHECK (Spielkategorie IN('Kindergarten', 'Unterstufe', 'Oberstufe')),
    FK_Filiale UNIQUEIDENTIFIER NOT NULL, 

    FOREIGN KEY (FK_Filiale) REFERENCES dbo.Filiale (FilialKeyGUID),
    FOREIGN KEY (FK_Tarifkategorie) REFERENCES dbo.Tarifkategorie (TarifkategorieKeyGUID));
GO

-- Ausleihe
CREATE TABLE dbo.Ausleihe
   (AusleiheKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    Startdatum DATETIME2 NOT NULL,  
    Enddatum DATETIME2 NOT NULL,  
    FK_Kunde UNIQUEIDENTIFIER NOT NULL,
    FK_Spiel1 UNIQUEIDENTIFIER NOT NULL,
    FK_Spiel2 UNIQUEIDENTIFIER NULL,
    FK_Spiel3 UNIQUEIDENTIFIER NULL,

    FOREIGN KEY (FK_Kunde) REFERENCES dbo.Kunde (KundenKeyGUID),
    FOREIGN KEY (FK_Spiel1) REFERENCES dbo.Spiel (SpielKeyGUID),
    FOREIGN KEY (FK_Spiel2) REFERENCES dbo.Spiel (SpielKeyGUID),
    FOREIGN KEY (FK_Spiel3) REFERENCES dbo.Spiel (SpielKeyGUID));
GO

-- Verlag
CREATE TABLE dbo.Verlag
   (VerlagKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,  
    Name varchar(255) NOT NULL,  
    Strasse varchar(255) NOT NULL,  
    Ort varchar(255) NOT NULL,  
    PLZ INT NOT NULL)  
GO  

-- Bestellung
CREATE TABLE dbo.Bestellung
   (Referenznummer INT PRIMARY KEY NOT NULL,
    Datum DATETIME2 NOT NULL,  
    FK_Mitarbeiter INT NOT NULL,
    FK_Filiale UNIQUEIDENTIFIER NOT NULL,
    FK_Verlag UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY (FK_Mitarbeiter) REFERENCES dbo.Mitarbeiter (AHVNummer),
    FOREIGN KEY (FK_Filiale) REFERENCES dbo.Filiale (FilialKeyGUID),
    FOREIGN KEY (FK_Verlag) REFERENCES dbo.Verlag (VerlagKeyGUID));
GO

-- Spielbestellung
CREATE TABLE dbo.SpielBestellung
   (SpielBestellungKeyGUID UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    FK_Bestellung INT NOT NULL,
    FK_Spiel UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY (FK_Bestellung) REFERENCES dbo.Bestellung (Referenznummer),
    FOREIGN KEY (FK_Spiel) REFERENCES dbo.Spiel (SpielKeyGUID));
GO

-- Index: Spiel.Spielkategorie 
CREATE NONCLUSTERED INDEX INDEX_Spielkategorie   
    ON Spiel (Spielkategorie);   
GO 