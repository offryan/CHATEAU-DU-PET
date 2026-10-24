# 🐾 Chateau Du Pet

Projeto acadêmico de conclusão de curso (TCC) onde encontramos um empregador real para o projeto (OBS: Apenas o website foi comprado)

🔗 **Site no ar:** https://chateaudupet.com.br

### Base do projeto: A rede de pet shop "Chateau Du Pet" buscava criar um ambiente onde outras empresas do ramo pet pudessem contratar candidatos com maior facilidade.

### APP DESKTOP:

- Usuário da Empresa: Publicação, exclusão e edição de vagas | visualização dos currículos dos candidatos | edição do usuário empresa
- Usuário do Candidato: Candidatura para as vagas | edição dos seus perfis e currículos | Visualização das vagas já candidatadas
- Usuário Administrador: Gerenciamento dos profissionais, empresas e vagas

### APP MOBILE:

- Visualiza vagas de emprego criadas pelas empresas

### WEB SITE:

- Galeria de Imagens de Pets;
- Contato e Localização das unidades;
- Depoimentos, avaliações e vídeos;
- https://chateaudupet.com.br

---

## 🚀 Demo online: versão 2026 em .NET 8

🔗 **https://chateau-du-pet-demo.onrender.com** (plano gratuito: o primeiro acesso pode levar até 1 minuto para o servidor acordar)

A plataforma de vagas foi migrada de Web Forms + SQL Server para **.NET 8 + PostgreSQL** e publicada como portfólio, com dados fictícios. Não é o site oficial do Chateau Du Pet.

| Perfil | E-mail | Senha |
|---|---|---|
| Empresa | `felipe@exemplo.com` | `demo1234` |
| Profissional | `jucelino@exemplo.com` | `demo1234` |
| Administrador | `admin@exemplo.com` | `demo1234` |

Os dados de demonstração são restaurados todos os dias às 3h.

### O que dá para fazer

- **Visitante:** ver e buscar vagas, se cadastrar como empresa ou profissional
- **Profissional:** montar o currículo (dados, experiências e certificados), se candidatar e acompanhar as candidaturas
- **Empresa:** publicar, editar e excluir vagas, ver os candidatos e o currículo de cada um
- **Administrador:** gerenciar profissionais, empresas e vagas

### Tecnologias

| Camada | Tecnologia |
|---|---|
| Web | ASP.NET Core 8 (Razor Pages), Bootstrap; o visual original foi mantido |
| Regras e dados | Arquitetura em camadas (DTO, DAL e BLL), Dapper + Npgsql |
| Banco | PostgreSQL no Supabase, com Row Level Security e usuário de banco restrito |
| Segurança | Senhas com BCrypt, login por cookie, checagem de dono em cada registro |
| Infra | Docker no Render, com deploy automático a cada push |
| Testes | xUnit com testes de integração contra PostgreSQL |

### Estrutura

```
src/
├── ChateauDuPet.DTO     → entidades
├── ChateauDuPet.DAL     → repositórios (SQL parametrizado com Dapper)
├── ChateauDuPet.BLL     → regras: login, cadastro, vagas, currículo
├── ChateauDuPet.Web     → páginas Razor, CSS e imagens do projeto original
└── ChateauDuPet.Tests   → testes de integração
database/                → schema.sql e seed.sql do PostgreSQL (veja database/README.md)
Dockerfile               → imagem usada no Render
```

### Rodando localmente

Pré-requisitos: .NET 8 SDK e PostgreSQL.

```bash
createdb chateau
psql -d chateau -f database/schema.sql
psql -d chateau -f database/seed.sql

cd src/ChateauDuPet.Web
# ajuste ConnectionStrings:Chateau em appsettings.Development.json, se precisar
dotnet run
```

Testes (criam um banco `chateau_testes` no PostgreSQL local; servidor configurável pela variável `CHATEAU_TEST_DB`):

```bash
cd src && dotnet test
```

### O que mudou na migração

- Web Forms (26 páginas `.aspx`) reescrito em Razor Pages, reaproveitando CSS, imagens e textos
- SQL Server → PostgreSQL, com o schema refeito a partir do que o código realmente usava
- Queries que estavam quebradas foram reescritas e parametrizadas
- Senhas passaram de texto puro para hash BCrypt, e a string de conexão saiu do código
- Empresas só veem e alteram as próprias vagas e candidatos; profissionais só alteram o próprio currículo

---

## 📦 Versão original (2021)

O código original continua na raiz do repositório, como histórico.

## 🛠️ Tecnologias

| Parte | Tecnologia |
|---|---|
| Website | ASP.NET MVC (.NET Framework 4.7.2), Razor, Bootstrap, JavaScript |
| Portal de vagas | ASP.NET Web Forms (.NET Framework 4.7.2) |
| App desktop | Windows Forms (.NET Framework 4.7.2) |
| App mobile | Xamarin.Forms (Android) |
| Banco de dados | SQL Server / Azure SQL (T-SQL) |
| Relatórios | Console .NET 5 |

## 🧱 Arquitetura

O sistema é dividido em camadas, e os apps reaproveitam a mesma regra de negócio e o mesmo acesso a dados:

```
ChateauDuPet.sln
├── ChateauDuPet.DTO     → objetos de transferência (Empresa, Vaga, Candidato...)
├── ChateauDuPet.DAL     → acesso ao banco (SQL Server) + script do banco em ScriptDB/
├── ChateauDuPet.BLL     → regras de negócio
├── DESKTOP.UI           → app desktop (empresa, candidato e administrador)
├── ChateauDuPet.SITE    → website institucional em ASP.NET MVC
├── ChateauDuPet.UI      → portal de vagas em ASP.NET Web Forms
├── GeradorRelatorio     → geração de relatórios dos profissionais
└── ProjetoIntegrador    → app mobile em Xamarin.Forms
```

## ▶️ Como rodar

1. Abra o `ChateauDuPet.sln` no **Visual Studio** (com as cargas de trabalho .NET Desktop, ASP.NET e Xamarin).
2. Crie o banco executando `ChateauDuPet.DAL/ScriptDB/ScriptChateauPet.sql` no SQL Server.
3. Ajuste a string de conexão em `ChateauDuPet.DAL/Conexao.cs` e `ChateauDuPet.UI/Web.config` para apontar para o seu banco.
4. Defina o projeto de inicialização (`DESKTOP.UI` para o app desktop ou `ChateauDuPet.SITE` para o site) e rode com **F5**.
