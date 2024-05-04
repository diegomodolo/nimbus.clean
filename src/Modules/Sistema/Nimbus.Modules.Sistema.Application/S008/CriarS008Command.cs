// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarS008Command.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarS008Command.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.S008;

using Nimbus.Common.Domain.Messaging;

public sealed record CriarS008Command(
    string NomeUsuario,
    string EMail,
    string Senha,
    string PrimeiroNome,
    string Sobrenome) : ICommand<Guid>;