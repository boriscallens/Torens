using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Torens.Application.Tiles.Queries;
using Torens.Domain.ValueObjects;
using Torens.Infrastructure.Logging;

namespace Torens.Infrastructure
{
    public static class AutofacConfig
    {
        public static ContainerBuilder GetBuilder()
        {
            var applicationMarkerType = typeof(GetChangedTilesQuery);
            var domainMarkerType = typeof(GroundTypes);
            var mediatrModule = new MediatrModule(applicationMarkerType);
            var loggingModule = new Log4NetModule();

            var builder = new ContainerBuilder();
            builder.RegisterModule(mediatrModule);
            builder.RegisterModule(loggingModule);
            RegisterDomain(builder, applicationMarkerType, domainMarkerType);

            return builder;
        }

        private static void RegisterDomain(ContainerBuilder builder, params Type[] markerTypes)
        {
            var assemblies = markerTypes.Select(markerType => markerType.GetTypeInfo().Assembly).Distinct().ToArray();
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}