// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="RequestLoggingPipelineBehavior.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the RequestLoggingPipelineBehavior.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.Behaviors;

using MediatR;
using Microsoft.Extensions.Logging;
using Nimbus.Common.Domain.Abstractions;
using Serilog.Context;

internal sealed class RequestLoggingPipelineBehavior<TRequest, TResponse>(
    ILogger<RequestLoggingPipelineBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class where TResponse : Result
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var moduleName = GetModuleName(typeof(TRequest).FullName!);
        string requestName = typeof(TRequest).Name;

        using (LogContext.PushProperty("Module", moduleName))
        {
            logger.LogInformation("Processing request {RequestName}", requestName);

            TResponse result = await next();

            if (result.IsSuccess)
            {
                logger.LogInformation("Complete request {RequestName}", requestName);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    logger.LogError("Complete request {RequestName} with error", requestName);
                }
            }

            return result;
        }
    }

    #endregion

    #region Methods

    private static string GetModuleName(string requestName)
    {
        var requestNameParts = requestName.Split(".");

        return requestNameParts[^1];
    }

    #endregion
}