using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL
{
   public class CandidatosBLL
    {
         CandidatosDAL objDAL = new CandidatosDAL();

        //Cadastrar Vaga - Insert
        public void CadastrarPRoVaga(CandidatosDTO objCad)
        {
            objDAL.CadastrarVP(objCad);
        }

        //Listar
        public List<CandidatosDTO> ListarCandidatos()
        {
            return objDAL.Listar();
        }
        //Listar
        public List<CandidatosDTO> ListarCandidatos(int idempresa,int idprofissional,int idvaga)
        {
            return objDAL.ListarID(idempresa, idprofissional, idvaga);
        }


        //Delete
        public void ExcluirCandidatura(int idprofissional)
        {
            objDAL.Excluir(idprofissional);
        }

        //Filtrar
        public List<CandidatosDTO> FiltrarVaga()
        {
            return objDAL.Filtrar();
        }

        //Selecionar

        public CandidatosDTO SelecionarVaga(int IdVaga)
        {
            return objDAL.Selecionar(IdVaga);
        }
    }
}
