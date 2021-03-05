using Zamin.Core.Domain.Events;

namespace ProductManagement.Core.Domain.Categories.Events
{
    public class CategoryEnabled : IDomainEvent
    {
        public string BusinessId { get; }
        public CategoryEnabled(string businessId)
        {
            BusinessId = businessId;
        }
    }
}
