// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Error.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Error.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Abstractions;

public record Error
{
    #region Fields

    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    public static readonly Error NullValue = new("General.Null", "Null value was provided", ErrorType.Failure);

    #endregion

    #region Constructors and Destructors

    public Error(string code, string description, ErrorType type)
    {
        this.Code = code;
        this.Description = description;
        this.Type = type;
    }

    #endregion

    #region Public Properties

    public string Code { get; }

    public string Description { get; }

    public ErrorType Type { get; }

    #endregion

    #region Public Methods and Operators

    public static Error Conflict(string code, string description) => new(code, description, ErrorType.Conflict);

    public static Error Failure(string code, string description) => new(code, description, ErrorType.Failure);

    public static Error NotFound(string code, string description) => new(code, description, ErrorType.NotFound);

    public static Error Problem(string code, string description) => new(code, description, ErrorType.Problem);

    #endregion
}