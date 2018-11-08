using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core.Registration;
using MediatR;
using MediatR.Pipeline;

namespace Torens.Infrastructure
{
    public class MediatrModule : Module
    {
        public IEnumerable<Type> MarkerTypes { get; }

        public MediatrModule(params Type[] markerTypes)
        {
            MarkerTypes = markerTypes ?? new Type[0];
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(INotificationHandler<>)
            };
            var assemblies = MarkerTypes.Select(type => type.Assembly).Distinct().ToArray();

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(assemblies)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.Register(ResolveRequestHandlers);
        }

        private static ServiceFactory ResolveRequestHandlers(IComponentContext ctx)
        {
            var c = ctx.Resolve<IComponentContext>();
            return t =>
            {
                try { return c.Resolve(t); }
                catch (ComponentNotRegisteredException notRegisteredException)
                {
                    var requestTypeName = t.GenericTypeArguments[0].Name;
                    var responseTypeName = t.GenericTypeArguments[1].Name;
                    var msg = $"IRequestHandler<{requestTypeName}, {responseTypeName}>";
                    throw new NotImplementedException(msg, notRegisteredException);
                }
            };
        }
    }
}
