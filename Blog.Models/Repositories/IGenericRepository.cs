using System.Linq;
using System.Web.Http.OData;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IQueryable<T> All();
        bool Exists(int key);
        T Get(int key);
        void Create(T entity);
        T Patch(int key, Delta<T> patch);
    }
}