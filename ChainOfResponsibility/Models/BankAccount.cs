using Microsoft.EntityFrameworkCore;
using ChainOfResponsibilty.Models;

namespace ChainOfResponsibilty.Models
{
    // Models/BankAccount.cs
    public class BankAccount
    {
        public BankAccount()
        {
            UserId = new Guid();   
        }
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public ICollection<Transactions> Transactions { get; set; }
    }

}
