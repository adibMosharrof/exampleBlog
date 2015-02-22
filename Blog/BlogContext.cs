using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models.Entities;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
            // the terrible hack
            var ensureDLLIsCopied =
                    System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
