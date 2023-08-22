using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BoilerPlateCrud.Authorization.Roles;
using BoilerPlateCrud.Authorization.Users;
using BoilerPlateCrud.MultiTenancy;
using BoilerPlateCrud.Product;

namespace BoilerPlateCrud.EntityFrameworkCore
{
    public class BoilerPlateCrudDbContext : AbpZeroDbContext<Tenant, Role, User, BoilerPlateCrudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BoilerPlateCrudDbContext(DbContextOptions<BoilerPlateCrudDbContext> options)
            : base(options)
        {
        }
    public DbSet<Products> Product { get; set; }

  }
}
