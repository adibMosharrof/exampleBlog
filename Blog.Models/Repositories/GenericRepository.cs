using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Http.OData;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _context;
        public GenericRepository()
        {
            _context = new BlogContext();
        }

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                return _context.Set<T>();
            }
        }
        public virtual IQueryable<T> Get()
        {
            return DbSet.AsQueryable();
        }

        public virtual bool Exists(int key)
        {
            return DbSet.Any(p => p.Id == key);
        }

        public virtual T Get(int key)
        {
            return DbSet.Find(key);
        }

        //public virtual int Post(T entity)
        //{

        //}
    }
}