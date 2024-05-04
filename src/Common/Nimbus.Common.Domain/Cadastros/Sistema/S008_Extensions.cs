// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="S008_Extensions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the S008_Extensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.Sistema;

using Nimbus.Common.Domain.Abstractions;

public partial class S008_Usuario
{
    public static Result<S008_Usuario> Create(
        Guid id,
        string nome,
        string email,
        Guid? idProvedorAutenticacao = default,
        bool registroAtivo = true)

    {
        var c001 = new S008_Usuario
            {
                S008_Id = id,
                S008_Nome = nome,
                EMail = email,
                S008_IdProvedorAutenticacao = idProvedorAutenticacao,
                RegistroAtivo = registroAtivo
            };

        // Disparar evento de usuário criado

        return c001;
    }
}