﻿using System.Collections.Generic;
using Torens.Domain.Entities;

namespace Torens.Application.Worlds.Queries
{
    public class WorldViewModel
    {
        public IEnumerable<Tile> Tiles { get; set; }
    }
}