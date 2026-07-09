using Microsoft.Extensions.DependencyInjection;
using WorldRank.Application.interfaces;
using WorldRank.Infrastructure.repos;

namespace WorldRank.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IPlayerRepository, InMemoryPlayerRepository>();
            services.AddSingleton<IWalletRepository, InMemoryWalletRepository>();

            return services;
        }
    }
}