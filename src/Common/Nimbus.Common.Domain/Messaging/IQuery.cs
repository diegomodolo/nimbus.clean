// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IQuery.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IQuery.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Messaging
{
    using MediatR;
    using Nimbus.Common.Domain.Abstractions;

    public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
}