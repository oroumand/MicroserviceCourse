using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ProductManagement.Infra.Data.Sql.Commands.Common
{
    public class ProductManagementCommandDbContextFactory : IDesignTimeDbContextFactory<ProductManagementCommandDbContext>
    {
        public ProductManagementCommandDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProductManagementCommandDbContext>();
            optionsBuilder.UseSqlServer("Server =.,1833; Database=ProductManagementDb ;User Id =sa;Password=1qaz!QAZ; MultipleActiveResultSets=true");

            return new ProductManagementCommandDbContext(optionsBuilder.Options);
        }
    }
}
