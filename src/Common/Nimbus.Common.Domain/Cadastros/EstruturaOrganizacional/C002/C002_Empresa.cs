// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C002_Empresa.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C002_Empresa.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C002;

using Nimbus.Common.Domain.Abstractions;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;

public class C002_Empresa : Entity
{
    #region Public Properties

    public required C001_Holding C001_Holding { get; set; }

    #endregion
}