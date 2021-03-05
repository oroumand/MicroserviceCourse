using ProductManagement.Core.Domain.Categories;
using ProductManagement.Core.Domain.Categories.Entities;
using ProductManagement.Infra.Data.Sql.Commands.Common;
using Zamin.Infra.Data.Sql.Commands;

namespace ProductManagement.Infra.Data.Sql.Commands.Categories
{
    public class CategoryCommandRepository : BaseCommandRepository<Category, ProductManagementCommandDbContext>,
        ICategoryCommandRepository
    {
        public CategoryCommandRepository(ProductManagementCommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
