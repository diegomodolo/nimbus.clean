// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NimbusException.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the NimbusException.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.Exceptions;

using Nimbus.Common.Domain.Abstractions;

public sealed class NimbusException : Exception
{
    #region Constructors and Destructors

    public NimbusException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        this.RequestName = requestName;
        this.Error = error;
    }

    #endregion

    #region Public Properties

    public Error? Error { get; }

    public string RequestName { get; }

    #endregion
}