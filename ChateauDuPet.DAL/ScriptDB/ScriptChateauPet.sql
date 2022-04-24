  Create database ChateauDuPetASP
  SELECT NmRecrutador, DsEmail, SenhaEmpresa, FKTipoUser idempresa FROM Empresa WHERE DsEmail='medeiros0441@gmail.com' AND SenhaEmpresa=00


  SELECT * FROM Profissional WHERE DsEmail='medeiros0441@gmail.com'
  SELECT * FROM Profissional WHERE DsEmail='medeiros0441@gmail.com'
  select * from Administrativo ; 
  select * from  Experiencia; 
  select * from  Candidatos; 
  delete Experiencia where FKProfissional=5  
  delete profissional where DsEmail='medeiros0441@gmail.com' 
  drop table profissional 
  select  * From profissional where dsemail='medeiros0442@gmail.com'
SELECT DsEmail  FROM Profissional WHERE DsEmail=  'medeiros0441@gmail.com'  SELECT  DsUser FROM Profissional WHERE    DsUser='medeiros0441'  SELECT NroCPF FROM Profissional WHERE   NroCPF='00000000000'  
                                  -- CRIANDO TABELAS E SEGUIDAMENTE SEUS DEVIDOS INSERTS --
SELECT * from Profissional where DsEmail ='medeiros0441@gmail.com'and  DsUser='medeiros0441' and NroCPF='00000000000' 

CREATE TABLE [dbo].[TipoUser]
(
    [IdTipoUser] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DescricaoUser] NVARCHAR(15) NOT NULL 

);
SELECT NMADM,SENHAADM,FKTIPOUSER FROM [Administrativo] WHERE NMADM='SAMUEL' AND SENHAADM='04411' 

INSERT INTO [TipoUser] VALUES('Empresa');
INSERT INTO [TipoUser] VALUES('Profissional');
INSERT INTO [TipoUser] VALUES('Administrativo');
SELECT * FROM Administrativo
SELECT dsEmail, SenhaADM, FKTipoUser FROM Administrativo WHERE dsEmail='medeiros0441@gmail.com' AND SenhaADM='04411'
-- Consulte TipoUser para ver numeração de tipo de usuário --

SELECT * FROM TipoUser
select * from vaga
-------------------------------------------------------------
ALTER TABLE  Empresa ADD DsUser VARCHAR(50) NULL
CREATE TABLE [dbo].[Administrativo]
(
    [IdAdministrativo] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NmADM] NVARCHAR(100) NOT NULL,
    [SenhaADM] NVARCHAR(15) NOT NULL ,
    [UrlImage] NVARCHAR(MAX) NULL ,
    [FKTipoUser] INT NOT NULL ,
    FOREIGN KEY (FKTipoUser) REFERENCES [TipoUser](IdTipoUser),
);
INSERT INTO [Administrativo] VALUES ('Ricardo','230316','~/Images/Ricardo.jpg',3);
INSERT INTO [Administrativo] VALUES ('Samuel','04411','~/Images/Samuel.jpg',3);
INSERT INTO [Administrativo] VALUES ('Lucas','250213','~/Images/Lucas.jpg',3);
INSERT INTO [Administrativo] VALUES ('Ryan','350922','~/Images/Ryan.jpg',3);
update  Administrativo set Usuario='medeiros0441@gmail.com' 
-- Consulte Administrativo para ver numeração de cada Adm --

SELECT * FROM Administrativo 

------------------------------------------------------------
select * from Profissional
drop database ChateauDuPetASP

CREATE TABLE [dbo].[Profissional]
(
    [IdProfissional] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NmProfissional] NVARCHAR(100) NOT NULL,
    [DsEmail] NVARCHAR(100) NOT NULL ,
    [NroCPF] NVARCHAR(11) NOT NULL,
    [SenhaProfissional] NVARCHAR(15) NOT NULL, 
    [NroTelefone] NVARCHAR(11) NOT NULL,
    [DsBiografia] NVARCHAR(300) NOT NULL ,
    [DtNascimento] DATETIME NOT NULL ,
    [FormacaoEscolar] NVARCHAR(30) NOT NULL, 
    [DsSexo] NVARCHAR(20) NOT NULL ,
    [DsEndereco] NVARCHAR(100) NOT NULL, 
    [NroEndereco] NVARCHAR(6) NOT NULL, 
    [DsComplemento] NVARCHAR(50) NOT NULL, 
    [DsCEP] NVARCHAR(10) NOT NULL,
    [DsBairro] NVARCHAR(50) NOT NULL,
    [DsCidade] NVARCHAR(50) NOT NULL ,
    [DsUF] NVARCHAR(2) NOT NULL ,
    [DtTermos] DATETIME NOT NULL, 
    [DsPrivacidade] DATETIME NOT NULL, 
    [UrlImage] varchar(max) NOT NULL ,
    [FKTipoUser] INT NOT NULL ,
    FOREIGN KEY (FKTipoUser) REFERENCES [TipoUser](IdTipoUser),
);

