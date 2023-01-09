using System;
using MySqlConnector;
using System.Collections.Generic;
namespace Atividade_02OFC.Models
{
    public class PacotesRepository
    {
        private const string conexaoprincipal_ = "Database=destinocerto; Data Source=localhost; User id=root";

        public void Inserir(Pacotes pc)
        {
            MySqlConnection strconexa_ = new MySqlConnection(conexaoprincipal_);

            strconexa_.Open();

            string strinserir_ = "INSERT INTO pacotesturisticos(nome, origem, destino, atrativos, idUsuarios) VALUES (@nome, @origem, @destino, @atrativos, @idUsuarios)";
            MySqlCommand comando = new MySqlCommand(strinserir_, strconexa_);
            comando.Parameters.AddWithValue("@nome", pc.nome);
            comando.Parameters.AddWithValue("@origem", pc.origem);
            comando.Parameters.AddWithValue("@destino", pc.destino);
            comando.Parameters.AddWithValue("@atrativos", pc.atrativos);
               comando.Parameters.AddWithValue("@idUsuarios", pc.idUsuarios);
            comando.ExecuteNonQuery();
            strconexa_.Close();
        }

        public List<Pacotes> Ler()
        {
            MySqlConnection strconexa_ = new MySqlConnection(conexaoprincipal_);

            strconexa_.Open();

            string strler_ = "Select * From pacotesturisticos";
            MySqlCommand comando = new MySqlCommand(strler_, strconexa_);
            MySqlDataReader Reader = comando.ExecuteReader();

            List<Pacotes> ListaPacotes = new List<Pacotes>();

            while (Reader.Read())
            {
                Pacotes p = new Pacotes();

                p.idPacotes = Reader.GetInt32("idPacote");

                if (!Reader.IsDBNull(Reader.GetOrdinal("nome")))
                {
                    p.nome = Reader.GetString("nome");
                }

                if (!Reader.IsDBNull(Reader.GetOrdinal("origem")))
                {
                    p.origem = Reader.GetString("origem");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("destino")))
                {
                    p.destino = Reader.GetString("destino");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("atrativos")))
                {
                    p.atrativos = Reader.GetString("atrativos");
                }
                  if (!Reader.IsDBNull(Reader.GetOrdinal("idUsuarios")))
                {
                    p.idUsuarios = Reader.GetInt32("idUsuarios");
                }
                ListaPacotes.Add(p);
            }

            strconexa_.Close();
            return ListaPacotes;
        }

        public Pacotes BuscarId(int id)
        {
            MySqlConnection strconexa_ = new MySqlConnection(conexaoprincipal_);

            strconexa_.Open();

            string strler_ = "Select * From pacotesturisticos WHERE idPacote = @idPacote";
            MySqlCommand comando = new MySqlCommand(strler_, strconexa_);

            comando.Parameters.AddWithValue("idPacote", id);

            MySqlDataReader Reader = comando.ExecuteReader();
            Pacotes p = new Pacotes();

            while (Reader.Read())
            {
                p.idPacotes = Reader.GetInt32("idPacote");

                if (!Reader.IsDBNull(Reader.GetOrdinal("nome")))
                {
                    p.nome = Reader.GetString("nome");
                }

                if (!Reader.IsDBNull(Reader.GetOrdinal("origem")))
                {
                    p.origem = Reader.GetString("origem");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("destino")))
                {
                    p.destino = Reader.GetString("destino");
                }
                if (!Reader.IsDBNull(Reader.GetOrdinal("atrativos")))
                {
                    p.atrativos = Reader.GetString("atrativos");
                }
            }

            strconexa_.Close();
            return p;
        }

        public void Deletar(int id)
        {
            MySqlConnection strconexa_ = new MySqlConnection(conexaoprincipal_);

            strconexa_.Open();

            string strinserir_ = "DELETE FROM pacotesturisticos WHERE idPacote = @idPacote";
            MySqlCommand comando = new MySqlCommand(strinserir_, strconexa_);
            comando.Parameters.AddWithValue("@idPacote", id);
            
            comando.ExecuteNonQuery();
            strconexa_.Close();
        }

     public void Editar(Pacotes pc){
            MySqlConnection strconexa_ = new MySqlConnection(conexaoprincipal_);

            strconexa_.Open();

            string strinserir_ = "UPDATE  pacotesturisticos SET nome = @nome, origem = @origem, destino = @destino, atrativos = @atrativos";
            MySqlCommand comando = new MySqlCommand(strinserir_, strconexa_);
            comando.Parameters.AddWithValue("@nome", pc.nome);
            comando.Parameters.AddWithValue("@origem", pc.origem);
            comando.Parameters.AddWithValue("@destino", pc.destino);
            comando.Parameters.AddWithValue("@atrativos", pc.atrativos);
             comando.Parameters.AddWithValue("@idPacote", pc.idPacotes);
            comando.ExecuteNonQuery();
            strconexa_.Close();
     }

    }

}
