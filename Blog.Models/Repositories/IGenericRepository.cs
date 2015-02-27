using System.Linq;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get();
        bool Exists(int key);
        T Get(int key);
    }
}