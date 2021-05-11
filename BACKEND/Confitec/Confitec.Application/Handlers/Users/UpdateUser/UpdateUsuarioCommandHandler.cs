using Confitec.Application.Commands.Users;
using Confitec.Domain.Messages;
using Confitec.Domain.Results;
using Confitec.Infra.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.application.Handlers.Users.UpdateUser
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResult> Handle(UpdateUsuarioCommand command, CancellationToken cancellationToken)
        {
            var req = await _usuarioRepository.GetById(command.Id);
            if (req == null)
                return new BaseResult(command, Messages.USUARIO_ALTERADO_ERRO);

            req.Email = command.Email;
            req.DataNascimento = command.DataNascimento;
            req.EscolaridadeId = command.EscolaridadeId;
            req.Nome = command.Nome;
            req.Sobrenome = command.Sobrenome;
                      
            await _usuarioRepository.Update(req);

            if (await _usuarioRepository.Commit())
                return new BaseResult(command, Messages.USUARIO_ALTERADO_COM_SUCESSO);
            else
                return new BaseResult(command, Messages.USUARIO_ALTERADO_ERRO);
        }
    }
}
