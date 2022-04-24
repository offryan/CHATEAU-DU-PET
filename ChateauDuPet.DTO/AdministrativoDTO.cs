using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
   public class AdministrativoDTO
    {
        public int IdAdministrativo { get; set; }
        public string EmailAdm { get; set; }
        public string NomeAdmin { get; set; }
        public string SenhaAdmin { get; set; }
        public string UrlImage { get; set; }
        public int FKTipoUser { get; set; }
    }
}
