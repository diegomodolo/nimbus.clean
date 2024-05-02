// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Result.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Result.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Abstractions;

using System.Diagnostics.CodeAnalysis;

public class Result
{
    #region Constructors and Destructors

    public Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        this.IsSuccess = isSuccess;
        this.Error = error;
    }

    #endregion

    #region Public Properties

    public Error Error { get; }

    public bool IsFailure => !this.IsSuccess;

    public bool IsSuccess { get; }

    #endregion

    #region Public Methods and Operators

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    #endregion
}

public class Result<TValue> : Result
{
    #region Fields

    private readonly TValue? _value;

    #endregion

    #region Constructors and Destructors

    public Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        this._value = value;
    }

    #endregion

    #region Public Properties

    [NotNull]
    public TValue Value =>
        this.IsSuccess
            ? this._value!
            : throw new InvalidOperationException("The value of a failure result can't be accessed.");

    #endregion

    #region Public Methods and Operators

    public static implicit operator Result<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    public static Result<TValue> ValidationFailure(Error error) => new(default, false, error);

    #endregion
}