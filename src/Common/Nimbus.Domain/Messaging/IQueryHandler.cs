// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IQueryHandler.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IQueryHandler.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Messaging
{
    using MediatR;
    using Nimbus.Domain.Abstractions;

    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>;
}