using Microsoft.Data.Sqlite;
using primeiroprograma_emCu.Data;
using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Repositories
{
    internal class ClienteRepository
    {
        // CREATE — insere um novo cliente no banco
        public void Inserir(Cliente cliente)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            // @Nome é um parâmetro — protege contra SQL Injection
            cmd.CommandText = "INSERT INTO Clientes (Nome, Contato) VALUES (@nome, @contato)";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@contato", cliente.Contato);
            cmd.ExecuteNonQuery();
        }

        // READ — busca todos os clientes do banco
        public List<Cliente> BuscarTodos()
        {
            var lista = new List<Cliente>();

            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Nome, Contato FROM Clientes";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // Lê cada coluna pelo índice e monta o objeto
                lista.Add(new Cliente(
                    reader.GetInt32(0),   // Id
                    reader.GetString(1),  // Nome
                    reader.GetString(2)   // Contato
                ));
            }

            return lista;
        }

        // UPDATE — atualiza dados de um cliente existente
        public void Atualizar(Cliente cliente)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Clientes SET Nome = @nome, Contato = @contato WHERE Id = @id";
            cmd.Parameters.AddWithValue("@nome", cliente.Nome);
            cmd.Parameters.AddWithValue("@contato", cliente.Contato);
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.ExecuteNonQuery();
        }

        // DELETE — remove pelo Id
        public void Excluir(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Clientes WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}