CREATE TABLE [dbo].[Profissional]
(
    [IdProfissional] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NmProfissional] NVARCHAR(100) NOT NULL,
    [DsEmail] NVARCHAR(100) NOT NULL ,
    [NroCPF] NVARCHAR(11) NOT NULL,
    [SenhaProfissional] NVARCHAR(15) NOT NULL, 
    [NroTelefone] NVARCHAR(11) NOT NULL,
    [DsBiografia] NVARCHAR(300) NOT NULL ,
    [DtNascimento] DATETIME NOT NULL ,
    [FormacaoEscolar] NVARCHAR(30) NOT NULL, 
    [DsSexo] NVARCHAR(20) NOT NULL ,
    [DsEndereco] NVARCHAR(100) NOT NULL, 
    [NroEndereco] NVARCHAR(6) NOT NULL, 
    [DsComplemento] NVARCHAR(50) NOT NULL, 
    [DsCEP] NVARCHAR(10) NOT NULL,
    [DsBairro] NVARCHAR(50) NOT NULL,
    [DsCidade] NVARCHAR(50) NOT NULL ,
    [DsUF] NVARCHAR(2) NOT NULL ,
    [DtTermos] DATETIME NOT NULL, 
    [DsPrivacidade] DATETIME NOT NULL, 
    [UrlImage] varchar(max) NOT NULL ,
    [FKTipoUser] INT NOT NULL ,
    FOREIGN KEY (FKTipoUser) REFERENCES [TipoUser](IdTipoUser),
    );
    update  profissional set IdProfissional=@1,NmProfissional =@2,DsEmail =@3 ,  NroCPF  =@4, SenhaProfissional =@5,  NroTelefone=@6,
    DsBiografia =@7 ,
    DtNascimento =@8 ,
    FormacaoEscolar =@9, 
    DsSexo =@10 ,
    DsEndereco =@11, 
    NroEndereco =@12, 
    DsComplemento =@13, 
    DsCEP =@14,
    DsBairro =@15,
    DsCidade =@16 ,
    DsUF =@17 ,
    DtTermos =@18, 
    DsPrivacidade=@19 ,
    UrlImage=@20, DsUser=@
 
INSERT INTO [Profissional] VALUES ('Jucelino Silva','JucelinoSilv@hotmail.com','44455566677','020500','911290115','No ramo de pet desde a infancia, apaixonado por animais','09/03/1995','Superior Completo','Masculino','Rua Alemeada Filho','47','Casa 3','08180180','Lajeado','São Paulo','SP','02/06/2021','02/06/2021','~/Images/Ricardo.jpg',2);
INSERT INTO [Profissional] VALUES ('Armando Pereira','ArmandosPereira@Outlook.com','33355566622','045322','911290117','Desde criança apaixonado pelos bichos do mundo','05/01/1995','Superior Completo','Masculino','Rua Quatro','155','Sem Complemento','08180150','Sao Martinho','São Paulo','SP','02/06/2021','02/06/2021','~/Images/dwassw.jpg',2);
INSERT INTO [Profissional] VALUES ('Jessica Ferreira','JeehFera@Outlook.com','33655894588','022200','911290112','Apaixonada por bichinhos fofinhos e defensora dos mesmos ','01/01/1995','Superior Completo','Feminino','Rua Dom Miguel','208','Casa 1','08180080','Sao Afoxe','São Paulo','SP','02/06/2021','02/06/2021','~/Images/Jeh.jpg',2);
INSERT INTO [Profissional] VALUES ('Caroline Cordeiro','CaahCord12@Gmail.com','57626543899','090320','955869445','Amante da profissao desde sempre e pra sempre','02/02/1995','Superior Completo','Feminino','Rua Seven','455','Ap35','08180155','Valinhos','São Paulo','SP','02/06/2021','02/06/2021','~/Images/CaaCord.jpg',2);
INSERT INTO [Profissional] VALUES ('Caroline Cordeiro','CaahCord12@Gmail.com','57626543899','090320','955869445','sexo',  2);
  
  select * from Profissional
  

