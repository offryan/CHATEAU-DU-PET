
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DAL;
using ChateauDuPet.DTO;

namespace ChateauDuPet.BLL
{
   public class VagaBLL
    {
        VagaDAL objDAL = new VagaDAL();

        //Cadastrar Vaga - Insert
        public void CadastrarVaga(VagaDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<VagaDTO> ListarVaga()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarVaga(VagaDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirVaga(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }

        //Filtrar
        public List<VagaDTO> FiltrarVaga()
        {
            return objDAL.Filtrar();
        }

        //Selecionar

        public VagaDTO SelecionarVaga(int IdVaga)
        {
            return objDAL.Selecionar(IdVaga);
        }
    }

}
