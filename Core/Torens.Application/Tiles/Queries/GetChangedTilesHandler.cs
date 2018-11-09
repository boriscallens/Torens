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
            var tiles = _tilesRepository.Tiles.Where(tile => request.TileIds.Contains(tile.Id) && tile.LastChanged >= lastChanged);

            return Task.FromResult(new TilesViewModel(tiles));
        }
    }
}