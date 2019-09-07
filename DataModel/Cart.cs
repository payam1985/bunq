using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Cart
    {
        public long Id { get; set; }
        public string Value { get; set; }
        public LoginType Type { get; set; }


        public long UserId { get; set; }
        public virtual User User { get; set; }
    }

    public enum LoginType : byte {
        PHONE_NUMBER,
        EMAIL
    }
}
