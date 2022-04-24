using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
    public class AutenticaDTO
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public int FKTipoUser { get; set; }
    }
}

