using System;

namespace Confitec.Domain.Models.Users
{
    public class Usuario : BaseEntity
	{

		public string Nome { get; set; }
		public string Sobrenome { get; set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; set; }
		public int EscolaridadeId { get; set; }
		public Escolaridade Escolaridade { get; set; }

        public Usuario() { }

        public Usuario(string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, int escolaridadeId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            EscolaridadeId = escolaridadeId;
        }

        public Usuario(int id) => Id = id;        
    }
}
