using ChateauDuPet.DAL;
using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.BLL
{
   public class TipoUserBLL
    {
        //objeto para acoes gerais
        TipoUserDAL objDAL = new TipoUserDAL();
       
        //autentica
        public AutenticaDTO AutenticarUsuario(string objNome, string objSenha)
        {
            return objDAL.Autenticar(objNome, objSenha);
        }
    }
}
