-- =============================================================================
-- Chateau Du Pet: schema PostgreSQL (Supabase)
-- Rode este arquivo primeiro e depois o seed.sql.
-- =============================================================================

-- Tipos de usuário do sistema (1 = Empresa, 2 = Profissional, 3 = Administrativo)
CREATE TABLE TipoUser (
    IdTipoUser     INT PRIMARY KEY,
    DescricaoUser  VARCHAR(15) NOT NULL
);

CREATE TABLE Administrativo (
    IdAdministrativo  INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    NmADM             VARCHAR(100) NOT NULL,
    DsEmail           VARCHAR(100) NOT NULL UNIQUE,
    SenhaADM          VARCHAR(100) NOT NULL,          -- hash BCrypt
    UrlImage          TEXT,
    FKTipoUser        INT NOT NULL DEFAULT 3 REFERENCES TipoUser (IdTipoUser)
);

-- Candidato a vagas. O cadastro inicial preenche só os dados básicos;
-- o restante do perfil é completado depois, por isso essas colunas aceitam NULL.
CREATE TABLE Profissional (
    IdProfissional     INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    NmProfissional     VARCHAR(100) NOT NULL,
    DsUser             VARCHAR(50)  NOT NULL UNIQUE,
    DsEmail            VARCHAR(100) NOT NULL UNIQUE,
    NroCPF             VARCHAR(11)  NOT NULL UNIQUE,
    SenhaProfissional  VARCHAR(100) NOT NULL,          -- hash BCrypt
    NroTelefone        VARCHAR(11)  NOT NULL,
    DtNascimento       DATE         NOT NULL,
    DsSexo             VARCHAR(20)  NOT NULL,
    DsBiografia        VARCHAR(300),
    FormacaoEscolar    VARCHAR(30),
    DsEndereco         VARCHAR(100),
    NroEndereco        VARCHAR(6),
    DsComplemento      VARCHAR(50),
    DsCEP              VARCHAR(10),
    DsBairro           VARCHAR(50),
    DsCidade           VARCHAR(50),
    DsUF               VARCHAR(2),
    DtTermos           TIMESTAMP    NOT NULL DEFAULT now(),
    DsPrivacidade      TIMESTAMP    NOT NULL DEFAULT now(),
    UrlImage           TEXT,
    FKTipoUser         INT NOT NULL DEFAULT 2 REFERENCES TipoUser (IdTipoUser)
);

CREATE TABLE Experiencia (
    IdExperiencia   INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    DsCargo         VARCHAR(50) NOT NULL,
    DsEmpresa       VARCHAR(50) NOT NULL,
    DsTipoContrato  VARCHAR(15) NOT NULL,
    DsLocalidade    VARCHAR(30) NOT NULL,
    DataInicio      DATE NOT NULL,
    DataFinal       DATE,                              -- NULL = emprego atual
    FKProfissional  INT NOT NULL REFERENCES Profissional (IdProfissional) ON DELETE CASCADE
);

CREATE TABLE Certificado (
    IdCertificado   INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    DsCurso         VARCHAR(50)   NOT NULL,
    DsInstituicao   VARCHAR(100)  NOT NULL,
    DataInicio      DATE NOT NULL,
    DataConclusao   DATE,                              -- NULL = em andamento
    DsDescricao     VARCHAR(1000) NOT NULL,
    FKProfissional  INT NOT NULL REFERENCES Profissional (IdProfissional) ON DELETE CASCADE
);

-- Empresa recrutadora. Mesmo esquema do Profissional: cadastro básico primeiro,
-- dados da empresa (CNPJ, razão social, endereço) completados no perfil.
CREATE TABLE Empresa (
    IdEmpresa       INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    NmRecrutador    VARCHAR(100) NOT NULL,
    DsUser          VARCHAR(50)  NOT NULL UNIQUE,
    DsEmail         VARCHAR(100) NOT NULL UNIQUE,
    NroCPF          VARCHAR(11)  NOT NULL UNIQUE,
    SenhaEmpresa    VARCHAR(100) NOT NULL,             -- hash BCrypt
    NroTelefone     VARCHAR(12)  NOT NULL,
    DtNascimento    DATE         NOT NULL,
    DsSexo          VARCHAR(15)  NOT NULL,
    DsEndereco      VARCHAR(100),
    NroEndereco     VARCHAR(6),
    DsComplemento   VARCHAR(100),
    DsCep           VARCHAR(9),
    DsBairro        VARCHAR(50),
    DsCidade        VARCHAR(50),
    DsUF            VARCHAR(2),
    NroCNPJ         VARCHAR(18),
    DsNomeFantasia  VARCHAR(100),
    DsRazaoSocial   VARCHAR(100),
    DsDataAbertura  DATE,
    DtTermos        TIMESTAMP    NOT NULL DEFAULT now(),
    DsPrivacidade   TIMESTAMP    NOT NULL DEFAULT now(),
    UrlImage        TEXT,
    FKTipoUser      INT NOT NULL DEFAULT 1 REFERENCES TipoUser (IdTipoUser)
);

CREATE TABLE Vaga (
    IdVaga          INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    NmVaga          VARCHAR(100)  NOT NULL,
    DsExperiencia   VARCHAR(50),
    DsTipoRegistro  VARCHAR(15),
    DsDescricao     VARCHAR(4000),
    DsSexo          VARCHAR(20),
    Validade        VARCHAR(20),
    DataPublicacao  TIMESTAMP     NOT NULL DEFAULT now(),
    FKEmpresa       INT NOT NULL REFERENCES Empresa (IdEmpresa) ON DELETE CASCADE
);

-- Candidaturas: qual profissional se candidatou a qual vaga
CREATE TABLE Candidatos (
    IdCandidatos    INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    FKProfissional  INT NOT NULL REFERENCES Profissional (IdProfissional) ON DELETE CASCADE,
    FKVaga          INT NOT NULL REFERENCES Vaga (IdVaga) ON DELETE CASCADE,
    DsData          TIMESTAMP NOT NULL DEFAULT now(),
    UNIQUE (FKProfissional, FKVaga)
);

-- Chaves que o ASP.NET Core usa para proteger cookies de login e formulários.
-- Ficam no banco para sobreviverem aos redeploys do container.
CREATE TABLE DataProtectionKeys (
    FriendlyName  TEXT PRIMARY KEY,
    Xml           TEXT NOT NULL
);

CREATE INDEX ix_experiencia_profissional ON Experiencia (FKProfissional);
CREATE INDEX ix_certificado_profissional ON Certificado (FKProfissional);
CREATE INDEX ix_vaga_empresa             ON Vaga (FKEmpresa);
CREATE INDEX ix_candidatos_vaga          ON Candidatos (FKVaga);

-- -----------------------------------------------------------------------------
-- Segurança no Supabase: a Data API pública (chave anon) enxerga o schema
-- public. O app conecta direto no Postgres como dono das tabelas, então
-- bloqueamos qualquer acesso pela API.
-- -----------------------------------------------------------------------------
DO $$
DECLARE t TEXT;
BEGIN
    FOREACH t IN ARRAY ARRAY['tipouser','administrativo','profissional','experiencia',
                             'certificado','empresa','vaga','candidatos','dataprotectionkeys'] LOOP
        EXECUTE format('ALTER TABLE %I ENABLE ROW LEVEL SECURITY', t);
        IF EXISTS (SELECT 1 FROM pg_roles WHERE rolname = 'anon') THEN
            EXECUTE format('REVOKE ALL ON TABLE %I FROM anon, authenticated', t);
        END IF;
    END LOOP;
END $$;
