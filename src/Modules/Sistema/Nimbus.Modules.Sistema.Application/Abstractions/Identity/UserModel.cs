// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserModel.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the UserModel.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.Abstractions.Identity
{
    public sealed record UserModel(string Email, string Password, string FirstName, string LastName);
}