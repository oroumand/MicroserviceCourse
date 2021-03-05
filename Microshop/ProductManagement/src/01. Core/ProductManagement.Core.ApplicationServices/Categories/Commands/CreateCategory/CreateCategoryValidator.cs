using FluentValidation;
using ProductManagement.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.ValueObjects;

namespace ProductManagement.Core.ApplicationServices.Categories.Commands.CreateCategory
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {

        public CreateCategoryValidator(ICategoryCommandRepository categoryCommandRepository)
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("برای عنوان مقدار لازم است")
                .MinimumLength(2).WithMessage("حداقل طول مجاز برای عنوان 2 کاراکتر است")
                .MaximumLength(100).WithMessage("حداکثر طول مجاز برای عنوان 100 کاراکتر است");
            RuleFor(c => c.BusinessId).Must(bid => !categoryCommandRepository.Exists(c => c.BusinessId == BusinessId.FromGuid(bid)))
                .WithMessage("شناسه ارسال شده تکراری است");

        }
    }
}
