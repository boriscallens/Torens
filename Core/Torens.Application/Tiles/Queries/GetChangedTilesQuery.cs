using System;
using System.Collections.Generic;
using MediatR;

namespace Torens.Application.Tiles.Queries
{
    public class GetChangedTilesQuery:  IRequest<TilesViewModel>
    {
        public IEnumerable<Guid> TileIds { get; }
        public TimeSpan Since { get; }

        public GetChangedTilesQuery(TimeSpan since, params Guid[] tileIds)
        {
            TileIds = tileIds;
            Since = since;
        }
    }
}