using System.Data;

namespace Order.Domain.Data.Connections
{
    public interface IConnectionFactory
    {
        IDbConnection BuildConnection();

        int CommandTimeOut();
    }
}
