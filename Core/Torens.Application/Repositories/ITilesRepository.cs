using System.Collections.Generic;
using System.Threading.Tasks;
using Torens.Application.Tiles.Commands;
using Torens.Domain.Entities;

namespace Torens.Application.Repositories
{
    public interface ITilesRepository
    {
        IEnumerable<Tile> Tiles { get; }
        Task<List<Tile>> AddTiles(CreateTilesCommand command);
    }
}