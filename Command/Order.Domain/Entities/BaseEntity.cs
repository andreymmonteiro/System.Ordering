namespace Order.Domain.Entities
{
    public abstract record class BaseEntity
    {
        public Guid Id { get; init; }

        public DateTime CreateAt { get; init; }

        public DateTime UpdateAt { get; init; }
    }
}
