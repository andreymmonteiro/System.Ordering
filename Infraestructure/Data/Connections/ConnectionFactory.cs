using Microsoft.Data.SqlClient;
using Order.Domain.Data;
using Order.Domain.Data.Connections;
using System.Data;

namespace Order.Infraestructure.Data.Connections
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfig _config;

        public ConnectionFactory(IConfig config)
            => _config = config;

        private const int _commandTimeOut = 60;

        public IDbConnection BuildConnection() => new SqlConnection(_config.ConnectionString);

        public int CommandTimeOut() => _commandTimeOut;
    }
}
