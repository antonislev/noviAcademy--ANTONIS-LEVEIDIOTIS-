using Microsoft.Extensions.DependencyInjection;
using WorldRank.Application.Services;

namespace WorldRank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<PlayerService>();
            services.AddScoped<WalletService>();

            return services;
        }
    }
}