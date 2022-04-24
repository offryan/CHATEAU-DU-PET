using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class ExperienciaDTO
    {
        public int IdExperiencia { get; set; }
        public string Cargo { get; set; }
        public string Empresa { get; set; }
        public string TipoContrato { get; set; }
        public string Localidade { get; set; }
        public string DataInicio { get; set; }
        public string DataFinal { get; set; }
        public int FKProfissional { get; set; }
    }
}
