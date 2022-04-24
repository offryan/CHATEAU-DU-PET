using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DAL
{
   public class ExperienciaDAL:Conexao
    {
        //inserir - create
        public void Cadastrar(ExperienciaDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Experiencia(DsCargo,DsEmpresa,DsTipoContrato,DsLocalidade,DataInicio,DataFinal,FKProfissional) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Cargo);
                cmd.Parameters.AddWithValue("@v2", objCad.Empresa);
                cmd.Parameters.AddWithValue("@v3", objCad.TipoContrato);
                cmd.Parameters.AddWithValue("@v4", objCad.Localidade);
                cmd.Parameters.AddWithValue("@v5", objCad.DataInicio);
                cmd.Parameters.AddWithValue("@v6", objCad.DataFinal);
                cmd.Parameters.AddWithValue("@v7", objCad.FKProfissional);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<ExperienciaDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdExperiencia, DsCargo, DsEmpresa, DsTipoContrato, DsLocalidade, DataInicio, DataFinal, FKProfissional FROM Experiencia JOIN Profissional ON FKProfissional=IdExperiencia", conn);
                dr = cmd.ExecuteReader();
                List<ExperienciaDTO> Lista = new List<ExperienciaDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    ExperienciaDTO obj = new ExperienciaDTO();
                    obj.IdExperiencia = Convert.ToInt32(dr["IdExperiencia"]);
                    obj.Cargo = dr["DsCargo"].ToString();
                    obj.Empresa = dr["DsEmpresa"].ToString();
                    obj.TipoContrato = dr["DsTipoContrato"].ToString();
                    obj.Localidade = dr["DsLocalidade"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataFinal = dr["DataFinal"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);
                  
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(ExperienciaDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Experiencia SET DsCargo = @v1,DsEmpresa = @v2,DsTipoContrato = @v3,DsLocalidade = @v4,DataInicio = @v5,DataFinal = @v6,FKProfissional = @v7 WHERE IdExperiencia = @v8", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.Cargo);
                cmd.Parameters.AddWithValue("@v2", objEdita.Empresa);
                cmd.Parameters.AddWithValue("@v3", objEdita.TipoContrato);
                cmd.Parameters.AddWithValue("@v4", objEdita.Localidade);
                cmd.Parameters.AddWithValue("@v5", objEdita.DataInicio);
                cmd.Parameters.AddWithValue("@v6", objEdita.DataFinal);
                cmd.Parameters.AddWithValue("@v7", objEdita.FKProfissional);
                cmd.Parameters.AddWithValue("@v8", objEdita.IdExperiencia);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Delete
        public void Excluir(int objExclui)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Experiencia WHERE IdExperiencia=@v8", conn);
                cmd.Parameters.AddWithValue("@v8", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        //Selecionar
        public ExperienciaDTO SelecionaExp(int IdProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM experiencia  WHERE FKProfissional = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", IdProfissional);
                dr = cmd.ExecuteReader();

                ExperienciaDTO obj = new ExperienciaDTO();
                while (dr.Read())
                {
                    obj.IdExperiencia = Convert.ToInt32(dr["IdExperiencia"]);
                    obj.Cargo = dr["DsCargo"].ToString();
                    obj.Empresa = dr["DsEmpresa"].ToString();
                    obj.TipoContrato = dr["DsTipoContrato"].ToString();
                    obj.Localidade = dr["DsLocalidade"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataFinal = dr["DataFinal"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);

                  
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Experiencia" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<ExperienciaDTO> FiltroExpID(int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Experiencia  WHERE FKProfissional = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();

                List<ExperienciaDTO> Listar = new List<ExperienciaDTO>();

                while (dr.Read())
                {
                    ExperienciaDTO obj = new ExperienciaDTO();
                    obj.IdExperiencia = Convert.ToInt32(dr["IdExperiencia"]);
                    obj.Cargo = dr["DsCargo"].ToString();
                    obj.Empresa = dr["DsEmpresa"].ToString();
                    obj.TipoContrato = dr["DsTipoContrato"].ToString();
                    obj.Localidade = dr["DsLocalidade"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataFinal = dr["DataFinal"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);

                    Listar.Add(obj);
                }
                return Listar;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Experiencia!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<ExperienciaDTO> FiltroExp()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Experiencia ", conn);

                dr = cmd.ExecuteReader();

                List<ExperienciaDTO> Listar = new List<ExperienciaDTO>();
                while (dr.Read())
                {
                    ExperienciaDTO obj = new ExperienciaDTO();
                    obj.IdExperiencia = Convert.ToInt32(dr["IdExperiencia"]);
                    obj.Cargo = dr["DsCargo"].ToString();
                    obj.Empresa = dr["DsEmpresa"].ToString();
                    obj.TipoContrato = dr["DsTipoContrato"].ToString();
                    obj.Localidade = dr["DsLocalidade"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataFinal = dr["DataFinal"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);

                    Listar.Add(obj);
                }
                return Listar;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Experiencia !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
