using System;

namespace EsSample.Framework
{
    public class EventStoreItem
    {
        public long EventStoreItemId { get; set; }
        public string StreamName { get; set; }
        public string StreamId { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime EventDate { get; set; }
    }
}
