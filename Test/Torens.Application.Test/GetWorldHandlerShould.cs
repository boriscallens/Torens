using System;
using System.Linq;
using System.Threading;
using MediatR;
using NSubstitute;
using Torens.Application.Chunks.Commands;
using Torens.Application.Worlds.Queries;
using Torens.Infrastructure;
using Xunit;

namespace Torens.Application.Test
{
    public class GetWorldHandlerShould
    {
        [Fact]
        public async void ReturnWorld()
        {
            var mediatr = new MediatrBuilder().Build();
            var qry = new GetWorldQuery();
            var handler = new GetWorldHandler(mediatr);

            var result = await handler.Handle(qry, CancellationToken.None);

            Assert.IsType<WorldViewModel>(result);
        }

        [Fact]
        public void GenerateTilesAccordingToDimensions()
        {
            var mediatr = new MediatrBuilder().Build();
            var qry = new GetWorldQuery
            {
                ChunkSize = 10,
                WorldSize = 10
            };
            var handler = new GetWorldHandler(mediatr);

            var result = handler.Handle(qry, CancellationToken.None).Result;

            var chunkCount = Math.Pow(qry.WorldSize, 3);
            var expectedTileCount = Math.Pow(qry.ChunkSize, 3) * chunkCount;

            Assert.Equal(result.Tiles.Count(), expectedTileCount);
        }
    }
}