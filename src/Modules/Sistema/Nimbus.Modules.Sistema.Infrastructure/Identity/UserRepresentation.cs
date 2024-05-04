// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserRepresentation.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the UserRepresentation.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure.Identity
{
    internal sealed record UserRepresentation(
        string Username,
        string Email,
        string FirstName,
        string LastName,
        bool EmailVerified,
        bool Enabled,
        CredentialRepresentation[] Credentials);
}