using System.Data;

namespace Order.Domain.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        Task ExecuteAsync(Func<Task> func);

    }
}
