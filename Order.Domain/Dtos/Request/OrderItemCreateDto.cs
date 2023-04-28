using FluentValidation;

namespace Order.Domain.Dtos.Request
{
    public record class OrderItemCreateDto : BaseDto
    {
        public Guid ItemId { get; init; }

        public int Item { get; init; }
        
        public string ProductDescription { get; init; }
        
        public Guid ProductId { get; init; }
        
        public decimal Amount { get; init; }

        public decimal TotalPrice => UnitPrice * Amount; 

        public decimal UnitPrice { get; init; }

        public decimal Discount { get; init; }

        public decimal TotalDiscount { get; init; }
    }

    public class OrderItemDtoValidation : AbstractValidator<OrderItemCreateDto>
    {
        public OrderItemDtoValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.UnitPrice).NotEmpty();
            RuleFor(x => x.Item).NotEmpty();
            RuleFor(x => x.ProductDescription).NotEmpty();
        }
    }
}
