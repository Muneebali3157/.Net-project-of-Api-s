using Microsoft.EntityFrameworkCore;
using Crud_Operation_with_Repo.Models;

namespace Crud_Operation_with_Repo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Product> Products
        {
            get; set;
        }
    }
}