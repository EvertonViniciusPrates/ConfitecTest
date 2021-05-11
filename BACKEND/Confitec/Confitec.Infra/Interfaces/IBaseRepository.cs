using Confitec.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confitec.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Save(T objeto);

        Task<T> Update(T objeto);

        Task Remove(T obj);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<bool> Commit();
    }
}
