using ChateauDuPet.DTO;

namespace ChateauDuPet.Tests;

[Collection("Banco")]
public class AutenticacaoTests(BancoFixture banco)
{
    [Theory]
    [InlineData("admin@demo.com", TipoUsuario.Administrativo)]
    [InlineData("empresa@demo.com", TipoUsuario.Empresa)]
    [InlineData("CANDIDATO@demo.com", TipoUsuario.Profissional)] // e-mail sem diferenciar maiúsculas
    public async Task Contas_de_demo_entram_com_o_tipo_certo(string email, TipoUsuario tipo)
    {
        var usuario = await banco.Autenticacao().EntrarAsync(email, "demo1234");

        Assert.NotNull(usuario);
        Assert.Equal(tipo, usuario.Tipo);
    }

    [Theory]
    [InlineData("empresa@demo.com", "senha-errada")]
    [InlineData("ninguem@exemplo.com", "demo1234")]
    [InlineData("", "")]
    public async Task Login_invalido_retorna_null(string email, string senha)
    {
        Assert.Null(await banco.Autenticacao().EntrarAsync(email, senha));
    }
}

[Collection("Banco")]
public class CadastroTests(BancoFixture banco)
{
    private static ProfissionalDTO NovoProfissional(string sufixo) => new()
    {
        NmProfissional = "Teste " + sufixo,
        DsUser = "teste." + sufixo,
        DsEmail = $"teste.{sufixo}@exemplo.com",
        NroCPF = "123.456.789-" + sufixo[..2].PadLeft(2, '0'),
        NroTelefone = "(11) 98888-7777",
        DtNascimento = new DateTime(1998, 5, 10),
        DsSexo = "Feminino"
    };

    [Fact]
    public async Task Profissional_cadastrado_consegue_entrar()
    {
        var r = await banco.Cadastro().CadastrarProfissionalAsync(NovoProfissional("01"), "senhaforte1");

        Assert.True(r.Sucesso, r.Erro);
        var usuario = await banco.Autenticacao().EntrarAsync("teste.01@exemplo.com", "senhaforte1");
        Assert.Equal(TipoUsuario.Profissional, usuario?.Tipo);
    }

    [Fact]
    public async Task Senha_e_guardada_como_hash()
    {
        await banco.Cadastro().CadastrarProfissionalAsync(NovoProfissional("02"), "senhaforte2");

        var salvo = (await banco.Perfil().ListarProfissionaisAsync()).Single(p => p.DsUser == "teste.02");
        Assert.NotEqual("senhaforte2", salvo.SenhaProfissional);
        Assert.StartsWith("$2", salvo.SenhaProfissional);
    }

    [Fact]
    public async Task Email_repetido_e_recusado()
    {
        var dup = NovoProfissional("03");
        dup.DsEmail = "candidato@demo.com";

        var r = await banco.Cadastro().CadastrarProfissionalAsync(dup, "senhaforte3");

        Assert.False(r.Sucesso);
        Assert.Contains("e-mail", r.Erro);
    }

    [Theory]
    [InlineData("curta")]
    [InlineData("")]
    public async Task Senha_fraca_e_recusada(string senha)
    {
        var r = await banco.Cadastro().CadastrarProfissionalAsync(NovoProfissional("04"), senha);
        Assert.False(r.Sucesso);
    }
}

[Collection("Banco")]
public class VagaTests(BancoFixture banco)
{
    private static readonly UsuarioLogado Felipe = new(1, "Salvadores do Bem", "empresa@demo.com", TipoUsuario.Empresa);
    private static readonly UsuarioLogado Marcilia = new(2, "Linha Voadora Med", "marcilia@exemplo.com", TipoUsuario.Empresa);

    [Fact]
    public async Task Lista_traz_empresa_e_total_de_candidatos()
    {
        var vagas = await banco.Vagas().ListarAsync();

        var vet = vagas.Single(v => v.NmVaga == "Médico Veterinário");
        Assert.Equal("Salvadores do Bem", vet.NomeEmpresa);
        Assert.Equal(2, vet.TotalCandidatos);
    }

    [Fact]
    public async Task Busca_filtra_por_nome_ou_descricao()
    {
        var vagas = await banco.Vagas().ListarAsync("ECOSSISTEMA");
        Assert.Equal("Ecologista", Assert.Single(vagas).NmVaga);
    }

    [Fact]
    public async Task Empresa_nao_edita_nem_exclui_vaga_de_outra_empresa()
    {
        var vaga = (await banco.Vagas().ListarDaEmpresaAsync(Felipe.Id)).First();
        vaga.NmVaga = "Invadida";

        Assert.False((await banco.Vagas().EditarAsync(vaga, Marcilia.Id)).Sucesso);
        Assert.False((await banco.Vagas().ExcluirAsync(vaga.IdVaga, Marcilia)).Sucesso);
        Assert.Equal(vaga.IdVaga, (await banco.Vagas().ObterAsync(vaga.IdVaga))?.IdVaga);
    }

    [Fact]
    public async Task Empresa_nao_ve_candidatos_de_vaga_de_outra_empresa()
    {
        var vagaDoFelipe = (await banco.Vagas().ListarDaEmpresaAsync(Felipe.Id)).Single(v => v.NmVaga == "Médico Veterinário");

        Assert.Equal(2, (await banco.Vagas().CandidatosDaVagaAsync(vagaDoFelipe.IdVaga, Felipe)).Count);
        Assert.Empty(await banco.Vagas().CandidatosDaVagaAsync(vagaDoFelipe.IdVaga, Marcilia));
    }

    [Fact]
    public async Task Candidatura_repetida_e_recusada_e_pode_ser_cancelada()
    {
        var vaga = (await banco.Vagas().ListarAsync()).Single(v => v.NmVaga == "Oceanógrafo");

        Assert.True((await banco.Vagas().CandidatarAsync(3, vaga.IdVaga)).Sucesso);
        Assert.False((await banco.Vagas().CandidatarAsync(3, vaga.IdVaga)).Sucesso);
        Assert.True(await banco.Vagas().CancelarCandidaturaAsync(3, vaga.IdVaga));
        Assert.False(await banco.Vagas().JaCandidatadoAsync(3, vaga.IdVaga));
    }

    [Fact]
    public async Task Publicar_vaga_exige_nome_e_descricao()
    {
        var r = await banco.Vagas().PublicarAsync(new VagaDTO { NmVaga = "Tosador" }, Felipe.Id);
        Assert.False(r.Sucesso);
    }
}

[Collection("Banco")]
public class CurriculoTests(BancoFixture banco)
{
    [Fact]
    public async Task Profissional_nao_exclui_experiencia_de_outro()
    {
        var expDoJucelino = (await banco.Perfil().ExperienciasAsync(1)).First();

        Assert.False(await banco.Perfil().ExcluirExperienciaAsync(expDoJucelino.IdExperiencia, idProfissional: 2));
        Assert.Contains(await banco.Perfil().ExperienciasAsync(1), e => e.IdExperiencia == expDoJucelino.IdExperiencia);
    }

    [Fact]
    public async Task Experiencia_com_data_final_antes_do_inicio_e_recusada()
    {
        var r = await banco.Perfil().AdicionarExperienciaAsync(new ExperienciaDTO
        {
            DsCargo = "Banhista", DsEmpresa = "PetShop", DsTipoContrato = "CLT", DsLocalidade = "SP",
            DataInicio = new DateTime(2022, 1, 1), DataFinal = new DateTime(2021, 1, 1)
        }, idProfissional: 2);

        Assert.False(r.Sucesso);
    }
}
