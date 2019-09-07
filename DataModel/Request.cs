using System;

namespace DataModel
{
    public class Request
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public decimal Amount { get; set; }
        public string Recipient { get; set; }


        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
