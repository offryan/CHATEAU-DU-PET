using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL
{
   public class AutenticaBLL
    {
        AutenticaDAL objDAL = new AutenticaDAL();

        //Autentica

        public AutenticaDTO AutenticarUser(string objEmail, string objSenha ,int objTipoUser)
        {
            return objDAL.Autenticar(objEmail, objSenha, objTipoUser);
        }

    }
}
