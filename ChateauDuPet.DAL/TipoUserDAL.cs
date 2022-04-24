using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DAL
{
   public class TipoUserDAL:Conexao
    {
        //Autenticar
        public AutenticaDTO Autenticar(string objNome, string objSenha)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT DsEmail, Senha, FKTipoUser FROM Usuario WHERE NomeUsuario=@v1 AND SenhaUsuario=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", objNome);
                cmd.Parameters.AddWithValue("@v2", objSenha);

                AutenticaDTO obj = null;
                if (dr.Read())
                {
                    obj = new AutenticaDTO();
                    obj.Email = dr["NomeUsuario"].ToString();
                    obj.Senha = dr["SenhaUsuario"].ToString();
                    obj.FKTipoUser = Convert.ToInt32 (dr["FKTipoUser"]);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

       
    }
}
