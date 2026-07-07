using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create some test players
        List<Player> players = new List<Player>
        {
            new Player("Alice", "Red Falcons", 85),
            new Player("Bob", "Blue Sharks", 92),
            new Player("Charlie", "Red Falcons", 60),
            new Player("Diana", "Green Wolves", 78),
            new Player("Ethan", "Blue Sharks", 45)
        };

        Console.WriteLine("=== All Players ===");
        foreach (var p in players)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n=== Sorted by Score (Descending) ===");
        var ranked = players.OrderByDescending(p => p.Score);
        foreach (var p in ranked)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n=== Players with Score > 70 ===");
        var highScorers = players.Where(p => p.Score > 70);
        foreach (var p in highScorers)
        {
            Console.WriteLine(p);
        }

        Console.WriteLine("\n=== Grouped by Team ===");
        var byTeam = players.GroupBy(p => p.Team);
        foreach (var group in byTeam)
        {
            Console.WriteLine($"Team: {group.Key}");
            foreach (var p in group)
            {
                Console.WriteLine($"   {p}");
            }
        }

        Console.WriteLine("\n=== Average Score ===");
        double avg = players.Average(p => p.Score);
        Console.WriteLine($"Average score: {avg:F2}");

        Console.WriteLine("\n=== Top Player ===");
        Player top = players.OrderByDescending(p => p.Score).First();
        Console.WriteLine($"Top player: {top}");
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    
}