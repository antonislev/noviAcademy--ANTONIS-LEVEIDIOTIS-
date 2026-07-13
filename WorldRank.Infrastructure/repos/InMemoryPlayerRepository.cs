using Microsoft.Extensions.Caching.Memory;
using NLog;
using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;


namespace WorldRank.Infrastructure.repos
{
	public class InMemoryPlayerRepository : IPlayerRepository
	{
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		private List<Player> _players;
		private readonly IMemoryCache _cache;

		public InMemoryPlayerRepository(IMemoryCache cache)
		{
			_players = new List<Player>();
			_cache = cache;
		}

		public void AddPlayer(Player player)
		{
			_players.Add(player);
			_logger.Info("Player {PlayerId} ({Name}) added with score {Score}", player.Id, player.Name, player.Score);
		}


        public IEnumerable<Player> GetAllPlayers()
		{
			if (_cache.TryGetValue("AllPlayers", out List<Player>? cachedPlayers)&& cachedPlayers is not null)
            {
                return cachedPlayers;
            }
            var players = _players.ToList();
            _cache.Set("AllPlayers", players, TimeSpan.FromMinutes(5)); 
            return players;
        }


        public void DeletePlayer(int playerId)
		{
			var player = _players.Where(item => item.Id == playerId).FirstOrDefault();

			if (player is null)
			{
				_logger.Warn("Delete skipped: player {PlayerId} not found", playerId);
				return;
			}

			_players.Remove(player);
			_logger.Info("Player {PlayerId} deleted", playerId);
		}

		public Player? FindPlayer(int playerId)
		{
			return _players.Where(item => item.Id == playerId).FirstOrDefault();
		}

		public IEnumerable<IGrouping<int, Player>> GroupPlayersByScore()
		{
			return _players
				.GroupBy(player => player.Score)
				.OrderByDescending(group => group.Key);
		}
	}
}
