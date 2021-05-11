using Confitec.Infra.Contexts;
using Confitec.Infra.Interfaces;
using Confitec.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Confitec.Infra.Repositories.Users
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ConfitecDbContext context) : base(context)
        {
        }
    }
}
