﻿using SimpleBank.Models;
using System.Linq;

namespace SimpleBank.Services.BankAccountServices
{
    public class BankAccountServices
    {
        private IApplicationDbContext db;

        public BankAccountServices(IApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }
        

        public void Deposit(Transaction transaction)
        {           
            var bankAccount = db.BankAccounts.Where(c => c.ApplicationUserId.Equals(transaction.userId) && c.Id == transaction.id).FirstOrDefault();
            if (bankAccount != null)
            {
                bankAccount.Balance += transaction.amount;
                db.SaveChanges();
            }
        }

        public string Withdraw(Transaction transaction)
        {
            var bankAccount = db.BankAccounts.Where(c => c.ApplicationUserId.Equals(transaction.userId) && c.Id == transaction.id).FirstOrDefault();
            if(bankAccount == null)
            {
                return "Not Found";
            }
            if (bankAccount.Balance - transaction.amount < 100)
            {
                return "TooMuch";
            }
            if ((transaction.amount / bankAccount.Balance) > 0.9M)
            {
                return "insufficientFunds";
            }

            bankAccount.Balance -= transaction.amount;
            db.SaveChanges();
            return "";
        }
    }
}