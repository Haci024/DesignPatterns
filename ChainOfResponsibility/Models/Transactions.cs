using ChainOfResponsibilty.Models;

namespace ChainOfResponsibilty.Models
{
    public class Transactions
    {
        public Transactions()
        {
            Id = new Guid();
        }
        public Guid Id { get; set; }
        public string TransactionType { get; set; }  
        public decimal Amount { get; set; }          
        public Guid UserId { get; set; }
        public BankAccount BankAccount { get; set; }
        public string result { get; set; }


    }
}
