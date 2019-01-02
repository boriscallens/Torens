using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Torens.Application.Chunks.Commands;
using Torens.Application.Repositories;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class ChunkRepositoryShould
    {
        [Fact]
        public async void CreateChunks()
        {
            var repo = new ChunkRepository();
            var originPoints = new[] { TilePosition.Zero, new TilePosition(0, 0, 1) };
            var command = new CreateChunksCommand(originPoints);

            var chunk = await repo.AddChunks(command, CancellationToken.None);

            Assert.IsAssignableFrom<IEnumerable<Chunk>>(chunk);
        }

        //[Fact]
        //public async void CreateChunkWithCorrectPosition()
        //{
        //    var repo = new ChunkRepository();
        //    var position = ChunkPosition.Zero;
        //    var command = new CreateChunksCommand(position);

        //    var chunk = await repo.AddChunks(command, CancellationToken.None);

        //    Assert.Equal(position, chunk.Single().Origin);
        //}
    }
}