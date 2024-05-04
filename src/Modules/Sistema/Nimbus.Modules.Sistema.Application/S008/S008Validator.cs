// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="S008Validator.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the S008Validator.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.S008
{
    using FluentValidation;
    using Nimbus.Common.Domain.Cadastros.Sistema;

    internal sealed class S008Validator : AbstractValidator<S008_Usuario>
    {
        #region Constructors and Destructors

        public S008Validator()
        {
            this.RuleFor(c => c.S008_Nome).NotEmpty();
            this.RuleFor(c => c.EMail).NotEmpty();
        }

        #endregion
    }
}