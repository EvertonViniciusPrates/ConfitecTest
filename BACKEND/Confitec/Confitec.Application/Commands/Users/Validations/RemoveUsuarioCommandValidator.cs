using Confitec.Domain.Messages;
using FluentValidation;

namespace Confitec.Application.Commands.Users.Validations
{
    public class RemoveUsuarioCommandValidator : AbstractValidator<RemoveUsuarioCommand>
    {
        public RemoveUsuarioCommandValidator() {
            RuleFor(x => x.Id).NotEmpty().WithMessage(Messages.CAMPO_NAO_PREENCHIDO);
        }
    }
}
