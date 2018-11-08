using System;
using System.Collections.Generic;
using Torens.Domain;
using Torens.Domain.Entities;

namespace Torens.Application.Tiles
{
    public class TilesRepository : ITilesRepository
    {
        public IEnumerable<Tile> Tiles { get; }

        public TilesRepository(ITimeProvider timeProvider)
        {
            Tiles = new List<Tile> { new Tile { Id = Guid.NewGuid(), LastChanged = timeProvider.Now } };
        }
    }
}
