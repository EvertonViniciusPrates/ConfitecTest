using Confitec.Application.Commands.Users;
using Confitec.Domain.Messages;
using Confitec.Domain.Results;
using Confitec.Infra.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.application.Handlers.Users.RemoveUser
{
    public class RemoveUsuarioCommandHandler : IRequestHandler<RemoveUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public RemoveUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResult> Handle(RemoveUsuarioCommand command, CancellationToken cancellationToken)
        {
            var obj = await _usuarioRepository.GetById(command.Id);
            if (obj != null)
                await _usuarioRepository.Remove(obj);
            else
                return new BaseResult(command, Messages.USUARIO_NAO_EXISTENTE);

            if (await _usuarioRepository.Commit())
                return new BaseResult(command, Messages.USUARIO_REMOVIDO_COM_SUCESSO);
            else
                return new BaseResult(command, Messages.USUARIO_REMOVIDO_ERRO);
        }
    }
}
