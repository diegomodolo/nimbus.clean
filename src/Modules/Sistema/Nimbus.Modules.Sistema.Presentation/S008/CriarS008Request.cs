// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarS008Request.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarS008Request.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Presentation.S008
{
    public sealed class CriarS008Request
    {
        #region Public Properties

        public string EMail { get; set; } = string.Empty;

        public Guid Id { get; set; }

        public Guid? IdProvedor { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string PrimeiroNome { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        #endregion
    }
}