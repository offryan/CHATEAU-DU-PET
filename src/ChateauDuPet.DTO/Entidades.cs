namespace ChateauDuPet.DTO;

// As propriedades seguem os nomes das colunas do banco para o Dapper mapear direto.

public enum TipoUsuario
{
    Empresa = 1,
    Profissional = 2,
    Administrativo = 3
}

public class AdministrativoDTO
{
    public int IdAdministrativo { get; set; }
    public string NmADM { get; set; } = "";
    public string DsEmail { get; set; } = "";
    public string SenhaADM { get; set; } = "";
    public string? UrlImage { get; set; }
}

public class EmpresaDTO
{
    public int IdEmpresa { get; set; }
    public string NmRecrutador { get; set; } = "";
    public string DsUser { get; set; } = "";
    public string DsEmail { get; set; } = "";
    public string NroCPF { get; set; } = "";
    public string SenhaEmpresa { get; set; } = "";
    public string NroTelefone { get; set; } = "";
    public DateTime DtNascimento { get; set; }
    public string DsSexo { get; set; } = "";
    public string? DsEndereco { get; set; }
    public string? NroEndereco { get; set; }
    public string? DsComplemento { get; set; }
    public string? DsCep { get; set; }
    public string? DsBairro { get; set; }
    public string? DsCidade { get; set; }
    public string? DsUF { get; set; }
    public string? NroCNPJ { get; set; }
    public string? DsNomeFantasia { get; set; }
    public string? DsRazaoSocial { get; set; }
    public DateTime? DsDataAbertura { get; set; }
    public DateTime DtTermos { get; set; }
    public DateTime DsPrivacidade { get; set; }
    public string? UrlImage { get; set; }

    public string NomeExibicao => string.IsNullOrWhiteSpace(DsNomeFantasia) ? NmRecrutador : DsNomeFantasia;
}

public class ProfissionalDTO
{
    public int IdProfissional { get; set; }
    public string NmProfissional { get; set; } = "";
    public string DsUser { get; set; } = "";
    public string DsEmail { get; set; } = "";
    public string NroCPF { get; set; } = "";
    public string SenhaProfissional { get; set; } = "";
    public string NroTelefone { get; set; } = "";
    public DateTime DtNascimento { get; set; }
    public string DsSexo { get; set; } = "";
    public string? DsBiografia { get; set; }
    public string? FormacaoEscolar { get; set; }
    public string? DsEndereco { get; set; }
    public string? NroEndereco { get; set; }
    public string? DsComplemento { get; set; }
    public string? DsCEP { get; set; }
    public string? DsBairro { get; set; }
    public string? DsCidade { get; set; }
    public string? DsUF { get; set; }
    public DateTime DtTermos { get; set; }
    public DateTime DsPrivacidade { get; set; }
    public string? UrlImage { get; set; }
}

public class ExperienciaDTO
{
    public int IdExperiencia { get; set; }
    public string DsCargo { get; set; } = "";
    public string DsEmpresa { get; set; } = "";
    public string DsTipoContrato { get; set; } = "";
    public string DsLocalidade { get; set; } = "";
    public DateTime DataInicio { get; set; }
    public DateTime? DataFinal { get; set; }
    public int FKProfissional { get; set; }
}

public class CertificadoDTO
{
    public int IdCertificado { get; set; }
    public string DsCurso { get; set; } = "";
    public string DsInstituicao { get; set; } = "";
    public DateTime DataInicio { get; set; }
    public DateTime? DataConclusao { get; set; }
    public string DsDescricao { get; set; } = "";
    public int FKProfissional { get; set; }
}

public class VagaDTO
{
    public int IdVaga { get; set; }
    public string NmVaga { get; set; } = "";
    public string? DsExperiencia { get; set; }
    public string? DsTipoRegistro { get; set; }
    public string? DsDescricao { get; set; }
    public string? DsSexo { get; set; }
    public string? Validade { get; set; }
    public DateTime DataPublicacao { get; set; }
    public int FKEmpresa { get; set; }

    // Preenchidos nas consultas com JOIN
    public string? NomeEmpresa { get; set; }
    public string? CidadeEmpresa { get; set; }
    public int TotalCandidatos { get; set; }
}

public class CandidaturaDTO
{
    public int IdCandidatos { get; set; }
    public int FKProfissional { get; set; }
    public int FKVaga { get; set; }
    public DateTime DsData { get; set; }

    // Preenchidos nas consultas com JOIN
    public string? NmVaga { get; set; }
    public string? NomeEmpresa { get; set; }
    public string? NmProfissional { get; set; }
    public string? DsEmail { get; set; }
    public string? FormacaoEscolar { get; set; }
}

public record UsuarioLogado(int Id, string Nome, string Email, TipoUsuario Tipo);
