using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class PositionShould
    {
        [Fact]
        public void DecrementColumnForLeft()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(-1, 0, 0);

            Assert.Equal(left, zero.Left());
        }

        [Fact]
        public void IncrementColumnForRight()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(1, 0, 0);

            Assert.Equal(left, zero.Right());
        }
        [Fact]
        public void DecrementRowForBack()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(0, 0, -1);

            Assert.Equal(left, zero.Back());
        }
        [Fact]
        public void IncrementRowForForward()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(0, 0, 1);

            Assert.Equal(left, zero.Front());
        }
        [Fact]
        public void DecrementLayerForBelow()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(0, -1, 0);

            Assert.Equal(left, zero.Below());
        }
        [Fact]
        public void IncrementLayerForAbove()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(0, 1, 0);

            Assert.Equal(left, zero.Above());
        }
    }
}