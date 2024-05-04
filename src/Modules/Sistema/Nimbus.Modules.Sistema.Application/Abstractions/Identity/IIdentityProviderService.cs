// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IIdentityProviderService.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IIdentityProviderService.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.Abstractions.Identity;

using Nimbus.Common.Domain.Abstractions;

public interface IIdentityProviderService
{
    #region Public Methods and Operators

    Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default);

    #endregion
}