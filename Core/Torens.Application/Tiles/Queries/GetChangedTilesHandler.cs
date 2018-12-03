using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Application.Repositories;
using Torens.Domain;

namespace Torens.Application.Tiles.Queries
{
    public class GetChangedTilesHandler: IRequestHandler<GetChangedTilesQuery, TilesViewModel>
    {
        private readonly ITilesRepository _tilesRepository;
        private readonly ITimeProvider _timeProvider;

        public GetChangedTilesHandler(ITilesRepository tilesRepository, ITimeProvider timeProvider)
        {
            _tilesRepository = tilesRepository;
            _timeProvider = timeProvider;
        }

        public Task<TilesViewModel> Handle(GetChangedTilesQuery request, CancellationToken cancellationToken)
        {
            var lastChanged = _timeProvider.Now.Subtract(request.Since);

            var tiles = request.TileIds
                .Where(tileId => _tilesRepository.Tiles.ContainsKey(tileId))
                .Select(tileId => _tilesRepository.Tiles[tileId])
                .Where(tile => tile.LastChanged >= lastChanged)
                .ToList();

            return Task.FromResult(new TilesViewModel(tiles));
        }
    }
}