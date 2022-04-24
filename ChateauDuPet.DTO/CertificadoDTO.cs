using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class CertificadoDTO
    {
        public int IdCertificado { get; set; }
        public string Curso { get; set; }
        public string Instituicao { get; set; }
        public string DataInicio { get; set; }
        public string DataConclusao { get; set; }
        public string Descricao { get; set; }
        public int FKProfissional { get; set; }
    }
}
