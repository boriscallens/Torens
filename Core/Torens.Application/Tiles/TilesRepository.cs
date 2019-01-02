using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles
{
    public class TilesRepository: ITilesRepository
    {
        public IDictionary<TilePosition, GroundType> GetTileTypes(IEnumerable<TilePosition> positions)
        {
            throw new System.NotImplementedException();
        }
    }
}