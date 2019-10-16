-- ************* SELECT TABLES ************* --

--  SELECT * FROM DonneesMedicamentsATU
--  SELECT * FROM ListeMedicamentsATU
--  SELECT * FROM ListeMedicamentsPostATU 

-- ************* DROP TABLES ************** --

-- DROP TABLE ListeMedicamentsPostATU 
-- DROP TABLE ListeMedicamentsATU
-- DROP TABLE DonneesMedicamentsATU 

-- ************* CREATE TABLES **************** --

CREATE TABLE [dbo].[DonneesMedicamentsATU] (
    [IdATU] INT IDENTITY(1,1) NOT NULL,
    [PostATU] CHAR(1) NOT NULL DEFAULT 'N',
    [ReserveHospitaliere] CHAR(1) NOT NULL DEFAULT 'N',
    [UCD7] NVARCHAR(50),
    [LibelleCodeUCD] NVARCHAR(2000),
    [CodeIndication] varchar(12),
    [IndicationATUCohorte] varchar(2000),
    [Laboratoire] NVARCHAR(2000) NOT NULL,
    [Medicament] NVARCHAR(2000),
    [DateDerniereMaj] DATETIME
	);
GO

ALTER TABLE [dbo].[DonneesMedicamentsATU]
ADD CONSTRAINT [PK_DonneesMedicamentsATU]
    PRIMARY KEY CLUSTERED ([IdATU] ASC);
GO


CREATE TABLE [dbo].[ListeMedicamentsATU]  (
	 [Id] INT IDENTITY(1,1) NOT NULL,
	 [IdMedicamentATU] INT NOT NULL,
	 [UCD13] NVARCHAR(13) NOT NULL,
	 [SubstanceActive] NVARCHAR(2000) NOT NULL,
	 [StatutATU] NVARCHAR(2000) NOT NULL,
	 [DateDebutATU] DATETIME,
	 [DateFinATU] DATETIME	 
);
GO

ALTER TABLE [dbo].[ListeMedicamentsATU]
ADD CONSTRAINT [PK_ListeMedicamentsATU]
    PRIMARY KEY CLUSTERED ([Id] ASC);

ALTER TABLE [dbo].[ListeMedicamentsATU]
ADD CONSTRAINT [FK_ListeMedicamentsATU]
	FOREIGN KEY ([IdMedicamentATU]) REFERENCES [dbo].[DonneesMedicamentsATU]([IdATU]);
GO


CREATE TABLE [dbo].[ListeMedicamentsPostATU]  (
	 [Id] INT IDENTITY(1,1) NOT NULL,
	 [IdMedicamentATU] INT NOT NULL,
	 [PostATUTermine] CHAR(1) NOT NULL DEFAULT 'N',
	 [UCD7ATUN] NUMERIC(18),
	 [UCD7ATUC] NVARCHAR(2000),
	 [DenominationCommune] NVARCHAR(2000),
	 [StatutAnterieur] NVARCHAR(2000),
	 [PriseEnChargePostATU] CHAR(1) NOT NULL DEFAULT 'N',
	 [InitierNouveauxTraitements] CHAR(1) NOT NULL DEFAULT 'N',
	 [Observations] NVARCHAR(2000),
	 [InscriptionRemboursement] CHAR(1),
	 [IndicationEvaluationDefavorable] NVARCHAR(2000) DEFAULT 'NON',
	 [ExtensionIndicationEnCours] NVARCHAR(2000) DEFAULT 'NON',
	 [ConclusionAvisHAS] NVARCHAR(2000),
	 [DateOctroiAMM] DATETIME,
	 [DateDebutPostATU] DATETIME,
	 [DateFinPostATU] DATETIME	 
);

GO

ALTER TABLE [dbo].[ListeMedicamentsPostATU]
ADD CONSTRAINT [PK_ListeMedicamentsPostATU]
    PRIMARY KEY CLUSTERED ([Id] ASC);
ALTER TABLE [dbo].[ListeMedicamentsPostATU]
ADD CONSTRAINT FK_IdMedicamentPostATU
	FOREIGN KEY (IdMedicamentATU) REFERENCES [dbo].[DonneesMedicamentsATU](IdATU);
GO


-- ******* ORDRE INSERT TABLE ********-
-- 1- INSERT TableDonneesATUINSERT.sql
-- 2- INSERT TableListMedicamentsATUINSERT.sql
-- 3- INSERT TablePostATUListINSERT.sql
-- 4- INSERT TablePostATUListMedINSERT.sql
-- 5- INSERT TablePostATUTermineListINSERT.sql
-- 6- INSERT TablePostATUTermineListMedINSERT.sql




