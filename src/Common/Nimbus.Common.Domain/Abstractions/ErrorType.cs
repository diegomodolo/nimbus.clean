// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ErrorType.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ErrorType.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Abstractions;

public enum ErrorType
{
    Failure = 0,

    Validation = 1,

    Problem = 2,

    NotFound = 3,

    Conflict = 4
}