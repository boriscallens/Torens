using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    /// <summary>
    /// Holds a collection of tiles
    /// </summary>
    public class Chunk
    {
        public IEnumerable<Tile> Tiles { get; set; } = new List<Tile>();
        public Position Position { get; set; }

        public Chunk(Position position, int size){}
    }
}