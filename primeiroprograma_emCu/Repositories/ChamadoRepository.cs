using Microsoft.Data.Sqlite;
using primeiroprograma_emCu.Data;
using primeiroprograma_emCu.Models;

namespace primeiroprograma_emCu.Repositories
{
    internal class ChamadoRepository
    {
        public void Inserir(Chamado chamado)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Chamados (Descricao, Status, ClienteId, AtendenteId)
                VALUES (@descricao, @status, @clienteId, @atendenteId)
            ";
            cmd.Parameters.AddWithValue("@descricao", chamado.Descricao);
            cmd.Parameters.AddWithValue("@status", chamado.Status);
            cmd.Parameters.AddWithValue("@clienteId", chamado.Cliente.Id);
            cmd.Parameters.AddWithValue("@atendenteId", chamado.Atendente.Id);
            cmd.ExecuteNonQuery();
        }

        public List<Chamado> BuscarTodos()
        {
            var lista = new List<Chamado>();

            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            // JOIN para trazer os dados do cliente e atendente junto
            cmd.CommandText = @"
                SELECT ch.Id, ch.Descricao, ch.Status,
                       cl.Id, cl.Nome, cl.Contato,
                       at.Id, at.Nome, at.Setor
                FROM Chamados ch
                INNER JOIN Clientes cl ON ch.ClienteId = cl.Id
                INNER JOIN Atendentes at ON ch.AtendenteId = at.Id
            ";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Cliente(reader.GetInt32(3), reader.GetString(4), reader.GetString(5));
                var atendente = new Atendente(reader.GetInt32(6), reader.GetString(7), reader.GetString(8));

                // Chamado tem Status privado — precisamos de um construtor que aceite Status
                // Veja a nota abaixo sobre ajustar o model
                var chamado = new Chamado(reader.GetInt32(0), reader.GetString(1), cliente, atendente);
                chamado.AlterarStatus(reader.GetString(2));
                lista.Add(chamado);
            }

            return lista;
        }

        public void AtualizarStatus(int id, string novoStatus)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Chamados SET Status = @status WHERE Id = @id";
            cmd.Parameters.AddWithValue("@status", novoStatus);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public void Excluir(int id)
        {
            using var connection = Database.GetConnection();
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Chamados WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}