-- Consulte Profissional para ver a informação de cada Profissional --
select * from Certificado;


SELECT * FROM Profissional

----------------------------------------------------------------------

CREATE TABLE [dbo].[Experiencia]
(
    [IdExperiencia] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DsCargo] NVARCHAR(50) NOT NULL ,
    [DsEmpresa] NVARCHAR(50) NOT NULL,
    [DsTipoContrato] NVARCHAR(15) NOT NULL, 
    [DsLocalidade] NVARCHAR(30) NOT NULL ,
    [DataInicio] DATETIME NOT NULL ,
    [DataFinal] DATETIME NOT NULL ,
    [FKProfissional] INT NOT NULL
    FOREIGN KEY (FKProfissional) REFERENCES [Profissional](IdProfissional),
    
);

INSERT INTO [Experiencia] VALUES ('Tosador de cachorros','Salvores do bem','CLT','São Paulo','2010-01-15','2020-01-15',24);
INSERT INTO [Experiencia] VALUES ('Auxiliar veterinario ','MedPet LTDA','CLT','São Paulo','2011-01-15','2021-01-15',24);
INSERT INTO [Experiencia] VALUES ('Tecnico de Raio X','aoInves Raio X Med','CLT','São Paulo','2015-01-15','2017-01-15',6);

-- Consulte Experinecia para ver a Experiencia de cada Profissional --

SELECT * FROM Experiencia 

----------------------------------------------------------------------
SELECT * FROM Certificado  WHERE [FKProfissional] = 4


CREATE TABLE [dbo].[Certificado]
(
    [IdCertificado] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [DsCurso] NVARCHAR(50) NOT NULL ,
    [DsInstituicao] NVARCHAR(100) NOT NULL,
    [DataInicio] DATETIME NOT NULL ,
    [DataConclusao] DATETIME NOT NULL,
    [DsDescricao] NVARCHAR(1000) NOT NULL ,
    [FKProfissional] INT NOT NULL,
    FOREIGN KEY (FKProfissional) REFERENCES [Profissional](IdProfissional),
);

 INSERT INTO [Certificado] VALUES ('Medico Veterinario','SENAC','2017-01-01','2020-01-01','A formação conta com atividades práticas e disciplinas teóricas na área da Saúde Pequenas cirurgias, consultas e exames são alguns dos exemplos',24);
 INSERT INTO [Certificado] VALUES ('Institutos de pesquisa','UNIP','2015-01-01','2019-01-01','A formação conta com atividades práticas e disciplinas teóricas na área da pesquisa',24);
 INSERT INTO [Certificado] VALUES ('Cirurgiao de peixes','Sumare','2011-01-01','2018-01-01','A formação conta com atividades na área cirúrgica o médico veterinário trabalha especificamente com operações em diversos tipos de animais como o peixe',5);
 INSERT INTO [Certificado] VALUES ('Cirurgiao de carnívoros','Anhanguera','2010-01-01','2015-01-01','A formação conta com atividades na área cirúrgica o médico veterinário trabalha especificamente com operações em diversos tipos de animais',6);

-- Consulte Certificado para ver o Certificado de cada Profissional --

SELECT * FROM Certificado

----------------------------------------------------------------------
 
