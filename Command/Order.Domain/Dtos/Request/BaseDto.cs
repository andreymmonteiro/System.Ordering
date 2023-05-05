namespace Order.Domain.Dtos.Request
{
    public abstract record class BaseDto
    {
        public Guid Id { get; init; }

        public DateTime CreateAt { get; init; }

        public DateTime UpdateAt { get; init; }
    }
}
