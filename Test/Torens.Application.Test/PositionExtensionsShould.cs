using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class PositionExtensionsShould
    {
        [Fact]
        public void IncrementColumnForLeft()
        {
            var zero = TilePosition.Zero;
            var left = new TilePosition(-1, 0, 0);

            Assert.Equal(left, zero.Left());
        }
    }
}