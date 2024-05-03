// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001_HoldingDto.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001_HoldingDto.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001
{
    public sealed class C001_HoldingDto
    {
        #region Public Properties

        public string C001_Codigo { get; set; } = string.Empty;

        public string C001_Descricao { get; set; } = string.Empty;

        public bool RegistroAtivo { get; set; }

        #endregion
    }
}