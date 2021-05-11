using Confitec.Domain.Results;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Domain.Behavior
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : BaseResult
    {
        private readonly IEnumerable<IValidator> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return failures.Any()
                ? Errors(failures)
                : next();
        }

        private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        {
            var response = new BaseResult();

            foreach (var failure in failures)
            {
                response.Msg = failure.ErrorMessage;
            }

            return Task.FromResult(response as TResponse);
        }
    }
}
