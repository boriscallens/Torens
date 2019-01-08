using System;
using System.Collections.Generic;
using System.Linq;
using Paravaly;
using Torens.Domain.ValueObjects;

namespace Torens.Domain.Entities
{
    /// <summary>
    /// Holds a collection of tiles
    /// </summary>
    public struct Chunk : IEquatable<Chunk>
    {
        private readonly int _columns;
        private readonly int _layers;
        private readonly int _rows;
        public TilePosition Origin { get; }

        public Chunk(TilePosition origin, int dimensions) : this(origin, dimensions, dimensions, dimensions)
        {
        }

        public Chunk(TilePosition origin, int columns = 16, int layers = 16, int rows = 16)
        {
            Require
                .Parameter(nameof(columns), columns).IsGreaterThan(0)
                .AndParameter(nameof(layers), layers).IsGreaterThan(0)
                .AndParameter(nameof(rows), rows).IsGreaterThan(0);

            _columns = columns;
            _layers = layers;
            _rows = rows;

            Origin = origin;
        }

        public IEnumerable<TilePosition> GetPositions()
        {
            var tmpThis = this; // weird?!

            return from column in Enumerable.Range(tmpThis.Origin.Column, tmpThis._columns)
                   from layer in Enumerable.Range(tmpThis.Origin.Layer, tmpThis._layers)
                   from row in Enumerable.Range(tmpThis.Origin.Row, tmpThis._rows)
                   select new TilePosition(column, layer, row);
        }

        public bool Equals(Chunk other)
        {
            return Origin.Equals(other.Origin);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Chunk other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Origin.GetHashCode();
        }

        public static bool operator ==(Chunk left, Chunk right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Chunk left, Chunk right)
        {
            return !left.Equals(right);
        }
    }
}