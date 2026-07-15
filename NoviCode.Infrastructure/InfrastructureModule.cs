using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoviCode
{
    public class InfrastructureModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<CreatePlayerPersistence>().As<ICreatePlayerPersistence>().InstancePerLifetimeScope();

            //builder.RegisterDecorator(typeof(CreatePlayersPersistenceCachingDecorator), typeof(ICreatePlayerPersistence));
        }
    }
}
