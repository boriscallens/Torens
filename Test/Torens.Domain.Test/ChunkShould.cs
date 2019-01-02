using System.Linq;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Domain.Test
{
    public class ChunkShould
    {
        [Fact]
        public void GiveItsTilePositions()
        {
            var chunk = new Chunk(ChunkPosition.Zero);
            const int halfSize = Chunk.Size/2;
            var expectedRange = Enumerable.Range(-halfSize, halfSize).ToList();

            var expectedPositions =
                from column in expectedRange
                from layer in expectedRange
                from row in expectedRange
                select new TilePosition(column, layer, row);
            var actualPositions = chunk.GetTilePositions();

            Assert.Equal(expectedPositions, actualPositions);

        }
    }
}
