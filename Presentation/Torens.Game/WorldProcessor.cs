using System.Linq;
using MediatR;
using Torens.Application.Worlds.Queries;
using Xenko.Core.Annotations;
using Xenko.Engine;

namespace Torens.Presentation
{
    public class WorldProcessor: EntityProcessor<WorldComponent>
    {
        private IMediator _mediator;
        private TileFactory _tileFactory;

        protected override void OnSystemAdd()
        {
            base.OnSystemAdd();
            _mediator = _mediator ?? Services.GetService<IMediator>();
            _tileFactory = _tileFactory?? Services.GetService<TileFactory>();
        }

        protected override void OnEntityComponentAdding(Entity entity, [NotNull] WorldComponent component, [NotNull] WorldComponent data)
        {
            base.OnEntityComponentAdding(entity, component, data);

            var getWorldQuery = new GetWorldQuery
            {
                WorldSize = component.WorldSize,
                ChunkSize = component.ChunkSize
            };
            var worldViewModel = _mediator.Send(getWorldQuery).GetAwaiter().GetResult();

            var tileEntities = worldViewModel.Tiles.Select(tile => _tileFactory.Create(tile)).ToList();
            
            foreach (var tile in tileEntities)
            {
                entity.AddChild(tile);
            }
        }
    }
}