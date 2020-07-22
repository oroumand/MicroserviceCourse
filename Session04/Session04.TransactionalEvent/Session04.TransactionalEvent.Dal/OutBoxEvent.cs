using System;

namespace Session04.TransactionalEvent.Dal
{
    public class OutBoxEvent
    {
        public long OutBoxEventId { get; set; }
        public string StreamName { get; set; }
        public string StreamId { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime EventDate { get; set; }
    }
}
