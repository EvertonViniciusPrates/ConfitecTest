using Confitec.Application.Commands.Users;
using Confitec.Domain.Messages;
using Confitec.Domain.Results;
using Confitec.Infra.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Confitec.Application.Queries.Users
{
    public class FindUsuarioCommandHandler : IRequestHandler<FindUsuarioCommand, BaseResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public FindUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<BaseResult> Handle(FindUsuarioCommand command, CancellationToken cancellationToken)
        {
            if (command.Id < 1)
            {
                var results = await _usuarioRepository.GetAll();

                if(results.Count > 0)
                    return new BaseResult { Result = results };

                return new BaseResult { Result = results, Msg = Messages.SEM_REGISTROS_SUFICIENTE };
            }
            var result = await _usuarioRepository.GetById(command.Id);

            if (result != null)
                return new BaseResult { Result = result };

            return new BaseResult { Result = result, Msg = Messages.USUARIO_NAO_EXISTENTE };
        }
    }
}
