using System;
using System.Collections.Generic;

namespace Torens.Domain.ValueObjects
{
    public struct TilePosition : IEquatable<TilePosition>
    {
        public static TilePosition Zero => new TilePosition(0, 0, 0);
        public static TilePosition Unit => new TilePosition(1, 1, 1);

        public readonly int Column;
        public readonly int Layer;
        public readonly int Row;

        public TilePosition(int dimension) : this(dimension, dimension, dimension)
        {
        }
        public TilePosition(int column, int layer, int row)
        {
            Column = column;
            Layer = layer;
            Row = row;
        }

        public TilePosition Left()
        {
            return new TilePosition(Column - 1, Layer, Row);
        }
        public TilePosition Right()
        {
            return new TilePosition(Column + 1, Layer, Row);
        }
        public TilePosition Front()
        {
            return new TilePosition(Column, Layer, Row + 1);
        }
        public TilePosition Back()
        {
            return new TilePosition(Column, Layer, Row - 1);
        }
        public TilePosition Above()
        {
            return new TilePosition(Column, Layer + 1, Row);
        }
        public TilePosition Below()
        {
            return new TilePosition(Column, Layer - 1, Row);
        }
        public IDictionary<Direction, TilePosition> Neighbors()
        {
            return new Dictionary<Direction, TilePosition> {
                {Direction.Left, Left()},
                {Direction.Right, Right()},
                {Direction.Front, Front()},
                {Direction.Back, Back()},
                {Direction.Top, Above()},
                {Direction.Bottom, Below()}
            };
        }

        public bool Equals(TilePosition other)
        {
            return Column == other.Column && Layer == other.Layer && Row == other.Row;
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is TilePosition other && Equals(other);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Column;
                hashCode = (hashCode * 397) ^ Layer;
                hashCode = (hashCode * 397) ^ Row;
                return hashCode;
            }
        }
        public static bool operator ==(TilePosition left, TilePosition right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(TilePosition left, TilePosition right)
        {
            return !left.Equals(right);
        }


    }
}