// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001_Extensions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001_Extensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;

using Nimbus.Domain.Abstractions;

public partial class C001_Holding
{
    #region Public Methods and Operators

    public static Result<C001_Holding> Create(string C001_Codigo, string C001_Descricao, bool RegistroAtivo)
    {
        var c001 = new C001_Holding
            {
                C001_Codigo = C001_Codigo,
                C001_Descricao = C001_Descricao,
                RegistroAtivo = RegistroAtivo
            };

        return c001;
    }

    #endregion
}