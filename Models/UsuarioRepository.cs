using System;
using MySqlConnector;

namespace Atividade_02OFC.Models
{
    public class UsuarioRepository
    {
        private const string _conexaoOfc = "Database=destinocerto;Data Source=localhost;User Id=root;";

        public void Inserir(Usuario us)
        {
            MySqlConnection conexao_ = new MySqlConnection(_conexaoOfc);

            conexao_.Open();

            string _str = "INSERT INTO usuario(nome, login, senha, datanascimento) VALUES(@nome,@login, @senha, @datanascimento)";
            MySqlCommand comando = new MySqlCommand(_str, conexao_);
            comando.Parameters.AddWithValue("@nome", us.nome);
            comando.Parameters.AddWithValue("@login", us.login);
            comando.Parameters.AddWithValue("@senha", us.senha);
            comando.Parameters.AddWithValue("@datanascimento", us.datanascimento);
            comando.ExecuteNonQuery();
            conexao_.Close();
        }

        public Usuario QueryLogin(Usuario u)
        {
            MySqlConnection conexao_ = new MySqlConnection(_conexaoOfc);


            conexao_.Open();
            string sql = "SELECT * FROM Usuario WHERE login = @login AND senha = @senha";

            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao_);
            comandoQuery.Parameters.AddWithValue("@Login", u.login);
            comandoQuery.Parameters.AddWithValue("@Senha", u.senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if (reader.Read())
            {
                usr = new Usuario();
                usr.idUsuario = reader.GetInt32("idUsuario");
                if (!reader.IsDBNull(reader.GetOrdinal("nome")))
                    usr.nome = reader.GetString("nome");

                if (!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");
                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
            }

            conexao_.Close();
            return usr;
        }

    }
}
