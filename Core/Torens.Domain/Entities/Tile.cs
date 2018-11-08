using System;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    public class Tile
    {
        public Guid Id { get; set; }
        public GroundTypes Type { get; private set; }
        public DateTime LastChanged { get; set; }
    }
}
