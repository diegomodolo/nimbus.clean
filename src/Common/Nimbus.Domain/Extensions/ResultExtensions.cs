// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ResultExtensions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ResultExtensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Extensions;

using Nimbus.Domain.Abstractions;

public static class ResultExtensions
{
    #region Public Methods and Operators

    public static TOut Match<TOut>(this Result result, Func<TOut> onSuccess, Func<Result, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result);
    }

    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Result<TIn>, TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result);
    }

    #endregion
}