CREATE TABLE [dbo].[Empresa]
(
    [IdEmpresa] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NmRecrutador] NVARCHAR(100) NOT NULL ,
    [NroCPF] NVARCHAR (11) NOT NULL,
    [DsEmail] NVARCHAR(100) NOT NULL ,
    [NroTelefone] NVARCHAR (12) NOT NULL ,
    [SenhaEmpresa] VARCHAR (15) NOT NULL,
    [DtNascimento] DATETIME NOT NULL ,
    [DsSexo] VARCHAR (15) NOT NULL,
    [DsEndereco] VARCHAR (50) NOT NULL ,
    [DsComplemento] VARCHAR (100) NOT NULL,
    [DsCep] NVARCHAR (9) NOT NULL ,
    [DsBairro] VARCHAR (50) NOT NULL,
    [DsCidade] NVARCHAR (50) NOT NULL ,
    [DsUF] NVARCHAR(13) NOT NULL,
    [NroCNPJ] NVARCHAR (50) NOT NULL,
    [DsNomeFantasia] NVARCHAR(100) NOT NULL,
    [DsRazaoSocial] NVARCHAR(100) NOT NULL,
    [DsDataAbertura] DATETIME  NOT NULL,
    [DtTermos] DATETIME NOT NULL,
    [DsPrivacidade] DATETIME NOT NULL,
    [UrlImage] NVARCHAR(MAX) NOT NULL,
    [FKTipoUser] INT NOT NULL,
     FOREIGN KEY (FKTipoUser) REFERENCES [TipoUser](IdTipoUser),
);
SELECT DsEmail, SenhaEmpresa, FKTipoUser FROM Empresa WHERE DsEmail=@v3 AND SenhaUsuario=@v5
INSERT INTO [Empresa] VALUES ('Felipe','23669856899','Felipesalvadoresdobem@gmail.com','955668647','230316','03-09-2001','Masculino','Rua Dom Miguel','Comercial 32','08180000','Tatuapé','Sao Paulo','SP','14.844.253/0002-37','Salvadores do bem','Salvadores do bem','01-01-2001','01-01-2005','01-01-2005','~/Images/slvdbem.jpg',1,2);
INSERT INTO [Empresa] VALUES ('Marcilia','55699866355','Marcilia22med@gmail.com','955668643','090321','01-09-2001','Feminino','Rua Augusta','Sem Complemento','15862158','Centro','Sao Paulo','SP','14.844.253/0002-20','Linha voadora Med','Linha voadora Med','02-03-2004','05-06-2007','05-06-2007','~/Images/mclsmed.jpg',1);
INSERT INTO [Empresa] VALUES ('Kathleen','56812348835','Kathms13@gmail.com','955668655','010502','01-09-1995','Feminino','Rua Teles','Comercial 12','18069080','Tatuape','Sao Paulo','SP','14.844.253/0001-15','MedPet LTDA','MedPet LTDA','02-03-2005','05-06-2006','05-06-2006','~/Images/petkath.jpg',1);
INSERT INTO [Empresa] VALUES ('Gabriely','33685458886','gabycac21@gmail.com','955668333','420420','08-03-2001','Feminino','Rua Terraseca','Sem Complemento','15862158','Centro','Sao Paulo','SP','14.844.253/0001-50','aoInves Raio X Med','aoInves Raio X Med','01-03-1999','05-06-2010','05-06-2011','~/Images/gbsxxx.jpg',1);

-- Consulte Empresa para ver as Empresas e seus devidos recrutadores --

Select * FROM Empresa

-----------------------------------------------------------------------
drop table Empresa

CREATE TABLE [dbo].[Vaga]
(
    [IdVaga] INT PRIMARY KEY IDENTITY (1,1) NOT NULL,
    [NmVaga] NVARCHAR(100)  NULL ,
    [DsExperiencia] NVARCHAR (50)  NULL,
    [DsTipoRegistro] NVARCHAR(15)  NULL ,
    [DsDescricao] NVARCHAR (4000)  NULL, 
    [DsSexo] NVARCHAR (20)  NULL, 
    [Validade] NVARCHAR (20)  NULL, 
    [DataPublicacao] DATETIME  NULL ,
    [FKEmpresa] INT NOT NULL ,
    [FKCandidatos] int  null,
    FOREIGN KEY (FKEmpresa) REFERENCES [Empresa](IdEmpresa), 
       
);

 INSERT into Vaga   (NmVaga  ,
    DsExperiencia,
    DsTipoRegistro,
    DsDescricao, 
    DsSexo, 
    Validade, 
    DataPublicacao,
    FKEmpresa)

 VALUES ('Médico Veterinário','No minimo 1 ano','CLT','responsável por cuidar e tratar bichos tanto de pequeno quanto de grande porte, podendo atender animais domésticos,como gato e cachorro, e também os silvestres','Indiferente','1 Mês','06-02-2021',2);


 INSERT INTO [Vaga] VALUES ('Zootécnico','No minimo 1 ano','CLT','deve estar apto para planejar e coordenar a criação de bovinos, suínos, ovinos e aves','Indiferente','1 Mês','06-02-2021',2,2);
 INSERT INTO [Vaga] VALUES ('Ecologista ','No minimo 2 ano','CLT','deve prezar pela manutenção dos ecossistemas e das cadeias alimentares','Indiferente','1 Mês','06-02-2021',4);
 INSERT INTO [Vaga] VALUES ('Oceanógrafo','No minimo 2 ano','CLT','preparados para lidar com as diferentes espécies do mar','Indiferente','1 Mês','06-02-2021',5);

