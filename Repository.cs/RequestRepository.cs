using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RequestRepository
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public decimal Amount { get; set; }
        public string Recipient { get; set; }
    }
}
