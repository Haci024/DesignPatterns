using ChainOfResponsibilty.Connection;
using ChainOfResponsibilty.DTO;
using ChainOfResponsibilty.Handlers;
using ChainOfResponsibilty.Models;
using System.Transactions;

namespace ChainOfResponsibilty.Handlers
{
    
    public class WithdrawHandler : ActionHandler
    {
        private readonly AppDbContext _context;

        public WithdrawHandler(AppDbContext context)
        {
            _context = context;
        }

        public override void Handle(ActionRequestDTO request)
        {
            if (request.TransactionType == "Withdraw")
            {
                var account = _context.BankAccounts.FirstOrDefault(a => a.UserId == request.UserId);

                if (account == null)
                {

                    Console.WriteLine("WithdrawHandler: The User Not Found In Database!");
                }
                if (account.Balance >= request.Amount)
                {
                    Transactions transaction = new();
                    transaction.TransactionType = request.TransactionType;
                    transaction.Amount = request.Amount;
                    transaction.UserId = account.UserId;
                    account.Balance -= request.Amount;
                    transaction.result= $"WithdrawHandler: {request.Amount} azn remove from account: {account.Balance} azn";
                    _context.Update(account);
                    _context.Add(transaction);
                    _context.SaveChanges();
                    
                }
                else
                {
                    Transactions transaction = new();
                    transaction.TransactionType = request.TransactionType;
                    transaction.Amount = request.Amount;
                    transaction.UserId = account.UserId;
                    transaction.result = $"Your balance low from {request.Amount}!";
                    _context.Add(transaction);
                    _context.SaveChanges();
                    
                }
            }
            else
            {

                _nextHandler?.Handle(request);
               
             
            }
        }
    }

}
