// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IQuery.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IQuery.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Messaging
{
    using MediatR;
    using Nimbus.Domain.Abstractions;

    public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
}