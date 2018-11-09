using System;
using System.Collections.Generic;
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

            var tilesRepository = Substitute.For<ITilesRepository>();
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

            var tilesRepository = Substitute.For<ITilesRepository>();
            var timeProvider = Substitute.For<ITimeProvider>();

            var now = new DateTime(2000, 1, 1);
            var aFrameAgo = now - frameTimespan;
            timeProvider.Now.Returns(now);

            var chunk = new Chunk(new Position(), 1);
            var tile = new Tile(tileId, chunk, new Position(), aFrameAgo);
            tilesRepository.Tiles.Returns(new[] { tile });

            var qry = new GetChangedTilesQuery(frameTimespan, tileId);
            var handler = new GetChangedTilesHandler(tilesRepository, timeProvider);

            var result = handler.Handle(qry, CancellationToken.None).Result;

            Assert.NotEmpty(result.Tiles);
        }
    }
}
