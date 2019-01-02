using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles.Queries
{
    public class GetTilesHandler: IRequestHandler<GetTilesQuery, TileSet>
    {
        private readonly ITilesRepository _tilesRepository;

        public GetTilesHandler(ITilesRepository tilesRepository)
        {
            _tilesRepository = tilesRepository;
        }

        public Task<TileSet> Handle(GetTilesQuery request, CancellationToken cancellationToken)
        {
            var tileSet = new TileSet();

            foreach (var position in request.Positions)
            {
                var left = position.Left();
                // _tilesRepository.GetTiles(tilePosition)
            }

            return Task.FromResult(tileSet);
        }
    }
}