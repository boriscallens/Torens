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
            var positions = new[] { new Position(0, 0, 0), new Position(0, 0, 1) };
            var command = new CreateChunksCommand(1, positions);

            var chunk = await repo.AddChunks(command, CancellationToken.None);

            Assert.IsAssignableFrom<IEnumerable<Chunk>>(chunk);
        }

        [Fact]
        public async void CreateChunkWithCorrectPosition()
        {
            var repo = new ChunkRepository();
            var position = new Position(0, 0, 0);
            var command = new CreateChunksCommand(1, position);

            var chunk = await repo.AddChunks(command, CancellationToken.None);

            Assert.Equal(position, chunk.Single().Position);
        }
    }
}