using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DTO;


namespace ChateauDuPet.DAL
{
   public class VagaDAL:Conexao
    {
        //inserir - create
        public void Cadastrar(VagaDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO VAGA (nmVaga,Experiencia,Registro,Descricao,Sexo,Validade,DataPublicacao,FKEmpresa) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Vaga);
                cmd.Parameters.AddWithValue("@v2", objCad.Experiencia);
                cmd.Parameters.AddWithValue("@v3", objCad.Registro);
                cmd.Parameters.AddWithValue("@v4", objCad.Descricao);
                cmd.Parameters.AddWithValue("@v5", objCad.Sexo);
                cmd.Parameters.AddWithValue("@v6", objCad.Validade);
                cmd.Parameters.AddWithValue("@v7", objCad.DataPublicacao);
                cmd.Parameters.AddWithValue("@v8", objCad.FKEmpresa);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Vaga !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<VagaDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Vaga ORDER BY NmVaga", conn);
                dr = cmd.ExecuteReader();
                List<VagaDTO> Lista = new List<VagaDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    VagaDTO obj = new VagaDTO();
                    obj.IdVaga = Convert.ToInt32(dr["IdVaga"]);
                    obj.Vaga = Convert.ToString(dr["NmVaga"]);
                    obj.Experiencia = dr["DsExperiencia"].ToString();
                    obj.Registro = dr["DsTipoRegistro"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Validade= dr["Validade"].ToString();
                    obj.DataPublicacao = Convert.ToDateTime(dr["DataPublicacao"]);
                    obj.FKEmpresa = Convert.ToInt32(dr["FKEmpresa"]);
                    obj.FKCandidatos = Convert.ToInt32(dr["FKCandidatos"]);
                    
                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Selecionar
        public VagaDTO Selecionar(int IdVaga)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Vaga WHERE IdV", conn);
                cmd.Parameters.AddWithValue("@v9", IdVaga);
                dr = cmd.ExecuteReader();

                VagaDTO obj = new VagaDTO();

                if (dr.Read())
                {
                    obj.IdVaga = Convert.ToInt32(dr["IdVaga"]);
                    obj.Vaga = Convert.ToString(dr["NmVaga"]);


                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Vaga" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Vaga WHERE IdVaga=@v9", conn);
                cmd.Parameters.AddWithValue("@v9", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(VagaDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Vaga SET NmVaga = @v1, DsExperiencia = @v2, DsTipoRegistro = @v3, DsDescricao = @v4, DsSexo = @v5, Validade = @v6, DataPublicacao = @v7, FKEmpresa = @v8, WHERE IdVaga = @v9", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.Vaga);
                cmd.Parameters.AddWithValue("@v2", objEdita.Experiencia);
                cmd.Parameters.AddWithValue("@v3", objEdita.Registro);
                cmd.Parameters.AddWithValue("@v4", objEdita.Descricao);
                cmd.Parameters.AddWithValue("@v5", objEdita.Sexo);
                cmd.Parameters.AddWithValue("@v6", objEdita.Validade);
                cmd.Parameters.AddWithValue("@v7", objEdita.DataPublicacao);
                cmd.Parameters.AddWithValue("@v8", objEdita.FKEmpresa);
                cmd.Parameters.AddWithValue("@v9", objEdita.IdVaga);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Vaga !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Filtrar
        public List<VagaDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Vaga ORDER BY NmVaga", conn);
                dr = cmd.ExecuteReader();
                List<VagaDTO> Lista = new List<VagaDTO>();
                while (dr.Read())
                {
                    VagaDTO obj = new VagaDTO();
                    obj.IdVaga = Convert.ToInt32(dr["IdVaga"]);
                    obj.Vaga = dr["NmVaga"].ToString();
                    obj.Experiencia = dr["DsExperiencia"].ToString();
                    obj.Registro = dr["DsTipoRegistro"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Validade = dr["Validade"].ToString();
                    obj.DataPublicacao = Convert.ToDateTime(dr["DataPublicacao"]);
                    obj.FKEmpresa = Convert.ToInt32(dr["FKEmpresa"]);

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

    }
}
