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
		   ,5010994729585
           ,'Monopoly'
           ,'e3050e74-6d5f-4b86-851d-ddd94980c869'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),

		   ('b872d62e-9ec3-4db0-b4cc-ff14c4a9dc0f'
		   ,8710126039830
           ,'Rummikub'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('c5a4bf87-792d-4f00-976e-a048fef14f72'
		   ,4002051693602
           ,'Die Siedler von Catan'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Unterstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('0e155375-fa2d-47b7-8bd9-f6046b80cc7a'
		   ,4001504482589
           ,'Stone Age Junior'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Kindergarten'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('63b06571-6b71-40c7-9579-d6a4e75ef0c5'
		   ,4250231705588
           ,'Camel Cup'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Unterstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('2b6d8849-8832-441b-987e-7c6bd5637153'
		   ,3558380028123
           ,'Elysium'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('791086bf-3db3-449b-a661-18de2e705428'
		   ,4002051692339
           ,'Ubongo'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Unterstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('dfa8677f-a0ba-47e2-9aa8-c03a5c7b1e4c'
		   ,4250231754517
           ,'Village'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b'),
	   
	   	   ('78b90b82-a2fd-4b03-a367-6b3a2209f5b8'
		   ,3558380022244
           ,'Splendor'
           ,'9d61521b-01dc-4553-a8df-2a30626fc394'
           ,'Oberstufe'
           ,'f6009d89-7d13-4a72-b73b-6c224780882b')
GO


