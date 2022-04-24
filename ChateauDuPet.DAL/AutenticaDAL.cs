using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DTO;

namespace ChateauDuPet.DAL
{
    public class AutenticaDAL : Conexao
    {
        //Autenticar

        public AutenticaDTO Autenticar(string objEmail, string objSenha, int objTipoUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT Email, Senha, FKTpUsuario FROM TipoUsuario WHERE Email=@v1, Senha=@v2 AND FKTipoUser=@v3", conn);
                cmd.Parameters.AddWithValue("@v1", objEmail);
                cmd.Parameters.AddWithValue("@v2", objSenha);
                cmd.Parameters.AddWithValue("@v3", objTipoUser);
                dr = cmd.ExecuteReader();

                AutenticaDTO obj = null;
                if (dr.Read())
                {
                    obj = new AutenticaDTO();
                    obj.Email = dr["Email"].ToString();
                    obj.Senha = dr["Senha"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTpUsuario"]);
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Usuário não cadastrado !! " + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
    }
}
    