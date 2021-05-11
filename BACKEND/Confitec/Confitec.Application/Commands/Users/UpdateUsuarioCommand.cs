using Confitec.Domain.Models.Users;
using System;

namespace Confitec.Application.Commands.Users
{
    public class UpdateUsuarioCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }

        public UpdateUsuarioCommand()
        {
        }

        public UpdateUsuarioCommand(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public static explicit operator UpdateUsuarioCommand(Usuario usr)
        {
            return new UpdateUsuarioCommand(usr.Id, usr.Nome, usr.Sobrenome, usr.Email, usr.DataNascimento, usr.EscolaridadeId);
        }
    }
}
