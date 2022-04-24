using ChateauDuPet.DAL;
using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.BLL
{
   public class CertificadoBLL
    {
       CertificadoDAL objDAL = new CertificadoDAL();

        //Cadastrar Certificado - Insert
        public void CadastrarCertificado(CertificadoDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<CertificadoDTO> ListarCertificado()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarCertificado(CertificadoDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirCertificado(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }
        public  CertificadoDTO SelecionarCertificado(int idProfissional)
        {
            return objDAL.SelecionarCertificado(idProfissional);
        }
        public List<CertificadoDTO> FiltroCerID (int idProfissional)
        {
            return objDAL.FiltroCerID(idProfissional);
        }
        public List<CertificadoDTO> FiltroC()
        {
            return objDAL.FiltroCertificado();
        }
    }
}
