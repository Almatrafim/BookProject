using BookProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.DataAccess
{
    public class DBcontext : DbContext
    {
        public DBcontext(DbContextOptions<DBcontext> options):base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
