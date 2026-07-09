using System;
using System.Collections.Generic;
using System.Text;
using WorldRank.Application.interfaces;
using WorldRank.Domain.Entities;
using WorldRank.Domain.Enums;

namespace WorldRank.Application.Strategies
{
    public class SubtractFundsStrategy : IFoundsStrategy
    {
        public FundsOperation Operation => FundsOperation.Subtract;

        public void Execute(Wallet wallet, decimal amount) => wallet.Withdraw(amount);
    }
}