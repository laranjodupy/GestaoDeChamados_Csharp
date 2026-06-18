using Microsoft.Data.Sqlite;
using primeiroprograma_emCu.Data;
using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Repositories
{
    internal class UsuarioRepository
    {
        // Busca por login para o processo de autenticação
        public Usuario? BuscarPorLogin(string login)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome, Login, SenhaHash, PapelId FROM Usuarios WHERE Login = @login";
            cmd.Parameters.AddWithValue("@login", login);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Login = reader.GetString(2),
                    SenhaHash = reader.GetString(3),
                    // Converte o número do banco para o enum Papel
                    Papel = (Papel)reader.GetInt32(4)
                };
            }

            return null; // Login não encontrado
        }

        public List<Usuario> BuscarTodos()
        {
            var lista = new List<Usuario>();

            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome, Login, SenhaHash, PapelId FROM Usuarios";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Login = reader.GetString(2),
                    SenhaHash = reader.GetString(3),
                    Papel = (Papel)reader.GetInt32(4)
                });
            }

            return lista;
        }

        public void Inserir(Usuario usuario)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Usuarios (Nome, Login, SenhaHash, PapelId)
                VALUES (@nome, @login, @hash, @papelId)
            ";
            cmd.Parameters.AddWithValue("@nome", usuario.Name);
            cmd.Parameters.AddWithValue("@login", usuario.Login);
            cmd.Parameters.AddWithValue("@hash", usuario.SenhaHash);
            cmd.Parameters.AddWithValue("@papelId", (int)usuario.Papel);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Usuarios WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}