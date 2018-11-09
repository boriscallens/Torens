using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    public class Chunk
    {
        public IEnumerable<Tile> Tiles { get; set; }
        public Position Position { get; set; }

        public Chunk(Position position, int size)
        {
            Tiles = new List<Tile>();
        }
    }
}