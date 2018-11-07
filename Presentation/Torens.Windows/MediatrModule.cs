using Autofac;
using MediatR;
using Torens.Application.Tiles.Queries;

namespace Torens.Presentation
{
    public class MediatrModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.Register<SingleInstanceFactory>(context =>
            {
                var ctx = context.Resolve<IComponentContext>();   // unsure why needed, but it works
                return t => ctx.TryResolve(t, out var o) ? o : null;
            }).InstancePerLifetimeScope();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(INotificationHandler<>),
            };

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(typeof(GetChangedTilesQuery).Assembly)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }
        }
    }
}