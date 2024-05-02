// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BuscarC001Query.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the BuscarC001Query.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Presentation.C001;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Domain.Abstractions;
using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Domain.Extensions;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

[Route("api/v2/c001")]
public sealed class BuscarC001(ISender sender) : ControllerBase
{
    #region Public Methods and Operators

    [HttpGet("{codigo}")]
    [Tags(Tags.Cadastros)]
    public async Task<IResult> Get(string codigo)
    {
        var query = new BuscarC001Query(codigo);

        var result = await sender.Send(query);

        return result.Match(Results.Ok, ApiResults.Problem);
    }

    #endregion
}