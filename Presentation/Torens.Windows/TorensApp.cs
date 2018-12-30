using Torens.Infrastructure;

namespace Torens.Windows
{
    // ReSharper disable once ClassNeverInstantiated.Global
    class TorensApp
    {
        static void Main(string[] args)
        {
            var mediatr = new MediatrBuilder().Build();
            
            using (var game = new Xenko.Engine.Game())
            {
                //var chunkFactory = new ChunkFactory(game.Services);
                game.Services.AddService(mediatr);
                //game.Services.AddService(chunkFactory);
                game.Run();
            }
        }
    }
}
