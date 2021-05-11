using Confitec.Domain.Messages;
using FluentValidation;
using System;

namespace Confitec.Application.Commands.Users.Validations
{
    public class InsertUsuarioCommandValidator : AbstractValidator<InsertUsuarioCommand>
    {
        public InsertUsuarioCommandValidator() {
            RuleFor(x => x.Email).NotEmpty().WithMessage(Messages.CAMPO_NAO_PREENCHIDO).EmailAddress().WithMessage(Messages.EMAIL_INVALIDO);
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage(Messages.CAMPO_NAO_PREENCHIDO).LessThan(DateTime.Now).WithMessage(Messages.DATA_NASCIMENTO_MAIOR_ERRO);
            RuleFor(x => x.Nome).MaximumLength(100).WithMessage(Messages.CAMPO_NAO_PREENCHIDO).MaximumLength(100).WithMessage(Messages.CAMPO_MAIOR);
            RuleFor(x => x.Sobrenome).MaximumLength(100).WithMessage(Messages.CAMPO_MAIOR).NotEmpty().WithMessage(Messages.CAMPO_NAO_PREENCHIDO);
            RuleFor(x => x.EscolaridadeId).NotEmpty().WithMessage(Messages.CAMPO_NAO_PREENCHIDO);
        }
    }
}
