using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class EmpresaDTO
    {
        public int IdEmpresa { get; set; }
        public string Recrutador { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string SenhaEmpresa { get; set; }
        public string Nascimento { get; set; }
        public string Sexo { get; set; }
        //Recrutador acima\\
        public string NroEndereco { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        //
        public string CNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string DataAbertura { get; set; }
        
        public DateTime Termos { get; set; }
        public DateTime Privacidade { get; set; }
        
        public string UrlImage { get; set; }
        public int FKTipoUser { get; set; }
        public string User { get; set; }


    }
}
