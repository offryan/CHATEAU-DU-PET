using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DAL
{
   public class AdministrativoDAL:Conexao
    {
        //inserir - create
        public void Cadastrar(AdministrativoDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Administrativo(dsEmail,SenhaADM,UrlImage,FKTipoUser) VALUES (@v1,@v2,@v3,@v4)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.NomeAdmin);
                cmd.Parameters.AddWithValue("@v2", objCad.SenhaAdmin);
                cmd.Parameters.AddWithValue("@v3", objCad.UrlImage);
                cmd.Parameters.AddWithValue("@v4", objCad.FKTipoUser);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Admin!" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Administrativo WHERE IdAdministrativo=@v5", conn);
                cmd.Parameters.AddWithValue("@v5", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar
        public AdministrativoDTO Autenticar(string objEmailA, string objSenhaA)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT dsEmail, SenhaADM, FKTipoUser FROM Administrativo WHERE dsEmail=@v1 AND SenhaADM=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", objEmailA);
                cmd.Parameters.AddWithValue("@v2", objSenhaA);
                dr = cmd.ExecuteReader();
                AdministrativoDTO obj = null;
                if (dr.Read())
                {
                    obj = new AdministrativoDTO();
                    obj.NomeAdmin = dr["dsEmail"].ToString();
                    obj.SenhaAdmin = dr["SenhaADM"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(AdministrativoDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Administrativo SET NmADM = @v1,SenhaADM = @v2,UrlImagem = @v3,FKTipoUser = @v4, WHERE IdUsuario = @v5", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.NomeAdmin);
                cmd.Parameters.AddWithValue("@v2", objEdita.SenhaAdmin);
                cmd.Parameters.AddWithValue("@v3", objEdita.UrlImage);
                cmd.Parameters.AddWithValue("@v4", objEdita.FKTipoUser);
                cmd.Parameters.AddWithValue("@v5", objEdita.IdAdministrativo);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Administrativo !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<AdministrativoDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdAdministrativo, NmADM, SenhaADM, UrlImage, FKTipoUser FROM Administrativo JOIN TipoUser ON FKTipoUser=IdTipoUser", conn);
                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();//criando lista vazia

                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO();
                    obj.IdAdministrativo = Convert.ToInt32(dr["IdAdministrativo"]);
                    obj.NomeAdmin = dr["NmADM"].ToString();
                    obj.SenhaAdmin = dr["SenhaADM"].ToString();
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);
                    

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Filtrar
        public List<AdministrativoDTO> Filtrar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Administrativo ORDER BY NmADM", conn);
                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();
                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO();
                    obj.IdAdministrativo = Convert.ToInt32(dr["IdVaga"]);
                    obj.NomeAdmin = dr["NmVaga"].ToString();
                    obj.SenhaAdmin = dr["DsExperiencia"].ToString();
                    obj.UrlImage = dr["DsTipoRegistro"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["DsDescricao"]);
                    ;

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Filtrar
        public List<AdministrativoDTO> FiltrarID(int idOperador)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Administrativo where IdAdministrativo=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idOperador);

                dr = cmd.ExecuteReader();
                List<AdministrativoDTO> Lista = new List<AdministrativoDTO>();
                while (dr.Read())
                {
                    AdministrativoDTO obj = new AdministrativoDTO();
                    obj.IdAdministrativo = Convert.ToInt32(dr["IdVaga"]);
                    obj.NomeAdmin = dr["NmVaga"].ToString();
                    obj.SenhaAdmin = dr["DsExperiencia"].ToString();
                    obj.UrlImage = dr["DsTipoRegistro"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["DsDescricao"]);
                    ;

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Filtrar Admin!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
