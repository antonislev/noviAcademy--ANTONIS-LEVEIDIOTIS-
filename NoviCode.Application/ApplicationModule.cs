using Autofac;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using NoviCode.Decorators;

namespace NoviCode
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = MediatRConfigurationBuilder
                .Create(ThisAssembly)
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();

            builder.RegisterMediatR(configuration);

            
            builder.RegisterGenericDecorator(typeof(QueryCachingDecorator<,>), typeof(IRequestHandler<,>));
            builder.RegisterGenericDecorator(typeof(CacheInvalidationDecorator<,>), typeof(IRequestHandler<,>));
            builder.RegisterGenericDecorator(typeof(LoggingDecorator<,>), typeof(IRequestHandler<,>));
        }
    }
}