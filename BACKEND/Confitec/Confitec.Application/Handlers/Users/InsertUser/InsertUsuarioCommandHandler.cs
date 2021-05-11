using Confitec.Application.Commands.Users;
using Confitec.Domain.Messages;
using Confitec.Domain.Models.Users;
using Confitec.Domain.Results;
using Confitec.Infra.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.application.Handlers.Users.InsertUser
{
    public class InsertUsuarioCommandHandler : IRequestHandler<InsertUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public InsertUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResult> Handle(InsertUsuarioCommand command, CancellationToken cancellationToken)
        {
            var result = await _usuarioRepository.Save(new Usuario(command.Nome, command.Sobrenome, 
                                                                   command.Email, command.DataNascimento, 
                                                                   command.EscolaridadeId));

            if (await _usuarioRepository.Commit())
                return new BaseResult(result, Messages.USUARIO_INSERIDO_COM_SUCESSO);
            else
                return new BaseResult(command, Messages.USUARIO_INSERIDO_ERRO);
        }
    }

}
