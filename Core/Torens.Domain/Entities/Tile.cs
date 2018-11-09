using System;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    public class Tile
    {
        public Tile(Chunk chunk, Position tilePosition, DateTime now):this(Guid.NewGuid(), chunk, tilePosition, now){}

        public Tile(Guid tileId, Chunk chunk, Position tilePosition, DateTime now)
        {
            Id = tileId;
            Position = tilePosition;
            Chunk = chunk;
            LastChanged = now;
        }

        public Chunk Chunk { get; set; }
        public Position Position { get; set; }
        public Guid Id { get; set; }
        public GroundTypes Type { get; set; }
        public DateTime LastChanged { get; set; }
    }
}
