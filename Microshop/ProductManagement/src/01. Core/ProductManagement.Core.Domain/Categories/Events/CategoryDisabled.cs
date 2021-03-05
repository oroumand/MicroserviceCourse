using Zamin.Core.Domain.Events;

namespace ProductManagement.Core.Domain.Categories.Events
{
    public class CategoryDisabled : IDomainEvent
    {
        public string BusinessId { get; }
        public CategoryDisabled(string businessId)
        {
            BusinessId = businessId;
        }
    }
}
