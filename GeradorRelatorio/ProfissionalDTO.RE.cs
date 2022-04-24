using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorRelatorio
{
    [Serializable]
    class ProfissionalDTO
    {
        public int IDprofissional {get;set;}
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Telefone {get;set;}
        public string Verificação {get;set;}
        public string Usuario {get;set;}
    }
}
