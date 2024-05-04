// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="S008Controller.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the S008Controller.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Presentation.S008;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nimbus.Common.Domain.Extensions;
using Nimbus.Modules.Sistema.Application.S008;

[Route("api/v2/s008")]
[Tags(Tags.Sistema)]
public sealed class S008Controller(ISender sender) : ControllerBase
{
    #region Public Methods and Operators

    [HttpPost]
    [Tags(Tags.Sistema)]
    public async Task<IResult> Post([FromBody] CriarS008Request request)
    {
        var command = new CriarS008Command(request.Nome, request.EMail, request.Senha, request.PrimeiroNome, request.Sobrenome);

        var result = await sender.Send(command);

        return result.Match(Results.Ok, ApiResults.Problem);
    }

    #endregion
}