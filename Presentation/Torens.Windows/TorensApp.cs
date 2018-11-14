using Torens.Infrastructure;
using Xenko.Engine;

namespace Torens.Presentation
{
    class TorensApp
    {
        static void Main(string[] args)
        {
            var mediatr = new MediatrBuilder().Build();
            
            using (var game = new Game())
            {
                var tileFactory = new TileFactory(game.Services);
                game.Services.AddService(mediatr);
                game.Services.AddService(tileFactory);
                game.Run();
            }
        }
    }
}
