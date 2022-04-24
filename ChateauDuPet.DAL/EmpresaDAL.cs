using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChateauDuPet.DTO;


namespace ChateauDuPet.DAL
{
    public class EmpresaDAL : Conexao
    {

        //inserir - create
        public void Cadastrar(EmpresaDTO objCad)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("INSERT INTO Empresa(NmRecrutador,NroCPF,DsEmail,NroTelefone,SenhaEmpresa,DtNascimento,DsSexo,DtTermos,DsPrivacidade,FKTipoUser,dsuser) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@11)", conn);
                cmd.Parameters.AddWithValue("@v1", objCad.Recrutador);
                cmd.Parameters.AddWithValue("@v2", objCad.CPF);
                cmd.Parameters.AddWithValue("@v3", objCad.Email);
                cmd.Parameters.AddWithValue("@v4", objCad.Telefone);
                cmd.Parameters.AddWithValue("@v5", objCad.SenhaEmpresa);
                cmd.Parameters.AddWithValue("@v6", objCad.Nascimento);
                cmd.Parameters.AddWithValue("@v7", objCad.Sexo);
                cmd.Parameters.AddWithValue("@v8", objCad.Termos);
                cmd.Parameters.AddWithValue("@v9", objCad.Privacidade);
                cmd.Parameters.AddWithValue("@v10", objCad.FKTipoUser);
                cmd.Parameters.AddWithValue("@11", objCad.User);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao cadastrar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }



        //Autenticar
        public EmpresaDTO Autenticar(string objEmailE, string objSenhaE)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT DsEmail, SenhaEmpresa, FKTipoUser idempresa FROM Empresa WHERE DsEmail=@v1 AND SenhaEmpresa=@v2", conn);
                cmd.Parameters.AddWithValue("@v1", objEmailE);
                cmd.Parameters.AddWithValue("@v2", objSenhaE);
                dr = cmd.ExecuteReader();

                EmpresaDTO obj = null;
                if (dr.Read())
                {
                    obj = new EmpresaDTO();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.SenhaEmpresa = dr["SenhaEmpresa"].ToString();
                    obj.IdEmpresa = Convert.ToInt32(dr["idEmpresa"]);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public EmpresaDTO AutenticaEmail(string objEmail)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT DsEmail,  FROM Empresa WHERE DsEmail=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objEmail);
                dr = cmd.ExecuteReader();

