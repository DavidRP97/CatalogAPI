using CatalogAPI_BLL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI_DAL.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }         
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
