using Torens.Domain.ValueObjects;
using Xenko.Core.Mathematics;

namespace Torens.Game.Mesh
{
    public static class Vector3Extensions
    {
        public static Position ToPosition(this Vector3 value)
        {
            return new Position((int)value.X, (int)value.Y, (int)value.Z);
        }

        public static Vector3 ToVector3(this Position value)
        {
            return new Vector3(value.Column, value.Layer, value.Row);
        }
    }
}
