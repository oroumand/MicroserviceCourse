using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Events;

namespace ProductManagement.Core.Domain.Categories.Events
{
    public class CategoryCreated:IDomainEvent
    {
        public string Title { get; }
        public string BusinessId { get; }
        public string ParentBusinessId { get; }
        public CategoryCreated(string title, string businessId)
        {
            Title = title;
            BusinessId = businessId;
        }
        public CategoryCreated(string title, string businessId, string parentBusinessId) : this(title, businessId)
        {
            ParentBusinessId = parentBusinessId;
        }
    }
}
