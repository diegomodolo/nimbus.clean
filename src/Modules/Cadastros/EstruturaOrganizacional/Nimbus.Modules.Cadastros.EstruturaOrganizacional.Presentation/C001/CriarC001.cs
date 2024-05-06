// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarC001.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarC001.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Presentation.C001;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Common.Domain.Extensions;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

[Route("api/v2/c001")]
[Tags(Tags.Cadastros)]
public sealed class CriarC001(ISender sender) : ControllerBase
{
    #region Public Methods and Operators

    [HttpPost]
    [Tags(Tags.Cadastros)]
    public async Task<IResult> Post([FromBody] CriarC001Request request)
    {
        var command = new CriarC001Command(request.C001_Codigo, request.C001_Descricao, request.RegistroAtivo);

        var codigo = await sender.Send(command);

        return codigo.Match(Results.Ok, ApiResults.Problem);
    }

    #endregion
}