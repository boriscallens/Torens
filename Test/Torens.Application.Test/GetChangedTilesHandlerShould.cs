using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NSubstitute;
using Torens.Application.Repositories;
using Torens.Application.Tiles.Queries;
using Torens.Domain;
using Torens.Domain.Entities;
using Torens.Domain.ValueObjects;
using Xunit;

namespace Torens.Application.Test
{
    public class GetChangedTilesHandlerShould
    {
        [Fact]
        public void ReturnEmptyCollectionWhenNothingChanged()
        {
            var tileId = Guid.NewGuid();
            var timeSpan = TimeSpan.Zero;

            var tilesRepository = new TileRepositoryBuilder().Build();
            var timeProvider = Substitute.For<ITimeProvider>();

            var qry = new GetChangedTilesQuery(timeSpan, tileId);
            var handler = new GetChangedTilesHandler(tilesRepository, timeProvider);

            var result = handler.Handle(qry, CancellationToken.None).Result;

            Assert.Empty(result.Tiles);
        }

        [Fact]
        public void ReturnChangedTilesAccordingToIdsAndTimespan()
        {
            var tileId = Guid.NewGuid();
            var frameTimespan = TimeSpan.FromSeconds(1) / 60;
            var now = new DateTime(2000, 1, 1);
            var aFrameAgo = now - frameTimespan;

            var timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.Now.Returns(now);

            var tilesRepository = new TileRepositoryBuilder()
                .WithTile(tileId, aFrameAgo)
                .Build();

            var qry = new GetChangedTilesQuery(frameTimespan, tileId);
            var handler = new GetChangedTilesHandler(tilesRepository, timeProvider);

            var result = handler.Handle(qry, CancellationToken.None).Result;

            Assert.NotEmpty(result.Tiles);
        }

        [Fact]
        public void ReturnChangedTilesFast()
        {
            var frameTimespan = TimeSpan.FromSeconds(1) / 60;
            var now = new DateTime(2000, 1, 1);
            var aFrameAgo = now - frameTimespan;

            var tilesRepository = new TileRepositoryBuilder()
                .WithRandomTiles(1_000_000, aFrameAgo)
                .Build();
            var tileIds = tilesRepository.Tiles.Keys;

            var timeProvider = Substitute.For<ITimeProvider>();
            timeProvider.Now.Returns(now);
            
            var qry = new GetChangedTilesQuery(frameTimespan, tileIds.ToArray());
            var handler = new GetChangedTilesHandler(tilesRepository, timeProvider);

            var stopWatch = Stopwatch.StartNew();
            var result = handler.Handle(qry, CancellationToken.None).Result;
            stopWatch.Stop();

            var elapsedFrames = stopWatch.Elapsed / frameTimespan;
            Assert.True(elapsedFrames < 1, $"Handler took {elapsedFrames} frames");
        }
    }

    public class TileRepositoryBuilder
    {
        private readonly ITilesRepository _repo;
        private readonly Dictionary<Guid, Tile> _tiles = new Dictionary<Guid, Tile>();
        private readonly Chunk _nullChunk = new Chunk(new Position(), 1);

        public TileRepositoryBuilder()
        {
            _repo = Substitute.For<ITilesRepository>();
            _repo.Tiles.Returns(_tiles);
        }

        public ITilesRepository Build()
        {
            return _repo;
        }

        public TileRepositoryBuilder WithRandomTiles(int numberOfTiles, DateTime when)
        {
            var tileIds = Enumerable.Range(0, numberOfTiles).Select(ix => Guid.NewGuid());
            var newTiles = tileIds.Select(id => new Tile(id, _nullChunk, new Position(), when));

            foreach (var newTile in newTiles)
            {
                _tiles.Add(newTile.Id, newTile);
            }

            return this;
        }

        public TileRepositoryBuilder WithTile(Guid tileId, DateTime when)
        {
            _tiles.Add(tileId, new Tile(tileId, _nullChunk, new Position(), when));
            return this;
        }
    }
}
