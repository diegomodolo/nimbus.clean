// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001CriadaIntegrationEventConsumer.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001CriadaIntegrationEventConsumer.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.IntegrationTest;

using MassTransit;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.IntegrationEvents;

public sealed class C001CriadaIntegrationEventConsumer : IConsumer<C001CriadaIntegrationEvent>
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task Consume(ConsumeContext<C001CriadaIntegrationEvent> context)
    {
        Console.WriteLine($"Evento {context.Message.GetType().Name} consumido com sucesso");

        await Task.CompletedTask;
    }

    #endregion
}