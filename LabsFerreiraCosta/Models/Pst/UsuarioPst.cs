using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LabsFerreiraCosta.Models.Pst {

    /* File History
 * --------------------------------------------------------------------
 * Created by : Luciano Filho
 * Date       : 13/02/2021
 * Purpose    : Criação da Pst do Usuário
 * --------------------------------------------------------------------
 */

    public class UsuarioPst {

        #region Connection

        public SqlConnection _con = new SqlConnection(ConfigurationManager.ConnectionStrings["AuxiliarConnectionString"].ConnectionString);
      
        #endregion

        #region Methods

        /* Incluir Usuário */
        public bool Incluir(UsuarioMdl Usuario) {
            int i;

            using (SqlCommand Command = new SqlCommand("stp_usuario_incluir", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@nome", Usuario.Nome);
                Command.Parameters.AddWithValue("@login", Usuario.Login);
                Command.Parameters.AddWithValue("@senha", Usuario.Senha);
                Command.Parameters.AddWithValue("@email", Usuario.Email);
                Command.Parameters.AddWithValue("@fone", Usuario.Fone);
                Command.Parameters.AddWithValue("@cpf", Usuario.Cpf);
                Command.Parameters.AddWithValue("@data_nascimento", Usuario.DataNascimento);
                Command.Parameters.AddWithValue("@nome_mae", Usuario.NomeMae);
                Command.Parameters.AddWithValue("@status", Usuario.Status);

                _con.Open();

                i = Command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        /* Pesquisar Usuário */
        public List<UsuarioMdl> Pesquisar(string nome, string cpf, string login, string status) {

            List<UsuarioMdl> Usuarios = new List<UsuarioMdl>();

            using (SqlCommand Command = new SqlCommand("stp_usuario_pesquisar", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read()) {
                    UsuarioMdl Usuario = new UsuarioMdl();

                    Usuario.Id = Convert.ToInt32(reader["id"]);
                    if (reader["nome"] != DBNull.Value) {
                        Usuario.Nome = Convert.ToString(reader["nome"]);
                    }
                    if (reader["login"] != DBNull.Value) {
                        Usuario.Login = Convert.ToString(reader["login"]);
                    }
                    if (reader["senha"] != DBNull.Value) {
                        Usuario.Senha = Convert.ToString(reader["senha"]);
                    }
                    if (reader["email"] != DBNull.Value) {
                        Usuario.Email = Convert.ToString(reader["email"]);
                    }
                    if (reader["fone"] != DBNull.Value) {
                        Usuario.Fone = Convert.ToString(reader["fone"]);
                    }
                    if (reader["cpf"] != DBNull.Value) {
                        Usuario.Cpf = Convert.ToString(reader["cpf"]);
                    }
                    if (reader["data_nascimento"] != DBNull.Value) {
                        Usuario.DataNascimento = Convert.ToDateTime(reader["data_nascimento"]);
                    }
                    if (reader["nome_mae"] != DBNull.Value) {
                        Usuario.NomeMae = Convert.ToString(reader["nome_mae"]);
                    }
                    if (reader["data_inclusao"] != DBNull.Value) {
                        Usuario.DataInclusao = Convert.ToDateTime(reader["data_inclusao"]);
                    }
                    if (reader["data_alteracao"] != DBNull.Value) {
                        Usuario.DataAlteracao = Convert.ToDateTime(reader["data_alteracao"]);
                    }
                    if (reader["status"] != DBNull.Value) {
                        Usuario.Status = Convert.ToString(reader["status"]);
                    }
                    
                    Usuarios.Add(Usuario);
                }
                _con.Close();

                return Usuarios;
            }
        }

        public List<UsuarioMdl> Pesquisar() {

            List<UsuarioMdl> Usuarios = new List<UsuarioMdl>();

            using (SqlCommand Command = new SqlCommand("stp_usuario_pesquisar", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                _con.Open();

                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read()) {
                    UsuarioMdl Usuario = new UsuarioMdl();

                    Usuario.Id = Convert.ToInt32(reader["id"]);
                    if (reader["nome"] != DBNull.Value) {
                        Usuario.Nome = Convert.ToString(reader["nome"]);
                    }
                    if (reader["login"] != DBNull.Value) {
                        Usuario.Login = Convert.ToString(reader["login"]);
                    }
                    if (reader["senha"] != DBNull.Value) {
                        Usuario.Senha = Convert.ToString(reader["senha"]);
                    }
                    if (reader["email"] != DBNull.Value) {
                        Usuario.Email = Convert.ToString(reader["email"]);
                    }
                    if (reader["fone"] != DBNull.Value) {
                        Usuario.Fone = Convert.ToString(reader["fone"]);
                    }
                    if (reader["cpf"] != DBNull.Value) {
                        Usuario.Cpf = Convert.ToString(reader["cpf"]);
                    }
                    if (reader["data_nascimento"] != DBNull.Value) {
                        Usuario.DataNascimento = Convert.ToDateTime(reader["data_nascimento"]);
                    }
                    if (reader["nome_mae"] != DBNull.Value) {
                        Usuario.NomeMae = Convert.ToString(reader["nome_mae"]);
                    }
                    if (reader["data_inclusao"] != DBNull.Value) {
                        Usuario.DataInclusao = Convert.ToDateTime(reader["data_inclusao"]);
                    }
                    if (reader["data_alteracao"] != DBNull.Value) {
                        Usuario.DataAlteracao = Convert.ToDateTime(reader["data_alteracao"]);
                    }
                    if (reader["status"] != DBNull.Value) {
                        Usuario.Status = Convert.ToString(reader["status"]);
                    }

                    Usuarios.Add(Usuario);
                }
                _con.Close();

                return Usuarios;
            }
        }

        /* Alterar Usuário */
        public void Alterar(UsuarioMdl Usuario) {

            using (SqlCommand Command = new SqlCommand("stp_usuario_alterar", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@id", Usuario.Id);
                Command.Parameters.AddWithValue("@nome", Usuario.Nome);
                Command.Parameters.AddWithValue("@login", Usuario.Login);
                Command.Parameters.AddWithValue("@senha", Usuario.Senha);
                Command.Parameters.AddWithValue("@email", Usuario.Email);
                Command.Parameters.AddWithValue("@fone", Usuario.Fone);
                Command.Parameters.AddWithValue("@cpf", Usuario.Cpf);
                Command.Parameters.AddWithValue("@data_nascimento", Usuario.DataNascimento);
                Command.Parameters.AddWithValue("@nome_mae", Usuario.NomeMae);
                Command.Parameters.AddWithValue("@status", Usuario.Status);

                _con.Open();

                Command.ExecuteNonQuery();
            }
            _con.Close();
        }

        /* Excluir Usuário */
        public bool Excluir(int id) {
            int i;

            using (SqlCommand Command = new SqlCommand("stp_usuario_excluir", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@id", id);

                _con.Open();

                i = Command.ExecuteNonQuery();
            }
            _con.Close();
            return i >= 1;
        }

        /* Validar Login Usuário */
        public bool Validar(string login, string senha) {
            int i=0;

            using (SqlCommand Command = new SqlCommand("stp_usuario_validar_login", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@login", login);
                Command.Parameters.AddWithValue("@senha", senha);
                _con.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while(reader.Read()) {
                    i = 1;
                } 
            }
            _con.Close();
            return i >= 1;
        }

        /* Criar nova senha do Usuário */
        public bool CriarNovaSenha(string login, string senha, string cpf) {
            int i = 0;

            using (SqlCommand Command = new SqlCommand("stp_usuario_nova_senha", _con)) {
                Command.CommandType = CommandType.StoredProcedure;
                Command.Parameters.AddWithValue("@login", login);
                Command.Parameters.AddWithValue("@senha", senha);
                Command.Parameters.AddWithValue("@cpf", cpf);
                _con.Open();
                SqlDataReader reader = Command.ExecuteReader();

                while (reader.Read()) {
                    i = 1;
                }
            }
            _con.Close();
            return i >= 1;
        }
        #endregion
    }
}
