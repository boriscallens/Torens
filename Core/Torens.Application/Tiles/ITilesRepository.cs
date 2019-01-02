using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles
{
    public interface ITilesRepository
    {
        IDictionary<TilePosition, GroundType> GetTileTypes(IEnumerable<TilePosition> positions);
    }
}