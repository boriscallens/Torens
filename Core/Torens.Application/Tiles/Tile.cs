using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles
{
    public struct Tile
    {
        public TilePosition Position;
        public GroundType GroundType;
        public Direction Visibility { get; set; }
    }
}