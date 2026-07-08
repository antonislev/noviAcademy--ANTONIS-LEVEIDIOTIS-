namespace WorldRank.main;

public class Wallet
{
	public int PlayerId { get; }
	public Currency Currency { get; }
	public decimal	Balance { get; private set; }
	public	bool IsBlocked { get; private set; }


    public Wallet(int playerId , Currency currency)
	{
		PlayerId = playerId;
		Currency = currency;
    }

	public void Deposit(decimal amount)
    {
        if (IsBlocked)
            throw new InvalidOperationException("Wallet is blocked.");
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (IsBlocked)
            throw new InvalidOperationException("Wallet is blocked.");
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient balance.");
        Balance -= amount;
    }

    public void Block() => IsBlocked = true;
    public void Unblock() => IsBlocked = false;

    public override string ToString() =>
        $"Wallet for Player ID: {PlayerId}, Currency: {Currency}, Balance: {Balance}, IsBlocked: {IsBlocked}";
}
