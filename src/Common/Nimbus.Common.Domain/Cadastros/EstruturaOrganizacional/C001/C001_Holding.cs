// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001_Holding.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001_Holding.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nimbus.Common.Domain.Abstractions;

[Table(nameof(C001_Holding), Schema = "Cadastros")]
public sealed partial class C001_Holding : Entity
{
    #region Constructors and Destructors

    private C001_Holding()
    {
    }

    #endregion

    #region Public Properties

    [Key]
    [MaxLength(16)]
    public string C001_Codigo { get; set; } = string.Empty;

    [MaxLength(60)]
    public string C001_Descricao { get; set; } = string.Empty;

    #endregion
}