-- =============================================================================
-- Chateau Du Pet: dados de demonstração
-- Rode depois do schema.sql. Todos os dados são fictícios.
--
-- Contas de demonstração (senha de todas: demo1234)
--   Administrador: admin@exemplo.com
--   Empresa:       felipe@exemplo.com
--   Profissional:  jucelino@exemplo.com
-- =============================================================================

INSERT INTO TipoUser (IdTipoUser, DescricaoUser) VALUES
    (1, 'Empresa'),
    (2, 'Profissional'),
    (3, 'Administrativo');

-- O hash abaixo é o BCrypt de "demo1234"
INSERT INTO Administrativo (NmADM, DsEmail, SenhaADM) VALUES
    ('Administrador Demo', 'admin@exemplo.com', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su');

INSERT INTO Empresa (NmRecrutador, DsUser, DsEmail, NroCPF, SenhaEmpresa, NroTelefone, DtNascimento, DsSexo,
                     DsEndereco, NroEndereco, DsComplemento, DsCep, DsBairro, DsCidade, DsUF,
                     NroCNPJ, DsNomeFantasia, DsRazaoSocial, DsDataAbertura) VALUES
    ('Felipe',   'salvadoresdobem', 'felipe@exemplo.com',   '23669856899', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11955668647', '2001-09-03', 'Masculino',
     'Rua Dom Miguel', '32', 'Comercial 32', '08180-000', 'Tatuapé', 'São Paulo', 'SP',
     '12.345.678/0001-01', 'Salvadores do Bem', 'Salvadores do Bem Ltda', '2001-01-01'),
    ('Marcilia', 'linhavoadoramed', 'marcilia@exemplo.com', '55699866355', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11955668643', '2001-09-01', 'Feminino',
     'Rua Augusta', '120', 'Sem complemento', '01305-000', 'Centro', 'São Paulo', 'SP',
     '12.345.678/0001-02', 'Linha Voadora Med', 'Linha Voadora Med Ltda', '2004-03-02'),
    ('Kathleen', 'medpet',          'kathleen@exemplo.com', '56812348835', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11955668655', '1995-09-01', 'Feminino',
     'Rua Teles', '12', 'Comercial 12', '03071-000', 'Tatuapé', 'São Paulo', 'SP',
     '12.345.678/0001-03', 'MedPet', 'MedPet Ltda', '2005-03-02'),
    ('Gabriely', 'aoinvesraiox',    'gabriely@exemplo.com', '33685458886', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11955668333', '2001-03-08', 'Feminino',
     'Rua Terraseca', '45', 'Sem complemento', '01310-000', 'Centro', 'São Paulo', 'SP',
     '12.345.678/0001-04', 'aoInves Raio X Med', 'aoInves Raio X Med Ltda', '1999-03-01');

INSERT INTO Profissional (NmProfissional, DsUser, DsEmail, NroCPF, SenhaProfissional, NroTelefone, DtNascimento, DsSexo,
                          DsBiografia, FormacaoEscolar, DsEndereco, NroEndereco, DsComplemento, DsCEP, DsBairro, DsCidade, DsUF) VALUES
    ('Jucelino Silva',    'jucelino', 'jucelino@exemplo.com', '44455566677', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11911290115', '1995-03-09', 'Masculino',
     'No ramo pet desde a infância, apaixonado por animais.', 'Superior Completo', 'Rua Alameda Filho', '47', 'Casa 3', '08180-180', 'Lajeado', 'São Paulo', 'SP'),
    ('Armando Pereira',   'armando',  'armando@exemplo.com',  '33355566622', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11911290117', '1995-01-05', 'Masculino',
     'Desde criança apaixonado pelos bichos do mundo.', 'Superior Completo', 'Rua Quatro', '155', 'Sem complemento', '08180-150', 'São Martinho', 'São Paulo', 'SP'),
    ('Jessica Ferreira',  'jessica',  'jessica@exemplo.com',  '33655894588', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11911290112', '1995-01-01', 'Feminino',
     'Apaixonada por bichinhos fofinhos e defensora dos mesmos.', 'Superior Completo', 'Rua Dom Miguel', '208', 'Casa 1', '08180-080', 'São Afoxé', 'São Paulo', 'SP'),
    ('Caroline Cordeiro', 'caroline', 'caroline@exemplo.com', '57626543899', '$2a$11$CYjS6DgzkrQa7TDoWh6DueDE7keBrEShD7Eq.Ifsr4g.LiMTDm0su', '11955869445', '1995-02-02', 'Feminino',
     'Amante da profissão desde sempre e para sempre.', 'Superior Completo', 'Rua Seven', '455', 'Ap 35', '08180-155', 'Valinhos', 'São Paulo', 'SP');

INSERT INTO Experiencia (DsCargo, DsEmpresa, DsTipoContrato, DsLocalidade, DataInicio, DataFinal, FKProfissional) VALUES
    ('Tosador de cachorros', 'Salvadores do Bem',  'CLT', 'São Paulo', '2010-01-15', '2020-01-15', 1),
    ('Auxiliar veterinário', 'MedPet',             'CLT', 'São Paulo', '2020-02-01', NULL,         1),
    ('Técnico de Raio X',    'aoInves Raio X Med', 'CLT', 'São Paulo', '2015-01-15', '2017-01-15', 2),
    ('Recepcionista',        'Linha Voadora Med',  'CLT', 'São Paulo', '2018-03-01', '2021-06-30', 3);

INSERT INTO Certificado (DsCurso, DsInstituicao, DataInicio, DataConclusao, DsDescricao, FKProfissional) VALUES
    ('Medicina Veterinária',      'SENAC',      '2017-01-01', '2020-01-01', 'Atividades práticas e disciplinas teóricas na área da saúde: pequenas cirurgias, consultas e exames.', 1),
    ('Institutos de pesquisa',    'UNIP',       '2015-01-01', '2019-01-01', 'Atividades práticas e disciplinas teóricas na área de pesquisa.', 1),
    ('Cirurgião de peixes',       'Sumaré',     '2011-01-01', '2018-01-01', 'Formação na área cirúrgica com foco em operações em peixes.', 2),
    ('Cirurgião de carnívoros',   'Anhanguera', '2010-01-01', '2015-01-01', 'Formação na área cirúrgica com foco em operações em diversos tipos de animais.', 4);

INSERT INTO Vaga (NmVaga, DsExperiencia, DsTipoRegistro, DsDescricao, DsSexo, Validade, FKEmpresa) VALUES
    ('Médico Veterinário', 'No mínimo 1 ano',  'CLT', 'Responsável por cuidar e tratar animais de pequeno e grande porte, domésticos e silvestres.', 'Indiferente', '1 mês', 1),
    ('Zootecnista',        'No mínimo 1 ano',  'CLT', 'Planejar e coordenar a criação de bovinos, suínos, ovinos e aves.', 'Indiferente', '1 mês', 1),
    ('Ecologista',         'No mínimo 2 anos', 'CLT', 'Prezar pela manutenção dos ecossistemas e das cadeias alimentares.', 'Indiferente', '1 mês', 3),
    ('Oceanógrafo',        'No mínimo 2 anos', 'PJ',  'Preparado para lidar com as diferentes espécies do mar.', 'Indiferente', '1 mês', 4);

INSERT INTO Candidatos (FKProfissional, FKVaga) VALUES
    (1, 1),
    (2, 1),
    (4, 3);
