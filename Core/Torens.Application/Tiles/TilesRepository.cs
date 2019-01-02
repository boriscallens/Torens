using System.Collections.Generic;
using System.Linq;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles
{
    public class TilesRepository: ITilesRepository
    {
        public IDictionary<TilePosition, GroundType> GetTileTypes(IEnumerable<TilePosition> positions)
        {
            return positions.ToDictionary(pos => pos, pos => GroundType.Dirt);
        }
    }
}