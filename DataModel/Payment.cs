using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Payment
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Recipient { get; set; }


        public long UserId { get; set; }
        public virtual User User { get; set; }
    }
}
