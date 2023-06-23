using Npgsql;

namespace Order.Infraestructure.Data
{
    public static class Database
    {
        public static void CreateDatabase(this Config config) => NpgsqlDataSource.Create(config.ConnectionString);

    }
}
