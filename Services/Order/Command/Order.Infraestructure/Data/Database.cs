using Npgsql;

namespace Order.Infraestructure.Data
{
    public static class Database
    {

        private const string DatabaseName = "\"Order\"";


        public static async Task CreateDatabase(this Config config)
        {
            using var conn = new NpgsqlConnection(config.ConnectionString);
            conn.Open();

            bool existsDb = default;

            using (var databaseExist = new NpgsqlCommand(@$"SELECT COUNT(0) FROM pg_catalog.pg_database WHERE DATNAME = '{DatabaseName}'")) 
            {
                databaseExist.Connection = conn;
                using (var reader = await databaseExist.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        existsDb = reader.GetInt64(default) > default(int);
                    }
                } 

            }

            if (!existsDb)
            {
                using var createDb = new NpgsqlCommand(@$"
                CREATE DATABASE {DatabaseName}
                    WITH
                    OWNER = postgres
                    ENCODING = 'UTF8'
                    LC_COLLATE = 'Portuguese_Brazil.1252'
                    LC_CTYPE = 'Portuguese_Brazil.1252'
                    TABLESPACE = pg_default
                    CONNECTION LIMIT = -1;
                ");

                createDb.Connection = conn;
                await createDb.ExecuteNonQueryAsync();
            }

            conn.Close();
        }

    }
}
