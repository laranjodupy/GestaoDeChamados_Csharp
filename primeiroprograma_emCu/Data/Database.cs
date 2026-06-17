using Microsoft.Data.Sqlite;

namespace primeiroprograma_emCu.Data
{
    public static class Database // é uma classe utilitária, ou seja, não é um objeto do sistema e nem representa um banco de dados, mas reúne as funcionalidades relacionadas ao banco
    {
        private static string connectionString =
            "Data Source=chamados.db";

        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(connectionString);
        }

        public static void Initialize()
        {
            using var connection = GetConnection();
            connection.Open();

            var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL,
                    Email TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Atendentes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Chamados (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Descricao TEXT NOT NULL,
                    Status TEXT NOT NULL,
                    ClienteId INTEGER,
                    AtendenteId INTEGER,
                    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
                    FOREIGN KEY (AtendenteId) REFERENCES Atendentes(Id)
                );
            ";

            command.ExecuteNonQuery();
        }
    }
}