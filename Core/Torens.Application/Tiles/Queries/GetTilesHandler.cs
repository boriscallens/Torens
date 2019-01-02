using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Torens.Domain.ValueObjects;
using EnumsNET;

namespace Torens.Application.Tiles.Queries
{
    public class GetTilesHandler : IRequestHandler<GetTilesQuery, TileSet>
    {
        private readonly ITilesRepository _tilesRepository;

        public GetTilesHandler(ITilesRepository tilesRepository)
        {
            _tilesRepository = tilesRepository;
        }

        public Task<TileSet> Handle(GetTilesQuery request, CancellationToken cancellationToken)
        {
            var groundTypes = _tilesRepository.GetTileTypes(request.Positions);
            var tileInfos = groundTypes.Keys.Select(pos => new Tile
            {
                Position = pos,
                GroundType = groundTypes[pos],
                Visibility = GetVisibilityMask(pos, groundTypes)
            });

            var tileSet = new TileSet(tileInfos);
            return Task.FromResult(tileSet);
        }

        private static Direction GetVisibilityMask(TilePosition position, IDictionary<TilePosition, GroundType> groundTypes)
        {
            if (!groundTypes.ContainsKey(position)) return Direction.None;
            if (groundTypes[position].IsInVisible()) return Direction.None;

            return position.Neighbors()
                .Where(dirAndPos => !HasVisibleNeighbor(groundTypes, dirAndPos.Value))
                .Aggregate(Direction.None, (prev, next) => prev.CombineFlags(next.Key));
        }

        private static bool HasVisibleNeighbor(IDictionary<TilePosition, GroundType> groundTypes, TilePosition position)
        {
            return groundTypes.ContainsKey(position) && groundTypes[position].IsVisible();
        }
    }
}