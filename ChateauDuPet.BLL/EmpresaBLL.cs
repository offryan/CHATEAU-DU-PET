using ChateauDuPet.DAL;
using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.BLL
{
   public class EmpresaBLL
    {
        EmpresaDAL objDAL = new EmpresaDAL();

        //Cadastrar Vaga - Insert
        public void CadastrarEmpresa(EmpresaDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<EmpresaDTO> ListarEmpresa()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarEmpresa(EmpresaDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirEmpresa(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }

        //autentica

        public EmpresaDTO AutenticarEmpresa(string objEmailE, string objSenhaE)
        {
            return objDAL.Autenticar(objEmailE, objSenhaE);
        }


        //autentica cadastro
        public EmpresaDTO AutenticaEmailBLL(string objEmail)
        {
            return objDAL.AutenticaEmail(objEmail);
        }
        
        public EmpresaDTO AutenticaUserBLL(string objUser)
        {
            return objDAL.AutenticaUser(objUser);
        }
        
        public EmpresaDTO AutenticaCPFBLL(string objCPF)
        {
            return objDAL.AutenticaCPF(objCPF);
        }
        
        
        public List<EmpresaDTO> FiltarP()
        {
            return objDAL.Filtro();
        }
    
        public List<EmpresaDTO> FiltrarID(int idEmpresa)
        {
           return objDAL.FiltroID(idEmpresa);
        }
        //selecionar
        public EmpresaDTO SelecionarID  (int IdEmpresa)
        {
            return objDAL.Selecionar(IdEmpresa);
        }
    }
}
