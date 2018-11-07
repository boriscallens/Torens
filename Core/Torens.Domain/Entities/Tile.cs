using System;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    public class Tile
    {
        public Guid Id { get; private set; }
        public GroundTypes Type { get; private set; }
    }
}
