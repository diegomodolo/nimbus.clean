// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CadastrosMappingProfile.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CadastrosMappingProfile.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Cadastros;

using AutoMapper;
using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;

internal sealed class CadastrosMappingProfile : Profile
{
    #region Constructors and Destructors

    public CadastrosMappingProfile()
    {
        this.CreateMap<C001_Holding, C001_HoldingDto>();
    }

    #endregion
}