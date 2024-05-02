// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarC001Command.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarC001Command.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using Nimbus.Domain.Messaging;

public sealed record CriarC001Command(string C001_Codigo, string C001_Descricao, bool RegistroAtivo) : ICommand<string>;