using System.Linq;
using System.Threading;
using NSubstitute;
using Torens.Application.Tiles;
using Torens.Application.Tiles.Queries;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class GetTilesHandlerShould
    {
        [Fact]
        public void ReturnTilesAroundPosition()
        {
            var repo = Substitute.For<ITilesRepository>();

            const int halfSize = Chunk.Size/2;
            var expectedRange = Enumerable.Range(-halfSize, halfSize).ToList();
            var expectedPositions =
                from column in expectedRange
                from layer in expectedRange
                from row in expectedRange
                select new TilePosition(column, layer, row);

            
            var qry = new GetTilesQuery(expectedPositions);
            var handler = new GetTilesHandler(repo);
            var result = handler.Handle(qry, CancellationToken.None);
        }
    }
}