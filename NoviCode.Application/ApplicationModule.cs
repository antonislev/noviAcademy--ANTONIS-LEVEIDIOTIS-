using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode
{
    internal class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           var configuration = MediatRConfigurationBuilder
                .Create()
                .WithAllOpenGenericHandlerTypesRegistered()
                .Build();
            builder.RegisterMediatR(configuration);
        }
    }
}
