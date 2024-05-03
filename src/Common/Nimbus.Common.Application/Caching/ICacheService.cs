// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICacheService.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ICacheService.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.Caching;

public interface ICacheService
{
    #region Public Methods and Operators

    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    Task RemoveAsync(string key, CancellationToken cancellationToken = default);

    Task SetAsync<T>(string key, T value, TimeSpan? expiration = null, CancellationToken cancellationToken = default);

    #endregion
}