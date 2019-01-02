namespace Torens.Domain.ValueObjects
{
    public enum GroundType
    {
        Grass,
        Dirt,
        Air,
        Water
    }

    public static class GroundTypeExtensions
    {
        public static bool IsTransparent(this GroundType groundType)
        {
            return groundType == GroundType.Air || groundType == GroundType.Water;
        }
        public static bool IsInVisible(this GroundType groundType)
        {
            return groundType == GroundType.Air;
        }
        public static bool IsVisible(this GroundType groundType)
        {
            return !IsTransparent(groundType);
        }
    }
}