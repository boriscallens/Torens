using System.Collections.Generic;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksCommand : IRequest<CreateChunksViewModel>
    {
        public CreateChunksCommand(int chunkSize, params Position[] chunkPositions)
        {
            ChunkSize = chunkSize;
            ChunkPositions = chunkPositions;
        }

        public int ChunkSize { get; }
        public IEnumerable<Position> ChunkPositions { get; }
    }
}