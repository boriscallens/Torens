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
        private readonly List<Tile> _tiles = new List<Tile>();

        public IEnumerable<Tile> Tiles => _tiles;

        public TilesRepository(ITimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public Task<List<Tile>> AddTiles(CreateTilesCommand command)
        {
            var newTiles = command.TilePositions.Select(position => new Tile(
                command.Chunk,
                position,
                _timeProvider.Now))
                .ToList();

            _tiles.AddRange(newTiles);

            return Task.FromResult(newTiles);
        }
    }
}
