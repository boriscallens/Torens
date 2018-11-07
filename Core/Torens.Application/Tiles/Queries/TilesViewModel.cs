using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Application.Tiles.Queries
{
    public class TilesViewModel
    {
        public IEnumerable<Tile> Tiles { get; } = new List<Tile>();
    }
}