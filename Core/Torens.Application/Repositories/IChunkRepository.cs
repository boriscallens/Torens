using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Torens.Application.Chunks.Commands;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Repositories
{
    public interface IChunkRepository
    {
        Task<List<Chunk>> AddChunks(CreateChunksCommand command, CancellationToken cancellationToken);
    }
}