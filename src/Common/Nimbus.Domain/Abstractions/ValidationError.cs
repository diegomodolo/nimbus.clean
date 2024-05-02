// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ValidationError.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ValidationError.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Abstractions;

public sealed record ValidationError : Error
{
    #region Constructors and Destructors

    public ValidationError(Error[] errors)
        : base("General.Validation", "One or more validation errors occurred", ErrorType.Validation)
    {
        this.Errors = errors;
    }

    #endregion

    #region Public Properties

    public Error[] Errors { get; }

    #endregion

    #region Public Methods and Operators

    public static ValidationError FromResults(IEnumerable<Result> results) =>
        new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());

    #endregion
}