using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class ProfissionalDTO
    {
        public int IdProfissional { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Biografia { get; set; }
        public string Nascimento { get; set; }
        public string FormacaoEscolar { get; set; }
        public string Sexo { get; set; }
        //
        public string Endereco { get; set; }
        public string NroEndereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        //
        public DateTime Termos { get; set; }
        public DateTime Privacidade { get; set; }
        public string UrlImage { get; set; }
        public int FKTipoUser { get; set; }
        public string User { get; set; }
    }
}
