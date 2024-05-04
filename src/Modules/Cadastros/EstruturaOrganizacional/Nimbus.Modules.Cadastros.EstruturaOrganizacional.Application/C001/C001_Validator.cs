// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001_Validator.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001_Validator.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using FluentValidation;

internal sealed class C001_Validator : AbstractValidator<CriarC001Command>
{
    #region Constructors and Destructors

    public C001_Validator()
    {
        this.RuleFor(c => c.C001_Codigo).NotEmpty();
        this.RuleFor(c => c.C001_Descricao).NotEmpty();
    }

    #endregion
}