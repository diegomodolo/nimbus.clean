// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="CriarS008CommandHandler.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the CriarS008CommandHandler.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Application.S008
{
    using Nimbus.Common.Domain.Abstractions;
    using Nimbus.Common.Domain.Cadastros.Sistema;
    using Nimbus.Common.Domain.Messaging;
    using Nimbus.Modules.Sistema.Application.Abstractions.Identity;
    using Nimbus.Modules.Sistema.Domain.S008;

    public class CriarS008CommandHandler(
        IIdentityProviderService identityProviderService,
        IS008Repository repository,
        IUnitOfWork unitOfWork) : ICommandHandler<CriarS008Command, Guid>
    {
        #region Public Methods and Operators

        /// <inheritdoc />
        public async Task<Result<Guid>> Handle(CriarS008Command request, CancellationToken cancellationToken)
        {
            var result = await identityProviderService.RegisterUserAsync(
                new UserModel(request.EMail, request.Senha, request.PrimeiroNome, request.Sobrenome),
                cancellationToken);

            if (result.IsFailure)
            {
                return Result.Failure<Guid>(result.Error);
            }

            var usuario = S008_Usuario.Create(
                Guid.NewGuid(),
                request.NomeUsuario,
                request.EMail,
                idProvedorAutenticacao: Guid.Parse(result.Value),
                registroAtivo: true);

            repository.Inserir(usuario.Value);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return usuario.Value.S008_Id;
        }

        #endregion
    }
}