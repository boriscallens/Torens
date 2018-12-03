//using System;
//using System.Threading;
//using BenchmarkDotNet.Attributes;
//using NSubstitute;
//using Torens.Application.Repositories;
//using Torens.Application.Tiles.Queries;
//using Torens.Domain;

//namespace Torens.Application.Test
//{
//    public class GetChangedTilesHandlerBenchmark
//    {
//        private GetChangedTilesHandler _handler;
//        private GetChangedTilesQuery _query;

//        [GlobalSetup]
//        public void Setup()
//        {
//            var tilesRepository = Substitute.For<ITilesRepository>();
//            var timeProvider = Substitute.For<ITimeProvider>();

//            var frameTimespan = TimeSpan.FromSeconds(1) / 60;
//            var now = new DateTime(2000, 1, 1);
//            var aFrameAgo = now - frameTimespan;
//            timeProvider.Now.Returns(now);

//            _handler = new GetChangedTilesHandler(tilesRepository, timeProvider);
//            _query = new GetChangedTilesQuery(frameTimespan, tileId);
//        }

//        [Benchmark]
//        public TilesViewModel Handle()
//        {
//            return _handler.Handle(_query, CancellationToken.None).Result;
//        }
//    }
//}