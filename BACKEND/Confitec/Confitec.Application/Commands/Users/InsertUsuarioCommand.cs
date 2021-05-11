using Confitec.Domain.Models.Users;
using System;

namespace Confitec.Application.Commands.Users
{
    public class InsertUsuarioCommand : Command
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }

        public InsertUsuarioCommand()
        {
        }

        public InsertUsuarioCommand(string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public static explicit operator InsertUsuarioCommand(Usuario usr) {
            return new InsertUsuarioCommand(usr.Nome, usr.Sobrenome, usr.Email, usr.DataNascimento, usr.EscolaridadeId);
        }
    }
}
