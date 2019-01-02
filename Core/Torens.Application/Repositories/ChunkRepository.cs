using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Torens.Application.Chunks.Commands;
using Torens.Domain.Entities;

namespace Torens.Application.Repositories
{
    public class ChunkRepository : IChunkRepository
    {
        private readonly List<Chunk> _chunks = new List<Chunk>();

        public IEnumerable<Chunk> Chunks => _chunks;

        public Task<List<Chunk>> AddChunks(CreateChunksCommand command, CancellationToken cancellationToken)
        {
            var newChunks = command.ChunkOrigins
                .Select(position => new Chunk(position))
                .ToList();

            _chunks.AddRange(newChunks);

            return Task.FromResult(newChunks);
        }
    }
}