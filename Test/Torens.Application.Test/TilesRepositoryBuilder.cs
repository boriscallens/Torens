using System.Collections.Generic;
using NSubstitute;
using Torens.Application.Tiles;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Test
{
    public class TilesRepositoryBuilder
    {
        private readonly IDictionary<TilePosition, GroundType> _tiles = new Dictionary<TilePosition, GroundType>();
        public ITilesRepository Build()
        {
            var repo = Substitute
                .For<ITilesRepository>();

            repo.GetTileTypes(Arg.Any<IEnumerable<TilePosition>>())
                .Returns(ctx => _tiles);

            return repo;
        }

        public TilesRepositoryBuilder WithTiles(GroundType groundType, params TilePosition[] positions)
        {
            foreach (var position in positions)
            {
                _tiles.Add(position, groundType);
            }

            return this;
        }
    }
}