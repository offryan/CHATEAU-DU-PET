# Banco de dados (PostgreSQL / Supabase)

| Arquivo | O que faz |
|---|---|
| `schema.sql` | Cria as 8 tabelas, índices e o bloqueio de acesso pela API pública do Supabase |
| `seed.sql` | Insere dados fictícios de demonstração |

## Criando o banco no Supabase

1. No painel do projeto, abra **SQL Editor** → **New query**.
2. Cole o conteúdo de `schema.sql` e clique em **Run**.
3. Abra outra query, cole o conteúdo de `seed.sql` e clique em **Run**.
4. Confira em **Table Editor**: devem aparecer as tabelas com 4 empresas, 4 profissionais e 4 vagas.

## Contas de demonstração

Senha de todas: `demo1234`

| Perfil | E-mail |
|---|---|
| Administrador | `admin@exemplo.com` |
| Empresa | `felipe@exemplo.com` |
| Profissional | `jucelino@exemplo.com` |

## Modelo

```
TipoUser ─┬─< Administrativo
          ├─< Empresa ──────< Vaga ──────< Candidatos >── Profissional
          └─< Profissional ─┬─< Experiencia
                            └─< Certificado
```

## Segurança

- Senhas guardadas como hash **BCrypt**, nunca em texto puro.
- **Row Level Security** ligado em todas as tabelas e acesso revogado dos papéis `anon` e `authenticated`: a Data API pública do Supabase não lê nada.
- A aplicação conecta com um usuário próprio, `chateau_app`, que só lê e escreve nas tabelas do Chateau: não é dono delas, não cria tabelas e não acessa os outros schemas do Supabase. A string de conexão fica na variável `DATABASE_URL` do Render.

Para recriar esse usuário em outro projeto (troque a senha):

```sql
CREATE ROLE chateau_app WITH LOGIN PASSWORD '<senha forte>' NOINHERIT;
GRANT USAGE ON SCHEMA public TO chateau_app;
GRANT SELECT, INSERT, UPDATE, DELETE ON ALL TABLES IN SCHEMA public TO chateau_app;
GRANT USAGE ON ALL SEQUENCES IN SCHEMA public TO chateau_app;
-- uma policy por tabela, liberando só esse usuário (o RLS segue bloqueando a API pública)
CREATE POLICY app_acesso_total ON vaga FOR ALL TO chateau_app USING (true) WITH CHECK (true);
-- ...repita para tipouser, administrativo, profissional, experiencia, certificado,
--    empresa, candidatos e dataprotectionkeys
```

String de conexão (Session pooler do Supabase, porta 5432):
`postgresql://chateau_app.<ref-do-projeto>:<senha>@aws-0-<regiao>.pooler.supabase.com:5432/postgres`

## Mudanças em relação ao banco SQL Server original

- `INT IDENTITY` → `INT GENERATED ALWAYS AS IDENTITY`; `NVARCHAR` → `VARCHAR`/`TEXT`; datas sem hora viraram `DATE`.
- Colunas que a aplicação usava mas não estavam no script original foram incluídas (`DsUser`, `NroEndereco`, e-mail do administrador).
- Dados de perfil completados depois do cadastro passaram a aceitar `NULL`, como o fluxo de cadastro exige.
- `Candidatos` ficou só com profissional + vaga (a empresa vem da vaga), com candidatura única por vaga. A coluna `FKCandidatos` de `Vaga` saiu, porque a relação já fica em `Candidatos`.
- E-mail, CPF e usuário passaram a ser únicos; exclusões removem os dados dependentes em cascata.
