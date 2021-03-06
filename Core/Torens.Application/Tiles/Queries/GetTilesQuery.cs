﻿using System.Collections.Generic;
using MediatR;
using Torens.Domain.ValueObjects;

namespace Torens.Application.Tiles.Queries
{
    public class GetTilesQuery: IRequest<TileSet>
    {
        public IEnumerable<TilePosition> Positions { get; }

        public GetTilesQuery(params TilePosition[] positions)
        {
            Positions = positions;
        }
    }
}