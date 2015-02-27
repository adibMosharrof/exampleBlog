using System.Data.Entity;
using System.Linq;
using Blog.Models.Entities;

namespace Blog.Models.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DbContext _db;
        public GenericRepository()
        {
            _db = new BlogContext();
        }

        public GenericRepository(DbContext context)
        {
            _db = context;
        }
        protected DbSet<T> DbSet
        {
            get
            {
                return _db.Set<T>();
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