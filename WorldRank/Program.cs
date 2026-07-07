using WorldRank;

var playerRepo = new InMemoryPlayerRepository();
var walletRepo = new InMemoryWalletRepository(playerRepo);

while (true)
{
    Console.WriteLine("\n=== WorldRank Player Registry ===");
    Console.WriteLine("1. Add player");
    Console.WriteLine("2. List all players");
    Console.WriteLine("3. Find player by ID");
    Console.WriteLine("4. Delete player");
    Console.WriteLine("5. Add wallet to player");
    Console.WriteLine("6. List player's wallets");
    Console.WriteLine("7. Group players by score");
    Console.WriteLine("0. Exit");
    Console.Write("> ");

    Action? action = Console.ReadLine() switch
    {
        "1" => AddPlayer,
        "2" => ListPlayers,
        "3" => FindPlayer,
        "4" => DeletePlayer,
        "5" => AddWallet,
        "6" => ListWallets,
        "7" => GroupByScore,
        "0" => null,
        _ => () => Console.WriteLine("Unknown option.")
    };

    if (action is null)
        return;

    action();
}

void AddPlayer()
{
    Console.Write("Name: ");
    var name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Name cannot be empty.");
        return;
    }

    Console.Write("Score: ");
    if (!int.TryParse(Console.ReadLine(), out var score) || score < 0)
    {
        Console.WriteLine("Score must be a non-negative whole number.");
        return;
    }

    var player = new Player(name);
    player.UpdateScore(score);
    playerRepo.AddPlayer(player);
    Console.WriteLine($"Player added successfully. (ID: {player.Id})");
}

void ListPlayers()
{
    var players = playerRepo.GetAll().ToList();
    if (players.Count == 0)
    {
        Console.WriteLine("No players registered.");
        return;
    }

    foreach (var p in players)
        Console.WriteLine(p);
}

void FindPlayer()
{
    Console.Write("Search by ID: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    var player = playerRepo.FindPlayer(id);
    Console.WriteLine(player is null ? "No player found." : player.ToString());
}

void DeletePlayer()
{
    Console.Write("Player ID to delete: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    if (playerRepo.FindPlayer(id) is null)
    {
        Console.WriteLine("No player found.");
        return;
    }

    playerRepo.DeletePlayer(id);
    Console.WriteLine("Player deleted.");
}

void AddWallet()
{
    Console.Write("Player ID: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    if (playerRepo.FindPlayer(id) is null)
    {
        Console.WriteLine("No player found.");
        return;
    }

    Console.WriteLine($"Currencies: {string.Join(", ", Enum.GetNames<Currency>())}");
    Console.Write("Currency: ");
    if (!Enum.TryParse<Currency>(Console.ReadLine(), true, out var currency))
    {
        Console.WriteLine("Unknown currency.");
        return;
    }

    try
    {
        walletRepo.Add(new Wallet(id, currency), id);
        Console.WriteLine("Wallet added.");
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void ListWallets()
{
    Console.Write("Player ID: ");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Invalid ID.");
        return;
    }

    var wallets = walletRepo.GetByPlayer(id).ToList();
    if (wallets.Count == 0)
    {
        Console.WriteLine("No wallets for this player.");
        return;
    }

    foreach (var w in wallets)
        Console.WriteLine(w);
}

void GroupByScore()
{
    var groups = playerRepo.GetPlayersGroupedByScore().ToList();
    if (groups.Count == 0)
    {
        Console.WriteLine("No players registered.");
        return;
    }

    foreach (var group in groups)
    {
        Console.WriteLine($"Score {group.Key}:");
        foreach (var p in group)
            Console.WriteLine($"  {p}");
    }
}