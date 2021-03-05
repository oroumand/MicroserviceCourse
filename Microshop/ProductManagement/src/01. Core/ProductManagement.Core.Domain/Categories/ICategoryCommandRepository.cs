using ProductManagement.Core.Domain.Categories.Entities;
using Zamin.Core.Domain.Data;

namespace ProductManagement.Core.Domain.Categories
{
    public interface ICategoryCommandRepository: ICommandRepository<Category>
    {
    }
}
