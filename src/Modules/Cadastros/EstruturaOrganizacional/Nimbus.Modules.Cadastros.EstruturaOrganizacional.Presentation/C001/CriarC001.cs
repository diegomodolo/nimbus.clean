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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

[Route("api/v2/c001")]
public sealed class CriarC001(ISender sender) : ControllerBase
{
    #region Public Methods and Operators

    [HttpPost]
    [Tags(Tags.Cadastros)]
    public async Task<IResult> Post([FromBody] Request request)
    {
        var command = new CriarC001Command(request.C001_Codigo, request.C001_Descricao, request.RegistroAtivo);

        var codigo = await sender.Send(command);

        return Results.Ok(codigo);
    }

    #endregion
}

public sealed class Request
{
    #region Public Properties

    public string C001_Codigo { get; init; } = string.Empty;

    public string C001_Descricao { get; init; } = string.Empty;

    public bool RegistroAtivo { get; init; }

    #endregion
}