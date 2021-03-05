using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.ApplicationServices.Commands;

namespace ProductManagement.Core.ApplicationServices.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand: ICommand
    {
        public string Title { get; set; }
        public Guid BusinessId { get; set; }
    }
}
