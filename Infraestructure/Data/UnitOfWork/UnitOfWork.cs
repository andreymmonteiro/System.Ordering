using Order.Domain.Data.Connections;
using Order.Domain.Data.UnitOfWork;
using System.Data;

namespace Order.Infraestructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IConnectionFactory _connectionFactory;
        private bool _disposed;

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            OpenConnection();
            _disposed = false;
        } 

        public IDbConnection Connection { get; private set; }

        public IDbTransaction Transaction { get; private set; }

        public async Task ExecuteAsync(Func<Task> func)
        {
            try
            {

                Begin();
                await func();
                Commit();

            }catch
            {
                Rollback();
            }
        }

        private void Begin()
        {
            if(!(ConnectionState.Open == Connection.State))
            {
                OpenConnection();
            }

            Transaction = Connection.BeginTransaction();
        }

        private void Commit()
        {
            Transaction.Commit();
            Connection.Close();
        }

        private void Rollback()
        {
            Transaction.Rollback();
            Connection.Close();
        }

        private void OpenConnection()
        {
            Connection = _connectionFactory.BuildConnection();
            Connection.Open();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _disposed = true;
                Transaction.Dispose();
                Connection.Close();
            }
        }
    }
}
