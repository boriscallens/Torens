using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    /// <summary>
    /// Holds a collection of tiles
    /// </summary>
    public class Chunk
    {
        public Position Position { get; set; }

        public Chunk(Position position){}
    }
}