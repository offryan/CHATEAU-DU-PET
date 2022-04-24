using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class VagaDTO
    {
        public int IdVaga { get; set; }
        public string Vaga { get; set; }
        public string Experiencia { get; set; }
        public string Registro { get; set; }
        public string Descricao { get; set; }
        public string Sexo { get; set; }
        public string Validade { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int FKEmpresa { get; set; }
        public int FKCandidatos { get; set; }
    }
}
