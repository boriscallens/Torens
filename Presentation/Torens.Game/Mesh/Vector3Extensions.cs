using Torens.Domain.ValueObjects;
using Xenko.Core.Mathematics;

namespace Torens.Game.Mesh
{
    public static class Vector3Extensions
    {
        public static TilePosition ToPosition(this Vector3 value)
        {
            return new TilePosition((int)value.X, (int)value.Y, (int)value.Z);
        }

        public static Vector3 ToVector3(this TilePosition value)
        {
            return new Vector3(value.Column, value.Layer, value.Row);
        }

        public static TilePosition ToPosition(this Int3 value)
        {
            return new TilePosition(value.X, value.Y, value.Z);
        }

        public static Vector3 ToVector3(this Int3 value)
        {
            return new Vector3(value.X, value.Y, value.Z);
        }
    }
}
