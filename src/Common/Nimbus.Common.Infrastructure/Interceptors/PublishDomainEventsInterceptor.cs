// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PublishDomainEventsInterceptor.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the PublishDomainEventsInterceptor.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure.Interceptors;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Nimbus.Common.Domain.Abstractions;

public sealed class PublishDomainEventsInterceptor(IServiceScopeFactory serviceScopeFactory)
    : SaveChangesInterceptor
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public override async ValueTask<int> SavedChangesAsync(
        SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not null)
        {
            await this.PublishDomainEventsAsync(eventData.Context);
        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    #endregion

    #region Methods

    private async Task PublishDomainEventsAsync(DbContext context)
    {
        var domainEvents = context.ChangeTracker.Entries<Entity>()
                                  .Select(c => c.Entity)
                                  .SelectMany(
                                      c =>
                                          {
                                              var domainsEVents = c.DomainEvents;

                                              c.ClearDomainEvents();

                                              return domainsEVents;
                                          })
                                  .ToList();

        using IServiceScope scope = serviceScopeFactory.CreateScope();

        var publisher = scope.ServiceProvider.GetRequiredService<IPublisher>();

        foreach (var domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent);
        }
    }

    #endregion
}