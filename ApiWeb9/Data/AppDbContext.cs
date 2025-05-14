using ApiWeb9.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb9.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<ProdutosModel> Produtos { get; set; }



    }
}
