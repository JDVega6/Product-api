using ApiProducts.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProducts.Data
{
    public class ProductContextDb : DbContext
    {
        public ProductContextDb()
        { }

        public ProductContextDb(DbContextOptions options)
            : base(options)
        { }
        public DbSet<Products> Product { get; set; }
            
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost; Port=3306; Database=firtschallenge; Uid=root; Pwd=123456") ;                                                               
        }

    }
}
