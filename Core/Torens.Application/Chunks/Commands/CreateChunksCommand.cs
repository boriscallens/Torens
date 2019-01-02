using System.Collections.Generic;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Chunks.Commands
{
    public class CreateChunksCommand : IRequest<CreateChunksViewModel>
    {
        public CreateChunksCommand(params TilePosition[] chunkOrigins)
        {
            ChunkOrigins = chunkOrigins;
        }

        public TilePosition[] ChunkOrigins { get; }
    }
}