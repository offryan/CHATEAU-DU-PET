using ChateauDuPet.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChateauDuPet.DAL
{
    public class ProfissionalDAL : Conexao
    {
        //inserir - create
        public void Cadastrar(ProfissionalDTO objCad)
        {
            try
            {
                Conectar(); cmd = new SqlCommand("  INSERT INTO Profissional(NmProfissional,DsEmail,NroCPF,SenhaProfissional,NroTelefone,FKTipoUser,DsUser,DtNascimento,DsSexo,DtTermos,DsPrivacidade) " +
                    " VALUES(@Nome, @Email, @CPF, @Senha, @Tel, @TipoUSer, @User, @DtNascimento, @Sexo,@Termos,@Privacidade ); ", conn);
                cmd.Parameters.AddWithValue("@Nome", objCad.Nome);
                cmd.Parameters.AddWithValue("@Email", objCad.Email);
                cmd.Parameters.AddWithValue("@CPF", objCad.CPF);
                cmd.Parameters.AddWithValue("@Senha", objCad.Senha);
                cmd.Parameters.AddWithValue("@Tel", objCad.Telefone);
                cmd.Parameters.AddWithValue("@TipoUser", objCad.FKTipoUser);
                cmd.Parameters.AddWithValue("@User", objCad.User);
                cmd.Parameters.AddWithValue("@DtNascimento", objCad.Nascimento);
                cmd.Parameters.AddWithValue("@Sexo", objCad.Sexo);
                cmd.Parameters.AddWithValue("@Termos", objCad.Termos);
                cmd.Parameters.AddWithValue("@Privacidade", objCad.Privacidade);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        public List<ProfissionalDTO> FiltrarP()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("Select  * from profissional order by nmProfissional", conn);
                dr = cmd.ExecuteReader();
                List<ProfissionalDTO> Listar = new List<ProfissionalDTO>();
                while (dr.Read())
                {
                    ProfissionalDTO obj = new ProfissionalDTO();
                    obj.IdProfissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.Nome = dr["NmProfissional"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.Biografia = dr["DsBiografia"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.FormacaoEscolar = dr["FormacaoEscolar"].ToString();
                    obj.Sexo = dr["dsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.NroEndereco = dr["NroEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCEP"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.User = dr["DsUser"].ToString();
                    Listar.Add(obj);


                }
                return Listar;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Profissional!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }

        public List<ProfissionalDTO> FiltrarPro(int idProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("Select idProfissional,NmProfissional,DsEmail,NroCPF,NroTelefone," +
                            "DsBiografia,DtNascimento,FormacaoEscolar,dsSexo,DsEndereco,NroEndereco,DsComplemento,DsCEP," +
                            "DsBairro,DsCidade,DsUF,UrlImage,DsUser from profissional where idprofissional=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", idProfissional);
                dr = cmd.ExecuteReader();
                List<ProfissionalDTO> Listar = new List<ProfissionalDTO>();
                while (dr.Read())
                {
                    ProfissionalDTO obj = new ProfissionalDTO();
                    obj.IdProfissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.Nome = dr["NmProfissional"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.Biografia = dr["DsBiografia"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.FormacaoEscolar = dr["FormacaoEscolar"].ToString();
                    obj.Sexo = dr["dsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.NroEndereco = dr["NroEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCEP"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.User = dr["DsUser"].ToString();
                    Listar.Add(obj);


                }
                return Listar;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Profissional!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
        //Listar
        public List<ProfissionalDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdProfissional, NmProfissional, DsEmail, NroCPF, SenhaProfissional, NroTelefone, DsBiografia, DtNascimento, FormacaoEscolar, DsSexo, DsEndereco, DsComplemento, DsCEP , DsBairro, DsCidade, DsUF, DtTermos, DsPrivacidade, UrlImage,DsUser FKTipoUser FROM Profissional JOIN TipoUser ON FKTipoUser=IdProfissional", conn);
                dr = cmd.ExecuteReader();

                List<ProfissionalDTO> Lista = new List<ProfissionalDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    ProfissionalDTO obj = new ProfissionalDTO();
                    obj.IdProfissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.Nome = dr["NmProfissional"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Senha = dr["SenhaProfissional"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.Biografia = dr["DsBiografia"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.FormacaoEscolar = dr["FormacaoEscolar"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCEP"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString(); 
                    obj.Termos = Convert.ToDateTime(dr["DtTermos"]);
                    obj.Privacidade = Convert.ToDateTime(dr["DsPrivacidade"]);
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);
                    obj.User = dr["DsUser"].ToString();


                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Profissional!" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Profissional WHERE IdProfissional=@v10", conn);
                cmd.Parameters.AddWithValue("@v10", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Profissional!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autenticar
        public ProfissionalDTO Autenticar(string objEmailP, string objSenhaP)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT idprofissional, DsEmail, SenhaProfissional, FKTipoUser FROM Profissional WHERE DsEmail=@v2 AND SenhaProfissional=@v4", conn);
                cmd.Parameters.AddWithValue("@v2", objEmailP);
                cmd.Parameters.AddWithValue("@v4", objSenhaP);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = null;
                if (dr.Read())
                {
                    obj = new ProfissionalDTO();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.Senha = dr["SenhaProfissional"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);
                    obj.IdProfissional = Convert.ToInt32(dr["IdProfissional"]);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Profissional !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Autentica Cadastro
        public ProfissionalDTO AutenticaEmail(string objEmail)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Profissional WHERE DsEmail=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objEmail);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = null;
                if (dr.Read())
                {
                    obj = new ProfissionalDTO();
                    obj.Email = dr["DsEmail"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Email !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ProfissionalDTO AutenticaUser(string objUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Profissional WHERE DsUser=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objUser);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = null;
                if (dr.Read())
                {
                    obj = new ProfissionalDTO();
                    obj.User = dr["DsUser"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar User!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public ProfissionalDTO AutenticaCPF( string objCPF)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Profissional WHERE NroCPF =@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objCPF);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = null;
                if (dr.Read())
                {
                    obj = new ProfissionalDTO();
                    obj.CPF = dr["NroCPF"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar CPF !" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        //Selecionar
        public ProfissionalDTO Selecionar(int IdProfissional)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Profissional  WHERE IdProfissional =@v1", conn);
                cmd.Parameters.AddWithValue("@v1", IdProfissional);
                dr = cmd.ExecuteReader();

                ProfissionalDTO obj = new ProfissionalDTO();

                if (dr.Read())
                {
                    obj.IdProfissional = Convert.ToInt32(dr["IdProfissional"]);
                    obj.Nome = dr["NmProfissional"].ToString();
                    obj.Email =dr["DsEmail"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Senha = dr["SenhaProfissional"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.Biografia = dr["DsBiografia"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.FormacaoEscolar = dr["FormacaoEscolar"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.NroEndereco = dr["NroEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCEP"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.UrlImage = dr["urlimage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FkTipoUSer"]);
                    obj.User = dr["DsUSer"].ToString();


                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Profissional" + ex.Message);
            }
            finally
            {
                Desconectar();
            }

        }
            //Editar - Update
            public void Editar(ProfissionalDTO objEdita)
            {
                try
                {
                    Conectar();
                    cmd = new SqlCommand("update  profissional set  NmProfissional =@2, DsEmail =@3, NroCPF =@4,  NroTelefone =@6, DsBiografia =@7," +
                        " DtNascimento =@8, FormacaoEscolar =@9, DsSexo =@10, DsEndereco =@11, NroEndereco =@12, DsComplemento =@13," +
                        "  DsCEP =@14, DsBairro =@15, DsCidade =@16, DsUF =@17, UrlImage =@18, DsUser =@19 where= idProfissional=@1", conn);

                    cmd.Parameters.AddWithValue("@v1", objEdita.IdProfissional);
                    cmd.Parameters.AddWithValue("@v2", objEdita.Nome);
                    cmd.Parameters.AddWithValue("@v3", objEdita.Email);
                    cmd.Parameters.AddWithValue("@v4", objEdita.CPF);
                    cmd.Parameters.AddWithValue("@v6", objEdita.Telefone);
                    cmd.Parameters.AddWithValue("@v7", objEdita.Biografia);
                    cmd.Parameters.AddWithValue("@v8", objEdita.Nascimento);
                    cmd.Parameters.AddWithValue("@v9", objEdita.FormacaoEscolar);
                    cmd.Parameters.AddWithValue("@v10", objEdita.Sexo);
                    cmd.Parameters.AddWithValue("@v11", objEdita.Endereco);
                    cmd.Parameters.AddWithValue("@v12", objEdita.NroEndereco);
                    cmd.Parameters.AddWithValue("@v13", objEdita.Complemento);
                    cmd.Parameters.AddWithValue("@v14", objEdita.CEP);
                    cmd.Parameters.AddWithValue("@v15", objEdita.Bairro);
                    cmd.Parameters.AddWithValue("@v16", objEdita.Cidade);
                    cmd.Parameters.AddWithValue("@v17", objEdita.UF);
                    cmd.Parameters.AddWithValue("@v18", objEdita.UrlImage);
                    cmd.Parameters.AddWithValue("@v19", objEdita.User);


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

    }
}
