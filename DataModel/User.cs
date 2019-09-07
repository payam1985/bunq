using System;
using System.Collections.Generic;

namespace DataModel
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MonetaryAccount> MonetaryAccounts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<DataModel.Request> Requests { get; set; }
        public virtual ICollection<Cart> Cards { get; set; }
        
    }
}
