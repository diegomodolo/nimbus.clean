// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ICommand.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ICommand.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Messaging;

using MediatR;
using Nimbus.Common.Domain.Abstractions;

public interface ICommand : IRequest<Result>,
                            IBaseCommand;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>,
                                       IBaseCommand;

public interface IBaseCommand;