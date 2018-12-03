using Torens.Domain.ValueObjects;
using Xenko.Core.Mathematics;

namespace Torens.Presentation
{
    public static class Vector3Extensions
    {
        public static Position ToPosition(this Vector3 value){ 
            return new Position((int)value.X, (int)value.Y, (int)value.Z);
        }
    }
}