-- Consulte Vaga para ver as Vagas Publicadas --
select * from Vaga  where FKCandidatos=2
Select Profissional, Candidatos  where idprofissional =2
  SELECT * FROM Profissional join Candidatos  on IdProfissional=IdProfissional where  FKVaga=2

SELECT * FROM Candidatos join Profissional on IdProfissional=IdProfissional where idempresa=2
SELECT * FROM Vaga join Profissional on IdProfissional=FKCandidatos where IdProfissional=24
SELECT * FROM Vaga   where FKEmpresa=2
 
------------------------------------------------
 drop table Candidatos
CREATE TABLE [dbo].[Candidatos]
(
    IdCandidatos int PRIMARY KEY  identity (1,1) not null,
    IdProfissional int NOT NULL,
    DsData DATETIME NOT NULL,
   FKVaga  INT NOT NULL ,
    idEmpresa INT NOT NULL ,
     FOREIGN KEY (IdEmpresa) REFERENCES [Empresa](IdEmpresa),
   foreign key (idProfissional) references  [Profissional](IdProfissional),
    FOREIGN KEY (FKvaga) REFERENCES Vaga (idvaga)
);
 select * from Empresa
 select * from Vaga
 select * from candidatos 
insert  into Candidatos (idprofissional,DsData,FKVaga,idEmpresa) values (24,28/08/2000,1,2);
insert  into Candidatos (idprofissional,DsData,IdVaga,idEmpresa) values (24,28/08/2000,1,2);
Select * from Vaga where FKCandidatos =2
select * from Candidatos  join Profissional on IdProfissional=IdProfissional where IdProfissional=24
Select * from Candidatos where idProfissional =24
select * from Candidatos

 select * from  Candidatos  join  profissional on IdProfissional=NmProfissional
 join Vaga on IdVaga=IdVaga
 join Empresa on idEmpresa=nmRecrutador
 ---------------------------- SELECTS (TESTES) ----------------------------

SELECT IdVaga, Vaga, Experiencia, Registro, Descricao, Sexo, Validade, BairroEndereco, DataPublicacao, FKEmpresa FROM Vaga JOIN Empresa ON FKEmpresa=IdVaga

SELECT * FROM Vaga ORDER BY NmVaga


SELECT IdVaga, NmVaga, SenhaUsuario, DsExperiencia, DsTipoRegistro, DsDescricao, DsSexo, Validade, DataPublicacao, FKEmpresa=IdEmpresa
Select * from Profissional
SELECT IdCertificado, DsCurso, DsInstituicao, DataInicio, DataConclusao, DsDescricao, FKProfissional FROM Certificado JOIN Profissional ON FKProfissional=IdCertificado
SELECT IdEmpresa, NmRecrutador, NroCPF, DsEmail, NroTelefone, SenhaEmpresa, DtNascimento, DsSexo, DsEndereco, DsComplemento, DsCep, DsBairro, DsCidade, DsUF, NroCNPJ, DsNomeFantasia, DsRazaoSocial, DsDataAbertura, DtTermos, DsPrivacidade, UrlImage, FKTipoUser FROM Empresa JOIN TipoUser ON FKTipoUser=IdEmpresa
SELECT IdProfissional, NmProfissional, DsEmail, NroCPF, SenhaProfissional, NroTelefone, DsBiografia, DtNascimento, FormacaoEscolar, DsSexo, DsEndereco, DsComplemento, DsCEP , DsBairro, DsCidade, DsUF, DtTermos, DsPrivacidade, UrlImage, FKTipoUser FROM Profissional JOIN TipoUser ON FKTipoUser=IdProfissiona


Select DsEmail,SenhaEmpresa from Empresa TipoUser

SELECT Email, Senha, FKTpUsuario  FROM TipoUser

Select * From TipoUse




SELECT Email, Senha, FKTpUsuario FROM TipoUsuario WHERE Email='Felipesalvadoresdobem@gmail.com'and Senha='23669856899' and FKTipoUser=3
