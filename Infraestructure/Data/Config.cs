using Order.Domain.Data;

namespace Order.Infraestructure.Data
{
    public record class Config : IConfig
    {
        public string ConnectionString { get; init; }
    }
}
