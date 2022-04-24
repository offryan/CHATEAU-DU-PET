using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DAL
{
    public class CertificadoDAL : Conexao
    {
        //inserir - Create
        public void Cadastrar(CertificadoDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Certificado(DsCurso,DsInstituicao,DataInicio,DataConclusao,DsDescricao,FKProfissional) VALUES (@v1,@v2,@v3,@v4,@v5,@v6)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Curso);
                cmd.Parameters.AddWithValue("@v2", objCad.Instituicao);
                cmd.Parameters.AddWithValue("@v3", objCad.DataInicio);
                cmd.Parameters.AddWithValue("@v4", objCad.DataConclusao);
                cmd.Parameters.AddWithValue("@v5", objCad.Descricao);
                cmd.Parameters.AddWithValue("@v6", objCad.FKProfissional);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<CertificadoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdCertificado, DsCurso, DsInstituicao, DataInicio, DataConclusao, DsDescricao, FKProfissional FROM Certificado JOIN Profissional ON FKProfissional=IdCertificado", conn);
                dr = cmd.ExecuteReader();
                List<CertificadoDTO> Lista = new List<CertificadoDTO>();//criando lista vazia

                while (dr.Read())
                {
                    CertificadoDTO obj = new CertificadoDTO();
                    obj.IdCertificado = Convert.ToInt32(dr["IdCertificado"]);
                    obj.Curso = dr["DsCurso"].ToString();
                    obj.Instituicao = dr["DsInstituicao"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataConclusao = dr["DataConclusao"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificado!" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Certificado WHERE IdCertificado=@v7", conn);
                cmd.Parameters.AddWithValue("@v7", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(CertificadoDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Certificado SET DsCurso = @v1,DsInstituicao = @v2,DataInicio = @v3,DataConclusao = @v4,DsDescricao = @v5,FKProfissional = @v6 WHERE IdCertificado = @v7", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.Curso);
                cmd.Parameters.AddWithValue("@v2", objEdita.Instituicao);
                cmd.Parameters.AddWithValue("@v3", objEdita.DataInicio);
                cmd.Parameters.AddWithValue("@v4", objEdita.DataConclusao);
                cmd.Parameters.AddWithValue("@v5", objEdita.Descricao);
                cmd.Parameters.AddWithValue("@v6", objEdita.FKProfissional);
                cmd.Parameters.AddWithValue("@v7", objEdita.IdCertificado);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Certificado!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        //Selecionar
        public CertificadoDTO SelecionarCertificado(int IdProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Certificado  WHERE FKProfissional = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", IdProfissional);
                dr = cmd.ExecuteReader();

                CertificadoDTO obj = new CertificadoDTO();

                if (dr.Read())
                {
                    obj.IdCertificado = Convert.ToInt32(dr["IdCertificado"]); obj.Curso = dr["DsCurso"].ToString();
                    obj.Instituicao = dr["DsInstituicao"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataConclusao = dr["DataConclusao"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);


                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Certificados" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public List<CertificadoDTO> ListarCertificado(int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Certificado  WHERE [FKProfissional] = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();


                List<CertificadoDTO> Lista = new List<CertificadoDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    CertificadoDTO obj = new CertificadoDTO();
                    obj.IdCertificado = Convert.ToInt32(dr["IdCertificado"]);
                    obj.Curso = dr["DsCurso"].ToString();
                    obj.Instituicao = dr["DsInstituicao"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataConclusao = dr["DataConclusao"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);
                    Lista.Add(obj);

                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificados!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
           public List<CertificadoDTO> FiltroCerID(int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Certificado  WHERE FKProfissional = @v1", conn); 
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();

                List<CertificadoDTO> Listar = new List<CertificadoDTO>();
                while (dr.Read())
                {
                    CertificadoDTO obj = new CertificadoDTO();
                    obj.IdCertificado = Convert.ToInt32(dr["IdCertificado"]);
                    obj.Curso = dr["DsCurso"].ToString();
                    obj.Instituicao = dr["DsInstituicao"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataConclusao = dr["DataConclusao"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);
                    Listar.Add(obj);

                }
                return Listar;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificados!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<CertificadoDTO> FiltroCertificado()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Certificado ", conn);
 
                dr = cmd.ExecuteReader();

                List<CertificadoDTO> Listar = new List<CertificadoDTO>();
                while (dr.Read())
                {
                    CertificadoDTO obj = new CertificadoDTO();
                    obj.IdCertificado = Convert.ToInt32(dr["IdCertificado"]);
                    obj.Curso = dr["DsCurso"].ToString();
                    obj.Instituicao = dr["DsInstituicao"].ToString();
                    obj.DataInicio = dr["DataInicio"].ToString();
                    obj.DataConclusao = dr["DataConclusao"].ToString();
                    obj.Descricao = dr["DsDescricao"].ToString();
                    obj.FKProfissional = Convert.ToInt32(dr["FKProfissional"]);
                    Listar.Add(obj);

                }
                return Listar;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Certificados!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
    }
