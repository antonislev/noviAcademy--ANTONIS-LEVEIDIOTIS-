using WorldRank.Domain.Enums;

namespace WorldRank.Domain.Entities
{
	public interface IWallet
	{
		int PlayerId { get; }
		Currency Currency { get; }
		decimal Balance { get; }
		bool IsBlocked { get; }

		void Block();
		void Unblock();
		void SetBalance(decimal balance);
		void Deposit(decimal amount);
		void Withdraw(decimal amount);
		void AddFunds(decimal amount);
		void SubstractFunds(decimal amount);
		void ForceSubstractFunds(decimal amount);
		void ForceDeposit(decimal amount);

    }
}
