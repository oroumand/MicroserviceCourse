using System;
using System.Collections.Generic;

namespace Dm.Domain
{
    public class ApiResult<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public interface IDomainEvent
    {

    }
    public class DomainEventWrapper<TDomainEvent> where TDomainEvent :IDomainEvent
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public TDomainEvent Event { get; set; }
    }
    public class Keyword
    {
        public string Title { get; private set; }
        public List<News> News  { get; private set; }
        public Keyword(string titl)
        {
            SetTitle(titl);
        }
        public void SetTitle(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                throw new InvalidOperationException();
            }
            if(title.Length<3 || title.Length>50)
            {
                throw new InvalidOperationException();
            }
            Title = title;
        }
    }

    public class News
    {
        public string Title { get; private set; }
        public List<int> keywordIds{ get; set; }

        public List<int> CategoryIdes { get; set; }
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
        public void AddKeyword(Keyword keyword)
        {
            if (keywords.Count >= 10)
                throw new InvalidCastException();
        }
    }
}
