USE [LudothekDb]
GO

INSERT INTO [dbo].[Verband]
           ([VerbandKeyGUID]
           ,[Name]
           ,[Region])
     VALUES
           ('b6f8bb5e-14e6-4c7c-8c95-b4b74a7159b8'
           ,'LUOZ'
           ,'Ostschweiz')
GO

INSERT INTO [dbo].[Filiale]
           ([FilialKeyGUID]
           ,[Vereinsname]
           ,[Strasse]
           ,[Ort]
           ,[PLZ]
           ,[FK_Verband])
     VALUES
           ('f6009d89-7d13-4a72-b73b-6c224780882b'
           ,'Ludothek Spielgut'
           ,'Veltur 3'
           ,'Sevelen'
           ,9475
           ,'b6f8bb5e-14e6-4c7c-8c95-b4b74a7159b8')
GO



INSERT INTO [dbo].[Tarifkategorie]
           ([TarifkategorieKeyGUID]
           ,[Bezeichnung]
           ,[Preis])
     VALUES
           ('e3050e74-6d5f-4b86-851d-ddd94980c869'
           ,'Tarifkategorie 1'
           ,25.50),
		   ('5952683d-1711-4bef-8ebb-96a1b7a35f62'
           ,'Tarifkategorie 2'
           ,49.90),
		   ('9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Tarifkategorie 3'
           ,75.50)
GO

INSERT INTO [dbo].[Spiel]
           ([SpielKeyGUID]
           ,[EANNummer]
           ,[Name]
           ,[FK_Tarifkategorie]
           ,[Spielkategorie]
           ,[FK_Filiale])
     VALUES
       
	   	   ('78b90b82-a2fd-4b03-a367-6b3a2209f5b8'
		   ,355838
           ,'Splendor'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b')
GO


