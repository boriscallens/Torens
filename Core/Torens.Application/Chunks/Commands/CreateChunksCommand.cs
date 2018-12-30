using System.Collections.Generic;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksCommand : IRequest<CreateChunksViewModel>
    {
        public CreateChunksCommand(params Position[] chunkPositions)
        {
            ChunkPositions = chunkPositions;
        }

        public IEnumerable<Position> ChunkPositions { get; }
    }
}