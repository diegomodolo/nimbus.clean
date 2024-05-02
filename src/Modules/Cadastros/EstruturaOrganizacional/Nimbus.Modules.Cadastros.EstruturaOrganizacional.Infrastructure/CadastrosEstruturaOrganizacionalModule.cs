// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CadastrosEstruturaOrganizacionalModule.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CadastrosEstruturaOrganizacionalModule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Domain.C001;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Infrastructure.C001;

public static class CadastrosEstruturaOrganizacionalModule
{
    #region Public Methods and Operators

    public static void AddCadastrosEstruturaOrganizacionalModule(this IServiceCollection services)
    {
        services.AddScoped<IC001Repository, C001Repository>();
    }

    #endregion
}