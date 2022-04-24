using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DTO
{
    public class EmailDTO
    {
       
    
        public string NomeRemetente { get; set; }
        public string EmailRemetente { get; set; }
        public string NomeDestinatario { get; set; }
        public string EmailDestinatario { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }
    } 
}
