using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using WorldRank.Application.Strategies;
using WorldRank.Application.interfaces;
using WorldRank.Application.Services;

namespace WorldRank.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWorldRank(this IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.ClearProviders();
                builder.AddNLog();
                builder.SetMinimumLevel(LogLevel.Trace);
            });

            services.AddApplication();
            services.AddInfrastructure();

            return services;
        }

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IFoundsStrategy, AddFundsStrategy>();
            services.AddSingleton<IFoundsStrategy, SubtractFundsStrategy>();
            services.AddSingleton<IFoundsStrategy, ForceSubtractFundsStrategy>();

            services.AddSingleton<WalletService>();

            return services;
        }
    }
}