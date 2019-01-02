using System.Linq;
using System.Threading;
using FluentAssertions;
using Torens.Application.Tiles;
using Torens.Application.Tiles.Queries;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class GetTilesHandlerShould
    {
        [Fact]
        public async void ReturnInformationForEachPosition()
        {
            var positions = new[] { TilePosition.Zero };
            var repo = new TilesRepositoryBuilder()
                .WithTiles(GroundType.Dirt, positions)
                .Build();

            var qry = new GetTilesQuery(positions);
            var handler = new GetTilesHandler(repo);
            var result = await handler.Handle(qry, CancellationToken.None);
            var actualPositions = result.Select(item => item.Position);

            actualPositions.Should().BeEquivalentTo(positions);
        }

        [Fact]
        public async void SetFullVisibilityOnSingleTile()
        {
            var repo = new TilesRepositoryBuilder()
                .WithTiles(GroundType.Dirt, TilePosition.Zero)
                .Build();

            var qry = new GetTilesQuery(TilePosition.Zero);
            var handler = new GetTilesHandler(repo);
            var result = await handler.Handle(qry, CancellationToken.None);

            result.Single().Visibility.Should().HaveFlag(Direction.All);
        }

        [Fact]
        public async void OccludeInvisibleSides()
        {
            var left = TilePosition.Zero;
            var right = TilePosition.Zero.Right();
            
            var repo = new TilesRepositoryBuilder()
                .WithTiles(GroundType.Dirt, left, right)
                .Build();

            var qry = new GetTilesQuery(left, right);
            var handler = new GetTilesHandler(repo);
            var result = await handler.Handle(qry, CancellationToken.None);

            var leftInfo = result.Single(item => item.Position == left);
            var rightInfo = result.Single(item => item.Position == right);

            leftInfo.Visibility.Should().NotHaveFlag(Direction.Right);
            rightInfo.Visibility.Should().NotHaveFlag(Direction.Left);
        }
    }
}