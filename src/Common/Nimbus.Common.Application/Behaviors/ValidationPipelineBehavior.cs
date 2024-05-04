// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidationPipelineBehavior.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ValidationPipelineBehavior.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.Behaviors;

using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Nimbus.Common.Domain.Abstractions;
using Nimbus.Common.Domain.Messaging;

public class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseCommand
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationFailures = await this.ValidateAsync(request);

        if (validationFailures.Length == 0)
        {
            return await next();
        }

        if (typeof(TResponse).IsGenericType && typeof(TResponse).GetGenericTypeDefinition() == typeof(Result<>))
        {
            var resultType = typeof(TResponse).GetGenericArguments()[0];

            var failureMethod = typeof(Result<>).MakeGenericType(resultType)
                                                .GetMethod(nameof(Result<object>.ValidationFailure));

            if (failureMethod is not null)
            {
                return (TResponse)failureMethod.Invoke(null, [CreateValidationError(validationFailures)])!;
            }
            else if (typeof(TResponse) == typeof(Result))
            {
                return (TResponse)(object)Result.Failure(CreateValidationError(validationFailures));
            }
        }

        throw new ValidationException(validationFailures);
    }

    #endregion

    private async Task<ValidationFailure[]> ValidateAsync(TRequest request)
    {
        if (!validators.Any())
        {
            return [];
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(context)));

        var validationFailures = validationResults.Where(c => !c.IsValid).SelectMany(c => c.Errors).ToArray();

        return validationFailures;
    }

    private static ValidationError CreateValidationError(ValidationFailure[] validationFailures) =>
        new(validationFailures.Select(c => Error.Problem(c.ErrorCode, c.ErrorMessage)).ToArray());
}