using ProductManagement.Core.Domain.Categories;
using ProductManagement.Core.Domain.Categories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;
using Zamin.Utilities;

namespace ProductManagement.Core.ApplicationServices.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryCommandRepository _repository;

        public CreateCategoryCommandHandler(ZaminServices zaminServices,
                                            ICategoryCommandRepository repository) : base(zaminServices)
        {
            this._repository = repository;
        }

        public override Task<CommandResult> Handle(CreateCategoryCommand request)
        {
            var category = new Category(request.BusinessId, request.Title);
            _repository.Insert(category);
            _repository.Commit();
            return OkAsync();
        }
    }
}
