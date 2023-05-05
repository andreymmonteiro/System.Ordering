namespace Order.Domain.Entities
{
    public sealed record class OrderItemEntity(Guid ItemId, Guid OrderItem, int Item, string ProductDescription, Guid ProductId, decimal Amount, decimal TotalPrice, decimal UnitPrice, decimal Discount, decimal TotalDiscount) : BaseEntity;
}
