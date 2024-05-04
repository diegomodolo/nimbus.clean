// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="JwtBearerConfigureOptions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the JwtBearerConfigureOptions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure.Authentication;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

internal sealed class JwtBearerConfigureOptions(IConfiguration configuration) : IConfigureNamedOptions<JwtBearerOptions>
{
    #region Fields

    private const string ConfigurationSectionName = "Authentication";

    #endregion

    #region Public Methods and Operators

    /// <inheritdoc />
    public void Configure(JwtBearerOptions options)
    {
        configuration.GetSection(ConfigurationSectionName).Bind(options);
    }

    /// <inheritdoc />
    public void Configure(string? name, JwtBearerOptions options)
    {
        this.Configure(options);
    }

    #endregion
}