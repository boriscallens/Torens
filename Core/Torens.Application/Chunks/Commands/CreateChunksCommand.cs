using System.Collections.Generic;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksCommand : IRequest<CreateChunksViewModel>
    {
        public CreateChunksCommand(params ChunkPosition[] chunkPositions)
        {
            ChunkPositions = chunkPositions;
        }

        public ChunkPosition[] ChunkPositions { get; }
    }
}