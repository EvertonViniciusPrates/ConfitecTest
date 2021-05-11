using Confitec.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Domain.Results.Users
{
    public class UsuarioResult
    {
        public int Id;
           

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId { get; set; }
        public Escolaridade Escolaridade { get; set; }

        public UsuarioResult(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId, Escolaridade escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
            Escolaridade = escolaridade;
        }

        public static explicit operator UsuarioResult(Usuario usuario){
            if (usuario != null)
                return new UsuarioResult(usuario.Id, 
                                     usuario.Nome, 
                                     usuario.Sobrenome, 
                                     usuario.Email, 
                                     usuario.DataNascimento, 
                                     usuario.EscolaridadeId, 
                                     usuario.Escolaridade);

            return null;
        }
    }
}
