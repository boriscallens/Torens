using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Domain
{
    public interface ITilesRepository
    {
        IEnumerable<Tile> Tiles { get; }
    }
}