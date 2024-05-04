// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CredentialRepresentation.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CredentialRepresentation.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure.Identity
{
    internal sealed record CredentialRepresentation(string Type, string Value, bool Temporary);
}