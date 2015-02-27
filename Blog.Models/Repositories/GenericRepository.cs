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
        public virtual IQueryable<T> All()
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

        public virtual void Create(T entity)
        {
            DbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual T Patch(int key, Delta<T> patch)
        {
            var entity = DbSet.Find(key);
            if (entity == null)
            {
                return null;
            }
            patch.Patch(entity);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(key))
                    return null;
                throw;
            }
            return entity;
        }

    }
}