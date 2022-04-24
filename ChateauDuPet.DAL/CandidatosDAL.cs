using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DTO;
using System.Data.SqlClient;



namespace ChateauDuPet.DAL
{
  public class CandidatosDAL:Conexao
    {

        //inserir - create
        public void CadastrarVP(CandidatosDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Candidatos (IdProfissional ,DsData ,FKEmpresa,FKVaga) VALUES (@v1,@v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Idprofissional);
                cmd.Parameters.AddWithValue("@v2", objCad.DataInscrição);
                cmd.Parameters.AddWithValue("@v3", objCad.IdEmpresa);
                cmd.Parameters.AddWithValue("@v4", objCad.IdEmpresa);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar em vaga!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<CandidatosDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Candidatos ORDER BY DsDAta", conn);
                dr = cmd.ExecuteReader();
                List<CandidatosDTO> Lista = new List<CandidatosDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    CandidatosDTO obj = new CandidatosDTO();
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);
                    obj.IdEmpresa = Convert.ToInt32(dr["FKEmpresa"]);

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Candidatos!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Listar
        public List<CandidatosDTO> ListarID (int idempresa,int idprofissional,int idvaga)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Candidatos = ", conn);
                cmd.Parameters.AddWithValue("@v1", idempresa);
                cmd.Parameters.AddWithValue("@v2", idprofissional);
                cmd.Parameters.AddWithValue("@v3", idvaga);

                dr = cmd.ExecuteReader();
                List<CandidatosDTO> Lista = new List<CandidatosDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    CandidatosDTO obj = new CandidatosDTO();
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);
                    obj.IdEmpresa = Convert.ToInt32(dr["FKEmpresa"]);

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Candidatos!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Selecionar
        public CandidatosDTO Selecionar(int idprofissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Candidato WHERE IdProfissional= @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idprofissional);
                dr = cmd.ExecuteReader();

                CandidatosDTO obj = new CandidatosDTO();
                while (dr.Read())
                {
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["idProfissional"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdEmpresa = Convert.ToInt32(dr["idEmpresa"]);
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);

                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Candidatura" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Candidatos WHERE IdProfissional=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Candidatura!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //Filtrar
        public List<CandidatosDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Candidatos ORDER BY NmVaga", conn);
                dr = cmd.ExecuteReader();
                List<CandidatosDTO> Lista = new List<CandidatosDTO>();
                while (dr.Read())
                {
                    CandidatosDTO obj = new CandidatosDTO();
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdEmpresa = Convert.ToInt32(dr["idEmpresa"]);

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
        public List<CandidatosDTO> FiltrarIDPro( int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Candidatos where idProfissional =@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();
                List<CandidatosDTO> Lista = new List<CandidatosDTO>();
                while (dr.Read())
                {
                    CandidatosDTO obj = new CandidatosDTO();
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdEmpresa = Convert.ToInt32(dr["idEmpresa"]);

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
        public List<CandidatosDTO> FiltrarIDEmpresa(int idEmpresa)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Profissional on  where idEmpresa=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idEmpresa);
                dr = cmd.ExecuteReader();
                List<CandidatosDTO> Lista = new List<CandidatosDTO>();
                while (dr.Read())
                {
                    CandidatosDTO obj = new CandidatosDTO();
                    obj.idCandidato = Convert.ToInt32(dr["IdCandidatos"]);
                    obj.Idprofissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.IdVaga = Convert.ToInt32(dr["FKVaga"]);
                    obj.DataInscrição = dr["DsData"].ToString();
                    obj.IdEmpresa = Convert.ToInt32(dr["idEmpresa"]);

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
