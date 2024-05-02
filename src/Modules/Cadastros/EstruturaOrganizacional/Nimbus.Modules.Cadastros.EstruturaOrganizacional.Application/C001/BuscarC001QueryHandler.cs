// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="BuscarC001QueryHandler.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the BuscarC001QueryHandler.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using AutoMapper;
using Nimbus.Domain.Abstractions;
using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Domain.Messaging;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Domain.C001;

internal sealed class BuscarC001QueryHandler(IC001Repository repository, IMapper mapper)
    : IQueryHandler<BuscarC001Query, C001_HoldingDto>
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<Result<C001_HoldingDto>> Handle(BuscarC001Query request, CancellationToken cancellationToken)
    {
        var c001 = await repository.BuscarAsync(request.Codigo, cancellationToken);

        var dto = mapper.Map<C001_HoldingDto>(c001);

        return Result.Success(dto);
    }

    #endregion
}