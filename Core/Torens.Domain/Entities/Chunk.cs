using System.Collections;
using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    /// <summary>
    /// Holds a collection of tiles
    /// </summary>
    public class Chunk
    {
        public const int Size = 16;
        public ChunkPosition Position { get; }

        public Chunk(ChunkPosition position)
        {
            Position = position;
        }

        public IEnumerable<TilePosition> GetTilePositions()
        {
            throw new System.NotImplementedException();
        }
    }
}