// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ExceptionHandlingPipelineBehavior.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ExceptionHandlingPipelineBehavior.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.Behaviors;

using MediatR;
using Microsoft.Extensions.Logging;
using Nimbus.Common.Application.Exceptions;

internal sealed class ExceptionHandlingPipelineBehavior<TRequest, TResponse>(
    ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Unhandled exception for {RequestName}", typeof(TRequest).Name);

            throw new NimbusException(typeof(TRequest).Name, innerException: exception);
        }
    }

    #endregion
}