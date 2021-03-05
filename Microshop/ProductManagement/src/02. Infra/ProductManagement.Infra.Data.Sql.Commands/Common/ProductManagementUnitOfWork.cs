using ProductManagement.Core.Domain;
using Zamin.Infra.Data.Sql.Commands;
using Zamin.Utilities;

namespace ProductManagement.Infra.Data.Sql.Commands.Common
{
    public class ProductManagementUnitOfWork : BaseEntityFrameworkUnitOfWork<ProductManagementCommandDbContext>, IProductManagementUnitOfWork
    {
        public ProductManagementUnitOfWork(ProductManagementCommandDbContext dbContext, ZaminServices zaminApplicationContext) : base(dbContext, zaminApplicationContext)
        {
        }
    }
}
