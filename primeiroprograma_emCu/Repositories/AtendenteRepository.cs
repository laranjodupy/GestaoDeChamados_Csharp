using Microsoft.Data.Sqlite;
using primeiroprograma_emCu.Data;
using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Repositories
{
    internal class AtendenteRepository
    {
        public void Inserir(Atendente atendente)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Atendentes (Nome, Setor) VALUES (@nome, @setor)";
            cmd.Parameters.AddWithValue("@nome", atendente.Nome);
            cmd.Parameters.AddWithValue("@setor", atendente.Setor);
            cmd.ExecuteNonQuery();
        }

        public List<Atendente> BuscarTodos()
        {
            var lista = new List<Atendente>();

            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome, Setor FROM Atendentes";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Atendente(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ));
            }

            return lista;
        }

        public void Atualizar(Atendente atendente)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Atendentes SET Nome = @nome, Setor = @setor WHERE Id = @id";
            cmd.Parameters.AddWithValue("@nome", atendente.Nome);
            cmd.Parameters.AddWithValue("@setor", atendente.Setor);
            cmd.Parameters.AddWithValue("@id", atendente.Id);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Atendentes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}