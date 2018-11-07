using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Torens.Presentation;
using Xenko.Games;

namespace Torens.Game.Test
{
    [TestClass]
    public class TileComponentTest
    {
        private readonly IContainer _container;

        public TileComponentTest()
        {
            _container = BuildContainer();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var processor = new TileProcessor();

            var gameTime = new GameTime();

            processor.Update(gameTime);
        }


        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TileProcessor>().AsSelf();

            return builder.Build();
        }
    }
}
