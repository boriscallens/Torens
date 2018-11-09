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
                game.Services.AddService(mediatr);
                game.Run();
            }
        }
    }
}
