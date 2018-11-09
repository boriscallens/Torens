using System.Collections.Generic;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    public class World
    {
        public Seed Seed { get; set; }
        public IEnumerable<Chunk> Chunks { get; set; }

        public World()
        {
            Seed = new Seed();

            var position = new Position();
            Chunks = new List<Chunk> {new Chunk(position, 0)};
        }
    }
}