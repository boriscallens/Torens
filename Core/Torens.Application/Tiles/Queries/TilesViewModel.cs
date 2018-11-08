using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Application.Tiles.Queries
{
    public class TilesViewModel
    {
        public TilesViewModel(IEnumerable<Tile> tiles)
        {
            Tiles = tiles;
        }

        public IEnumerable<Tile> Tiles { get; }
    }
}