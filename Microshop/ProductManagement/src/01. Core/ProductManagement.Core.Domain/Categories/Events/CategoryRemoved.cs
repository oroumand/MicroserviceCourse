using Zamin.Core.Domain.Events;

namespace ProductManagement.Core.Domain.Categories.Events
{
    public class CategoryRemoved : IDomainEvent
    {
        public string BusinessId { get; }
        public CategoryRemoved(string businessId)
        {
            BusinessId = businessId;
        }
    }
}
