using System.Linq;
using MediatR;
using Torens.Application.Tiles.Queries;
using Xenko.Engine;
using Xenko.Games;

namespace Torens.Presentation
{
    public class TileProcessor: EntityProcessor<TileComponent>
    {
        private IMediator _mediator;

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = Services.GetService<IMediator>();
            Enabled = _mediator != null;
        }

        public override void Update(GameTime time)
        {
            var tilesById = this.ComponentDatas.Keys.ToDictionary(tile => tile.Id, tile => tile);
            var qry = new GetChangedTilesQuery(time.Elapsed, tilesById.Keys.ToArray());
            var tilesViewModel = _mediator.Send(qry);

            foreach (var tile in tilesViewModel.Tiles)
            {
                tilesById[tile.Id].Type = tile.Type;
                // TODO: switch models
            }
        }
    }
}