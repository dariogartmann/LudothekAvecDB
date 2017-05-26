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
           ('65e7be68-d30f-4811-a1aa-49fbcfc7b1a6'
		   ,403557
           ,'Monopoly'
           ,'e3050e74-6d5f-4b86-851d-ddd94980c869'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),

		   ('b872d62e-9ec3-4db0-b4cc-ff14c4a9dc0f'
		   ,489232
           ,'Cards Against Humanity'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b')
GO


