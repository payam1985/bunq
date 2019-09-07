namespace DataModel
{
    public class MonetaryAccount
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string IBAN { get; set; }
        public decimal Balance { get; set; }


        public long UserId { get; set; }
        public virtual User User { get; set; }
    }


}
