using WorldRank.Application.Interfaces;
using WorldRank.Domain.Entities;
using WorldRank.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;


namespace WorldRank.Infrastructure.repos
{
    public class DBPlayerRepository : IPlayerRepository
    {
        private readonly WorldRankDbContext _context;

        public DBPlayerRepository(WorldRankDbContext context)
        {
            _context = context;
        }

        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        public IEnumerable<Player> GetAllPlayers() => _context.Players.ToList();

        public void DeletePlayer(int playerId)
        {
            var player = _context.Players.Find(playerId);
            if (player != null)
            {
                _context.Players.Remove(player);
                _context.SaveChanges();
            }
        }

        public Player? FindPlayer(int playerId) => _context.Players.Find(playerId);

        public IEnumerable<IGrouping<int, Player>> GroupPlayersByScore()
            => _context.Players.ToList().GroupBy(p => p.Score);
    }
}