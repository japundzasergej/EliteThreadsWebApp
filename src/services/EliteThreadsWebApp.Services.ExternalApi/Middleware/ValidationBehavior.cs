﻿using EliteThreadsWebApp.Services.ExternalApi.Middleware.Types;
using FluentValidation;
using MediatR;
using ValidationException = EliteThreadsWebApp.Services.ExternalApi.Middleware.Types.ValidationException;

namespace EliteThreadsWebApp.Services.Products.Api.Middleware
{
    public class ValidationBehavior<TRequest, TResponse>(
        IEnumerable<IValidator<TRequest>> validators
    ) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            var context = new ValidationContext<TRequest>(request);

            var validationFailures = await Task.WhenAll(
                validators.Select(validator => validator.ValidateAsync(context))
            );

            var errors = validationFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Select(
                    validationFailure =>
                        new ValidationError(
                            validationFailure.PropertyName,
                            validationFailure.ErrorMessage
                        )
                )
                .ToList();

            if (errors.Count != 0)
            {
                throw new ValidationException(errors);
            }

            var response = await next();

            return response;
        }
    }
}
