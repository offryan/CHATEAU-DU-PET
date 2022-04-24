using ChateauDuPet.DAL;
using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.BLL
{
   public class AdministrativoBLL
    {
        AdministrativoDAL objDAL = new AdministrativoDAL();

        //Cadastrar Admin - Insert
        public void CadastrarAdministrativo(AdministrativoDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<AdministrativoDTO> ListarAdministrativo()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarAdministrativo(AdministrativoDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirAdministrativo(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }

        //autentica
        public AdministrativoDTO AutenticarAdministrativo(string objNome, string objSenha)
        {
            return objDAL.Autenticar(objNome, objSenha);
        }

        //Filtrar
        public List<AdministrativoDTO> FiltrarAdministrativo()
        {
            return objDAL.Filtrar();
        }

        //Filtrar
        public List<AdministrativoDTO> FiltrarAdministrativoID(int idOperador)
        {
            return objDAL.FiltrarID(idOperador);
        }
    }
}
