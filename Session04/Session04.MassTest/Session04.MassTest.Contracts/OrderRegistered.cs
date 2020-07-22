using System;

namespace Session04.MassTest.Contracts
{
    public class OrderRegistered
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerNumber { get; set; }
    }

    public class OrderAccepted
    {
        public int OrderId { get; set; }
        public DateTime AcceptDate { get; set; }
        public string AcceptBy { get; set; }
    }

    public class OrderRejected
    {
        public int OrderId { get; set; }
        public DateTime RejectDate { get; set; }
        public string RejectBy { get; set; }
        public string Reason { get; set; }
    }

}
