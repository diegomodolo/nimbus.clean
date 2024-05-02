// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarC001CommandHandler.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarC001CommandHandler.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using System.Net.Http.Headers;
using AutoMapper;
using Nimbus.Domain.Abstractions;
using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Domain.Messaging;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Domain.C001;

internal sealed class CriarC001CommandHandler(IC001Repository repository, IUnitOfWork unitOfWork)
    : ICommandHandler<CriarC001Command, string>
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<Result<string>> Handle(CriarC001Command request, CancellationToken cancellationToken)
    {
        var result = C001_Holding.Create(request.C001_Codigo, request.C001_Descricao, request.RegistroAtivo);

        repository.Insert(result.Value);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return result.Value.C001_Codigo;
    }

    #endregion
}