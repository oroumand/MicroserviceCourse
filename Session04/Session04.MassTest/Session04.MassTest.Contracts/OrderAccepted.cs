using System;

namespace Session04.MassTest.Contracts
{
    public class OrderAccepted
    {
        public int OrderId { get; set; }
        public DateTime AcceptDate { get; set; }
        public string AcceptBy { get; set; }
    }

}
