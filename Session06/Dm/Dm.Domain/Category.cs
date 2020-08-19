using System;
using System.Collections.Generic;

namespace Dm.Domain
{
    public class Category
    {
        public string Title { get; private set; }
        public List<News> News { get; private set; }
        public Category(string titl)
        {
            SetTitle(titl);
        }
        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException();
            }
            if (title.Length < 3 || title.Length > 50)
            {
                throw new InvalidOperationException();
            }
            Title = title;
        }
    }
}
