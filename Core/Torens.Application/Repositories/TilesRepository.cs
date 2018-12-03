using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Torens.Application.Tiles.Commands;
using Torens.Domain;
using Torens.Domain.Entities;

namespace Torens.Application.Repositories
{
    public class TilesRepository : ITilesRepository
    {
        private readonly ITimeProvider _timeProvider;
        private readonly Dictionary<Guid, Tile> _tiles = new Dictionary<Guid, Tile>();

        public IDictionary<Guid, Tile> Tiles => _tiles;

        public TilesRepository(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public Task<List<Tile>> AddTiles(CreateTilesCommand command)
        {
            var now = _timeProvider.Now;
            var newTiles = command.TilePositions.Select(position => new Tile(
                    command.Chunk,
                    position,
                    now))
                .ToList();

            foreach (var newTile in newTiles)
            {
                _tiles.Add(newTile.Id, newTile);
            }

            return Task.FromResult(newTiles);
        }
    }
}
