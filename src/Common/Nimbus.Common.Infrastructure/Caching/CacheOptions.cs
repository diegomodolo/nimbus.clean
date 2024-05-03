// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CacheOptions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CacheOptions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure.Caching;

using Microsoft.Extensions.Caching.Distributed;

public static class CacheOptions
{
    #region Public Properties

    public static DistributedCacheEntryOptions DefaultExpiration =>
        new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
            };

    #endregion

    #region Public Methods and Operators

    public static DistributedCacheEntryOptions Create(TimeSpan? expiration) =>
        expiration is not null
            ? new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expiration
                }
            : DefaultExpiration;

    #endregion
}