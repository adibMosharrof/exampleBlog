using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public DbSet<Post> Posts { get; set; }

    }
}
