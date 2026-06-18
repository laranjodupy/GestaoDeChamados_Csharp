using Microsoft.Data.Sqlite;

namespace primeiroprograma_emCu.Data
{
    public static class Database
    {
        private static string connectionString = "Data Source=chamados.db";

        public static SqliteConnection GetConnection()
            => new SqliteConnection(connectionString);

        public static void Initialize()
        {
            using var connection = GetConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Clientes (
                    Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome    TEXT NOT NULL,
                    Contato TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Atendentes (
                    Id    INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome  TEXT NOT NULL,
                    Setor TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Chamados (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Descricao   TEXT NOT NULL,
                    Status      TEXT NOT NULL,
                    ClienteId   INTEGER,
                    AtendenteId INTEGER,
                    FOREIGN KEY (ClienteId)   REFERENCES Clientes(Id),
                    FOREIGN KEY (AtendenteId) REFERENCES Atendentes(Id)
                );
                CREATE TABLE IF NOT EXISTS Papeis (
                    Id   INTEGER PRIMARY KEY,
                    Nome TEXT NOT NULL
                );
                CREATE TABLE IF NOT EXISTS Usuarios (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nome      TEXT NOT NULL,
                    Login     TEXT NOT NULL UNIQUE,
                    SenhaHash TEXT NOT NULL,
                    PapelId   INTEGER NOT NULL,
                    FOREIGN KEY (PapelId) REFERENCES Papeis(Id)
                );
            ";
            command.ExecuteNonQuery();

            SeedPapeis(connection);
            SeedAdminInicial(connection);
        }

        private static void SeedPapeis(SqliteConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT OR IGNORE INTO Papeis (Id, Nome) VALUES (1, 'Admin');
                INSERT OR IGNORE INTO Papeis (Id, Nome) VALUES (2, 'Operador');
                INSERT OR IGNORE INTO Papeis (Id, Nome) VALUES (3, 'Visualizador');
            ";
            cmd.ExecuteNonQuery();
        }

        private static void SeedAdminInicial(SqliteConnection connection)
        {
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE PapelId = 1";
            long count = (long)(check.ExecuteScalar() ?? 0L);

            if (count == 0)
            {
                string hash = BCrypt.Net.BCrypt.HashPassword("admin123");
                var insert = connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO Usuarios (Nome, Login, SenhaHash, PapelId)
                    VALUES ('Administrador', 'admin', @hash, 1)
                ";
                insert.Parameters.AddWithValue("@hash", hash);
                insert.ExecuteNonQuery();
            }
        }
    }
}