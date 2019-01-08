using System;

namespace Torens.Domain.ValueObjects
{
    [Flags]
    public enum Direction : uint
    {
        None = 1 << 0,
        Front = 1 << 1,
        Back = 1 << 2,
        Top = 1 << 3,
        Bottom = 1 << 4,
        Left = 1 << 5,
        Right = 1 << 6,
        All = Front | Back | Top | Bottom | Left | Right 
    }
}