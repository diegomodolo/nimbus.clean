// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="S008_Usuario.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the S008_Usuario.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.Sistema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nimbus.Common.Domain.Abstractions;

[Table(nameof(S008_Usuario), Schema = "Seguranca")]
public sealed partial class S008_Usuario : Entity
{
    #region Constructors and Destructors

    private S008_Usuario()
    {
    }

    #endregion

    #region Public Properties

    [Key]
    public required Guid S008_Id { get; set; } = Guid.NewGuid();

    public Guid? S008_IdProvedorAutenticacao { get; set; }

    [MaxLength(60)]
    public required string S008_Nome { get; set; }

    [MaxLength(250)]
    public string EMail { get; set; } = default!;

    #endregion
}