namespace Order.Domain.Entities
{
    public sealed record class OrderEntity(Guid PersonEntityId, decimal AmountTotal, decimal TotalOrderValue, decimal TotalDiscount, IEnumerable<OrderItemEntity> OrderItemEntity) : BaseEntity;
}
