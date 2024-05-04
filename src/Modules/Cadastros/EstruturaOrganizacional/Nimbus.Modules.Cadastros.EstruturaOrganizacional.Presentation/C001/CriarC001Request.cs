// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarC001Request.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarC001Request.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Presentation.C001
{
    public sealed class CriarC001Request
    {
        #region Public Properties

        public string C001_Codigo { get; init; } = string.Empty;

        public string C001_Descricao { get; init; } = string.Empty;

        public bool RegistroAtivo { get; init; }

        #endregion
    }
}