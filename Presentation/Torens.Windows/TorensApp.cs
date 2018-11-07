using Autofac;
using MediatR;
using Xenko.Engine;

namespace Torens.Presentation
{
    class TorensApp
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            using (var game = new Game())
            {
                game.Services.AddService(container.Resolve<IMediator>());
                game.Run();
            }
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MediatrModule>();

            return builder.Build();
        }
    }
}
