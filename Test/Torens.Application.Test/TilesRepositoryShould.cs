using System;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using Torens.Application.Repositories;
using Torens.Application.Tiles.Commands;
using Torens.Domain;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class TilesRepositoryShould
    {
        [Fact]
        public async void AddTiles()
        {
            var timeProvider = Substitute.For<ITimeProvider>();
            var repo = new TilesRepository(timeProvider);

            var command = new CreateTilesCommand(new Chunk(new Position(), 10), new Position());
            var tile = await repo.AddTiles(command);

            Assert.IsType<Tile>(tile.Single());
        }

        [Fact]
        public async void AddTilesWithCorrectProperties()
        {
            var now = DateTime.Now;
            var timeProvider = Substitute.For<ITimeProvider>();
            var repo = new TilesRepository(timeProvider);
            timeProvider.Now.Returns(now);

            var chunk = new Chunk(new Position(0,0,0), 10);
            var tilePositions = new []{new Position(0,0,0), new Position(0,0,1)};
            var command = new CreateTilesCommand(chunk, tilePositions);
            var tiles = await repo.AddTiles(command);
            
            Assert.All(tiles, tile => tile.LastChanged.Equals(now));
            Assert.All(tiles, tile => tile.Chunk.Equals(chunk));

        }
    }
}