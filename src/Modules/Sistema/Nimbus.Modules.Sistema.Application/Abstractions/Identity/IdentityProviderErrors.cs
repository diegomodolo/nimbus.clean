// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IdentityProviderErrors.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IdentityProviderErrors.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.Abstractions.Identity
{
    using Nimbus.Common.Domain.Abstractions;

    public static class IdentityProviderErrors
    {
        #region Fields

        public static readonly Error EmailIsNotUnique = Error.Conflict(
            "Identity.EmailIsNotUnique",
            "The specified email is not unique");

        #endregion
    }
}