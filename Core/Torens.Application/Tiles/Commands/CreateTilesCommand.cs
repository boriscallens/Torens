using System.Collections.Generic;
using MediatR;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles.Commands
{
    public class CreateTilesCommand: IRequest<CreateTilesViewModel>
    {
        public Chunk Chunk { get; }
        public IEnumerable<Position> TilePositions { get; }

        public CreateTilesCommand(Chunk chunk, params Position[] tilePositions)
        {
            Chunk = chunk;
            TilePositions = tilePositions;
        }
    }
}