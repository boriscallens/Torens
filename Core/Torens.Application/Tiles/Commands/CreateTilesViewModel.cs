using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Application.Tiles.Commands
{
    public class CreateTilesViewModel
    {
        public IEnumerable<Tile> Tiles { get; set; }
    }
}