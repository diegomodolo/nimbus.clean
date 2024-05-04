// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IdentityProviderService.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IdentityProviderService.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure.Identity;

using System.Net;
using Microsoft.Extensions.Logging;
using Nimbus.Common.Domain.Abstractions;
using Nimbus.Modules.Sistema.Application.Abstractions.Identity;

internal sealed class IdentityProviderService(KeyCloakClient keyCloakClient, ILogger<IdentityProviderService> logger)
    : IIdentityProviderService
{
    #region Fields

    private const string PasswordCredentialType = "Password";

    #endregion

    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<Result<string>> RegisterUserAsync(UserModel user, CancellationToken cancellationToken = default)
    {
        var userRepresentation = new UserRepresentation(
            user.Email,
            user.Email,
            user.FirstName,
            user.LastName,
            true,
            true,
                [new CredentialRepresentation(PasswordCredentialType, user.Password, false)]);

        try
        {
            var identityId = await keyCloakClient.RegisterUserAsync(userRepresentation, cancellationToken);

            return identityId;
        }
        catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Conflict)
        {
            logger.LogError(exception, "User registration failed");

            return Result.Failure<string>(IdentityProviderErrors.EmailIsNotUnique);
        }
    }

    #endregion
}