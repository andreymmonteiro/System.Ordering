using FluentValidation;

namespace Order.Domain.Dtos.Request
{
    public record class OrderCreateDto : BaseDto
    {
        public Guid PersonEntityId { get; init; }

        public decimal AmountTotal => OrderItemDto.Sum(s => s.Amount);

        public decimal TotalOrderValue => OrderItemDto.Sum(s => s.TotalPrice);

        public decimal TotalDiscount => OrderItemDto.Sum(s => s.TotalDiscount);

        public IEnumerable<OrderItemCreateDto> OrderItemDto { get; init; }
    }

    public class OrderDtoValidation : AbstractValidator<OrderCreateDto>
    {
        public OrderDtoValidation()
        {
            RuleFor(x => x.OrderItemDto).NotEmpty();
            RuleFor(x => x.PersonEntityId).NotEmpty();
        }
    }
}
