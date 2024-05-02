// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="GetC001Query.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the GetC001Query.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Domain.Messaging;

public sealed record BuscarC001Query(string Codigo) : IQuery<C001_HoldingDto>;