using System;
using System.Linq;
using FluentAssertions;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Domain.Test
{
    public class ChunkShould
    {
        [Fact]
        public void RequirePositiveDimensions()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, -1));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, 0, 0, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, -1, 2, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, 2, -1, 2));
            Assert.Throws<ArgumentOutOfRangeException>(() => new Chunk(TilePosition.Zero, 2, 2, -1));
        }

        [Fact]
        public void GiveOriginForChunkOfOne()
        {
            var origin = TilePosition.Unit;
            var chunk = new Chunk(origin, 1);

            var actual = chunk.GetPositions().Single();

            Assert.Equal(origin, actual);
        }

        [Fact]
        public void CalculatePositionsBasedOnOriginAndDimensions()
        {
            var origin = new TilePosition(1, 1, 1);
            var chunk = new Chunk(origin, 2);

            var expectedPositions =
                new[]
                {
                    new TilePosition(1, 1, 1),
                    new TilePosition(2, 1, 1),
                    new TilePosition(1, 2, 1),
                    new TilePosition(2, 2, 1),
                    new TilePosition(1, 1, 2),
                    new TilePosition(2, 1, 2),
                    new TilePosition(1, 2, 2),
                    new TilePosition(2, 2, 2)
                };
            var actualPositions = chunk.GetPositions().ToList();

            actualPositions.Should().BeEquivalentTo(expectedPositions);
        }
    }
}
