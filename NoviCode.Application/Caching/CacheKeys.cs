using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode.Caching
{
    public static class CacheKeys
    {
        public static string Player(Guid id) => $"player:{id}";
        public const string AllPlayers = "players:all";

        public static string Wallet(Guid id) => $"wallet:{id}";
        public static string PlayerWallets(Guid playerId) => $"wallets:player:{playerId}";
        public const string AllWallets = "wallets:all";
    }
}
