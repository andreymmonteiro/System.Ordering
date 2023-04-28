using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace Order.Domain.Validators
{
    /// <summary>
    /// CQRS validator
    /// </summary>
    /// <typeparam name="TRequest">Request command or query</typeparam>
    /// <typeparam name="TResult">Result command or query</typeparam>
    public class ValidatorBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, Result<TResult>>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidatorBehavior(IValidator<TRequest> validator)
            => _validator = validator;

        public async Task<Result<TResult>> Handle(TRequest request,
            RequestHandlerDelegate<Result<TResult>> next, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                //Implement the generic behavior here
                return default;
            }

            return await next().ConfigureAwait(false);
        }
    }
}
