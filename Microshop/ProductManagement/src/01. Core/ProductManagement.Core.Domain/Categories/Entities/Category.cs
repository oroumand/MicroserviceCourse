using ProductManagement.Core.Domain.Categories.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;
using Zamin.Core.Domain.Toolkits.ValueObjects;
using Zamin.Core.Domain.ValueObjects;

namespace ProductManagement.Core.Domain.Categories.Entities
{
    public class Category:AggregateRoot
    {
        private HashSet<Category> _children = new HashSet<Category>();
        public Title Title { get; private set; }
        public long? ParentId { get; private set; }
        public bool Disabled { get; private set; }
        public IReadOnlyCollection<Category> Children => _children.ToList();

        private Category()
        {
        }

        public Category(BusinessId businessId, Title title)
        {
            BusinessId = businessId;
            Title = title;
            Disabled = false;
            AddEvent(new CategoryCreated(Title.Value, BusinessId.Value.ToString()));
        }


        public void AddChild(BusinessId businessId, Title title)
        {
            if (_children.Any(c => c.Title == title))
                throw new InvalidEntityStateException(ResourceKeyes.InvalidDuplicateValueInCollection, nameof(Children), nameof(Title));
            if (Disabled)
                throw new InvalidEntityStateException(ResourceKeyes.InvalidOperation, nameof(AddChild), ResourceKeyes.EntityIsDisable);

            var child = new Category
            {
                Title = title,
                BusinessId = businessId,
                Disabled = false
            };
            _children.Add(child);
            AddEvent(new CategoryCreated(child.Title.Value, child.BusinessId.Value.ToString(), BusinessId.Value.ToString()));
        }

        public void Disable()
        {
            if (!Disabled)
            {
                Disabled = true;
                AddEvent(new CategoryDisabled(BusinessId.Value.ToString()));
            }
        }

        public void Enable()
        {
            if (Disabled)
            {
                Disabled = false;
                AddEvent(new CategoryEnabled(BusinessId.Value.ToString()));
            }
        }

        public void Remove()
        {
            if (_children.Any())
                throw new InvalidEntityStateException(ResourceKeyes.InvalidOperation, nameof(Remove), ResourceKeyes.EntityIsDisable);
            AddEvent(new CategoryRemoved(BusinessId.Value.ToString()));
        }
    }
}
