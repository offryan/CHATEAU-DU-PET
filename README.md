# 🐾 Chateau Du Pet

Projeto acadêmico de conclusão de curso (TCC) onde encontramos um empregador real para o projeto (OBS: Apenas o website foi comprado)

🔗 **Site no ar:** https://chateaudupet.com.br

### Base do projeto: A rede de pet shop "Chateau Du Pet" buscava criar um ambiente onde outras empresas do ramo pet pudessem contratar candidatos com maior facilidade.

### APP DESKTOP:

- Usuário da Empresa: Publicação, exclusão e edição de vagas | visualização dos currículos dos candidatos | edição do usuário empresa
- Usuário do Candidato: Candidatura para as vagas | edição dos seus perfis e currículos | Visualização das vagas já candidatadas
- Usuário Administrador: Gerenciamento e aprovação dos perfis das empresas

### APP MOBILE:

- Visualiza vagas de emprego criadas pelas empresas

### WEB SITE:

- Galeria de Imagens de Pets;
- Contato e Localização das unidades;
- Depoimentos, avaliações e vídeos;
- https://chateaudupet.com.br

---

## 🛠️ Tecnologias

| Parte | Tecnologia |
|---|---|
| Website | ASP.NET MVC (.NET Framework 4.7.2), Razor, Bootstrap, JavaScript |
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
├── ChateauDuPet.UI      → interface web auxiliar
├── GeradorRelatorio     → geração de relatórios dos profissionais
└── ProjetoIntegrador    → app mobile em Xamarin.Forms
```

## ▶️ Como rodar

1. Abra o `ChateauDuPet.sln` no **Visual Studio** (com as cargas de trabalho .NET Desktop, ASP.NET e Xamarin).
2. Crie o banco executando `ChateauDuPet.DAL/ScriptDB/ScriptChateauPet.sql` no SQL Server.
3. Ajuste a string de conexão em `ChateauDuPet.DAL/Conexao.cs` e `ChateauDuPet.UI/Web.config` para apontar para o seu banco.
4. Defina o projeto de inicialização (`DESKTOP.UI` para o app desktop ou `ChateauDuPet.SITE` para o site) e rode com **F5**.
