using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentRepository
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Recipient { get; set; }
    }
}
