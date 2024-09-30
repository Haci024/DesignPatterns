using ChainOfResponsibilty.Connection;
using ChainOfResponsibilty.DTO;
using ChainOfResponsibilty.Handlers;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ChainOfResponsibilty.Models;

namespace ChainOfResponsibilty.Handlers
{
    
    public class CheckBalanceHandler : ActionHandler
    {
        private readonly AppDbContext _context;

        public CheckBalanceHandler(AppDbContext context)
        {
            _context = context;
        }

        public override void Handle(ActionRequestDTO dto)
        {
            if (dto.TransactionType == "CheckBalance")
            {
                var account = _context.BankAccounts.FirstOrDefault(a => a.UserId == dto.UserId);

                if (account == null)
                {

                    Console.WriteLine("CheckBalanceHandler: The user not found in database.");
                }
                else
                {
                    Transactions transaction = new();
                    transaction.TransactionType = dto.TransactionType;
                    transaction.Amount =account.Balance;
                    transaction.UserId = dto.UserId;
                    transaction.result= $"CheckBalanceHandler:{account.Balance} {account.Currency} you have." + $"Action Date:{DateTime.UtcNow.ToString("dd:mm:yyyy HH:mm")}";
                    _context.Add(transaction);
                    _context.SaveChanges();
                    Console.WriteLine(transaction.result);
                }

               
            }
            else
            {
                _nextHandler?.Handle(dto);

                Console.WriteLine("Prosess ötürüldü");
            }
        }
    }

}
