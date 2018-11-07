using System;
using System.Collections.Generic;
using MediatR;

namespace Torens.Application.Tiles.Queries
{
    public class GetChangedTilesQuery:  IRequest<TilesViewModel>
    {
        private readonly IEnumerable<Guid> _tileIds;
        private readonly TimeSpan _time;

        public GetChangedTilesQuery(TimeSpan time, params Guid[] tileIds)
        {
            _tileIds = tileIds;
            _time = time;
        }
    }
}