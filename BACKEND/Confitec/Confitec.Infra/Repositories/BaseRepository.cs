using Confitec.Infra.Contexts;
using Confitec.Infra.Interfaces;
using Confitec.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Confitec.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ConfitecDbContext _context;

        protected BaseRepository(ConfitecDbContext context)
        {
            _context = context;
        }

        public async Task<T> Save(T objeto)
        {
            await _context.Set<T>().AddAsync(objeto);

            return objeto;
        }

        public async Task<T> Update(T objeto)
        {
            await Task.Run(() => _context.Entry(objeto).State = EntityState.Modified);
            return objeto;
        }

        public async Task Remove(T obj)
        {
            await Task.Run(() => _context.Remove(obj));
            await Task.CompletedTask;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
