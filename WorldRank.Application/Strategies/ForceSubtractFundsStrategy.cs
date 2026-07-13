using System;
using System.Collections.Generic;
using System.Text;
using WorldRank.Domain.Entities;
using WorldRank.Domain.Exceptions;
using WorldRank.Domain.Enums;

namespace WorldRank.Application.Strategies
{
    public class ForceSubtractFundsStrategy : IFoundsStrategy
    {
        public FundsOperation Operation => FundsOperation.ForceSubtract;

        public void Execute(Wallet wallet, decimal amount)
        {
            if (amount <= 0)
                throw new InvalidAmountException(amount);

            var newBalance = wallet.Balance - amount;
            if (newBalance < 0)
                newBalance = 0;

            wallet.SetBalance(newBalance);
        }
    }
}
