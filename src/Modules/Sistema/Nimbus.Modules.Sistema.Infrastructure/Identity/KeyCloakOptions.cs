// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="KeyCloakOptions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the KeyCloakOptions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure.Identity;

internal sealed class KeyCloakOptions
{
    #region Public Properties

    public string AdminUrl { get; set; } = string.Empty;

    public string ConfidentialClientId { get; set; } = string.Empty;

    public string ConfidentialClientSecret { get; set; } = string.Empty;

    public string PublicClientId { get; set; } = string.Empty;

    public string TokenUrl { get; set; } = string.Empty;

    #endregion
}