                EmpresaDTO obj = null;
                if (dr.Read())
                {
                    obj = new EmpresaDTO();
                    obj.Email = dr["DsEmail"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public EmpresaDTO AutenticaUser(string objUser)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT dsUser FROM Empresa WHERE DsUser=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objUser);
                dr = cmd.ExecuteReader();

                EmpresaDTO obj = null;
                if (dr.Read())
                {
                    obj = new EmpresaDTO();
                    obj.User =  dr["DsUser"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public EmpresaDTO AutenticaCPF(string objCPF)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT NroCPF FROM Empresa WHERE NroCPF=@v1", conn);
                cmd.Parameters.AddWithValue("@v1", objCPF);
                dr = cmd.ExecuteReader();

                EmpresaDTO obj = null;
                if (dr.Read())
                {
                    obj = new EmpresaDTO();
                    obj.CPF = dr["NroCPF"].ToString();
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Autenticar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Listar
        public List<EmpresaDTO> Listar()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT IdEmpresa, NmRecrutador, NroCPF, DsEmail, NroTelefone, SenhaEmpresa, DtNascimento, DsSexo, DsEndereco, DsComplemento, DsCep, DsBairro, DsCidade, DsUF, NroCNPJ, DsNomeFantasia, DsRazaoSocial, DsDataAbertura, DtTermos, DsPrivacidade, UrlImage, FKTipoUser FROM Empresa JOIN TipoUser ON FKTipoUser=IdEmpresa", conn);
                dr = cmd.ExecuteReader();
                List<EmpresaDTO> Lista = new List<EmpresaDTO>();
                //criando lista vazia

                while (dr.Read())
                {
                    EmpresaDTO obj = new EmpresaDTO();
                    obj.IdEmpresa = Convert.ToInt32(dr["IdEmpresa"]);
                    obj.Recrutador = dr["NmRecrutador"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.SenhaEmpresa = dr["SenhaEmpresa"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.Complemento = dr["DsComp lemento"].ToString();
                    obj.CEP = dr["DsCep"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.CNPJ = dr["NroCNPJ"].ToString();
                    obj.NomeFantasia = dr["DsNomeFantasia"].ToString();
                    obj.RazaoSocial = dr["DsRazaoSocial"].ToString();
                    obj.DataAbertura = dr["DsDataAbertura"].ToString();
                    obj.Termos = Convert.ToDateTime(dr["DtTermos"]);
                    obj.Privacidade = Convert.ToDateTime(dr["DsPrivacidade"]);
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);

                    Lista.Add(obj);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Listar Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //Editar - Update
        public void Editar(EmpresaDTO objEdita)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Empresa SET NmRecrutador = @v1,NroCPF = @v2,DsEmail = @v3,NroTelefone = @v4,SenhaEmpresa = @v5,DtNascimento = @v6,DsSexo = @v7,DsEndereco = @v8,DsComplemento = @v9,DsCep = @v10,DsBairro = @v11,DsCidade = @v12,DsUF = @v13,NroCNPJ = @v14,DsNomeFantasia = @v15,DsRazaoSocial = @v16,DsDataAbertura = @v17,DtTermos = @v18,DsPrivacidade = @v19,UrlImage = @v20,FKTipoUser = @v21 WHERE IdEmpresa = @v22", conn);

                cmd.Parameters.AddWithValue("@v1", objEdita.Recrutador);
                cmd.Parameters.AddWithValue("@v2", objEdita.CPF);
                cmd.Parameters.AddWithValue("@v3", objEdita.Email);
                cmd.Parameters.AddWithValue("@v4", objEdita.Telefone);
                cmd.Parameters.AddWithValue("@v5", objEdita.SenhaEmpresa);
                cmd.Parameters.AddWithValue("@v6", objEdita.Nascimento);
                cmd.Parameters.AddWithValue("@v7", objEdita.Sexo);
                cmd.Parameters.AddWithValue("@v8", objEdita.Endereco);
                cmd.Parameters.AddWithValue("@v9", objEdita.Complemento);
                cmd.Parameters.AddWithValue("@v10", objEdita.CEP);
                cmd.Parameters.AddWithValue("@v11", objEdita.Bairro);
                cmd.Parameters.AddWithValue("@v12", objEdita.Cidade);
                cmd.Parameters.AddWithValue("@v13", objEdita.UF);
                cmd.Parameters.AddWithValue("@v14", objEdita.CNPJ);
                cmd.Parameters.AddWithValue("@v15", objEdita.NomeFantasia);
                cmd.Parameters.AddWithValue("@v16", objEdita.RazaoSocial);
                cmd.Parameters.AddWithValue("@v17", objEdita.DataAbertura);
                cmd.Parameters.AddWithValue("@v18", objEdita.Termos);
                cmd.Parameters.AddWithValue("@v19", objEdita.Privacidade);
                cmd.Parameters.AddWithValue("@v20", objEdita.UrlImage);
                cmd.Parameters.AddWithValue("@v21", objEdita.FKTipoUser);
                cmd.Parameters.AddWithValue("@v22", objEdita.IdEmpresa);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Editar Empresa!" + ex.Message);
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
                cmd = new SqlCommand("DELETE FROM Empresa WHERE IdEmpresa=@v22", conn);
                cmd.Parameters.AddWithValue("@v22", objExclui);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Excluir Empresa!" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        public EmpresaDTO Selecionar(int idEmpresa)
        {
            try
            {

                Conectar();
                cmd = new SqlCommand("SELECT * FROM empresa WHERE IdEmpresa = @v1", conn);
                cmd.Parameters.AddWithValue("@v1", idEmpresa);
                dr = cmd.ExecuteReader();

                EmpresaDTO obj = new EmpresaDTO();
                if (dr.Read())
                {
                    obj.IdEmpresa = Convert.ToInt32(dr["IdEmpresa"]);
                    obj.Recrutador = dr["NmRecrutador"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.SenhaEmpresa = dr["SenhaEmpresa"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCep"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.CNPJ = dr["NroCNPJ"].ToString();
                    obj.NomeFantasia = dr["DsNomeFantasia"].ToString();
                    obj.RazaoSocial = dr["DsRazaoSocial"].ToString();
                    obj.DataAbertura = dr["DsDataAbertura"].ToString();
                    obj.Termos = Convert.ToDateTime(dr["DtTermos"]);
                    obj.Privacidade = Convert.ToDateTime(dr["DsPrivacidade"]);
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);
                }
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao selecionar Empresa" + ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        

        public List<EmpresaDTO> Filtro()
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("Select * from empresa order by NmRecrutador", conn);

                dr = cmd.ExecuteReader();
                List<EmpresaDTO> Lista = new List<EmpresaDTO>();

                while (dr.Read())
                {
                    EmpresaDTO obj = new EmpresaDTO();
                    obj.IdEmpresa = Convert.ToInt32(dr["IdEmpresa"]);
                    obj.Recrutador = dr["NmRecrutador"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.SenhaEmpresa = dr["SenhaEmpresa"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCep"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.CNPJ = dr["NroCNPJ"].ToString();
                    obj.NomeFantasia = dr["DsNomeFantasia"].ToString();
                    obj.RazaoSocial = dr["DsRazaoSocial"].ToString();
                    obj.DataAbertura = dr["DsDataAbertura"].ToString();
                    obj.Termos = Convert.ToDateTime(dr["DtTermos"]);
                    obj.Privacidade = Convert.ToDateTime(dr["DsPrivacidade"]);
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);

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

        public List<EmpresaDTO> FiltroID(int idEmpresa)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("Select * from empresa order by NmRecrutador", conn);
                cmd.Parameters.AddWithValue("@v1", idEmpresa);
                dr = cmd.ExecuteReader();
                List<EmpresaDTO> Lista = new List<EmpresaDTO>();

                while (dr.Read())
                {
                    EmpresaDTO obj = new EmpresaDTO();
                    obj.IdEmpresa = Convert.ToInt32(dr["IdEmpresa"]);
                    obj.Recrutador = dr["NmRecrutador"].ToString();
                    obj.CPF = dr["NroCPF"].ToString();
                    obj.Email = dr["DsEmail"].ToString();
                    obj.Telefone = dr["NroTelefone"].ToString();
                    obj.SenhaEmpresa = dr["SenhaEmpresa"].ToString();
                    obj.Nascimento = dr["DtNascimento"].ToString();
                    obj.Sexo = dr["DsSexo"].ToString();
                    obj.Endereco = dr["DsEndereco"].ToString();
                    obj.Complemento = dr["DsComplemento"].ToString();
                    obj.CEP = dr["DsCep"].ToString();
                    obj.Bairro = dr["DsBairro"].ToString();
                    obj.Cidade = dr["DsCidade"].ToString();
                    obj.UF = dr["DsUF"].ToString();
                    obj.CNPJ = dr["NroCNPJ"].ToString();
                    obj.NomeFantasia = dr["DsNomeFantasia"].ToString();
                    obj.RazaoSocial = dr["DsRazaoSocial"].ToString();
                    obj.DataAbertura = dr["DsDataAbertura"].ToString();
                    obj.Termos = Convert.ToDateTime(dr["DtTermos"]);
                    obj.Privacidade = Convert.ToDateTime(dr["DsPrivacidade"]);
                    obj.UrlImage = dr["UrlImage"].ToString();
                    obj.FKTipoUser = Convert.ToInt32(dr["FKTipoUser"]);

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
