using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BoilerPlateCrud.Configuration;
using BoilerPlateCrud.Web;

namespace BoilerPlateCrud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BoilerPlateCrudDbContextFactory : IDesignTimeDbContextFactory<BoilerPlateCrudDbContext>
    {
        public BoilerPlateCrudDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BoilerPlateCrudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BoilerPlateCrudDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BoilerPlateCrudConsts.ConnectionStringName));

            return new BoilerPlateCrudDbContext(builder.Options);
        }
    }
}
