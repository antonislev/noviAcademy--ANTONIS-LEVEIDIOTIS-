using Microsoft.Extensions.Logging;
using WorldRank.exe;
namespace WorldRank.main;

public class Wallet
{
	public int PlayerId { get; }
	public Currency Currency { get; }
	public decimal	Balance { get; private set; }
	public	bool IsBlocked { get; private set; }

    private readonly ILogger<Wallet> _logger;
    public Wallet(int playerId , Currency currency, ILogger<Wallet> logger)
	{
		PlayerId = playerId;
		Currency = currency;
        _logger = logger;
    }

	public void Deposit(decimal amount)
    {
        if (IsBlocked)
        {
            _logger.LogError("Deposit failed: PlayerId={PlayerId}, Currency={Currency} - wallet is blocked", PlayerId, Currency);
            throw new Walletblockedexception("Wallet is blocked.");
        }
        if (amount <= 0)
        {
            _logger.LogError("Deposit failed: PlayerId={PlayerId}, Currency={Currency} - deposit amount must be positive", PlayerId, Currency);
        }
        Balance += amount;
        _logger.LogInformation("Deposit successful: PlayerId={PlayerId}, Currency={Currency}, Amount={Amount}, NewBalance={NewBalance}", PlayerId, Currency, amount, Balance);
    }

    public void Withdraw(decimal amount)
    {
        if (IsBlocked)
        {
            _logger.LogError("Withdrawal failed: PlayerId={PlayerId}, Currency={Currency} - wallet is blocked", PlayerId, Currency);
            throw new Walletblockedexception("Wallet is blocked.");
        }
        if (amount <= 0)
        {
            _logger.LogError("Withdrawal failed: PlayerId={PlayerId}, Currency={Currency} - withdrawal amount must be positive", PlayerId, Currency);
            throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
        }
        if (amount > Balance)
        {
            _logger.LogError("Withdrawal failed: PlayerId={PlayerId}, Currency={Currency} - insufficient funds. Requested={Requested}, Available={Available}", PlayerId, Currency, amount, Balance);
            throw new InvalidOperationException("Insufficient funds.");
        }
        Balance -= amount;
        _logger.LogInformation("Withdrawal successful: PlayerId={PlayerId}, Currency={Currency}, Amount={Amount}, NewBalance={NewBalance}", PlayerId, Currency, amount, Balance);
    }

    public void Block() => IsBlocked = true;
    public void Unblock() => IsBlocked = false;
    public void SetBalance(decimal newBalance)
    {
        if (newBalance < 0)
            throw new ArgumentOutOfRangeException(nameof(newBalance), "Balance cannot be negative.");
        Balance = newBalance;
    }

    public override string ToString() =>
        $"Wallet for Player ID: {PlayerId}, Currency: {Currency}, Balance: {Balance}, IsBlocked: {IsBlocked}";
}
